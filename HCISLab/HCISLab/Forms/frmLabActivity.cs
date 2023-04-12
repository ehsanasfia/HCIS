using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmLabActivity : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmLabActivity()
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            InitializeComponent();
        }

        private void frmLabActivity_Load(object sender, EventArgs e)
        {
            dtFrom.Date = MainModule.GetPersianDate(DateTime.Now);
            dtTo.Date = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnShowResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var lst = dc.Spu_LabActivity(dtFrom.Date, dtTo.Date).Where(x => x.Dep == MainModule.InstallLocation.Name).ToList();

                stiReport1.Dictionary.Variables.Add("FromDate", dtFrom.Date);
                stiReport1.Dictionary.Variables.Add("ToDate", dtTo.Date);
                stiReport1.Dictionary.Synchronize();
                stiReport1.RegData("MyData", lst);
                
                stiReport1.Compile();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }

            //stiReport1.Design();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void btnTests_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var lstByTest = dc.Spu_LabActivityByTest(dtFrom.Date, dtTo.Date, MainModule.InstallLocation.ID).ToList();
                spuLabActivityByTestResultBindingSource.DataSource = lstByTest;
                gridControl1.RefreshDataSource();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}