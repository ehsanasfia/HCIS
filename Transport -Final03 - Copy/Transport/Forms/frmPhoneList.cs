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
using Transport.Data;


namespace Transport.Forms
{
    public partial class frmPhoneList : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        List<tblMngTicketPhone> lst = new List<tblMngTicketPhone>();
      
        public frmPhoneList()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            tblAllPhoneNumberBindingSource.DataSource = dc.tblAllPhoneNumbers.ToList();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblAllPhoneNumber u = new tblAllPhoneNumber();

            u.Active = checkActive.Checked;
            u.Date_Received = txtTahvilDate.Text;
            u.DeliveryDate = txtReciveDate.Text;
            u.DeliveryDate = txtDescription.Text;
            u.Interal = txtInNO.Text;
            u.Location = lkpDepartment.Text;
            u.LocationGroup = lkpGroup.Text;
            u.LocationGroup = txtPhoneNO.Text;
            u.PhoneType = txtphoneType.Text;
            u.Responsible = txtHead.Text;
           
            dc.tblAllPhoneNumbers.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtDescription.Text = " ";
            txtHead.Text = " ";
            txtInNO.Text = " ";
            txtPhoneNO.Text = " ";
            txtphoneType.Text = " ";
            txtReciveDate.Text = " ";
            txtTahvilDate.Text = " ";
            lkpDepartment.Text = " ";
            lkpGroup.Text = " ";
         

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void frmPhoneList_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void tblAllPhoneNumberBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = tblAllPhoneNumberBindingSource.Current as Data.tblAllPhoneNumber;
            if (current == null)
                return;
            var a = new Dialogs.dlgPhonBill();
            a.b = current;
            a.ShowDialog();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var curent = tblAllPhoneNumberBindingSource.Current as tblAllPhoneNumber;
            if (curent == null)
                return;
            lst = dc.tblMngTicketPhones.Where(x => x.IDM == curent.ID).ToList();
            tblMngTicketPhoneBindingSource.DataSource = lst;
            gridControl2.RefreshDataSource();
        }
    }
}