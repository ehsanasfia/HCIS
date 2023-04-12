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
namespace DrugManagement.Forms
{
    public partial class frmDaroDakhst : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_DrugRequestResult> lst = new List<Spu_DrugRequestResult>();
        public frmDaroDakhst()
        {
            InitializeComponent();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
            {
                return;
            }
            var cu = spuDrugRequestResultBindingSource.Current as Spu_DrugRequestResult;
            if (cu == null)
            {
                return;
            }




            requestDBindingSource.DataSource = dc.RequestDs.Where(c => c.RequestM.FromUnit == pid && c.Service.ID == cu.ID && c.AmountDeliveryDate.CompareTo(textEdit1.Text) >= 0 && c.AmountDeliveryDate.CompareTo(textEdit2.Text) <= 0).OrderByDescending(c => c.RequestM.CreationTime).OrderByDescending(c => c.RequestM.CreationDate).ToList();
        
    }

        private void frmDaroDakhst_Load(object sender, EventArgs e)
        {
            GetData();
            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            lkpPharmcy.EditValue = d.ID;
        }
        private void GetData()
        {

            var temp = textEdit1.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp2 = textEdit2.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;

            var temp3 = MainModule.MyDepartment.ID;


            lst = dc.Spu_DrugRequest(temp, temp2, temp3).ToList();
            spuDrugRequestResultBindingSource.DataSource = lst;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}