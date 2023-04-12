using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Dialogs;
using Inventory.Forms;
using Inventory.Data;
namespace Inventory.Dialogs
{
    public partial class dlganbargardani : DevExpress.XtraEditors.XtraForm
    {

        public DataClassesDataContext dc { get; set; }
        List<FactorProduct> lst = new List<FactorProduct>();
        List<Product> lstP = new List<Product>();
        List<FactorProduct> del = new List<FactorProduct>();
        List<InStack> x;
        public Factor ObjectRM { get; set; }
        public dlganbargardani()
        {
            InitializeComponent();
            providersBindingSource.DataSource = new Inventory.Data.DataClassesDataContext().Providers;
        }

        private void dlganbargardani_Load(object sender, EventArgs e)
        {
            GetData();
            txtFactorDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void GetData()
        {

            if (ObjectRM == null)
            {
                ObjectRM = new Factor();
            }
            var s = dc.Organs.Where(c => c.ID == Properties.Settings.Default.Install).FirstOrDefault();
            organBindingSource.DataSource = s;
            lkpIDWarehouse.EditValue = s.ID;
            var ag = dc.Providers.Where(c => c.Name == "انبارگردانی").FirstOrDefault();
            providersBindingSource.DataSource = ag;
            lkpProvider.EditValue = ag.ID;
            lstP = dc.Products.Where(x => x.Parent != null && x.IDWarehouse == Properties.Settings.Default.Install).ToList();
            productBindingSource.DataSource = lstP;
         
            factorProductBindingSource.DataSource = ObjectRM.FactorProducts.ToList();
            // providersBindingSource.DataSource = dc.Providers.Where(x => x.ID == 1).ToList();
            // organBindingSource.DataSource = dc.Organs.Where(c => c.Warehouse == true).ToList();
         
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //foreach (var item in lstP)
            ////if (item.AmountBuy == null)
            //{
            //    foreach (var item2 in lst)
            //        //  MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //        //   return;
            //        if (lst.Any(c => item2.IDProduct == item.ID))
            //        {
            //            { MessageBox.Show("کالای( " + item.FaName + " )قبلا به لیست اضافه شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

            //        }
            //}
            var row = productBindingSource.Current as Product;
            if (row == null)
            {
                return;
            }
            if (lst.Any(c => c.IDProduct == row.ID)) { MessageBox.Show("کالا تکراری"); return; }
            var x = gridView3.GetSelectedRows();
            foreach (var c in x)
            {
                var a = gridView3.GetRow(c) as Product;


                var RD = new FactorProduct()
                {
                    IDProduct = a.ID,
                    ProductName = a.FaName,
                    //AmountBuy = a.Mojodi,
                    //Price = a.Price,
                    WarehouseKeeper = true,
                    Factor = ObjectRM,
                };
            }
            lst = ObjectRM.FactorProducts.ToList();
            factorProductBindingSource.DataSource = lst;
            factorProductBindingSource.EndEdit();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //foreach (var item in lst)
            //    if (item.AmountBuy == null)
            //    {
            //        MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //        return;
            //    }
            //if (txtOrdernum.Text == null)
            //{
            //    MessageBox.Show("شماره سفارش را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (txtBarname.Text == null)
            //{
            //    MessageBox.Show("شماره بارنامه را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (lkpProvider.EditValue == null)
            //{
            //    MessageBox.Show("تحویل دهنده را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //if (lkpIDWarehouse.EditValue == null)
            //{
            //    MessageBox.Show("انبار تحویل دهنده را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            ObjectRM.WarehouseHandling = true;
          //ObjectRM.FactorNumber = Int32.Parse(txtFactorNumber.Text);
            ObjectRM.FactorDate = txtFactorDate.Text;
            ObjectRM.IDProvider = Int32.Parse(lkpProvider.EditValue.ToString());
            ObjectRM.ResponsibleSale = txtResponsibleSale.Text;
            ObjectRM.Ordernum = txtOrdernum.Text;
            ObjectRM.barname = txtBarname.Text;
            ObjectRM.WarehouseKeeper = true;
            ObjectRM.IDWarehouse = Int32.Parse(lkpIDWarehouse.EditValue.ToString());
            dc.Factors.InsertOnSubmit(ObjectRM);
            MessageBox.Show("اطلاعات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var row = productBindingSource.Current as Product;
            if (row == null)
            {
                return;
            }
            var GSM = gridView3.GetRow(e.ControllerRow) as Product;

            if (lst.Any(c => c.IDProduct == row.ID))
            {
                gridView3.SelectRow(e.ControllerRow);
                // MessageBox.Show("این خدمت قبلا پرداخت شده");
                if (lst.Any(c => c.IDProduct == row.ID))
                {
                  //  MessageBox.Show("برای حذف کالا( " + row.FaName + " )بر روی حذف کلیک کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            }
            //var x = gridView3.GetSelectedRows();

            ////foreach (var c in x)
            ////{
            //    var a = gridView3.GetRow(c) as Product;
            //    if (gridView3.GetRow(x) == false)

      
          
                //foreach (var item in lst)
                //    if (item.AmountBuy == null)
                //    {
                //        MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //        return;
                //    }
     
            //var x = gridView3.GetSelectedRows();
            //foreach (var c in x)
            //{
            //    var a = gridView3.GetRow(c) as Product;


            FactorProduct u = new FactorProduct();

            u.IDProduct = row.ID;
            u.ProductName = row.FaName;
            //AmountBuy = a.Mojodi,
            //Price = a.Price,
            
            u.WarehouseKeeper = true;
            u.WarehouseKeeperDate = MainModule.GetPersianDate(DateTime.Now);
            u.WarehouseKeeperTime = DateTime.Now.ToString("HH:mm");
            u.Factor = ObjectRM;
               
            //}
            lst.Add(u);
            //lst = ObjectRM.FactorProducts.ToList();
            factorProductBindingSource.DataSource = lst;
          //  factorProductBindingSource.EndEdit();
           gridControl3.RefreshDataSource();
            if (ObjectRM == null)
            {
                ObjectRM = new Factor();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
    
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //var row = productBindingSource.Current as Product;
            //if (row == null)
            //{
            //    return;
            //}
            var row = factorProductBindingSource.Current as FactorProduct;
            lst.Remove(row);
            gridControl3.RefreshDataSource();
            if (ObjectRM == null)
            {
                ObjectRM = new Factor();
            }
            //lst = ObjectRM.FactorProducts.ToList();
            factorProductBindingSource.DataSource = lst;
            //factorProductBindingSource.EndEdit();
     
        }
    }
}