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
using Stimulsoft;
using DevExpress.XtraGrid.Views.Grid;

namespace HCISCash.Dialogs
{
    public partial class dlgBackPaymentNew : DevExpress.XtraEditors.XtraForm
    {
        public HCISCashDataContextDataContext dc { get; set; }
       
        public Dossier dossier { get; set; }
        public GivenServiceM M { get; set; }
        public Person person { get; set; }
        public Guid personID { get; set; }
        public bool Local { get; set; }
        public int ServiceCategory { get; set; }
        public Guid DiagnosticParent { get; set; }
        List<GivenServiceM> GivenMInstallment { get; set; }
        public Payment Payment { get; internal set; }

        public List<GivenServiceM> lstGivenServiceM = new List<GivenServiceM>();
        public List<GivenServiceM> lstGivenServicePhyM = new List<GivenServiceM>();
        public List<GivenServiceD> lstGivenServiceD = new List<GivenServiceD>();
        public List<Payment> lstPayment;
        public dlgBackPaymentNew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgPayment_Load(object sender, EventArgs e)
        {
           
            M = dc.GivenServiceMs.FirstOrDefault(c => c.ID == Payment.GivenServiceMID);
            person = M.Person;
            personBindingSource.DataSource = person;
            var GivenD = M.GivenServiceDs.Where(c => c.Payed == true/* c.Reflected == true*/).ToList();
                M.PayedPrice = GivenD.Sum(c => c.PatientShare);
                M.PaymentPrice = GivenD.Sum(c => c.PatientShare);
           

            lstGivenServiceM.Add(M );
            givenServiceMBindingSource.DataSource = lstGivenServiceM;

            lstGivenServiceD = new List<GivenServiceD>();

          
                var GSM = givenServiceMBindingSource.Current as GivenServiceM;
                lstGivenServiceD.AddRange(GSM.GivenServiceDs.Where(c => c.Payed == true)/*c.Reflected==true*/);
 
            givenServiceDBindingSource.DataSource = lstGivenServiceD;
            var View1 = gridView2;
            View1.BeginUpdate();
            try
            {
            
                View1.ExpandAllGroups();
                View1.SelectAll();

            }
            finally
            {
                View1.EndUpdate();
            }
        }

        private void installment()
        {
            if (person.AllowInstallment == true && dossier.GivenServiceMs.Any(p => /* p.Reflected == true &&*/ p.Cancelled == false && p.ServiceCategoryID == (int)Category.داندانپزشکی))
            {
                InstallmentTab1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                GivenMInstallment = new List<GivenServiceM>();
                GivenMInstallment = dossier.GivenServiceMs.Where(p => p.Payed != true && p.Cancelled == false && p.ServiceCategoryID == (int)Category.داندانپزشکی).ToList();
                foreach (var GivenM in GivenMInstallment)
                {
                    var GivenD = GivenM.GivenServiceDs/*.Where(c => c.Reflected == true).*/.ToList();
                    GivenM.PayedPrice = GivenD.Sum(c => c.PatientShare);
                    GivenM.PaymentPrice = GivenD.Sum(c => c.PatientShare);
                }
                lstPayment = dc.Payments.Where(x => x.InstallMent == "قسط").ToList();
                var TotalPrice = GivenMInstallment.Sum(c => c.PaymentPrice);
                var payedPrice = lstPayment.Sum(c => c.Price);
                txtTotalPrice.Text = ((int)TotalPrice).ToString();
                txtPayedPrice.Text = ((int)payedPrice).ToString();
                txtRemainPrice.Text = ((int)(TotalPrice - payedPrice)).ToString();
                paymentBindingSource.DataSource = lstPayment;
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                decimal havepay = 0;
           
                //  p.StaffID=dc.Staffs.Where(c=>c.UserID==MainModule.UserID)
                bool flag = false; string servicecat = "";
               
                    var GSM = givenServiceMBindingSource.Current as GivenServiceM;
                    bool flagDetail = false;
                    servicecat += GSM.ServiceCategory.Name + ", ";
                if (gridView2.GetSelectedRows().Count() == 0)
                {
                    MessageBox.Show("هیچ رکوردی انتخاب نشده!");
                    return;
                }
                foreach (var DetailItem in gridView2.GetSelectedRows())
                {
                    var GSD = gridView2.GetRow(DetailItem) as GivenServiceD;
                    if (!gridView2.IsGroupRow(DetailItem))
                        if (GSD.GivenServiceMID == GSM.ID)
                        {
                            flagDetail = true;
                            GSD.Payed = false;
                            GSD.Reflected = false;
                            havepay += GSD.PatientShare;

                        }
                }
                  
                    flag = true;
                    if (GSM.Payed == false)
                    {
                        MessageBox.Show("فاکتور انتخاب شده قبلا استرداد شده است!");
                        return;
                    }
                    
                    GSM.PayedPrice = GSM.PayedPrice- (decimal)GSM.GivenServiceDs/*.Where(r => r.Reflected)*/.Sum(c => c.PatientShare);
                    GSM.PaymentPrice = GSM.PayedPrice - (decimal)GSM.GivenServiceDs/*.Where(r => r.Reflected)*/.Sum(c => c.PatientShare);

                 
                if (!flag)
                {
                    MessageBox.Show("هیچ موردی انتخاب نشده است.");
                    return;
                }
                servicecat = servicecat.Substring(0, servicecat.Length - 1);
                dossier = GSM.Dossier;
                var dlgpay = new dlgCreditOrCashPay() { dossier = dossier,GSM=GSM, dc = dc, havepay = havepay, IsBackPay = true };
                if (dlgpay.ShowDialog() == DialogResult.OK)
                {
                        foreach (var DetailItem in gridView2.GetSelectedRows())
                        {
                            var GSD = gridView2.GetRow(DetailItem) as GivenServiceD;
                            if (!gridView2.IsGroupRow(DetailItem))
                                if (GSD.GivenServiceMID == GSM.ID)
                                {
                                   
                                    GSD.Payed = false;
                                    GSD.Reflected = false;
                                    GSD.PatientShare = 0;
                                    GSD.InsuranceShare = 0;

                                }
                        }

                    
                        
                        GSM.PayedPrice = GSM.PayedPrice - (decimal)GSM.GivenServiceDs.Where(r => r.Reflected).Sum(c => c.PatientShare);
                        GSM.PaymentPrice = GSM.PayedPrice - (decimal)GSM.GivenServiceDs.Where(r => r.Reflected).Sum(c => c.PatientShare);

                        GSM.Reflected = false;
                      //  if (GSM.PayedPrice == 0)
                            GSM.Payed = false;

                    dlgpay.lstpay.FirstOrDefault().PayBackID = Payment.ID;
                    ////////
                    dc.SubmitChanges();
                    MessageBox.Show("استرداد با موفقیت انجام شد");
                    try
                    {
                      

                        var quary = from x in dlgpay. lstpay
                                    select new { x.SerialNumber,
                                        x.PayBack, x.Type, x.Date,
                                        Name = x.Person.FirstName + " " + x.Person.LastName, x.Time,
                                        x.Price, servicecat = servicecat,
                                        PriceNum = PNumberTString.GetStr(x.Price.ToString()) };
                            StiReturn.Dictionary.Variables.Add("serial",Payment.SerialNumber);
                            StiReturn.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                            StiReturn.Dictionary.Variables.Add("price adad", string.Format("{0:n0}", havepay));
                            StiReturn.Dictionary.Variables.Add("alphabeat", PNumberTString.GetStr(havepay.ToString()));
                            StiReturn.Dictionary.Variables.Add("namekamel", dossier.Person.FirstName + " " + dossier.Person.LastName + " ");

                            StiReturn.Dictionary.Variables.Add("CashName", MainModule.UserFullName);
                            //Print.Dictionary.Variables.Add("servie", current);

                            //  string a = "";

                            //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";
                            //  StiPayment.Dictionary.Variables.Add("cats", servicecat);
                            StiReturn.RegData("mydata", quary);
                         //   StiReturn.Design();
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dlgPayment_Shown(object sender, EventArgs e)
        {
            var View = grdBill;
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    View.SetMasterRowExpanded(rHandle, true);
                View.SelectAll();

            }
            finally
            {
                View.EndUpdate();
            }

            var View1 = gridView2;

            View1.BeginUpdate();
            try
            {
                //int dataRowCount = View1.DataRowCount;
                //for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                //    View1.SetMasterRowExpanded(rHandle, true);
                View1.ExpandAllGroups(); View1.SelectAll();

            }
            finally
            {
                View1.EndUpdate();
            }

           // layoutControlGroup3.Expanded = false;
            //foreach (var item in grdBill.GetSelectedRows())
            //{

            //    if (grdBill.GetMasterRowExpanded(item))
            //    {
            //        GridView View1 = (GridView)grdBill.GetDetailView(item, 0);

            //        View1.BeginUpdate();
            //        try
            //        {
            //            View1.SelectAll();

            //        }
            //        finally
            //        {
            //            View1.EndUpdate();
            //        }
            //    }
            //}
            //x = 1;
        }
        private void grdBill_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            lstGivenServiceD = new List<GivenServiceD>();

            foreach (var item in grdBill.GetSelectedRows())
            {
                var GSM = grdBill.GetRow(item) as GivenServiceM;
                lstGivenServiceD.AddRange(GSM.GivenServiceDs.Where(c=>c.Payed==true)/*c.Reflected==true*/);
               
            }
            givenServiceDBindingSource.DataSource = lstGivenServiceD;


            var View1 = gridView2;

            View1.BeginUpdate();
            try
            {
                //int dataRowCount = View1.DataRowCount;
                //for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                //    View1.SetMasterRowExpanded(rHandle, true);
                View1.ExpandAllGroups();
                View1.SelectAll();

            }
            finally
            {
                View1.EndUpdate();
            }
            //for (int i = 0; i < grdBill.DataRowCount; i++)
            //{
            //    if (!grdBill.IsRowSelected(i))
            //    {
            //        if (grdBill.GetMasterRowExpanded(i))
            //        {
            //            GridView detailView = (GridView)grdBill.GetDetailView(i, 0);

            //            foreach (var DetailItem in detailView.GetSelectedRows())
            //            {
            //                detailView.UnselectRow(DetailItem);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (grdBill.GetMasterRowExpanded(i))
            //        {
            //            GridView detailView = (GridView)grdBill.GetDetailView(i, 0);
            //            detailView.SelectAll();

            //        }
            //    }


            //}
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var lst = grdBill.GetSelectedRows();
            foreach (var item in lst)
            {
                var GSM = grdBill.GetRow(item) as GivenServiceM;
                GSM.PayedPrice = 0;
                GSM.PaymentPrice = 0;

                var lstD = gridView2.GetSelectedRows();
                foreach (var DetailItem in gridView2.GetSelectedRows())
                {
                    var GSD = gridView2.GetRow(DetailItem) as GivenServiceD;
                    if (!gridView2.IsGroupRow(DetailItem))

                        if (GSD.GivenServiceMID == GSM.ID)
                        {
                            GSM.PayedPrice += GSD.PayedPrice;
                            GSM.PaymentPrice += (decimal)GSD.PaymentPrice;
                        }
                }
            }

        }

        private void gridView2_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {

        }

        private void btnPayedPhy_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPhyGivenM.GetSelectedRows().Count() == 0)
                {
                    MessageBox.Show("هیچ رکوردی انتخاب نشده است.");
                    return;
                }

                //  p.StaffID=dc.Staffs.Where(c=>c.UserID==MainModule.UserID)
                string servicecat = "";
                foreach (var item in grdPhyGivenM.GetSelectedRows())
                {
                    Payment p = new Payment();

                    p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
                    p.Time = DateTime.Now.ToString("HH:mm");
                    if (chkPaymentTypePhy.Checked == true)
                        p.Type = "کارت";
                    else p.Type = "نقد";
                    p.Price = 0;
                    p.CreatorUserID = MainModule.UserID;
                    p.CreatorFullName = MainModule.UserFullName;
                    var GSM = grdPhyGivenM.GetRow(item) as GivenServiceM;

                    servicecat = GSM.ServiceCategory.Name;
                    foreach (var DetailItem in GSM.GivenServiceDs)
                    {
                        var GSD = DetailItem;
                        GSD.Payed = true;

                    }

                    if (GSM.Payed == true)
                    {
                        MessageBox.Show("فاکتور انتخاب شده قبلا پرداخت شده است!");
                        return;
                    }
                    p.Price = (decimal)GSM.PayedPrice;
                    p.PersonID = GSM.PersonID;
                   // p.GivenServiceM = GSM;
                    GSM.Payed = true;
                    if (!dc.Payments.Any(c => c.ID == p.ID))
                        dc.Payments.InsertOnSubmit(p);
                }

                dc.SubmitChanges();

                MessageBox.Show(".پرداخت با موفقیت انجام شد");

                try
                {
                    var mydata = from c in lstGivenServiceM
                                 select new
                                 {
                                     c.Date,
                                     c.Person.FirstName,
                                     c.Person.LastName,
                                     ServiceCat = servicecat,
                                     c.PayedPrice,
                                     c.PaymentPrice,
                                     Insurance = c.Insurance == null ? "" : c.Insurance.Name
                                 };

                    stiReport1.RegData("mydata", mydata);

                    stiReport1.Compile();
                    stiReport1.CompiledReport["DateNow"] = MainModule.GetPersianDate(DateTime.Now);


                    //  stiReport1.Design();

                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch { }

        }

        private void calcEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //    var Count =Int32.Parse( spinEdit1.Text);
            //    List<Payment> lstpayment = new List<Payment>();
            //var myM=  lstGivenServiceM.Where(c => c.ServiceCategoryID == (int)Category.داندانپزشکی).FirstOrDefault();

            //    for (int i = 0; i < Count; i++)
            //    {
            //        Payment p = new Payment();

            //        lstpayment.Add(p);
            //    }
        }

        private void BtnInstallmentPay_Click(object sender, EventArgs e)
        {
            if (txtPaymentPrice.Text.Trim() == "")
            {
                MessageBox.Show("مبلغ پرداختی را وارد کنید"); return;
            }
            var TotalPrice = GivenMInstallment.Sum(c => c.PaymentPrice);
            // txtTotalPrice.Text = TotalPrice.ToString();
            var payedPrice = lstPayment.Sum(c => c.Price);
            var X = payedPrice + decimal.Parse(txtPaymentPrice.Text);
            txtRemainPrice.Text = ((int)(TotalPrice - payedPrice)).ToString();
            if (X > TotalPrice)
            {
                txtPaymentPrice.Text = txtRemainPrice.Text;
                MessageBox.Show("مبلغ پرداختی بیشتر از مبلغ بدهی می باشد"); return;
            }
            var myM = lstGivenServiceM.Where(c => c.ServiceCategoryID == (int)Category.داندانپزشکی).FirstOrDefault();


            Payment p = new Payment();
            if (chkPaymentTypeInstal.Checked == true)
                p.Type = "کارت";
            else p.Type = "نقد";
            p.Price = decimal.Parse(txtPaymentPrice.Text);
            p.Person = person;
            //  p.GivenServiceM = GivenMInstallment;

            p.PayBackType = "";
            p.Date = MainModule.GetPersianDate(DateTime.Now).ToString();
            p.Time = DateTime.Now.ToString("HH:mm");
            if (X == TotalPrice)
            {
                p.InstallMent = "تمام";
            }
            else
                p.InstallMent = "قسط";
            p.CreatorUserID = MainModule.UserID;
            p.ModificatorUserID = MainModule.UserID;
            p.CreatorFullName = MainModule.UserFullName;
            p.ModificatorFullName = MainModule.UserFullName;

            lstPayment.Add(p);
            paymentBindingSource.DataSource = lstPayment;
            txtPayedPrice.Text = ((int)lstPayment.Sum(c => c.Price)).ToString();
            txtRemainPrice.Text = ((int)(TotalPrice - lstPayment.Sum(c => c.Price))).ToString();

            gridControl3.RefreshDataSource();
        }

        private void BtnOkInstalPay_Click(object sender, EventArgs e)
        {
            var TotalPrice = GivenMInstallment.Sum(c => c.PaymentPrice);
            var payedPrice = lstPayment.Sum(c => c.Price);

            if (payedPrice == TotalPrice)
            {
                foreach (var p in lstPayment)
                {
                    p.InstallMent = "تمام";
                    if (!dc.Payments.Any(c => c.ID == p.ID))
                        dc.Payments.InsertOnSubmit(p);
                }
            }
            else
                foreach (var p in lstPayment)
                {
                    if (!dc.Payments.Any(c => c.ID == p.ID))
                        dc.Payments.InsertOnSubmit(p);

                }
            dc.SubmitChanges();
            MessageBox.Show(".پرداخت با موفقیت انجام شد");
            this.DialogResult = DialogResult.OK;
        }

        private void gridView6_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var P = gridView6.GetRow(e.RowHandle) as Payment;
                lstPayment.Remove(P);
                gridView6.DeleteRow(e.RowHandle);
                gridControl3.RefreshDataSource();
            }
        }

        private void grdBill_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}

