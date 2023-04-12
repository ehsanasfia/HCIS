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
using Stimulsoft.Report;

namespace OccupationalMedicine.Forms
{
    public partial class frm111_3Rrpt : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        public frm111_3Rrpt()
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


            if (ContractLkp.EditValue == null || ContractLkp.EditValue.GetType() == typeof(DBNull))
            {
                v1113FormBindingSource.DataSource = null;
                return;
            }
            var cntNumber = (ContractLkp.EditValue as Contract).ContractNumber;
            v1113FormBindingSource.DataSource = dc.V111_3Forms.Where(x => x.ContractNumber == cntNumber);
            GetContractInfo();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cntNumber = (ContractLkp.EditValue as Contract).ContractNumber;

            var x = dc.V111_3Forms.Where(x1 => x1.ContractNumber == cntNumber);

            ////add variavble to stimulsoft
            //  for (int u = 0; u < 2; u++)
            //for (int i = 10; i < 58; i++)
            //for (int j = 0; j < 3; j++)

            //        for (int n = 0; n < 2; n++)
            //        { stiReport1.Dictionary.Variables.Add(new Stimulsoft.Report.Dictionary
            //            .StiVariable("Category", "A" + i.ToString()+j.ToString()+n.ToString() , typeof(string), "", false));

            //        }

            stiReport1.Compile();
            for (int u = 0; u < 2; u++)
                for (int i = 10; i < 58; i++)
                    for (int j = 0; j < 3; j++)

                        for (int n = 0; n < 2; n++)
                        {
                           
                            stiReport1.CompiledReport["A" + i.ToString() + j.ToString() + n.ToString()] ="-";

                        }
            //try
            //{
                foreach (var item in x)
                    stiReport1.CompiledReport[item.ItemCode.ToString()] = item.Count.ToString();
                int SumZan = 0;
            if (x.Any(u => u.Sex == "زن"))
            {
                SumZan = (int)x.Where(u => u.Sex == "زن").Sum(t => t.Count);
                stiReport1.CompiledReport["SumZan"] = SumZan.ToString();
            }
        
            else
                stiReport1.CompiledReport["SumZan"] = "0";
               
            int SumMard = 0;
            if (x.Any(u => u.Sex == "مرد"))
            {
                SumMard = (int)x.Where(u => u.Sex == "مرد").Sum(t => t.Count);
                stiReport1.CompiledReport["SumMard"] = SumMard.ToString();
            }
            else
                stiReport1.CompiledReport["SumMard"] = "0";

            int SumBimar = 0;
            if (x.Any(o => !o.ItemCode.Contains("XXX")))
            {
                SumBimar = (int)x.Where(o => !o.ItemCode.Contains("XXX")).Sum(s => s.Count);

                stiReport1.CompiledReport["SumBimar"] = SumBimar.ToString();
            }
            else
                stiReport1.CompiledReport["SumBimar"] = "0";
                stiReport1.CompiledReport["Year"] = txtdate.Text.ToString(); //(ContractLkp.EditValue as Contract).FromDate;
                stiReport1.CompiledReport["University"] = (ContractLkp.EditValue as Contract).University;
            stiReport1.CompiledReport["CountractAddress"] = (ContractLkp.EditValue as Contract).Address;

            
                // stiReport1.CompiledReport.ShowWithRibbonGUI();
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    stiReport1.CompiledReport.ShowWithRibbonGUI();

            //    stiReport1.CompiledReport.ExportDocument(StiExportFormat.Word2007, saveFileDialog1.FileName + ".docx");
            //}
            //else { 
            stiReport1.CompiledReport.ShowWithRibbonGUI();
         
            //}
            //catch {

            //}
        }
    }
}