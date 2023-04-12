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
    public partial class frmCountClothes : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        public frmCountClothes()
        {
            InitializeComponent();
        }

        private void frmCountClothes_Load(object sender, EventArgs e)
        {
            vwLaundryCountBindingSource.DataSource = dc.Vw_LaundryCounts.ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}