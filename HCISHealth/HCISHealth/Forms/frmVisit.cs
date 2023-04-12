using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISHealth.Data;
using HCISHealth.Classes;


namespace HCISHealth.Forms
{
    public partial class frmVisit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> Parents = new List<QA>();
        List<QA> AllChilds = new List<QA>();
        List<QA> FilterdChilds = new List<QA>();
        List<QA> lstHistory = new List<QA>();

        public frmVisit()
        {
            InitializeComponent();
        }

        private void frmVisit_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            var formService = dc.Services.Where(x => x.ParentID == Guid.Parse("766f5c6c-2454-48de-bccf-1b006e0467d7")).OrderBy(c => c.OldID).ToList();
            foreach (var item in formService)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);
                foreach (var service in item.Services)
                {
                    var qa = new QA()
                    {
                        PService = service,
                    };
                    AllChilds.Add(qa);
                }
            }
            QABindingSource.DataSource = Parents.OrderBy(c => c.Service.OldID);
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
                if (gsm == null)
                    return;

                foreach (var item in AllChilds)
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
                DetailQABindingSource.DataSource = null;

                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.Service1 != null && x.Service.Service1.ParentID == Guid.Parse("766f5c6c-2454-48de-bccf-1b006e0467d7")).ToList();
                HistoryQABindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
                gridControl3.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cur = QABindingSource.Current as QA;
                if (cur == null)
                    return;
                FilterdChilds = AllChilds.Where(x => x.PService.ParentID == cur.QuestionnariID || (x.PService.Service1 != null && x.PService.Service1.ParentID == cur.QuestionnariID)).OrderBy(c => c.PService.OldID).ToList();

                DetailQABindingSource.DataSource = FilterdChilds;
                gridControl2.RefreshDataSource();
            }
            else
                return;
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup2.Expanded = !layoutControlGroup2.Expanded;

            if (!lstHistory.Any())
            {
                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.Service1 != null && x.Service.Service1.ParentID == Guid.Parse("766f5c6c-2454-48de-bccf-1b006e0467d7")).ToList();
            }
            HistoryQABindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl3.RefreshDataSource();
        }
    }
}