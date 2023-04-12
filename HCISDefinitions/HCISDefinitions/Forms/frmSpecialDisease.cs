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
    public partial class frmSpecialDisease : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmSpecialDisease()
        {
            InitializeComponent();
        }

        private void frmSpecialDisease_Load(object sender, EventArgs e)
        {
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.OrderBy(c => c.Name).ToList();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new dlgSpecialDisease();
            dlg.dc = dc;
            dlg.Text = "جدید";
            dlg.ShowDialog();
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = specialDiseaseBindingSource.Current as SpecialDisease;
            if (cur == null)
                return;

            var dlg = new dlgSpecialDisease();
            dlg.dc = dc;
            dlg.SelectedSD = cur;
            dlg.Text = "ویرایش";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.OrderBy(c => c.Name).ToList();
                gridControl1.RefreshDataSource();
            }
            else
            {
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.SelectedSD);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = specialDiseaseBindingSource.Current as SpecialDisease;
            if (cur == null)
                return;

            dc.SpecialDiseases.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            specialDiseaseBindingSource.DataSource = dc.SpecialDiseases.OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}