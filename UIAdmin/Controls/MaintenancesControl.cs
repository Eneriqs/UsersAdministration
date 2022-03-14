using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIAdmin.Helpers;

namespace UIAdmin.Controls
{
    public partial class MaintenancesControl : UserControl
    {
        #region Constructor
        public MaintenancesControl()
        {
            InitializeComponent();           
        }
        #endregion
        #region Private Methods
        private static async Task DBImport()
        {
            var result = await RestHelper.Instance.ImportDBFromFile();
            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormGeneral.ErrorMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormGeneral.ErrorMessage(false, "DB import failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "DB import success");
        }

        #endregion 
        #region Event Handlers
        private async  void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do You want export the DB?", "DB Export", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes))
            {
                await DBExport();
            }

        }

        private static async Task DBExport()
        {
            var result = await RestHelper.Instance.ExportDBToFile();
            if (!string.IsNullOrEmpty(result.Item2))
            {
                FormGeneral.ErrorMessage(false, result.Item2);
                return;
            }
            if (!result.Item1)
            {
                FormGeneral.ErrorMessage(false, "DB Export failure");
                return;
            }
            FormGeneral.ErrorMessage(true, "DB export success");
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do You want import the DB?", "DB Import", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.Yes)) {
                await DBImport();
            }            
        }               

        private void MaintenancesControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) {
                FormGeneral.ErrorMessage(true,"");
            }
        }
        #endregion
    }
}
