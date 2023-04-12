using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Forms
{
    public partial class frmSurgeryWithSalamatBooklet : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_SurgeryWithSalamatBookletCode> lst = new List<Vw_SurgeryWithSalamatBookletCode>();

        public frmSurgeryWithSalamatBooklet()
        {
            InitializeComponent();
        }

        private void frmSurgeryWithSalamatBooklet_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSalamatBooklet.Text))
            {
                MessageBox.Show("لطفا کد دفترچه سلامت را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            lst = dc.Vw_SurgeryWithSalamatBookletCodes.Where(x => x.Date.CompareTo(txtFrom.Text) >= 0 && x.Date.CompareTo(txtTo.Text) <= 0 && x.SalamatBookletCode == txtSalamatBooklet.Text).ToList();

            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text ?? "");
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text ?? "");
            stiReport1.Dictionary.Variables.Add("SalamatCode", txtSalamatBooklet.Text ?? "");
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();

            stiReport1.RegData("MyData", lst.OrderByDescending(c => c.Date));

            stiViewerControl1.Report = stiReport1;

            //stiReport1.Design();
            stiReport1.Compile();
            stiReport1.Render();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}