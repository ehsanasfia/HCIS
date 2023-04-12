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
    public partial class dlgPaidShift : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        public SecurityDBDataContext dcs = new SecurityDBDataContext();
        private List<Vw_DosseirPayment> DataList;
        public Payment current;


        public dlgPaidShift()
        {
            InitializeComponent();

        }
        private void GetData()
        {
            try
            {
                var usr = lookUpEdit1.EditValue as tblUser;
                if (usr == null)
                {
                    MessageBox.Show("كاربر صندوق را انتخاب کنید");
                    return;
                }
                var FromDate = txtDate.Text;
                var ToDate = txtDateTo.Text;
                var CashUser = dcs.tblUsers.FirstOrDefault(c => c.UserName == usr.UserName && c.tblApplication.ApplicationName == "HCISCash");
                var HcisUser = dcs.tblUsers.FirstOrDefault(c => c.UserName == usr.UserName && c.tblApplication.ApplicationName == "HCIS");
                DataList = dc.Vw_DosseirPayments.Where(x => x.Date.CompareTo(FromDate) >= 0 && x.Date.CompareTo(ToDate) <= 0 && (x.CreatorUserID == CashUser.UserID || x.CreatorUserID == HcisUser.UserID)).ToList();
                vwDosseirPaymentBindingSource.DataSource = DataList;

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
            txtDateTo.Text = MainModule.GetPersianDate(DateTime.Now);
            tblUserBindingSource.DataSource = dcs.tblUsers.Where(c => c.tblApplication.ApplicationName == "HCISCash").ToList();

            //  GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
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
            if (DataList != null)
                if (DataList.Count > 0)
                {
                    var MyData = from c in DataList
                                 select new
                                 {
                                     c.Date,
                                     Fullname = c.FirstName + " " + c.LastName,
                                     c.Price,
                                     c.NationalCode,
                                     c.SerialNumber,c.InsuranceName,
                                     Type = c.PayBackType == "قبض استرداد" ? c.PayBackType : c.Type
                                 };
                    PrintShift.Dictionary.Variables.Add("user", (lookUpEdit1.EditValue as tblUser).FirstName.ToString() + " " + (lookUpEdit1.EditValue as tblUser).LastName.ToString());
                    PrintShift.RegData("MyData", MyData);
                    // PrintShift.Design();    
                    PrintShift.Compile();
                    PrintShift.Render();
                    PrintShift.Show();
                }
        }

        private void btnPrintall_Click(object sender, EventArgs e)
        {
            var MyData = from c in dc.Vw_DosseirPayments.Where(x => x.Date.CompareTo(txtDate.Text) >= 0 && x.Date.CompareTo(txtDateTo.Text) <= 0).ToList()
                         select new
                         {
                             c.Date,
                             Fullname = c.FirstName + " " + c.LastName,
                             c.Price,
                             c.NationalCode,
                             c.SerialNumber,
                             c.CreatorFullName,c.InsuranceName,
                             Type = c.PayBackType == "قبض استرداد" ? c.PayBackType : c.Type
                         };
            PrintAll.Dictionary.Variables.Add("DateFrom", txtDate.Text);
            PrintAll.Dictionary.Variables.Add("DateTo", txtDateTo.Text);
            PrintAll.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now).ToString());
            PrintAll.RegData("MyData", MyData);
           //  PrintAll.Design();    
            PrintAll.Compile();
            PrintAll.Render();
            PrintAll.CompiledReport.Show();
        }

        private void paymentBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            //var current = paymentBindingSource1.Current as Payment;
            //if (current.PayBackType == "قبض استرداد" || current.PayBack == true)
            //    btnReturn.Enabled = false;
            //else
            //    btnReturn.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}