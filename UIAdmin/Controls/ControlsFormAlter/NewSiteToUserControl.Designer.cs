namespace UIAdmin.Controls.ControlsFormAlter
{
    partial class NewSiteToUserControl
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
            this.txtNewSite = new System.Windows.Forms.TextBox();
            this.lblNewSite = new System.Windows.Forms.Label();
            this.epSiteToUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSiteToUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlGeneral.Controls.Add(this.txtNewSite);
            this.pnlGeneral.Controls.Add(this.lblNewSite);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.TabIndex = 1;
            // 
            // txtNewSite
            // 
            this.txtNewSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewSite.Location = new System.Drawing.Point(210, 143);
            this.txtNewSite.Name = "txtNewSite";
            this.txtNewSite.Size = new System.Drawing.Size(222, 22);
            this.txtNewSite.TabIndex = 3;
            this.txtNewSite.TextChanged += new System.EventHandler(this.txtNewSite_TextChanged);
            // 
            // lblNewSite
            // 
            this.lblNewSite.AutoSize = true;
            this.lblNewSite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNewSite.Location = new System.Drawing.Point(95, 147);
            this.lblNewSite.Name = "lblNewSite";
            this.lblNewSite.Size = new System.Drawing.Size(57, 14);
            this.lblNewSite.TabIndex = 2;
            this.lblNewSite.Text = "New Site";
            // 
            // epSiteToUser
            // 
            this.epSiteToUser.ContainerControl = this;
            // 
            // NewSiteToUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGeneral);
            this.Name = "NewSiteToUserControl";
            this.Size = new System.Drawing.Size(527, 387);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSiteToUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlGeneral;
        private ErrorProvider epSiteToUser;
        private TextBox txtNewSite;
        private Label lblNewSite;
    }
}
