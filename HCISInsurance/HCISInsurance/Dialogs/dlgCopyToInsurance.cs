using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISInsurance.Data;

namespace HCISInsurance.Dialogs
{
    public partial class dlgCopyToInsurance : DevExpress.XtraEditors.XtraForm
    {
        private HCISClassesDataContext dc;
        private List<ServiceCategory> lstCat;
        private List<Insurance> lstIns;

        public dlgCopyToInsurance(HCISClassesDataContext dc)
        {
            InitializeComponent();
            this.dc = dc;
        }

        private void dlgCopyToInsurance_Load(object sender, EventArgs e)
        {
            lstCat = dc.ServiceCategories.ToList();
            lstIns = dc.Insurances.OrderBy(x => x.Name).ToList();

            serviceCategoryBindingSource.DataSource = lstCat;
            insuranceBindingSource.DataSource = lstIns;
            insuranceBindingSource1.DataSource = lstIns;

            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                
                List<ServiceCategory> lstSelectedCats = chkCmbCategory.Properties.Items
                    .OfType<DevExpress.XtraEditors.Controls.CheckedListBoxItem>()
                    .Where(c => c.CheckState == CheckState.Checked && c.Value != null)
                    .Select(x => lstCat.FirstOrDefault(y => y.ID == Convert.ToInt32(x.Value)))
                    .Where(x => x != null)
                    .ToList();

                if (!lstSelectedCats.Any())
                {
                    MessageBox.Show("لطفا حداقل یک گروه خدمتی را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var fromIns = slkFromIns.EditValue as Insurance;
                var toIns = slkToIns.EditValue as Insurance;
                if (fromIns == null || toIns == null)
                {
                    MessageBox.Show("لطفا متعهد ها را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (fromIns.ID == toIns.ID)
                {
                    MessageBox.Show("متعهد ها نمیتوانند یکسان باشند.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var lstCatIDs = lstSelectedCats.Select(x => x.ID).ToList();
                var lstTff = dc.ViewTariffCompletes.Where(x => x.TariffID != null && x.CategoryID != null && x.InsuranceID == fromIns.ID && lstCatIDs.Contains(x.CategoryID.Value)).ToList();

                var lstToInsert = new List<Tariff>();

                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                int i = 1;
                int total = lstTff.Count;
                foreach (var trf in lstTff)
                {
                    var myTrf = new Tariff()
                    {
                        Date = trf.Date,
                        InsuranceID = toIns.ID,
                        Lock = true,
                        FreePrice=trf.FreePrice,
                        GovernmentalPrice=trf.GovernmentalPrice,
                        OrganizationShare = trf.OrganizationShare,
                        Difference=trf.Difference??0,
                        PatientShare = trf.PatientShare,
                        ServiceID = trf.ServiceID,
                        TotalPrice = trf.TotalPrice
                    };
                    lstToInsert.Add(myTrf);

                    progressBarControl1.EditValue = (i / total) * 100;
                    i++;
                }

                dc.Tariffs.InsertAllOnSubmit(lstToInsert);
                dc.SubmitChanges();
                MessageBox.Show("تعرفه های جدید با موفقیت ثبت شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }
    }
}