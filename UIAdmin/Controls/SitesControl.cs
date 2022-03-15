using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIAdmin.Helpers;

namespace UIAdmin.Controls
{
    public partial class SitesControl : UserControl
    {
        #region Members
        private string _currentSite;
        public event Func<Task> SiteChange;
        private static Serilog.ILogger Log => Serilog.Log.ForContext<SitesControl>();
        #endregion
        #region Constructors
        public SitesControl()
        {
            InitializeComponent();
        }
        #endregion
      
        #region Private Methods
        private async Task InitSiteList() {
            var sitesResult= await RestHelper.Instance.GetSites(txtSiteFilter.Text);
            if (!string.IsNullOrEmpty(sitesResult.Item2))
            {
                FormGeneral.ErrorMessage(false,sitesResult.Item2);
            }
            List<string> sites = sitesResult.Item1;
            dgSites.Rows.Clear();
            if(sites == null || sites.Count == 0)
            {
                Log.Here().Warning("Sites list is empty");
                return;
            }
            foreach (string site in sites.OrderBy(x => x))
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellSite = new DataGridViewTextBoxCell();
                cellSite.Value = site;
                tempRow.Cells.Add(cellSite);
                dgSites.Rows.Add(tempRow);
            }
            dgSites.CurrentCell.Selected = false;
           
        }
        private void LoadDGV(List<UserResponse> users)
        {
            dgUsers.Rows.Clear();
            if(users == null || users.Count == 0) {
                Log.Here().Warning("Users list is empty");    
                return; 
            }
              
            foreach (UserResponse user in users)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellUserName = new DataGridViewTextBoxCell();
                cellUserName.Value = user.UserName;
                tempRow.Cells.Add(cellUserName);

                DataGridViewCell cellAuthName = new DataGridViewTextBoxCell();
                cellAuthName.Value = user.AuthName;
                tempRow.Cells.Add(cellAuthName);                             

                DataGridViewCell cellAppRole = new DataGridViewTextBoxCell();
                cellAppRole.Value = Helper.GetAttributeOfType<EnumMemberAttribute>(user.AppRole).Value;
                tempRow.Cells.Add(cellAppRole);

                DataGridViewCell cellId = new DataGridViewTextBoxCell();
                cellId.Value = user.Id;
                tempRow.Cells.Add(cellId);

                dgUsers.Rows.Add(tempRow);
            }
            dgUsers.CurrentCell.Selected = false;          
        }

        private void ChangeByTypeAlert(TypeAlter type)
        {
            switch (type)
            {
                case TypeAlter.Site:
                    if (_currentSite == null)
                    {
                        StartedPosition();
                    }
                    else {
                        InitSiteList();
                        SiteChange();
                    }
                    break;
                case TypeAlter.SyteOnlyUserList:
                    SiteChange();
                    break;
            }
        }

        private async Task DeleteUserFromSite()
        {

            if (dgUsers.Rows.Count == 0)
            {
                Log.Here().Warning("Users list is empty");
                return;
            }
            string userName = dgUsers.SelectedRows[0].Cells["ClmUserName"].Value.ToString();
            string message = (dgUsers.Rows.Count > 1) ? $"Do You Want to remove the User '{userName}'\nfrom '{lblSiteInifo.Text}' ?" : $"The Site have one User .\nDo You Want to remove Site '{lblSiteInifo.Text}' ?";

            DialogResult result = MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {

                string userId = dgUsers.SelectedRows[0].Cells["ClmId"].Value.ToString();
                var resultDelete = await RestHelper.Instance.DeleteSiteForUser(userId, _currentSite, userName);

                if (!string.IsNullOrEmpty(resultDelete.Item2))
                {
                    FormGeneral.ErrorMessage(false, resultDelete.Item2);
                    return;
                }
                if (!resultDelete.Item1)
                {
                    FormGeneral.ErrorMessage(false, "Delete user from site failure");
                    return;
                }
                FormGeneral.ErrorMessage(true, "Success");

                if (dgUsers.Rows.Count > 1)
                {
                    FormAlter.DataChanged(TypeAlter.SyteOnlyUserList, _currentSite);
                }
                else {
                    _currentSite = null;
                    FormAlter.DataChanged(TypeAlter.Site, null);
                   // lblSiteInifo.Text = "";
                   // dgUsers.Rows.Clear();
                }
            }
        }
        private async void  SelectSiteItem() {
            if (dgSites.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgSites.SelectedRows[0];
                if (row != null)
                {
                    _currentSite = row.Cells["ClmSite"].Value.ToString();
                    await SiteChange();
                }
            }
        }

        private async void SelectSiteItemDown()
        {
            if (dgSites.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgSites.SelectedRows[0];
                if (row != null  &&  dgSites.Rows?.Count > row.Index+1)
                {
                     _currentSite = dgSites.Rows[row.Index+1].Cells["ClmSite"].Value.ToString();
                    await SiteChange();
                }
            }
        }
        private async void SelectSiteItemUp()
        {
            if (dgSites.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgSites.SelectedRows[0];
                if (row != null && dgSites.Rows?.Count  > row.Index - 1 && row.Index - 1 >= 0)
                {
                    _currentSite = dgSites.Rows[row.Index - 1].Cells["ClmSite"].Value.ToString();
                    await SiteChange();
                }
            }
        }
        private void StartedPosition()
        {
            FormGeneral.ErrorMessage(false, "");
            _currentSite = null;
            lblSiteInifo.Text = "";
            dgUsers.Rows.Clear();
            InitSiteList();
            dgSites.ClearSelection();
        }

        #endregion

        #region Event Handlers
        private async void SitesControl_Load(object sender, EventArgs e)
        {
                SiteChange += async () => {
                    if (_currentSite != null)
                    {
                        var usersForSiteResult = await RestHelper.Instance.GetUsersBySyte(_currentSite);
                        if (!string.IsNullOrEmpty(usersForSiteResult.Item2))
                        {
                            FormGeneral.ErrorMessage(false, usersForSiteResult.Item2);
                        }

                        var users = usersForSiteResult.Item1;
                        lblSiteInifo.Text = _currentSite;
                        LoadDGV(users);
                    }
                    //else {
                    //    StartedPosition();
                    //}               
            };
            FormAlter.DataChanged += (type, value) => {
                ChangeByTypeAlert(type);
            };
        }
             
        private async  void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgSites.SelectedRows.Count == 0  && dgUsers.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false, "Please Select a User and Site");
                return;
            }
            if (dgUsers.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false,"Please Select a User");
                return;
            }
            FormGeneral.ErrorMessage(false,"");
            
            await DeleteUserFromSite(); 
            dgSites.Focus();

        }      

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (dgSites.SelectedRows.Count == 0)
            {
                FormGeneral.ErrorMessage(false, "Please Select a Site");
                return;
            }
            if (string.IsNullOrEmpty(_currentSite))
            {
                Log.Here().Warning("Current site is null");
                return;
            }
          
            FormAlter frm = new FormAlter(ViewAlter.AddUserToSite, _currentSite);
            frm.ShowDialog(this);
            frm.Dispose();
        }
       

        private void SitesControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) 
            {
                txtSiteFilter.Text = "";
                StartedPosition();
            }
            
        }
        #endregion

        private void dgSites_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            FormGeneral.ErrorMessage(false, "");
            SelectSiteItem();
        }

        private void dgSites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                SelectSiteItemDown();
            }
            if (e.KeyCode == Keys.Up)
            {
                SelectSiteItemUp();
            }
        }

        private void dgSites_RowEnter(object sender, DataGridViewCellEventArgs e)
        { 
           // FormGeneral.ErrorMessage(false, "");
           // SelectSiteItem();
        }

        private void btnUserFilter_Click(object sender, EventArgs e)
        {
            StartedPosition();
        }

        private void btnClearUserFilter_Click(object sender, EventArgs e)
        {
            txtSiteFilter.Text = "";
            StartedPosition();
        }
    }
}
