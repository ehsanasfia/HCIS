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
using HCISCash.Classes;

namespace HCISCash.Dialogs
{
    public partial class dlgSearchBastari1 : DevExpress.XtraEditors.XtraForm
    {
        public dlgSearchBastari1()
        {
            InitializeComponent();
        }
        Data.HCISCashDataContextDataContext dc = new Data.HCISCashDataContextDataContext();
        public long dossierID;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch { }
        }

        private void GetData()
        {
            if (comboBoxEdit1.EditValue == null)
            {
                MessageBox.Show("ناریخ را وارد کنید");
                return;
            }

            if (txtToDate.Text.Trim() == "")
            {
                MessageBox.Show("ناریخ را وارد کنید");
                return;
            }
            //if (lookUpEdit1.EditValue == null)
            //{ MessageBox.Show("متعهد را انتخاب کنید"); return; }

            if (comboBoxEdit1.EditValue.ToString() == "تاریخ پذیرش")
            {
                vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => ((y.AdmitDate.CompareTo(txtFromDate.Text) >= 0 && y.AdmitDate.CompareTo(txtToDate.Text) <= 0) || (y.Date.CompareTo(txtFromDate.Text) >= 0 && y.Date.CompareTo(txtToDate.Text) <= 0)) && y.CompanyType == MainModule.CompanyTypeSelected && (MainModule.CompanyTypeSelected == "غیرشرکتی" ? !(y.depName == "اورژانس" || y.depName == "اتاق عمل اورژانس") : true)).OrderBy(x=>x.SpicialCode);
            }
            else if (comboBoxEdit1.EditValue.ToString() == "تاریخ ترخیص")
            {
                vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => y.DischargeDate != null
                && ((y.DischargeDate.CompareTo(txtFromDate.Text) >= 0 && y.DischargeDate.CompareTo(txtToDate.Text) <= 0) ) && y.CompanyType == MainModule.CompanyTypeSelected &&  (MainModule.CompanyTypeSelected == "غیرشرکتی" ? !(y.depName == "اورژانس" || y.depName == "اتاق عمل اورژانس") : true));
            }
          
  else if (comboBoxEdit1.EditValue.ToString() == "بیماران فعلی بخش ها")
            {
               vwDossierBastariBindingSource.DataSource = dc.Vw_DossierBastaris.Where(y => ((y.AdmitDate!=null)) && (y.AdmitDate.CompareTo("1397/07/19") >= 0) && y.DischargeDate==null && y.CompanyType == MainModule.CompanyTypeSelected && (MainModule.CompanyTypeSelected == "غیرشرکتی" ? !(y.depName == "اورژانس" || y.depName == "اتاق عمل اورژانس") : true)).OrderBy(x => x.SpicialCode);
            }


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;
            dossierID = cur.ID;
            DialogResult = DialogResult.OK;
        }

        private void dlgSearchBastari_Load(object sender, EventArgs e)
        {
            if (MainModule.CompanyTypeSelected == "غیرشرکتی")
            {
                lcgBimareKhosoosi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                colSpicialCode.Visible = true;
                ColMedicalID.Visible = false;
            }
            txtToDate.Text = txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            comboBoxEdit1.SelectedIndex = 0;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Count")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<Data.Vw_DossierBastari> lst = new List<Data.Vw_DossierBastari>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var datarow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Data.Vw_DossierBastari;

                lst.Add(datarow);
            }

            var MyData = from x in lst
                         select new
                         {
                             x.FirstName,
                             x.LastName,
                             PersonalCode = x.MedicalID,
                             x.ID,
                             WardName = x.depName,
                             InsuranceName = x.InsurName,
                             x.NationalCode,
                             SpicialCode=x.SpicialCode??""
                         };
            Report.RegData("MyData", MyData);

            Report.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            Report.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            if (comboBoxEdit1.EditValue.ToString()=="تاریخ پذیرش")
            Report.Dictionary.Variables.Add("Type", "پذیرش");
            else
                Report.Dictionary.Variables.Add("Type", "ترخیص");

            //  Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
            Report.Dictionary.Synchronize();
            // stiViewerControl1.Report = Report;
            Report.Compile();
            Report.Render();
          //  Report.Design();
            Report.ShowWithRibbonGUI();
        }

        private void bbiSpecialCode_Click(object sender, EventArgs e)
        {
            var Vwdossier = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;

            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            GetData();
            if (Vwdossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgSpecialCode();
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Vwdossier.ID);
            dlg.dossier = dossier;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK /*&& dc.Insurances.FirstOrDefault(c=>c.Name==dossier.Person.InsuranceName).CompanyType=="غیرشرکتی"*/)
            {
                dossier.SpicialCode = dlg.Code;
                dc.SubmitChanges();
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            GetData();
        }

        private void btnAdvancePayment_Click(object sender, EventArgs e)
        {
            var Vwdossier = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;

            if (Vwdossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }

            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Vwdossier.ID);
            if (dossier.SpicialCode == null)
            {
                MessageBox.Show("لطفا کد ویژه را ثبت نمایید");
                return;
            }
            var dlg = new Dialogs.dlgAdvancePayment();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.AdvancePayment = dlg.AdvancePayment;
                if (dossier.AdvancePayment > 0)
                    dossier.AdvancePaymentPayed = false;
                else
                {
                    if (MessageBox.Show(this, " شما مبلغ صفر را وارد کرده اید /n آیا اطمینان داری که نیازی به گرفتن هزینه نیست ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        dossier.AdvancePaymentPayed = true;
                    }
                    else
                        return;
                }
                dc.SubmitChanges();
                StiAdvance.Dictionary.Variables.Add("Price", dlg.AdvancePayment);
                StiAdvance.Dictionary.Variables.Add("StrPrice", PNumberTString.GetStr(dlg.AdvancePayment.ToString()));
                StiAdvance.Dictionary.Variables.Add("DossierID", dossier.ID);
                StiAdvance.Dictionary.Variables.Add("SpicialCode", dossier.SpicialCode ?? "");
                StiAdvance.Dictionary.Variables.Add("WardName", dossier.Department.Name ?? "");

                StiAdvance.Dictionary.Variables.Add("FirstName", dossier.Person.FirstName != null ? dossier.Person.FirstName : "");
                StiAdvance.Dictionary.Variables.Add("lastName", dossier.Person.LastName != null ? dossier.Person.LastName : "");
                StiAdvance.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                // StiTarkhis.Design();
                StiAdvance.Compile();
                StiAdvance.Render();
                StiAdvance.CompiledReport.Show();
            }
        }

        private void btnEditSpecialCode_Click(object sender, EventArgs e)
        {
            var Vwdossier = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;

            if (Vwdossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dlg = new Dialogs.dlgSpecialCode();
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Vwdossier.ID);
            dlg.dossier = dossier;
            dlg.dc = dc;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dossier.SpicialCode = dlg.Code;
                dc.SubmitChanges();
            }
            dc.Dispose();
            dc = new HCISCashDataContextDataContext();
            GetData();
        }

        private void btnPrintAdvancePayment_Click(object sender, EventArgs e)
        {
            var Vwdossier = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;

            if (Vwdossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var current = dc.Dossiers.FirstOrDefault(c => c.ID == Vwdossier.ID);


            StiAdvance.Dictionary.Variables.Add("Price", current.AdvancePayment);
            StiAdvance.Dictionary.Variables.Add("StrPrice", PNumberTString.GetStr(current.AdvancePayment.ToString()));
            StiAdvance.Dictionary.Variables.Add("DossierID", current.ID);
            StiAdvance.Dictionary.Variables.Add("SpicialCode", current.SpicialCode ?? "");

            StiAdvance.Dictionary.Variables.Add("WardName", current.Department.Name ?? "");
            StiAdvance.Dictionary.Variables.Add("FirstName", current.Person.FirstName != null ? current.Person.FirstName : "");
            StiAdvance.Dictionary.Variables.Add("lastName", current.Person.LastName != null ? current.Person.LastName : "");
            StiAdvance.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
            // StiTarkhis.Design();
            StiAdvance.Compile();
            StiAdvance.Render();
            StiAdvance.CompiledReport.Show();

        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            var cur = vwDossierBastariBindingSource.Current as Vw_DossierBastari;
            if (cur == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == cur.ID);
            var dlg = new dlgEditPerson();
            dlg.dc = dc;
            dlg.ObjectDoss = dossier;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
            else
            {
                dc.Dispose();
                dc = new HCISCashDataContextDataContext();
                GetData();
            }
        }

        private void btnAdvancePaymentandPay_Click(object sender, EventArgs e)
        {

            var current = vwDossierBastariBindingSource.Current as Vw_DossierBastari;
            if (current == null)
            {
                MessageBox.Show("رکوردی انتخاب نشده!"); /*this.DialogResult = DialogResult.OK;*/ return;
            }
            if (current.AdvancePaymentPayed == true)
            {
                MessageBox.Show("مبلغ علی الحساب قبلا پرداخت شده!"); /*this.DialogResult = DialogResult.OK;*/ return;
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
                var dlg = new Dialogs.dlgCreditOrCashPay() { dc = dc,Descip="علی الحساب", havepay = dossier.AdvancePayment, dossier = dossier };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    current.AdvancePaymentPayed = true;
                    dc.SubmitChanges();
                    StiPayment.Dictionary.Variables.Add("serial", current.ID);
                    StiPayment.Dictionary.Variables.Add("date", MainModule.GetPersianDate(DateTime.Now));
                    StiPayment.Dictionary.Variables.Add("price adad", dossier.AdvancePayment);
                    StiPayment.Dictionary.Variables.Add("WardName", dossier.Department.Name);
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
                    dc.SubmitChanges();
                }
                else
                {
                    dc.Dispose();
                    dc = new HCISCashDataContextDataContext();
                    GetData();
                }

            }

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            var Vwdossier = vwDossierBastariBindingSource.Current as Data.Vw_DossierBastari;

            if (Vwdossier == null)
            {
                MessageBox.Show("لطفا ابتدا یک پرونده را انتخاب نمایید");
                return;
            }
            var dossier = dc.Dossiers.FirstOrDefault(c => c.ID == Vwdossier.ID);
            var dlg = new Dialogs.dlgDossierPay();
            dlg.dc = dc;
            dlg.Dossier = dossier;
            dlg.ShowDialog();
        }

        private void btnRptPetientWard_Click(object sender, EventArgs e)
        {
            List<Data.Vw_DossierBastari> lst = new List<Data.Vw_DossierBastari>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var datarow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i)) as Data.Vw_DossierBastari;

                lst.Add(datarow);
            }
            var MyData = from x in lst
                         select new
                         {
                             x.FirstName,
                             x.LastName,
                             PersonalCode = x.MedicalID,
                             x.ID,
                             WardName = x.depName,
                             InsuranceName = x.InsurName,
                             x.NationalCode,
                             x.AdmitDate
                         };
            StiBakhsheFeli.RegData("MyData", MyData);
            StiBakhsheFeli.Dictionary.Variables.Add("FromDate", txtFromDate.Text);
            StiBakhsheFeli.Dictionary.Variables.Add("ToDate", txtToDate.Text);
            //  Report.Dictionary.Variables.Add("Insurance", ins != null ? (ins.Name ?? "") : "");
            StiBakhsheFeli.Dictionary.Synchronize();
            // stiViewerControl1.Report = Report;
       //     StiBakhsheFeli.Design();
            StiBakhsheFeli.Compile();
            StiBakhsheFeli.Render();
            // Report.Design();
            StiBakhsheFeli.ShowWithRibbonGUI();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}