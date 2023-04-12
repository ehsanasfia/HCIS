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
using HCISFinance.Data;

namespace HCISFinance.Forms
{
    public partial class frmIncome : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        CostsAndIncome ObjectCAI;
        public frmIncome()
        {
            InitializeComponent();
        }

        private void frmCost_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }

        private void EndEdit()
        {
            CostsAndIncomeBindingSource.EndEdit();
            costsAndIncomesBindingSource.EndEdit();
        }

        private void GetData()
        {
            EndEdit();
            if (ObjectCAI == null)
            {
                ObjectCAI = new CostsAndIncome();
            }

            CostsAndIncomeBindingSource.DataSource = ObjectCAI;
            costsAndIncomesBindingSource.DataSource = dc.CostsAndIncomes.Where(x => x.Income == true).OrderBy(c => c.CostType.Name).OrderBy(c => c.Date).ToList();
            costTypeBindingSource.DataSource = dc.CostTypes.Where(x => x.Income == true).OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ObjectCAI.Date = txtDate.Text.Trim();
            var today = MainModule.GetPersianDate(DateTime.Now);
            try
            {
                var ct = lkpCostType.EditValue as CostType;
                if (ct == null)
                {
                    MessageBox.Show("لطفا نوع هزینه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (clcPrice.Text == "")
                {
                    MessageBox.Show("لطفا مبلغ را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var CAI = dc.CostsAndIncomes.FirstOrDefault(c => c.Date == today && c.CostTypeID == (lkpCostType.EditValue as CostType).ID);
                if (CAI == null)
                {
                    ObjectCAI.Income = true;
                    ObjectCAI.CostType = ct;
                    ObjectCAI.CreationDate = today;
                    ObjectCAI.CreationTime = DateTime.Now.ToString("HH:mm");
                    ObjectCAI.LastModificationDate = today;
                    ObjectCAI.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    dc.CostsAndIncomes.InsertOnSubmit(ObjectCAI);
                }
                else
                {
                    CAI.Income = true;
                    CAI.Price = ObjectCAI.Price;
                    CAI.DocumentNumber = ObjectCAI.DocumentNumber;
                    CAI.Comment = ObjectCAI.Comment;
                    CAI.LastModificationDate = today;
                    CAI.LastModificationTime = DateTime.Now.ToString("HH:mm");
                    ObjectCAI.CostType = null;
                    ObjectCAI.Date = null;
                    ObjectCAI.Price = null;
                    ObjectCAI.Comment = null;
                    ObjectCAI = null;
                }

                dc.SubmitChanges();
                ObjectCAI = null;
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dc.Dispose();
                dc = new HCISDataClassesDataContext();
                ObjectCAI = null;
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}