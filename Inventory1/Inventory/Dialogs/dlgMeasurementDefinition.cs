using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Forms;
using Inventory.Dialogs;
namespace Inventory.Dialogs
{
    public partial class dlgMeasurementDefinition : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public MeasurementDefinition PHT { get; set; }

        public dlgMeasurementDefinition()
        {
            InitializeComponent();
        }

        private void dlgMeasurementDefinition_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                txtRegisterNumber.Text = PHT.MeasurementDefinition1 + "";
                txtMeasurementName.Text = PHT.MeasurementName;


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (isEdit == false)
            {
                PHT = new MeasurementDefinition();
            }

            PHT.MeasurementName = txtMeasurementName.Text;
            PHT.MeasurementDefinition1 = Int32.Parse(txtRegisterNumber.Text);
          
           
            if (isEdit == false)
                dc.MeasurementDefinitions.InsertOnSubmit(PHT);



            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}