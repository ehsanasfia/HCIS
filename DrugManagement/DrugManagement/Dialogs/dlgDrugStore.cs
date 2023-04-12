using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgDrugStore : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        List<Pharmacy> lst = new List<Pharmacy>();
      //  List<RequestD> lst = new List<RequestD>();
        public Department ObjectD {get; set; }
        public Pharmacy PH { get; set; }
        public bool isEdit { get; set; }
        public dlgDrugStore()
        {
            InitializeComponent();
        }

        private void dlgDrugStore_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            if (PH == null)
            {
                PH = new Pharmacy();
            }
            if (isEdit == true)
            {

                try
                {
                    txtName.Text = ObjectD.Name;
                    lkpTechnicalID.EditValue = PH.TechnicalID;
                    txtHIX.Text = PH.HIXCode;
                    txtPharmacyCode.Text = PH.PharmacyCode;
                    txtPostalCode.Text = PH.PostalCode;
                    mmdAdreess.Text = PH.Adreess;
                    checkEdit1.EditValue = PH.InWard;
                    checkEditPhStore.EditValue = PH.PharmacyStore;
                    lkpTechnicalID.EditValue = PH.Staff;
                    checkEditPharmcyM.EditValue = PH.OtherPharmacy;
                }
                catch
                {

                }
            }

            //if (ObjectD == null)
            //{
            //    ObjectD = new Department();
            //}
            if (lst.Any(c => c.TechnicalID == PH.TechnicalID)) { MessageBox.Show("داروخانه ای با نام این مسئول قبلا ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "داروخانه" ).ToList();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (isEdit == true)
            {
           //   ObjectD.TypeID = 12;
                ObjectD.Name = txtName.Text;
                PH.PharmacyCode = txtPharmacyCode.Text;
                PH.HIXCode = txtHIX.Text;
                PH.PostalCode = txtPostalCode.Text;
                PH.Staff = (lkpTechnicalID.EditValue as Staff);
                PH.Adreess = mmdAdreess.Text;
                PH.InWard = checkEdit1.Checked;
                PH.PharmacyStore = checkEditPhStore.Checked;
                ObjectD.Pharmacy = PH;
                PH.OtherPharmacy = checkEditPharmcyM.Checked;

                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            if (isEdit == false)
            {
                if (ObjectD == null)
                {
                    ObjectD = new Department();
                }
                ObjectD.TypeID = 12;
                ObjectD.Name = txtName.Text;
                Pharmacy u = new Pharmacy();
                u.PharmacyCode = txtPharmacyCode.Text;
                u.HIXCode = txtHIX.Text;
                u.PostalCode = txtPostalCode.Text;
                u.Staff = (lkpTechnicalID.EditValue as Staff);
                u.Adreess = mmdAdreess.Text;
                u.InWard = checkEdit1.Checked;
                u.PharmacyStore = checkEditPhStore.Checked;
                u.OtherPharmacy = checkEditPharmcyM.Checked;
                ObjectD.Pharmacy = u;
                dc.Departments.InsertOnSubmit(ObjectD);
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var a = new Forms.frmUser();
            a.Show();
        }
    }
}