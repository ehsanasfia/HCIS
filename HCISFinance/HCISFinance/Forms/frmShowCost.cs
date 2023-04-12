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
using HCISFinance.Data;

namespace HCISFinance.Forms
{
    public partial class frmShowCost : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<HCISCost> lst = new List<HCISCost>();

        public frmShowCost()
        {
            InitializeComponent();
        }

        private void frmShowCost_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.HCISCosts.Where(x => x.Income == false && x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0).OrderBy(c => c.Name).OrderBy(c => c.Date).ToList();
            hCISCostBindingSource.DataSource = lst;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}