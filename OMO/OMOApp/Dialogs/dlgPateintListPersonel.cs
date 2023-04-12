using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;

namespace OMOApp.Dialogs
{
    public partial class dlgPateintListPersonel : DevExpress.XtraEditors.XtraForm
    {
        public dlgPateintListPersonel()
        {
            InitializeComponent();
        }
        public string txtYear;
        public string cmp;
        public string subcmp;
        OMOClassesDataContext dc = new OMOClassesDataContext();
        private void dlgPateintListt_Load(object sender, EventArgs e)
        {
            vwResultCompanyBindingSource.DataSource = dc.Vw_ResultCompanies.Where(x => x.CreationDate.Substring(0, 4).CompareTo(txtYear) == 0 && x.CompanyName == cmp && x.SubCompanyName == subcmp).ToList();

        }
        private void print_Click(object sender, EventArgs e)
        {
            printableComponentLink1.ClearDocument();
            var hf = printableComponentLink1.PageHeaderFooter as DevExpress.XtraPrinting.PageHeaderFooter;
          //  hf.Header.Content[1] = String.Format("[Image 0]\r\n  لیست افراد داری بیماری  \r\nاز تاریخ {0} لغایت  {1}", ComInfo.FirstName,ComInfo.LastName);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}