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
    public partial class frmVaccian : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<Service> lstVacc;

        public frmVaccian()
        {
            InitializeComponent();
        }

        private void EndEdit()
        {
            ServiceBindingSource.EndEdit();
            SelectedServiceBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (lstVacc == null)
                {
                    lstVacc = new List<Service>();
                }

                ServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 15 && x.Service1.Name == "واکسن").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup2.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirrhday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void frmVaccian_Load(object sender, EventArgs e)
        {
            GetPersonInfo();
            GetData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var current = ServiceBindingSource.Current as Service;
                if (current == null)
                    return;
                if (!lstVacc.Contains(current))
                {
                    lstVacc.Add(current);
                }
                else
                {
                    MessageBox.Show("این واکسن انتخاب شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                SelectedServiceBindingSource.DataSource = lstVacc;
                gridControl3.RefreshDataSource();
            }
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

                if (lstVacc.Any())
                {
                    lstVacc.ForEach(x =>
                    {
                        var qa = new QA()
                        {
                            GivenServiceM = gsm,
                            ParentID = x.Service1.ID,
                            QuestionnariID = x.ID,
                            CreationUser = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            Date = MainModule.GetPersianDate(DateTime.Now),
                        };
                        dc.QAs.InsertOnSubmit(qa);
                    });
                    SelectedServiceBindingSource.DataSource = null;
                    lstVacc.Clear();
                }

                dc.SubmitChanges();
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

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_SET.ID);
            if (gsm == null)
                return;
            qABindingSource.DataSource = dc.QAs.Where(x => x.GivenServiceM == gsm && x.Service1 != null && x.Service1.Name == "واکسن").OrderByDescending(c => c.CreationDate).ToList();
        }
    }
}