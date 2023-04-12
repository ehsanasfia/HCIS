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
    public partial class frmInCome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmInCome()
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
            var PD = MainModule.GetPersianDate(DateTime.Now);
            dossierBindingSource.DataSource =
                 dc.Dossiers.Where(x => x.IOtype == 1 && x.Date == PD && x.Insurance.CompanyType == "غیرشرکتی").ToList();
            //y.GivenServiceMs.
        }
        void getdata()
        {
            var PD = MainModule.GetPersianDate(DateTime.Now);
            dossierBindingSource.DataSource = dc.Dossiers.Where(x => x.IOtype == 1 && x.Date == PD && x.Insurance.CompanyType == "غیرشرکتی").ToList();
        }

        private void btnTodaySearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            getdata();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var PD = txtDate.Text;
            dossierBindingSource.DataSource = dc.Dossiers.Where(x =>x.IOtype==1 && x.Date == PD && x.Insurance.CompanyType =="غیرشرکتی").ToList();
            //y.GivenServiceMs.
            //   Any(d => d.ServiceCategoryID == (Int32)Category.بخش &&
            //   (d.CreationDate == PD.ToString() || d.Date == PD.ToString())));
        }

        private void txtDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDate.Text.Length != 10) return;
            var PD = txtDate.Text;
            dossierBindingSource.DataSource = dc.Dossiers.Where(x => x.IOtype == 1 && x.Date == PD &&  x.Insurance.CompanyType == "غیرشرکتی").ToList();
         //.Where(y => y.GivenServiceMs.
         //      Any(d =>  d.ServiceCategoryID == (Int32)Category.بخش &&
         //      (d.CreationDate == PD.ToString() || d.Date == PD.ToString())));
        }

        private void btnAdvancePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = dossierBindingSource.Current as Dossier;
            if (current == null)
            {
                MessageBox.Show("لطفا یک پرونده انتخاب نمایید");
                return;
            }
            if (current.SpicialCode==null)
            { MessageBox.Show("لطفا کد ویژه را ثبت نمایید");
                return;
            }
            var dlg = new Dialogs.dlgAdvancePayment();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                current.AdvancePayment = dlg.AdvancePayment;
                if (current.AdvancePayment > 0)
                    current.AdvancePaymentPayed = false;
                else
                {
                    if (MessageBox.Show(this, " شما مبلغ صفر را وارد کرده اید /n آیا اطمینان داری که نیازی به گرفتن هزینه نیست ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        current.AdvancePaymentPayed = true;
                    }
                    else
                        return;
                }
                dc.SubmitChanges();
                 StiAdvance.Dictionary.Variables.Add("Price", dlg.AdvancePayment);
                StiAdvance.Dictionary.Variables.Add("StrPrice", PNumberTString.GetStr(dlg.AdvancePayment.ToString()) );
                StiAdvance.Dictionary.Variables.Add("DossierID", current.ID );
                StiAdvance.Dictionary.Variables.Add("SpicialCode", current.SpicialCode??"");

                StiAdvance.Dictionary.Variables.Add("FirstName", current.Person.FirstName != null ? current.Person.FirstName : "");
                StiAdvance.Dictionary.Variables.Add("lastName", current.Person.LastName != null ? current.Person.LastName : "");
                StiAdvance.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                // StiTarkhis.Design();
                StiAdvance.Compile();
                StiAdvance.Render();
                StiAdvance.CompiledReport.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiSpecialCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dossier = dossierBindingSource.Current as Dossier;

            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgSpecialCode();
            dlg.dossier = dossier;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.SpicialCode = dlg.Code;
                dc.SubmitChanges();
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            getdata();
        }

        private void bbiEditSpecialCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dossier = dossierBindingSource.Current as Dossier;

            if (dossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgSpecialCode();
            dlg.dossier = dossier;
            dlg.dc = dc;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.SpicialCode = dlg.Code;
                dc.SubmitChanges();
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
            getdata();
        }

        private void bbiPrintAdvancePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = dossierBindingSource.Current as Dossier;
            if (current == null)
            {
                MessageBox.Show("لطفا یک پرونده انتخاب نمایید");
                return;
            }
           
                StiAdvance.Dictionary.Variables.Add("Price", current.AdvancePayment);
                StiAdvance.Dictionary.Variables.Add("StrPrice", PNumberTString.GetStr(current.AdvancePayment.ToString()));
                StiAdvance.Dictionary.Variables.Add("DossierID", current.ID);
                StiAdvance.Dictionary.Variables.Add("SpicialCode", current.SpicialCode ?? "");

                StiAdvance.Dictionary.Variables.Add("FirstName", current.Person.FirstName != null ? current.Person.FirstName : "");
                StiAdvance.Dictionary.Variables.Add("lastName", current.Person.LastName != null ? current.Person.LastName : "");
                StiAdvance.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                // StiTarkhis.Design();
                StiAdvance.Compile();
                StiAdvance.Render();
                StiAdvance.CompiledReport.Show();
            }

        private void bbiEditPerson_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
    }
