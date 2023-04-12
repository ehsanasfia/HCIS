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
using DrugManagement.Forms;
using DrugManagement.Data;

namespace DrugManagement.Forms
{
    public partial class frmDrugOutPut : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<RequestD> lst = new List<RequestD>();
        public frmDrugOutPut()
        {
            InitializeComponent();
        }

        private void frmDrugOutPut_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
        
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
            //  var temp3 = MainModule.MyDepartment.ID;
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.RequestM.ToUnit == pid && c.AmountDeliveryDate.CompareTo(txtFromDate.Text) >= 0 && c.AmountDeliveryDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.AmountDeliveryDate.CompareTo(txtFromDate.Text) >= 0 && c.AmountDeliveryDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.AmountDeliveryDate.CompareTo(txtFromDate.Text) >= 0 && c.AmountDeliveryDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
        }
    }
}