using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgCarePatient : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Vw_CareGSM GSDCare { get; set; }

        public dlgCarePatient()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dlgCarePatient_Load(object sender, EventArgs e)
        {
            txtDate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            vwCareGSMBindingSource.DataSource = dc.Vw_CareGSMs.Where(x => x.RequestDate == txtDate.Text.Trim()).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            vwCareGSMBindingSource.DataSource = dc.Vw_CareGSMs.Where(x => x.RequestDate == txtDate.Text.Trim()).ToList();


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var curent = vwCareGSMBindingSource.Current as Vw_CareGSM;
            if (curent == null)
                return;
            GSDCare = curent;
            DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var curent = vwCareGSMBindingSource.Current as Vw_CareGSM;
            if (curent == null)
                return;
            GSDCare = curent;
            DialogResult = DialogResult.OK;
        }

        private void vwCareGSDBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void vwCareGSMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curent = vwCareGSMBindingSource.Current as Vw_CareGSM;
            if (curent == null)
                return;
            vwCareGSDBindingSource.DataSource = dc.Vw_CareGSDs.Where(x => x.GivenServiceMID == curent.ID);
        }
    }
}