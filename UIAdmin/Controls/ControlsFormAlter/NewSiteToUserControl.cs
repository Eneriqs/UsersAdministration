using UIAdmin.Helpers;
using Common;
using UIAdmin.Model;

namespace UIAdmin.Controls.ControlsFormAlter
{
    public partial class NewSiteToUserControl : UserControl
    {
        #region Members
        private UserFullInfo _currentUser;
        private static readonly string _messageErrorSite = "Site can't be empty";
        private string _currentSite;
        private static Serilog.ILogger Log => Serilog.Log.ForContext<AddSiteToUserControl>();
        private const ViewAlter _currentVewAlert = ViewAlter.NewSiteToUser;
        private FormAlter _parrent;
        #endregion
        public NewSiteToUserControl(FormAlter parrent, UserFullInfo currentUser)
        {
            _parrent = parrent;
            _currentUser = currentUser;
            InitializeComponent();
           _parrent.BtnOkClicked += SaveData;          
        }
        #region Private Methods

        
        
        private bool Validation() {

            var res = Helper.ValidateControlIsEmpty(epSiteToUser, txtNewSite, _messageErrorSite);
            if (res)
            {
                if (_currentUser.AllSites.Contains(txtNewSite.Text))
                {
                    epSiteToUser.SetError(txtNewSite, "Site already exists");
                    return false;
                }
                epSiteToUser.SetError(txtNewSite, ""); 
                return true;                    
            }
            return false;

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
                Site = txtNewSite.Text
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
            FormGeneral.ErrorMessage(true, "Success");
            FormAlter.DataChanged(TypeAlter.UserOnlySiteList, _currentUser.UserInfo);
            _parrent.Close();
        }

        #endregion

        #region Event Handlers    
       

        //private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Helper.ValidateControlIsEmpty(epSiteToUser, cmbSite, _messageErrorSite, _newItemSiteText);
        //        cmbSite.DropDownStyle = ComboBoxStyle.DropDown;
        //        if (cmbSite.SelectedIndex == 0 && cmbSite.Text.Equals(_newItemSiteText))
        //        {
        //            cmbSite.Items[0] = "";
        //        }
        //        else if (cmbSite.SelectedIndex > 0)
        //        {
        //            cmbSite.Items[0] = _newItemSiteText;
        //        }
        //    }
        //    catch (Exception ex )
        //    {
        //        Log.Here().Error("Error Selected", ex.Message);
        //    }
            
        //}

        //private void cmbSite_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    try
        //    {
        //        e.DrawBackground();
        //        Color color;
        //        string text = "";
        //        if (e.Index != -1)
        //        {
        //            text = ((ComboBox)sender).Items[e.Index].ToString();
        //        }
        //        Font font = e.Font;
        //        if (e.Index != -1 && text.Equals(_newItemSiteText))
        //        {
        //            color = Color.Bisque;
        //            font = new Font(font, FontStyle.Bold);
        //        }
        //        else
        //        {
        //            color = Color.White;
        //        }
        //        e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        //        e.Graphics.DrawString(text, font, new SolidBrush(((ComboBox)sender).ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
        //        e.DrawFocusRectangle();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Here().Error("Error Draw site", ex.Message);
        //    }
        //}      

        private void cmbSite_TextChanged(object sender, EventArgs e)
        {
           // Helper.ValidateControlIsEmpty(epSiteToUser, cmbSite, _messageErrorSite, _newItemSiteText);
        }
        #endregion

        private void dgSites_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gv = sender as DataGridView;
            if (gv != null && gv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gv.SelectedRows[0];
                if (row != null)
                {
                    _currentSite = row.Cells["ClmSite"].Value.ToString();                  
                }
            }
        }

       

        private void txtNewSite_TextChanged(object sender, EventArgs e)
        {
            Helper.ValidateControlIsEmpty(epSiteToUser, txtNewSite, _messageErrorSite);
        }
    }
}

