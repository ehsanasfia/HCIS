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
using HCISArchives.Data;
using HCISArchives.Dialogs;

namespace HCISArchives.Forms
{
    public partial class frmArchiveByZone : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();

        public frmArchiveByZone()
        {
            InitializeComponent();
        }

        private void frmArchiveByZone_Load(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void GetData()
        {
            var from = txtFrom.Text.Trim();
            var to = txtTo.Text.Trim();
            vwArchiveByZoneBindingSource.DataSource = dc.Vw_ArchiveByZones.Where(x => x.DossDate.CompareTo(from) >= 0 && x.DossDate.CompareTo(to) <= 0).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void vwArchiveByZoneBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = vwArchiveByZoneBindingSource.Current as Vw_ArchiveByZone;
            if (current == null)
                return;

            if (dc.GivenServiceMs.Any(x => x.DossierID == current.DossID && x.ServiceCategoryID == 9 || x.ServiceCategoryID == 11))
            {
                layoutControlItem5.Visibility = layoutControlItem6.Visibility = splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossID && x.GivenServiceM.ServiceCategoryID == 11).ToList();
                givenServiceDBindingSource1.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == current.DossID && x.GivenServiceM.ServiceCategoryID == 9).ToList();
            }
            else
            {
                layoutControlItem5.Visibility = layoutControlItem6.Visibility = splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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