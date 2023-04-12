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
    public partial class frmAssessment : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstComponent;
        List<QA> lstComponentHistory;
        List<QA> lstDanger;
        List<QA> lstDangerHistory;
        List<QA> lstAsk;
        List<QA> lstAskHistory;
        List<QA> lstMeasurement;
        List<QA> lstMeasurementHistory;
        List<QA> lstCheckup;
        List<QA> lstCheckupHistory;
        List<QA> lstEducation;
        List<QA> lstEducationHistory;
        List<QA> lstDrug;
        List<QA> lstDrugHistory;

        public frmAssessment()
        {
            InitializeComponent();
        }

        private void frmAssessment_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstComponent == null)
                lstComponent = new List<QA>();

            if (lstComponentHistory == null)
                lstComponentHistory = new List<QA>();

            if (lstDanger == null)
                lstDanger = new List<QA>();

            if (lstDangerHistory == null)
                lstDangerHistory = new List<QA>();

            if (lstAsk == null)
                lstAsk = new List<QA>();

            if (lstAskHistory == null)
                lstAskHistory = new List<QA>();

            if (lstMeasurement == null)
                lstMeasurement = new List<QA>();

            if (lstMeasurementHistory == null)
                lstMeasurementHistory = new List<QA>();

            if (lstCheckup == null)
                lstCheckup = new List<QA>();

            if (lstCheckupHistory == null)
                lstCheckupHistory = new List<QA>();

            if (lstEducation == null)
                lstEducation = new List<QA>();

            if (lstEducationHistory == null)
                lstEducationHistory = new List<QA>();

            if (lstDrug == null)
                lstDrug = new List<QA>();

            if (lstDrugHistory == null)
                lstDrugHistory = new List<QA>();

            var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("55c180cf-01c5-4ae2-80ac-25fac727fd57")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QA()
                {
                    PService = item,
                };
                lstComponent.Add(qa0);
            }
            ComponentQABindingSource.DataSource = lstComponent.OrderBy(c => c.PService.OldID);

            var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("4d4c87d6-e15f-4d1d-921a-45a580fd8539")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QA()
                {
                    PService = item,
                };
                lstDanger.Add(qa1);
            }
            DangerQABindingSource.DataSource = lstDanger.OrderBy(c => c.PService.OldID);

            var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("0793375e-baf4-4468-8824-8516a6d084a1")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QA()
                {
                    PService = item,
                };
                lstAsk.Add(qa2);
            }
            AskQABindingSource.DataSource = lstAsk.OrderBy(c => c.PService.OldID);

            var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("af5ed140-9cae-4019-838c-c6ddadac8c13")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QA()
                {
                    PService = item,
                };
                lstMeasurement.Add(qa3);
            }
            MeasurementQABindingSource.DataSource = lstMeasurement.OrderBy(c => c.PService.OldID);

            var srvList4 = dc.Services.Where(x => x.ParentID == Guid.Parse("4b86cfa2-9639-4436-b0ac-205c26c1d1f8")).ToList();
            foreach (var item in srvList4)
            {
                var qa4 = new QA()
                {
                    PService = item,
                };
                lstCheckup.Add(qa4);
            }
            CheckupQABindingSource.DataSource = lstCheckup.OrderBy(c => c.PService.OldID);

            var srvList5 = dc.Services.Where(x => x.ParentID == Guid.Parse("b88809bc-6bf3-459d-b3d3-d79964b8c29b")).ToList();
            foreach (var item in srvList5)
            {
                var qa5 = new QA()
                {
                    PService = item,
                };
                lstEducation.Add(qa5);
            }
            EducationQABindingSource.DataSource = lstEducation.OrderBy(c => c.PService.OldID);

            var srvList6 = dc.Services.Where(x => x.ParentID == Guid.Parse("552d28c1-cb27-4076-bdfe-9411d5538257")).ToList();
            foreach (var item in srvList6)
            {
                var qa6 = new QA()
                {
                    PService = item,
                };
                lstDrug.Add(qa6);
            }
            DrugQABindingSource.DataSource = lstDrug.OrderBy(c => c.PService.OldID);
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

                foreach (var item in lstComponent)
                {
                    if (!string.IsNullOrWhiteSpace(item.MResult) || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstDanger)
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
                foreach (var item in lstAsk)
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
                foreach (var item in lstMeasurement)
                {
                    if (!string.IsNullOrWhiteSpace(item.MResult) || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstCheckup)
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
                foreach (var item in lstDrug)
                {
                    if (!string.IsNullOrWhiteSpace(item.MResult) || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                ComponentQABindingSource.DataSource = null;
                DangerQABindingSource.DataSource = null;
                AskQABindingSource.DataSource = null;
                MeasurementQABindingSource.DataSource = null;
                CheckupQABindingSource.DataSource = null;
                EducationQABindingSource.DataSource = null;
                DrugQABindingSource.DataSource = null;

                lstComponentHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("55c180cf-01c5-4ae2-80ac-25fac727fd57")).ToList();
                ComponentHistoryQABindingSource.DataSource = lstComponentHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstDangerHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("4d4c87d6-e15f-4d1d-921a-45a580fd8539")).ToList();
                DangerHistoryQABindingSource.DataSource = lstDangerHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstAskHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("0793375e-baf4-4468-8824-8516a6d084a1")).ToList();
                AskHistoryQABindingSource.DataSource = lstAskHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstMeasurementHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("af5ed140-9cae-4019-838c-c6ddadac8c13")).ToList();
                MeasurementHistoryQABindingSource.DataSource = lstMeasurementHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstCheckupHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("4b86cfa2-9639-4436-b0ac-205c26c1d1f8")).ToList();
                CheckupHistoryQABindingSource.DataSource = lstCheckupHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstEducationHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b88809bc-6bf3-459d-b3d3-d79964b8c29b")).ToList();
                EducationHistoryQABindingSource.DataSource = lstEducationHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstDrugHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("552d28c1-cb27-4076-bdfe-9411d5538257")).ToList();
                DrugHistoryQABindingSource.DataSource = lstDrugHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl2.RefreshDataSource();
                gridControl4.RefreshDataSource();
                gridControl6.RefreshDataSource();
                gridControl8.RefreshDataSource();
                gridControl10.RefreshDataSource();
                gridControl12.RefreshDataSource();
                gridControl14.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup2.Visible = true;

            barStaticItem1.Caption = "نام: " + person.FirstName;
            barStaticItem2.Caption = "نام خانوادگی: " + person.LastName;
            barStaticItem3.Caption = "نام پدر: " + person.FatherName;
            barStaticItem4.Caption = "کد ملی: " + person.NationalCode;
            barStaticItem5.Caption = "تاریخ تولد: " + person.BirthDate;
            barStaticItem6.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void layoutControlGroup9_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup9.Expanded = !layoutControlGroup9.Expanded;

            if (!lstComponentHistory.Any())
            {
                lstComponentHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("55c180cf-01c5-4ae2-80ac-25fac727fd57")).ToList();
            }
            ComponentHistoryQABindingSource.DataSource = lstComponentHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl2.RefreshDataSource();
        }

        private void layoutControlGroup10_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup10.Expanded = !layoutControlGroup10.Expanded;

            if (!lstDangerHistory.Any())
            {
                lstDangerHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("4d4c87d6-e15f-4d1d-921a-45a580fd8539")).ToList();
            }
            DangerHistoryQABindingSource.DataSource = lstDangerHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl4.RefreshDataSource();
        }

        private void layoutControlGroup11_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup11.Expanded = !layoutControlGroup11.Expanded;

            if (!lstAskHistory.Any())
            {
                lstAskHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("0793375e-baf4-4468-8824-8516a6d084a1")).ToList();
            }
            AskHistoryQABindingSource.DataSource = lstAskHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl6.RefreshDataSource();
        }

        private void layoutControlGroup12_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup12.Expanded = !layoutControlGroup12.Expanded;

            if (!lstMeasurementHistory.Any())
            {
                lstMeasurementHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("af5ed140-9cae-4019-838c-c6ddadac8c13")).ToList();
            }
            MeasurementHistoryQABindingSource.DataSource = lstMeasurementHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl8.RefreshDataSource();
        }

        private void layoutControlGroup13_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup13.Expanded = !layoutControlGroup13.Expanded;

            if (!lstCheckupHistory.Any())
            {
                lstCheckupHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("4b86cfa2-9639-4436-b0ac-205c26c1d1f8")).ToList();
            }
            CheckupHistoryQABindingSource.DataSource = lstCheckupHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl10.RefreshDataSource();
        }

        private void layoutControlGroup14_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup14.Expanded = !layoutControlGroup14.Expanded;

            if (!lstEducationHistory.Any())
            {
                lstEducationHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("b88809bc-6bf3-459d-b3d3-d79964b8c29b")).ToList();
            }
            EducationHistoryQABindingSource.DataSource = lstEducationHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl12.RefreshDataSource();
        }

        private void layoutControlGroup15_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup15.Expanded = !layoutControlGroup15.Expanded;

            if (!lstDrugHistory.Any())
            {
                lstDrugHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("552d28c1-cb27-4076-bdfe-9411d5538257")).ToList();
            }
            DrugHistoryQABindingSource.DataSource = lstDrugHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl14.RefreshDataSource();
        }
    }
}