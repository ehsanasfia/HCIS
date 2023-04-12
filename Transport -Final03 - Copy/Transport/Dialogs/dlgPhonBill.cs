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

namespace Transport.Dialogs
{
    public partial class dlgPhonBill : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public tblAllPhoneNumber b { get; set; }
        public dlgPhonBill()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           tblMngTicketPhone u = new tblMngTicketPhone();

            u.Amount = Int32.Parse(txtMoney.Text);
            u.Date = txtDate.Text;
            u.IDM = b.ID;
            u.PhoneNumber = txtPhoneNO.Text;
            u.TicketNumber = txtTicketNO.Text;

            dc.tblMngTicketPhones.InsertOnSubmit(u);
            dc.SubmitChanges();

            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}