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
using UIAdmin.Controls;

namespace UIAdmin
{
    public partial class FormGeneral : Form
    {
        #region Members
        public static Action<bool,string> ErrorMessage;
        private Form parentForm;
        #endregion
        #region Constructors
        public FormGeneral(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
            InitControls();
        }
        #endregion
        #region Private Methods
        private void InitControls()
        {
            ErrorMessage += (status,details) =>
            {
               toolStriplblStatus.ForeColor = (status) ? Color.Blue : Color.Red;
               if (!string.IsNullOrEmpty(details))
               {
                    toolStriplblStatus.Text = details;
                    toolStriplblStatus.Visible = true;
                    tmErrorStatus.Enabled = true;
                    tmErrorStatus.Start();

               }
               else
               {
                    toolStriplblStatus.Text = details;
                    toolStriplblStatus.Visible = true;
                    tmErrorStatus.Stop();
                    tmErrorStatus.Enabled = false;
                }
            };
             
            InitControl(pnlGeneral, new SitesControl(), false);
            InitControl(pnlGeneral, new UsersControl(), true);
            InitControl(pnlGeneral, new MaintenancesControl(), false);
            toolStripBtnUsers.Select();

        }
        private void InitControl(Panel pnl, UserControl contrl, bool visible)
        {
            contrl.Visible = visible;
            contrl.Dock = DockStyle.Fill;
            pnl.Controls.Add(contrl);

        }
        private static bool ChangePanelVisible(Panel panel, string controlName)
        {
            IEnumerator enC = panel.Controls.GetEnumerator();
            while (enC.MoveNext())
            {
                ((UserControl)enC.Current).Visible = false;
            }

            IEnumerator enCnt = panel.Controls.GetEnumerator();
            while (enCnt.MoveNext())
            {

                UserControl currentUC = (UserControl)enCnt.Current;
                if (currentUC.Name == controlName)
                {
                    currentUC.Visible = true;
                    currentUC.Show();
                }
                else
                {
                    currentUC.Visible = false;
                }
            }
            // CommonData.Instance.CurrentControlName = controlName;
            return true;
        }

        #endregion
        #region Events Handlers

        private void toolStripBtnSite_Click(object sender, EventArgs e)
        {
            toolStripBtnSite.Checked = true;
            toolStripBtnMaintenance.Checked = false;
            toolStripBtnUsers.Checked = false;
            ((ToolStripButton)sender).Select();
            ChangePanelVisible(pnlGeneral, "SitesControl");
        }

        private void toolStripBtnUsers_Click(object sender, EventArgs e)
        {
            toolStripBtnSite.Checked = false;
            toolStripBtnMaintenance.Checked = false;
            toolStripBtnUsers.Checked = true;
            ((ToolStripButton)sender).Select();
            ChangePanelVisible(pnlGeneral, "UsersControl");          
        }

        private void toolStripBtnMaintenance_Click(object sender, EventArgs e)
        {
            toolStripBtnSite.Checked = false;
            toolStripBtnMaintenance.Checked = true;
            toolStripBtnUsers.Checked = false;
            ((ToolStripButton)sender).Select();
            ChangePanelVisible(pnlGeneral, "MaintenancesControl");
        }
        #endregion

        private void FormGeneral_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmErrorStatus_Tick(object sender, EventArgs e)
        {
            toolStriplblStatus.Text = "";
            tmErrorStatus.Stop();
            tmErrorStatus.Enabled = false;
        }
    }
}
