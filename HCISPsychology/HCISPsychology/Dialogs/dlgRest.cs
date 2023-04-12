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

namespace HCISPsychology.Dialogs
{
    public partial class dlgRest : DevExpress.XtraEditors.XtraForm
    {
        public dlgRest()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
                memZayeman.Enabled = false;
            else
                memZayeman.Enabled = true;
        }
    }
}