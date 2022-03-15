using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIAdmin.Controls.ControlsFormAlter;
using UIAdmin.Helpers;

namespace UIAdmin
{
    public partial class FormAlter : Form
    {
        #region Private Methods
        private ViewAlter _viewType;
        private UserControl _currentUserControl;
        internal Func<ViewAlter, Task> BtnOkClicked;
        internal static Action<TypeAlter, object> DataChanged;
        private dynamic _currentData;
        public static Action<bool, string> AlterStatusMessage;
        #endregion
        public FormAlter(object viewType, object data)
        {
            _viewType = (ViewAlter)viewType;
            _currentData = data;
            InitializeComponent();
            CheckActiveControl();
        }
        #region Private Methods
       
        private void InitControl()
        {

            _currentUserControl.Visible = true;
            //DataChanged += (type, value) => { 
            //   // this.Close(); 
            //};
            AlterStatusMessage += (status, details) =>
            {
                if (!string.IsNullOrEmpty(details))
                {
                    tmErrorMessage.Enabled = true;
                    tmErrorMessage.Start();
                }
                else {
                    tmErrorMessage.Stop();
                    tmErrorMessage.Enabled = false;
                }
                lblStatus.Text = details;
                lblStatus.ForeColor = (status)?  Color.Blue : Color.Red;
            };
            _currentUserControl.Dock = DockStyle.Fill;
            pnlAlter.Controls.Add(_currentUserControl);
            _currentUserControl.Show();
        }

      
        private void CheckActiveControl()
        {   
            switch (_viewType)
            {
                case ViewAlter.ChangePassword:
                    lblTitle.Text = $"Change Password to the User {_currentData.UserName}";
                    _currentUserControl = new ChangePasswordControl(this,_currentData);               
                    break;
                case ViewAlter.CreateUser:
                    lblTitle.Text = "Create User";
                    _currentUserControl = new CreateUserControl(this,_currentData);
                    break;
                case ViewAlter.AddSiteToUser:
                    lblTitle.Text = $"Add existing Site to the User {_currentData.UserInfo.UserName}";
                    _currentUserControl = new AddSiteToUserControl(this,_currentData);
                    break;
                case ViewAlter.NewSiteToUser:
                    lblTitle.Text = $"Add new Site to the User {_currentData.UserInfo.UserName}";
                    _currentUserControl = new NewSiteToUserControl(this,_currentData);
                     break;
                case ViewAlter.UpdateUser:
                    lblTitle.Text = $"Edit the User {_currentData.UserName}";
                    _currentUserControl = new UpdateUserControl(this,_currentData);
                     break;
                case ViewAlter.AddUserToSite:
                    lblTitle.Text = $"Add User to the Site {_currentData}";
                    _currentUserControl = new AddUserToSiteControl(this,_currentData);
                      break;
            }
            InitControl();
        }
        #endregion

        #region Event Handlers
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(BtnOkClicked != null)
            {
                BtnOkClicked(_viewType);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAlter.Controls.Remove(_currentUserControl);
            BtnOkClicked = null;
            this.Close();
        }
   

        private void tmErrorMessage_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            tmErrorMessage.Stop();
            tmErrorMessage.Enabled = false;
        }  
        #endregion
    }
}
