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
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class frmRecalls : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        SecurityControlClassesDataContext sec = new SecurityControlClassesDataContext();
        public Guid? RecallID { get; set; }
        public string NationalCode { get; set; }

        public frmRecalls()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var date = datePicker1.Date;
            if (chkShowAdmitted.Checked)
            {
                recallsBindingSource.DataSource = dc.Recalls.Where(x => x.RecallDate == date).OrderBy(x => x.Person.PersonalCode).ThenBy(x => x.Person.NationalCode).ToList();
            }
            else
            {
                recallsBindingSource.DataSource = dc.Recalls.Where(x => x.RecallDate == date && x.Admitted == false).OrderBy(x => x.Person.PersonalCode).ThenBy(x => x.Person.NationalCode).ToList();
            }
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = recallsBindingSource.Current as Recall;
            if (cur == null)
                return;

            if (cur.Admitted)
            {
                MainModule.GSM_Set = cur.GivenServiceMs.FirstOrDefault();
                DialogResult = DialogResult.OK;
            }
            else
            {
                RecallID = cur.ID;
                NationalCode = cur.Person.NationalCode;
                var frm = new frmOutDoor() { NationalCode = NationalCode, RecallID = RecallID };
                frm.Show();
                frm.brbOk.PerformClick();
                frm.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void frmRecalls_Load(object sender, EventArgs e)
        {
            tblUserBindingSource.DataSource = sec.tblUsers.Select(x => new { x.UserID, FullName = x.FirstName + " " + x.LastName }).ToList();
            btnSearch.PerformClick();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void frmRecalls_Shown(object sender, EventArgs e)
        {
            if (MainModule.GSM_Set != null)
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm.Recall != null)
                {
                    datePicker1.Date = gsm.Recall.RecallDate;
                    btnSearch.PerformClick();
                }
            }
        }
    }
}