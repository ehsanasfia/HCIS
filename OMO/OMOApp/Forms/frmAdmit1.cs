using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using OMOApp.Data;
using OMOApp.Data.IMPHOData;
using OMOApp.Classes;
using OMOApp.Data.HCISData;

namespace OMOApp.Forms
{
    public partial class frmAdmit1 : DevExpress.XtraEditors.XtraForm
    {
        JamiatClassesDataContext dcJ = new JamiatClassesDataContext();
        OMOClassesDataContext dco = new OMOClassesDataContext();
        IMPHODataContext dci = new IMPHODataContext();
        HCISClassesDataContext dc = new HCISClassesDataContext();
        public PersonTbl JamiatPrs { get; set; }

        public Data.HCISData.Person HCISPerson { get; set; }
        public OMOApp.Data.Person OmoPrs { get; set; }
        public OMOApp.Data.IMPHOData.Person ImphoPrs { get; set; }

        public frmAdmit1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region checktxt
                if (string.IsNullOrWhiteSpace(txtPersonalCode.Text))
                {
                    MessageBox.Show("کد پرسنلی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                int id = -1;
                bool valid = int.TryParse(txtPersonalCode.Text.Trim(), out id);
                if (id == -1 || !valid)
                {
                    MessageBox.Show("کد پرسنلی معتبر نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    return;
                }

                EmptyForm();
                #endregion
                OmoPrs = dco.Persons.Where(c => c.PersonalNo == Int32.Parse(txtPersonalCode.Text)).FirstOrDefault();
                if (OmoPrs == null)
                {
                    JamiatPrs = dcJ.PersonTbls.Where(c => c.PersonnelNo == id && c.RelationOrderNo == 0).FirstOrDefault();
                    if (JamiatPrs == null)
                    {
                        MessageBox.Show("فردی با کد شناسایی وارد شده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        if (MainModule.ConnectToHcis == true)

                        #region Use HCIS
                        {
                            var dlg = new dlgAdmisionHCIS();
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                HCISPerson = dlg.EditingPerson;
                                if (HCISPerson == null || HCISPerson.Photo == null)
                                {
                                    pictureEdit1.EditValue = null;
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        var data = HCISPerson.Photo.ToArray();
                                        ms.Write(data, 0, data.Length);
                                        ms.Flush();
                                        pictureEdit1.EditValue = Image.FromStream(ms);
                                    }
                                }

                                txtFirstName.Text = HCISPerson.FirstName;
                               txtLastName.Text= HCISPerson.LastName;
                                txtAdress.Text = HCISPerson.Address;
                                txtBirth.Text = HCISPerson.BirthDate + "";
                                txtFather.Text = HCISPerson.FatherName;

                            }
                            else
                                return;
                        }
                        #endregion

                        else
                        #region Not Use Hcis
                        {
                            var dlg = new dlgAdmisionOMO();
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                OmoPrs = dlg.OmoPrs;
                                if (OmoPrs == null || OmoPrs.Photo == null)
                                {
                                    pictureEdit1.EditValue = null;
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        var data = HCISPerson.Photo.ToArray();
                                        ms.Write(data, 0, data.Length);
                                        ms.Flush();
                                        pictureEdit1.EditValue = Image.FromStream(ms);
                                    }
                                }

                                txtFirstName.Text = OmoPrs.FirstName;
                                txtLastName.Text = OmoPrs.LastName;
                                txtAdress.Text = OmoPrs.Address;
                                txtBirth.Text = OmoPrs.BirthDate + "";
                                txtFather.Text = OmoPrs.FatherName;
                                slkManagment.EditValue = OmoPrs.IDManagement;
                                slkCompany.EditValue = OmoPrs.IDCompany;
                                slkSubCompany.EditValue = OmoPrs.IDSubCompany;
                                slkUnit.EditValue = OmoPrs.IDunit;
                            }
                            else
                                return;
                        }
                        #endregion

                    }
                    else
                    {


                        var MPH = dcJ.MemberPhotos.Where(c => c.IDPerson == JamiatPrs.IDPerson).FirstOrDefault();
                        if (MPH == null || MPH.Photo == null)
                        {
                            pictureEdit1.EditValue = null;
                        }
                        else
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                var data = MPH.Photo.ToArray();
                                ms.Write(data, 0, data.Length);
                                ms.Flush();
                                pictureEdit1.EditValue = Image.FromStream(ms);
                            }
                        }

                        if (string.IsNullOrWhiteSpace(JamiatPrs.NationalCode) || JamiatPrs.NationalCode.Trim().Length < 10 || JamiatPrs.NationalCode.Trim().Length > 10 || JamiatPrs.NationalCode.Trim() == "0000000000")
                        {
                            if (MessageBox.Show(".کد ملی بیمار ناقص میباشد لطفا آن را اصلاح فرمایید و یا با شماره 778 تماس بگیرید" + " در ضمن مسئولیت تغییر کد ملی به عهده شما میباشد " + " " + MainModule.UserFullName, "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                            {
                                var dlg = new Dialogs.dlgNtaionalCode();
                                dlg.Text = "کد ملی " + " " + JamiatPrs.Firstname + " " + JamiatPrs.Lastname;
                                dlg.ShowDialog();
                                if (dlg.DialogResult != DialogResult.OK)
                                {
                                    return;
                                }
                                else
                                {
                                    txtCodemeli.Text = dlg.NationalCode;
                                }
                            }
                        }
                        else
                            txtCodemeli.Text = JamiatPrs.NationalCode;

                        txtFirstName.Text = JamiatPrs.Firstname;
                        txtLastName.Text= JamiatPrs.Lastname;
                        txtAdress.Text = JamiatPrs.HomeAddress;
                        txtBirth.Text = JamiatPrs.BirthDate + "";
                        txtFather.Text = JamiatPrs.FatherName;
                        GetEmployeeInfo(JamiatPrs.IDPerson);
                    }
                }
                else
                {
                    txtFirstName.Text = OmoPrs.FirstName;
                    txtLastName.Text= OmoPrs.LastName;
                    txtAdress.Text = OmoPrs.Address;
                    txtBirth.Text = OmoPrs.BirthDate + "";
                    txtFather.Text = OmoPrs.FatherName;
                    GetEmployeeInfoOMO(OmoPrs.ID);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (OmoPrs == null)
            {
                visitBindingSource.DataSource = null;
            }
            else
            {
                visitBindingSource.DataSource = dco.Visits.Where(c => c.PersonID == OmoPrs.ID).OrderByDescending(c => c.AdmitDate).ToList();
            }
        }

        private void GetEmployeeInfoOMO(Guid OMOID)
        {
            var cmp = dco.Persons.FirstOrDefault(x => x.ID == OMOID);
            if (cmp == null)
            {
                slkManagment.EditValue = null;
                slkCompany.EditValue = null;
                slkSubCompany.EditValue = null;
                slkUnit.EditValue = null;
            }
            else
            {
                slkManagment.EditValue = cmp.IDManagement??null;
                slkCompany.EditValue = cmp.IDCompany??null;
                slkSubCompany.EditValue = cmp.IDSubCompany ?? null;
                slkUnit.EditValue = cmp.IDunit ?? null;
            }
        }
        private void GetEmployeeInfo(Guid IDPerson)
        {
            var cmp = dco.View_Jamiat_Person_Companies.FirstOrDefault(x => x.IDPerson == IDPerson);
            if (cmp == null)
            {
                slkManagment.EditValue = null;
                slkCompany.EditValue = null;
                slkSubCompany.EditValue = null;
                slkUnit.EditValue = null;
            }
            else
            {
                slkManagment.EditValue = cmp.IDManagement ;
                slkCompany.EditValue = cmp.IDCompany ;
                slkSubCompany.EditValue = cmp.IDSubCompany ;
                slkUnit.EditValue = cmp.IDUnit ;
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(spinEdit1.Text))
                //{
                //    MessageBox.Show("شماره پرسنلی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}
                if ((lkpNoeMoayene.EditValue as int?) == null)
                {
                    MessageBox.Show("نوع معاینات را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                //if (lkpIDIntroduction.EditValue == null)
                //{
                //    MessageBox.Show("معرفی نامه را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    return;
                //}

                var today = Classes.MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                //if( ImphoPrs?.MedicalID!=null)
                //    var person = dc.Persons.FirstOrDefault(c => c.MedicalID == JamiatPrs.NationalCode);

                //    if(person.NationalCode== JamiatPrs.NationalCode)
                //         person = dc.Persons.FirstOrDefault(c => c.NationalCode == JamiatPrs.NationalCode);
                //    if (person == null)
                string Medical = "";


                if (JamiatPrs != null)
                {
                    if (JamiatPrs.PersonnelNo > 0)
                    {
                        Medical = "";
                        for (int i = JamiatPrs.PersonnelNo.ToString().Length; i < 7; i++)
                        {
                            Medical = Medical + "0";

                        }
                        var c = JamiatPrs.PersonnelNo.ToString();
                        Medical = Medical + c;
                        Medical = "00-" + Medical + "-01";
                    }
                    if (MainModule.ConnectToHcis == true)
                    {
                        HCISPerson = dc.Persons.FirstOrDefault(c => c.NationalCode == txtCodemeli.Text);
                        if (HCISPerson == null)
                        {
                            HCISPerson = new Data.HCISData.Person()
                            {
                                Address = JamiatPrs.HomeAddress,
                                CreationDate = today,
                                CreationTime = now,
                                CreatorUser = MainModule.UserID,
                                FirstName = JamiatPrs.Firstname,
                                LastName = JamiatPrs.Lastname,
                                FatherName = JamiatPrs.FatherName,
                                BirthDate = JamiatPrs.BirthDate + "",
                                PersonalCode = JamiatPrs.PersonnelNo.ToString(),
                                NationalCode = txtCodemeli.Text,
                                Phone = JamiatPrs.HomePhone,
                                Sex = JamiatPrs.Sex == 0 ? false : true,
                                MedicalID = Medical,
                               // InsuranceName = "طب صنعتی",
                            };
                            var dlg = new dlgAdmisionHCIS();
                            dlg.EditingPerson = HCISPerson;
                            dlg.Code = HCISPerson.NationalCode;
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                HCISPerson = dlg.EditingPerson;
                              //  dc.Persons.InsertOnSubmit(HCISPerson);
                            }
                            else
                            {
                                MessageBox.Show("ثبت توسط کاربر لغو شد");
                                return;
                            }
                          
                        }
                    }
                }
                if (OmoPrs == null)
                {
                    OmoPrs = new OMOApp.Data.Person()
                    {
                        Address = txtAdress.Text,
                        CreationDate = today,
                        CreationTime = now,
                        CreatorUserID = MainModule.UserID,
                        CreatorUserFullName = MainModule.UserFullName,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        FatherName = txtFather.Text,
                        BirthDate = txtBirth.Text + "",
                        NationalCode = txtCodemeli.Text,
                        PhoneNumber = txttel.Text,
                     //   Sex = JamiatPrs.Sex == 0 ? false : true,
                        MedicalID = Medical,
                        

                    };
                    if (txtPersonalCode.Text.Trim() != "")
                        OmoPrs.PersonalNo = Int32.Parse(txtPersonalCode.Text);
                     
                    if (slkManagment.EditValue != null)
                        OmoPrs. IDManagement = int.Parse(slkManagment.EditValue.ToString());

                    if (slkCompany.EditValue != null)
                        OmoPrs.IDCompany = int.Parse(slkCompany.EditValue.ToString());
                    if (slkSubCompany.EditValue != null)
                        OmoPrs.IDSubCompany = int.Parse(slkSubCompany.EditValue.ToString());

                    if (slkUnit.EditValue != null)
                        OmoPrs.IDunit = int.Parse(slkUnit.EditValue.ToString());
                     //if (JamiatPrs != null)
                    //if (JamiatPrs != null)
                    //   OmoPrs. PersonIDJamiat = JamiatPrs.IDPerson;
                    if (pictureEdit1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                            objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            // PersonalPicturePic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            OmoPrs.Photo = binary;
                        }
                    }

                    dco.Persons.InsertOnSubmit(OmoPrs);
                }


                var cmp = slkIntroductionCompany.EditValue as OMOApp.Data.Tbl_Company;

                Visit visit = new Visit()
                {
                    Person = OmoPrs,
                    AdmitDate = dtpAdmitDate.Text,
                    Admitted = true,
                    AdmittedUserID = MainModule.UserID,
                    AdmitTime = DateTime.Now.ToString("HH:mm"),
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    CreatorUserID = MainModule.UserID,
                    IntroductionCode = txtIntroductionNumber.Text,
                    Definition = dco.Definitions.FirstOrDefault(x => x.ID == (lkpNoeMoayene.EditValue as int?)),
                    IntroductionDate = dtpIntroductionDate.Date,
                    IntroductionCompanyID = cmp == null ? (null as int?) : cmp.id
                };

                if (slkManagment.EditValue != null)
                    visit.IDManagment = int.Parse(slkManagment.EditValue.ToString());

                if (slkCompany.EditValue != null)
                    visit.IDCompany = int.Parse(slkCompany.EditValue.ToString());
                if (slkSubCompany.EditValue != null)
                    visit.IDSubCompany = int.Parse(slkSubCompany.EditValue.ToString());

                if (slkUnit.EditValue != null)
                    visit.IDUnit = int.Parse(slkUnit.EditValue.ToString());

                if (slkManagment.EditValue != null)
                    OmoPrs.IDManagement = int.Parse(slkManagment.EditValue.ToString());

                if (slkCompany.EditValue != null)
                    OmoPrs.IDCompany = int.Parse(slkCompany.EditValue.ToString());
                if (slkSubCompany.EditValue != null)
                    OmoPrs.IDSubCompany = int.Parse(slkSubCompany.EditValue.ToString());

                if (slkUnit.EditValue != null)
                    OmoPrs.IDunit = int.Parse(slkUnit.EditValue.ToString());

                dco.Visits.InsertOnSubmit(visit);
                var tdl = new ToDoList();
                tdl.Visit = visit;
                dco.ToDoLists.InsertOnSubmit(tdl);
                dco.SubmitChanges();
                dc.SubmitChanges();
                visitBindingSource.DataSource = dco.Visits.Where(c => c.PersonID == OmoPrs.ID).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
                Classes.MainModule.VST_Set = visit;

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }

            catch (Exception ex) { }

        }
        private void frmAdmit_Load(object sender, EventArgs e)
        {
            definitionBindingSource1.DataSource = dco.Definitions.Where(c => c.ParentID == 1).ToList();
            tblCompanyBindingSource.DataSource = dcJ.Tbl_Companies.OrderBy(x => x.Name).ToList();
            manageMentBindingSource.DataSource = dco.ManageMents.OrderBy(x => x.Name).ToList();

            companyBindingSource.DataSource = dco.Companies.OrderBy(x => x.Name).ToList();
            subCompanyBindingSource.DataSource = dco.SubCompanies.OrderBy(x => x.Name).ToList();
            unitBindingSource.DataSource = dco.Units.OrderBy(x => x.Name).ToList();

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtPersonalCode.Text = "";
            EmptyForm();
            visitBindingSource.Clear();
        }


        private void EmptyForm()
        {
            txtFirstName.Text = "";
            txtAdress.Text = "";
            txtBirth.Text = "";
            txtFather.Text = "";
            slkManagment.EditValue = null;
            slkCompany.EditValue = null;
            slkSubCompany.EditValue = null;
            slkUnit.EditValue = null;
            lkpNoeMoayene.EditValue = null;
            slkIntroductionCompany.EditValue = null;
            txtIntroductionNumber.Text = "";
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            dtpIntroductionDate.Date = today;
            dtpAdmitDate.Date = today;
            pictureEdit1.Image = null;
            OmoPrs = null;
            JamiatPrs = null;
        }

        private void spinEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                lkpNoeMoayene.Select();
            }
        }
        

        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtCodemeli.Text))
                {
                    MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                //for test
                var text = txtCodemeli.Text.Trim();
                var dlgSrch = new Dialogs.dlgPersonSearch() { GivenNationalCode = text };
                dlgSrch.ShowDialog();
                return;

                long id = -1;

                bool valid = long.TryParse(txtCodemeli.Text.Trim(), out id);
                if (id == -1 || !valid)
                {
                    MessageBox.Show("کد ملی معتبر نمیباشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                EmptyForm();
                OmoPrs = dco.Persons.Where(c => c.NationalCode == txtCodemeli.Text).FirstOrDefault();
                if (OmoPrs == null)
                {
                    JamiatPrs = dcJ.PersonTbls.Where(c => c.NationalCode == txtCodemeli.Text && c.RelationOrderNo == 0).FirstOrDefault();
                    if (JamiatPrs == null)
                    {
                        MessageBox.Show("فردی با کد شناسایی وارد شده یافت نشد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        if (MainModule.ConnectToHcis == true)
                        #region Use HCIS
                        {


                            var dlg = new dlgAdmisionHCIS();
                            dlg.Code = txtCodemeli.Text;
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                HCISPerson = dlg.EditingPerson;
                                if (HCISPerson == null || HCISPerson.Photo == null)
                                {
                                    pictureEdit1.EditValue = null;
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        var data = HCISPerson.Photo.ToArray();
                                        ms.Write(data, 0, data.Length);
                                        ms.Flush();
                                        pictureEdit1.EditValue = Image.FromStream(ms);
                                    }
                                }

                                txtFirstName.Text = HCISPerson.FirstName;
                                txtLastName.Text= HCISPerson.LastName;
                                txtAdress.Text = HCISPerson.Address;
                                txtBirth.Text = HCISPerson.BirthDate + "";
                                txtFather.Text = HCISPerson.FatherName;

                            }
                            else
                                return;
                        }

                        #endregion
                        else
                        #region Not Use Hcis
                        {
                            var dlg = new dlgAdmisionOMO();
                            dlg.codeMeli = txtCodemeli.Text;
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                OmoPrs = dlg.OmoPrs;
                                if (OmoPrs == null || OmoPrs.Photo == null)
                                {
                                    pictureEdit1.EditValue = null;
                                }
                                else
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        var data = HCISPerson.Photo.ToArray();
                                        ms.Write(data, 0, data.Length);
                                        ms.Flush();
                                        pictureEdit1.EditValue = Image.FromStream(ms);
                                    }
                                }

                                txtFirstName.Text = OmoPrs.FirstName;
                                txtLastName.Text = OmoPrs.LastName;
                                txtAdress.Text = OmoPrs.Address;
                                txtBirth.Text = OmoPrs.BirthDate + "";
                                txtFather.Text = OmoPrs.FatherName;
                                GetEmployeeInfoOMO(OmoPrs.ID);

                            }
                            else
                                return;
                        }
                        #endregion
                    }
                    else
                    {
                        var MPH = dcJ.MemberPhotos.Where(c => c.IDPerson == JamiatPrs.IDPerson).FirstOrDefault();
                        if (MPH == null || MPH.Photo == null)
                        {
                            pictureEdit1.EditValue = null;
                        }
                        else
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                var data = MPH.Photo.ToArray();
                                ms.Write(data, 0, data.Length);
                                ms.Flush();
                                pictureEdit1.EditValue = Image.FromStream(ms);
                            }
                        }
                        txtPersonalCode.Text = JamiatPrs.PersonnelNo.ToString();
                        txtFirstName.Text = JamiatPrs.Firstname;
                        txtLastName.Text = JamiatPrs.Lastname;
                        txtAdress.Text = JamiatPrs.HomeAddress;
                        txtBirth.Text = JamiatPrs.BirthDate + "";
                        txtFather.Text = JamiatPrs.FatherName;

                        /// eslah shavad
                        var cmp = dco.View_Jamiat_Person_Companies.FirstOrDefault(x => x.IDPerson == JamiatPrs.IDPerson);
                        if (cmp == null)
                        {
                            slkManagment.EditValue = null;
                            slkCompany.EditValue = null;
                            slkSubCompany.EditValue = null;
                            slkUnit.EditValue = null;
                        }
                        else
                        {
                            slkManagment.EditValue = cmp.IDManagement;
                            slkCompany.EditValue = cmp.IDCompany;
                            slkSubCompany.EditValue = cmp.IDSubCompany;
                            slkUnit.EditValue = cmp.IDUnit;
                        }
                    }
                }

                else
                {
                    txtFirstName.Text = OmoPrs.FirstName;
                    txtLastName.Text = OmoPrs.LastName;
                    txtAdress.Text = OmoPrs.Address;
                    txtBirth.Text = OmoPrs.BirthDate + "";
                    txtFather.Text = OmoPrs.FatherName;
                    GetEmployeeInfoOMO(OmoPrs.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (OmoPrs == null)
            {
                visitBindingSource.DataSource = null;
            }
            else
            {
                visitBindingSource.DataSource = dco.Visits.Where(c => c.PersonID == OmoPrs.ID).OrderByDescending(c => c.AdmitDate).ToList();
            }
        }

       

        private void slkManagment_EditValueChanged(object sender, EventArgs e)
        {
            if (slkManagment.EditValue != null)
                companyBindingSource.DataSource = dco.Companies.Where(c => c.IDMg == Int32.Parse(slkManagment.EditValue.ToString())).ToList();

        }
        private void slkCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (slkCompany.EditValue != null)
                subCompanyBindingSource.DataSource = dco.SubCompanies.Where(c => c.IDCo == Int32.Parse(slkCompany.EditValue.ToString()) && c.IDMg == Int32.Parse(slkManagment.EditValue.ToString())).ToList();

        }

        private void slkSubCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (slkSubCompany.EditValue != null)
                unitBindingSource.DataSource = dco.Units.Where(c => c.IDMg == Int32.Parse(slkCompany.EditValue.ToString()) && c.IDOrgan == Int32.Parse(slkSubCompany.EditValue.ToString())).ToList();

        }

        private void slkUnit_EditValueChanged(object sender, EventArgs e)
        { }
    }
}