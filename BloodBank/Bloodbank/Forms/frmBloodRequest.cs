using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace BloodBank.Forms
{
    public partial class frmBloodRequest : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBloodRequest()
        {
            InitializeComponent();
        }

        private void frmBloodRequest_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}