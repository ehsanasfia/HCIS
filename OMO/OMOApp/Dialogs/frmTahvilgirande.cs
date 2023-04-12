using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.ParsiData;
using OMOApp.Classes;
namespace OMOApp.Dialogs
{
    public partial class frmTahvilgirande : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineOilDataContexDataContext dc { get; set; }
        public Introduction C { get; set; }
        public bool isEdit { get; set; }
        public frmTahvilgirande()
        {
            InitializeComponent();
        }

        private void frmTahvilgirande_Load(object sender, EventArgs e)
        {
            companyBindingSource.DataSource = dc.Companies.ToList();
            medicalCenterBindingSource.DataSource = dc.MedicalCenters.ToList();
            if (isEdit == true)
            {
                txtDoDate.Text = C.DateDo;
                txtMNumber.Text = C.Number;
                lkpcompany.EditValue = C.Company;

            }
            else
            {
                txtDoDate.Text = MainModule.GetPersianDate(DateTime.Now);
          
            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {

                C.CreatorUserFullName = Classes.MainModule.UserFullName;
                C.CreatorUserID = Classes.MainModule.UserID;
                C.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                C.CreationTime = DateTime.Now.ToString("HH:mm");
                C.Number = txtMNumber.Text;
                C.DateDo = txtDoDate.Text;
              //  C.IDMedicalCenter = Int32.Parse(lkpMedicalid.EditValue.ToString());
                C.Company = (lkpcompany.EditValue as Company);
                dc.SubmitChanges();
            }
            if (isEdit == false)
            {
                Introduction u = new Introduction();
                u.CreatorUserFullName = Classes.MainModule.UserFullName;
                u.CreatorUserID = Classes.MainModule.UserID;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationTime = DateTime.Now.ToString("HH:mm");
                u.Number = txtMNumber.Text;
                u.DateDo = txtDoDate.Text;
             //   u.IDMedicalCenter =Int32.Parse(lkpMedicalid.EditValue.ToString());
                u.Company = (lkpcompany.EditValue as Company);
                dc.Introductions.InsertOnSubmit(u);
                dc.SubmitChanges();
                MessageBox.Show(" اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            DialogResult = DialogResult.OK;
        }
    }
}