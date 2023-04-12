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

namespace HCISNurse.Forms
{
    public partial class frmFDReport : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public frmFDReport()
        {
            InitializeComponent();
        }

        private void frmFDReport_Load(object sender, EventArgs e)
        {
            vwFamilyDoctorRptBindingSource.DataSource = dc.Vw_FamilyDoctorRpts.ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}