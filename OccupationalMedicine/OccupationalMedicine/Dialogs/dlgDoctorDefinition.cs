using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Data;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgDoctorDefinition : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext dc { get; set; }
        public Doctor ObjectDoc;
        public bool isEdit = false;

        public dlgDoctorDefinition()
        {
            InitializeComponent();
        }

        private void dlgDoctorDefinition_Load(object sender, EventArgs e)
        {
            if(ObjectDoc == null)
            {
                ObjectDoc = new Doctor();
            }
            if (isEdit)
            {
                Pic.Image = MainModule.GetImageFromBinary(ObjectDoc.DoctorPicture);
            }
            DoctorBindingSource.DataSource = ObjectDoc;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDoc.Text))
                {
                    MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                ObjectDoc.DoctorPicture = MainModule.GetBinaryFromImage(Pic.Image);

                if (!dc.Doctors.Any(x => x.ID == ObjectDoc.ID))
                {
                    dc.Doctors.InsertOnSubmit(ObjectDoc);
                }

                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}