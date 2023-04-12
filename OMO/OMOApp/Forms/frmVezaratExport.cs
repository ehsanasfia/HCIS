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

namespace OMOApp.Forms
{
    public partial class frmVezaratExport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmVezaratExport()
        {
            InitializeComponent();
        }

        Data.OMOClassesDataContext dc = new Data.OMOClassesDataContext();

        private void frmExcelExport_Load(object sender, EventArgs e)
        {
            
            var x = new Data.ManageMent() { IDMg = -1, Name = "همه" };
            List<Data.ManageMent> LstManage = new List<Data.ManageMent>();
            LstManage.Add(x);
             LstManage.AddRange( dc.ManageMents.ToList());
            manageMentBindingSource.DataSource = LstManage;
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
                var x = new Data.Company() { IDCo = -1, Name = "همه" };
                List<Data.Company> LstCom = new List<Data.Company>();
                LstCom.Add(x);
                LstCom.AddRange(dc.Companies.Where(c => c.IDManagement == Int32.Parse(slkChooseManagment.EditValue.ToString())));
                companyBindingSource.DataSource = LstCom;
           //     barButtonItem1.Enabled = true;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int IDManag = -2;
            int IDCom = -2;
            if (slkChooseManagment.EditValue as int? !=null)
             IDManag = Int32.Parse(slkChooseManagment.EditValue.ToString());
            if(IDManag!=-1)
                  if (lkpCompany.EditValue as int? != null)
                IDCom = Int32.Parse(lkpCompany .EditValue.ToString());
            dc.CommandTimeout=500000;
            try
            {
              if  (IDManag == -1 || IDManag == -2)
                    vwVezaratBindingSource.DataSource = dc.Vw_Vezarats.Where(c=>c.AdmitDate.CompareTo(FromDate.Text)>=0 && c.AdmitDate .CompareTo(ToDate.Text )<=0).ToList();
              else if (IDCom == -1 || IDCom == -2)
   vwVezaratBindingSource.DataSource = dc.Vw_Vezarats .Where(c =>c.IDManagement==Int32.Parse(slkChooseManagment .EditValue.ToString()) && c.AdmitDate.CompareTo(FromDate.Text) >= 0 && c.AdmitDate.CompareTo(ToDate.Text) <= 0);
              else
                vwVezaratBindingSource.DataSource = dc.Vw_Vezarats .Where(c =>( (c.IDManagement==Int32.Parse(slkChooseManagment .EditValue.ToString()))) &&  ( c.IDCompany == Int32.Parse(lkpCompany.EditValue.ToString())) && c.AdmitDate.CompareTo(FromDate.Text) >= 0 && c.AdmitDate.CompareTo(ToDate.Text) <= 0);
                gridView1.BestFitColumns();
                barButtonItem1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}