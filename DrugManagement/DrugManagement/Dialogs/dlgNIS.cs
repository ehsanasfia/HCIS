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
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class dlgNIS : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public dlgNIS()
        {
            InitializeComponent();
        }

        private void dlgNIS_Load(object sender, EventArgs e)
        {
            pharmacyBindingSource.DataSource = dc.Pharmacies.Where(c => c.ID == c.Department.ID).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}