using UIAdmin.Helpers;
using Common;
using UIAdmin.Model;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class AddSiteToUserControl : UserControl
    {
        #region Members
        private UserFullInfo _currentUser;
        private static readonly string _messageErrorSite = "Site can't be empty";
        private static readonly string _newItemSiteText = "New Site";
        private string _currentSite;
        private static Serilog.ILogger Log => Serilog.Log.ForContext<AddSiteToUserControl>();
        private const ViewAlter _currentVewAlert = ViewAlter.AddSiteToUser;
        private FormAlter _parrent;
        #endregion
        public AddSiteToUserControl(FormAlter parrent, UserFullInfo currentUser)
        {
            _parrent = parrent;
            _currentUser = currentUser;
            InitializeComponent();
            CreateSite();
            _parrent.BtnOkClicked += SaveData;          
        }
        #region Private Methods

        private async Task CreateSite()
        {
            dgSites.Rows.Clear();
            var sites = _currentUser.PotentialSites;
            if (sites == null || sites.Count == 0)
            {
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
            dgSites.ClearSelection();
        }
        private bool Validation() {

            bool result;
            if (string.IsNullOrEmpty(_currentSite))
            {
                epSiteToUser.SetError(dgSites, _messageErrorSite);
                result = false;
            }
            else {
                epSiteToUser.SetError(dgSites, "");
                result = true;
            }
            return result;
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
                UserName = _currentUser.UserInfo.UserName,
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
            FormAlter.DataChanged(TypeAlter.UserOnlySiteList, _currentUser.UserInfo);
            _parrent.Close();
        }

        #endregion

        #region Event Handlers    
              

        private void dgSites_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView gv = sender as DataGridView;
            //if (gv != null && gv.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = gv.SelectedRows[0];
            //    if (row != null)
            //    {
            //        _currentSite = row.Cells["ClmSite"].Value.ToString();                  
            //    }
            //}
        }

       
        private void pnlGeneral_VisibleChanged(object sender, EventArgs e)
        {
            dgSites.ClearSelection();
            _currentSite = null;
        }

        private void SelectSite() { 
            epSiteToUser.SetError(dgSites, "");
            if (dgSites.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgSites.SelectedRows[0];
                if (row != null)
                {
                    _currentSite = row.Cells["ClmSite"].Value.ToString();
                }
            }
        }
        private void dgSites_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectSite();
        }
        #endregion

        private void dgSites_DoubleClick(object sender, EventArgs e)
        {
            SelectSite();
            SaveData(ViewAlter.AddSiteToUser);
        }
    }
}

