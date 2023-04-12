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
using Inventory.Dialogs;
using Inventory.Forms;
using Inventory.Data;

namespace Inventory.Dialogs
{
    public partial class dlgRequest : DevExpress.XtraEditors.XtraForm
    {
        public SecurityLoginsAndAccessControl.User User { get; set; }
        DataClassesSEcDataContext sec = new DataClassesSEcDataContext();
        public DataClassesDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }

        public int LocationID { get; set; }

        public dlgRequest()
        {
            InitializeComponent();
           // organBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Organs;
        }

        private void dlgRequest_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            organBindingSource.DataSource = dc.Organs.Where(c => c.Warehouse == true).ToList();
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }
            requestDBindingSource.DataSource = ObjectRM.RequestDs.ToList();
            
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (lkpWarehouse.Text == "")
            {
                MessageBox.Show("انبار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
           
            foreach (var item in lst)
                if (item.AmountRequest == null)
                {
                    MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            //    var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
           

            ObjectRM.IDWarehouse = (lkpWarehouse.EditValue as Organ).ID;
            ObjectRM.RequestDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.RequestTime = DateTime.Now.ToString("HH:mm");
            try
            {
                //var userid = sec.tblUsers.FirstOrDefault(k => k.UserName == MainModule.UserName && k.ApplicationID == 3106).UserID;
                var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                ObjectRM.IDPerson = x.UserID;
                var orID = x.IDOrgan;

                var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
                //ObjectRM.OrganName = m.Name + "";
                //  ObjectRM.IDOrgan = m.ID;
                ObjectRM.LocationUnit =/* Properties.Settings.Default.Install*/ m.ID;
            }
            catch
            {
                MessageBox.Show("واحد شما مشخص نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //ObjectRM.IDPerson = MainModule.UserID;
            ObjectRM.RUser = MainModule.RoleName + "";
         // ObjectRM.IDOrgan = m.ID;
        
            //ObjectRM.Description = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, colDescription).ToString();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var row = productBindingSource.Current as Product;
            if (row == null)
            {
                return;
            }
            if (lst.Any(c => c.IDProduct == row.ID)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است","توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var RD = new RequestD()
            {
                Product = row,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
               // RUser = MainModule.RoleName + "",
                WarehouseKeeper = false,
                LocationUnit = Properties.Settings.Default.Install,
                RequestM = ObjectRM,
            };
            ObjectRM.RequestDs.Add(RD);
            dc.RequestDs.InsertOnSubmit(RD);
            lst = ObjectRM.RequestDs.ToList();
            requestDBindingSource.DataSource = lst;
            requestDBindingSource.EndEdit();
            if(RD != null)
            {
                lkpWarehouse.Enabled = false;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in lst)
                if (item.AmountRequest == null)
                {
                    MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            var q = from u in lst
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.LastModificationDate, u.RUser };
            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("GDateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.CompiledReport.ShowWithRibbonGUI();
           // stiReport1.Design();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            var row = requestDBindingSource.Current as RequestD;
           
            requestDBindingSource.RemoveCurrent();
            dc.RequestDs.DeleteOnSubmit(row);
            dc.SubmitChanges();
            requestDBindingSource.EndEdit();
            gridControl1.RefreshDataSource();
            del = ObjectRM.RequestDs.ToList();
            requestDBindingSource.DataSource = del;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var w = lkpWarehouse.EditValue as Organ;
            if (w == null)
            {
                productBindingSource.DataSource = null;
                return;
            }

            productBindingSource.DataSource = dc.Products.Where(x => x.IDWarehouse == w.ID).ToList();
        }
    }
}
