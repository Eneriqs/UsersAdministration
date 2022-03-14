namespace UIAdmin.Controls
{
    partial class UsersControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerSitesControl = new System.Windows.Forms.SplitContainer();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnClearUserFilter = new System.Windows.Forms.Button();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUserFilter = new System.Windows.Forms.Button();
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.btnNewSite = new System.Windows.Forms.Button();
            this.btnRemoveSite = new System.Windows.Forms.Button();
            this.btnAddSite = new System.Windows.Forms.Button();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgSites = new System.Windows.Forms.DataGridView();
            this.ClmSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUserInifo = new System.Windows.Forms.Label();
            this.pnlUsersControl = new System.Windows.Forms.Panel();
            this.toolTipUseControl = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSitesControl)).BeginInit();
            this.splitContainerSitesControl.Panel1.SuspendLayout();
            this.splitContainerSitesControl.Panel2.SuspendLayout();
            this.splitContainerSitesControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            this.pnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).BeginInit();
            this.pnlUsersControl.SuspendLayout();
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
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnDeleteUser);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnChangePassword);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnUpdateUser);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnAddUser);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnClearUserFilter);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.dgUsers);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.btnUserFilter);
            this.splitContainerSitesControl.Panel1.Controls.Add(this.txtUserFilter);
            // 
            // splitContainerSitesControl.Panel2
            // 
            this.splitContainerSitesControl.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainerSitesControl.Panel2.Controls.Add(this.btnNewSite);
            this.splitContainerSitesControl.Panel2.Controls.Add(this.btnRemoveSite);
            this.splitContainerSitesControl.Panel2.Controls.Add(this.btnAddSite);
            this.splitContainerSitesControl.Panel2.Controls.Add(this.pnlUsers);
            this.splitContainerSitesControl.Size = new System.Drawing.Size(1060, 531);
            this.splitContainerSitesControl.SplitterDistance = 185;
            this.splitContainerSitesControl.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Image")));
            this.btnDeleteUser.Location = new System.Drawing.Point(140, 483);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(38, 40);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = " ";
            this.toolTipUseControl.SetToolTip(this.btnDeleteUser, "Remove User");
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.Location = new System.Drawing.Point(92, 483);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(38, 40);
            this.btnChangePassword.TabIndex = 8;
            this.btnChangePassword.Text = " ";
            this.toolTipUseControl.SetToolTip(this.btnChangePassword, "Change Password");
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateUser.Image")));
            this.btnUpdateUser.Location = new System.Drawing.Point(46, 483);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(38, 40);
            this.btnUpdateUser.TabIndex = 7;
            this.btnUpdateUser.Text = " ";
            this.toolTipUseControl.SetToolTip(this.btnUpdateUser, "Update User");
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(1, 483);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(38, 40);
            this.btnAddUser.TabIndex = 5;
            this.btnAddUser.Text = " ";
            this.toolTipUseControl.SetToolTip(this.btnAddUser, "Create User");
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnClearUserFilter
            // 
            this.btnClearUserFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClearUserFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearUserFilter.Location = new System.Drawing.Point(126, 0);
            this.btnClearUserFilter.Name = "btnClearUserFilter";
            this.btnClearUserFilter.Size = new System.Drawing.Size(30, 27);
            this.btnClearUserFilter.TabIndex = 6;
            this.btnClearUserFilter.Text = " X ";
            this.btnClearUserFilter.UseVisualStyleBackColor = true;
            this.btnClearUserFilter.Click += new System.EventHandler(this.btnClearUserFilter_Click);
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.AllowUserToResizeColumns = false;
            this.dgUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUsers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.ColumnHeadersVisible = false;
            this.dgUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUserName,
            this.clmEmail,
            this.clmRole});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgUsers.Location = new System.Drawing.Point(-1, 26);
            this.dgUsers.MultiSelect = false;
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.RowHeadersVisible = false;
            this.dgUsers.RowHeadersWidth = 51;
            this.dgUsers.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dgUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgUsers.RowTemplate.Height = 25;
            this.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsers.Size = new System.Drawing.Size(187, 454);
            this.dgUsers.TabIndex = 4;
            this.dgUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsers_CellClick);
            this.dgUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgUsers_KeyDown);
            // 
            // clmUserName
            // 
            this.clmUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmUserName.HeaderText = "User Name";
            this.clmUserName.MinimumWidth = 6;
            this.clmUserName.Name = "clmUserName";
            this.clmUserName.ReadOnly = true;
            // 
            // clmEmail
            // 
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.MinimumWidth = 6;
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.ReadOnly = true;
            this.clmEmail.Visible = false;
            this.clmEmail.Width = 180;
            // 
            // clmRole
            // 
            this.clmRole.HeaderText = "Role";
            this.clmRole.MinimumWidth = 6;
            this.clmRole.Name = "clmRole";
            this.clmRole.ReadOnly = true;
            this.clmRole.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmRole.Visible = false;
            this.clmRole.Width = 180;
            // 
            // btnUserFilter
            // 
            this.btnUserFilter.AutoSize = true;
            this.btnUserFilter.BackgroundImage = global::UIAdmin.Properties.Resources.search_client;
            this.btnUserFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUserFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserFilter.Location = new System.Drawing.Point(156, 0);
            this.btnUserFilter.Name = "btnUserFilter";
            this.btnUserFilter.Size = new System.Drawing.Size(30, 27);
            this.btnUserFilter.TabIndex = 3;
            this.btnUserFilter.UseVisualStyleBackColor = true;
            this.btnUserFilter.Click += new System.EventHandler(this.btnUserFilter_Click);
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUserFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserFilter.Location = new System.Drawing.Point(0, 0);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(126, 27);
            this.txtUserFilter.TabIndex = 2;
            // 
            // btnNewSite
            // 
            this.btnNewSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewSite.Location = new System.Drawing.Point(386, 492);
            this.btnNewSite.Name = "btnNewSite";
            this.btnNewSite.Size = new System.Drawing.Size(100, 23);
            this.btnNewSite.TabIndex = 12;
            this.btnNewSite.Text = "New Site";
            this.toolTipUseControl.SetToolTip(this.btnNewSite, "Add new Site to current User");
            this.btnNewSite.UseVisualStyleBackColor = true;
            this.btnNewSite.Click += new System.EventHandler(this.btnNewSite_Click);
            // 
            // btnRemoveSite
            // 
            this.btnRemoveSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveSite.Location = new System.Drawing.Point(601, 492);
            this.btnRemoveSite.Name = "btnRemoveSite";
            this.btnRemoveSite.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveSite.TabIndex = 11;
            this.btnRemoveSite.Text = "Remove Site";
            this.toolTipUseControl.SetToolTip(this.btnRemoveSite, "Remove Site from current User");
            this.btnRemoveSite.UseVisualStyleBackColor = true;
            this.btnRemoveSite.Click += new System.EventHandler(this.btnRemoveSite_Click);
            // 
            // btnAddSite
            // 
            this.btnAddSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddSite.Location = new System.Drawing.Point(163, 492);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(100, 23);
            this.btnAddSite.TabIndex = 10;
            this.btnAddSite.Text = "Add Site";
            this.toolTipUseControl.SetToolTip(this.btnAddSite, "Add exists Site to current User");
            this.btnAddSite.UseVisualStyleBackColor = true;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlUsers.Controls.Add(this.pictureBox1);
            this.pnlUsers.Controls.Add(this.dgSites);
            this.pnlUsers.Controls.Add(this.lblUserInifo);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUsers.Location = new System.Drawing.Point(0, 0);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(869, 480);
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
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dgSites
            // 
            this.dgSites.AllowUserToAddRows = false;
            this.dgSites.AllowUserToDeleteRows = false;
            this.dgSites.AllowUserToResizeColumns = false;
            this.dgSites.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSites.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgSites.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmSite,
            this.clmUserId});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSites.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSites.Location = new System.Drawing.Point(0, 27);
            this.dgSites.MultiSelect = false;
            this.dgSites.Name = "dgSites";
            this.dgSites.ReadOnly = true;
            this.dgSites.RowHeadersVisible = false;
            this.dgSites.RowHeadersWidth = 51;
            this.dgSites.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dgSites.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgSites.RowTemplate.Height = 25;
            this.dgSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSites.Size = new System.Drawing.Size(869, 453);
            this.dgSites.TabIndex = 1;
            this.dgSites.SelectionChanged += new System.EventHandler(this.dgSites_SelectionChanged);
            // 
            // ClmSite
            // 
            this.ClmSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmSite.HeaderText = "Site Name";
            this.ClmSite.MinimumWidth = 6;
            this.ClmSite.Name = "ClmSite";
            this.ClmSite.ReadOnly = true;
            // 
            // clmUserId
            // 
            this.clmUserId.HeaderText = "UserId";
            this.clmUserId.MinimumWidth = 6;
            this.clmUserId.Name = "clmUserId";
            this.clmUserId.ReadOnly = true;
            this.clmUserId.Visible = false;
            this.clmUserId.Width = 125;
            // 
            // lblUserInifo
            // 
            this.lblUserInifo.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblUserInifo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUserInifo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserInifo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserInifo.ForeColor = System.Drawing.Color.White;
            this.lblUserInifo.Location = new System.Drawing.Point(0, 0);
            this.lblUserInifo.Margin = new System.Windows.Forms.Padding(5);
            this.lblUserInifo.Name = "lblUserInifo";
            this.lblUserInifo.Size = new System.Drawing.Size(869, 27);
            this.lblUserInifo.TabIndex = 0;
            this.lblUserInifo.Text = " ";
            this.lblUserInifo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsersControl
            // 
            this.pnlUsersControl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlUsersControl.Controls.Add(this.splitContainerSitesControl);
            this.pnlUsersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsersControl.Location = new System.Drawing.Point(0, 0);
            this.pnlUsersControl.Name = "pnlUsersControl";
            this.pnlUsersControl.Size = new System.Drawing.Size(1060, 531);
            this.pnlUsersControl.TabIndex = 1;
            // 
            // toolTipUseControl
            // 
            this.toolTipUseControl.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlUsersControl);
            this.Name = "UsersControl";
            this.Size = new System.Drawing.Size(1060, 531);
            this.Load += new System.EventHandler(this.UsersControl_Load);
            this.VisibleChanged += new System.EventHandler(this.UsersControl_VisibleChanged);
            this.splitContainerSitesControl.Panel1.ResumeLayout(false);
            this.splitContainerSitesControl.Panel1.PerformLayout();
            this.splitContainerSitesControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSitesControl)).EndInit();
            this.splitContainerSitesControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.pnlUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).EndInit();
            this.pnlUsersControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainerSitesControl;
        private Panel pnlUsers;
        private DataGridView dgSites;
        private Label lblUserInifo;
        private Panel pnlUsersControl;
        private TextBox txtUserFilter;
        private Button btnUserFilter;
        private DataGridView dgUsers;
        private Button btnAddUser;
        private Button btnClearUserFilter;
        private Button btnUpdateUser;
        private Button btnChangePassword;
        private Button btnDeleteUser;
        private Button btnAddSite;
        private Button btnRemoveSite;
        private ToolTip toolTipUseControl;
        private DataGridViewTextBoxColumn clmUserName;
        private DataGridViewTextBoxColumn clmEmail;
        private DataGridViewTextBoxColumn clmRole;
        private DataGridViewTextBoxColumn ClmSite;
        private DataGridViewTextBoxColumn clmUserId;
        private Button btnNewSite;
        private PictureBox pictureBox1;
    }
}
