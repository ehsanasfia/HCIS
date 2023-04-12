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
    public partial class dlgPateintListSurv : DevExpress.XtraEditors.XtraForm
    {
        public dlgPateintListSurv()
        {
            InitializeComponent();
        }
        public Vw_SickPerson ComInfo;
        OMOClassesDataContext dc = new OMOClassesDataContext();
        private void dlgPateintListt_Load(object sender, EventArgs e)
        {
              vwSickPersonBindingSource.DataSource = dc.Vw_SickPersons.Where(x=>x.SicknessID ==ComInfo.SicknessID && x.IDManagement==ComInfo.IDManagement  && x.CreationDate.CompareTo(ComInfo.FirstName)>=0 && x.CreationDate.CompareTo(ComInfo.LastName)<=0 ).ToList();        }

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