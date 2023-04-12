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
using HCISSecretary.Data;
using System.IO;
using SecurityLoginsAndAccessControl;
using HCISSecretary.Classes;
using HCISSpecialist.Forms;

namespace HCISSecretary.Dialogs
{
    public partial class dlgDoctorDefinition : DevExpress.XtraEditors.XtraForm
    {
        
        public HCISDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Staff doctor { get; set; }
        public string parentName { get; set; }
        public dlgDoctorDefinition()
        {
            InitializeComponent();
        }

        private void dlgDoctorDefinition_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 5);
            specialityBindingSource.DataSource = dc.Specialities;
            if (isEdit == true)
            {
                txtFname.Text = doctor.Person.FirstName;
                txtLname.Text = doctor.Person.LastName;
                txtFatherName.Text = doctor.Person.FatherName;
                txtNationalCode.Text = doctor.Person.NationalCode;
                txtPhone.Text = doctor.Person.Phone;
                txtSS.Text = doctor.Person.IdentityNumber;
                dateBirthDay.Text = doctor.Person.BirthDate;
                
                if (doctor.Person.Sex == true)
                    radioGender.SelectedIndex = 1;
                else
                    radioGender.SelectedIndex = 0;

                if (doctor.Person.MaritalStatus == "مجرد")
                    radiomarige.SelectedIndex = 0;
                else
                    radiomarige.SelectedIndex = 1;

                txtDocCode.Text = doctor.MedicalSystemCode;
                lkpExperties.EditValue = doctor.Speciality;
                txtDegree.EditValue = doctor.SpecialityDegree;
                if (doctor.Person.Photo != null)
                {

                    using (MemoryStream ms = new MemoryStream())
                    {
                        var data = doctor.Person.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pictureEdit1.Image = Image.FromStream(ms);
                    }
                }
                else
                    pictureEdit1.Image = null;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (isEdit == false)
            {
                try
                {
                    if (txtFname.Text == "" && txtLname.Text == "" && txtNationalCode.Text == "" && txtDocCode.Text == "")
                    {
                        MessageBox.Show("لطفا اطلاعات را کامل وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (txtFname.Text == "" || txtLname.Text == "")
                    {
                        MessageBox.Show("لطفا نام و نام خانوادگي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (txtNationalCode.Text == "")
                    {
                        MessageBox.Show("لطفا کد ملي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (txtDocCode.Text == "")
                    {
                        MessageBox.Show("لطفا کد نظام پزشکي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    bool b;
                    if (radioGender.SelectedIndex == 0)
                        b = false;
                    else
                        b = true;

                    string c;
                    if (radiomarige.SelectedIndex == 0)
                        c = "مجرد";
                    else
                        c = "متاهل";

                    var a = new Person()
                    {
                        FirstName = txtFname.Text,
                        LastName = txtLname.Text,
                        BirthDate = dateBirthDay.Text,
                        FatherName = txtFatherName.Text,
                        NationalCode = txtNationalCode.Text,
                        Phone = txtPhone.Text,
                        IdentityNumber = txtSS.Text,
                        Sex = b,
                        MaritalStatus = c,
                    };
                    if (pictureEdit1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            a.Photo = binary;
                        }
                    }
                    else
                        a.Photo = null;
                    dc.Persons.InsertOnSubmit(a);
                    var m = dc.GetChangeSet();
                    dc.SubmitChanges();
                    var stf = new Staff()
                    {
                        Person = a,
                        MedicalSystemCode = txtDocCode.Text,
                        SpecialityDegree = txtDegree.EditValue as string,
                        Speciality = lkpExperties.EditValue as Speciality,
                        UserType = "دکتر"
                    };
                    dc.Staffs.InsertOnSubmit(stf);
                    dc.SubmitChanges();
                    if ((lkpExperties.EditValue as Speciality).Speciality1 == "دندانپزشکی")
                    {
                        var main = new HCISDentist.Forms.frmMain();
                        var f = new frmManageUsers(MainModule.UserName, main.Name, main.ribbonControl1, "HCISDentist");
                        f.btnNewUser_Click(null, null);
                        HCISSecretary.Data.SecDataContext sequrity = new SecDataContext();
                        var app = sequrity.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISDentist");
                        var user = sequrity.tblUsers.FirstOrDefault(x => x.UserName == f.UserName && x.ApplicationID == app.ApplicationID);
                        stf.UserID = user.UserID;
                        dc.SubmitChanges();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        var main = new HCISSpecialist.Forms.frmMain();
                        var f = new frmManageUsers(MainModule.UserName, main.Name, main.ribbonControl1, "HCISSpecialist");
                        f.btnNewUser_Click(null, null);
                        HCISSecretary.Data.SecDataContext sequrity = new SecDataContext();
                        var app = sequrity.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISSpecialist");
                        var user = sequrity.tblUsers.FirstOrDefault(x => x.UserName == f.UserName && x.ApplicationID == app.ApplicationID);
                        stf.UserID = user.UserID;
                        dc.SubmitChanges();
                        DialogResult = DialogResult.OK;
                    }
                    //txtDegree.Text = txtDocCode.Text = txtFatherName.Text = txtFname.Text = txtLname.Text = txtNationalCode.Text = txtPhone.Text = txtSS.Text = null;
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                if (txtFname.Text == "" && txtLname.Text == "" && txtNationalCode.Text == "" && txtDocCode.Text == "")
                {
                    MessageBox.Show("لطفا اطلاعات را کامل وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (txtFname.Text == "" || txtLname.Text == "")
                {
                    MessageBox.Show("لطفا نام و نام خانوادگي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (txtNationalCode.Text == "")
                {
                    MessageBox.Show("لطفا کد ملي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (txtDocCode.Text == "")
                {
                    MessageBox.Show("لطفا کد نظام پزشکي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                doctor.Person.FirstName = txtFname.Text;
                doctor.Person.LastName = txtLname.Text;
                doctor.Person.FatherName = txtFatherName.Text;
                doctor.Person.NationalCode = txtNationalCode.Text;
                doctor.Person.Phone = txtPhone.Text;
                doctor.Person.IdentityNumber = txtSS.Text;
                doctor.Person.BirthDate = dateBirthDay.Text;
                if (radioGender.SelectedIndex == 0)
                    doctor.Person.Sex = false;
                else
                    doctor.Person.Sex = true;

                if (radiomarige.SelectedIndex == 0)
                    doctor.Person.MaritalStatus = "مجرد";
                else
                    doctor.Person.MaritalStatus = "متاهل";

                doctor.MedicalSystemCode = txtDocCode.Text;
                doctor.Speciality = lkpExperties.EditValue as Speciality;
                doctor.SpecialityDegree = txtDegree.EditValue as string;
                if (pictureEdit1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        doctor.Person.Photo = binary;
                    }
                }
                else
                    doctor.Person.Photo = null;
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
                
            }

        }

        private void pictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (pictureEdit1.Image == null)
            {
                pictureEdit1.LoadImage();
                return;
            }
            var a = new dlgShowPicture();
            a.image = pictureEdit1.Image;
            a.WindowState = FormWindowState.Maximized;
            a.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
