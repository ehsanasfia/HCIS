using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class frmSpecialAdmit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDataContext dc = new HCISDataContext();

        Guid? SelectedDepID = null;
        public frmSpecialAdmit()
        {
            InitializeComponent();
        }

        private void frmSpecialAdmit_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTime.Text = DateTime.Now.ToString("HH:mm");
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
        }

        private void GetData()
        {
            bedsBindingSource.DataSource = dc.Beds.Where(x => x.Condition == "خالی" && x.DepartmentID == Classes.MainModule.MyDepartment.ID).ToList();

            if (SelectedDepID == null)
                personsBindingSource.DataSource = null;
            else
            {
                lkpPerson.EditValue = null;
                var lst = dc.Persons.Where(x =>
                        x.GivenServiceMs.Any(y =>
                                y.DepartmentID != null && y.DepartmentID == SelectedDepID))
                        .OrderBy(x => x.LastName).ToList();

                personsBindingSource.DataSource = lst;
                personsBindingSource1.DataSource = lst;


                gridControl1.RefreshDataSource();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((radioGroup1.EditValue as int?) == 0) // foghe takhasosi
            {
                SelectedDepID = new Guid("77edc350-955a-4a91-b50e-f2b4867f8cd4");
            }
            else if ((radioGroup1.EditValue as int?) == 1) // dializ
            {
                SelectedDepID = new Guid("21f469f7-d596-4ee2-aa48-14cfa6f59ba0");
            }
            else if ((radioGroup1.EditValue as int?) == 2) // talasemi
            {
                SelectedDepID = new Guid("e5c03478-1f45-4e23-a626-e252e2872202");
            }
            else
            {
                SelectedDepID = null;
            }

            GetData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lkpPerson.EditValue = null;
        }

        private void lkpPerson_EditValueChanged(object sender, EventArgs e)
        {
            var prs = lkpPerson.EditValue as Person;
            List<Person> lst;
            if (prs == null)
            {
                lst = dc.Persons.Where(x =>
                        x.GivenServiceMs.Any(y =>
                                y.DepartmentID != null && y.DepartmentID == SelectedDepID))
                        .OrderBy(x => x.LastName).ToList();
            }
            else
            {
                lst = dc.Persons.Where(x => x.ID == prs.ID).ToList();
            }
            personsBindingSource.DataSource = lst;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (searchLookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("پزشک  معالج را با دقت انتخاب نمایید"); return;
                }
                var prs = personsBindingSource.Current as Person;
                if (prs == null)
                {
                    MessageBox.Show("ابتدا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (bedsBindingSource.Count == 0)
                {
                    MessageBox.Show("لطفا ابتدا برای بخش تخت تعریف کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var crnt = bedsBindingSource.Current as Bed;
                if (crnt == null)
                {
                    MessageBox.Show("لطفا یک تخت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (dc.GivenServiceMs.Any(x => x.ServiceCategoryID == 10 && x.DepartmentID == SelectedDepID && x.Dossier.Discharge != true && x.Confirm == true && x.PersonID == prs.ID))
                {
                    MessageBox.Show("پرونده بیمار هنوز در بخش باز است لطفا ابتدا بیمار را ترخیص کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (MessageBox.Show("آیا میخواهید بیمار را پذیرش کنید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) != DialogResult.Yes)
                    return;

                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");

                var gsm = prs.GivenServiceMs.FirstOrDefault(x =>
                        x.ServiceCategoryID == 10 && x.DepartmentID == SelectedDepID && x.Admitted == false && x.Confirm != true && x.Dossier.AdvancePaymentPayed == true);

                if (gsm == null)
                {
                    var lastGsm = prs.GivenServiceMs.FirstOrDefault(x => x.DepartmentID == SelectedDepID);

                    var EditingGivenM = new GivenServiceM() { BookletPageNumber = "1" };

                    EditingGivenM.Date = txtDate.Text;
                    EditingGivenM.Time = txtTime.Text;
                    EditingGivenM.RequestStaffID = (searchLookUpEdit1.EditValue as Staff).ID;
                    EditingGivenM.RequestDate = txtDate.Text;
                    EditingGivenM.RequestTime = txtTime.Text;
                    EditingGivenM.DepartmentID = SelectedDepID;
                    EditingGivenM.PersonID = prs.ID;
                    EditingGivenM.ServiceCategoryID = 10;
                    var advancepayment = dc.DepAdvancePayments.Where(c => c.InsuranceID == EditingGivenM.InsuranceID && c.DepartmentID == SelectedDepID).OrderByDescending(c => c.Date).FirstOrDefault();
                    var dossier = new Dossier()
                    {
                        Date = txtDate.Text,
                        Time = txtTime.Text,
                        NationalCode = prs.NationalCode,
                        StaffCure = (searchLookUpEdit1.EditValue as Staff).ID,
                        PersonID = prs.ID,
                        DepartmentID = SelectedDepID,
                        IOtype = 1,
                        AdvancePayment = advancepayment == null ? 0 : (decimal)advancepayment.AdvancePayment,
                        CreationDate = txtDate.Text,
                        CreationTime = txtTime.Text,
                        CreatorUser = MainModule.UserID
                    };
                    dc.Dossiers.InsertOnSubmit(dossier);
                    dc.SubmitChanges();
                    //  EditingGivenM.RequestStaffID = lastGsm.RequestStaffID;
                    //EditingGivenM.BedID = (bedBindingSource.Current as Bed).ID;
                    //var bd = dc.Beds.FirstOrDefault(x => x.ID == EditingGivenM.BedID);
                    //bd.Condition = "پر";
                    EditingGivenM.DepartmentID = SelectedDepID;
                    EditingGivenM.BookletExpireDate = lastGsm.BookletExpireDate;
                    EditingGivenM.InsuranceNo = lastGsm.InsuranceNo;
                    EditingGivenM.BookletPageNumber = lastGsm.BookletPageNumber;
                    EditingGivenM.ComplementInsurance = lastGsm.ComplementInsurance;
                    EditingGivenM.InsuranceID = lastGsm.InsuranceID;
                    EditingGivenM.LastModificationDate = txtDate.Text;
                    EditingGivenM.LastModificationTime = txtTime.Text;
                    EditingGivenM.DossierID = dossier.ID;
                    EditingGivenM.CreatorUserID = MainModule.UserID;
                    EditingGivenM.CreationDate = txtDate.Text;
                    EditingGivenM.CreationTime = txtTime.Text;
                    //if (!((slkInsurance.EditValue as Insurance).Name).Contains("آزاد"))
                    //    if (dc.Persons.Any(x => x.InsuranceNo == txtInsuranceNo.Text.Trim() && x.NationalCode != EditingPerson.NationalCode && x.InsuranceNo != "" && x.InsuranceNo != null))
                    //    {
                    //        MessageBox.Show(".شماره بیمه ی وارد شده تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //        return;
                    //    }
                    if (EditingGivenM.ID == Guid.Empty)
                        dc.GivenServiceMs.InsertOnSubmit(EditingGivenM);

                    var ServiceID = Guid.Parse("aea2e856-0117-4de6-b92f-10252997c6f1");
                    var dentalService = Guid.Parse("a1f7359c-4024-4873-b588-51ddb79c14e7");
                    var EditinGivenD = new GivenServiceD()
                    {
                        GivenServiceM = EditingGivenM,
                        ServiceID = ServiceID,
                        Time = txtTime.Text,
                        Amount = 1,
                        Date = txtDate.Text
                        //TariffID = dc.Tariffs.FirstOrDefault(c => c.InsuranceID == EditingGivenM.InsuranceID && c.Service.ID == ServiceID).ID
                    };
                    if (lastGsm.InsuranceID != null)
                    {
                        var Tariff = dc.Tariffs.Where(c => c.InsuranceID == lastGsm.InsuranceID && c.ServiceID == Guid.Parse("f9e4f381-fc5e-41da-b58d-fa80d9f71ef1")).OrderByDescending(x => x.Date).FirstOrDefault();
                        if (Tariff != null)
                        {
                            var InsuranceShare = Tariff.OrganizationShare ?? 0;
                            var PatientShare = Tariff.PatientShare ?? 0;

                            if (dossier.AdvancePayment == 0)
                            {
                                dossier.AdvancePaymentPayed = true;
                                EditinGivenD.InsuranceShare = InsuranceShare;
                                EditinGivenD.PatientShare = PatientShare;
                                EditinGivenD.TotalPrice = InsuranceShare + PatientShare;
                                EditinGivenD.PayedPrice = 0;
                                EditinGivenD.PaymentPrice = 0;
                                EditinGivenD.Payed = true;
                                EditingGivenM.Payed = true;
                                EditingGivenM.PayedPrice = 0;
                                EditingGivenM.PaymentPrice = 0;
                            }

                        }
                    }

                    EditingGivenM.Bed = crnt;
                    EditingGivenM.Admitted = true;
                    EditingGivenM.AdmitDate = txtDate.Text;
                    EditingGivenM.AdmitTime = DateTime.Now.ToString("HH:mm");
                    EditingGivenM.Bed.Condition = "پر";
                    dc.GivenServiceDs.InsertOnSubmit(EditinGivenD);
                    dc.SubmitChanges();

                    MessageBox.Show("پذیرش شد");

                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}