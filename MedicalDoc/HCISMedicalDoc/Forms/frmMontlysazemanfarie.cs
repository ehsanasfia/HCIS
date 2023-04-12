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
    public partial class frmMontlysazemanfarie : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<Spu_MontlySazemanFarieResult> lst = new List<Spu_MontlySazemanFarieResult>();
        public frmMontlysazemanfarie()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMontlysazemanfarie_Load(object sender, EventArgs e)
        {
            spinEdit1.Text = "1397";
            vwSazemanFarieBindingSource.DataSource = dc.vwSazemanFaries.ToList();
        }
        private void GetData()
        {



            var pid = lookUpEdit1.Text;
            if (lookUpEdit1.Text == null)
                return;
            //  var did = comboBoxEdit2.Text;
            //if (did == null)
            //    return;
            var temp = spinEdit1.Text + "/" + comboBoxEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.Spu_MontlySazemanFarie(pid, temp).ToList();
            spuMontlySazemanFarieResultBindingSource.DataSource = lst;


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
}