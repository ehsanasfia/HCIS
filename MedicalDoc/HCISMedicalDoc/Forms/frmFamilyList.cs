using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISMedicalDoc.Data;

namespace HCISMedicalDoc.Forms
{
    public partial class frmFamilyList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmFamilyList()
        {
            InitializeComponent();
        }
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var Family= dc.spuAdmit(txtPersonalCode.Text).ToList();
            spuAdmitResultBindingSource.DataSource = Family;
            if (Family.Count()==0)
            { 
                MessageBox.Show(""); }
        }

        private void bbiAddNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new frmAddNewPerson();
            dlg.IsEmployer = false;
            dlg.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {if(spuAdmitResultBindingSource.Count==0)
            {
                MessageBox.Show("اطلاعات شاغل قبلا ثبت شده آبا مایل به ویرایش اطلاعات می باشید؟");
                return;
            }
            var dlg = new frmAddNewPerson();
            dlg.IsEmployer = true;
            dlg.ShowDialog();
        }
    }
}