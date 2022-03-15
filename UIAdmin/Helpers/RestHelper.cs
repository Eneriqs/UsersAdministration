using Common;
using Common.Models;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace UIAdmin.Helpers
{
   
    internal class RestHelper : IRestHelper
    {
        #region Private Methods
        HttpClient _client = null;
        private static readonly string _baseURL = ConfigurationSettings.AppSettings.Get("urlServer");
        public static RestHelper _instance = null;
        private static readonly object _instanceLock = new object();
        private static ILogger Log => Serilog.Log.ForContext<RestHelper>();
        private TimeSpan _requestTimeout = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationSettings.AppSettings.Get("requestTimeoutSec")));
        #endregion
        #region Constructors
        private RestHelper()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMinutes(20);
        }
        public static RestHelper Instance
        {
            get{
                if(_instance == null)
                {
                    lock (_instanceLock)
                    {
                        _instance = new RestHelper();
                    }
                }
                return _instance;
                }
        }
        #endregion

        #region Private Methods
        private void AssignToken(string token)
        {
            if (_client != null && !string.IsNullOrEmpty(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);
        }
        private void LogRequest(Dictionary<string, string> request) {
            foreach (var kvp in request)
            {
                if (!kvp.Key.Equals("AuthPwrd") && (!kvp.Key.Equals("Password"))) {
                    Log.Here().Information($" {kvp.Key} : {kvp.Value} ");
                }
            }        
        }
        private string CheckResponse(HttpResponseMessage response) {
            string errorMessage = "";
            if (response.StatusCode == HttpStatusCode.OK) {
                Log.Here().Information("Success Status Code");
                return errorMessage;
            }
            Log.Here().Warning($"Error Status Code {response.StatusCode}");
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                errorMessage = "Session Expired. Please close the application and reconnect";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                errorMessage = "Invalid parameter";
            }
            else 
            {
                errorMessage = "Error Status Code";               
            } 
            Log.Here().Error(errorMessage);
            return errorMessage;
        }
        #endregion

        #region IRestHelper
        #region Authenticate
        public async Task<Tuple<AuthenticateResponse, string>> Login(AuthenticateRequest authenticateRequest)
        {
            AuthenticateResponse authenticateResponse = null;
            string result = string.Empty;
            string url = $"{Helper.UrlPathCombine(_baseURL, ProjectConstance.Authenticate)}?UserName={authenticateRequest.UserName}&Password={authenticateRequest.Password}";
            var stopwatch = Stopwatch.StartNew();
            Log.Here().Information($"Call :{ url}");
            var _logiTimeOut = TimeSpan.FromSeconds(30);
            try
            {
                using (var tokenSource = new CancellationTokenSource(_logiTimeOut))
                using (HttpResponseMessage response = await _client.GetAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                authenticateResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(data);
                                AssignToken(authenticateResponse.Token);
                            }
                            Log.Here().Information("Success Status Code");
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            result = "User Name or password incorrect";
                            Log.Here().Warning($"{result} {authenticateRequest.UserName}");
                        }
                        else 
                        {
                            result = "Login problem";
                            Log.Here().Error("Error Status Code");
                        }
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";               
            }           
            catch (Exception ex)
            {
                result = "Login problem.Please reconnect";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<AuthenticateResponse, string>(authenticateResponse, result);
        }
        #endregion

        #region Get
        public async Task<Tuple<List<UserResponse>, string>> GetUsersBySyte(string site)
        {
            List<UserResponse>  users= null;
            string url = $"{Helper.UrlPathCombine(_baseURL,ProjectConstance.GetUsersBySite)}{site}";
            string result = string.Empty;
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.GetAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                users = JsonConvert.DeserializeObject<List<UserResponse>>(data);
                            }                           
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Get Users List By Syte failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<List<UserResponse>, string>(users, result);
        }

        public async Task<Tuple<List<UserInfo>, string>> GetUserByName(string userName)
        {
            List<UserInfo> users = null;
            string result = string.Empty;
            string urlBase = Helper.UrlPathCombine(_baseURL,ProjectConstance.GetUserByName);
            string url =string.IsNullOrEmpty(userName) ? urlBase : $"{urlBase}{userName}";
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.GetAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                users = JsonConvert.DeserializeObject<List<UserInfo>>(data);
                            }                            
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "GetUsers List  By Name  failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }

            return new Tuple<List<UserInfo>, string>(users, result);
        }      
      

        public async Task<Tuple<List<UserUniqueResponse>, string>> GetUniqUsersByName(string userName = "")
        {
            List<UserUniqueResponse> users = null;
            string result = string.Empty;
            string urlBase = Helper.UrlPathCombine(_baseURL,ProjectConstance.GetUniqUsersByName);
            string url = string.IsNullOrEmpty(userName) ? urlBase : $"{urlBase}?userName={userName}";
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.GetAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                users = JsonConvert.DeserializeObject<List<UserUniqueResponse>>(data);
                            }                           
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Get Unique Users list failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<List<UserUniqueResponse>, string>(users, result);
        }       

        public async Task<Tuple<List<string>, string>> GetSites(string siteName="")
        {
            List<string> sites = null;
            string result = string.Empty;
            string urlBase = Helper.UrlPathCombine(_baseURL,ProjectConstance.Sites);
            string url = (!string.IsNullOrEmpty(siteName)) ? $"{urlBase}?siteName={siteName}" : urlBase;
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.GetAsync(url,tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                sites = JsonConvert.DeserializeObject<List<string>>(data);
                            }                          
                        }
                        result = CheckResponse(response);                        
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Get Sites list failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<List<string>, string> (sites, result);
        }
       
        #endregion

        #region Alter
        public async Task<Tuple<bool, string>> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            string result= string.Empty;
            bool resultAlter = false;
            string url =  Helper.UrlPathCombine(_baseURL,ProjectConstance.UpdatePassword);
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
               // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(telemetry), Encoding.UTF8);
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Create the request data.
                var requestData = new Dictionary<string, string>();
                requestData["UserName"] = updatePasswordRequest.UserName;
                requestData["AuthName"] = updatePasswordRequest.AuthName;
                requestData["Password"] = updatePasswordRequest.Password;
                LogRequest(requestData);
                var data = JsonConvert.SerializeObject(requestData);
                var requestDatagContent = new StringContent(data, Encoding.UTF8, "application/json");
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.PostAsync(url, requestDatagContent, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultAlter = JsonConvert.DeserializeObject<bool>(dataResponse);
                            }                           
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Update password failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return  new Tuple<bool, string>(resultAlter, result);
        }
        public async Task<Tuple<bool, string>> CreateUser(CreateUserRequest createUserRequest)
        {
            Tuple<bool, string> resultAlter = new Tuple<bool, string>(false, "") ;
            string result = string.Empty;
            string url = Helper.UrlPathCombine(_baseURL, ProjectConstance.CreateUser);
            Log.Here().Information($"Call :{ url}"); 
            var stopwatch = Stopwatch.StartNew();
            try
            {              
                _client.DefaultRequestHeaders.Accept.Clear();
                // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(telemetry), Encoding.UTF8);
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Create the request data.
                var requestData = new Dictionary<string, string>();
                requestData["UserName"] = createUserRequest.UserName;
                requestData["AuthName"] = createUserRequest.AuthName;
                requestData["AuthPwrd"] = createUserRequest.AuthPwrd;
                requestData["Site"] = createUserRequest.Site;
                requestData["AppRole"] = createUserRequest.AppRole.ToString();
                LogRequest(requestData);
                var data = JsonConvert.SerializeObject(requestData);
                var requestDatagContent = new StringContent(data, Encoding.UTF8, "application/json");
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.PostAsync(url, requestDatagContent, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultAlter = JsonConvert.DeserializeObject<Tuple<bool, string>>(dataResponse);
                            }
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Create user failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultAlter.Item1, result);
        }

        public async Task<Tuple<bool, string>> AddSiteToUser(AddSiteToUserRequest addSiteToUserRequest)
        {
            bool resultAlter = false;
            string result = string.Empty;
            string url = Helper.UrlPathCombine(_baseURL,ProjectConstance.AddSiteToUser);
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(telemetry), Encoding.UTF8);
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Create the request data.
                var requestData = new Dictionary<string, string>();
                requestData["UserName"] = addSiteToUserRequest.UserName;
                requestData["Site"] = addSiteToUserRequest.Site;
                LogRequest(requestData);
                var data = JsonConvert.SerializeObject(requestData);
                var requestDatagContent = new StringContent(data, Encoding.UTF8, "application/json");
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.PostAsync(url, requestDatagContent,tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultAlter = JsonConvert.DeserializeObject<bool>(dataResponse);
                            }
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Add site to user failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultAlter, result);
        }
       
        public async Task<Tuple<bool, string>> UpdateUser(UpdateUserRequest updateUserRequest)
        {
            Tuple<bool, string> resultAlter = new Tuple<bool, string>(false, "");
            string result = string.Empty;
            string url = Helper.UrlPathCombine(_baseURL,ProjectConstance.UpdateUser);
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", sBToken);
                //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(telemetry), Encoding.UTF8);
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Create the request data.
                var requestData = new Dictionary<string, string>();
                requestData["id"] = updateUserRequest.Id;
                requestData["site"] = updateUserRequest.Site;
                requestData["userName"] = updateUserRequest.UserName;
                requestData["authName"] = updateUserRequest.AuthName;
                requestData["appRole"] =updateUserRequest.AppRole.ToString();
                LogRequest(requestData);
                var data = JsonConvert.SerializeObject(requestData);
                var requestDatagContent = new StringContent(data, Encoding.UTF8, "application/json");
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.PostAsync(url, requestDatagContent, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultAlter = JsonConvert.DeserializeObject <Tuple<bool, string>> (dataResponse);
                            }
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Update user failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultAlter.Item1, result);
        }

        public async Task<Tuple<bool, string>> DeleteUser(string userName)
        {
            string result = string.Empty;
            bool resultAlter = false;
            string url = $"{Helper.UrlPathCombine(_baseURL,ProjectConstance.DeleteUser)}/{userName}";
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.DeleteAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            resultAlter = JsonConvert.DeserializeObject<bool>(dataResponse);                          
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Delete user failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultAlter, result);
        }

        public async Task<Tuple<bool, string>> DeleteSiteForUser(string id, string site)
        {
            string result = string.Empty;
            bool resultAlter = false;
            string url = $"{Helper.UrlPathCombine(_baseURL,ProjectConstance.DeleteUser)}/{id}/{site}";
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                using (var tokenSource = new CancellationTokenSource(_requestTimeout))
                using (HttpResponseMessage response = await _client.DeleteAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            resultAlter = JsonConvert.DeserializeObject<bool>(dataResponse);                          
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "Delete  site from user failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultAlter, result);
        }
        #endregion

        #region Maintenances
        public async Task<Tuple<bool, string>> ExportDBToFile()
        {
            string result = string.Empty;
            bool resultExport = false;
            string url =  Helper.UrlPathCombine(_baseURL,ProjectConstance.ExportDBToFile);
            Log.Here().Information($"Call :{ url}");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultExport = JsonConvert.DeserializeObject<bool>(data);                              
                            }                           
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Check data and try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "DB Import failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultExport, result);
        }

        public async Task<Tuple<bool, string>> ImportDBFromFile()
        {
            string result = string.Empty;
            bool resultImport = false;
            string url = Helper.UrlPathCombine(_baseURL,ProjectConstance.ImportDBFromFile);
            Log.Here().Information($"Call :{ url}");
            TimeSpan importTimeout = TimeSpan.FromSeconds(30);
            var stopwatch = Stopwatch.StartNew();
            try
            {
                using (var tokenSource = new CancellationTokenSource(importTimeout))
                using (HttpResponseMessage response = await _client.GetAsync(url, tokenSource.Token))
                {
                    using (HttpContent content = response.Content)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                resultImport= JsonConvert.DeserializeObject<bool>(data);
                            }                          
                        }
                        result = CheckResponse(response);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                result = "Timeout. Please try again";
                Log.Here().Error($"Timeout after {stopwatch.Elapsed}");
            }
            catch (HttpRequestException ex)
            {
                Log.Here().Warning(ex.Message);
                result = (((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode == 10061) ? "Server does not respond" : "Server connection problem";
            }
            catch (Exception ex)
            {
                result = "DB Import failure";
                Log.Here().Error($"Error :{ url}", ex.Message);
            }
            return new Tuple<bool, string>(resultImport, result);
        }
        #endregion
        #endregion

    }
}
