using HealthAndFamilyReportHCIS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HealthAndFamilyReportHCIS.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DevExpress.XtraBars.Ribbon.RibbonPage selectedPage;
        bool showShakhes = false;

        public frmMain()
        {
            InitializeComponent();
        }
        void ShowForm(Form f)
        {
            foreach (var form in MdiChildren)
                form.Close();

            if (MdiChildren.Count() > 0)
            {
                MessageBox.Show("برای ادامه ابتدا کلیه پنجره های باز را ببندید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            selectedPage = ribbonControl1.SelectedPage;
            f.MdiParent = this;
            f.FormClosed += FormClosedTabChange;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();
            if (ribbonControl1.MergedPages.Count > 0)
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
        }

        private void FormClosedTabChange(object sender, FormClosedEventArgs e)
        {
            ribbonControl1.SelectedPage = selectedPage;
        }

        private void bbiIndex_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmMap();
            frm.FormClosed += Frm_FormClosed;
            ShowForm(frm);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (showShakhes)
                return;
            var frm = sender as frmMap;
            if (frm == null || frm.SelectedZone == null)
                return;
            
            var frmSh = new frmShakhes() { SelectedZone = frm.SelectedZone, jdc = frm.jdc };
            showShakhes = true;
            ShowForm(frmSh);
            showShakhes = false;
        }
    }
}
