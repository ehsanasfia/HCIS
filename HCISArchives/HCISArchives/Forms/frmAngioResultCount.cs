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
    public partial class frmAngioResultCount : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();

        public frmAngioResultCount()
        {
            InitializeComponent();
        }

        private void frmWardPatinetList_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            angioResultBindingSource.DataSource = dc.AngioResults.OrderBy(c => c.Result).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var res = slkResult.EditValue as AngioResult;
            if(res == null)
            {
                spuArchiveAngioResultResultBindingSource.DataSource = dc.Spu_ArchiveAngioResult(txtFrom.Text.Trim(), txtTo.Text.Trim()).ToList();
            }
            else
            {
                spuArchiveAngioResultResultBindingSource.DataSource = dc.Spu_ArchiveAngioResult(txtFrom.Text.Trim(), txtTo.Text.Trim()).Where(x => x.Result == res.Result).ToList();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش نتایج آنژیوگرافی از تاریخ {0} لغایت {1}", txtFrom.Text, txtTo.Text);
            printableComponentLink1.CreateDocument();

            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = new SaveFileDialog() { DefaultExt = "xlsx", Filter = "Excel Files (*.xlsx)|*.xlsx", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(dialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions() { RightToLeftDocument = DevExpress.Utils.DefaultBoolean.True });
                System.Diagnostics.Process.Start(dialog.FileName);
            }
        }
    }
}