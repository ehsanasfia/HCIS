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
    public partial class frmMamogeraphi : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lst;
        List<QA> lstHistory;

        public frmMamogeraphi()
        {
            InitializeComponent();
        }

        private void frmMamogeraphi_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lst == null)
                lst = new List<QA>();

            if (lstHistory == null)
                lstHistory = new List<QA>();

            var srvList = dc.Services.Where(x => x.ParentID == Guid.Parse("2c21fcea-7227-41c6-b17d-40282b835115")).ToList();
            foreach (var item in srvList)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                lst.Add(qa);
            }
            QABindingSource.DataSource = lst.OrderBy(c => c.PService.OldID);
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup1.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLName.Caption = "نام خانوادگی: " + person.LastName;
            lblFatherName.Caption = "نام پدر: " + person.FatherName;
            lblNationalNO.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonelID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
                if (gsm == null)
                    return;

                foreach (var item in lst)
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
                QABindingSource.DataSource = null;

                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("2c21fcea-7227-41c6-b17d-40282b835115")).ToList();
                QAHistoryBindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl2.RefreshDataSource();
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

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup2.Expanded = !layoutControlGroup2.Expanded;

            if (!lstHistory.Any())
            {
                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("2c21fcea-7227-41c6-b17d-40282b835115")).ToList();
            }
            QAHistoryBindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl2.RefreshDataSource();
        }
    }
}