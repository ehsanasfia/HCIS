using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class frmEDit : DevExpress.XtraEditors.XtraForm
    {
        public FactorM ofm { get; set; }
        public HCISDataContexDataContext dc { get; set; }
        List<FactorD> lst = new List<FactorD>();
        public FactorM ObjectFM { get; set; }
        public bool MES;
        public frmEDit()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEDit_Load(object sender, EventArgs e)
        {
            txtFactorNumber.Text = ofm.FactorNumber;
            txtDemandNumber.Text = ofm.DemandNumber;
            txtORdernum.Text = ofm.Ordernum;
            txtReceiptNumber.Text = ofm.ReceiptNumber;
            txtFactorDate.Text = ofm.FactorDate;
            radioGroup1.EditValue = ofm.AwardFactor;
            textEdit1.Text = ofm.NeedDate;
            txtBarname.Text = ofm.Barname;
            var Com = dc.Companies.Where(c => c.ID == ofm.CompanyID).FirstOrDefault();
            if (Com.ID == null) { }
            drugTransfereeBindingSource.DataSource = Com.ID;
            lkpComapany.EditValue = Com;

            var DT = dc.DrugTransferees.Where(c => c.ID == ofm.DrugTransfereeID).FirstOrDefault();
            if(DT == null) { return; }
            if (DT.ID == null) { }

            drugTransfereeBindingSource.DataSource = DT.ID;
            lkpResponsibleSale.EditValue = DT;
            mmdDescription.Text = ofm.Description;
            GetData();
           // txtFactorDate.Text = MainModule.GetPersianDate(DateTime.Now);
            //textEdit1.Text = (int.Parse(txtFactorDate.Text)+  int.Parse("30")).ToString() ;
            //txtExpireDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void GetData()
        {
            lst = dc.FactorDs.Where(c => c.FactorMID == ofm.ID).OrderBy(c=> c.IDint).ToList();
            factorDBindingSource.DataSource = lst;
            drugTransfereeBindingSource.DataSource = dc.DrugTransferees.ToList();
            //  departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID && c.Name != "انبار").ToList();
            if (ObjectFM == null)
            {
                ObjectFM = new FactorM();
            }
            companyBindingSource.DataSource = dc.Companies.ToList();

            aPPharmcyDrugAnbarBindingSource.DataSource = dc.AP_PharmcyDrugAnbars.ToList();


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (var item in lst)
            {
                if (item.AmountBuy == null)
                {
                    MessageBox.Show("مقدار یا مبلغ برای( " + item.AP_PharmcyDrugAnbar.Name + " )وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

            }

            if (lkpComapany.EditValue == null)
            {
                MessageBox.Show("نام توزیع کننده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (lkpResponsibleSale.EditValue == null)
            {
                MessageBox.Show("تحویل گیرنده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }


            //foreach (var item in lst)
            //    if (item.AmountBuy == null)
            //    {
            //        MessageBox.Show("قیمت را برای( " + item.Service.Name + " )وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //        return;
            //    }

            if (txtFactorDate.Text == "")
            {
                MessageBox.Show("تاریخ فاکتور را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            ofm.FactorNumber = txtFactorNumber.Text;
            ofm.DemandNumber = txtDemandNumber.Text;
            ofm.Ordernum = txtORdernum.Text;
            ofm.ReceiptNumber = txtReceiptNumber.Text;
            ofm.FactorDate = txtFactorDate.Text;
            ofm.AwardFactor = Boolean.Parse(radioGroup1.EditValue.ToString());
            ofm.NeedDate = textEdit1.Text;
            ofm.Barname = txtBarname.Text;
            ofm.Company = (lkpComapany.EditValue as Company);
            ofm.DrugTransferee = (lkpResponsibleSale.EditValue as DrugTransferee);
            ofm.Description = mmdDescription.Text;
            ofm.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ofm.LastModificationTime = DateTime.Now.ToString("HH:mm");
            ofm.LastModificator = MainModule.UserID;
            ofm.LastModificatorUserFullName = MainModule.UserFullName;
            dc.SubmitChanges();
            MessageBox.Show("تغییرات با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
         
           
            if (txtAmount.Text == "")
            {
                MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (txtPrice.Text == "")
            {
                MessageBox.Show("ارزش را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            FactorD u = new FactorD();
            u.AP_PharmcyDrugAnbar = (skpDrug.EditValue as AP_PharmcyDrugAnbar);
            u.ExpireDate = txtExpireDate.Text;
            //u.NumPageProduct = Int32.Parse(txtNumPageProduct.Text);

            if (MES == true)
            {
                u.MESCCode_No = txtMESC.Text;
            }
            else
            {
                u.MESCCode_No = "";
            }
            u.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            u.LastModificationTime = DateTime.Now.ToString("HH:mm");
            u.LastModificator = MainModule.UserID;
            u.LastModificatorUserFullName = MainModule.UserFullName;
            if (txtAmount == null)
            {
                u.AmountBuy = 0;
            }
            else if (txtAmount != null)
            {
                u.AmountBuy = Int32.Parse(txtAmount.Text);
            }
            if (txtPrice == null)
            {
                u.Price = 0;
            }
            else if (txtPrice != null)
            {
                u.Price = Int32.Parse(txtPrice.Text);
            }
            u.FactorMID = ofm.ID;

            if (lst.Any(c => c.AP_PharmcyDrugAnbar == u.AP_PharmcyDrugAnbar)) { MessageBox.Show("دارو قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); }
            dc.FactorDs.InsertOnSubmit(u);
            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد");
            gridControl1.RefreshDataSource();
            factorDBindingSource.DataSource = lst;
            GetData();
            txtAmount.Text = "";
            skpDrug.EditValue = null;
            txtPrice.Text = null;
            txtMESC.Text = null;
            txtExpireDate.Text = "";
            skpDrug.Select();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var row = factorDBindingSource.Current as FactorD;
            if (row == null)
            {
                return;
            }
            dc.FactorDs.DeleteOnSubmit(row);
            dc.SubmitChanges();
            gridControl1.RefreshDataSource();
            factorDBindingSource.DataSource = lst;
            GetData();

        }

        private void skpDrug_EditValueChanged(object sender, EventArgs e)
        {
            var did = skpDrug.EditValue as AP_PharmcyDrugAnbar;
            if (did == null)
            {
                return;
            }
            txtMESC.Text = dc.AP_PharmcyDrugAnbars.FirstOrDefault(c => c.ID == did.ID).MESCCode_No;
            if (txtMESC.Text == null || txtMESC.Text == "" || txtMESC.Text == " " || txtMESC.Text == "  " || txtMESC.Text == "   ")
            {
                txtMESC.Enabled = true;
                MES = true;
            }
            else
            {
                txtMESC.Enabled = false;
                MES = false;
            }
        }
    }
}