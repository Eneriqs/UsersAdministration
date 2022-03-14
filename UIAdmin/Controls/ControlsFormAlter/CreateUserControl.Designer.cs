namespace UIAdmin.Controls.ControlsFormAlter
{
    partial class CreateUserControl
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
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.txtAuthPwrd = new System.Windows.Forms.TextBox();
            this.lblAuthPwrd = new System.Windows.Forms.Label();
            this.txtAuthName = new System.Windows.Forms.TextBox();
            this.lblAuthName = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.epCreateUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCreateUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlGeneral.Controls.Add(this.cmbRole);
            this.pnlGeneral.Controls.Add(this.lblRole);
            this.pnlGeneral.Controls.Add(this.cmbSite);
            this.pnlGeneral.Controls.Add(this.txtAuthPwrd);
            this.pnlGeneral.Controls.Add(this.lblAuthPwrd);
            this.pnlGeneral.Controls.Add(this.txtAuthName);
            this.pnlGeneral.Controls.Add(this.lblAuthName);
            this.pnlGeneral.Controls.Add(this.lblSite);
            this.pnlGeneral.Controls.Add(this.txtUserName);
            this.pnlGeneral.Controls.Add(this.lblUserName);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.TabIndex = 0;
            // 
            // cmbRole
            // 
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRole.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRole.Location = new System.Drawing.Point(189, 248);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(222, 22);
            this.cmbRole.TabIndex = 10;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.Location = new System.Drawing.Point(74, 252);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 14);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "Role";
            // 
            // cmbSite
            // 
            this.cmbSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(189, 166);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(222, 23);
            this.cmbSite.TabIndex = 8;
            this.cmbSite.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbSite_DrawItem);
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            this.cmbSite.TextChanged += new System.EventHandler(this.cmbSite_TextChanged);
            // 
            // txtAuthPwrd
            // 
            this.txtAuthPwrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthPwrd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAuthPwrd.Location = new System.Drawing.Point(189, 289);
            this.txtAuthPwrd.Name = "txtAuthPwrd";
            this.txtAuthPwrd.PasswordChar = '*';
            this.txtAuthPwrd.Size = new System.Drawing.Size(222, 22);
            this.txtAuthPwrd.TabIndex = 7;
            this.txtAuthPwrd.TextChanged += new System.EventHandler(this.txtAuthPwrd_TextChanged);
            // 
            // lblAuthPwrd
            // 
            this.lblAuthPwrd.AutoSize = true;
            this.lblAuthPwrd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthPwrd.Location = new System.Drawing.Point(74, 293);
            this.lblAuthPwrd.Name = "lblAuthPwrd";
            this.lblAuthPwrd.Size = new System.Drawing.Size(58, 14);
            this.lblAuthPwrd.TabIndex = 6;
            this.lblAuthPwrd.Text = "Password";
            // 
            // txtAuthName
            // 
            this.txtAuthName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAuthName.Location = new System.Drawing.Point(189, 207);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(222, 22);
            this.txtAuthName.TabIndex = 5;
            this.txtAuthName.TextChanged += new System.EventHandler(this.txtAuthName_TextChanged);
            // 
            // lblAuthName
            // 
            this.lblAuthName.AutoSize = true;
            this.lblAuthName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthName.Location = new System.Drawing.Point(74, 211);
            this.lblAuthName.Name = "lblAuthName";
            this.lblAuthName.Size = new System.Drawing.Size(71, 14);
            this.lblAuthName.TabIndex = 4;
            this.lblAuthName.Text = "Login Name";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSite.Location = new System.Drawing.Point(74, 170);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(28, 14);
            this.lblSite.TabIndex = 2;
            this.lblSite.Text = "Site";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(189, 125);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(222, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(74, 129);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // epCreateUser
            // 
            this.epCreateUser.ContainerControl = this;
            // 
            // CreateUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGeneral);
            this.Name = "CreateUserControl";
            this.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epCreateUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGeneral;
        private TextBox txtUserName;
        private Label lblUserName;
        private Label lblSite;
        private ErrorProvider epCreateUser;
        private TextBox txtAuthName;
        private Label lblAuthName;
        private TextBox txtAuthPwrd;
        private Label lblAuthPwrd;
        private ComboBox cmbSite;
        private ComboBox cmbRole;
        private Label lblRole;
    }
}
