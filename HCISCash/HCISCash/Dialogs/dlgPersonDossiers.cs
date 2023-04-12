using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgPersonDossiers : DevExpress.XtraEditors.XtraForm
    {
        public dlgPersonDossiers()
        {
            InitializeComponent();
        }

        public HCISCashDataContextDataContext dc { get; internal set; }
        public long DosseirID { get; internal set; }
        public String PCode { get; internal set; }

        private void dlgPersonDossiers_Load(object sender, EventArgs e)
        {
            var lst = dc.Vw_DosFinances.Where(c => c.PersonalCode == PCode).
                 Select(x=> new { x.Date,x.DossierNO,x.FirstName,x.LastName,x.NationalCode}).Distinct();
            vwDosFinanceBindingSource.DataSource = lst;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
                DosseirID =long.Parse( gridView1.GetFocusedRowCellValue("DossierNO").ToString());
              DialogResult = DialogResult.OK;
        }
    }
}