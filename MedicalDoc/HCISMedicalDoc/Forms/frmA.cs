using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISMedicalDoc.Data;
using System.IO;
using DevExpress.XtraEditors.DXErrorProvider;
using HCISMedicalDoc.Classes;
namespace HCISMedicalDoc.Forms
{
    public partial class frmA : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        OccupationalMedicineOilDataContexDataContext bank = new OccupationalMedicineOilDataContexDataContext();
        private Guid ttempIDPErson;

        public PersonTbl PT { get; set; }
        public MemberPhoto MPH { get; set; }
        public Person P { get; set; }
        public string PCode { get; set; }
        public string NationalCode { get; set; }
        public string nameCompa;
        public string subcompa;
        public string sazemanfarieN;
        public string SharkatfarieN;
        public int sucomID;
        public int comid;

        public frmA()
        {
            InitializeComponent();
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (spinEdit1.Text == "")
                {
                    MessageBox.Show("کد پرسنلی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (spinEdit1.Text == "")
                {
                    return;
                }

                var dlg = new frmALL();
                dlg.Text = "انتخاب بیمار";
                dlg.PCode = spinEdit1.Text;

                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    ttempIDPErson = dlg.tempIDPErson;
                    nameCompa = dlg.NameCompany;
                    subcompa = dlg.NameSubCompan;
                    sazemanfarieN = dlg.sazemanfarieNA;
                    SharkatfarieN = dlg.SharkatfarieNA;
                    sucomID = dlg.tempIDSUBCo;
                    comid = dlg.tempIDCO;
                }
                PT = dc.PersonTbls.Where(c => c.IDPerson == ttempIDPErson).FirstOrDefault();
                MPH = dc.MemberPhotos.Where(c => c.IDPerson == PT.IDPerson).FirstOrDefault();
                if (MPH == null)
                {
                    pictureEdit1.EditValue = null;
                }
                txtPation.Text = PT.Firstname + "  " + PT.Lastname;
                txtAdress.Text = PT.HomeAddress;
                txtBirth.Text = PT.BirthDate + "";
                txtFather.Text = PT.FatherName;
                textEdit1.Text = subcompa;
                textEdit2.Text = nameCompa;
                txtSazemanFarie.Text = sazemanfarieN;
                txtSherkatFarie.Text = SharkatfarieN;
                try
                {
                    if (MPH != null)
                        if (MPH.Photo != null)
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                            {
                                var data = MPH.Photo.ToArray();
                                ms.Write(data, 0, data.Length);
                                ms.Flush();
                                pictureEdit1.EditValue = Image.FromStream(ms);
                            }
                        }
                        else if (MPH.Photo == null)
                        {
                            pictureEdit1.EditValue = null;
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (PT == null)
            { return; }
            P = bank.Persons.Where(c => c.IDPersonJamiat == ttempIDPErson).FirstOrDefault();
            if (P == null)
            {
                referenceFileBindingSource.DataSource = null;
            }

            referenceFileBindingSource.DataSource = bank.ReferenceFiles.Where(c => c.PersonID == P.ID).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            spinEdit1.Select();

        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lkpInsourance.EditValue == null)
            {
                MessageBox.Show("بیمه را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (spinEdit1.Text == "")
            {
                MessageBox.Show("شماره پرسنلی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (PT == null)
                return;

            if (bank.Persons.Any(c => c.IDPersonJamiat == PT.IDPerson))
            {


            }
            else if (!bank.Persons.Any(c => c.IDPersonJamiat == PT.IDPerson))
            {
                Person u = new Person();
                u.IDPersonJamiat = ttempIDPErson;
                u.FirstName = PT.Firstname;
                u.LastName = PT.Lastname;
                u.Address = PT.HomeAddress;
                u.BirthDate = PT.BirthDate + "";
                u.FatherName = PT.FatherName;
                u.IDInsurance = Int32.Parse(lkpInsourance.EditValue.ToString());
                u.Tel = txttel.Text;
                u.PersonalNo = PT.PersonnelNo;
                u.NationalCode = PT.NationalCode;
                u.SubCompany = subcompa;
                u.Company = nameCompa;
                u.sazemanfarieName = sazemanfarieN;
                u.SharkatfarieName = SharkatfarieN;
                u.IDCompany = comid;
                u.IDSubCompany = sucomID;
                u.NROrder = PT.RelationOrderNo;

                if (pictureEdit1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

                        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                    }
                }

                bank.Persons.InsertOnSubmit(u);
                bank.SubmitChanges();
            }
            P = bank.Persons.Where(c => c.IDPersonJamiat == PT.IDPerson).FirstOrDefault();
            if (textEdit3.Text == "")
            {
                if (MessageBox.Show("شماره پذیرش جدید ثبت شود؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;

            }
            if (textEdit3.Text == "")
            {
                tblAdmission ad = new tblAdmission();
                ad.CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                ad.CreationTime = DateTime.Now.ToString("HH:mm");
                ad.CreatorUserID = Classes.MainModule.UserID;
                ad.CreationUserIFullName = Classes.MainModule.UserFullName;
                bank.tblAdmissions.InsertOnSubmit(ad);
                bank.SubmitChanges();
                textEdit3.Text = ad.ID + "";
            }

            if (bank.ReferenceFiles.Any(x => x.IDAdmit == Int32.Parse(textEdit3.Text) && x.PersonID == P.ID))
            {
                MessageBox.Show("بیمار در این پذیرش ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            if (bank.ReferenceFiles.Any(x => x.CreationDate == today && x.PersonID == P.ID))
            {
                if (MessageBox.Show("این بیمار امروز پذیرش شده است آیا از ثبت اطمینان دارید", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }

            ReferenceFile m = new ReferenceFile();
            m.PersonID = P.ID;
            m.IDAdmit = Int32.Parse(textEdit3.Text);
            m.IDInsurance = Int32.Parse(lkpInsourance.EditValue.ToString());
            m.IDCompany = comid;
            m.IDSubCompany = sucomID;
            m.CreationTime = DateTime.Now.ToString("HH:mm");
            m.CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            m.DepartmanAdmitID = MainModule.MyDepartment.ID;
            m.CreatorUserID = Classes.MainModule.UserID;
            m.CreatorUserFullName = Classes.MainModule.UserFullName;
            bank.ReferenceFiles.InsertOnSubmit(m);
            bank.SubmitChanges();
            referenceFileBindingSource.DataSource = bank.ReferenceFiles.Where(c => c.PersonID == P.ID).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
            spinEdit1.Select();
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            spinEdit1.Text = "";
            txtPation.Text = "";
            txtAdress.Text = "";
            txtBirth.Text = "";
            txtFather.Text = "";
            textEdit1.Text = "";
            textEdit2.Text = "";
            txtSazemanFarie.Text = "";
            txtSherkatFarie.Text = "";
            pictureEdit1.EditValue = null;
            referenceFileBindingSource.DataSource = null;
        }

        private void frmA_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("fa-IR"));

            if (checkBox1Introduction.Checked == true)
            {
                mmdIntroduction.Enabled = true;
            }
            else
            {
                mmdIntroduction.Enabled = false;
            }


            var today = Classes.MainModule.GetPersianDate(DateTime.Now);
            if (MainModule.InstallLocation.Name == "بیمارستان")
            {
                bbiDrugSS.Caption = "واحد:" + "" + MainModule.MyDepartment.Name + "";
            }
            else
            {
                bbiDrugSS.Caption = "واحد:" + "" + MainModule.MyDepartment.Name + "";
            }

            insuranceBindingSource.DataSource = bank.Insurances.ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = referenceFileBindingSource.Current as ReferenceFile;
            if (current == null)
                return;
            Classes.MainModule.ReferenceFile_Set = current;
            var dlg = new frmREsidegi();
            dlg.Text = "رسیدگی";
            dlg.RF = current;
            dlg.ShowDialog();
        }

        private void simpleButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (spinEdit1.Text == "")
                    {
                        MessageBox.Show("کد پرسنلی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    if (spinEdit1.Text == "")
                    {
                        return;
                    }

                    var dlg = new frmALL();
                    dlg.Text = "انتخاب بیمار";
                    dlg.PCode = spinEdit1.Text;

                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {

                        ttempIDPErson = dlg.tempIDPErson;
                        nameCompa = dlg.NameCompany;
                        subcompa = dlg.NameSubCompan;

                        sazemanfarieN = dlg.sazemanfarieNA;
                        SharkatfarieN = dlg.SharkatfarieNA;

                        sucomID = dlg.tempIDSUBCo;
                        comid = dlg.tempIDCO;
                        //txtPation.Text = dlg.firstn /*+ "  " +*/ ;
                    }
                    PT = dc.PersonTbls.Where(c => c.IDPerson == ttempIDPErson).FirstOrDefault();
                    MPH = dc.MemberPhotos.Where(c => c.IDPerson == PT.IDPerson).FirstOrDefault();
                    if (MPH == null)
                    {
                        pictureEdit1.EditValue = null;
                    }
                    txtPation.Text = PT.Firstname + "  " + PT.Lastname;
                    txtAdress.Text = PT.HomeAddress;
                    txtBirth.Text = PT.BirthDate + "";
                    txtFather.Text = PT.FatherName;
                    textEdit1.Text = subcompa;
                    textEdit2.Text = nameCompa;
                    txtSazemanFarie.Text = sazemanfarieN;
                    txtSherkatFarie.Text = SharkatfarieN;
                    try
                    {
                        if (MPH.Photo != null)
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                            {
                                var data = MPH.Photo.ToArray();
                                ms.Write(data, 0, data.Length);
                                ms.Flush();
                                pictureEdit1.EditValue = Image.FromStream(ms);
                            }
                        }
                        else if (MPH.Photo == null)
                        {
                            pictureEdit1.EditValue = null;
                        }
                    }
                    catch
                    {

                    }

                }
                catch
                {

                }

                P = bank.Persons.Where(c => c.IDPersonJamiat == PT.IDPerson).FirstOrDefault();
                if (P == null)
                {
                    referenceFileBindingSource.DataSource = null;
                }
                else
                {
                    referenceFileBindingSource.DataSource = bank.ReferenceFiles.Where(c => c.IDAdmit == Int32.Parse(textEdit3.Text)).OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
                }
            }
        }

        private void spinEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                simpleButton1_Click(null, null);
            }
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblAdmission ad = new tblAdmission();
            ad.CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            ad.CreationTime = DateTime.Now.ToString("HH:mm");
            ad.CreatorUserID = Classes.MainModule.UserID;
            ad.CreationUserIFullName = Classes.MainModule.UserFullName;
            bank.tblAdmissions.InsertOnSubmit(ad);
            bank.SubmitChanges();

            textEdit3.Text = ad.ID + "";
            spinEdit1.Text = "";
            txtPation.Text = "";
            txtAdress.Text = "";
            txtBirth.Text = "";
            txtFather.Text = "";
            textEdit1.Text = "";
            textEdit2.Text = "";
            txtSazemanFarie.Text = "";
            txtSherkatFarie.Text = "";
            pictureEdit1.EditValue = null;
            referenceFileBindingSource.DataSource = null;

        }


        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }

        private void checkBox1Introduction_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1Introduction.Checked == true)
            {
                mmdIntroduction.Enabled = true;
            }
            else
            {
                mmdIntroduction.Enabled = false;
            }
        }

    }
}