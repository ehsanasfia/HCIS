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
    public partial class dlgPaidCatch : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc { get; set; }
        private List<Vw_DosseirPayment> DataList;
        public Vw_DosseirPayment current;


        public dlgPaidCatch()
        {
            InitializeComponent();

        }
        private void GetData()
        {
            try
            {
                var toDay = txtDate.Text;
                DataList = dc.Vw_DosseirPayments.Where(x => x.Date == toDay).ToList();
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
            GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایلید قبض را استرداد کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                try
                {
                    current = vwDosseirPaymentBindingSource.Current as Vw_DosseirPayment;
                    if (current == null)
                    {
                        MessageBox.Show("لطفا یک قبض را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    //}//////////// inja bayad forme esterdad baraye hamon gms namayesh dade shavad
                    
                    dlgBackPaymentNew dlg = new Dialogs.dlgBackPaymentNew();
                       
                        dlg.dc = this.dc;
                    dlg.Payment =dc.Payments.Where(c=>c.SerialNumber== current.SerialNumber).FirstOrDefault();
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (MessageBox.Show("آیا مایلید قبض را دریافت کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                            {
                                dlg.StiReturn.Compile();
                                dlg.StiReturn.Render();
                                dlg.StiReturn.ShowWithRibbonGUI();
                            }
                            GetData();
              
                    current.PayBack = true;
                  //  dc.Payments.InsertOnSubmit(a);
                    dc.SubmitChanges();
                
                    GetData();
                    }
                    else
                    {
                        //dc.Dispose();
                        //dc = new HCISCashDataContextDataContext();
                        //GetData();
                    }
                }
                  
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {try
            {
                current = vwDosseirPaymentBindingSource.Current as Vw_DosseirPayment;
              var cur=  dc.Payments.Where(c => c.SerialNumber == current.SerialNumber).FirstOrDefault();
                if (current.PayBackType == "قبض استرداد")
                {
                    Return.Dictionary.Variables.Add("serial", cur.SerialNumber + " ");
                    Return.Dictionary.Variables.Add("date", cur.Date);
                    Return.Dictionary.Variables.Add("number", string.Format("{0:n0}", cur.Price));
                    Return.Dictionary.Variables.Add("alphabeat", PNumberTString.GetStr(cur.Price.ToString()));
                    Return.Dictionary.Variables.Add("serialpev", cur.Payment1.SerialNumber + " ");
                    Return.Dictionary.Variables.Add("name", cur.Person.FirstName + " " + cur.Person.LastName + " ");
                    //Return.Design();    
                    Return.Compile();
                    Return.Render();
                    Return.Show();
                }
                else
                {
                    Print.Dictionary.Variables.Add("serial", cur.SerialNumber);
                    Print.Dictionary.Variables.Add("date", cur.Date);
                    Print.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", cur.Price));
                    Print.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(cur.Price.ToString()));
                    Print.Dictionary.Variables.Add("name kamel", cur.Person.FirstName + " " + cur.Person.LastName + " ");
                    Print.Dictionary.Variables.Add("CashName", cur.CreatorFullName);
                    //Print.Dictionary.Variables.Add("servie", current);
                    string a = dc.GivenServiceMs.FirstOrDefault(c => c.ID == cur.GivenServiceMID).ServiceCategory.Name;

                    //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";

                    Print.Dictionary.Variables.Add("cats", a);
                    //Print.Design(); 
                    Print.Compile();
                    Print.Render();
                    Print.Show();
                }
            }
            catch
            {
                current = vwDosseirPaymentBindingSource.Current as Vw_DosseirPayment;
                var cur = dc.Payments.Where(c => c.SerialNumber == current.SerialNumber).FirstOrDefault();
                if (current.PayBackType == "قبض استرداد")
                {
                    Return.Dictionary.Variables.Add("serial", cur.SerialNumber + " ");
                    Return.Dictionary.Variables.Add("date", cur.Date);
                    Return.Dictionary.Variables.Add("number", string.Format("{0:n0}", cur.Price));
                    Return.Dictionary.Variables.Add("alphabeat", PNumberTString.GetStr(cur.Price.ToString()));
                 //   Return.Dictionary.Variables.Add("serialpev", current.Payment1.SerialNumber + " ");
                    Return.Dictionary.Variables.Add("name", cur.Person.FirstName + " " + cur.Person.LastName + " ");
                    //Return.Design();    
                    Return.Compile();
                    Return.Render();
                    Return.Show();
                }
                else
                {
                    Print.Dictionary.Variables.Add("serial", cur.SerialNumber);
                    Print.Dictionary.Variables.Add("date", cur.Date);
                    Print.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", cur.Price));
                    Print.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(cur.Price.ToString()));
                    Print.Dictionary.Variables.Add("name kamel", cur.Person.FirstName + " " + cur.Person.LastName + " ");
                    Print.Dictionary.Variables.Add("CashName", cur.CreatorFullName);
                    //Print.Dictionary.Variables.Add("servie", current);
                    string a = dc.GivenServiceMs.FirstOrDefault(c => c.ID == cur.GivenServiceMID).ServiceCategory.Name;

                    //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";

                    Print.Dictionary.Variables.Add("cats", a);
                    //Print.Design(); 
                    Print.Compile();
                    Print.Render();
                    Print.Show();
                }
            }
        }

        private void btnPrintall_Click(object sender, EventArgs e)
        {
            var MyData = from c in dc.Vw_DosseirPayments
                         where c.Date == txtDate.Text
                         select new
                         {
                             c.Date,
                             Fullname = c.FirstName + " " + c.LastName,
                             c.Price,
                             c.NationalCode,
                             c.Type,
                             c.InsuranceName
                         };
            PrintAll.RegData("MyData", MyData);
            //PrintAll.Design();    
            PrintAll.Compile();
            PrintAll.Render();
            PrintAll.Show();

        }

        private void paymentBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            var current = vwDosseirPaymentBindingSource.Current as Vw_DosseirPayment;
            if (current.PayBackType == "قبض استرداد" || current.PayBack == true )
                btnReturn.Enabled = false;
            else
                btnReturn.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}