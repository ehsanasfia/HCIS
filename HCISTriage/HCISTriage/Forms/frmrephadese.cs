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
namespace HCISTriage.Forms
{
    public partial class frmrephadese : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public Person ObjectP;
        public Triage ObjectT;
        public GivenServiceM ObjectM;
        public frmrephadese()
        {
            InitializeComponent();
        }

        private void frmrephadese_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c =>
            c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
            .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = triageEMGincidentBindingSource.Current as TriageEMGincident;
            if (cur == null)
                return;
            ObjectP = cur.Person;
            ObjectM = cur.GivenServiceM;
            if (cur.Person.Triages.Any())
            {
                var lst = cur.Person.Triages.OrderByDescending(c => c.LoginDate);
                ObjectT = lst.FirstOrDefault();
                ObjectT.GivenServiceM = ObjectM;
            }
            else
                ObjectT = null;

            DialogResult = DialogResult.OK;
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c =>
     c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
     .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            triageEMGincidentBindingSource.DataSource = dc.TriageEMGincidents.Where(c =>
     c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
     .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var cur = triageEMGincidentBindingSource.Current as TriageEMGincident;
            if (cur == null)
                return;
            ObjectP = cur.Person;
            ObjectM = cur.GivenServiceM;
            if (cur.Person.Triages.Any())
            {
                var lst = cur.Person.Triages.OrderByDescending(c => c.LoginDate);
                ObjectT = lst.FirstOrDefault();
                ObjectT.GivenServiceM = ObjectM;
            }
            else
                ObjectT = null;

            DialogResult = DialogResult.OK;
        }
    }
}