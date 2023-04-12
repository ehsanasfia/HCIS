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
using HCISMedicalDoc.Classes;

namespace HCISMedicalDoc.Forms
{
    public partial class frmHistory : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<SpuCompanyHandelResult> lst = new List<SpuCompanyHandelResult>();
        public Guid NationalCode2 { get; set; }
        public frmHistory()
        {
            InitializeComponent();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
        spuHistoryResultBindingSource.DataSource = dc.SpuHistory(NationalCode2).ToList();
        }

        private void simpleButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}