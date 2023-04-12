using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Forms
{
    public partial class frmBastariPhone : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public frmBastariPhone()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBastariPhone_Load(object sender, EventArgs e)
        {
            vwBastariPhoneBindingSource.DataSource = dc.Vw_BastariPhones.ToList();
        }
    }
}