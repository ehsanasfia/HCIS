using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Dialogs;
using HCISHealth.Forms;
using HCISHealth.Data;
using HCISHealth.Classes;
namespace HCISHealth.Forms
{
    public partial class frmServiceRegister : DevExpress.XtraEditors.XtraForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<GivenServiceD> lst = new List<GivenServiceD>();
        List<GivenServiceD> del = new List<GivenServiceD>();
        public GivenServiceM ObjectRM { get; set; }


        public frmServiceRegister()
        {
            InitializeComponent();
        }

        private void frmServiceRegister_Load(object sender, EventArgs e)
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup3.Visible = true;
            aPHeAlthBindingSource.DataSource = dc.AP_HeAlths.Where(c => c.PersonID == Classes.MainModule.PRS_SET.ID && c.ServiceCategoryID == 15).OrderByDescending(c => c.LastModificationDate).ThenByDescending(c => c.LastModificationTime).ToList();
            if (person == null)
            {
                // return;
            }
            else
            {
                lblName.Caption = "نام: " + person.FirstName;
                lblLname.Caption = "نام خانوادگی: " + person.LastName;
                lblFather.Caption = "نام پدر: " + person.FatherName;
                lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
                lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
                lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
            }
            serviceBindingSource.DataSource = dc.Services.Where(c => c.ParentID == Guid.Parse("a7dadd4e-951b-4ec2-8c4e-d6282bed4181")).ToList();
            GetData();
        }

        private void GetData()
        {
            if (ObjectRM == null)
            {
                ObjectRM = new GivenServiceM();
            }
            givenServiceDBindingSource.DataSource = ObjectRM.GivenServiceDs.ToList();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var row = serviceBindingSource.Current as Service;
            if (row == null)
            {
                return;
            }
            if (lst.Any(c => c.ServiceID == row.ID)) { MessageBox.Show("خدمت قبلا در لیست موجود می باشد"); return; }
            var RD = new GivenServiceD()
            {
                Service = row,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                Category = "1",
                CreatorUserFullname = Classes.MainModule.UserFullName,
                GivenServiceM = ObjectRM,
            };
            ObjectRM.GivenServiceDs.Add(RD);
            dc.GivenServiceDs.InsertOnSubmit(RD);
            lst = ObjectRM.GivenServiceDs.ToList();
            givenServiceDBindingSource.DataSource = lst;
            givenServiceDBindingSource.EndEdit();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var person = Classes.MainModule.Person; ribbonPageGroup3.Visible = true;
            if (ObjectRM == null)
            {
                return;
            }
            ObjectRM.PersonID = Classes.MainModule.PRS_SET.ID;

            ObjectRM.ServiceCategoryID = 15;
            ObjectRM.DepartmentID = MainModule.MyDepartment.ID;
            ObjectRM.DossierID = MainModule.GSM_SET.DossierID;
            ObjectRM.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.Date = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectRM.CreatorUserID = MainModule.UserID;
            ObjectRM.CreatorUserFullname = MainModule.UserFullName;
            dc.GivenServiceMs.InsertOnSubmit(ObjectRM);
            dc.SubmitChanges();
            ObjectRM = null;

            givenServiceDBindingSource.DataSource = null;
            MessageBox.Show("اطلاعات با موفقیت ثبت  گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            aPHeAlthBindingSource.DataSource = dc.AP_HeAlths.Where(c => c.PersonID == Classes.MainModule.PRS_SET.ID && c.ServiceCategoryID == 15).OrderByDescending(c => c.LastModificationDate).ThenByDescending(c => c.LastModificationTime).ToList();
            if (ObjectRM == null)
            {
                ObjectRM = new GivenServiceM();
            }
            givenServiceDBindingSource.DataSource = ObjectRM.GivenServiceDs.ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}