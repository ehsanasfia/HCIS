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
namespace HCISMedicalDoc.Forms
{
    public partial class frmALL : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<spuAdmitResult> lst = new List<spuAdmitResult>();
        public string PCode { get; set; }
        public Guid tempIDPErson { get; set; }
        public int tempIDCO { get; set; }
        public int tempIDSUBCo { get; set; }
        public string firstn { get; set; }
        public string NameSubCompan { get; set; }

        public string sazemanfarieNA { get; set; }
        public string SharkatfarieNA { get; set; }

        public string NameCompany { get; set; }
        List<Person> Pe = new List<Person>();
        public frmALL()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmALL_Load(object sender, EventArgs e)
        {
            var temp = PCode;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            lst = dc.spuAdmit(temp).ToList();
            spuAdmitResultBindingSource.DataSource = lst;
            //.Where(c => (c. == PCode) || (c.NationalCode == PCode)).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var temp3 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPerson").ToString();
            var te = Guid.Parse(temp3);
            if (string.IsNullOrWhiteSpace(temp3))
                return;
            tempIDPErson = te;
             NameSubCompan = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NameSubCompan").ToString();
             NameCompany = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NameCompany").ToString();
            sazemanfarieNA = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sazemanfarie").ToString();
            SharkatfarieNA = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Sharkatfarie").ToString();
            var temp4 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCo").ToString();
            var te4 = int.Parse(temp4);
            if (string.IsNullOrWhiteSpace(temp4))
            { }
            tempIDCO = te4;
            var temp5 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idSubCompany").ToString();
            var te5 = int.Parse(temp5);
            if (string.IsNullOrWhiteSpace(temp5))
            { }
            tempIDSUBCo = te5;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var temp3 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDPerson").ToString();
                var te = Guid.Parse(temp3);
                if (string.IsNullOrWhiteSpace(temp3))
                    return;
                tempIDPErson = te;
                NameSubCompan = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NameSubCompan").ToString();
                NameCompany = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NameCompany").ToString();
                sazemanfarieNA = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sazemanfarie").ToString();
                SharkatfarieNA = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Sharkatfarie").ToString();
                var temp4 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCo").ToString();
                var te4 = int.Parse(temp4);
                if (string.IsNullOrWhiteSpace(temp4))
                { }
                tempIDCO = te4;
                var temp5 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idSubCompany").ToString();
                var te5 = int.Parse(temp5);
                if (string.IsNullOrWhiteSpace(temp5))
                { }
                tempIDSUBCo = te5;
                DialogResult = DialogResult.OK;
            }
           }

        private void simpleButton2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
       }
    }
}
