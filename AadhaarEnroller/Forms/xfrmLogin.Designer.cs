namespace AadhaarEnroller.Forms
{
    partial class xfrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrmLogin));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.bttnOK = new DevExpress.XtraEditors.SimpleButton();
            this.bttnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.rbPassword = new System.Windows.Forms.RadioButton();
            this.rbFingerprint = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(233, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "UID:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(205, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(286, 30);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(244, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(286, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(244, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // bttnOK
            // 
            this.bttnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.bttnOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bttnOK.ImageOptions.Image")));
            this.bttnOK.Location = new System.Drawing.Point(374, 111);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 3;
            this.bttnOK.Text = "Ok";
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bttnCancel.ImageOptions.Image")));
            this.bttnCancel.Location = new System.Drawing.Point(455, 111);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 4;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // rbPassword
            // 
            this.rbPassword.AutoSize = true;
            this.rbPassword.Checked = true;
            this.rbPassword.Location = new System.Drawing.Point(12, 28);
            this.rbPassword.Name = "rbPassword";
            this.rbPassword.Size = new System.Drawing.Size(164, 17);
            this.rbPassword.TabIndex = 6;
            this.rbPassword.TabStop = true;
            this.rbPassword.Text = "Login with UID and password";
            this.rbPassword.UseVisualStyleBackColor = true;
            // 
            // rbFingerprint
            // 
            this.rbFingerprint.AutoSize = true;
            this.rbFingerprint.Location = new System.Drawing.Point(12, 65);
            this.rbFingerprint.Name = "rbFingerprint";
            this.rbFingerprint.Size = new System.Drawing.Size(128, 17);
            this.rbFingerprint.TabIndex = 7;
            this.rbFingerprint.Text = "Login with Fingerprint";
            this.rbFingerprint.UseVisualStyleBackColor = true;
            // 
            // xfrmLogin
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(542, 146);
            this.Controls.Add(this.rbFingerprint);
            this.Controls.Add(this.rbPassword);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "xfrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aadhaar";
            this.Load += new System.EventHandler(this.xfrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton bttnOK;
        private DevExpress.XtraEditors.SimpleButton bttnCancel;
        private System.Windows.Forms.RadioButton rbPassword;
        private System.Windows.Forms.RadioButton rbFingerprint;
    }
}