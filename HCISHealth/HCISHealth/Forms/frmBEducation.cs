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
    public partial class frmBEducation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstEdu;
        List<QA> lstHistory;

        public frmBEducation()
        {
            InitializeComponent();
        }

        private void frmBEducation_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstEdu == null)
                lstEdu = new List<QA>();

            if (lstHistory == null)
                lstHistory = new List<QA>();

            var srvList = dc.Services.Where(x => x.ParentID == Guid.Parse("78fe721d-e84c-4c6e-9bd1-44a3598b2ec6")).ToList();
            foreach (var item in srvList)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                lstEdu.Add(qa);
            }
            QABindingSource.DataSource = lstEdu.OrderBy(c => c.PService.OldID);
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

                foreach (var item in lstEdu)
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

                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("78fe721d-e84c-4c6e-9bd1-44a3598b2ec6")).ToList();
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

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            layoutControlGroup2.Expanded = !layoutControlGroup2.Expanded;

            if (!lstHistory.Any())
            {
                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("78fe721d-e84c-4c6e-9bd1-44a3598b2ec6")).ToList();
            }
            HistoryQABindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl3.RefreshDataSource();
        }
    }
}