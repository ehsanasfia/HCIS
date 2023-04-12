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
using DrugManagement.Data;
using System.IO;

namespace DrugManagement.Dialogs
{
    public partial class dlgUser : DevExpress.XtraEditors.XtraForm
    {
     //   public Person EditingPerson { get; set; }
        public Staff ObjectS { get; set; }
        public HCISDataContexDataContext dc { get; set; }
        public UserDrugManagement Doc { get; set; }
        public bool isEditt { get; set; }
        public dlgUser()
        {
            InitializeComponent();
        }

        private void dlgUser_Load(object sender, EventArgs e)
        {
            GetData();
           
        }
        private void GetData()
        {
            if (ObjectS == null)
                {
                    ObjectS = new Staff();
                }
            
            txtLastName.Text = Doc.LastName;
            txtName.Text = Doc.FirstName;
            txtUserID.Text = Doc.UserID + "";
            if (isEditt == true)
            {
                var x = dc.Staffs.Where(c => c.UserID == Doc.UserID).FirstOrDefault();
                ObjectS = x;
                txtNationalCode.Text = x.Person.NationalCode;
                txtPersonalCode.Text = x.Person.PersonalCode;
                txtSpecialityDegree.Text = x.SpecialityDegree;
                txtIdentityNumber.Text = x.Person.IdentityNumber;
              //txtUserType.Text = x.UserType;
                txtBirthDay.Text = x.Person.BirthDate;
                txtPhone.Text = x.Person.Phone;
                mmdAddress.Text = x.Person.Address;
            }

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
           
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    pictureEdit1.LoadImage();
        //}

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (pictureEdit1.Image != null)
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        Bitmap objBitmap = new Bitmap(pictureEdit1.Image, 120, 120);

            //        objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //        var binary = new System.Data.Linq.Binary(ms.GetBuffer());
            //        EditingPerson.Photo = binary;
            //    }
            //}
            //else
            //    EditingPerson.Photo = null;
            // ObjectS.TypeID = 12;
            ObjectS.UserID = Int32.Parse(txtUserID.Text);
            ObjectS.SpecialityDegree = txtSpecialityDegree.Text;
            ObjectS.UserType = "داروخانه";
            Person u = new Person();
            if (isEditt == true)
                u = ObjectS.Person;
            //u.Sex = Boolean.Parse(rdbSex.Tag.ToString());
            u.NationalCode = txtNationalCode.Text;
            u.PersonalCode = txtPersonalCode.Text;
            u.FirstName = txtName.Text;
            u.LastName = txtLastName.Text;
            u.IdentityNumber = txtIdentityNumber.Text;
            u.BirthDate = txtBirthDay.Text;
            u.Phone = txtPhone.Text;
            u.Address = mmdAddress.Text;
            ObjectS.Person = u;
            if (isEditt == false)
                dc.Staffs.InsertOnSubmit(ObjectS);
            if (isEditt == true)
                dc.SubmitChanges();
            // MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}