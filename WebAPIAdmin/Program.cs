using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using WebAPIAdmin.Helpers;
using WebAPIAdmin.Interfaces;
using WebAPIAdmin.Models;
using WebAPIAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

var logger = new Serilog.LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
               // .WriteTo.AzureTableStorage(connectionString, LogEventLevel.Information)
                .Enrich.FromLogContext()
                .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
Log.Logger = logger;
builder.Services.AddCors();

builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IDBProvider, CosmosProvider>();
builder.Services.AddSingleton<IDataService, DataService>();


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.IgnoreNullValues = true;
}); 

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

LoginInfo loginInfo = builder.Configuration.GetSection("Settings:Login").Get<LoginInfo>();



//IServiceCollection serviceCollection = builder.Services.AddSingleton<IDataService, DataService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCodeBuzz-Service", Version = "v1" });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>(loginInfo.Secret);

app.MapControllers();

app.Run();
