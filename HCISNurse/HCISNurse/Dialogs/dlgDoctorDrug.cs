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
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgDoctorDrug : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Person prs;

        public dlgDoctorDrug()
        {
            InitializeComponent();
        }

        private void dlgDoctorDrug_Load(object sender, EventArgs e)
        {
            txtFrom.Text = MainModule.GetPersianDate(DateTime.Now);
            txtTo.Text = MainModule.GetPersianDate(DateTime.Now);
            btnSearch_Click(null,null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            givenServiceDBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null
            && x.GivenServiceM.Person == prs
            && x.GivenServiceM.ServiceCategoryID == (int)Category.دارو
            && x.GivenServiceM.CreationDate.CompareTo(txtFrom.Text) >= 0
            && x.GivenServiceM.CreationDate.CompareTo(txtTo.Text) <= 0)
            .OrderByDescending(c => c.GivenServiceM.CreationTime).OrderByDescending(c => c.GivenServiceM.CreationDate)
            .ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}