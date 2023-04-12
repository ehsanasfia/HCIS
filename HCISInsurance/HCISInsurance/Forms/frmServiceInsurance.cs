using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISInsurance.Dialogs;
using HCISInsurance.Data;

namespace HCISInsurance.Forms
{
    public partial class frmServiceInsurance : DevExpress.XtraEditors.XtraForm
    {

        HCISClassesDataContext dc = new HCISClassesDataContext();
        public frmServiceInsurance()
        {
            InitializeComponent();
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgServiceInsurance();
            dlg.dc = dc;
            dlg.ShowDialog();
            //if(dlg.DialogResult==DialogResult.OK)
            //{
            //    serviceInsurancBindingSource.DataSource = dc.ServiceInsurancs.ToList();
            //}
        }

        private void frmServiceInsurance_Load(object sender, EventArgs e)
        {          
            insuranceBindingSource.DataSource = dc.Insurances.ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgServiceInsurance();
            dlg.isEdit = true;
            dlg.dc = dc;
            dlg.EditingServiceInsurance=serviceInsurancBindingSource.Current as ServiceInsuranc;
            dlg.ShowDialog();
            //if (dlg.DialogResult == DialogResult.OK)
            //{
            //    serviceInsurancBindingSource.DataSource = dc.ServiceInsurancs.ToList();
            //}

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        
        private void gridView2_Click(object sender, EventArgs e)
        {
            var CurrentInsurance = insuranceBindingSource.Current as Insurance;
            serviceInsurancBindingSource.DataSource = dc.ServiceInsurancs.Where(x=>x.Insurance== CurrentInsurance).ToList();
        }

        private void bbiAddPer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new  dlgInsuranceServiceDef();
         
             dlg.ShowDialog();
        }
    }
}