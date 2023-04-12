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
    public partial class dlgAdmissionList : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public Person ObjectP;
        public Triage ObjectT;
        public GivenServiceM ObjectM;

        public dlgAdmissionList()
        {
            InitializeComponent();
        }

        private void dlgAdmissionList_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            txtDate.Text = today;


            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                                  Where(x => x.ServiceCategoryID == 10 &&
                                   x.Admitted == true &&
                                  // && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                                  x.AdmitDate == txtDate.Text
                                  && x.Department.ID == Guid.Parse("d457926e-73f1-4096-9528-d023366a1835")
                                 ).OrderBy(c=> c.AdmitDate).ThenByDescending(c=> c.AdmitTime).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = givenServiceMBindingSource.Current as GivenServiceM;
            if (cur == null)
                return;
            ObjectP = cur.Person;
            ObjectM = cur;
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

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                btnOk_Click(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.
                                    Where(x => x.ServiceCategoryID == 10 &&
                                     x.Admitted == true &&
                                    // && x.DepartmentID == Classes.MainModule.MyDepartment.ID
                                    x.AdmitDate == txtDate.Text
                                    && x.Department.ID == Guid.Parse("d457926e-73f1-4096-9528-d023366a1835")
                                   ).OrderBy(c => c.AdmitDate).ThenByDescending(c => c.AdmitTime).ToList();
        }
    }
}