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
using HCISAngio.Data;
using HCISAngio.Dialogs;
using HCISAngio.Classes;

namespace HCISAngio.Forms
{  
    public partial class frmSuppliesPanelDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISAngioDataClassesDataContext dc = new HCISAngioDataClassesDataContext();

        public frmSuppliesPanelDefinition()
        {
            InitializeComponent();
        }

        private void frmServiceDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            EndEdit();
            patternMBindingSource.DataSource = dc.PatternMs.Where(x => x.Service != null && (x.Service.CategoryID == (int)Category.آنژیوگرافی || x.Service.CategoryID == (int)Category.آنژیوپلاستی)
            && x.PatternDs.Any()
            && x.PatternDs.FirstOrDefault().Service != null
            && x.PatternDs.FirstOrDefault().Service.CategoryID == (int)Category.لوازم_مصرفی).OrderByDescending(c => c.Time).OrderByDescending(c => c.Date).ToList();
            gridControl1.RefreshDataSource();
        }
        private void EndEdit()
        {
            patternMBindingSource.EndEdit();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSuppliesPanelDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        } 

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = patternMBindingSource.Current as PatternM;
            var dlg = new dlgSuppliesPanelDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectPTM = current;
            dlg.isEdit = true;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISAngioDataClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = patternMBindingSource.Current as PatternM;
            dc.Dispose();
            dc = new HCISAngioDataClassesDataContext();
            var row = dc.PatternMs.FirstOrDefault(x => x.ID == cur.ID);
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            foreach (var item in row.PatternDs)
            {
                dc.PatternDs.DeleteOnSubmit(item);
            }
            dc.PatternMs.DeleteOnSubmit(row);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}