using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISArchives.Data;
using HCISArchives.Classes;
namespace HCISArchives.Forms
{
    public partial class frmCountWardPatient : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();

        public frmCountWardPatient()
        {
            InitializeComponent();
        }

        private void frmCountWardPatient_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dep = slkWard.EditValue as Department;
            if (dep == null)
                spuCountBastariPatientResultBindingSource.DataSource = dc.Spu_CountBastariPatient(txtFrom.Text,txtTo.Text).ToList();
            else
                spuCountBastariPatientResultBindingSource.DataSource = dc.Spu_CountBastariPatient(txtFrom.Text,txtTo.Text).Where(x => x.bakhsh == dep.Name).ToList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (slkWard.EditValue == null)
                return;

            var dep = slkWard.EditValue as Department;

            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کلی بیماران بستری بخش {2} از تاریخ {0} لغایت {1}", txtFrom.Text, txtTo.Text, dep.Name);
            printableComponentLink1.CreateDocument();

            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
        
        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = new SaveFileDialog() { DefaultExt = "xlsx", Filter = "Excel Files (*.xlsx)|*.xlsx", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(dialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions() { RightToLeftDocument = DevExpress.Utils.DefaultBoolean.True });
                System.Diagnostics.Process.Start(dialog.FileName);
            }
        }
    }
}