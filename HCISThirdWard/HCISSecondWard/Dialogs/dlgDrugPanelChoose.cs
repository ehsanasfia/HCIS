using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgDrugPanelChoose : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public List<DrugTempelateForWard> lstDP { get; set; }
        public dlgDrugPanelChoose()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            foreach (var item in gridView1.GetSelectedRows())
            {
                var drug = gridView1.GetRow(item) as DrugTempelateForWard;
                lstDP.Add(drug);
            }
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgDrugPanelChoose_Load(object sender, EventArgs e)
        {
            lstDP = new List<DrugTempelateForWard>();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == MainModule.MyDepartment.ID && x.Service.CategoryID == 4);
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            gridView1.CloseEditor();
            dc.SubmitChanges();
        }

        private void dlgDrugPanelChoose_Shown(object sender, EventArgs e)
        {
            gridView1.SelectAll();
        }
    }
}