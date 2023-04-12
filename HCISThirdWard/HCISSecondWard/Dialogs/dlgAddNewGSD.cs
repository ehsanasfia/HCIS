using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgAddNewGSD : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddNewGSD()
        {
            InitializeComponent();
        }

        public HCISDataContext dc { get; internal set; }
        public GivenServiceM MainGSM { get; internal set; }
        GivenServiceD gsd = new GivenServiceD();
        private void dlgAddNewGSD_Load(object sender, EventArgs e)
        {
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();

        }
        private void lkpServiceCat_EditValueChanged(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == Int32.Parse(lkpServiceCat.EditValue.ToString())).ToList();
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر").ToList();
                 }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (slkService.EditValue == null)
            {
                MessageBox.Show("لطفا خدمت را انتخاب کنید");return;
            }
                try
            {
                gsd.GivenServiceM = MainGSM;
                gsd.Service = slkService.EditValue as Service;
                gsd.Amount = Int32.Parse(spnAmount.EditValue.ToString());
                   gsd.GivenAmount = Int32.Parse(spnAmount.EditValue.ToString());
                gsd.Comment = "توسط کاربر درآمد اضافه شده";
                gsd.LastModificator = MainModule.UserID;
                gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                gsd.Time = DateTime.Now.ToString("HH:mm");
                gsd.PaymentPrice =decimal.Parse( txtPatientShare.Text);
                gsd.PatientShare = decimal.Parse(txtPatientShare.Text); ;
                gsd.InsuranceShare = decimal.Parse(txtInsureShare.Text); 
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                if (slkDoctor.EditValue != null)
                {
                   gsd. FunctorID = Guid.Parse(slkDoctor.EditValue.ToString());
                }
                if (gsd.ID == Guid.Empty)
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void slkService_EditValueChanged(object sender, EventArgs e)
        {
            var Service = slkService.EditValue as Service;
            gsd.Amount = int.Parse(spnAmount.EditValue.ToString());
            var tarefee = Service.Tariffs.Where(z => z.ServiceID == Service .ID && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
            if (tarefee == null)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
                gsd.TotalPrice = 0;
            }

            else if (tarefee.PatientShare == 0)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                gsd.TotalPrice = gsd.InsuranceShare;
            }
            else
            {
               // gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                txtPatientShare.Text = (gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0).ToString();
                txtInsureShare.Text = (gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0).ToString();
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            }
        }

        private void spnAmount_EditValueChanged(object sender, EventArgs e)
        {

            var Service = slkService.EditValue as Service;
            gsd.Amount = int.Parse(spnAmount.EditValue.ToString());
            var tarefee = Service.Tariffs.Where(z => z.ServiceID == Service.ID && z.InsuranceID == MainGSM.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
            if (tarefee == null)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
                gsd.TotalPrice = 0;
            }

            else if (tarefee.PatientShare == 0)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0;
                gsd.TotalPrice = gsd.InsuranceShare;
            }
            else
            {
                // gsd.PaymentPrice = (decimal)gsd.Amount * tarefee.PatientShare ?? 0;
                txtPatientShare.Text = (gsd.PatientShare = (decimal)gsd.Amount * tarefee.PatientShare ?? 0).ToString();
                txtInsureShare.Text = (gsd.InsuranceShare = (decimal)gsd.Amount * tarefee.OrganizationShare ?? 0).ToString();
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            }
        }
    }
}