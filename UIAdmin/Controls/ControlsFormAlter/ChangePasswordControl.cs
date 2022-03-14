using UIAdmin.Helpers;
using Common;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class ChangePasswordControl : UserControl
    {
        #region Members
        private UserInfo _currentUser;
        private static readonly string _messageErrorPasswordTextBox = "New Password can't be empty";
        private static readonly string _messageErrorConfirationTextBox = "Confirmation Password  can't be empty";
        private static readonly string _messageErrorConfiration = "New Password should be equal to Confirmation Password";
        private const ViewAlter _currentVewAlert = ViewAlter.ChangePassword;
        private FormAlter _parrent;
        #endregion
        public ChangePasswordControl(FormAlter parrent,  UserInfo currentUser)
        {
            _currentUser = currentUser;
            _parrent = parrent;
            InitializeComponent();
            _parrent.BtnOkClicked += SaveNewPassword;          
        }
        #region Private Methods
        private bool CheckPassword() {
            bool res = true;
            res = Helpers.Helper.ValidateControlIsEmpty(epChangePassword, txtNewPassword, _messageErrorPasswordTextBox);
            res = Helpers.Helper.ValidateControlIsEmpty(epChangePassword, txtConfirmPassword, _messageErrorConfirationTextBox) && res;
            if (!res)
            {
                return false;
            }
            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                epChangePassword.SetError(txtConfirmPassword, _messageErrorConfiration);
                res = false;
            }
            return res;
        }

        private async Task SaveNewPassword(ViewAlter alertType)
        {
            if (alertType != _currentVewAlert)
            {
                return;
            }
            if (!CheckPassword())
            {
                return;
            }
            var result = await RestHelper.Instance.UpdatePassword(new Common.Models.UpdatePasswordRequest
            {
                UserName = _currentUser.UserName,
                Password = txtNewPassword.Text,
                AuthName =_currentUser.AuthName,
            });
            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormAlter.AlterStatusMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormAlter.AlterStatusMessage(false, "Update password failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "Success");
            FormAlter.DataChanged(TypeAlter.Empty, null);
            _parrent.Close();
        }

        #endregion

        #region Event Handlers
        #endregion

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            Helpers.Helper.ValidateControlIsEmpty(epChangePassword, txtNewPassword, _messageErrorPasswordTextBox);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            Helpers.Helper.ValidateControlIsEmpty(epChangePassword, txtConfirmPassword, _messageErrorConfirationTextBox);
        }
    }
}

