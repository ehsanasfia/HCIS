using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
namespace Inventory.Dialogs
{
    public partial class dlgRequestLP : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public RequestM ObjectRM { get; set; }
        List<RequestD> lst = new List<RequestD>();
        public bool boolPMR { get; set; }
        public dlgRequestLP()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {


            foreach (var item in lst)
                if (item.AmountPMRLP == null)
                {
                    MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            //var prs = lkpPerson.EditValue as Person;
            //if (prs == null)
            //{
            //    MessageBox.Show("درخواست دهنده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            ObjectRM.LP = true;
            ObjectRM.WarehouseKeeper = false;
            ObjectRM.OrganBoss = true;
            //var org = lkpOrgan.EditValue as Organ;
           
            //ObjectRM.LocationUnit = (lkpOrgan.EditValue as Organ).ID;
            
            //ObjectRM.IDOrgan = org.ID;
            ObjectRM.IDWarehouse = Properties.Settings.Default.Install;
            ObjectRM.RequestDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.RequestTime = DateTime.Now.ToString("HH:mm");
            //ObjectRM.IDPerson = (lkpPerson.EditValue as Person).UserID;
            ObjectRM.UMDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.UMtime = DateTime.Now.ToString("HH:mm");
            ObjectRM.UMUser = MainModule.UserID + "";
            ObjectRM.WarHouseORUserPMRLP = true;
            
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void dlgRequestLP_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
           
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }

        
           organsBindingSource.DataSource = dc.Organs.Where(c => c.Warehouse == true).ToList();
            
           requestDBindingSource.DataSource = ObjectRM.RequestDs.ToList();

        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            var P = skpInventory.EditValue as Organ;
            if(P == null)
            {
                productBindingSource.DataSource = null;
                return;
            
            }
                productBindingSource.DataSource = P.Products/*.Where(c => c.GroupP == true)*/.ToList();
           
        }
    }
}