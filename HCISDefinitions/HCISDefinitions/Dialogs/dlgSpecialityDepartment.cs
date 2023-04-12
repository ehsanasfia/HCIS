using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgSpecialityDepartment : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Speciality SelectedSPL { get; set; }

        public dlgSpecialityDepartment()
        {
            InitializeComponent();
        }

        private void dlgSpecialityDepartment_Load(object sender, EventArgs e)
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = slkSpeciality.EditValue as Speciality;
                if(cur == null)
                {
                    MessageBox.Show("تخصصی انتخاب نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                SelectedSPL = cur;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}