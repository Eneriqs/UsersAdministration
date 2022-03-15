using Common;
using System.Data;
using System.Runtime.Serialization;
using UIAdmin.Helpers;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class CreateUserControl : UserControl
    {
        #region Members
        private static readonly string _messageErrorUserName = "User Name can't be empty";
        private static readonly string _messageErrorPassword = "Password  can't be empty";
        private static readonly string _messageErrorEmail = "Email can't be empty";
        private static readonly string _messageErrorSite = "Site can't be empty";
        private static readonly string _messageErrorRole = "Role can't be empty";
        private static readonly string _newItemSiteText = "New Site";
        private bool _enabledValidateSiteIsChanged = false;
        private const ViewAlter _currentVewAlert = ViewAlter.CreateUser;
        private List<string> _sites;
        private static Serilog.ILogger Log => Serilog.Log.ForContext<CreateUserControl>();
        private FormAlter _parrent;

        #endregion
        #region Constructor

        public CreateUserControl(FormAlter parrent, List<string> sites)
        {
            _parrent = parrent;
            _sites = sites;
            InitializeComponent(); 
            ControlInit();
           _parrent.BtnOkClicked += CreateUser;          
        }
        #endregion 
        #region Private Methods
        private void ControlInit()
        {
            CreateUserRole();
            CreateSite();          
        }

        private void CreateUserRole() {
            cmbRole.DisplayMember = "Text";
            cmbRole.ValueMember = "Value";
            List<UserRole> roles = Enum.GetValues(typeof(UserRole))
            .Cast<UserRole>()
            .Select(v => v)
            .ToList();
            foreach (UserRole role in roles) {
                string roleName = Helper.GetAttributeOfType<EnumMemberAttribute>(role).Value;
                cmbRole.Items.Add(new ComboboxItem { Text = roleName, Value = role });             
            }
        }
        private async Task CreateSite()
        {
            cmbSite.Items.Add(_newItemSiteText);                  
            if(_sites == null)
            {
                Log.Here().Warning("Sites list is empty");
                return;
            }
            foreach (string site in _sites)
            {
               cmbSite.Items.Add(site);
            }
        }


        private bool Validation() {
            bool res = true;
            _enabledValidateSiteIsChanged = true;
            res = Helper.ValidateControlIsEmpty(epCreateUser, txtUserName, _messageErrorUserName);
            res = Helper.ValidateControlIsEmpty(epCreateUser, txtAuthPwrd, _messageErrorPassword) && res;
            res = Helper.ValidateControlIsEmpty(epCreateUser, txtAuthName, _messageErrorEmail) && res;
            res = Helper.ValidateControlIsEmpty(epCreateUser, cmbSite, _messageErrorSite, _newItemSiteText) && res;
            res = Helper.ValidateControlIsEmpty(epCreateUser, cmbRole, _messageErrorRole) && res;
            return res;
        }

        private async Task CreateUser(ViewAlter alertType)
        {
            if (alertType != _currentVewAlert) 
            {
                return;
            }
            if (!Validation())
            {
                return;
            }
            ComboboxItem roleItem = cmbRole.SelectedItem as ComboboxItem;
            if (roleItem == null) {
                MessageBox.Show("Invalid Role");
                return;
            }
            var result = await RestHelper.Instance.CreateUser(new Common.Models.CreateUserRequest
            {
                UserName = txtUserName.Text,
                AuthPwrd = txtAuthPwrd.Text,
                AuthName = txtAuthName.Text,
                Site = cmbSite.Text,
                AppRole = Helper.ParseEnum<UserRole>(roleItem.Value.ToString())
            });
            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormAlter.AlterStatusMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormAlter.AlterStatusMessage(false, "Create user failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "Success");

            UserInfo currectUser = new UserInfo()
            {
                AppRole = Helper.ParseEnum<UserRole>(roleItem.Value.ToString()),
                UserName = txtUserName.Text,
                AuthName = txtAuthName.Text,
                Site    = cmbSite.Text
            };
            FormAlter.DataChanged(TypeAlter.User, null);
            _parrent.Close();

        }

        #endregion

        #region Event Handlers
       
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epCreateUser, txtUserName, _messageErrorUserName);
        }
        private void txtAuthName_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epCreateUser, txtAuthName, _messageErrorEmail);
        }

        private void txtAuthPwrd_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epCreateUser, txtAuthPwrd, _messageErrorPassword);
        }
     
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epCreateUser, cmbRole, _messageErrorRole) ;
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               // Helper.ValidateControlIsEmpty(epCreateUser, cmbSite, _messageErrorSite, _newItemSiteText);
                cmbSite.DropDownStyle = ComboBoxStyle.DropDown;
                if (cmbSite.SelectedIndex == 0 && cmbSite.Text.Equals(_newItemSiteText))
                {
                    cmbSite.Items[0] = "";
                }
                else if (cmbSite.SelectedIndex > 0)
                {
                    cmbSite.Items[0] = _newItemSiteText;
                }
            }
            catch (Exception ex)
            {
                Log.Here().Error("Error Selected Site", ex.Message);
            }
        }

        private void cmbSite_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSite.Text) || (!string.IsNullOrEmpty(_messageErrorSite) && cmbSite.Text.Equals(_newItemSiteText)))
            {
                //epCreateUser.SetError(cmbSite, _messageErrorSite);
            }
            else
            {
                epCreateUser.SetError(cmbSite, "");
            }
            //if (!_enabledValidateSiteIsChanged)
            //{
            //    return;
            //}
            //Helper.ValidateControlIsEmpty(epCreateUser, cmbSite, _messageErrorSite, _newItemSiteText);
        }      

        private void cmbSite_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Color color;
                string text = "";
                if (e.Index != -1)
                {
                    text = ((ComboBox)sender).Items[e.Index].ToString();
                }
                Font font = e.Font;
                if (e.Index != -1 && text.Equals(_newItemSiteText))
                {
                    color = Color.Bisque;
                    font = new Font(font, FontStyle.Bold);
                }
                else
                {
                    color = Color.White;
                }
                e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
                e.Graphics.DrawString(text, font, new SolidBrush(((ComboBox)sender).ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                Log.Here().Error("Error Draw Site", ex.Message);
            }
        }
        #endregion
    }
}

