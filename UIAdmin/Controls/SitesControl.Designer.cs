namespace UIAdmin.Controls
{
    partial class SitesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SitesControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerSitesControl = new System.Windows.Forms.SplitContainer();
            this.btnClearUserFilter = new System.Windows.Forms.Button();
            this.txtSiteFilter = new System.Windows.Forms.TextBox();
            this.btnUserFilter = new System.Windows.Forms.Button();
            this.dgSites = new System.Windows.Forms.DataGridView();
            this.ClmSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.ClmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAuthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAppRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSiteInifo = new System.Windows.Forms.Label();
            this.pnlSitesControl = new System.Windows.Forms.Panel();
            this.toolTipSiteControl = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSitesControl)).BeginInit();
            this.splitContainerSitesControl.Panel1.SuspendLayout();
            this.splitContainerSitesControl.Panel2.SuspendLayout();
            this.splitContainerSitesControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).BeginInit();
            this.pnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            this.pnlSitesControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerSitesControl
            // 
            this.splitContainerSitesControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerSitesControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerSitesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSitesControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSitesControl.Name = "splitContainerSitesControl";
            // 
            // splitContainerSitesControl.Panel1
            // 
            this.splitContainerSitesControl.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnClearUserFilter);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.txtSiteFilter);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnUserFilter);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.dgSites);
            // 
            // splitContainerSitesControl.Panel2
            // 
            this.splitContainerSitesControl.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainerSitesControl.Panel2.Controls.Add(this.btnAddUser);
            this.splitContainerSitesControl.Panel2.Controls.Add(this.btnRemoveUser);
            this.splitContainerSitesControl.Panel2.Controls.Add(this.pnlUsers);
            this.splitContainerSitesControl.Size = new System.Drawing.Size(1060, 531);
            this.splitContainerSitesControl.SplitterDistance = 187;
            this.splitContainerSitesControl.TabIndex = 0;
            // 
            // btnClearUserFilter
            // 
            this.btnClearUserFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClearUserFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearUserFilter.Location = new System.Drawing.Point(126, 0);
            this.btnClearUserFilter.Name = "btnClearUserFilter";
            this.btnClearUserFilter.Size = new System.Drawing.Size(30, 27);
            this.btnClearUserFilter.TabIndex = 9;
            this.btnClearUserFilter.Text = " X ";
            this.btnClearUserFilter.UseVisualStyleBackColor = true;
            this.btnClearUserFilter.Click += new System.EventHandler(this.btnClearUserFilter_Click);
            // 
            // txtSiteFilter
            // 
            this.txtSiteFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiteFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSiteFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSiteFilter.Location = new System.Drawing.Point(0, 0);
            this.txtSiteFilter.Name = "txtSiteFilter";
            this.txtSiteFilter.Size = new System.Drawing.Size(128, 27);
            this.txtSiteFilter.TabIndex = 7;
            // 
            // btnUserFilter
            // 
            this.btnUserFilter.AutoSize = true;
            this.btnUserFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserFilter.BackgroundImage")));
            this.btnUserFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUserFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserFilter.Location = new System.Drawing.Point(156, 0);
            this.btnUserFilter.Name = "btnUserFilter";
            this.btnUserFilter.Size = new System.Drawing.Size(30, 27);
            this.btnUserFilter.TabIndex = 8;
            this.toolTipSiteControl.SetToolTip(this.btnUserFilter, "Search");
            this.btnUserFilter.UseVisualStyleBackColor = true;
            this.btnUserFilter.Click += new System.EventHandler(this.btnUserFilter_Click);
            // 
            // dgSites
            // 
            this.dgSites.AllowUserToAddRows = false;
            this.dgSites.AllowUserToDeleteRows = false;
            this.dgSites.AllowUserToResizeColumns = false;
            this.dgSites.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSites.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSites.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSites.ColumnHeadersVisible = false;
            this.dgSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmSite});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSites.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgSites.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgSites.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgSites.Location = new System.Drawing.Point(0, 26);
            this.dgSites.MultiSelect = false;
            this.dgSites.Name = "dgSites";
            this.dgSites.ReadOnly = true;
            this.dgSites.RowHeadersVisible = false;
            this.dgSites.RowHeadersWidth = 51;
            this.dgSites.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dgSites.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgSites.RowTemplate.Height = 25;
            this.dgSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSites.Size = new System.Drawing.Size(185, 503);
            this.dgSites.TabIndex = 2;
            this.dgSites.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSites_CellClick);
            this.dgSites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSites_KeyDown);
            // 
            // ClmSite
            // 
            this.ClmSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmSite.HeaderText = "Site Name";
            this.ClmSite.MinimumWidth = 6;
            this.ClmSite.Name = "ClmSite";
            this.ClmSite.ReadOnly = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddUser.Location = new System.Drawing.Point(256, 490);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 23);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.Text = "Add";
            this.toolTipSiteControl.SetToolTip(this.btnAddUser, "Add user to current Site");
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveUser.Location = new System.Drawing.Point(472, 490);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveUser.TabIndex = 8;
            this.btnRemoveUser.Text = "Remove";
            this.toolTipSiteControl.SetToolTip(this.btnRemoveUser, "Remove User from current Site");
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlUsers.Controls.Add(this.pictureBox1);
            this.pnlUsers.Controls.Add(this.dgUsers);
            this.pnlUsers.Controls.Add(this.lblSiteInifo);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUsers.Location = new System.Drawing.Point(0, 0);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(867, 480);
            this.pnlUsers.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Image = global::UIAdmin.Properties.Resources.elencton_logo;
            this.pictureBox1.Location = new System.Drawing.Point(827, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.AllowUserToResizeColumns = false;
            this.dgUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgUsers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmUserName,
            this.ClmAuthName,
            this.ClmAppRole,
            this.ClmId});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUsers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgUsers.Location = new System.Drawing.Point(0, 26);
            this.dgUsers.MultiSelect = false;
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.RowHeadersVisible = false;
            this.dgUsers.RowHeadersWidth = 51;
            this.dgUsers.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dgUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgUsers.RowTemplate.Height = 25;
            this.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsers.Size = new System.Drawing.Size(867, 454);
            this.dgUsers.TabIndex = 1;
            // 
            // ClmUserName
            // 
            this.ClmUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmUserName.HeaderText = "User Name";
            this.ClmUserName.MinimumWidth = 6;
            this.ClmUserName.Name = "ClmUserName";
            this.ClmUserName.ReadOnly = true;
            // 
            // ClmAuthName
            // 
            this.ClmAuthName.HeaderText = "Login Name";
            this.ClmAuthName.MinimumWidth = 6;
            this.ClmAuthName.Name = "ClmAuthName";
            this.ClmAuthName.ReadOnly = true;
            this.ClmAuthName.Width = 180;
            // 
            // ClmAppRole
            // 
            this.ClmAppRole.HeaderText = "Role";
            this.ClmAppRole.MinimumWidth = 6;
            this.ClmAppRole.Name = "ClmAppRole";
            this.ClmAppRole.ReadOnly = true;
            this.ClmAppRole.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmAppRole.Width = 180;
            // 
            // ClmId
            // 
            this.ClmId.HeaderText = "Column1";
            this.ClmId.MinimumWidth = 6;
            this.ClmId.Name = "ClmId";
            this.ClmId.ReadOnly = true;
            this.ClmId.Visible = false;
            this.ClmId.Width = 125;
            // 
            // lblSiteInifo
            // 
            this.lblSiteInifo.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblSiteInifo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSiteInifo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSiteInifo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSiteInifo.ForeColor = System.Drawing.Color.White;
            this.lblSiteInifo.Location = new System.Drawing.Point(0, 0);
            this.lblSiteInifo.Margin = new System.Windows.Forms.Padding(5);
            this.lblSiteInifo.Name = "lblSiteInifo";
            this.lblSiteInifo.Size = new System.Drawing.Size(867, 27);
            this.lblSiteInifo.TabIndex = 0;
            this.lblSiteInifo.Text = " ";
            this.lblSiteInifo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSitesControl
            // 
            this.pnlSitesControl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlSitesControl.Controls.Add(this.splitContainerSitesControl);
            this.pnlSitesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSitesControl.Location = new System.Drawing.Point(0, 0);
            this.pnlSitesControl.Name = "pnlSitesControl";
            this.pnlSitesControl.Size = new System.Drawing.Size(1060, 531);
            this.pnlSitesControl.TabIndex = 0;
            // 
            // toolTipSiteControl
            // 
            this.toolTipSiteControl.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // SitesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSitesControl);
            this.Name = "SitesControl";
            this.Size = new System.Drawing.Size(1060, 531);
            this.Load += new System.EventHandler(this.SitesControl_Load);
            this.VisibleChanged += new System.EventHandler(this.SitesControl_VisibleChanged);
            this.splitContainerSitesControl.Panel1.ResumeLayout(false);
            this.splitContainerSitesControl.Panel1.PerformLayout();
            this.splitContainerSitesControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSitesControl)).EndInit();
            this.splitContainerSitesControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).EndInit();
            this.pnlUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.pnlSitesControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainerSitesControl;
        private Panel pnlUsers;
        private DataGridView dgUsers;
        private Label lblSiteInifo;
        private Panel pnlSitesControl;
        private DataGridView dgSites;
        private DataGridViewTextBoxColumn ClmSite;
        private Button btnRemoveUser;
        private Button btnAddUser;
        private ToolTip toolTipSiteControl;
        private DataGridViewTextBoxColumn ClmUserName;
        private DataGridViewTextBoxColumn ClmAuthName;
        private DataGridViewTextBoxColumn ClmAppRole;
        private DataGridViewTextBoxColumn ClmId;
        private PictureBox pictureBox1;
        private Button btnClearUserFilter;
        private Button btnUserFilter;
        private TextBox txtSiteFilter;
    }
}
