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
    public partial class frmTelephoneBill : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public frmTelephoneBill()
        {
            InitializeComponent();
        }

        private void GetData()
        {

        }
        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblMngTicketPhone u = new tblMngTicketPhone(); 

            u.Amount = Int32.Parse(txtPey.Text);
            u.Date = txtdate.Text;
            u.PhoneNumber = txtPhoneNO.Text;
            u.TicketNumber = txtTicketNO.Text;


            dc.tblMngTicketPhones.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtTicketNO.Text = " ";
            txtPhoneNO.Text = " ";
            txtPey.Text = " ";
            txtdate.Text = " ";               


            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}