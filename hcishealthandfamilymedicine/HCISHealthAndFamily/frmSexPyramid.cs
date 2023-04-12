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
using HCISHealthAndFamily.Classes;
using HCISHealthAndFamily.Data;

namespace HCISHealthAndFamily
{
    public partial class frmSexPyramid : DevExpress.XtraEditors.XtraForm
    {

        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public frmSexPyramid()
        {
            InitializeComponent();
        }

        private void frmSexPyramid_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            dashboardViewer1.LoadDashboard(MainModule.GetStreamFromString(Properties.Resources.SexPyramid_Version_1_1));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                dc.Spu_SexPyramid();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }
    }
}