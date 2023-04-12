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

namespace HCISSecondWard.Forms
{

    public partial class frmConsumerGoodsTemplate : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmConsumerGoodsTemplate()
        {
            InitializeComponent();
        }

        private void frmConsumerGoodsTemplate_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 12);
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID && x.Service.CategoryID == 12).ToList();

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode.HasChildren)
                return;

            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;

            if(dc.DrugTempelateForWards.Any(x => x.Service.ID == current.ID && x.WardID == Classes.MainModule.MyDepartment.ID))
            {
                MessageBox.Show("این سرویس وجود دارد");
                return;
            }
            var Ctemp = new DrugTempelateForWard
            {
                WardID = Classes.MainModule.MyDepartment.ID,
                DrugID = current.ID,
                Amount = 1,
            };

            dc.DrugTempelateForWards.InsertOnSubmit(Ctemp);
            dc.SubmitChanges();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID && x.Service.CategoryID == 12).ToList();

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = drugTempelateForWardBindingSource.Current as DrugTempelateForWard;
            if (current == null)
                return;
            if (MessageBox.Show("ایا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            dc.DrugTempelateForWards.DeleteOnSubmit(current);
            dc.SubmitChanges();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID && x.Service.CategoryID == 12).ToList();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}