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
    public partial class dlgOrderSee : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public DrugOrder_Main RD { get; set; }
        List<RequestD> lstr = new List<RequestD>();
        public dlgOrderSee()
        {
            InitializeComponent();
        }

        private void dlgOrderSee_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            if (RD == null)
            {
                return;
            }
            //lkpDrug.EditValue = RD.Service;
            // textEdit1.Text = RD.ID +"";
            txtAmountR.Text = RD.AmountRest + "";
            companyBindingSource.DataSource = dc.Companies.ToList();
            serviceBindingSource.DataSource = dc.Services/*.Where(c=> c.ID == RD.ServiceID)*/.ToList();
            orderBindingSource.DataSource = dc.Orders.Where(c=> c.ServiceID == RD.ServiceID).ToList();
            lkpDrug.Text = RD.Name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            int Sum = 0;
            Sum = RD.AmountS ?? 0; /*AmountSub - (RD.Orders.Sum(C => C.Amount) + Int32.Parse(txtAmount.Text))*/

            if (Sum < 0)
            {
                /*if (*/
                MessageBox.Show("مقدار سفارش از مقدار درخواست بیشتر است ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading)/* != DialogResult.OK)*/;
                    return;
            }
            if (float.Parse(txtAmountR.Text) < float.Parse(txtAmount.Text))
            {
                /*if (*/
                MessageBox.Show("مقدار سفارش از مقدار درخواست بیشتر است ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading)/* != DialogResult.OK)*/;
                    return;
            }
            Order u = new Order();
          //  u.ReqDID = RD.ServiceID;
            u.Service = (lkpDrug.EditValue as Service);
            u.Company = (txtCompany.EditValue as Company);
            u.Amount = Int32.Parse(txtAmount.Text);
            u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            u.CreationTime = DateTime.Now.ToString("HH:mm");
            u.CreatorUserFullName = MainModule.UserFullName;
            dc.Orders.InsertOnSubmit(u);
            dc.SubmitChanges();
            //foreach(var item in lstr)
            //     if(lstr.)

            DialogResult = DialogResult.OK;
        }
      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}