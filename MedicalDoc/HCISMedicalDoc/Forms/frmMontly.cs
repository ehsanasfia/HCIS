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
    public partial class frmMontly : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
       List<Spu_MontlyCompanyResult> lst = new List<Spu_MontlyCompanyResult>();
        public frmMontly()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMontly_Load(object sender, EventArgs e)
        {
            spinEdit1.Text = "1397";
            vwcompaniBindingSource.DataSource = dc.vwcompanis.ToList();
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

            lst = dc.Spu_MontlyCompany(pid,temp).ToList();
           spuMontlyCompanyResultBindingSource.DataSource = lst;


        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
//            var q = from u in lst

//                    select new
//                    {
//                        comboBoxEdit1.Text,
//                        spinEdit1.Value,
//                        u.Date,
//                        u.TTriajLevell1,
//                        u.TTriajLevell2,
//                        u.TTriajLevell3,
//                        u.TTriajLevell4,
//                        u.TTriajLevell5,
//                        u.TTriajLevellNULL
//,
//                        u.bastarikol
//,
//                        u.BastraiSherkati
//,
//                        u.bazneshaste
//,
//                        u.GheyreSherkati
//,
//                        u.bastarikol115
//,
//                        u.BastraiSherkati115
//,
//                        u.bazneshaste115
//,
//                        u.GheyreSherkati115
//                    };
//            stiReport1.RegData("Drugs", q.ToList());
//            stiReport1.Compile();
//            stiReport1.CompiledReport.ShowWithRibbonGUI();
//            //  stiReport1.ShowWithRibbonGUI();
//            //  stiReport1.Design();
        }
    }
}