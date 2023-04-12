using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecretary.Data;

namespace HCISSecretary.Dialogs
{
    public partial class dlgDosLavazemHistory : DevExpress.XtraEditors.XtraForm
    {
        public Dossier dos { get; set; }
        public HCISDataContext dc { get; set; }
        public dlgDosLavazemHistory()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgDosLavazemHistory_Load(object sender, EventArgs e)
        {
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM.DossierID == dos.ID && x.GivenServiceM.ServiceCategoryID == 12);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            givenServiceDBindingSource.EndEdit();
            dc.SubmitChanges();
        }
    }
}