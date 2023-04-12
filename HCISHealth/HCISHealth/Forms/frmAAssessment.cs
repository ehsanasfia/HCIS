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
    public partial class frmAAssessment : DevExpress.XtraEditors.XtraForm
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

        public frmAAssessment()
        {
            InitializeComponent();
        }

        private void frmAAssessment_Load(object sender, EventArgs e)
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

            var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("35f1cb36-354a-4a03-9b2e-3ff2dd97cae8")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QA()
                {
                    PService = item,
                };
                lstComponent.Add(qa0);
            }
            ComponentQABindingSource.DataSource = lstComponent.OrderBy(c => c.PService.OldID);

            var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("85c1741a-fac0-4661-888c-7bcf505cd93b")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QA()
                {
                    PService = item,
                };
                lstDanger.Add(qa1);
            }
            DangerQABindingSource.DataSource = lstDanger.OrderBy(c => c.PService.OldID);

            var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("dba0e38e-d164-4b43-b58b-ba5f33eb05e3")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QA()
                {
                    PService = item,
                };
                lstAsk.Add(qa2);
            }
            AskQABindingSource.DataSource = lstAsk.OrderBy(c => c.PService.OldID);

            var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("a9a73efe-2538-4cc8-abf0-3f367a8223fe")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QA()
                {
                    PService = item,
                };
                lstMeasurement.Add(qa3);
            }
            MeasurementQABindingSource.DataSource = lstMeasurement.OrderBy(c => c.PService.OldID);

            var srvList4 = dc.Services.Where(x => x.ParentID == Guid.Parse("f95d1927-6f39-4015-b88b-1fc7154a16df")).ToList();
            foreach (var item in srvList4)
            {
                var qa4 = new QA()
                {
                    PService = item,
                };
                lstCheckup.Add(qa4);
            }
            CheckupQABindingSource.DataSource = lstCheckup.OrderBy(c => c.PService.OldID);

            var srvList5 = dc.Services.Where(x => x.ParentID == Guid.Parse("f587ce64-8376-4dc7-8103-6948b07b93b6")).ToList();
            foreach (var item in srvList5)
            {
                var qa5 = new QA()
                {
                    PService = item,
                };
                lstEducation.Add(qa5);
            }
            EducationQABindingSource.DataSource = lstEducation.OrderBy(c => c.PService.OldID);
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

                dc.SubmitChanges();
                ComponentQABindingSource.DataSource = null;
                DangerQABindingSource.DataSource = null;
                AskQABindingSource.DataSource = null;
                MeasurementQABindingSource.DataSource = null;
                CheckupQABindingSource.DataSource = null;
                EducationQABindingSource.DataSource = null;

                lstComponentHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("35f1cb36-354a-4a03-9b2e-3ff2dd97cae8")).ToList();
                ComponentHistoryQABindingSource.DataSource = lstComponentHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstDangerHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("85c1741a-fac0-4661-888c-7bcf505cd93b")).ToList();
                DangerHistoryQABindingSource.DataSource = lstDangerHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstAskHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("dba0e38e-d164-4b43-b58b-ba5f33eb05e3")).ToList();
                AskHistoryQABindingSource.DataSource = lstAskHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstMeasurementHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("a9a73efe-2538-4cc8-abf0-3f367a8223fe")).ToList();
                MeasurementHistoryQABindingSource.DataSource = lstMeasurementHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstCheckupHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("f95d1927-6f39-4015-b88b-1fc7154a16df")).ToList();
                CheckupHistoryQABindingSource.DataSource = lstCheckupHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstEducationHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("f587ce64-8376-4dc7-8103-6948b07b93b6")).ToList();
                EducationHistoryQABindingSource.DataSource = lstEducationHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl2.RefreshDataSource();
                gridControl4.RefreshDataSource();
                gridControl6.RefreshDataSource();
                gridControl8.RefreshDataSource();
                gridControl10.RefreshDataSource();
                gridControl12.RefreshDataSource();
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
                lstComponentHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("35f1cb36-354a-4a03-9b2e-3ff2dd97cae8")).ToList();
            }
            ComponentHistoryQABindingSource.DataSource = lstComponentHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl2.RefreshDataSource();
        }

        private void layoutControlGroup10_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup10.Expanded = !layoutControlGroup10.Expanded;

            if (!lstDangerHistory.Any())
            {
                lstDangerHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("85c1741a-fac0-4661-888c-7bcf505cd93b")).ToList();
            }
            DangerHistoryQABindingSource.DataSource = lstDangerHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl4.RefreshDataSource();
        }

        private void layoutControlGroup11_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup11.Expanded = !layoutControlGroup11.Expanded;

            if (!lstAskHistory.Any())
            {
                lstAskHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("dba0e38e-d164-4b43-b58b-ba5f33eb05e3")).ToList();
            }
            AskHistoryQABindingSource.DataSource = lstAskHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl6.RefreshDataSource();
        }

        private void layoutControlGroup12_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup12.Expanded = !layoutControlGroup12.Expanded;

            if (!lstMeasurementHistory.Any())
            {
                lstMeasurementHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("a9a73efe-2538-4cc8-abf0-3f367a8223fe")).ToList();
            }
            MeasurementHistoryQABindingSource.DataSource = lstMeasurementHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl8.RefreshDataSource();
        }

        private void layoutControlGroup13_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup13.Expanded = !layoutControlGroup13.Expanded;

            if (!lstCheckupHistory.Any())
            {
                lstCheckupHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("f95d1927-6f39-4015-b88b-1fc7154a16df")).ToList();
            }
            CheckupHistoryQABindingSource.DataSource = lstCheckupHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl10.RefreshDataSource();
        }

        private void layoutControlGroup14_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup14.Expanded = !layoutControlGroup14.Expanded;

            if (!lstEducationHistory.Any())
            {
                lstEducationHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("f587ce64-8376-4dc7-8103-6948b07b93b6")).ToList();
            }
            EducationHistoryQABindingSource.DataSource = lstEducationHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl12.RefreshDataSource();
        }
    }
}