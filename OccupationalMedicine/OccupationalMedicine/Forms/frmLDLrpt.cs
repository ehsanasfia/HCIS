﻿using System;
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
    public partial class frmLDLrpt : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frmLDLrpt()
        {
            InitializeComponent();
        }


        private void frmDiabetes_Load(object sender, EventArgs e)
        {
            contractsBindingSource.DataSource = dc.Contracts;
            GetContractInfo();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void ContractLkp_EditValueChanged(object sender, EventArgs e)
        {
            if (ContractLkp.EditValue == null || ContractLkp.EditValue.GetType() == typeof(DBNull))
            {
                vwLDLPercentagesBindingSource.DataSource = null;
                return;
            }
            var cntNumber = (ContractLkp.EditValue as Contract).ContractNumber;
            var lstVW = dc.VwLDLPercentages.Where(x => x.ContractNumber == cntNumber).ToList();
            var tc = lstVW.Sum(x => x.No);
            foreach (var item in lstVW)
            {
                item.Percentage = Convert.ToDecimal((Convert.ToDouble(item.No) / Convert.ToDouble(tc)) * 100);
            }

            vwLDLPercentagesBindingSource.DataSource = lstVW;
            GetContractInfo();
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
                string.IsNullOrWhiteSpace(barEditItem1.EditValue as string) ? "گزارش افزایش چربی خون" : barEditItem1.EditValue as string,
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
    }
}