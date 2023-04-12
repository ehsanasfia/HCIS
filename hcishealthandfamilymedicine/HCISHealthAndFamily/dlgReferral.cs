using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;

namespace HCISHealthAndFamily
{
    public partial class dlgReferral : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Person ObjectP;
        public dlgReferral()
        {
            InitializeComponent();
        }

        private void dlgReferral_Load(object sender, EventArgs e)
        {
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceM != null && x.DepartmentID != null && x.GivenServiceM.PersonID == ObjectP.ID).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}