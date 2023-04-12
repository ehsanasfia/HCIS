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
    public partial class frmWorkHistory : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();

        public frmWorkHistory()
        {
            InitializeComponent();
        }

        private void frmWorkHistory_Load(object sender, EventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
            GetData();
        }

        void GetData()
        {
            if (MainModule.VST_Set == null)
            {
                MessageBox.Show("لطفا یک مراجعه کننده را انتخاب کنید");
                return;
            }
            personWorkHistoryBindingSource.DataSource = dc.PersonWorkHistories.Where(c=>c.PesronID==MainModule.VST_Set.PersonID).OrderByDescending(c => c.CreationDate).ToList();

        }
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgWorkHistory();
            dlg.dc = dc;
            dlg.EditingPerson = MainModule.VST_Set.Person;
            dlg.Text = "جدید";
            dlg.isEdit = false;
            dlg.ShowDialog();
            GetData();
            gridControl1.RefreshDataSource();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = personWorkHistoryBindingSource.Current as PersonWorkHistory;
            if (cur == null)
                return;

            var dlg = new dlgWorkHistory();
            dlg.dc = dc;
            dlg.EditingPerson = MainModule.VST_Set.Person;
            dlg.ObjectPWH = cur;
            dlg.isEdit = true;
            dlg.Text = "ویرایش";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GetData(); gridControl1.RefreshDataSource();
            }
            else
            {
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.ObjectPWH);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = personWorkHistoryBindingSource.Current as PersonWorkHistory;
            if (cur == null)
                return;

            dc.PersonWorkHistories.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            GetData(); gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}