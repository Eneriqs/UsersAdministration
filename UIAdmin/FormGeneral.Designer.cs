namespace UIAdmin
{
    partial class FormGeneral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStrip toolStripTab;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneral));
            this.toolStripBtnUsers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnMaintenance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStriplblStatus = new System.Windows.Forms.ToolStripLabel();
            this.tmErrorStatus = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainerForm = new System.Windows.Forms.ToolStripContainer();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            toolStripTab = new System.Windows.Forms.ToolStrip();
            toolStripTab.SuspendLayout();
            this.toolStripContainerForm.ContentPanel.SuspendLayout();
            this.toolStripContainerForm.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTab
            // 
            toolStripTab.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            toolStripTab.CanOverflow = false;
            toolStripTab.Dock = System.Windows.Forms.DockStyle.None;
            toolStripTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnUsers,
            this.toolStripSeparator1,
            this.toolStripBtnSite,
            this.toolStripSeparator2,
            this.toolStripBtnMaintenance,
            this.toolStripSeparator3,
            this.toolStriplblStatus});
            toolStripTab.Location = new System.Drawing.Point(3, 0);
            toolStripTab.Name = "toolStripTab";
            toolStripTab.Size = new System.Drawing.Size(1051, 25);
            toolStripTab.TabIndex = 0;
            toolStripTab.Text = "toolStrip1";
            // 
            // toolStripBtnUsers
            // 
            this.toolStripBtnUsers.CheckOnClick = true;
            this.toolStripBtnUsers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUsers.Image")));
            this.toolStripBtnUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUsers.Name = "toolStripBtnUsers";
            this.toolStripBtnUsers.Size = new System.Drawing.Size(55, 22);
            this.toolStripBtnUsers.Text = "Users";
            this.toolStripBtnUsers.Click += new System.EventHandler(this.toolStripBtnUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnSite
            // 
            this.toolStripBtnSite.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripBtnSite.CheckOnClick = true;
            this.toolStripBtnSite.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSite.Image")));
            this.toolStripBtnSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSite.Name = "toolStripBtnSite";
            this.toolStripBtnSite.Size = new System.Drawing.Size(51, 22);
            this.toolStripBtnSite.Text = "Sites";
            this.toolStripBtnSite.Click += new System.EventHandler(this.toolStripBtnSite_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnMaintenance
            // 
            this.toolStripBtnMaintenance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripBtnMaintenance.CheckOnClick = true;
            this.toolStripBtnMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnMaintenance.Image")));
            this.toolStripBtnMaintenance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnMaintenance.Name = "toolStripBtnMaintenance";
            this.toolStripBtnMaintenance.Size = new System.Drawing.Size(96, 22);
            this.toolStripBtnMaintenance.Text = "Maintenance";
            this.toolStripBtnMaintenance.Click += new System.EventHandler(this.toolStripBtnMaintenance_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStriplblStatus
            // 
            this.toolStriplblStatus.AutoSize = false;
            this.toolStriplblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStriplblStatus.Name = "toolStriplblStatus";
            this.toolStriplblStatus.Size = new System.Drawing.Size(800, 22);
            this.toolStriplblStatus.Text = "dd";
            // 
            // tmErrorStatus
            // 
            this.tmErrorStatus.Interval = 4000;
            this.tmErrorStatus.Tick += new System.EventHandler(this.tmErrorStatus_Tick);
            // 
            // toolStripContainerForm
            // 
            // 
            // toolStripContainerForm.ContentPanel
            // 
            this.toolStripContainerForm.ContentPanel.Controls.Add(this.pnlGeneral);
            this.toolStripContainerForm.ContentPanel.Size = new System.Drawing.Size(1054, 526);
            this.toolStripContainerForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainerForm.Name = "toolStripContainerForm";
            this.toolStripContainerForm.Size = new System.Drawing.Size(1054, 551);
            this.toolStripContainerForm.TabIndex = 0;
            this.toolStripContainerForm.Text = "toolStripContainer1";
            // 
            // toolStripContainerForm.TopToolStripPanel
            // 
            this.toolStripContainerForm.TopToolStripPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripContainerForm.TopToolStripPanel.Controls.Add(toolStripTab);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(1054, 526);
            this.pnlGeneral.TabIndex = 1;
            // 
            // FormGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 551);
            this.Controls.Add(this.toolStripContainerForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGeneral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGeneral_FormClosed);
            toolStripTab.ResumeLayout(false);
            toolStripTab.PerformLayout();
            this.toolStripContainerForm.ContentPanel.ResumeLayout(false);
            this.toolStripContainerForm.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerForm.TopToolStripPanel.PerformLayout();
            this.toolStripContainerForm.ResumeLayout(false);
            this.toolStripContainerForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ToolStripContainer toolStripContainerForm;
        private ToolStrip toolStripTab;
        private ToolStripButton toolStripBtnSite;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripBtnMaintenance;
        private ToolStripButton toolStripBtnUsers;
        private ToolStripSeparator toolStripSeparator2;
        private Panel pnlGeneral;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox toolStripTextBoxStatus;
        private System.Windows.Forms.Timer tmErrorStatus;
        private ToolStripLabel toolStriplblStatus;
    }
}