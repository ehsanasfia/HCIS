using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OMOApp.Data;

namespace OMOApp.Forms
{
    public partial class frmBillForCompany : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBillForCompany()
        {
            InitializeComponent();
        }
        OMOClassesDataContext dc = new OMOClassesDataContext();

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            vwbillComBindingSource.DataSource=dc.Vw_billComs.Where(x=>x.AdmitDate.CompareTo(txtFrom.Text)>=0 && x.AdmitDate.CompareTo(txtTo.Text) <= 0).ToList();
        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            printableComponentLink1.ClearDocument();
            var hf = printableComponentLink1.PageHeaderFooter as DevExpress.XtraPrinting.PageHeaderFooter;
            hf.Header.Content[1] = String.Format("[Image 0]\r\nگزارش صورتحساب شرکت ها\r\nاز تاریخ {0} لغایت {1}", txtFrom.Text, txtTo.Text);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

        }
    }
}