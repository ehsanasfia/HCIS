using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLaundry.Data;

namespace HCISLaundry.Forms
{
    public partial class frmCountStaffClothes : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        public frmCountStaffClothes()
        {
            InitializeComponent();
        }

        private void frmCountStaffClothes_Load(object sender, EventArgs e)
        {
            vwLaundryStaffBindingSource.DataSource = dc.Vw_LaundryStaffs.OrderBy(c => c.FirstName).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}