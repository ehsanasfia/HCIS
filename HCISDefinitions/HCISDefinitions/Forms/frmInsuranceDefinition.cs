using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;
using HCISDefinitions.Dialogs;

namespace HCISDefinitions.Forms
{
    public partial class frmInsuranceDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmInsuranceDefinition()
        {
            InitializeComponent();
        }

        private void frmInsuranceDefinition_Load(object sender, EventArgs e)
        {
            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgInsuranceDefinition();
            dlg.dc = dc;
            dlg.Text = "جدید";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = insuranceBindingSource.Current as Insurance;
            if (cur == null)
                return;

            var dlg = new dlgInsuranceDefinition();
            dlg.dc = dc;
            dlg.ObjectInsur = cur;
            dlg.Text = "ویرایش";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dc.SubmitChanges();
                insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
                gridControl1.RefreshDataSource();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = insuranceBindingSource.Current as Insurance;
            if (cur == null)
                return;
            if(cur.DoctorInsurances.Any() || cur.GivenServiceMs.Any() || cur.Insurances.Any() || cur.Tariffs.Any())
            {
                MessageBox.Show("برای این مورد اطلاعات ثبت شده و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Insurances.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            insuranceBindingSource.DataSource = dc.Insurances.OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}