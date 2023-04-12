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
    public partial class frmrepEM : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public Person ObjectP;
        public Triage ObjectT;
        public GivenServiceM ObjectM;
        public frmrepEM()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmrepEM_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            triageDossierEMBindingSource.DataSource = dc.TriageDossierEMs.Where(c =>
            c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
            .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
    
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            var cur = triageDossierEMBindingSource.Current as TriageDossierEM;
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
            triageDossierEMBindingSource.DataSource = dc.TriageDossierEMs.Where(c =>
       c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
       .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            triageDossierEMBindingSource.DataSource = dc.TriageDossierEMs.Where(c =>
       c.CreationDate.CompareTo(txtFromDate.Text) >= 0 && c.CreationDate.CompareTo(txtToDate.Text) <= 0)
       .OrderByDescending(c => c.CreationDate).ThenByDescending(c => c.CreationTime).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var cur = triageDossierEMBindingSource.Current as TriageDossierEM;
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