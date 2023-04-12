using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;
using HCISTriage.Dialogs;
namespace HCISTriage.Forms
{
    public partial class frmMontly2 : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<Spu_MontlyTriajLevellResult> lst = new List<Spu_MontlyTriajLevellResult>();
        public frmMontly2()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMontly2_Load(object sender, EventArgs e)
        {
            spinEdit1.Text = "1397";
        }
        private void GetData()
        {


            //var pid = MainModule.MyDepartment.ID;
            //if (pid == null)
            //    return;
            var did = comboBoxEdit1.Text;
            if (did == null)
                return;
            var temp = spinEdit1.Text + "/" + comboBoxEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.Spu_MontlyTriajLevell(temp).ToList();
            spuMontlyTriajLevellResultBindingSource.DataSource = lst;


        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var q = from u in lst

                    select new
                    {
                        comboBoxEdit1.Text,
                        spinEdit1.Value,
                        u.Date
,
                        u.bastarikol115
,
                        u.BastraiSherkati115
,
                        u.bazneshaste115
,
                        u.GheyreSherkati115
                    };
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
         //   stiReport1.Design();
        }

    }
   
}