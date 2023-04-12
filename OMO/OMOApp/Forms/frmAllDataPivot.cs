using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OMOApp.Forms
{
    public partial class frmAllDataPivot : DevExpress.XtraEditors.XtraForm
    {
        public frmAllDataPivot()
        {
            InitializeComponent();
        }
       
      
        private void frmAllDataPivot_Load(object sender, EventArgs e)
        {
                 }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pivotGridControl1.ExportToXlsx(saveFileDialog1.FileName);

                    MessageBox.Show("ذخیره شد");
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا");
                }
            }
         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            vwAllDataBindingSource.DataSource = new Data.OMOClassesDataContext().Vw_AllDatas.Where(x=>x.AdmitDate.CompareTo(txtFrom.Text)>=0 && x.AdmitDate.CompareTo(txtTo.Text)<=0).ToList();

        }
    }
}