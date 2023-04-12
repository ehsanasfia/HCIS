using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BloodBank.Forms;

namespace BloodBank.Dialogs
{
    public partial class dlgRegInformation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public dlgRegInformation()
        {
            InitializeComponent();
        }

        private void dlgRegInformation_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        public static implicit operator dlgRegInformation(frmBloodRequest v)
        {
            throw new NotImplementedException();
        }
    }
}
