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
    public partial class frmDrug : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<Service> lst = new List<Service>();

        public frmDrug()
        {
            InitializeComponent();
        }

        private void frmDrug_Load(object sender, EventArgs e)
        {
            var q = from p in dc.Services
                    where p.CategoryID == 4
                    select p;
            serviceBindingSource.DataSource = q;
            GetPersonInfo();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;
            if (!lst.Contains(current))
            {
                lst.Add(current);
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            bindingSource1.DataSource = lst;
            gridControl2.RefreshDataSource();
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup3.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }

        private void btnOk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lst.Any())
            {
                lst.ForEach(x =>
                {
                    var DH = new DrugHistory()
                    {
                        PersonID = MainModule.PRS_SET.ID,
                        DrugID = x.ID,
                        CreatorUserID = MainModule.UserID,
                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                    };
                    dc.DrugHistories.InsertOnSubmit(DH);
                });
                MessageBox.Show("اطلاعات با موفقیت ثبت شد");
                dc.SubmitChanges();
                //  DrugHistoryBindingSource.DataSource = null;
                lst.Clear();
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}