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
    public partial class frmtaghaza : DevExpress.XtraEditors.XtraForm
    {
        public string taghazaa { get; set; }
        public HCISDataContexDataContext dc { get; set; }
        List<spuOrderNumberDrugResult> lst = new List<spuOrderNumberDrugResult>();
        public frmtaghaza()
        {
            InitializeComponent();
        }

        private void frmtaghaza_Load(object sender, EventArgs e)
        {
            lst = dc.spuOrderNumberDrug(taghazaa).ToList();
            spuOrderNumberDrugResultBindingSource.DataSource = lst;

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

            lst = dc.spuOrderNumberDrug(taghazaa).Where(x =>
             x.SMESCCode_No != null && x.SMESCCode_No != "" && x.SMESCCode_No != " "
            && x.SMESCCode_No != "  "
            ).ToList();

            var q = from u in lst
                    select new
                    {

                        u.Name,
                        u.AmountBuy,
                        u.Price,
                        u.SMESCCode_No,
                        //u.OldID,
                        u.ExpireDate,
                        // u.NumPageProduct,
                        // u.Pack,
                        //  u.FactorM.Company.CompanyName,
                        //   u.FactorM.Company.Responsible,
                        //   u.FactorM.FactorNumber,
                        //  u.FactorM.FactorDate,
                        u.Shape,
                        //   u.FactorM.DrugTransferee.LName,
                        //    u.FactorM.Company.Adreess,
                        //   u.Service.MeasurementDefinition.MeasurementName,
                        //  u.FactorM.CreationDate,
                        //   u.FactorM.NeedDate,
                        //      NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.DemandNumber == null ? "" : u.DemandNumber,
                        Ordernum1 = u.Ordernum == null ? "" : u.Ordernum,
                        ReceiptNumber1 = u.ReceiptNumber == null ? "" : u.ReceiptNumber,
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
             //   stiReport6.Design();
        }

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
        {
            lst = dc.spuOrderNumberDrug(taghazaa).Where(x =>
                    (x.SMESCCode_No == null || x.SMESCCode_No == "" || x.SMESCCode_No == " " || x.SMESCCode_No == "  " || x.SMESCCode_No == "   ")
               ).ToList();
            var q = from u in lst
                    select new
                    {

                        u.Name,
                        u.AmountBuy,
                        u.Price,
                        u.SMESCCode_No,
                        //u.OldID,
                        u.ExpireDate,
                        // u.NumPageProduct,
                        // u.Pack,
                        //  u.FactorM.Company.CompanyName,
                        //   u.FactorM.Company.Responsible,
                        //   u.FactorM.FactorNumber,
                        //  u.FactorM.FactorDate,
                        u.Shape,
                        //   u.FactorM.DrugTransferee.LName,
                        //    u.FactorM.Company.Adreess,
                        //   u.Service.MeasurementDefinition.MeasurementName,
                        //  u.FactorM.CreationDate,
                        //   u.FactorM.NeedDate,
                        //      NeedDate1 = u.FactorM.NeedDate == null ? "" : u.FactorM.NeedDate,
                        DemandNumber1 = u.DemandNumber == null ? "" : u.DemandNumber,
                        Ordernum1 = u.Ordernum == null ? "" : u.Ordernum,
                        ReceiptNumber1 = u.ReceiptNumber == null ? "" : u.ReceiptNumber,
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
         //   stiReport6.Design();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

            lst = dc.spuOrderNumberDrug(taghazaa).Where(x =>
            x.SMESCCode_No != null && x.SMESCCode_No != "" && x.SMESCCode_No != " "
            && x.SMESCCode_No != "  ").ToList();
            var q = from u in lst
                    select new
                    {
                        u.Name,
                        u.AmountBuy,
                        u.Price,
                        u.SMESCCode_No,
                       // u.Service.OldID,
                        u.ExpireDate,
                      //  u.NumPageProduct,
                      //  u.Pack,
                      //  u.FactorM.Company.CompanyName,
                      //  u.FactorM.Company.Responsible,
                      //  u.FactorM.FactorNumber,
                       u.FactorDate,
                       u.Shape,
                       // u.FactorM.DrugTransferee.LName,
                    //    u.FactorM.Company.Adreess,
                        u.MeasurementName
                    ,
                        u.CreationDate,
                     
                        NeedDate1 = u.NeedDate == null ? "" : u.NeedDate,
                        DemandNumber1 = u.DemandNumber == null ? "" : u.DemandNumber,
                        Ordernum1 = u.Ordernum == null ? "" : u.Ordernum,
                        ReceiptNumber1 = u.ReceiptNumber == null ? "" : u.ReceiptNumber,
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
         // stiReport4.Design();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

            lst = dc.spuOrderNumberDrug(taghazaa).Where(x => 
            (x.SMESCCode_No == null || x.SMESCCode_No == "" || x.SMESCCode_No == " " || x.SMESCCode_No == "  " || x.SMESCCode_No == "   ")

            ).ToList();
            var q = from u in lst
                    select new
                    {
                        u.Name,
                        u.AmountBuy,
                        u.Price,
                        u.SMESCCode_No,
                     //   u.Service.OldID,
                        u.ExpireDate,
                       // u.NumPageProduct,
                       // u.Pack,
                       // u.FactorM.Company.CompanyName,
                       // u.FactorM.Company.Responsible,
                     //   u.FactorNumber,
                        u.FactorDate,
                        u.Shape,
                       // u.FactorM.DrugTransferee.LName,
                       // u.FactorM.Company.Adreess,
                        u.MeasurementName,
                        u.CreationDate,
                        NeedDate1 = u.NeedDate == null ? "" : u.NeedDate,
                        DemandNumber1 = u.DemandNumber == null ? "" : u.DemandNumber,
                        Ordernum1 = u.Ordernum == null ? "" : u.Ordernum,
                        ReceiptNumber1 = u.ReceiptNumber == null ? "" : u.ReceiptNumber,
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

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            lst = dc.spuOrderNumberDrug(taghazaa).ToList();
            var q = from u in lst
                    select new
                    {
                        u.Name,
                        u.AmountBuy,
                        u.Price,
                        u.SMESCCode_No,
                       // u.Service.OldID,
                        u.ExpireDate,
                      //  u.NumPageProduct,
                     //   u.Pack,
                      //  u.FactorM.Company.CompanyName,
                       // u.FactorM.Company.Responsible,
                    //    u.FactorM.FactorNumber,
                 //       u.FactorM.FactorDate,
                        u.Shape,
                      //  u.FactorM.DrugTransferee.LName,
                      //  u.FactorM.Company.Adreess,
                        u.MeasurementName,
                      
                        u.CreationDate,
                        NeedDate1 = u.NeedDate == null ? "" : u.NeedDate,
                        DemandNumber1 = u.DemandNumber == null ? "" : u.DemandNumber,
                        Ordernum1 = u.Ordernum == null ? "" : u.Ordernum,
                        ReceiptNumber1 = u.ReceiptNumber == null ? "" : u.ReceiptNumber,
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
        //   stiReport3.Design();
        }

        private void toolStripStatusLabel7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}