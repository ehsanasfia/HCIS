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
using HCISOnCall.Data;
using HCISOnCall.Classes;
using HCISOnCall.Dialogs;

namespace HCISOnCall.Forms
{
    public partial class frmSubmit : DevExpress.XtraEditors.XtraForm
    {
        HCISOnCallDataContext dc = new HCISOnCallDataContext();

        public frmSubmit()
        {
            InitializeComponent();
        }

        private void frmSubmit_Load(object sender, EventArgs e)
        {
            var myStaff = dc.View_SecurityUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationName == "HCISSpecialist");
            var query = from c in dc.vwMemGroups
                        where c.HeadUserID == myStaff.UserID
                        select dc.Persons.FirstOrDefault(x => x.ID == c.ID);

            vwMemGroupBindingSource.DataSource = query.ToList();

            ShiftBindingSource.DataSource = dc.Shifts.ToList();

            GetData();
        }

        private void GetData()
        {
            oNcallBindingSource.DataSource = dc.ONcalls.ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgPeriodicCalender();
            dlg.dc = dc;
            dlg.ShowDialog();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.GetChangeSet().Updates.OfType<ONcall>().ToList().ForEach(c =>
            {
                c.History = c.History + " " + MainModule.GetPersianDate(DateTime.Now) + ' ' + DateTime.Now.ToString("HH:MM") + ' ' + MainModule.UserFullName;
            });
            dc.SubmitChanges();
            gridView1.RefreshRow(e.RowHandle);
        }
    }
}