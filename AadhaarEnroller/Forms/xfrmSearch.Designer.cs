namespace AadhaarEnroller.Forms
{
    partial class xfrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrmSearch));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.bttnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.bttnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "UID";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(83, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(323, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // bttnAcept
            // 
            this.bttnAcept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bttnAcept.ImageOptions.Image")));
            this.bttnAcept.Location = new System.Drawing.Point(250, 54);
            this.bttnAcept.Name = "bttnAcept";
            this.bttnAcept.Size = new System.Drawing.Size(75, 23);
            this.bttnAcept.TabIndex = 2;
            this.bttnAcept.Text = "OK";
            this.bttnAcept.Click += new System.EventHandler(this.bttnAcept_Click);
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bttnCancelar.ImageOptions.Image")));
            this.bttnCancelar.Location = new System.Drawing.Point(331, 54);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 3;
            this.bttnCancelar.Text = "Cancel";
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // xfrmSearch
            // 
            this.AcceptButton = this.bttnAcept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancelar;
            this.ClientSize = new System.Drawing.Size(418, 90);
            this.Controls.Add(this.bttnCancelar);
            this.Controls.Add(this.bttnAcept);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "xfrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton bttnAcept;
        private DevExpress.XtraEditors.SimpleButton bttnCancelar;
    }
}