using Common.Models;
using UIAdmin.Helpers;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class AddUserToSiteControl : UserControl
    {
        #region Members
        private string _currentSite;
        private static readonly string _messageErrorUser = "User can't be empty";
        private static Serilog.ILogger Log => Serilog.Log.ForContext<AddUserToSiteControl>();
        private const ViewAlter _currentVewAlert = ViewAlter.AddUserToSite;
        private FormAlter _parrent;
        #endregion
        public AddUserToSiteControl(FormAlter parrent, string currentSite)
        {
            _parrent = parrent;
            _currentSite = currentSite;
            InitializeComponent();
            CreateUsersList();
            _parrent.BtnOkClicked += SaveData;
        }
        #region Private Methods

        private async Task<List<UserUniqueResponse>> GetUsersList()
        {
            var usersResult = await RestHelper.Instance.GetUniqUsersByName();
            if (!string.IsNullOrEmpty(usersResult.Item2))
            {
                FormAlter.AlterStatusMessage(false, usersResult.Item2);
                return null;
            }
            List<UserUniqueResponse> usersAll = usersResult.Item1;
            var usersForSiteResult =  await RestHelper.Instance.GetUsersBySyte(_currentSite);
            if (!string.IsNullOrEmpty(usersForSiteResult.Item2))
            {
                FormAlter.AlterStatusMessage(false, usersForSiteResult.Item2);
                return null;
            }
            List<UserResponse> usersForSite = usersForSiteResult.Item1;
            return usersAll?.Where(s => !usersForSite.Any(s2 => s2?.UserName == s?.UserName))?.ToList();         
        }
        private async Task CreateUsersList()
        {
            cmbUser.DisplayMember = "Text";
            cmbUser.ValueMember = "Value";
            var users = await GetUsersList();
            if (users == null) 
            {
                return;
            }
            foreach (var user in users.OrderBy( x=>x.UserName))
            {
                cmbUser.Items.Add(user.UserName);
            }
        }
        private bool Validation()
        {
            return Helper.ValidateControlIsEmpty(epAddUserToSite, cmbUser, _messageErrorUser);
        }

        private async Task SaveData(ViewAlter alertType)
        {
            if (alertType != _currentVewAlert)
            {
                return;
            }

            if (!Validation())
            {
                return;
            }
            var result = await RestHelper.Instance.AddSiteToUser(new Common.Models.AddSiteToUserRequest
            {
                UserName = cmbUser.Text,
                Site = _currentSite
            });
            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormAlter.AlterStatusMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormAlter.AlterStatusMessage(false, "Add site to user failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "Add site to user success");
            FormAlter.DataChanged(TypeAlter.SyteOnlyUserList,null);
            _parrent.Close();
        }

        #endregion

        #region Event Handlers
         
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epAddUserToSite, cmbUser, _messageErrorUser);
        }
        #endregion     
    }
}

