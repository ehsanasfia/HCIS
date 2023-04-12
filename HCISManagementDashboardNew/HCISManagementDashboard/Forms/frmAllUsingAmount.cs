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
    public partial class frmAllUsingAmount : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Vw_AllUsingAmount> lst;

        public frmAllUsingAmount()
        {
            InitializeComponent();
        }

        private void frmAllUsingAmount_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            if (lst == null)
            {
                lst = new List<Vw_AllUsingAmount>();
            }
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lst = dc.Vw_AllUsingAmounts.Where(x => x.CreationDate.CompareTo(txtFrom.Text) >= 0 && x.CreationDate.CompareTo(txtTo.Text) <= 0).ToList();
            var MyData = from x in lst
                         select new
                         {
                             x.Amount,
                             x.Name
                         };
            var a = MyData.GroupBy(x => x.Name).ToList().Select(x => new { Amount = x.Sum(y => y.Amount) , Name = x.Key });

            stiReport1.RegData("MyData", a);
            stiReport1.Dictionary.Variables.Add("FromDate", txtFrom.Text);
            stiReport1.Dictionary.Variables.Add("ToDate", txtTo.Text);
            MainModule.GetClientConfig(stiReport1);
            stiReport1.Dictionary.Synchronize();
            stiViewerControl1.Report = stiReport1;
            stiReport1.Compile();
            stiReport1.Render();
            stiViewerControl1.Refresh();
            //stiReport1.Design();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}