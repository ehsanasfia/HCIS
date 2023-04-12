using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgOutDoctor : DevExpress.XtraEditors.XtraForm
    {
        private Person EditingPerson;
        public Guid? PersonID { get; set; }

        private HCISLabClassesDataContext dc = new HCISLabClassesDataContext();

        public dlgOutDoctor()
        {
            InitializeComponent();
        }

        private void dlgOutDoctor_Load(object sender, EventArgs e)
        {
            EditingPerson = new Person();
            PersonBindingSource.DataSource = EditingPerson;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtMed.Text))
            {
                MessageBox.Show("لطفا تمام فیلد ها را پر کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var med = txtMed.Text.Trim();

            var foundStaff = dc.Staffs.FirstOrDefault(x => x.MedicalSystemCode != null && x.MedicalSystemCode.Trim() == med);

            if (foundStaff != null)
            {
                PersonID = foundStaff.ID;
                DialogResult = DialogResult.OK;
                return;
            }

            Speciality spc = dc.Specialities.FirstOrDefault(x => x.Speciality1 == "خارج از مرکز");

            Staff stf = new Staff()
            {
                MedicalSystemCode = txtMed.Text.Trim(),
                Speciality = spc,
                UserType = "دکتر",
            };

            string str = "";
            while (true)
            {
                try
                {

                    Random rnd = new Random();
                    Int64 national = Convert.ToInt64((rnd.NextDouble() * 9999999999));
                    str = ("0000000000" + national.ToString());
                    str = str.Substring(str.Length - 10, 10);
                    if (!Dialogs.dlgNtaionalCode.IsValidNationalCode(str) && !dc.Persons.Any(c => c.NationalCode == str))
                        break;
                }
                catch (Exception)
                {
                    break;
                }
            }

            EditingPerson.NationalCode = str;
            EditingPerson.Staff = stf;

            dc.Staffs.InsertOnSubmit(stf);
            dc.Persons.InsertOnSubmit(EditingPerson);

            dc.SubmitChanges();


            PersonID = EditingPerson.ID;

            DialogResult = DialogResult.OK;
        }
    }
}