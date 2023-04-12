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
    public partial class dlgInputproduct : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public RequestM ObjectRM { get; set; }
        List<RequestD> lst = new List<RequestD>();
        public bool boolPMR { get; set; }
        public dlgInputproduct()
        {
            InitializeComponent();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var prs = lkpPerson.EditValue as Person;
            if (prs == null)
            {
                MessageBox.Show("درخواست دهنده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var row = productBindingSource.Current as Product;
            if (row == null)
            {
                return;
            }
            if (lst.Any(c => c.IDProduct == row.ID)) { MessageBox.Show("کالا تکراری است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            //string PMR = null;
            var RD = new RequestD()
            {

                Product = row,
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                WarehouseKeeper = false,
                PMRLP = "LP",



                //  PMRLP = 

              //  RUser = prs.LastName + "",
                RequestM = ObjectRM,
            };

            ObjectRM.RequestDs.Add(RD);
            dc.RequestDs.InsertOnSubmit(RD);


            //requestDBindingSource.DataSource = dc.RequestDs.Where(x=> x=)
            lst = ObjectRM.RequestDs.ToList();
            requestDBindingSource.DataSource = lst;
            requestDBindingSource.EndEdit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            foreach (var item in lst)
                if (item.AmountPMRLP == null)
                {
                    MessageBox.Show("مقدار درخواستی را برای( " + item.Product.FaName + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
            var prs = lkpPerson.EditValue as Person;
            if (prs == null)
            {
                MessageBox.Show("درخواست دهنده را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ObjectRM.LP = true;
            ObjectRM.WarehouseKeeper = false;
            ObjectRM.OrganBoss = true;
            var org = lkpOrgan.EditValue as Organ;
            ///////
            //         var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            //         ObjectRM.IDPerson = x.UserID;
            //         var orID = x.IDOrgan;

            //         var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
            //         //ObjectRM.OrganName = m.Name + "";
            //  ObjectRM.IDOrgan = m.ID;
            ObjectRM.LocationUnit = (lkpOrgan.EditValue as Organ).ID;
            /////
            // ObjectRM.OrganName =org.Name;
            ObjectRM.IDOrgan = org.ID;
            ObjectRM.IDWarehouse = Properties.Settings.Default.Install;
            ObjectRM.RequestDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.RequestTime = DateTime.Now.ToString("HH:mm");
            ObjectRM.IDPerson = (lkpPerson.EditValue as Person).UserID;
            ObjectRM.UMDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectRM.UMtime = DateTime.Now.ToString("HH:mm");
            ObjectRM.UMUser = MainModule.UserID + "";
            ObjectRM.WarHouseORUserPMRLP = true;
            //  ObjectRM.RUser = prs.LastName + "";
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lkpOrgan_EditValueChanged(object sender, EventArgs e)
        {
            var org = lkpOrgan.EditValue as Organ;
            if (org == null)
            {
                personBindingSource.DataSource = null;
                return;
            }

            personBindingSource.DataSource = org.Persons.ToList();
        }

        private void dlgInputproduct_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            //productsBindingSource.DataSource = dc.Products.Where(x => x.Parent != null).ToList();
            if (ObjectRM == null)
            {
                ObjectRM = new RequestM();
            }

            //RequestDBindingSource.DataSource = ObjectRD;
            organsBindingSource.DataSource = dc.Organs.ToList();
            productBindingSource.DataSource = dc.Products.Where(x => x.Parent != null).ToList();
            requestDBindingSource.DataSource = ObjectRM.RequestDs.ToList();

        }
    }
}