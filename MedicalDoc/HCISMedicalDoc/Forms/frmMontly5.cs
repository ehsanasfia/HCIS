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
    public partial class frmMontly5 : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<Spu_MontlyTriajLevell2Result> lst = new List<Spu_MontlyTriajLevell2Result>();
        public frmMontly5()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMontly5_Load(object sender, EventArgs e)
        {
            spinEdit1.Text = "1397";
        }
        private void GetData()
        {


            //var pid = MainModule.MyDepartment.ID;
            //if (pid == null)
            //    return;
            var did = comboBoxEdit2.Text;
            if (did == null)
                return;
            var temp = spinEdit1.Text + "/" + comboBoxEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            lst = dc.Spu_MontlyTriajLevell2(temp).ToList();
            spuMontlyTriajLevell2ResultBindingSource.DataSource = lst;


        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}