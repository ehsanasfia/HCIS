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

namespace OMOApp.Dialogs
{
    public partial class dialogAddGroup : BaseDialog
    {
        public dialogAddGroup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        public string Title { get; set; }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Title = textEdit1.Text;
        }

        private void dialogAddGroup_Load(object sender, EventArgs e)
        {
            textEdit1.Text = Title;
        }
    }
}