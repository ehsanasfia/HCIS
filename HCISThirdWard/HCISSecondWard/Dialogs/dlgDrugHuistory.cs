using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgDrugHuistory : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public Person CurPerson { get; set; }
        public dlgDrugHuistory()
        {
            InitializeComponent();
        }

        private void dlgDrugHuistory_Load(object sender, EventArgs e)
        {
            this.Text = "سوابق دارویی" + " " + CurPerson.FirstName + " " + CurPerson.LastName;
            vwDrugHistoryUnionBindingSource.DataSource = dc.VwDrugHistoryUnions.Where(x => x.NationalCode == CurPerson.NationalCode).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}