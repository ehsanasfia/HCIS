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
using Inventory.Dialogs;
using Inventory.Forms;
namespace Inventory.Dialogs
{
    public partial class dlgGroupP : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public bool isEdit { get; set; }
        public Product PHT { get; set; }
        public dlgGroupP()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
        }

        private void dlgGroupP_Load(object sender, EventArgs e)
        {
            organsBindingSource.DataSource = dc.Organs.Where(c => c.Warehouse == true).OrderBy(c => c.Name).ToList();
            if (isEdit == true)
            {
                txtFaName.Text = PHT.FaName;
                // lkpParent.Text = PHT.Product1.FaName.ToString();
                //   lkpMeasurement.EditValue = PHT.IDMeasurement;
                //  lkpWarehouseName.EditValue = PHT.IDWarehouseName;  بعد 
              //  txtPrice.Text = PHT.Price + "";
               // txtRegisterDate.Text = PHT.RegisterDate;
          //      txtInitialBalance.Text = PHT.InitialBalance + "";
             //   txtLessAmount.Text = PHT.LessAmount + "";
          //      txtShelf.Text = PHT.Shelf + "";
               // txtunit.Text = PHT.Unit + "";
               // txtWeight.Text = PHT.Weight + "";
               // txtDimensions.Text = PHT.Dimensions + "";
              //  txtColor.Text = PHT.Color;
                memDescription.Text = PHT.Description;
              //  txtMCSE.Text = PHT.MESC;

                searchLookUpEdit1.EditValue = PHT.IDWarehouse;
                searchLookUpEdit1.Enabled = false;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.EditValue == null)
            {
                MessageBox.Show("انبار را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (isEdit == false)
            {
                PHT = new Product();
            }

            PHT.FaName = txtFaName.Text;

            PHT.GroupP = true;
            // PHT.Product1 = paren;
            //PHT.IDMeasurement = Mea; 
            //PHT.warehouse = idw; بعد
            PHT.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            PHT.CreationTime = DateTime.Now.ToString("HH:mm");
            PHT.CreatorUserID = MainModule.UserID;
            // var m = dc.warehouses.Where(c => c.ResponsibleUserID == MainModule.UserID).FirstOrDefault();

            PHT.IDWarehouse = Int32.Parse(searchLookUpEdit1.EditValue.ToString());

            
            PHT.Description = memDescription.Text;
            if (isEdit == false)
                dc.Products.InsertOnSubmit(PHT);

            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }
    }
}