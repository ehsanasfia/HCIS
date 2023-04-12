using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISLab.Dialogs;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmTarrife : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        Tariff EditingTariff;
        public frmTarrife()
        {
            InitializeComponent();
        }

        private void frmWorkingList_Load(object sender, EventArgs e)
        {
            if(EditingTariff==null)
            EditingTariff = new Tariff();
            tariffBindingSource.DataSource = EditingTariff;
            var lst = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش ).ToList();
            servicesBindingSource.DataSource = lst;
            groupLkp.EditValue = lst.FirstOrDefault().ID;
           EditingTariff.ServiceID = lst.FirstOrDefault().ID;
            var lstIns = dc.Insurances.ToList();
            insuranceBindingSource.DataSource = lstIns;
            InsurnceLkp.EditValue = lstIns.FirstOrDefault().ID;
           EditingTariff.InsuranceID = lstIns.FirstOrDefault().ID;
        }
        void GetData()
        {
           
        }
        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void groupLkp_EditValueChanged(object sender, EventArgs e)
        {
            var gp =Guid.Parse( groupLkp.EditValue.ToString());
            if (gp == null)
            {
                // servicesChildGroupsBindingSource.DataSource = null;
                TariffbindingSource1.DataSource = null;
                return;
            }
            var lst = dc.Tariffs.Where(x => x.ServiceID == gp).ToList();
            TariffbindingSource1.DataSource = lst;
           
        }

        private void childGroupLkp_EditValueChanged(object sender, EventArgs e)
        {
              }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {try
            {
                EditingTariff.Date = ToDtp.Date.ToString();
                if (!dc.Tariffs.Any(d => d.ID == EditingTariff.ID))
                    dc.Tariffs.InsertOnSubmit(EditingTariff);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                groupLkp_EditValueChanged(null, null);
            var g = EditingTariff.ServiceID;
            EditingTariff = null;
            EditingTariff = new Tariff();
            tariffBindingSource.DataSource = EditingTariff;
            EditingTariff.ServiceID = g;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}