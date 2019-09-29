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
using AadhaarFramework.Code.Security;
using AadhaarFramework.Code.Data.Entity.Security;
namespace AadhaarEnroller.Forms
{
    public partial class xfrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public xfrmLogin()
        {
            InitializeComponent();
        }

        private void xfrmLogin_Load(object sender, EventArgs e)
        {
            AadhaarContext.Enviroment = AadhaarContext.EnviromentType.DESKTOP;
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            if (rbFingerprint.Checked)
            {
                xFingerPrintCapture xFingerPrintCapture = new xFingerPrintCapture();
                xFingerPrintCapture.ShowDialog();
                this.DialogResult = DialogResult.OK;
            }
            else if (rbPassword.Checked)
            {
                Authentication authentication = new Authentication();
                User user = authentication.Authenticate(txtUser.Text, txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Wrong user and/or password.", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}