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
using HCISSurgery.Data;
using HCISSurgery.Dialogs;
using HCISSurgery.Classes;

namespace HCISSurgery.Forms
{  
    public partial class frmModularSurgeryDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISSurgeryDataClassesDataContext dc = new HCISSurgeryDataClassesDataContext();

        public frmModularSurgeryDefinition()
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
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Service1.Name == "خدمات تعدیلی").OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }
        private void EndEdit()
        {
            serviceBindingSource.EndEdit();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgModularSurgeryDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        } 

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = serviceBindingSource.Current as Service;
            var dlg = new dlgModularSurgeryDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectSRV = current;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISSurgeryDataClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = serviceBindingSource.Current as Service;
            dc.Dispose();
            dc = new HCISSurgeryDataClassesDataContext();
            row = dc.Services.FirstOrDefault(x => x.ID == row.ID);
            if (row.Tariffs.Any() || row.SampleAnswers.Any() || row.Agendas.Any(x => x.Deleted == false || x.Deleted == null) || row.FavoriteServices.Any() || row.GivenServiceDs.Any() || row.FactorDs.Any() || row.ModularServices.Any() || row.PatternDs.Any() || row.PatternMs.Any() || row.Services.Any())
            {
                MessageBox.Show("برای این خدمت اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Services.DeleteOnSubmit(row);

            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}