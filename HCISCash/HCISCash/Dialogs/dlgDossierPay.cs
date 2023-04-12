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
using HCISCash.Data;
using HCISCash.Classes;

namespace HCISCash.Dialogs
{
    public partial class dlgDossierPay : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc { get; set; }
        public Dossier Dossier { get; internal set; }

        private List<Payment> DataList;
        public Payment current;


        public dlgDossierPay()
        {
            InitializeComponent();

        }
        private void GetData()
        {
            try
            {
                DataList = new List<Payment>();
                var HavePay = Dossier.AllPateintShare ?? 0;
                var PayedPriceAntilNowlst = dc.Payments.Where(x => x.DossierID == Dossier.ID).ToList();
                PayedPriceAntilNowlst.ForEach(c =>c.Price= (c.PayBackType == "استرداد") ? (c.Price * -1) : c.Price );
                var PayedPriceAntilNow = PayedPriceAntilNowlst.Count != 0 ? PayedPriceAntilNowlst.Sum(x => x.Price) : 0;
                Payment PayedPriceAntilNowRecord = new Payment() { Price = HavePay - PayedPriceAntilNow, };
                if (PayedPriceAntilNowRecord.Price > 0)
                    PayedPriceAntilNowRecord.Description = "مبلغ باقی مانده";
                else
                    PayedPriceAntilNowRecord.Description = "مبلغ استرداد";
                var SumAdvancePaymentPrice = PayedPriceAntilNowlst.Where(c => c.Description == "علی الحساب").ToList().Sum(c => c.Price);
                PayedPriceAntilNowlst.ForEach(c => c.Price = (c.PayBackType == "استرداد") ? (c.Price * -1) : c.Price);
                DataList = dc.Payments.Where(x => x.DossierID == Dossier.ID).ToList();
                if (SumAdvancePaymentPrice != 0)
                {
                    Payment SumAdvancePayment = new Payment() { Price = SumAdvancePaymentPrice, Description = "جمع علی الحساب ها" };
                    DataList.Add(SumAdvancePayment);
                }
                txtDate.Text = (HavePay - PayedPriceAntilNow).ToString();
                //if (HavePay - PayedPriceAntilNow == 0)
                //{
                //    Dossier.TotalPayed = true;
                //    dc.SubmitChanges();
                //}
                DataList.Add(PayedPriceAntilNowRecord);
                paymentBindingSource1.DataSource = DataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgPaidcatch_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var current = decimal.Parse(txtDate.Text.ToString());
            Boolean IsBack = false;
            if (current < 0)
            {
                IsBack = true;
            }
            var dlg = new Dialogs.dlgCreditOrCashBastari() { dc = dc, dossier = Dossier, havepay = decimal.Parse(txtDate.Text), IsBackPay = IsBack };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataList.AddRange(dlg.lstpay);
                dc.SubmitChanges();
                GetData();
                gridView1.RefreshData();
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("آیا مایلید قبض را استرداد کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        current = paymentBindingSource1.Current as Payment;
            //        if (current == null)
            //            return;
            //        var a = new Payment()
            //        {
            //            PayBackType = "قبض استرداد",
            //            Type = "نقدی",
            //            PayBackID = current.ID,
            //            Date = MainModule.GetPersianDate(DateTime.Now),
            //            Price = current.Price,
            //            PersonID = current.PersonID,
            //            Time = DateTime.Now.ToString("HH:mm")
            //        };
            //        var gsm = dc.GivenServiceMs.Where(x => x.PaymentID == current.ID).ToList();
            //        foreach (var item in gsm)
            //        {
            //            item.Payed = false;
            //            var gsd = dc.GivenServiceDs.Where(x => x.GivenServiceMID == item.ID).ToList();
            //            foreach (var given in gsd)
            //            {
            //                given.Payed = false;
            //            }
            //        }

            //        current.PayBack = true;
            //        dc.Payments.InsertOnSubmit(a);
            //        dc.SubmitChanges();
            //        MessageBox.Show("قبض با موفقیت ثبت گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            //        Return.Dictionary.Variables.Add("serial", current.SerialNumber + " ");
            //        Return.Dictionary.Variables.Add("date", current.Date);
            //        Return.Dictionary.Variables.Add("number", string.Format("{0:n0}", current.Price));
            //        Return.Dictionary.Variables.Add("alphabeat", PNumberTString.GetStr(current.Price.ToString()));
            //        Return.Dictionary.Variables.Add("serialpev", current.SerialNumber + " ");
            //        Return.Dictionary.Variables.Add("name", current.Person.FirstName + " " + current.Person.LastName + " ");
            //        //Return.Design();
            //        Return.Compile();
            //        Return.Render();
            //        Return.Show();
            //        GetData();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //        return;
            //    }
            //}

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            current = paymentBindingSource1.Current as Payment;
            if (current.PayBackType == "قبض استرداد")
            {
                Return.Dictionary.Variables.Add("serial", current.SerialNumber + " ");
                Return.Dictionary.Variables.Add("date", current.Date);
                Return.Dictionary.Variables.Add("number", string.Format("{0:n0}", current.Price));
                Return.Dictionary.Variables.Add("alphabeat", PNumberTString.GetStr(current.Price.ToString()));
                //Return.Dictionary.Variables.Add("قبلی سریال", current.SerialNumber + " ");
                Return.Dictionary.Variables.Add("name", current.Person.FirstName + " " + current.Person.LastName + " ");
                Return.Dictionary.Variables.Add("SpecialCode", current.Dossier.SpicialCode);
                Return.Dictionary.Variables.Add("username", MainModule.UserFullName);
                Print.Dictionary.Variables.Add("Description", current.Description);

                //Return.Design();    
                Return.Compile();
                Return.Render();
                Return.Show();
            }
            else
            {
                Print.Dictionary.Variables.Add("serial", current.SerialNumber);
                Print.Dictionary.Variables.Add("SpecialCode", current.Dossier.SpicialCode);
                Print.Dictionary.Variables.Add("username", MainModule.UserFullName);
                Print.Dictionary.Variables.Add("date", current.Date);
                Print.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", current.Price));
                Print.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(current.Price.ToString()));
                Print.Dictionary.Variables.Add("name kamel", current.Person.FirstName + " " + current.Person.LastName + " ");
                //Print.Dictionary.Variables.Add("servie", current);

                string a = "";

                //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";

                Print.Dictionary.Variables.Add("Description", current.Description);
                //Print.Design(); 
                Print.Compile();
                Print.Render();
                Print.Show();
            }
        }

        private void btnPrintall_Click(object sender, EventArgs e)
        {
            var MyData = from c in dc.Payments.Where(c=>c.DossierID==Dossier.ID)
                         select new
                         {
                             c.Date,
                             Fullname = c.Person.FirstName + " " + c.Person.LastName,
                             c.Price,
                             c.Person.NationalCode,
                             c.Type
                         };
            PrintAll.RegData("MyData", MyData);
            //PrintAll.Design();    
            PrintAll.Compile();
            PrintAll.Render();
            PrintAll.Show();

        }

        private void paymentBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            var current = paymentBindingSource1.Current as Payment;
            if (current.PayBackType == "قبض استرداد" || current.PayBack == true)
                btnReturn.Enabled = false;
            else
                btnReturn.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBaghiMande_Click(object sender, EventArgs e)
        {
            var current = decimal.Parse(txtDate.Text.ToString());
            List<Data.Payment> lst = new List<Data.Payment>();
           lst= dc.Payments.Where(x => x.DossierID == Dossier.ID).ToList();
            lst.ForEach(c => c.Price = (c.PayBackType == "استرداد") ? (c.Price * -1) : c.Price);
            var MyData = from x in lst

            select new
                         {
                             x.Description,
                             x.Type,
                             x.ID,
                             x.Price,
                             x.Date
                         };
            if (current < 0)
            {
                current = current * -1;
                stiESterdad.RegData("MyData", MyData);
                stiESterdad.Dictionary.Variables.Add("serial", Dossier.Department.Name);
                stiESterdad.Dictionary.Variables.Add("SpecialCode", Dossier.SpicialCode ?? "");
                stiESterdad.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                stiESterdad.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", current));
                stiESterdad.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(current.ToString()));
                stiESterdad.Dictionary.Variables.Add("name kamel", Dossier.Person.FirstName + " " + Dossier.Person.LastName + " ");
                stiESterdad.Dictionary.Variables.Add("AllPateintShare", Dossier.AllPateintShare);
                // stiESterdad.Design();
                stiESterdad.Compile();
                stiESterdad.Render();
                stiESterdad.Show();
            }
            else
            {
                stiDaryaft.RegData("MyData", MyData);
                stiDaryaft.Dictionary.Variables.Add("serial", Dossier.Department.Name);
                stiDaryaft.Dictionary.Variables.Add("SpecialCode", Dossier.SpicialCode ?? "");
                stiDaryaft.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                stiDaryaft.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", current));
                stiDaryaft.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(current.ToString()));
                stiDaryaft.Dictionary.Variables.Add("name kamel", Dossier.Person.FirstName + " " + Dossier.Person.LastName + " ");
                stiDaryaft.Dictionary.Variables.Add("AllPateintShare", Dossier.AllPateintShare);
                string a = "";
                stiDaryaft.Dictionary.Variables.Add("cats", a);
                stiDaryaft.Compile();
                stiDaryaft.Render();
                stiDaryaft.Show();
                  }
            lst.ForEach(c => c.Price = (c.PayBackType == "استرداد") ? (c.Price * -1) : c.Price);

        }

        private void ribDelete_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var cur = paymentBindingSource1.Current as Payment;
            dc.Payments.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            GetData();
        }
    }
}