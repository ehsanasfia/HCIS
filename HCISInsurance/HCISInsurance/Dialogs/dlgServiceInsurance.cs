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
    public partial class dlgServiceInsurance : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc = new HCISClassesDataContext();
        public Boolean isEdit { get; set; }
        public ServiceInsuranc EditingServiceInsurance { get; set; }
        public dlgServiceInsurance()
        {
            InitializeComponent();
        }

        private void dlgServiceInsurance_Load(object sender, EventArgs e)
        {          
            if (!isEdit)
                EditingServiceInsurance = new ServiceInsuranc();
            serviceInsurancBindingSource.DataSource = EditingServiceInsurance;
            serviceBindingSource.DataSource = dc.Services.ToList();
            insuranceBindingSource.DataSource = dc.Insurances.Where(x=>x.ParentID!=null).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                serviceInsurancBindingSource.EndEdit();
                dc.SubmitChanges();
                this.Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                var ServiceInsuranclist = dc.ServiceInsurancs.ToList();
                var Insurance = slkInsurance.EditValue;
                var Service = lkpServiceCode.EditValue;
                foreach (var item in ServiceInsuranclist)
                {
                    if(item.Insurance==Insurance && item.Service==Service)
                    {
                        MessageBox.Show("خدمت وارد شده تکراری است.");
                        return;
                    }
                }
                serviceInsurancBindingSource.EndEdit();
                EditingServiceInsurance.Time = DateTime.Now.ToString("hh:mm");
                EditingServiceInsurance.Date = MainModule.GetPersianDate(DateTime.Now);
                dc.ServiceInsurancs.InsertOnSubmit(EditingServiceInsurance);
                dc.SubmitChanges();
                this.Close();
                DialogResult = DialogResult.OK;
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}