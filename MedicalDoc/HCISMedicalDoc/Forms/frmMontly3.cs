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
    public partial class frmMontly3 : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        List<Spu_MontlySazemanAsliResult> lst = new List<Spu_MontlySazemanAsliResult>();
        public frmMontly3()
        {
            InitializeComponent();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmMontly3_Load(object sender, EventArgs e)
        {
            spinEdit1.Text = "1397";
            vwSazemanAsliBindingSource.DataSource = dc.vwSazemanAslis.ToList();
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

            lst = dc.Spu_MontlySazemanAsli(pid, temp).ToList();
            spuMontlySazemanAsliResultBindingSource.DataSource = lst;


        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
}