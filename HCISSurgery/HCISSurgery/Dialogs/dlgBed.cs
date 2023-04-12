using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;

namespace HCISSurgery.Dialogs
{
    public partial class dlgBed : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public Bed SelectedBed { get; set; }

        public dlgBed()
        {
            InitializeComponent();
        }

        private void dlgBed_Load(object sender, EventArgs e)
        {
            bedBindingSource.DataSource = dc.Beds.Where(x => x.Condition == "خالی" && x.Department == Classes.MainModule.MyDepartment).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var row = bedBindingSource.Current as Bed;
            if (row == null)
                return;
            SelectedBed = row;
            DialogResult = DialogResult.OK;
        }

        private void btnOKwithoutBed_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیااز پذیرش بدون تخت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            SelectedBed = null;
            DialogResult = DialogResult.OK;
        }
    }
}