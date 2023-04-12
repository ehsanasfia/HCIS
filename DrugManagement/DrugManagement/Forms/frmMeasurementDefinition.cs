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
using DrugManagement.Dialogs;
using DrugManagement.Forms;
namespace DrugManagement.Forms
{
    public partial class frmMeasurementDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public frmMeasurementDefinition()
        {
            InitializeComponent();
        }

        private void frmMeasurementDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            measurementDefinitionBindingSource.DataSource = dc.MeasurementDefinitions.ToList();
            gridControl1.RefreshDataSource();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgMeasurementDefinition();
            dlg.Text = "جدید";
            dlg.dc = dc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                dc.SubmitChanges();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = measurementDefinitionBindingSource.Current as MeasurementDefinition;
            dc.Dispose();
            dc = new HCISDataContexDataContext();
            row = dc.MeasurementDefinitions.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;



            dc.MeasurementDefinitions.DeleteOnSubmit(row);

            dc.SubmitChanges();
            GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var current = measurementDefinitionBindingSource.Current as MeasurementDefinition;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgMeasurementDefinition();
            a.dc = dc;
            a.isEdit = true;
            a.PHT = current;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                GetData();
            }
            else
            {
                dc.Dispose();
                dc = new HCISDataContexDataContext();
                GetData();
            }
        }
    }
}