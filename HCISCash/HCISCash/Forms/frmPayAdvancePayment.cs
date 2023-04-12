using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISCash.Data;
using HCISCash.Classes;

namespace HCISCash.Forms
{
    public partial class frmPayAdvancePayment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPayAdvancePayment()
        {
            InitializeComponent();
        }
        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        private void frmInCome_Load(object sender, EventArgs e)
        {
           txtDate.Text= MainModule.GetPersianDate(DateTime.Now);
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            getdata();
        }
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtDate.Text.Length == 10) return;
            //var PD = txtDate.Text;
            //dossierBindingSource.DataSource =
            //    dc.Dossiers.Where(y => y.IOtype == 1 && /*y.AdvancePayment !=0  &&*/ y.AdvancePaymentPayed == false && y.GivenServiceMs.
            //   Any(d =>  
            //   d.Insurance.CompanyType ==(lkpInsure.EditValue as Insurance).CompanyType
            //   ));
            //if (dossierBindingSource.Count == 0)
            //    MessageBox.Show("یافت نشد"); this.DialogResult = DialogResult.OK;

        }
        void getdata()
        {
            //var PD = MainModule.GetPersianDate(DateTime.Now);
            //dossierBindingSource.DataSource =  dc.Dossiers.Where(y => y.IOtype==1 &&/* y.AdvancePayment != 0 &&*/ y.AdvancePaymentPayed==false && y.Date==PD);
            if (txtDate.Text.Length != 10) return;
            var PD = txtDate.Text;
            //  if (lkpInsure.EditValue.ToString() == "") return;
            vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => ((y.AdmitDate.CompareTo(PD) == 0 )) && y.CompanyType == "غیرشرکتی" &&  y.depName != "اورژانس" );
                ;
            if (vwDossierBastariBindingSource.Count == 0)
                MessageBox.Show("یافت نشد"); this.DialogResult = DialogResult.OK;
        }

        private void btnTodaySearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            getdata();

            if (vwDossierBastariBindingSource.Count == 0)
                MessageBox.Show("یافت نشد"); this.DialogResult = DialogResult.OK;
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            getdata();
            if (vwDossierBastariBindingSource.Count == 0)
                MessageBox.Show("یافت نشد"); this.DialogResult = DialogResult.OK;
        }

        private void txtDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length != 10) return;
            var PD = txtDate.Text;
            getdata();     }

        private void btnAdvancePayment_ItemClick(object sender, ItemClickEventArgs e)
        {

            var current = vwDossierBastariBindingSource.Current as Vw_DossierBastari;
            if (current == null)
            {
                MessageBox.Show("رکوردی انتخاب نشده!"); this.DialogResult = DialogResult.OK; return;
            }

            if (current.AdvancePaymentPayed == true)
            {
                MessageBox.Show("مبلغ علی الحساب قبلا پرداخت شده!"); this.DialogResult = DialogResult.OK; return;
            }
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == current.ID);
            var dlg = new Dialogs.dlgCreditOrCashPay() { dc = dc, havepay = current.AdvancePayment, dossier =dossier };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.AdvancePaymentPayed = true;
                dc.SubmitChanges();
                StiPayment.Dictionary.Variables.Add("serial", current.ID);
                StiPayment.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                StiPayment.Dictionary.Variables.Add("price adad", dossier.AdvancePayment);
                StiPayment.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(dossier.AdvancePayment.ToString()));
                StiPayment.Dictionary.Variables.Add("name kamel", current.FirstName + " " + current.LastName + " ");
                StiPayment.Dictionary.Variables.Add("cast", "علی الحساب");
                //Print.Dictionary.Variables.Add("servie", current);
                string a = "";
                //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";
                StiPayment.Dictionary.Variables.Add("cats", "علی الحساب");
                StiPayment.Compile();
              StiPayment.Render();
                StiPayment.ShowWithRibbonGUI();
            }
            else
            {
                dc.Dispose();
                dc = new HCISCashDataContextDataContext();
                getdata();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = vwDossierBastariBindingSource.Current as Vw_DossierBastari;
            if (current == null)
            {
                MessageBox.Show("رکوردی انتخاب نشده!"); this.DialogResult = DialogResult.OK; return;
            }
            if (current.AdvancePaymentPayed == true)
            {
                    MessageBox.Show("مبلغ علی الحساب قبلا پرداخت شده!"); this.DialogResult = DialogResult.OK; return;
            }
            var dlg1 = new Dialogs.dlgAdvancePayment();
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == current.ID);

            if (dlg1.ShowDialog() == DialogResult.OK)
            {
                dossier.AdvancePayment = dlg1.AdvancePayment;
                if (dossier.AdvancePayment > 0)
                    dossier.AdvancePaymentPayed = false;
                else
                {
                    if (MessageBox.Show(this, " شما مبلغ را صفر وارد کرده اید /n آیا اطمینان دارید که نیازی به گرفتن هزینه نیست؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        dossier.AdvancePaymentPayed = true;
                    }
                    else
                        return;
                }
            var dlg = new Dialogs.dlgCreditOrCashPay() { dc = dc, Descip = "علی الحساب", havepay = dossier.AdvancePayment, dossier = dossier };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    current.AdvancePaymentPayed = true;
                    dc.SubmitChanges();
                    StiPayment.Dictionary.Variables.Add("serial", current.ID);
                    StiPayment.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                    StiPayment.Dictionary.Variables.Add("price adad", dossier.AdvancePayment);
                    StiPayment.Dictionary.Variables.Add("price horof", PNumberTString.GetStr(dossier.AdvancePayment.ToString()));
                    StiPayment.Dictionary.Variables.Add("name kamel", current.FirstName + " " + current.LastName + " ");
                    StiPayment.Dictionary.Variables.Add("cast", "علی الحساب");
                    StiPayment.Dictionary.Variables.Add("WardName", dossier.Department.Name);
                    //Print.Dictionary.Variables.Add("servie", current);
                    string a = "";
                    //    a = current.GivenServiceM!= null ?current.GivenServiceM.ServiceCategory.Name.ToString():"داندان پزشکی";
                    StiPayment.Dictionary.Variables.Add("cats", "علی الحساب");
                    StiPayment.Compile();
                    StiPayment.Render();
                    StiPayment.ShowWithRibbonGUI();
                    dc.SubmitChanges();
                }
                else
                {
                    dc.Dispose();
                    dc = new HCISCashDataContextDataContext();
                    getdata();
                }
       
            }
        }
    }
}