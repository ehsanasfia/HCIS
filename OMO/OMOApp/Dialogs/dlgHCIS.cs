using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgHCIS : DevExpress.XtraEditors.XtraForm
    {
        public Person OmoPerson { get; set; }
        public Data.HCISData.Person EditingPerson { get; set; }

        private Data.HCISData.HCISClassesDataContext dc = new Data.HCISData.HCISClassesDataContext();

        public dlgHCIS()
        {
            InitializeComponent();
        }

        private void dlgHCIS_Load(object sender, EventArgs e)
        {
            try
            {
                insuranceBindingSource.DataSource = dc.Insurances.Where(x => x.OMO == true).OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var ins = lkpInsurance.EditValue as Data.HCISData.Insurance;
            if (ins == null)
            {
                MessageBox.Show("لطفا بیمه را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            try
            {
                var now = DateTime.Now;
                var today = MainModule.GetPersianDate(DateTime.Now);
                var nowTime = DateTime.Now.ToString("HH:mm");
                var later = now.AddYears(10);
                var laterPersian = MainModule.GetPersianDate(later);

                EditingPerson = new Data.HCISData.Person()
                {
                    Address = OmoPerson.Address,
                    BirthDate = OmoPerson.BirthDate,
                    BirthPlace = OmoPerson.BirthCity,
                    BookletExpireDate = laterPersian,
                    CellularPhone = OmoPerson.MobileNumber,
                    CreationDate = today,
                    CreationTime = nowTime,
                    CreatorUser = MainModule.UserID,
                    Education = OmoPerson.EducationLicence,
                    FatherName = OmoPerson.FatherName,
                    FirstName = OmoPerson.FirstName,
                    IdentityNumber = OmoPerson.IdentityNumber,
                    IdentityPlace = OmoPerson.BirthCertificateCity,
                    InsuranceName = ins.Name,
                    LastName = OmoPerson.LastName,
                    LastModificationDate = today,
                    LastModificationTime = nowTime,
                    MaritalStatus = OmoPerson.MaritalStatus,
                    //MedicalID = MainModule.CreateMedicalID(OmoPerson.PersonalNo),
                    NationalCode = OmoPerson.NationalCode,
                    PersonalCode = MainModule.PersonalNoToString(OmoPerson.PersonalNo),
                    Phone = OmoPerson.PhoneNumber,
                    Photo = OmoPerson.Photo,
                    Sex = OmoPerson.Sex
                };


                dc.Persons.InsertOnSubmit(EditingPerson);
                dc.SubmitChanges();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}