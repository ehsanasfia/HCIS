using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgAddFreeGSD : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddFreeGSD()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public HCISCashDataContextDataContext dc { get; internal set; }
        public GivenServiceM MainGSM { get; internal set; }
        GivenServiceD gsd = new GivenServiceD();
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim()=="")
            {
                MessageBox.Show("لطفا نوع هزینه را انتخاب کنید"); return;
            }
            if (txtinsureShare.Text.Trim() == "")
            {
                MessageBox.Show("لطفا سهم سازمان را وارد کنید"); return;
            }
            if (txtPatientShare.Text.Trim() == "")
            {
                MessageBox.Show("لطفا سهم بیمار را وارد کنید"); return;
            }
            try
            {
                gsd.GivenServiceM = MainGSM;
              //  gsd.Service = slkService.EditValue as Service;
              //  gsd.Amount = Int32.Parse(spnAmount.EditValue.ToString());
               // gsd.GivenAmount = Int32.Parse(spnAmount.EditValue.ToString());
                gsd.Comment = txtName.Text;
                gsd.LastModificator = MainModule.UserID;
                gsd.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsd.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsd.Date = MainModule.GetPersianDate(DateTime.Now);
                gsd.Time = DateTime.Now.ToString("HH:mm");
                gsd.Amount = txtAmount.Text != "" ? Int32.Parse(txtAmount.Text) : 1;
                gsd.GivenAmount = txtAmount.Text != "" ? Int32.Parse(txtAmount.Text) : 1;
                gsd.NoTake = false;
                gsd.PaymentPrice =(decimal) gsd.Amount* decimal.Parse(txtPatientShare.Text);
                gsd.PatientShare = (decimal)gsd.Amount * decimal.Parse(txtPatientShare.Text); 
                gsd.InsuranceShare = (decimal)gsd.Amount * decimal.Parse(txtinsureShare.Text);
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
                //if (slkDoctor.EditValue != null)
                //{
                //    gsd.FunctorID = Guid.Parse(slkDoctor.EditValue.ToString());
                //}
                if (gsd.ID == Guid.Empty)
                    dc.GivenServiceDs.InsertOnSubmit(gsd);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
           
        }
    }
}