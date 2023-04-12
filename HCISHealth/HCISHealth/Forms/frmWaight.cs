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
    public partial class frmWaight : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> lstWeight;
        List<QA> lstHistory;

        public frmWaight()
        {
            InitializeComponent();
        }

        private void frmWaight_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

            if (lstWeight == null)
                lstWeight = new List<QA>();

            if (lstHistory == null)
                lstHistory = new List<QA>();

            var srvList = dc.Services.Where(x => x.ParentID == Guid.Parse("dcafcff0-bfeb-4c3d-8c6c-13ec7f9df140")).ToList();
            foreach (var item in srvList)
            {
                var qa = new QA()
                {
                    PService = item,
                };
                lstWeight.Add(qa);
            }
            QABindingSource.DataSource = lstWeight.OrderBy(c => c.PService.OldID);
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
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

                foreach (var item in lstWeight)
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
                QABindingSource.DataSource = null;

                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("dcafcff0-bfeb-4c3d-8c6c-13ec7f9df140")).ToList();
                HistoryBindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);

                gridControl2.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (!lstHistory.Any())
            {
                lstHistory = dc.QAs.Where(x => x.Service != null && x.Service.ParentID == Guid.Parse("dcafcff0-bfeb-4c3d-8c6c-13ec7f9df140")).ToList();
            }
            HistoryBindingSource.DataSource = lstHistory.OrderBy(c => c.Service.OldID).OrderByDescending(c => c.CreationDate);
            gridControl2.RefreshDataSource();
        }
    }
}