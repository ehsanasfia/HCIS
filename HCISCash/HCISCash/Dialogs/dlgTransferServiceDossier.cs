using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISCash.Data;

namespace HCISCash.Dialogs
{
    public partial class dlgTransferServiceDossier : DevExpress.XtraEditors.XtraForm
    {
        public dlgTransferServiceDossier()
        {
            InitializeComponent();
        }
        HCISCashDataContextDataContext dc = new HCISCashDataContextDataContext();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            long Dos1 = long.Parse(textEdit1.Text);
            long Dos2 = long.Parse(textEdit2.Text);
            var gsm = dc.GivenServiceMs.Where
                (d => d.DossierID == Dos1 && d.ServiceCategoryID != 10).ToList();
            var gsm2 = dc.GivenServiceMs.Where
               (d => d.DossierID == Dos2 && d.ServiceCategoryID == 10).OrderBy(c=>c.SerialNumber).FirstOrDefault();
            gsm.ForEach(c => c.ParentID = gsm2.ID);
            gsm.ForEach(c => c.DossierID = Dos2);
            dc.SubmitChanges();
        }
    }
}