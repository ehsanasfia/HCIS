using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{
    public partial class dlgTransfer : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public GivenServiceM EditingGSM { get; set; }
        public Guid MyID { get; set; }
        public dlgTransfer()
        {
            InitializeComponent();
        }

        private void dlgTransfer_Load(object sender, EventArgs e)
        {
            transferBindingSource.DataSource = dc.Transfers.Where(x => x.GivenServiceMID == EditingGSM.ID).OrderBy(x => x.Time).OrderBy(x => x.Date).ToList();
            gridView1.BestFitColumns();
            var lstDocs = dc.Staffs.Where(x => x.UserType == "دکتر").Select(x => x.Person).ToList();
            personsBindingSource.DataSource = lstDocs;
            var myPrs = lstDocs.FirstOrDefault(x => x.ID == MyID);
            if (myPrs != null)
            {
                lkpFrom.EditValue = myPrs.Staff;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((lkpTo.EditValue as Staff) == null || (lkpTo.EditValue as Staff) == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید.");
                return;
            }

            var trf = new Transfer()
            {
                CreatorID = MainModule.UserID,
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                GivenServiceMID = EditingGSM.ID,
                FromStaffID = (lkpFrom.EditValue as Staff).ID,
                ToStaffID = (lkpTo.EditValue as Staff).ID,
            };

            dc.Transfers.InsertOnSubmit(trf);
            EditingGSM.Staff = (lkpTo.EditValue as Staff);

            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
        }
    }
}