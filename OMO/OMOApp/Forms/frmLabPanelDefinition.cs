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
using OMOApp.Data;
using OMOApp.Dialogs;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmLabPanelDefinition : DevExpress.XtraEditors.XtraForm
    {
        OMOClassesDataContext dc = new OMOClassesDataContext();

        public frmLabPanelDefinition()
        {
            InitializeComponent();
        }

        private void frmLabPanelDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            EndEdit();
            patternBindingSource.DataSource = dc.Patterns.GroupBy(c => c.PatternName).OrderBy(c => c.Key).ToList();
            gridControl1.RefreshDataSource();
        }

        private void EndEdit()
        {
            patternBindingSource.EndEdit();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgLabPanelDefinition();
            dlg.Text = "جدید";
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var current = patternBindingSource.Current as Pattern;
            //if (current == null)
            //{
            //    MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}

            //var dlg = new dlgLabPanelDefinition();
            //dlg.Text = "ویرایش";
            //dlg. = current;
            //dlg.isEdit = true;
            //if (dlg.ShowDialog() == DialogResult.OK)
            //    GetData();
            //else
            //{
            //    dc.Dispose();
            //    dc = new HCISSurgeryDataClassesDataContext();
            //    GetData();
            //}
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = patternBindingSource.Current as IGrouping<string, Pattern>;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Dispose();
            dc = new OMOClassesDataContext();
            var rows = dc.Patterns.Where(x => x.PatternName == cur.Key).ToList();
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            
            dc.Patterns.DeleteAllOnSubmit(rows);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 2)
            {
                var cur = patternBindingSource.Current as IGrouping<string, Pattern>;
                if (cur == null)
                    return;

                var dlg = new dlgLabServiceList();
                dlg.ObjectPTT = cur;
                dlg.ShowDialog();
            }
        }
    }
}