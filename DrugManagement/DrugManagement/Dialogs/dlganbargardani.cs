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
namespace DrugManagement.Dialogs
{
    public partial class dlganbargardani : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        List<RequestD> lst = new List<RequestD>();
        List<RequestD> del = new List<RequestD>();
        public RequestM ObjectRM { get; set; }
        public bool isEdit { get; set; }
        public dlganbargardani()
        {
            InitializeComponent();
        }

        private void dlganbargardani_Load(object sender, EventArgs e)
        {

            GetData();
        }
        private void GetData()
        {
            if (isEdit == true)
            {
                servicesBindingSource.DataSource = dc.Services.Where(c => c.CategoryID == 4).OrderBy(c => c.Name).ToList();

                //  departmentBindingSource.DataSource= dc.Departments.Where(c => c.ID == ObjectRM.Department1.ID).FirstOrDefault();
                //departmentBindingSource1.DataSource = dc.Departments.Where(c => c.ID == ObjectRM.Department.ID).FirstOrDefault();


                //  lkpFromUnit.EditValue = s;
                //  lkpFromUnit.EditValue = x;

                textEdit1.Text = ObjectRM.CreationDate;
                textEdit2.Text = ObjectRM.CreationTime;
               // servicesBindingSource.DataSource = dc.Services.Where()
                //departmentBindingSource.DataSource = dc.Departments.Where(c => /*c.RequestPermissions1.Any(d=>d.FromUnit==s.ID && d.Permission == true)*/ c.TypeID == 12 || c.TypeID == 32 || c.TypeID == 53).OrderBy(c => c.Name);
                //////lkpToUnit.Properties.DisplayMember = s.ID;


                //requestDsBindingSource.DataSource = ObjectRM.RequestDs.OrderBy(c => c.Service.Name);
                //lst.AddRange(ObjectRM.RequestDs);
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //if (txtAmount.Text == "")
            //{
            //    MessageBox.Show("تعداد را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //    return;
            //}
            //RequestD u = new RequestD();
            //u.Amount = Int32.Parse(txtAmount.Text);
            //u.AmountDelivery = Int32.Parse(txtAmount.Text);
            //u.Service = (skpDrug.EditValue as PharmacyDrug).Service;
            //u.ReqMID = ObjectRM.ID;
            //if (lst.Any(c => c.Service == u.Service)) { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }

            //lst.Add(u);
            //requestDsBindingSource.DataSource = lst;
            //gridControl1.RefreshDataSource();
            //GetData();
            //txtAmount.Text = "";
            //skpDrug.EditValue = null;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (ObjectRM.RequestDs.Any(c => c.Drug == (skpDrug.EditValue as Service).ID )) { MessageBox.Show("دارو قبلا به انبارگردانی اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            RequestD u = new RequestD();
            u.Drug = (skpDrug.EditValue as Service).ID;
            u.ReqMID = ObjectRM.ID;
            u.Amount = Int32.Parse(txtAmount.Text);
            u.AmountDelivery = Int32.Parse(txtAmount.Text);
            u.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
            u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
            u.AmountDeliveryUser = MainModule.UserID;
            dc.RequestDs.InsertOnSubmit(u);
            dc.SubmitChanges();
                //foreach (var item in lst)
                //{

                //    item.RequestM = ObjectRM;


                //}
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (skpDrug.Text == "")
            {
                MessageBox.Show("دارو را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ObjectRM.RequestDs.Any(c => c.Drug == (skpDrug.EditValue as Service).ID)) { MessageBox.Show("دارو قبلا به انبارگردانی اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                RequestD u = new RequestD();
                u.Drug = (skpDrug.EditValue as Service).ID;
                u.ReqMID = ObjectRM.ID;
                u.Amount = Int32.Parse(txtAmount.Text);
                u.AmountDelivery = Int32.Parse(txtAmount.Text);
                u.AmountDeliveryDate = MainModule.GetPersianDate(DateTime.Now);
                u.AmountDeliveryTime = DateTime.Now.ToString("HH:mm");
                u.AmountDeliveryUser = MainModule.UserID;
                dc.RequestDs.InsertOnSubmit(u);
                dc.SubmitChanges();
                //foreach (var item in lst)
                //{

                //    item.RequestM = ObjectRM;


                //}
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
        }
    }
   
}