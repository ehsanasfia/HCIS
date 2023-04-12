using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class diagChangeDate : DevExpress.XtraEditors.XtraForm
    {
        private VwDoctorInstraction EditingVwDoctorInstraction;

        public diagChangeDate()
        {
            InitializeComponent();
        }

        public diagChangeDate(VwDoctorInstraction current)
        {
            InitializeComponent();
            this.EditingVwDoctorInstraction = current;
        }

        private void diagChangeDate_Load(object sender, EventArgs e)
        {
            textEdit1.EditValue = EditingVwDoctorInstraction.Date;
            textEdit2.EditValue = EditingVwDoctorInstraction.Time;
        }

        Data.HCISDataContext dc = new HCISDataContext();
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (textEdit1.Text.Length<10 || textEdit2.Text.Length < 5)
            {
                MessageBox.Show("لطفاً تاریخ و ساعت را درست وارد نمایید");
                return;
            }

            var gsd = dc.GivenServiceDs.FirstOrDefault(c => c.ID == EditingVwDoctorInstraction.GSDID);

            EditingVwDoctorInstraction.Date = textEdit1.EditValue.ToString();
            EditingVwDoctorInstraction.Time  = textEdit2.EditValue.ToString();
            gsd.Date = textEdit1.EditValue.ToString();
            gsd.Time = textEdit2.EditValue.ToString();
            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}