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
    public partial class frmVisitSpecialDepartment : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        public frmVisitSpecialDepartment()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var year = spinEdit1.Value;
            var month = comboBox1.Text;
            vwDoctorSpecialityVisitBindingSource.DataSource = dc.Vw_DoctorSpecialityVisits.Where(x => x.Year == year.ToString() && x.MonthName == month);
            pivotGridControl1.BestFit();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var Year = spinEdit1.Text;
            var Month = comboBox1.Text;
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی بیماران مراجعا کرده به کلینیک های تخصصی و فوق تخصصی در سال {0} ماه {1}", Year, Month);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}