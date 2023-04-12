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
    public partial class frmMojodibakhsh : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        List<Spu_WardStockResult> lst = new List<Spu_WardStockResult>();
        public frmMojodibakhsh()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmMojodibakhsh_Load(object sender, EventArgs e)
        {
            GetData();
            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 11).ToList();
            radioGroup1.SelectedIndex = 0;
            textEditFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            textEditToDate.Text = MainModule.GetPersianDate(DateTime.Now);

            //var d = dc.Departments.Where(l => l.ID == MainModule.MyDepartment.ID).FirstOrDefault();
            //lkpPharmcy.EditValue = d.ID;
        }

        private void GetData()
        {

            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12).ToList();
            var pid = lkpPharmcy.EditValue as Guid?;
            if (pid == null)
                return;
            var temp = textEditFromDate.Text;
            if (string.IsNullOrWhiteSpace(temp))
                return;
            var temp1 = textEditToDate.Text;
            if (string.IsNullOrWhiteSpace(temp1))
                return;
            //var yearmonth = temp.Substring(0, 7);
             lst = dc.Spu_WardStock(temp,temp1,pid).ToList();
            spuWardStockResultBindingSource.DataSource = lst;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                layoutControlItem8.Text = "بخش:";
                departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 11 || c.TypeID == 15 || c.TypeID == 16).OrderBy(c => c.Name).ToList();
            }

            else if (radioGroup1.SelectedIndex == 1)
            {
                layoutControlItem8.Text = "کلینیک:";
                departmentBindingSource.DataSource = dc.Departments.Where(c => c.IDIntParent == 37 && c.TypeID == 10).OrderBy(c => c.Name).ToList();
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                layoutControlItem8.Text = "پرستاری:";
                departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 53).OrderBy(c => c.Name).ToList();
            }
            else if (radioGroup1.SelectedIndex == 3)
            {

                layoutControlItem8.Text = "متفرقه:";
                departmentBindingSource.DataSource = dc.Departments.Where(c => (c.TypeID == 32 && c.Name == "بهداشت طب صنعتی") ||
                     c.Name == "آزمایشگاه بیمارستان").OrderBy(c => c.Name).ToList();
            }
        }
    }
}