using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace OccupationalMedicine.Forms
{
    public partial class frmExcelExport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmExcelExport()
        {
            InitializeComponent();
        }

        Data.OccupationalMedicineClassesDataContext dc = new Data.OccupationalMedicineClassesDataContext();

        private void frmExcelExport_Load(object sender, EventArgs e)
        {
            contractBindingSource.DataSource = dc.Contracts;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    gridView1.ExportToXlsx(saveFileDialog1.FileName);
                    MessageBox.Show("ذخیره شد");
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"خطا");
                }
            }

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                vExcelRpt1BindingSource.DataSource = dc.VExcelRpt1s .Where(c => c.ContractNumber == slkChooseContract.EditValue.ToString());
                gridView1.BestFitColumns();
                barButtonItem1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void BtnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Data.VExcelRpt1> lst = new List<Data.VExcelRpt1>();
            foreach (var item in gridView2.GetSelectedRows())
            {
                var SelectedContract = gridView2.GetRow(item) as Data.Contract;
                   var report = dc.VExcelRpt1s.Where(c => c.ContractNumber == SelectedContract.ContractNumber.ToString());
                lst.AddRange(report);
            }
            vExcelRpt1BindingSource.DataSource = lst;
            barButtonItem1.Enabled = true;

        }
    }
}