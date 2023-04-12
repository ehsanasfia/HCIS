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
    public partial class frmOutProtection : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd;
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> lstLP = new List<RequestD>();
        List<RequestD> lstPMR = new List<RequestD>();
        public frmOutProtection()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmOutProtection_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {

            requestMBindingSource.DataSource = dc.RequestMs.Where(c => c.OrganBoss == true).ToList();

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lstPMR = lstLP = lst = lstRd = dc.RequestDs.Where(x => x.IDRequestM == curent.ID && x.OrganBoss == true).ToList();
            requestDBindingSource.DataSource = lstRd = lst = lstLP = lstPMR;
            gridControl2.RefreshDataSource();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rm = requestMBindingSource.Current as RequestM;
            if (rm == null)
                return;
            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.outProtection == true)
                {


                    item.DateOutProtection = MainModule.GetPersianDate(DateTime.Now);
                    item.TimeOutProtection = DateTime.Now.ToString("HH:mm");
                    item.OPUser = MainModule.RoleName + "";
                    rm.outProtection = true;
                    rm.DateOutProtection = MainModule.GetPersianDate(DateTime.Now);
                    rm.TimeOutProtection = DateTime.Now.ToString("HH:mm");
                    rm.OPUser = MainModule.RoleName + "";
                    trueFound = false;


                }

                else
                {



                    if (trueFound == true)
                        rm.outProtection = false;
                }
            }
            dc.SubmitChanges();
            GetData();
            gridControl2.RefreshDataSource();
            if (rm.outProtection == true)
            {
                MessageBox.Show("ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }
    }
}