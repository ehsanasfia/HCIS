using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Forms
{
    public partial class frmInProtection : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        public RequestM ap { get; set; }
        List<FactorProduct> lstRd;
        public frmInProtection()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmInProtection_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            factorBindingSource.DataSource = dc.Factors.Where(x=>x.WarehouseKeeper==true).ToList();
        }
        
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rm = factorBindingSource.Current as Factor;
            if (rm == null)
                return;
            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.InProtection == true)
                {


                    item.DateInProtection = MainModule.GetPersianDate(DateTime.Now);
                    item.TimeInProtection = DateTime.Now.ToString("HH:mm");
                    item.IPUser = MainModule.RoleName + "";
                    rm.InProtection = true;
                    rm.DateInProtection = MainModule.GetPersianDate(DateTime.Now);
                    rm.TimeInProtection = DateTime.Now.ToString("HH:mm");
                    rm.IPUser = MainModule.RoleName + "";
                    trueFound = false;


                }

                else
                {

                  

                    if (trueFound == true)
                        rm.InProtection = false;
                }
            }
            dc.SubmitChanges();
            GetData();
            gridControl3.RefreshDataSource();


            if (rm.InProtection == true)
            {
                MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = factorBindingSource.Current as Factor;
            if (curent == null)
                return;


            lstRd = dc.FactorProducts.Where(x => x.IDFactor == curent.ID).ToList();
            factorProductBindingSource.DataSource = lstRd;
        }
    }
}