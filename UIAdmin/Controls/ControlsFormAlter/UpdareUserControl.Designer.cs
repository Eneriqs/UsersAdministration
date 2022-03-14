namespace UIAdmin.Controls.ControlsFormAlter
{
    partial class UpdateUserControl
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
            this.txtAuthName = new System.Windows.Forms.TextBox();
            this.lblAuthName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.epUpdateUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUpdateUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlGeneral.Controls.Add(this.cmbRole);
            this.pnlGeneral.Controls.Add(this.lblRole);
            this.pnlGeneral.Controls.Add(this.txtAuthName);
            this.pnlGeneral.Controls.Add(this.lblAuthName);
            this.pnlGeneral.Controls.Add(this.txtUserName);
            this.pnlGeneral.Controls.Add(this.label1);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.TabIndex = 1;
            // 
            // cmbRole
            // 
            this.cmbRole.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(189, 210);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(222, 22);
            this.cmbRole.TabIndex = 10;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.Location = new System.Drawing.Point(74, 214);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 14);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "Role";
            // 
            // txtAuthName
            // 
            this.txtAuthName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAuthName.Location = new System.Drawing.Point(189, 165);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(222, 22);
            this.txtAuthName.TabIndex = 5;
            this.txtAuthName.TextChanged += new System.EventHandler(this.txtAuthName_TextChanged);
            // 
            // lblAuthName
            // 
            this.lblAuthName.AutoSize = true;
            this.lblAuthName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthName.Location = new System.Drawing.Point(74, 169);
            this.lblAuthName.Name = "lblAuthName";
            this.lblAuthName.Size = new System.Drawing.Size(71, 14);
            this.lblAuthName.TabIndex = 4;
            this.lblAuthName.Text = "Login Name";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(189, 120);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(222, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(74, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // epUpdateUser
            // 
            this.epUpdateUser.ContainerControl = this;
            // 
            // UpdateUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGeneral);
            this.Name = "UpdateUserControl";
            this.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUpdateUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGeneral;
        private ComboBox cmbRole;
        private Label lblRole;
        private TextBox txtAuthName;
        private Label lblAuthName;
        private TextBox txtUserName;
        private ErrorProvider epUpdateUser;
        private Label label1;
    }
}
