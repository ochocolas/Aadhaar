using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace AadhaarEnroller.Forms
{
    public partial class xFingerPrintCapture : DevExpress.XtraEditors.XtraForm
    {
        public string ScannedFingerprint = String.Concat(Guid.NewGuid().ToString(), "-", Guid.NewGuid().ToString());
        public xFingerPrintCapture()
        {
            InitializeComponent();
        }

        private void xFingerPrintCapture_Load(object sender, EventArgs e)
        {
            

        }

        private void xFingerPrintCapture_Activated(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Reading fingerprint...");
            splashScreenManager1.SetWaitFormDescription("Please wait...");
            Thread.Sleep(2000);
            splashScreenManager1.CloseWaitForm();
            this.DialogResult = DialogResult.OK;
        }
    }
}