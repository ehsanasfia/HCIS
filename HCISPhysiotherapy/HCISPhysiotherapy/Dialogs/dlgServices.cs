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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgServices : DevExpress.XtraEditors.XtraForm
    {
        public GivenServiceM GSM { get; set; }
        public dlgServices()
        {
            InitializeComponent();
        }

        private void dlgServices_Load(object sender, EventArgs e)
        {
            givenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.فیزیوتراپی ).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Q | Keys.Control))
            {
                btnClose.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}