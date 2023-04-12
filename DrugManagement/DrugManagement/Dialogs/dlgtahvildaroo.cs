using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Dialogs;
using DrugManagement.Forms;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class dlgtahvildaroo : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public bool isEdit { get; set; }
        public dlgtahvildaroo()
        {
            InitializeComponent();
        }

        private void dlgtahvildaroo_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            // departmentBindingSource1.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ c.TypeID == 12 || c.TypeID == 32 || c.TypeID == 53).OrderBy(c => c.Name);
            var x = dc.Staffs.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
            ////staffBindingSource.DataSource = x;
            ////lkpResponsible.EditValue = x.UserID;
            var s = dc.Departments.Where(c => c.Pharmacy.TechnicalID == x.ID).FirstOrDefault();
            //departmentBindingSource1.DataSource = s;
            //lkpFromUnit.EditValue = s.ID;
            // departmentBindingSource.DataSource = dc.Departments.Where(c => c.RequestPermissions1.Any(d => d.FromUnit == s.ID));
            // lkpToUnit.EditValue = departmentBindingSource.DataSource;
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
            //if (ObjectRM == null)
            //{
            
            //}

           var b = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID && c.Pharmacy.PharmacyStore == true).FirstOrDefault();
            departmentBindingSource.DataSource = b;
            lkpToUnit.EditValue = b.ID;
            //    lkpToUnit.EditValue = departmentBindingSource.DataSource;
            servicesBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).ToList();
            if (isEdit == true)
            {
                var n = ObjectRM.Department;
                departmentBindingSource1.DataSource = n;
                lkpFromUnit.EditValue = n.ID;
                //  lkpToUnit.EditValue = ObjectRM.Department1;

                lst = ObjectRM.RequestDs.Where(m => m.ReqMID == ObjectRM.ID && m.Indent == true).OrderBy(c => c.Service.Name).ToList();
                requestDsBindingSource.DataSource = lst;
                //lst.AddRange(ObjectRM.RequestDs);
                //ObjectRM = new RequestM();
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //if (txtAmount.Text == "")
            //{
            //    MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //RequestD u = new RequestD();
            //u.Amount = Int32.Parse(txtAmount.Text);
            //u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
            //if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

            //lst.Add(u);
            //requestDsBindingSource.DataSource = lst;
            //gridControl1.RefreshDataSource();
            //GetData();
            //txtAmount.Text = "";
            //skpDrug.EditValue = null;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var row = requestDsBindingSource.Current as RequestD;
            lst.Remove(row);
            requestDsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (lkpToUnit.EditValue == null)
            {
                MessageBox.Show("واحد صادر کننده را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            //var x = gridView3.GetSelectedRows();
           
            

            ObjectRM.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectRM.CreationDate = txtDate.Text;
            ObjectRM.FromUnit = Guid.Parse(lkpFromUnit.EditValue.ToString());
            ObjectRM.ToUnit = Guid.Parse(lkpToUnit.EditValue.ToString());
            ObjectRM.UserFullname = MainModule.UserFullName;
            ObjectRM.CreatorUserID = MainModule.UserID;
            dc.RequestMs.InsertOnSubmit(ObjectRM);
            dc.SubmitChanges();
            foreach (var item in lst)
            {
                item.Drug = Guid.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Drug").ToString());
                item.AmountDelivery = Int32.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "AmountSub").ToString());
                item.RequestM = ObjectRM;

                //  dc.RequestDs.InsertOnSubmit(item);
            }
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void gridView3_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }
    }
}