using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;

namespace HCISNurse.Dialogs
{
    public partial class dlgVaccinationHistory : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public GivenServiceM CurGSM { get; set; }
        public dlgVaccinationHistory()
        {
            InitializeComponent();
        }

        private void dlgVaccinationHistory_Load(object sender, EventArgs e)
        {
            qABindingSource.DataSource = dc.QAs.Where(x => x.GivenServiceM == CurGSM && x.Service1 != null && x.Service1.Name == "واکسن").OrderByDescending(c => c.CreationDate).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}