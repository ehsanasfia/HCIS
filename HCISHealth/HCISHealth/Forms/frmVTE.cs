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
    public partial class frmVTE : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstTebbi;
        List<QA> lstGeneral;
        List<QA> lstMama;
        List<QA> lstTemporary;
        List<QA> lstHistoryTebbi;
        List<QA> lstHistoryGeneral;
        List<QA> lstHistoryMama;
        List<QA> lstHistoryTemporary;

        public frmVTE()
        {
            InitializeComponent();
        }

        private void frmVTE_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstTebbi == null)
                lstTebbi = new List<QA>();

            if (lstGeneral == null)
                lstGeneral = new List<QA>();

            if (lstMama == null)
                lstMama = new List<QA>();

            if (lstTemporary == null)
                lstTemporary = new List<QA>();

            if (lstHistoryTebbi == null)
                lstHistoryTebbi = new List<QA>();

            if (lstHistoryGeneral == null)
                lstHistoryGeneral = new List<QA>();

            if (lstHistoryMama == null)
                lstHistoryMama = new List<QA>();

            if (lstHistoryTemporary == null)
                lstHistoryTemporary = new List<QA>();

            var srvList0 = dc.Services.Where(x => x.ParentID == Guid.Parse("37a239a3-90ca-4836-a18e-a7819866b585")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QA()
                {
                    PService = item,
                };
                lstTebbi.Add(qa0);
            }
            TebbiQABindingSource.DataSource = lstTebbi.OrderBy(c => c.PService.OldID);

            var srvList1 = dc.Services.Where(x => x.ParentID == Guid.Parse("9a99d399-b3e8-4e1e-b6ab-19b8718b6d68")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QA()
                {
                    PService = item,
                };
                lstGeneral.Add(qa1);
            }
            GeneralQABindingSource.DataSource = lstGeneral.OrderBy(c => c.PService.OldID);

            var srvList2 = dc.Services.Where(x => x.ParentID == Guid.Parse("ea0645e9-c92f-4c92-9c4d-5a66b2a95819")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QA()
                {
                    PService = item,
                };
                lstMama.Add(qa2);
            }
            MamaQABindingSource.DataSource = lstMama.OrderBy(c => c.PService.OldID);

            var srvList3 = dc.Services.Where(x => x.ParentID == Guid.Parse("59bc95bb-74a1-4448-a823-0447ae82093e")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QA()
                {
                    PService = item,
                };
                lstTemporary.Add(qa3);
            }
            TemporaryQABindingSource.DataSource = lstTemporary.OrderBy(c => c.PService.OldID);
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

                foreach (var item in lstTebbi)
                {
                    if (item.ResultN != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstGeneral)
                {
                    if (item.ResultN != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstMama)
                {
                    if (item.ResultN != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }
                foreach (var item in lstTemporary)
                {
                    if (item.ResultN != null || !string.IsNullOrWhiteSpace(item.Description))
                    {
                        item.Service = item.PService;
                        item.GivenServiceM = gsm;
                        item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                        item.CreationUser = MainModule.UserID;
                        dc.QAs.InsertOnSubmit(item);
                    }
                }

                dc.SubmitChanges();
                TebbiQABindingSource.DataSource = null;
                GeneralQABindingSource.DataSource = null;
                MamaQABindingSource.DataSource = null;
                TemporaryQABindingSource.DataSource = null;

                lstHistoryTebbi = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("37a239a3-90ca-4836-a18e-a7819866b585")).ToList();
                HistoryTebbiQABindingSource.DataSource = lstHistoryTebbi.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstHistoryGeneral = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("9a99d399-b3e8-4e1e-b6ab-19b8718b6d68")).ToList();
                HistoryGeneralQABindingSource.DataSource = lstHistoryGeneral.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstHistoryMama = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("ea0645e9-c92f-4c92-9c4d-5a66b2a95819")).ToList();
                HistoryMamaQABindingSource.DataSource = lstHistoryMama.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                lstHistoryTemporary = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("59bc95bb-74a1-4448-a823-0447ae82093e")).ToList();
                HistoryTemporaryQABindingSource.DataSource = lstHistoryTemporary.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl5.RefreshDataSource();
                gridControl6.RefreshDataSource();
                gridControl7.RefreshDataSource();
                gridControl8.RefreshDataSource();
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

        private void layoutControlGroup9_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup9.Expanded = !layoutControlGroup9.Expanded;

            if (!lstHistoryTebbi.Any())
            {
                lstHistoryTebbi = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("37a239a3-90ca-4836-a18e-a7819866b585")).ToList();
            }
            HistoryTebbiQABindingSource.DataSource = lstHistoryTebbi.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl5.RefreshDataSource();
        }

        private void layoutControlGroup8_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup8.Expanded = !layoutControlGroup8.Expanded;

            if (!lstHistoryGeneral.Any())
            {
                lstHistoryGeneral = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("9a99d399-b3e8-4e1e-b6ab-19b8718b6d68")).ToList();
            }
            HistoryGeneralQABindingSource.DataSource = lstHistoryGeneral.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl6.RefreshDataSource();
        }

        private void layoutControlGroup7_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup7.Expanded = !layoutControlGroup7.Expanded;

            if (!lstHistoryMama.Any())
            {
                lstHistoryMama = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("ea0645e9-c92f-4c92-9c4d-5a66b2a95819")).ToList();
            }
            HistoryMamaQABindingSource.DataSource = lstHistoryMama.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl7.RefreshDataSource();
        }

        private void layoutControlGroup6_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup6.Expanded = !layoutControlGroup6.Expanded;

            if (!lstHistoryTemporary.Any())
            {
                lstHistoryTemporary = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("59bc95bb-74a1-4448-a823-0447ae82093e")).ToList();
            }
            HistoryTemporaryQABindingSource.DataSource = lstHistoryTemporary.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl8.RefreshDataSource();
        }
    }
}