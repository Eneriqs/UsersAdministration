using Common;
using System.Runtime.Serialization;
using UIAdmin.Helpers;
using UIAdmin.Model;

namespace UIAdmin.Controls
{
    public partial class UsersControl : UserControl
    {
        #region Members
        public event Func<Task> UserChange;
        private UserInfo _currentUser = null;
        private static Serilog.ILogger Log => Serilog.Log.ForContext<UsersControl>();
        private List<string> _sites = new List<string>();
        private List<UserInfo> _currentUserInfo = new List<UserInfo>();
        #endregion
        #region Constructor
        public UsersControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private async void InitSitesList()
        {
            var sitesResult = await RestHelper.Instance.GetSites();
            if (!string.IsNullOrEmpty(sitesResult.Item2))
            {
                FormGeneral.ErrorMessage(false,sitesResult.Item2);
            }
            _sites = sitesResult.Item1;
        }

        private async Task InitUsersList(object selectedUser = null)
        {
            var usersResult = await RestHelper.Instance.GetUniqUsersByName(txtUserFilter.Text);
            if (!string.IsNullOrEmpty(usersResult.Item2))
            {
                FormGeneral.ErrorMessage(false,usersResult.Item2);
            }
            var users = usersResult.Item1;
            dgUsers.Rows.Clear();
            if (users == null || users.ToList().Count == 0)                
            {
                Log.Here().Information($"Users list is empty for {txtUserFilter.Text}");
                return;
            }
            foreach (var user in users.OrderBy( x=> x.UserName))
            {
               
                DataGridViewRow tempRow = new DataGridViewRow();
                
                //tempRow.Height = 100;
                DataGridViewCell cellUserName = new DataGridViewTextBoxCell();
                cellUserName.Value = user.UserName;
                tempRow.Cells.Add(cellUserName);

                DataGridViewCell cellAuthName = new DataGridViewTextBoxCell();
                cellAuthName.Value = user.AuthName;
                tempRow.Cells.Add(cellAuthName);


                DataGridViewCell cellAppRole = new DataGridViewTextBoxCell();
                cellAppRole.Value = user.AppRole;
                tempRow.Cells.Add(cellAppRole);              
                dgUsers.Rows.Add(tempRow);
                if (selectedUser != null && ((UserInfo)selectedUser).UserName.Equals(user.UserName))
                {
                    tempRow.Selected = true;                   
                }
            }
            if (selectedUser == null)
            {
                dgUsers.CurrentCell.Selected = false;
            }
            //else
            //{
            //    dgUsers.CurrentCell.Selected = true;
            //}

        }

        private void StartedPosition() 
        {
            FormGeneral.ErrorMessage(false, "");
            _currentUser = null;
            _currentUserInfo = null;
            lblUserInifo.Text = "";
            dgSites.Rows.Clear();
            InitUsersList();
            dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsers.ClearSelection();
            dgUsers.CurrentCell = null;
        }

        private string GetEnumValue(UserRole role)
        {
            return Helper.GetAttributeOfType<EnumMemberAttribute>(role).Value;
        }
        private void UserInfoShow()
        {
            lblUserInifo.Text = $"{_currentUser.UserName} | {_currentUser.AuthName} | {GetEnumValue(_currentUser.AppRole)}";
        }

        public void LoadDGV()
        {
            dgSites.Rows.Clear();
            if (_currentUserInfo == null || _currentUserInfo.Count == 0) { return; }

            foreach (UserInfo user in _currentUserInfo)
            {

                DataGridViewRow tempRow = new DataGridViewRow();
                //tempRow.Height = 100;
                DataGridViewCell cellSite = new DataGridViewTextBoxCell();
                cellSite.Value = user.Site;
                tempRow.Cells.Add(cellSite);
                DataGridViewCell cellId = new DataGridViewTextBoxCell();
                cellId.Value = user.Id;
                tempRow.Cells.Add(cellId);
                dgSites.Rows.Add(tempRow);
            }

            dgSites.CurrentCell.Selected = false;
        }

        private void ChangeByTypeAlert(TypeAlter type, object value)
        {
            switch (type)
            {
                case TypeAlter.User:
                    InitSitesList();
                    InitUsersList(value);
                    UserChange();
                      break;
                case TypeAlter.UserOnlySiteList:
                    InitSitesList();
                    UserChange();
                    break;
            }
        }
        private UserRole ConvertRoleNameToEnum(string roleName)
        {
            return Helper.ParseEnum<UserRole>(roleName);
        }

        private async Task DeleteUser()
        {
            if (dgSites.Rows.Count == 0)
            {
                Log.Here().Warning("Sites list is empty");
                return;
            }
            _currentUser.Site = dgSites.SelectedRows[0].Cells[0].Value.ToString();
            _currentUser.Id = dgSites.SelectedRows[0].Cells[1].Value.ToString();

            string message = (dgSites.Rows.Count > 1) ? $"Do You want to remove the Site '{_currentUser.Site}'\nfrom the User '{_currentUser.UserName}' ?" : $"The User '{_currentUser.UserName}' have one Site.\nDo You want to remove the User ?";

            DialogResult result = MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                
               

                var resultDelete = await RestHelper.Instance.DeleteSiteForUser(_currentUser.Id, _currentUser.Site);
                ///
                if (!string.IsNullOrEmpty(resultDelete.Item2))
                {
                    FormGeneral.ErrorMessage(false, resultDelete.Item2);
                    return;
                }
                if (!resultDelete.Item1)
                {
                    FormGeneral.ErrorMessage(false, "Delete site from user failure");
                    return;
                }
                FormGeneral.ErrorMessage(true, "Success");
                if (dgSites.Rows.Count > 1)
                {
                    FormAlter.DataChanged(TypeAlter.UserOnlySiteList, null);
                }
                else {
                    _currentUser = null;
                    _currentUserInfo = null;
                    FormAlter.DataChanged(TypeAlter.User, null);
                    lblUserInifo.Text = "";
                    dgSites.Rows.Clear();
                    //InitUsersList();
                    dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgUsers.ClearSelection();
                    dgUsers.CurrentCell = null;
                }               
            }
        }

        #endregion

        #region Event Handlers
        private void UsersControl_Load(object sender, EventArgs e)
        {
          
            UserChange += async()=>  
            {
                if(_currentUser != null){
                    var userInfoResult = await RestHelper.Instance.GetUserByName(_currentUser.UserName);
                    if (!string.IsNullOrEmpty(userInfoResult.Item2))
                    {
                        FormGeneral.ErrorMessage(false, userInfoResult.Item2);                       
                    }
                    _currentUserInfo = userInfoResult.Item1;
                    UserInfoShow();
                    LoadDGV();
                }               
            };
            FormAlter.DataChanged += (type, value) => {
               ChangeByTypeAlert(type, value);
            };
        }
      
       
        private void btnUserFilter_Click(object sender, EventArgs e)
        {
            StartedPosition();
        }
        private  async void SelectUserItem()
        {
            if (dgUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgUsers.SelectedRows[0];
                if (row != null)
                {
                    await SelectUserRow(row.Index);
                }
            }           
        }

        private async void SelectUserItemDown() {

            if (dgUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgUsers.SelectedRows[0];
                if (row != null  && dgUsers.Rows?.Count > row.Index + 1)
                {
                    await SelectUserRow(row.Index+1);
                }
            }
        }

        private async void SelectUserItemUp()
        {

            if (dgUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgUsers.SelectedRows[0];
                if (row != null && dgUsers.Rows?.Count > row.Index - 1 && row.Index - 1 > 0)
                {
                    await SelectUserRow(row.Index - 1);
                }
            }
        }

        private async Task SelectUserRow(int currentRow)
        {
            _currentUser = new UserInfo()
            {
                UserName = dgUsers.Rows[currentRow].Cells["clmUserName"].Value.ToString(),
                AppRole = ConvertRoleNameToEnum(dgUsers.Rows[currentRow].Cells["clmRole"].Value.ToString()),
                AuthName = dgUsers.Rows[currentRow].Cells["clmEmail"].Value.ToString(),
            };
            await UserChange();
        }

        private void btnClearUserFilter_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = "";
            StartedPosition();     
        }


        private void CreateCurrentUser()
        {
            if (dgUsers.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false, "Please Select a User");
                return;
            }
            FormGeneral.ErrorMessage(false, "");
            
            if (_currentUser == null)
            {
                Log.Here().Warning("Current user is null");
                return;
            }
            if (dgSites.Rows.Count == 0)
            {
                Log.Here().Warning("Sites List is empty");
                return;
            }
            string site = dgSites.Rows[0].Cells[0].Value.ToString();
            string id = dgSites.Rows[0].Cells[1].Value.ToString();

            _currentUser.Site = site;
            _currentUser.Id = id;
        }

        #endregion

        #region Event Handlers

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //FormGeneral.ErrorMessage(false, "");
            StartedPosition();
            FormAlter frm = new FormAlter(ViewAlter.CreateUser, _sites);
            frm.ShowDialog(this);
            frm.Dispose();
        }
       
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            CreateCurrentUser();
            if (_currentUser == null)
            {
                 return;
            }
            FormAlter frm = new FormAlter(ViewAlter.UpdateUser, _currentUser);
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            CreateCurrentUser();
            if (_currentUser == null) 
            {
                return;
            }

            FormAlter frm = new FormAlter(ViewAlter.ChangePassword, _currentUser);
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            CreateCurrentUser();
            if (_currentUser == null)
            {
                return;
            }
            DialogResult result = MessageBox.Show($"Do You Want to remove the User '{_currentUser.UserName}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {                                          
                var resultDelete = await RestHelper.Instance.DeleteUser(_currentUser.UserName);
                ///
                if (!string.IsNullOrEmpty(resultDelete.Item2))
                {
                    FormGeneral.ErrorMessage(false, resultDelete.Item2);
                    return;
                }
                if (!resultDelete.Item1)
                {
                    FormGeneral.ErrorMessage(false, "Delete user failure");
                    return;
                }
                FormGeneral.ErrorMessage(true, "Delete user success");
                ///
                _currentUser = null;
                FormAlter.DataChanged(TypeAlter.User, null);
                //StartedPosition();
                // _currentUser = null;
                _currentUserInfo = null;
                lblUserInifo.Text = "";
                dgSites.Rows.Clear();
                //InitUsersList();
                dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgUsers.ClearSelection();
                dgUsers.CurrentCell = null;
            }           
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            CreateCurrentUser();
            if (_currentUser == null || _currentUserInfo == null)
            {
                return;
            }

            UserFullInfo userFullInfo = new UserFullInfo()
            {
                PotentialSites = _sites?.Where(s => !_currentUserInfo.Any(s2 => s2.Site == s))?.ToList(),
                UserInfo = _currentUser
            };
            FormAlter frm = new FormAlter(ViewAlter.AddSiteToUser, userFullInfo);
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private async void btnRemoveSite_Click(object sender, EventArgs e)
        {
            if (dgUsers.SelectedRows.Count == 0  && dgSites.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false, "Please Select a User and Site");
                return;
            }
            if (dgSites.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false, "Please Select a Site");
                return;
            }
            FormGeneral.ErrorMessage(false,"");
            await DeleteUser();
            dgUsers.Focus();
        }      

        private void dgSites_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgSites.SelectedRows.Count > 0) {
            //    FormGeneral.ErrorMessage("");
            //}
        }
      
        private void UsersControl_VisibleChanged(object sender, EventArgs e)
        { 
            
            if (this.Visible) 
            {
                StartedPosition();
                InitSitesList();
            }
           
        }

        private void btnNewSite_Click(object sender, EventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            CreateCurrentUser();
            if (_currentUser == null)
            {
                return;
            }
            UserFullInfo userFullInfo = new UserFullInfo()
            {
                UserInfo = _currentUser,
                AllSites = _sites
            };
            FormAlter frm = new FormAlter(ViewAlter.NewSiteToUser, userFullInfo);
            frm.ShowDialog(this);
            frm.Dispose();
        }
       
        #endregion      

        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            SelectUserItem();
        }

        private void dgUsers_KeyDown(object sender, KeyEventArgs e)
        {
            FormGeneral.ErrorMessage(false, "");
            if (e.KeyCode == Keys.Down)
            {
                SelectUserItemDown();
            }
            if (e.KeyCode == Keys.Up)
            {
                SelectUserItemUp();
            }
        }
    }
}
