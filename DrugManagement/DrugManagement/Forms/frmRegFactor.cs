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
using DrugManagement.Dialogs;
namespace DrugManagement.Forms
{
    public partial class frmRegFactor : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<FactorD> lst = new List<FactorD>();
        public FactorM ObjectFM { get; set; }
        //  public RequestD ObjectRD { get; set; }
        public frmRegFactor()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmRegFactor_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            GetData();
        }
        private void GetData()
        {
            factorMBindingSource.DataSource = dc.FactorMs.Where(c => c.FactorDate.CompareTo(txtFromDate.Text) >= 0 && c.FactorDate.CompareTo(txtToDate.Text) <= 0)
                .OrderByDescending(c => c.FactorDate).ThenByDescending(c => c.CreationTime)
                .ToList();



        }
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgRegFactor();
            dlg.Text = "ثبت فاکتور";
            //dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            lst = dc.FactorDs.Where(c => c.FactorMID == current.ID).OrderBy(c => c.IDint).ToList();
            factorDBindingSource.DataSource = lst;

            gridControl1.RefreshDataSource();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new Forms.frmOrderdialog();
            a.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            lst = dc.FactorDs.Where(x => x.FactorMID == current.ID
            && x.AP_PharmcyDrugAnbar.MESCCode_No != null && x.AP_PharmcyDrugAnbar.MESCCode_No != "" && x.AP_PharmcyDrugAnbar.MESCCode_No != " "
            && x.AP_PharmcyDrugAnbar.MESCCode_No != "  ").OrderBy(c => c.IDint).ToList();
            if (lst.Any(c => c.FactorM.AwardFactor == true))
            { MessageBox.Show("درخواست چاپ MT49 شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new
                    {
                        Service = u.AP_PharmcyDrugAnbar == null ? "" : u.AP_PharmcyDrugAnbar.Name,
                        u.AmountBuy,
                        u.Price,
                        u.AP_PharmcyDrugAnbar.MESCCode_No,
                        u.AP_PharmcyDrugAnbar.OldID,
                        u.ExpireDate,
                        u.NumPageProduct,
                        u.Pack,
                        u.FactorM.Company.CompanyName,
                        u.FactorM.Company.Responsible,
                        u.FactorM.FactorNumber,
                        u.FactorM.FactorDate,
                        u.AP_PharmcyDrugAnbar.Shape,
                        u.FactorM.DrugTransferee.LName,
                        u.FactorM.Company.Adreess,
                        u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName,
                        u.FactorM.CreationDate,
                        u.FactorM.NeedDate,
                        NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.FactorM.DemandNumber == null ? "" : u.FactorM.DemandNumber,
                        Ordernum1 = u.FactorM.Ordernum == null ? "" : u.FactorM.Ordernum,
                        ReceiptNumber1 = u.FactorM.ReceiptNumber == null ? "" : u.FactorM.ReceiptNumber,
                        MESCCode_No1 = u.MESCCode_No == null ? "" : u.MESCCode_No
                    };
            stiReport4.Dictionary.Variables.Add("SumPrice", q.Sum(f => f.Price));
            stiReport4.Dictionary.Variables.Add("SumAmountBuy", q.Sum(f => f.AmountBuy));
            stiReport4.Dictionary.Variables.Add("countq", q.Count());
            stiReport4.RegData("Drugs", q.ToList());
            stiReport4.RegData("Drugs1", q.Take(13));
            stiReport4.RegData("Drugs2", q.Skip(13));
            stiReport4.Compile();
            stiReport4.CompiledReport.ShowWithRibbonGUI();
            //  stiReport4.ShowWithRibbonGUI();
            //   stiReport4.Design();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (lst.Any(c => c.FactorM.AwardFactor == false))
            { MessageBox.Show("درخواست چاپ MT31 شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new
                    {
                        Service = u.AP_PharmcyDrugAnbar == null ? "" : u.AP_PharmcyDrugAnbar.Name,
                        u.AmountBuy,
                        u.Price,
                        u.AP_PharmcyDrugAnbar.MESCCode_No,
                        u.AP_PharmcyDrugAnbar.OldID,
                        u.ExpireDate,
                        u.NumPageProduct,
                        u.Pack,
                        u.FactorM.Company.CompanyName,
                        u.FactorM.Company.Responsible,
                        u.FactorM.FactorNumber,
                        u.FactorM.FactorDate,
                        u.AP_PharmcyDrugAnbar.Shape,
                        u.FactorM.DrugTransferee.LName,
                        u.FactorM.Company.Adreess,
                        u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName,
                        u.FactorM.NeedDate,
                        u.FactorM.CreationDate,
                        NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.FactorM.DemandNumber == null ? "" : u.FactorM.DemandNumber,
                        Ordernum1 = u.FactorM.Ordernum == null ? "" : u.FactorM.Ordernum,
                        ReceiptNumber1 = u.FactorM.ReceiptNumber == null ? "" : u.FactorM.ReceiptNumber,
                        MESCCode_No1 = u.MESCCode_No == null ? "" : u.MESCCode_No

                    };

            stiReport3.Dictionary.Variables.Add("SumPrice", q.Sum(f => f.Price));
            stiReport3.Dictionary.Variables.Add("SumAmountBuy", q.Sum(f => f.AmountBuy));
            stiReport3.Dictionary.Variables.Add("countq", q.Count());
            stiReport3.RegData("Drugs", q.ToList());
            stiReport3.RegData("Drugs1", q.Take(8));
            stiReport3.RegData("Drugs2", q.Skip(8));

            stiReport3.Compile();
            stiReport3.CompiledReport.ShowWithRibbonGUI();
            //  stiReport3.ShowWithRibbonGUI();
            //stiReport3.Design();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = factorMBindingSource.Current as FactorM;

            dc.Dispose();
            dc = new HCISDataContexDataContext();
            var row1 = dc.FactorMs.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.FactorMs.DeleteOnSubmit(row1);
            var allDrow = dc.FactorDs.Where(x => x.FactorMID == row.ID);
            dc.FactorDs.DeleteAllOnSubmit(allDrow);
            dc.SubmitChanges();
            GetData();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            factorMBindingSource.EndEdit();
            dc.SubmitChanges();
            GetData();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            factorMBindingSource.DataSource = dc.FactorMs.Where(c => c.FactorDate.CompareTo(txtFromDate.Text) >= 0 && c.FactorDate.CompareTo(txtToDate.Text) <= 0)
            .OrderByDescending(c => c.FactorDate).ThenByDescending(c => c.CreationTime)
            .ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            factorMBindingSource.DataSource = dc.FactorMs.Where(c => c.FactorDate.CompareTo(txtFromDate.Text) >= 0 && c.FactorDate.CompareTo(txtToDate.Text) <= 0)
       .OrderByDescending(c => c.FactorDate).ThenByDescending(c => c.CreationTime)
       .ToList();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            lst = dc.FactorDs.Where(x => x.FactorMID == current.ID &&
            (x.AP_PharmcyDrugAnbar.MESCCode_No == null || x.AP_PharmcyDrugAnbar.MESCCode_No == "" || x.AP_PharmcyDrugAnbar.MESCCode_No == " " || x.AP_PharmcyDrugAnbar.MESCCode_No == "  " || x.AP_PharmcyDrugAnbar.MESCCode_No == "   ")

            ).OrderBy(c => c.IDint).ToList();
            if (lst.Any(c => c.FactorM.AwardFactor == true))
            { MessageBox.Show("درخواست چاپ MT49 شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new
                    {
                        Service = u.AP_PharmcyDrugAnbar == null ? "" : u.AP_PharmcyDrugAnbar.Name
                    ,
                        u.AmountBuy,
                        u.Price,
                        u.AP_PharmcyDrugAnbar.MESCCode_No,
                        u.AP_PharmcyDrugAnbar.OldID,
                        u.ExpireDate,
                        u.NumPageProduct,
                        u.Pack,
                        u.FactorM.Company.CompanyName,
                        u.FactorM.Company.Responsible,
                        u.FactorM.FactorNumber,
                        u.FactorM.FactorDate,
                        u.AP_PharmcyDrugAnbar.Shape,
                        u.FactorM.DrugTransferee.LName,
                        u.FactorM.Company.Adreess,
                        u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName,
                        u.FactorM.NeedDate
                     ,
                        u.FactorM.CreationDate,
                        NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.FactorM.DemandNumber == null ? "" : u.FactorM.DemandNumber,
                        Ordernum1 = u.FactorM.Ordernum == null ? "" : u.FactorM.Ordernum,
                        ReceiptNumber1 = u.FactorM.ReceiptNumber == null ? "" : u.FactorM.ReceiptNumber,
                        MESCCode_No1 = u.MESCCode_No == null ? "" : u.MESCCode_No
                    };
            stiReport5.Dictionary.Variables.Add("SumPrice", q.Sum(f => f.Price));
            stiReport5.Dictionary.Variables.Add("SumAmountBuy", q.Sum(f => f.AmountBuy));
            stiReport5.Dictionary.Variables.Add("countq", q.Count());
            stiReport5.RegData("Drugs", q.ToList());

            stiReport5.RegData("Drugs1", q.Take(10));
            stiReport5.RegData("Drugs2", q.Skip(10));

            stiReport5.Compile();
            stiReport5.CompiledReport.ShowWithRibbonGUI();
            //  stiReport5.ShowWithRibbonGUI();
            //   stiReport5.Design();
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            lst = dc.FactorDs.Where(x => x.FactorMID == current.ID &&
              (x.AP_PharmcyDrugAnbar.MESCCode_No == null || x.AP_PharmcyDrugAnbar.MESCCode_No == "" || x.AP_PharmcyDrugAnbar.MESCCode_No == " " || x.AP_PharmcyDrugAnbar.MESCCode_No == "  " || x.AP_PharmcyDrugAnbar.MESCCode_No == "   ")
            ).OrderBy(c => c.IDint).ToList();
            if (lst.Any(c => c.FactorM.AwardFactor == true))
            { MessageBox.Show("درخواست چاپ MT49 شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new
                    {
                        Service = u.AP_PharmcyDrugAnbar == null ? "" :
                        u.AP_PharmcyDrugAnbar.Name,
                        u.AmountBuy,
                        u.Price,
                        MESCCode_No = u.AP_PharmcyDrugAnbar.MESCCode_No == null ? "" : u.AP_PharmcyDrugAnbar.MESCCode_No,
                        // u.AP_PharmcyDrugAnbar.OldID,
                        ExpireDate = u.ExpireDate == null ? "" : u.ExpireDate,
                        //u.NumPageProduct,
                        // Pack =  u.Pack == null ? "" : u.Pack == null,
                        CompanyName = u.FactorM.Company.CompanyName == null ? "" : u.FactorM.Company.CompanyName,
                        Responsible = u.FactorM.Company.Responsible == null ? "" : u.FactorM.Company.Responsible,
                        FactorNumber = u.FactorM.FactorNumber == null ? "" : u.FactorM.FactorNumber,
                        FactorDate = u.FactorM.FactorDate == null ? "" : u.FactorM.FactorDate,
                        Shape = u.AP_PharmcyDrugAnbar.Shape == null ? "" : u.AP_PharmcyDrugAnbar.Shape,
                        LName = u.FactorM.DrugTransferee.LName == null ? "" : u.FactorM.DrugTransferee.LName,
                        Adreess = u.FactorM.Company.Adreess == null ? "" : u.FactorM.Company.Adreess,
                        MeasurementName = u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName == null ? "" : u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName,
                        CreationDate = u.FactorM.CreationDate == null ? "" : u.FactorM.CreationDate,
                        NeedDate = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.FactorM.DemandNumber == null ? "" : u.FactorM.DemandNumber,
                        Ordernum1 = u.FactorM.Ordernum == null ? "" : u.FactorM.Ordernum,
                        ReceiptNumber1 = u.FactorM.ReceiptNumber == null ? "" : u.FactorM.ReceiptNumber,
                        MESCCode_No1 = u.MESCCode_No == null ? "" : u.MESCCode_No

                    };
            stiReport6.Dictionary.Variables.Add("SumPrice", q.Sum(f => f.Price));
            stiReport6.Dictionary.Variables.Add("SumAmountBuy", q.Sum(f => f.AmountBuy));
            stiReport6.Dictionary.Variables.Add("countq", q.Count());
            stiReport6.RegData("Drugs", q.ToList());
            stiReport6.RegData("Drugs1", q.Take(9));
            stiReport6.RegData("Drugs2", q.Skip(9));
            stiReport6.Compile();
            stiReport6.CompiledReport.ShowWithRibbonGUI();
            //  stiReport6.ShowWithRibbonGUI();
            // stiReport6.Design();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            factorMBindingSource.EndEdit();
            dc.SubmitChanges();
        }

        private void barButtonItem30_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cu = factorMBindingSource.Current as FactorM;
            if (cu == null) { return; }
            var dlg = new frmEDit();
            dlg.ofm = cu;
            dlg.Text = "ویرایش فاکتور";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var i = barEditItem1.EditValue.ToString();
            if (i == null)
                return;
            var dlg = new frmtaghaza();

            dlg.taghazaa = i;
            dlg.Text = "چاپ بر اساس شماره تقاضا";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = factorMBindingSource.Current as FactorM;
            if (current == null)
            {
                return;
            }
            lst = dc.FactorDs.Where(x => x.FactorMID == current.ID
            && x.AP_PharmcyDrugAnbar.MESCCode_No != null && x.AP_PharmcyDrugAnbar.MESCCode_No != "" && x.AP_PharmcyDrugAnbar.MESCCode_No != " "
            && x.AP_PharmcyDrugAnbar.MESCCode_No != "  "
            ).OrderBy(c => c.IDint).ToList();
            if (lst.Any(c => c.FactorM.AwardFactor == true))
            { MessageBox.Show("درخواست چاپ MT49 شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            var q = from u in lst
                    select new
                    {
                        Service = u.AP_PharmcyDrugAnbar == null ? "" :
                    u.AP_PharmcyDrugAnbar.Name,
                        u.AmountBuy,
                        u.Price,
                        u.AP_PharmcyDrugAnbar.MESCCode_No,
                        u.AP_PharmcyDrugAnbar.OldID,
                        u.ExpireDate,
                        u.NumPageProduct,
                        u.Pack,
                        u.FactorM.Company.CompanyName,
                        u.FactorM.Company.Responsible,
                        u.FactorM.FactorNumber,
                        u.FactorM.FactorDate,
                        u.AP_PharmcyDrugAnbar.Shape,
                        u.FactorM.DrugTransferee.LName,
                        u.FactorM.Company.Adreess,
                        u.AP_PharmcyDrugAnbar.MeasurementDefinition.MeasurementName,
                        u.FactorM.CreationDate,
                        u.FactorM.NeedDate,
                        NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.FactorM.DemandNumber == null ? "" : u.FactorM.DemandNumber,
                        Ordernum1 = u.FactorM.Ordernum == null ? "" : u.FactorM.Ordernum,
                        ReceiptNumber1 = u.FactorM.ReceiptNumber == null ? "" : u.FactorM.ReceiptNumber,
                        MESCCode_No1 = u.MESCCode_No == null ? "" : u.MESCCode_No

                    };
            stiReport6.Dictionary.Variables.Add("SumPrice", q.Sum(f => f.Price));
            stiReport6.Dictionary.Variables.Add("SumAmountBuy", q.Sum(f => f.AmountBuy));
            stiReport6.Dictionary.Variables.Add("countq", q.Count());
            stiReport6.RegData("Drugs", q.ToList());
            stiReport6.RegData("Drugs1", q.Take(9));
            stiReport6.RegData("Drugs2", q.Skip(9));
            stiReport6.Compile();
            stiReport6.CompiledReport.ShowWithRibbonGUI();
            //  stiReport6.ShowWithRibbonGUI();
            // stiReport6.Design();
        }
    }
}
