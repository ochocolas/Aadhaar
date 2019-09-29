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

namespace AadhaarEnroller.Forms
{
    public partial class xfrmSearch : DevExpress.XtraEditors.XtraForm
    {
        public long UID { get; set; } = 0;
        public xfrmSearch()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void bttnAcept_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                MessageBox.Show("Plese enter a valid UID", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool res = long.TryParse(txtSearch.Text, out long tmpUID);
            if (!res)
            {
                MessageBox.Show("Plese enter a valid UID", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.UID=tmpUID;
            this.DialogResult = DialogResult.OK;
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}