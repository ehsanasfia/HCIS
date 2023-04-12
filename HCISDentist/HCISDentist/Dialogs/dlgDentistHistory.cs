using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDentist.Data;

namespace HCISDentist.Dialogs
{
    public partial class dlgDentistHistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISDentisClassesDataContext dc { get; set; }
        public Person prs;
        List<Spu_DentistHistoryResult> lst;

        public dlgDentistHistory()
        {
            InitializeComponent();
        }

        private void dlgDentistHistory_Load(object sender, EventArgs e)
        {
            if (lst == null)
                lst = new List<Spu_DentistHistoryResult>();

            lst = dc.Spu_DentistHistory(prs.NationalCode).ToList();
            spuDentistHistoryResultBindingSource.DataSource = lst;
            gridView1.ExpandAllGroups();
            gridView1.BestFitColumns();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("سوابق دنداپزشکی {0}", prs.FullName);
            printableComponentLink1.CreateDocument();

            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}