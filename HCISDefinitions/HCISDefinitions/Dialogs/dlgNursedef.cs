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
using staff = HCISDefinitions.Data.Staff;
using System.IO;
using HCISDefinitions.Dialogs;

namespace HCISDefinitions.Forms
{
    public partial class dlgNursedef : DevExpress.XtraEditors.XtraForm
    {

        public dlgNursedef()
        {
            InitializeComponent();
        }
        public HCISDataClassesDataContext dc;
        public bool isEdit { get; set; }
        public staff EditingUser { get; set; }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgNurseDef_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                txtName.Text = EditingUser.Person.FirstName;
                txtFamily.Text = EditingUser.Person.LastName;
                txtNationalCode.Text = EditingUser.Person.NationalCode;
                txtCode.Text = EditingUser.Person.PersonalCode;
                txtFatherName.Text = EditingUser.Person.FatherName;
                txtSS.Text = EditingUser.Person.IdentityNumber;
                txtphoneNumber.Text = EditingUser.Person.Phone;
                txtBirthday.Text = EditingUser.Person.BirthDate;
                if (EditingUser.Person.Sex == true)
                    rdgGender.SelectedIndex = 1;
                else
                    rdgGender.SelectedIndex = 0;

                if (EditingUser.Person.MaritalStatus == "مجرد")
                    rdgMaritalStatus.SelectedIndex = 0;
                else
                    rdgMaritalStatus.SelectedIndex = 1;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit == false)
                {
                    if (txtName.Text == "" && txtFamily.Text == "" && txtNationalCode.Text == "")
                    {
                        MessageBox.Show("لطفا اطلاعات را کامل وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (txtName.Text == "" || txtFamily.Text == "")
                    {
                        MessageBox.Show("لطفا نام و نام خانوادگي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (txtNationalCode.Text == "")
                    {
                        MessageBox.Show("لطفا کد ملي را وارد کنيد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    var p = new Person
                    {
                        FirstName = txtName.Text,
                        LastName = txtFamily.Text,
                        FatherName = txtFatherName.Text,
                        BirthDate = txtBirthday.Text,
                        NationalCode = txtNationalCode.Text,
                        IdentityNumber = txtSS.Text,
                        Phone = txtphoneNumber.Text,

                    };
                    var chek = rdgGender.SelectedIndex;
                    if (chek == 0)
                    {
                        p.Sex = false;
                    }
                    else
                    {
                        p.Sex = true;
                    }
                    var check = rdgMaritalStatus.SelectedIndex;
                    if (check == 0)
                    {
                        p.MaritalStatus = "مجرد";
                    }
                    else
                    {
                        p.MaritalStatus = "متاهل";
                    }
                    if (pic.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            p.Photo = binary;
                        }
                    }
                    else
                        p.Photo = null;
                    dc.Persons.InsertOnSubmit(p);
                    dc.SubmitChanges();
                    var stf = new Staff()
                    {
                        Person = p,
                        UserType = "پرستار"
                    };
                    var main = new HCISNurse.Forms.frmMain();
                    var f = new SecurityLoginsAndAccessControl.frmManageUsers(MainModule.UserName, main.Name, main.ribbonControl1, "HCISNurse");
                    f.btnNewUser_Click(null, null);
                    HCISDefinitions.Data.SeqDataContext sequrity = new SeqDataContext();
                    var app = sequrity.tblApplications.FirstOrDefault(x => x.ApplicationName == "HCISNurse");
                    var user = sequrity.tblUsers.FirstOrDefault(x => x.UserName == f.UserName && x.ApplicationID == app.ApplicationID);
                    stf.UserID = user.UserID;
                    dc.Staffs.InsertOnSubmit(stf);
                    dc.SubmitChanges();
                    txtName.Text = "";
                    txtFamily.Text = "";
                    txtFatherName.Text = "";
                    txtNationalCode.Text = "";
                    txtphoneNumber.Text = "";
                    txtBirthday.Text = "";
                    txtCode.Text = "";
                    txtSS.Text = "";

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    EditingUser.Person.FirstName = txtName.Text;
                    EditingUser.Person.LastName = txtFamily.Text;
                    EditingUser.Person.NationalCode = txtNationalCode.Text;
                    EditingUser.Person.PersonalCode = txtCode.Text;
                    EditingUser.Person.FatherName = txtFatherName.Text;
                    EditingUser.Person.IdentityNumber = txtSS.Text;
                    EditingUser.Person.Phone = txtphoneNumber.Text;
                    EditingUser.Person.BirthDate = txtBirthday.Text;
                    var chek = rdgGender.SelectedIndex;
                    if (chek == 0)
                    {
                        EditingUser.Person.Sex = false;
                    }
                    else
                    {
                        EditingUser.Person.Sex = true;
                    }
                    var check = rdgMaritalStatus.SelectedIndex;
                    if (check == 0)
                    {
                        EditingUser.Person.MaritalStatus = "مجرد";
                    }
                    else
                    {
                        EditingUser.Person.MaritalStatus = "متاهل";
                    }
                    if (pic.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                            EditingUser.Person.Photo = binary;
                        }
                    }
                    else
                        EditingUser.Person.Photo = null;


                    dc.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}