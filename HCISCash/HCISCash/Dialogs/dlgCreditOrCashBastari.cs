using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Classes;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgCreditOrCashBastari : DevExpress.XtraEditors.XtraForm
    {
        public dlgCreditOrCashBastari()
        {
            InitializeComponent();
        }
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        public List<Payment> lstpay = new List<Payment>();
        public Dossier dossier;
        public Boolean IsBackPay = false;
        public decimal havepay = 0;
        public decimal havepayCopy = 0;
        private void dlgCreditOrCashPay_Load(object sender, EventArgs e)
        {
            if (havepay < 0)
            {
                IsBackPay = true;
                havepay = -havepay;
            }
            if (IsBackPay)
                btnCreditPay.Text = "چک بانکی";
            havepayCopy = havepay;
            txthavePay.Text = havepay.ToString();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnCreditPay_Click(object sender, EventArgs e)
        {
            //if (havepay < decimal.Parse(txthavePay.Text))
            //{
            //    MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
            //    return;
            //}
             if (decimal.Parse(txthavePay.Text) ==0)
            {
                MessageBox.Show("مبلغ صفر می باشد");
                return;
            }
            Payment p = new Payment();
            p.Date = txtDate.Text;
            p.Time = DateTime.Now.ToString("HH:mm");
             p.Type = "کارت";
            if (IsBackPay)
                p.Type = "چک بانکی";
            p.Price = decimal.Parse(txthavePay.Text);
            havepay -=decimal.Parse( txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            
            p.PersonID = dossier.PersonID;
            p.DossierID = dossier.ID;
            p.GhabzCode = txtGhabzCode.Text;
            p.Description = txtDes.Text;
            p.PayBackType = IsBackPay ? "استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();
            //if (!dc.Payments.Any(c => c.ID == p.ID))
            //    dc.Payments.InsertOnSubmit(p);
        }

        private void btnCashPay_Click(object sender, EventArgs e)
        {
            //if (havepay< decimal.Parse(txthavePay.Text))
            //{ MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
            //    return;
            //}
            if (decimal.Parse(txthavePay.Text) ==0)
            {
                MessageBox.Show("مبلغ صفر می باشد");
                return;
            }
            Payment p = new Payment();
            p.Date = txtDate.Text;
            p.Time = DateTime.Now.ToString("HH:mm");
            p.Type = "نقدی";
            p.GhabzCode = txtGhabzCode.Text;
            p.Price = decimal.Parse(txthavePay.Text);
            havepay -= decimal.Parse(txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.PayBackType = IsBackPay ? "استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            p.PersonID = dossier.PersonID;
            p.DossierID = dossier.ID;
            p.Description = txtDes.Text;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try {
                if(havepay!=0)
                {
                    MessageBox.Show("مبلغ باقی مانده " + havepay.ToString() + " ریال می باشد");
                   // return;
                }
                var x = lstpay.Where(c => !dc.Payments.Any(d => d.ID == c.ID)).ToList();
                dc.Payments.InsertAllOnSubmit(lstpay);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            lstpay.Remove(paymentBindingSource.Current as Payment);
         //   dc.Payments.DeleteOnSubmit();
            paymentBindingSource.RemoveCurrent();
            havepay = (havepayCopy - lstpay.Sum(l => l.Price));
            txthavePay.Text = (havepayCopy - lstpay.Sum(l => l.Price)).ToString();
        }
    }
}