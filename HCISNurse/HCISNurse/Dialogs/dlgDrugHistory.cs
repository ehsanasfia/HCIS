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
    public partial class dlgDrugHistory : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person CurPerson { get; set; }

        public dlgDrugHistory()
        {
            InitializeComponent();
        }

        private void dlgDrugHuistory_Load(object sender, EventArgs e)
        {
            this.Text = "سابقه ی دارویی" + " " + CurPerson.FirstName + " " + CurPerson.LastName;
            vwDrugHistoryUnionBindingSource.DataSource = dc.VwDrugHistoryUnions.Where(x => x.NationalCode == CurPerson.NationalCode).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}