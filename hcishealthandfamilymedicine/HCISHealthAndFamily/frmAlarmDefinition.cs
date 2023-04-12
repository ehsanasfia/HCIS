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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Dialogs;

namespace HCISHealthAndFamily
{
    public partial class frmAlarmDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmAlarmDefinition()
        {
            InitializeComponent();
        }

        private void frmAlarmDefinition_Load(object sender, EventArgs e)
        {
            alarmBindingSource.DataSource = dc.Alarms.OrderBy(c => c.Name).OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgAlarmDefinition();
            dlg.dc = dc;
            dlg.Text = "جدید";
            dlg.ShowDialog();
            alarmBindingSource.DataSource = dc.Alarms.OrderBy(c => c.Name).OrderByDescending(c => c.CreationDate).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = alarmBindingSource.Current as Alarm;
            if (cur == null)
                return;

            dc.AlarmDetails.DeleteAllOnSubmit(cur.AlarmDetails);
            dc.Alarms.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            alarmBindingSource.DataSource = dc.Alarms.OrderBy(c => c.Name).OrderByDescending(c => c.CreationDate).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}