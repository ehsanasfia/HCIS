using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Classes;
using OMOApp.Data;
using System.IO;

namespace OMOApp.Dialogs
{
    public partial class dlgPerson : DevExpress.XtraEditors.XtraForm
    {
        private OMOClassesDataContext om = new OMOClassesDataContext();
        public Person EditingPerson { get; set; }
        public PersonTbl JamiatPerson { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }


        private List<ManageMent> lstManagement;
        private List<Company> lstCompany;
        private List<SubCompany> lstSubCompany;
        private List<Unit> lstUnit;

        public dlgPerson()
        {
            InitializeComponent();
        }

        private void dlgPerson_Load(object sender, EventArgs e)
        {
            if (EditingPerson == null)
            {
                EditingPerson = new Person();
                if (JamiatPerson != null)
                {
                    EditingPerson.BirthDate = JamiatPerson.BirthDate == 0 || JamiatPerson.BirthDate.ToString().Length != 8 ? null : JamiatPerson.BirthDate.ToString().Substring(0, 4) + "/" + JamiatPerson.BirthDate.ToString().Substring(4, 2) + "/" + JamiatPerson.BirthDate.ToString().Substring(6, 2);
                    EditingPerson.FatherName = JamiatPerson.FatherName?.Trim();
                    EditingPerson.FirstName = JamiatPerson.Firstname?.Trim();
                    EditingPerson.Address = JamiatPerson.HomeAddress?.Trim();
                    EditingPerson.PhoneNumber = JamiatPerson.HomePhone?.Trim();
                    EditingPerson.IdentityNumber = JamiatPerson.IdentityNo?.Trim();
                    EditingPerson.MaritalStatus = JamiatPerson.IDMaritalStatus == 0 || JamiatPerson.IDMaritalStatus == 3 ? null : (JamiatPerson.IDMaritalStatus == 1 ? "مجرد" : "متاهل");
                    EditingPerson.LastName = JamiatPerson.Lastname?.Trim();
                    EditingPerson.NationalCode = JamiatPerson.NationalCode?.Trim();
                    EditingPerson.PersonalNo = JamiatPerson.PersonnelNo == 0 ? null as int? : JamiatPerson.PersonnelNo;
                    EditingPerson.PostalCode = JamiatPerson.PostCode?.Trim();
                    EditingPerson.Sex = JamiatPerson.Sex == 0 ? false : true;
                    EditingPerson.BirthCity = JamiatPerson.TBirthPlace?.Trim();
                    EditingPerson.BirthCertificateCity = JamiatPerson.TIdentityPlace?.Trim();
                    EditingPerson.PersonIDJamiat = JamiatPerson.IDPerson;
                    GetEmployeeInfo(JamiatPerson.IDPerson);
                }
                else if (NationalCode != null)
                {
                    EditingPerson.NationalCode = NationalCode;
                }
            }
            else
            {
                EditingPerson = om.Persons.FirstOrDefault(x => x.ID == EditingPerson.ID);
                if (EditingPerson.Photo == null)
                {
                    pictureEdit1.EditValue = null;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var data = EditingPerson.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pictureEdit1.EditValue = Image.FromStream(ms);
                    }
                }
            }

            lstManagement = om.ManageMents.OrderBy(x => x.Name).ToList();
            lstCompany = om.Companies.OrderBy(x => x.Name).ToList();
            lstSubCompany = om.SubCompanies.OrderBy(x => x.Name).ToList();
            lstUnit = om.Units.OrderBy(x => x.Name).ToList();
            manageMentBindingSource.DataSource = lstManagement;

            if (EditingPerson.IDManagement != null)
            {
                slkManagement.EditValue = lstManagement.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement);
                if (EditingPerson.IDCompany != null)
                {
                    slkCompany.EditValue = lstCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany);
                    if (EditingPerson.IDSubCompany != null)
                    {
                        slkSubCompany.EditValue = lstSubCompany.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDCo == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany);
                        if (EditingPerson.IDunit != null)
                        {
                            slkUnit.EditValue = lstUnit.FirstOrDefault(x => x.IDMg == EditingPerson.IDManagement && x.IDco == EditingPerson.IDCompany && x.IDOrgan == EditingPerson.IDSubCompany && x.IDUnit == EditingPerson.IDunit);
                        }
                    }
                }
            }

            PersonBindingSource.DataSource = EditingPerson;
        }
        private void GetEmployeeInfoOMO(Guid OMOID)
        {
            var cmp = om.Persons.FirstOrDefault(x => x.ID == OMOID);
            if (cmp == null)
            {
                slkManagement.EditValue = null;
                slkCompany.EditValue = null;
                slkSubCompany.EditValue = null;
                slkUnit.EditValue = null;
            }
            else
            {
                slkManagement.EditValue = cmp.IDManagement ?? null;
                slkCompany.EditValue = cmp.IDCompany ?? null;
                slkSubCompany.EditValue = cmp.IDSubCompany ?? null;
                slkUnit.EditValue = cmp.IDunit ?? null;
            }
        }
        private void GetEmployeeInfo(Guid IDPerson)
        {
            var cmp = om.View_Jamiat_Person_Companies.FirstOrDefault(x => x.IDPerson == IDPerson);
            if (cmp == null)
            {
            //    slkManagement.EditValue = null;
            //    slkCompany.EditValue = null;
            //    slkSubCompany.EditValue = null;
            //    slkUnit.EditValue = null;
            }
            else
            {
            //slkManagement.EditValue = cmp.IDManagement;
            //slkCompany.EditValue = cmp.IDCompany;
            //slkSubCompany.EditValue = cmp.IDSubCompany;
            //slkUnit.EditValue = cmp.IDUnit;
            EditingPerson.IDManagement = cmp.IDManagement;
            EditingPerson.IDCompany = cmp.IDCompany;
            EditingPerson.IDSubCompany = cmp.IDSubCompany;
            EditingPerson.IDunit = cmp.IDUnit;
        }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EditingPerson.NationalCode))
            {
                MessageBox.Show("لطفا کد ملی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtNationalCode.Select();
                return;
            }

            EditingPerson.NationalCode = EditingPerson.NationalCode.Trim();

            if (EditingPerson.NationalCode.Length != 10  ||  !MainModule.IsValidNationalCode(EditingPerson.NationalCode))
            {
                MessageBox.Show("کد ملی وارد شده معتبر نمیباشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtNationalCode.Select();
                return;
            }

            if (EditingPerson.ID == Guid.Empty)
            {
                var prs = om.Persons.FirstOrDefault(x => x.NationalCode == EditingPerson.NationalCode);
                if (prs != null)
                {
                     if (MessageBox.Show(this, $"بیماری با نام و نام خانوادگی \"{prs.FirstName + " " + prs.LastName}\" با این کد ملی قبلا در سیستم ثبت شده است. آیا می خواهید اطلاعات را ویرایش کنید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        txtNationalCode.Select();
                        return;
                    }
                    else
                    {
                        try
                        {

                            prs .FirstName= EditingPerson.FirstName;
                            prs.Address = EditingPerson.Address;
                            prs.BirthCertificateCity = EditingPerson.BirthCertificateCity;
                            prs.BirthCertificateNo = EditingPerson.BirthCertificateNo;
                            prs.BirthCity = EditingPerson.BirthCity;
                            prs.BirthDate = EditingPerson.BirthDate;
                            prs.EducationLicence = EditingPerson.EducationLicence;
                            prs.FatherName = EditingPerson.FatherName;

                            prs.FirstName = EditingPerson.FirstName;
                            prs.LastName = EditingPerson.LastName;
                            prs.MaritalStatus = EditingPerson.MaritalStatus;
                            prs.MilitaryServiceState = EditingPerson.MilitaryServiceState;
                            prs.MobileNumber = EditingPerson.MobileNumber;
                            prs.NaftJobExperience = EditingPerson.NaftJobExperience;
                         //   prs.NationalCode = EditingPerson.FirstName;
                            prs.PersonalNo = EditingPerson.PersonalNo;
                            prs.PersonIDJamiat = EditingPerson.PersonIDJamiat;

                            prs.PersonWorkHistories = EditingPerson.PersonWorkHistories;
                            prs.PhoneNumber = EditingPerson.PhoneNumber;
                            prs.PostalCode = EditingPerson.PostalCode;
                            prs.Sex = EditingPerson.Sex;
                            
                            if (pictureEdit1.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                                    objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                                    prs.Photo = binary;
                                }
                            }
                            else
                                prs.Photo = null;

                            var mg = slkManagement.EditValue as ManageMent;
                            var cmp = slkCompany.EditValue as Company;
                            var sub = slkSubCompany.EditValue as SubCompany;
                            var unt = slkUnit.EditValue as Unit;


                            if (mg == null)
                                prs.IDManagement = null;
                            else
                                prs.IDManagement = mg.IDMg;


                            if (cmp == null)
                                prs.IDCompany = null;
                            else
                                prs.IDCompany = cmp.IDCo;


                            if (sub == null)
                                prs.IDSubCompany = null;
                            else
                                prs.IDSubCompany = sub.IDOrgan;


                            if (unt == null)
                                prs.IDunit = null;
                            else
                                prs.IDunit = unt.IDUnit;
                            om.SubmitChanges();
                            EditingPerson = prs;
                            DialogResult = DialogResult.OK;
                            return;
                        }

                        catch(Exception ex) { MessageBox.Show(ex.ToString()); }
                        }
                   
                }
            }

            if (string.IsNullOrWhiteSpace(EditingPerson.FirstName))
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtFirstName.Select();
                return;
            }

            if (string.IsNullOrWhiteSpace(EditingPerson.LastName))
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtLastName.Select();
                return;
            }

            try
            {
                
                if (pictureEdit1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        EditingPerson.Photo = binary;
                    }
                }
                else
                    EditingPerson.Photo = null;

                var mg = slkManagement.EditValue as ManageMent;
                var cmp = slkCompany.EditValue as Company;
                var sub = slkSubCompany.EditValue as SubCompany;
                var unt = slkUnit.EditValue as Unit;


                if (mg == null)
                    EditingPerson.IDManagement = null;
                else
                    EditingPerson.IDManagement = mg.IDMg;


                if (cmp == null)
                    EditingPerson.IDCompany = null;
                else
                    EditingPerson.IDCompany = cmp.IDCo;


                if (sub == null)
                    EditingPerson.IDSubCompany = null;
                else
                    EditingPerson.IDSubCompany = sub.IDOrgan;


                if (unt == null)
                    EditingPerson.IDunit = null;
                else
                    EditingPerson.IDunit = unt.IDUnit;

                if (EditingPerson.ID == Guid.Empty)
                {
                    EditingPerson.CreatorUserID = MainModule.UserID;
                    EditingPerson.CreatorUserFullName = MainModule.UserFullName;
                    EditingPerson.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingPerson.CreationTime = DateTime.Now.ToString("HH:mm");
                    if (om.Persons.Any(c => c.NationalCode == EditingPerson.NationalCode))
                        {
                        MessageBox.Show("کدملی وارد شده تکراری می باشد."); return;
                    }
                    om.Persons.InsertOnSubmit(EditingPerson);
                } else
                {

                    if (om.Persons.Any(c => c.NationalCode == EditingPerson.NationalCode))
                            {
                        MessageBox.Show("کدملی وارد شده تکراری می باشد."); return;
                    }
                }
                om.SubmitChanges();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void slkManagement_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkManagement.EditValue as ManageMent;
            if (cur == null)
            {
                companyBindingSource.DataSource = null;
                return;
            }

            companyBindingSource.DataSource = lstCompany.Where(x => x.IDMg == cur.IDMg).ToList();
        }

        private void slkCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkCompany.EditValue as Company;
            if (cur == null)
            {
                subCompanyBindingSource.DataSource = null;
                return;
            }

            subCompanyBindingSource.DataSource = lstSubCompany.Where(x => x.IDMg == cur.IDMg && x.IDCo == cur.IDCo).ToList();
        }

        private void slkSubCompany_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkSubCompany.EditValue as SubCompany;
            if (cur == null)
            {
                unitBindingSource.DataSource = null;
                return;
            }

            unitBindingSource.DataSource = lstUnit.Where(x => x.IDMg == cur.IDMg && x.IDco == cur.IDCo && x.IDOrgan == cur.IDOrgan).ToList();
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            pictureEdit1.LoadImage();
        }
    }
}