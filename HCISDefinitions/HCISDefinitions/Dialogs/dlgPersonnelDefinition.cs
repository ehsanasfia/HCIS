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
using HCISDefinitions.Data;
using System.IO;
using SecurityLoginsAndAccessControl;

using HCISDefinitions.Forms;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgPersonnelDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Staff stff { get; set; }

        public dlgPersonnelDefinition()
        {
            InitializeComponent();
        }

        private void dlgPersonnelDefinition_Load(object sender, EventArgs e)
        {
            DegreeBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 5);
            SpecialityBindingSource.DataSource = dc.Specialities;
            PersonnelTypeBindingSource.DataSource = dc.Definitions.Where(x => x.Parent == 73);
            if (isEdit == true)
            {
                lkpPersonnelType.EditValue = stff.UserType;
                txtFname.Text = stff.Person.FirstName;
                txtLname.Text = stff.Person.LastName;
                txtNationalCode.Text = stff.Person.NationalCode;
                txtFatherName.Text = stff.Person.FatherName;
                txtSS.Text = stff.Person.IdentityNumber;
                dateBirthDay.Text = stff.Person.BirthDate;
                txtPhone.Text = stff.Person.Phone;
                txtDocCode.Text = stff.MedicalSystemCode;
                lkpExperties.EditValue = stff.Speciality;
                lkpDegree.EditValue = stff.SpecialityDegree;

                if (stff.Person.Sex == true)
                    radioGender.SelectedIndex = 1;
                else
                    radioGender.SelectedIndex = 0;

                if (stff.Person.MaritalStatus == "مجرد")
                    radioMarige.SelectedIndex = 0;
                else
                    radioMarige.SelectedIndex = 1;

                if (stff.Person.Photo != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var data = stff.Person.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pic.Image = Image.FromStream(ms);
                    }
                }
                else
                    pic.Image = null;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                try
                {
                    if ((lkpPersonnelType.EditValue as string) == null || lkpPersonnelType.Text == "")
                    {
                        MessageBox.Show("لطفا نوع کاربر را مشخص کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtFname.Text) && string.IsNullOrWhiteSpace(txtLname.Text) && string.IsNullOrWhiteSpace(txtNationalCode.Text))
                    {
                        MessageBox.Show("لطفا اطلاعات را کامل وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text))
                    {
                        MessageBox.Show("لطفا نام و نام خانوادگي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
                    {
                        MessageBox.Show("لطفا کد ملي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if ((lkpPersonnelType.EditValue as string) == "دکتر" && string.IsNullOrWhiteSpace(txtDocCode.Text))
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
                    if (radioMarige.SelectedIndex == 0)
                        c = "مجرد";
                    else
                        c = "متاهل";

                    var a = new Person()
                    {
                        FirstName = txtFname.Text,
                        LastName = txtLname.Text,
                        NationalCode = txtNationalCode.Text,
                        FatherName = txtFatherName.Text,
                        IdentityNumber = txtSS.Text,
                        BirthDate = dateBirthDay.Text,
                        Sex = b,
                        MaritalStatus = c,
                        Phone = txtPhone.Text
                    };
                    if (pic.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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
                        UserType = lkpPersonnelType.EditValue as string,
                        MedicalSystemCode = txtDocCode.Text,
                        Speciality = lkpExperties.EditValue as Speciality,
                        SpecialityDegree = lkpDegree.EditValue as string
                    };
                    dc.Staffs.InsertOnSubmit(stf);
                    dc.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                if ((lkpPersonnelType.EditValue as string) == null || lkpPersonnelType.Text == "")
                {
                    MessageBox.Show("لطفا نوع کاربر را مشخص کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtFname.Text) && string.IsNullOrWhiteSpace(txtLname.Text) && string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    MessageBox.Show("لطفا اطلاعات را کامل وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text))
                {
                    MessageBox.Show("لطفا نام و نام خانوادگي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
                {
                    MessageBox.Show("لطفا کد ملي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if ((lkpPersonnelType.EditValue as string) == "دکتر" && string.IsNullOrWhiteSpace(txtDocCode.Text))
                {
                    MessageBox.Show("لطفا کد نظام پزشکي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                stff.UserType = lkpPersonnelType.EditValue as string;
                stff.Person.FirstName = txtFname.Text;
                stff.Person.LastName = txtLname.Text;
                stff.Person.NationalCode = txtNationalCode.Text;
                stff.Person.FatherName = txtFatherName.Text;
                stff.Person.IdentityNumber = txtSS.Text;
                stff.Person.BirthDate = dateBirthDay.Text;
                stff.Person.Phone = txtPhone.Text;
                stff.MedicalSystemCode = txtDocCode.Text;
                stff.Speciality = lkpExperties.EditValue as Speciality;
                stff.SpecialityDegree = lkpDegree.EditValue as string;

                if (radioGender.SelectedIndex == 0)
                    stff.Person.Sex = false;
                else
                    stff.Person.Sex = true;

                if (radioMarige.SelectedIndex == 0)
                    stff.Person.MaritalStatus = "مجرد";
                else
                    stff.Person.MaritalStatus = "متاهل";

                if (pic.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        stff.Person.Photo = binary;
                    }
                }
                else
                    stff.Person.Photo = null;

                dc.SubmitChanges();
            }

            DialogResult = DialogResult.OK;
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (pic.Image == null)
            {
                pic.LoadImage();
                return;
            }
            var a = new dlgShowPicture();
            a.image = pic.Image;
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
