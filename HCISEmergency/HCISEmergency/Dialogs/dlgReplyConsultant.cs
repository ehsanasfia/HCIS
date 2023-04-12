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
    public partial class dlgReplyConsultant : DevExpress.XtraEditors.XtraForm
    {
        public dlgReplyConsultant()
        {
            InitializeComponent();
        }
        HCISDataContext dc = new HCISDataContext();
        private void dlgReplyConsultant_Load(object sender, EventArgs e)
        {
            try
            {
                var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName).UserID;
                specialityBindingSource.DataSource = dc.Specialities.ToList();

                consultantListToansewrBindingSource.DataSource = dc.Consultants.Where(c => c.DossierID == MainModule.GSM_Set.DossierID && c.StaffID == dc.Staffs.FirstOrDefault(x => x.UserID == clinicStaff).ID).ToList();
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            consultantListToansewrBindingSource.EndEdit();
            var clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName).UserID;

            var gsd = new GivenServiceD()
            {
                GivenServiceMID = MainModule.GSM_Set.ID,
                ServiceID = Guid.Parse("38561f84-b5b0-4db1-a6ac-63fe8f45e052"),
                Date = MainModule.GetPersianDate(DateTime.Now),
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                Staff = dc.Staffs.FirstOrDefault(c => c.UserID == clinicStaff)
            };
            var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
            if (tarefee == null)
            {
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
            }

            else if (tarefee.PatientShare == 0)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
            }
            else
            {
                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                gsd.PatientShare = tarefee.PatientShare ?? 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
            }
            dc.GivenServiceDs.InsertOnSubmit(gsd);

            //CheckUp.PaymentPrice = CheckUp.GivenServiceDs.Sum(x => x.PatientShare);
            //if (CheckUp.PaymentPrice == 0)
            //{
            //    CheckUp.Payed = true;
            //    CheckUp.PayedPrice = 0;
            //}
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد");
          this.DialogResult = DialogResult.OK;
            //   ConsultHistoryBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceMID == CheckUp.ID && x.Service.Service1.Name == "ویزیت و مشاوره").ToList();
        }
    }
}