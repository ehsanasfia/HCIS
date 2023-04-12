using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISTriage.Data;
using HCISTriage.Classes;

namespace HCISTriage.Dialogs
{
    public partial class dlgTriageList : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public Person ObjectP;
        public Triage ObjectT;

        public dlgTriageList()
        {
            InitializeComponent();
        }

        private void dlgTriageList_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            triageBindingSource.DataSource = dc.Triages.Where(x => x.LoginDate == today ).OrderByDescending(c=> c.CreationDate)
                .ThenByDescending(c=> c.CreationTime).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = triageBindingSource.Current as Triage;
            if (cur == null)
                return;
            ObjectP = cur.Person;
            ObjectT = cur;
            DialogResult = DialogResult.OK;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(null,null);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 2)
            {
                btnOk_Click(null, null);
            }
        }
    }
}