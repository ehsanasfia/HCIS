using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmMenopause : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstPrs;
        List<QA> lstEsteo;
        List<QA> lstMammo;
        List<QA> lstSwix;
        List<QA> lstImportant;
        List<QA> lstReferences;
        List<QA> lstEducation;

        public frmMenopause()
        {
            InitializeComponent();
        }

        private void frmMenopause_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstPrs == null)
                lstPrs = new List<QA>();

            if (lstEsteo == null)
                lstEsteo = new List<QA>();

            if (lstMammo == null)
                lstMammo = new List<QA>();

            if (lstSwix == null)
                lstSwix = new List<QA>();

            if (lstImportant == null)
                lstImportant = new List<QA>();

            if (lstReferences == null)
                lstReferences = new List<QA>();

            if (lstEducation == null)
                lstEducation = new List<QA>();

            var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("50f8424f-8230-4dbe-b9ba-552c8b781fc8")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QA()
                {
                    PService = item,
                };
                lstPrs.Add(qa0);
            }
            PersonalQABindingSource.DataSource = lstPrs.OrderBy(c => c.PService.OldID);

            var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("2df756ae-0d77-428e-8973-60a8ea7c7fec")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QA()
                {
                    PService = item,
                };
                lstEsteo.Add(qa1);
            }
            EsteoQABindingSource.DataSource = lstEsteo.OrderBy(c => c.PService.OldID);

            var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("bfa6398f-5d54-4ff5-a51d-d72fd727d993")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QA()
                {
                    PService = item,
                };
                lstMammo.Add(qa2);
            }
            MammoQABindingSource.DataSource = lstMammo.OrderBy(c => c.PService.OldID);

            var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("f048fbdd-6e9b-46e7-b9fa-9638f4a88c7f")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QA()
                {
                    PService = item,
                };
                lstSwix.Add(qa3);
            }
            SwixQABindingSource.DataSource = lstSwix.OrderBy(c => c.PService.OldID);

            var srvList4 = dc.Services.Where(x => x.ParentID == Guid.Parse("25841c3f-01bc-42b4-96ec-732bd9f822e7")).ToList();
            foreach (var item in srvList4)
            {
                var qa4 = new QA()
                {
                    PService = item,
                };
                lstImportant.Add(qa4);
            }
            ImportantQABindingSource.DataSource = lstImportant.OrderBy(c => c.PService.OldID);
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup2.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
                if (gsm == null)
                    return;

                if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                {
                    foreach (var item in lstPrs)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstEsteo)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstMammo)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstSwix)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstImportant)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    PersonalQABindingSource.DataSource = null;
                    EsteoQABindingSource.DataSource = null;
                    MammoQABindingSource.DataSource = null;
                    SwixQABindingSource.DataSource = null;
                    ImportantQABindingSource.DataSource = null;
                }
                if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                {
                    foreach (var item in lstReferences)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    ReferenceQABindingSource.DataSource = null;
                }
                if (tabbedControlGroup1.SelectedTabPageIndex == 2)
                {
                    foreach (var item in lstEducation)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Service = item.PService;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAs.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    EducationQABindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("03c52050-cd30-4600-b592-87d88e9206ed")).ToList();
                foreach (var item in srvList1)
                {
                    var qa1 = new QA()
                    {
                        PService = item,
                    };
                    lstReferences.Add(qa1);
                }
                ReferenceQABindingSource.DataSource = lstReferences.OrderBy(c => c.PService.OldID);
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("64b5a258-4cc8-44d7-bf83-5f9b283f978a")).ToList();
                foreach (var item in srvList2)
                {
                    var qa2 = new QA()
                    {
                        PService = item,
                    };
                    lstEducation.Add(qa2);
                }
                EducationQABindingSource.DataSource = lstEducation.OrderBy(c => c.PService.OldID);
            }
        }
    }
}