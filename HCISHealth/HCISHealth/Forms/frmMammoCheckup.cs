using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISHealth.Forms
{
    public partial class frmMammoCheckup : DevExpress.XtraEditors.XtraForm
    {
        public frmMammoCheckup()
        {
            InitializeComponent();
        }

        private void frmMammoCheckup_Load(object sender, EventArgs e)
        {
            GetPersonInfo();
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET;
            ribbonPageGroup2.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
    }
}