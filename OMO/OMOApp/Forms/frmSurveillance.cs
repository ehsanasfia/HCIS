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
using OMOApp.Data;
using OMOApp.Dialogs;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmSurveillance : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();

        public frmSurveillance()
        {
            InitializeComponent();
        }

        private void frmSurveillance_Load(object sender, EventArgs e)
        {
            surveillanceBindingSource.DataSource = dc.Surveillances.Where(x => x.Deleted == false && x.VisitID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSurveillance();
            dlg.dc = dc;
            dlg.Text = "جدید";
            dlg.ShowDialog();
            surveillanceBindingSource.DataSource = dc.Surveillances.Where(x => x.Deleted == false && x.VisitID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = surveillanceBindingSource.Current as Surveillance;
            if (cur == null)
                return;

            var dlg = new dlgSurveillance();
            dlg.dc = dc;
            dlg.ObjectSRV = cur;
            dlg.Text = "ویرایش";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                surveillanceBindingSource.DataSource = dc.Surveillances.Where(x => x.Deleted == false && x.VisitID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
                gridControl1.RefreshDataSource();
            }
            else
            {
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.ObjectSRV);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = surveillanceBindingSource.Current as Surveillance;
            if (cur == null)
                return;

            cur.Deleted = true;
            dc.SubmitChanges();
            surveillanceBindingSource.DataSource = dc.Surveillances.Where(x => x.Deleted == false && x.VisitID == MainModule.VST_Set.ID).OrderByDescending(c => c.CreationDate).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnOldHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);

            var dlg = new Dialogs.dlgOldHistory();
            dlg.SelectedPrs = MainModule.VST_Set.Person;
            dlg.Surveillance = true;
            dlg.ShowDialog();
        }
    }
}