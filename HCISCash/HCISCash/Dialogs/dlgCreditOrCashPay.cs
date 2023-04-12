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
    public partial class dlgCreditOrCashPay : DevExpress.XtraEditors.XtraForm
    {
        public dlgCreditOrCashPay()
        {
            InitializeComponent();
        }
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        public List<Payment> lstpay = new List<Payment>();
        public Dossier dossier;
        public string Descip="";
        public Boolean IsBackPay = false;
        public decimal havepay = 0;
        public decimal havepayCopy = 0;

        public GivenServiceM GSM { get; internal set; }

        private void dlgCreditOrCashPay_Load(object sender, EventArgs e)
        {
            if (IsBackPay)
                btnCreditPay.Text = "چک بانکی";
            havepayCopy = havepay;
            txthavePay.Text = havepay.ToString();
          
        }

        private void btnCreditPay_Click(object sender, EventArgs e)
        {
            if (havepay < decimal.Parse(txthavePay.Text))
            {
                MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
                return;
            }
            // if (decimal.Parse(txthavePay.Text) ==0)
            //{
            //    MessageBox.Show("مبلغ صفر می باشد");
            //    return;
            //}
            Payment p = new Payment();
            p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
            p.Time = DateTime.Now.ToString("HH:mm");
             p.Type = "تعهدی";
            if (IsBackPay)
            { p.Type = "چک بانکی";
                p.Payment1.ID = GSM.ParentID??Guid.Empty;
            }
            p.Price = decimal.Parse(txthavePay.Text);
            havepay -=decimal.Parse( txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.PersonID = dossier.PersonID;
            p.Description = Descip;
            p.Dossier = dossier;
            p.GivenServiceMID =GSM==null?Guid.Empty: GSM.ID;
            p.PayBackType = IsBackPay ? "قبض استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();
            try
            {
                dc.Payments.InsertAllOnSubmit(lstpay.Where(c => !dc.Payments.Any(d => d.ID == c.ID)));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCashPay_Click(object sender, EventArgs e)
        {
            if (havepay< decimal.Parse(txthavePay.Text))
            { MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
                return;
            }
            //if (decimal.Parse(txthavePay.Text) ==0)
            //{
            //    MessageBox.Show("مبلغ صفر می باشد");
            //    return;
            //}
         
            Payment p = new Payment();
            p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
            p.Time = DateTime.Now.ToString("HH:mm");
            p.Type = "نقدی";

            p.Price = decimal.Parse(txthavePay.Text);
            havepay -= decimal.Parse(txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.Description = Descip;
            p.PayBackType = IsBackPay ? "قبض استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            p.PersonID = dossier.PersonID;
            p.Dossier = dossier;
            p.GivenServiceMID = GSM == null ? Guid.Empty : GSM.ID;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();

        
            try
            {
                dc.Payments.InsertAllOnSubmit(lstpay.Where(c => !dc.Payments.Any(d => d.ID == c.ID)));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (havepay < decimal.Parse(txthavePay.Text))
            {
                MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
                return;
            }
            //if (decimal.Parse(txthavePay.Text) == 0)
            //{
            //    MessageBox.Show("مبلغ صفر می باشد");
            //    return;
            //}
            Payment p = new Payment();
            p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
            p.Time = DateTime.Now.ToString("HH:mm");
            p.Type = "سایر";

            p.Price = decimal.Parse(txthavePay.Text);
            havepay -= decimal.Parse(txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.PayBackType = IsBackPay ? "قبض استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            p.Description = Descip;
            p.PersonID = dossier.PersonID;
            p.Dossier = dossier;
            p.GivenServiceMID = GSM == null ? Guid.Empty : GSM.ID;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();

            try
            {
                dc.Payments.InsertAllOnSubmit(lstpay.Where(c => !dc.Payments.Any(d => d.ID == c.ID)));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            lstpay.Remove(paymentBindingSource.Current as Payment);
            paymentBindingSource.RemoveCurrent();
            havepay = (havepayCopy - lstpay.Sum(l => l.Price));
            txthavePay.Text = (havepayCopy - lstpay.Sum(l => l.Price)).ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (havepay < decimal.Parse(txthavePay.Text))
            {
                MessageBox.Show("مبلغ وارد شده بیشتر از مقدار قابل پرداخت می باشد");
                return;
            }
            //if (decimal.Parse(txthavePay.Text) ==0)
            //{
            //    MessageBox.Show("مبلغ صفر می باشد");
            //    return;
            //}

            Payment p = new Payment();
            p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
            p.Time = DateTime.Now.ToString("HH:mm");
            p.Type = "كارتی";

            p.Price = decimal.Parse(txthavePay.Text);
            havepay -= decimal.Parse(txthavePay.Text);
            p.CreatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.PayBackType = IsBackPay ? "قبض استرداد" : "پرداخت";
            p.PayBack = IsBackPay ? true : false;
            p.Description = Descip;
            p.PersonID = dossier.PersonID;
            p.Dossier = dossier;
            p.GivenServiceMID = GSM == null ? Guid.Empty : GSM.ID;
            lstpay.Add(p);
            txthavePay.Text = havepay.ToString();
            paymentBindingSource.DataSource = lstpay.ToList();


            try
            {
                dc.Payments.InsertAllOnSubmit(lstpay.Where(c => !dc.Payments.Any(d => d.ID == c.ID)));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}