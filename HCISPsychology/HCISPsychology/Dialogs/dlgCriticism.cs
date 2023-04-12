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
    public partial class dlgCriticism : DevExpress.XtraEditors.XtraForm
    {
        public dlgCriticism()
        {
            InitializeComponent();
        }

        private void dlgCriticism_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}