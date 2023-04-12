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
using Inventory.Data;
using Inventory.Dialogs;
using Inventory.Forms;

namespace Inventory.Forms
{
    public partial class frmBuy : DevExpress.XtraEditors.XtraForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd;
        List<RequestD> lstPMR = new List<RequestD>();
        public frmBuy()
        {
            InitializeComponent();
        }

        private void frmBuy_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void GetData()
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => (T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.HealthcareBossPRM == true && T.ProcurementPRM == true && T.OrdersPRM == true 
            && (T.MedicalEquipmentPRM == true || T.BuyUnitPRM == true) || (T.LP == true && T.WKBossLP == true && T.BudgetLP == true && T.FinancialLP == true && T.SupportLibraryLP == true && T.ProcurementLP))
            && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

      

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;

            bool trueFound = true;
            foreach (var item in lstRd)
            {
                if (item.BuyPMRLP == true)
                {
                    curent.Buser = MainModule.RoleName + "";
                    curent.BDate = MainModule.GetPersianDate(DateTime.Now);
                    curent.BuyPMRLP = true;
                    trueFound = false;
                    break;
                }
            }
            if (trueFound == true)
                curent.BuyPMRLP = false;

            dc.SubmitChanges();
            GetData();
            if (curent.BuyPMRLP == true)
            {
                MessageBox.Show("اطلاعات با موفقیت ثبت  گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
            lstRd = lstPMR = dc.RequestDs.Where(x =>
            (x.IDRequestM == curent.ID && x.WarehouseKeeper == false && x.WKBossPMR == true && x.BudgetPRM == true && x.FinancialPRM == true && x.SupportLibraryPRM == true && x.HealthcareBossPRM == true && x.ProcurementPRM == true && x.OrdersPRM == true && x.Product != null && x.Product.Parent != null && x.PMRLP == "PMR" && (x.MedicalEquipmentPRM == true || x.BuyUnitPRM == true))
            ||
            (x.IDRequestM == curent.ID && x.WKBossLP == true && x.BudgetLP == true && x.FinancialLP == true && x.SupportLibraryLP == true && x.PMRLP == "LP" && x.ProcurementLP )
            ).ToList();
            requestDBindingSource.DataSource = lstRd = lstPMR;
            gridControl2.RefreshDataSource();
           
           
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = requestMBindingSource.Current as RequestM;
            var q = from u in lstPMR
                    where u.OrganBoss == true && u.WarehouseKeeper == false && u.PMRLP == "PMR" && u.WKBossPMR == true && u.BudgetPRM == true && u.FinancialPRM == true && u.SupportLibraryPRM == true && u.HealthcareBossPRM == true && u.ProcurementPRM == true && u.OrdersPRM == true && u.BuyUnitPRM == true /*&& u.BuyPMRLP ==true*/
                    select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.IDRequestM, current.RequestDate, current.RUser, current.LastModificationDate, current.IBDate, current.IBUser, u.DatePMRLP };
            stiReport3.RegData("PMR", q);
            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
            // stiReport3.Design();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => (T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.HealthcareBossPRM == true && T.ProcurementPRM == true && T.OrdersPRM == true
            && (T.MedicalEquipmentPRM == true || T.BuyUnitPRM == true) || (T.LP == true && T.WKBossLP == true && T.BudgetLP == true && T.FinancialLP == true && T.SupportLibraryLP == true && T.ProcurementLP))
            && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
            // requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.HealthcareBossPRM == true && T.ProcurementPRM == true && T.OrdersPRM == true && (T.MedicalEquipmentPRM == true || T.BuyUnitPRM == true) && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestMBindingSource.DataSource = dc.RequestMs.Where(T => (T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.HealthcareBossPRM == true && T.ProcurementPRM == true && T.OrdersPRM == true
            && (T.MedicalEquipmentPRM == true || T.BuyUnitPRM == true) || (T.LP == true && T.WKBossLP == true && T.BudgetLP == true && T.FinancialLP == true && T.SupportLibraryLP == true && T.ProcurementLP))
            && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
            // requestMBindingSource.DataSource = dc.RequestMs.Where(T => T.PMR == true && T.WKBossPRM == true && T.BudgetPRM == true && T.FinancialPRM == true && T.SupportLibraryPRM == true && T.HealthcareBossPRM == true && T.ProcurementPRM == true && T.OrdersPRM == true && (T.MedicalEquipmentPRM == true || T.BuyUnitPRM == true) && T.UMDate.CompareTo(txtFromDate.Text) >= 0 && T.UMDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = this.requestMBindingSource.Current as RequestM;
            var dlg = new dlgFactorMain();
            dlg.Text = "لیست فاکتورها";
            dlg.ap = current;
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.Factors.InsertOnSubmit(dlg.ObjectRM);
                dc.SubmitChanges();
                GetData();
            }
        }
    }
}