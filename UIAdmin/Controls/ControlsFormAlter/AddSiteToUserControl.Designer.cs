namespace UIAdmin.Controls.ControlsFormAlter
{
    partial class AddSiteToUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.dgSites = new System.Windows.Forms.DataGridView();
            this.ClmSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epSiteToUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSiteToUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlGeneral.Controls.Add(this.dgSites);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.TabIndex = 1;
            this.pnlGeneral.VisibleChanged += new System.EventHandler(this.pnlGeneral_VisibleChanged);
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
            this.dgSites.Location = new System.Drawing.Point(175, 79);
            this.dgSites.MultiSelect = false;
            this.dgSites.Name = "dgSites";
            this.dgSites.ReadOnly = true;
            this.dgSites.RowHeadersVisible = false;
            this.dgSites.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.dgSites.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgSites.RowTemplate.Height = 25;
            this.dgSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSites.Size = new System.Drawing.Size(219, 224);
            this.dgSites.TabIndex = 3;
            this.dgSites.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSites_RowEnter);
            this.dgSites.SelectionChanged += new System.EventHandler(this.dgSites_SelectionChanged);
            this.dgSites.DoubleClick += new System.EventHandler(this.dgSites_DoubleClick);
            // 
            // ClmSite
            // 
            this.ClmSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmSite.HeaderText = "Site Name";
            this.ClmSite.Name = "ClmSite";
            this.ClmSite.ReadOnly = true;
            // 
            // epSiteToUser
            // 
            this.epSiteToUser.ContainerControl = this;
            // 
            // AddSiteToUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGeneral);
            this.Name = "AddSiteToUserControl";
            this.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSiteToUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGeneral;
        private ErrorProvider epSiteToUser;
        private DataGridView dgSites;
        private DataGridViewTextBoxColumn ClmSite;
    }
}
