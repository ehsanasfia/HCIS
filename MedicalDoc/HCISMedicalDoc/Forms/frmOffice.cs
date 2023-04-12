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
namespace HCISMedicalDoc.Forms
{
    public partial class frmOffice : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmOffice()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ProfileMatabha u = new ProfileMatabha();
            u.Fname = txtName.Text;
            u.Lname = txtLastName.Text;
            u.FatherName = txtFatherName.Text;
            u.Sex = comboBoxEdit1.Text;
            u.Codemeli = txtNationalCode.Text;
            u.Birthday = txtBirthday.Text;
            u.TypeStaff = (lkpType.EditValue as TypeStaff);
            u.ShomareNezam = txtShNezam.Text;
            u.Line = (lkpReshte.EditValue as Line);
            u.Floship = (lkpFloship.EditValue as Floship);
            u.BordTakhasosi = checkEdit1Bord.Checked;
            u.Univercity = NameUnivercity.Text;
            u.DateGet = txtDateGet.Text;
            u.BackgroundWork = txtWorkExperience.Text;
            u.Tel = txtTell.Text;
            u.Description = mmddescrption.Text;
            dc.ProfileMatabhas.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            profileMatabhaBindingSource.DataSource = dc.ProfileMatabhas/*.OrderByDescending(c => c.IDint)*/.ToList();
            txtName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            comboBoxEdit1.Text = "";
            txtNationalCode.Text = "";
            txtBirthday.Text = "";
            lkpType.EditValue = "";
            txtShNezam.Text = "";
            lkpReshte.EditValue = "";
            lkpFloship.EditValue = "";
            checkEdit1Bord.Checked = false;
            NameUnivercity.Text = "";
            txtDateGet.Text = "";
            txtWorkExperience.Text = "";
            txtTell.Text = "";
            mmddescrption.Text = "";

        }

        private void frmOffice_Load(object sender, EventArgs e)
        {
            typeStaffBindingSource.DataSource = dc.TypeStaffs.ToList();
            lineBindingSource.DataSource = dc.Lines.ToList();
            floshipBindingSource.DataSource = dc.Floships.ToList();
            profileMatabhaBindingSource.DataSource = dc.ProfileMatabhas/*.OrderByDescending(c => c.IDint)*/.ToList();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            comboBoxEdit1.Text = "";
            txtNationalCode.Text = "";
            txtBirthday.Text = "";
            lkpType.EditValue = "";
            txtShNezam.Text = "";
            lkpReshte.EditValue = "";
            lkpFloship.EditValue = "";
            checkEdit1Bord.Checked = false;
            NameUnivercity.Text = "";
            txtDateGet.Text = "";
            txtWorkExperience.Text = "";
            txtTell.Text = "";
            mmddescrption.Text = "";
        }
    }
}