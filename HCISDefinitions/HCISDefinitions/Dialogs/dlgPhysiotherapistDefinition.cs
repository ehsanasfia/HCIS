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

namespace HCISDefinitions.Dialogs
{
    public partial class dlgPhysiotherapistDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Staff PHT { get; set; }
        public dlgPhysiotherapistDefinition()
        {
            InitializeComponent();
        }

        private void dlgPhysiotherapistDefinition_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                txtName.Text = PHT.Person.FirstName;
                txtLastName.Text = PHT.Person.LastName;
                txtFatherName.Text = PHT.Person.FatherName;
                txtNationalCode.Text = PHT.Person.NationalCode;
                txtPhone.Text = PHT.Person.Phone;
                txtIdentityNumber.Text = PHT.Person.IdentityNumber;
                txtBirthDate.Text = PHT.Person.BirthDate;
                if (PHT.Person.Sex == true)
                    rdgSex.SelectedIndex = 1;
                else
                    rdgSex.SelectedIndex = 0;

                if (PHT.Person.MaritalStatus == "مجرد")
                    rdgMaritalStatus.SelectedIndex = 0;
                else
                    rdgMaritalStatus.SelectedIndex = 1;

                txtMedicalSystemCode.Text = PHT.MedicalSystemCode;

                if (PHT.Person.Photo != null)
                {

                    using (MemoryStream ms = new MemoryStream())
                    {
                        var data = PHT.Person.Photo.ToArray();
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
                    if (txtName.Text == "" || txtLastName.Text == "" || txtNationalCode.Text == "" || txtMedicalSystemCode.Text == "")
                    {
                        MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.");
                        return;
                    }
                    else
                    {
                        bool b;
                        if (rdgSex.SelectedIndex == 0)
                            b = false;
                        else
                            b = true;
                        string c;
                        if (rdgMaritalStatus.SelectedIndex == 0)
                            c = "مجرد";
                        else
                            c = "متاهل";

                        var a = new Person()
                        {
                            FirstName = txtName.Text,
                            LastName = txtLastName.Text,
                            BirthDate = txtBirthDate.Text,
                            FatherName = txtFatherName.Text,
                            NationalCode = txtNationalCode.Text,
                            Phone = txtPhone.Text,
                            IdentityNumber = txtIdentityNumber.Text,
                            Sex = b,
                            MaritalStatus = c,
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
                        dc.SubmitChanges();
                        var stf = new Staff()
                        {
                            Person = a,
                            MedicalSystemCode = txtMedicalSystemCode.Text,
                            UserType = "فیزیوتراپیست"
                        };

                        dc.Staffs.InsertOnSubmit(stf);
                        dc.SubmitChanges();

                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                PHT.Person.FirstName = txtName.Text;
                PHT.Person.LastName = txtLastName.Text;
                PHT.Person.FatherName = txtFatherName.Text;
                PHT.Person.NationalCode = txtNationalCode.Text;
                PHT.Person.Phone = txtPhone.Text;
                PHT.Person.IdentityNumber = txtIdentityNumber.Text;
                PHT.Person.BirthDate = txtBirthDate.Text;
                if (rdgSex.SelectedIndex == 0)
                    PHT.Person.Sex = false;
                else
                    PHT.Person.Sex = true;

                if (rdgMaritalStatus.SelectedIndex == 0)
                    PHT.Person.MaritalStatus = "مجرد";
                else
                    PHT.Person.MaritalStatus = "متاهل";

                PHT.MedicalSystemCode = txtMedicalSystemCode.Text;

                if (pic.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                        PHT.Person.Photo = binary;
                    }
                }
                else
                    PHT.Person.Photo = null;

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;

            }
        }
    }
}