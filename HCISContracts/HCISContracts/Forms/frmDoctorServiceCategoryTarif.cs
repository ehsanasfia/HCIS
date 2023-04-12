using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISContracts.Data;

namespace HCISContracts.Forms
{
    public partial class frmDoctorServiceCategoryTarif : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Data.HCISDataContexDataContext dc = new Data.HCISDataContexDataContext();
        List<DoctorServiceCategoryTariff> lst = new List<DoctorServiceCategoryTariff>();

        public frmDoctorServiceCategoryTarif()
        {
            InitializeComponent();
            doctorServiceCategoryTariffBindingSource.DataSource = dc.DoctorServiceCategoryTariffs;

        }

        private void frmDoctorServiceCategoryTarif_Load(object sender, EventArgs e)
        {
            FilterList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FilterList();
        }

        private void FilterList()
        {
            if (spinEdit1.Value.ToString() == "" /*|| lkpMounth.Text == ""*/)
                return;

            //string d = string.Format("{0}/{1}", spinEdit1.Text.ToString(), lkpMounth.Text);

            if (radioGroup1.SelectedIndex == 0)
            {
                doctorServiceCategoryTariffBindingSource.DataSource = dc.DoctorServiceCategoryTariffs.Where(x => x.Year == spinEdit1.Value.ToString() && x.DoctorPaymentCategory.ForOffical == true);
                doctorPaymentCategoryBindingSource.DataSource = dc.DoctorPaymentCategories.Where(x => x.ForOffical == true && x.Hide != true).ToList();
            }
            else
            {
                doctorServiceCategoryTariffBindingSource.DataSource = dc.DoctorServiceCategoryTariffs.Where(x => x.Year == spinEdit1.Value.ToString() && x.DoctorPaymentCategory.ForNonOffical == true);
                doctorPaymentCategoryBindingSource.DataSource = dc.DoctorPaymentCategories.Where(x => x.ForNonOffical == true && x.Hide != true).ToList();
            }
            gridControl1.RefreshDataSource();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                gridView1.CloseEditor();
                doctorServiceCategoryTariffBindingSource.EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقیت ذخیره شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItemNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            doctorServiceCategoryTariffBindingSource.AddNew();
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterList();
        }
    }
}