using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmVisitInsurance : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmVisitInsurance()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmVisitInsurance_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            spuVisitInsuranceResultBindingSource.DataSource = dc.Spu_VisitInsurance(txtFrom.Text, txtTo.Text);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var fromdate = txtFrom.Text;
            var to = txtTo.Text;
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی تعداد مراجعین به کلینیک های تخضضی  از تاریخ {0} لغایت {1}", fromdate, to);
            printableComponentLink1.CreateDocument();

            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}