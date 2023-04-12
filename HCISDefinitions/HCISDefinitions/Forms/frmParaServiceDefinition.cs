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
using HCISDefinitions.Data;
using HCISDefinitions.Dialogs;

namespace HCISDefinitions.Forms
{  
    public partial class frmParaServiceDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmParaServiceDefinition()
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
            servicesBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.پاراکلینیکی).ToList();
            gridControl1.RefreshDataSource();
        }
        private void EndEdit()
        {
            servicesBindingSource.EndEdit();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgParaServiceDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
        } 

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = servicesBindingSource.Current as Service;
            var dlg = new dlgParaServiceDefinition();
            dlg.Text = "ویرایش";
            dlg.dc = dc;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dlg.ObjectSRV = current;
            dlg.ObjectDSD = current.DiagnosticServiceDetail;

            if (dlg.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISDataClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = servicesBindingSource.Current as Service;
            dc.Dispose();
            dc = new HCISDataClassesDataContext();
            row = dc.Services.FirstOrDefault(x => x.ID == row.ID);
            if(row.Tariffs.Any() || row.SampleAnswers.Any() || row.Agendas.Any(x => x.Deleted == false || x.Deleted == null) || row.FavoriteServices.Any() || row.GivenServiceDs.Any())
            {
                MessageBox.Show("برای این خدمت اطلاعات ثبت شده است", "توجه" , MessageBoxButtons.OK , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            dc.Services.DeleteOnSubmit(row);
            var row2 = dc.DiagnosticServiceDetails.FirstOrDefault(x => x.ID == row.ID);
            if(row2 != null)
                dc.DiagnosticServiceDetails.DeleteOnSubmit(row2);
            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}