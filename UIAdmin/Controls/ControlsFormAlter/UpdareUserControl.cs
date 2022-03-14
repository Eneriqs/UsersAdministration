using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIAdmin;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UIAdmin.Helpers;
using Common;
using System.Runtime.Serialization;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class UpdateUserControl : UserControl
    {
        #region Members
        UserInfo _currentUser;
        private static readonly string _messageErrorUserName = "User Name can't be empty";
        private static readonly string _messageErrorEmail = "Email can't be empty";
        private static readonly string _messageErrorRole = "Role can't be empty";
        private const ViewAlter _currentVewAlert = ViewAlter.UpdateUser;
        private FormAlter _parrent;
        #endregion
        #region Constructor

        public UpdateUserControl(FormAlter parrent, UserInfo currentUser)
        {
            _parrent = parrent;
            _currentUser = currentUser;
            InitializeComponent();
            ControlInit();
            _parrent.BtnOkClicked += UpdateUser;          
        }
        #endregion
        #region Private Methods
        private void ControlInit()
        {
            CreateUserRole();
            SetUserInfoValue();

        }
        private void CreateUserRole()
        {
            cmbRole.DisplayMember = "Text";
            cmbRole.ValueMember = "Value";
            List<UserRole> roles = Enum.GetValues(typeof(UserRole))
            .Cast<UserRole>()
            .Select(v => v)
            .ToList();
            foreach (UserRole role in roles)
            {
                string roleName = Helper.GetAttributeOfType<EnumMemberAttribute>(role).Value;
                var item = new ComboboxItem { Text = roleName, Value = role };
                cmbRole.Items.Add(item);
                if(role == _currentUser.AppRole)
                {
                    cmbRole.SelectedItem = item;
                }
            }
        }
        private void SetUserInfoValue()
        {
            txtUserName.Text = _currentUser.UserName;
            txtAuthName.Text = _currentUser.AuthName;             
        }



        private bool Validation()
        {
            bool res = true;
            res = Helper.ValidateControlIsEmpty(epUpdateUser, txtUserName, _messageErrorUserName);
            res = Helper.ValidateControlIsEmpty(epUpdateUser, txtAuthName, _messageErrorEmail) && res;
            res = Helper.ValidateControlIsEmpty(epUpdateUser, cmbRole, _messageErrorRole) && res;
            return res;
        }

        private async Task UpdateUser(ViewAlter alertType)
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
            if (roleItem == null)
            {
                MessageBox.Show("Role does not valid");
                return;
            }
            var result = await RestHelper.Instance.UpdateUser(new Common.Models.UpdateUserRequest
            {
                Id = _currentUser.Id,
                UserName = txtUserName.Text,
                AuthName = txtAuthName.Text,
                Site = _currentUser.Site,
                AppRole = Helper.ParseEnum<UserRole>(roleItem.Value.ToString())
            }); 
            _currentUser.AuthName = txtAuthName.Text;
            _currentUser.UserName = txtUserName.Text;
            _currentUser.AppRole = Helper.ParseEnum<UserRole>(roleItem.Value.ToString());

            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormAlter.AlterStatusMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormAlter.AlterStatusMessage(false, "Update failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "Success");

            FormAlter.DataChanged(TypeAlter.User, _currentUser);
            _parrent.Close();
        }

        #endregion

        #region Event Handlers
       
     
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epUpdateUser, txtUserName, _messageErrorUserName);
        }

        private void txtAuthName_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epUpdateUser, txtAuthName, _messageErrorEmail);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epUpdateUser, cmbRole, _messageErrorRole);
        }
        #endregion
      
    }
}

