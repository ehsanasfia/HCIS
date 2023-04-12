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
namespace HCISMedicalDoc.Dialogs
{
    public partial class frmMP : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public frmMP()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMP_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.Parent == Guid.Parse("07a7b228-4835-48e7-8af0-35ed02c627f3")).OrderBy(c => c.IDInt).ToList();
            departmentBindingSource2.DataSource = dc.Departments.Where(c => c.Parent == Guid.Parse("d070091d-fab4-4676-b390-c3b69dcd32ef")).OrderBy(c => c.IDInt).ToList();
            departmentBindingSource4.DataSource = dc.Departments.Where(c => c.Parent == Guid.Parse("ee11b204-2606-436b-ac3b-7e57551d3267")).OrderBy(c => c.IDInt).ToList();
            profileAgreementBindingSource.DataSource = dc.ProfileAgreements.Where(c => c.Type == true).OrderByDescending(c => c.IDint).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lkptypeActivityID.EditValue == null)
            {
                MessageBox.Show("نوع فعالیت را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpCityInAreaID.EditValue == null)
            {
                MessageBox.Show("شهر در منطقه درمانی مششخص نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpCity.EditValue == null)
            {
                MessageBox.Show("نام شهرستان را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ProfileAgreement u = new ProfileAgreement();
            u.Name = txtName.Text;
            u.Description = mmdDescription.Text;
            u.Interfacetel = txtTell.Text;
            u.Interfacelastname = txtInterfacelastname.Text;
            u.Interfacename = txtInterfacename.Text;
            u.RegionalMunicipality = txtRegionalMunicipality.Text;
            u.thepart = txtthepart.Text;
            u.Village = txtVillage.Text;
            u.CodePosti = txtCodePosti.Text;
            u.Tell = txtTell.Text;
            u.Address = mmdAdress.Text;
            u.untiloclock = txtuntiloclock.Text;
            u.activityoclock = txtactivityoclock.Text;
            u.AmountFlat = txtAmountFlat.Text;
            u.Activebed = txtActivebed.Text;
            u.CityID = (lkpCity.EditValue as Department).ID;
            u.CityInAreaID = (lkpCityInAreaID.EditValue as Department).ID;
            u.typeActivityID = (lkptypeActivityID.EditValue as Department).ID;
            u.Type = true;
            dc.ProfileAgreements.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            profileAgreementBindingSource.DataSource = dc.ProfileAgreements.Where(c=> c.Type == true).OrderByDescending(c => c.IDint).ToList();
            txtName.Text = "";
           mmdDescription.Text = "";
            txtTell.Text = "";
            txtInterfacelastname.Text = "";
            txtInterfacename.Text = "";
            txtRegionalMunicipality.Text = "";
            txtthepart.Text = "";
            txtVillage.Text = "";
            txtCodePosti.Text = "";
            txtTell.Text = "";
            mmdAdress.Text = "";
            txtuntiloclock.Text = "";
            txtactivityoclock.Text = "";
            txtAmountFlat.Text = "";
            txtActivebed.Text = "";
            lkpCity.EditValue = "";
            lkpCityInAreaID.EditValue = "";
            lkptypeActivityID.EditValue = "";
        }

        private void lookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {
            var dep = lookUpEdit5.EditValue as Department;
            if (dep == null)
            {
                departmentBindingSource1.DataSource = null;
                return;
            }
            departmentBindingSource1.DataSource = dc.Departments.Where(c => c.Parent == dep.ID).OrderBy(c => c.IDInt).ToList();

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var dep = lookUpEdit1.EditValue as Department;
            if (dep == null)
            {
                departmentBindingSource3.DataSource = null;
                return;
            }
            departmentBindingSource3.DataSource = dc.Departments.Where(c => c.Parent == dep.ID).OrderBy(c => c.IDInt).ToList();

        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            var dep = lookUpEdit3.EditValue as Department;
            if (dep == null)
            {
                departmentBindingSource5.DataSource = null;
                return;
            }
            departmentBindingSource5.DataSource = dc.Departments.Where(c => c.Parent == dep.ID).OrderBy(c => c.IDInt).ToList();

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtName.Text = "";
            mmdDescription.Text = "";
            txtTell.Text = "";
            txtInterfacelastname.Text = "";
            txtInterfacename.Text = "";
            txtRegionalMunicipality.Text = "";
            txtthepart.Text = "";
            txtVillage.Text = "";
            txtCodePosti.Text = "";
            txtTell.Text = "";
            mmdAdress.Text = "";
            txtuntiloclock.Text = "";
            txtactivityoclock.Text = "";
            txtAmountFlat.Text = "";
            txtActivebed.Text = "";
            lkpCity.EditValue = "";
            lkpCityInAreaID.EditValue = "";
            lkptypeActivityID.EditValue = "";
        }
    }
}