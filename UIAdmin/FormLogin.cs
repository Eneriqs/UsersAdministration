using Serilog;
using UIAdmin.Helpers;

namespace UIAdmin
{
    public partial class FormLogin : Form
    {
        #region Members
        private static readonly string _messageErrorUserName = "User Name can't be empty";
        private static readonly string _messageErrorPassword = "Password can't be empty";
        private static Serilog.ILogger Log => Serilog.Log.ForContext<FormLogin>();
        #endregion

        #region Constructor
        public FormLogin()
        {
            InitializeComponent();
            this.ActiveControl = txtUserName;
            txtUserName.Focus();
        }
        #endregion

        #region Private Methods
        private bool Validation()
        {
            bool res = true;
            res = Helper.ValidateControlIsEmpty(epLogin, txtUserName, _messageErrorUserName);
            res = Helper.ValidateControlIsEmpty(epLogin, txtPassword, _messageErrorPassword) && res;
             return res;
        }
        #endregion

        #region Event Handlers
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            if (!Validation()) 
            {
                btnLogin.Enabled = true;
                return;
            }
            var login = await RestHelper.Instance.Login(new Common.AuthenticateRequest()
                                        {
                                            UserName = txtUserName.Text,
                                            Password = txtPassword.Text
                                        }
                    );
            if (login.Item1 == null) 
            {
                Log.Here().Warning($"Login failed user:{ txtUserName.Text}");
                lblErrorLogin.Text = login.Item2;
                lblErrorLogin.Visible = true;
                btnLogin.Enabled = true;
                return;
            }
            else
            {
                lblErrorLogin.Text = "";
                lblErrorLogin.Visible = false;
            }
            Log.Here().Information($"Login user:{ txtUserName.Text}");
            var frm = new FormGeneral(this);
            frm.Show();
            this.Hide();
        }
       

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epLogin, txtUserName, _messageErrorUserName);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epLogin, txtPassword, _messageErrorPassword);
        }
        #endregion

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }
    }
}
