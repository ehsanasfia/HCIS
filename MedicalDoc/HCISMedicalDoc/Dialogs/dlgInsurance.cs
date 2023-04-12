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
using HCISMedicalDoc.Data;

namespace HCISMedicalDoc.Dialogs
{
    public partial class dlgInsurance : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public dlgInsurance()
        {
            InitializeComponent();
        }

        private void dlgInsurance_Load(object sender, EventArgs e)
        {
            insurancesBindingSource.DataSource = dc.Insurances;
        }
        
        private void insurancesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Insurance ins = new Insurance();
            e.NewObject = ins;
            dc.Insurances.InsertOnSubmit(ins);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            insurancesBindingSource.AddNew();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("آیا ثبت تغییرات را تایید می نمایید ؟\r\nلطفا دقت فرمایید در صورت ویرایش تمامی پرونده های متعهد ها تغییر خواهند کرد", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != System.Windows.Forms.DialogResult.Yes)
                    return;
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}