namespace UIAdmin.Controls.ControlsFormAlter
{
    partial class AddUserToSiteControl
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
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.epAddUserToSite = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epAddUserToSite)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlGeneral.Controls.Add(this.cmbUser);
            this.pnlGeneral.Controls.Add(this.lblUser);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.TabIndex = 0;
            // 
            // cmbUser
            // 
            this.cmbUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbUser.Location = new System.Drawing.Point(189, 125);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(222, 22);
            this.cmbUser.TabIndex = 11;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUser.Location = new System.Drawing.Point(111, 129);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(31, 14);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            // 
            // epAddUserToSite
            // 
            this.epAddUserToSite.ContainerControl = this;
            // 
            // AddUserToSiteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGeneral);
            this.Name = "AddUserToSiteControl";
            this.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epAddUserToSite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGeneral;
        private Label lblUser;
        private ErrorProvider epAddUserToSite;
        private ComboBox cmbUser;
    }
}
