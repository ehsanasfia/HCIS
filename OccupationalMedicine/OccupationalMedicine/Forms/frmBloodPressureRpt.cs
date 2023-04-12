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
using OccupationalMedicine.Data;

namespace OccupationalMedicine.Forms
{
    public partial class frmBloodPressureRpt : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmBloodPressureRpt()
        {
            InitializeComponent();
        }

        private void frmDiabetes_Load(object sender, EventArgs e)
        {
            txtFrom.Text = "1395/01/01";
            txtTo.Text = "1397/12/29";

            contractsBindingSource.DataSource = dc.Contracts.ToList();
            GetContractInfo();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void GetContractInfo()
        {
            Contract cnt = null;
            if (ContractLkp.Focused)
            {
                cnt = ContractLkp.EditValue as Contract;
            }

            if (cnt == null)
            {
                ribbonPageGroup2.Visible = false;
                return;
            }

            ribbonPageGroup2.Visible = true;
            ContractNumberLbl.Caption = "شماره قرارداد: " + cnt.ContractNumber;
            ContractSubjectLbl.Caption = "موضوع قرارداد: " + cnt.ContractSubject;
            ContractTypeLbl.Caption = "نوع قرارداد: " + cnt.ContractType;
            CompanyLbl.Caption = "شرکت طرف قرارداد: " + cnt.Company;
            FromDateLbl.Caption = "تاریخ شروع: " + cnt.FromDate;
            ToDateLbl.Caption = "تاریخ خاتمه: " + cnt.ToDate;
        }

        private void ContractLkp_EditValueChanged(object sender, EventArgs e)
        {
            if (ContractLkp.EditValue == null || ContractLkp.EditValue.GetType() == typeof(DBNull) || string.IsNullOrWhiteSpace(txtFrom.Text) || string.IsNullOrWhiteSpace(txtTo.Text))
            {
                vwBloodPressurePercentagesBindingSource.DataSource = null;
                return;
            }
            var cntNumber = (ContractLkp.EditValue as Contract).ContractNumber;
            sPBloodPressurePercentageTableAdapter.Fill(dataSet1.SPBloodPressurePercentage, txtFrom.Text, txtTo.Text, cntNumber);
           
            GetContractInfo();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cols = gridView1.Columns;
            for (int i = 0; i < cols.Count; i++)
            {
                cols[i].VisibleIndex = cols.Count - cols[i].VisibleIndex - 1;
                cols[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                string.IsNullOrWhiteSpace(barEditItem1.EditValue as string) ? "گزارش افزایش فشار خون" : barEditItem1.EditValue as string,
                ""}, new Font("B Nazanin", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 178), DevExpress.XtraPrinting.BrickAlignment.Center), null);

            printableComponentLink1.ClearDocument();
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

            for (int i = 0; i < cols.Count; i++)
            {
                cols[i].VisibleIndex = cols.Count - cols[i].VisibleIndex - 1;
                cols[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ContractLkp_EditValueChanged(null, null);
        }
    }
}