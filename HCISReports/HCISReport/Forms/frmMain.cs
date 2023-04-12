using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using HCISReport.Forms.Reports;
using HCISReport.Classes;

namespace HCISReport.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void ShowForm(Form frm)
        {
            foreach (var form in MdiChildren) form.Close();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }
        private void bbiTodayPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new frmTodayPatient();
                ShowForm(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    splashScreenManager2.CloseWaitForm();
            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bbiPatientByDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var frm = new frmPatientByDate();
                ShowForm(frm);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bbiInsuranceByDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    var frm = new frmInsurancebydate();
            //    ShowForm(frm);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("ورود انجام نشد" + ex);
            //}

        }

        private void bbiDoctorByDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var frm = new frmDoctorbydate();
                ShowForm(frm);
            }
            catch(Exception ex)
            {
                MessageBox.Show(" ورود انجام نشد" + ex);
            }
        }
    }
}