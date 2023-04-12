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
using Transport.Data;

namespace Transport.Forms
{
    public partial class frmOutcall : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public frmOutcall()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            tblMngOut_of_CareCall u = new tblMngOut_of_CareCall();

            u.CallTime = txtcalltime.Text;
            u.ConversationType = txtReqType.Text;
            u.Date = txtDate.Text;
            u.Description = txtDescription.Text;
            u.InteralNO = txtINNO.Text;
            u.ReqName = txtReqName.Text;
            u.ReservationTime = txtReserv.Text;
            u.Result = txtResult.Text;
            u.TelecommunicationsEmployee =Int32.Parse(lkpWorker.EditValue.ToString());

            dc.tblMngOut_of_CareCalls.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtResult.Text = " ";
            txtReserv.Text = " ";
            txtReqType.Text = " ";
            txtReqName.Text = " ";
            txtINNO.Text = " ";
            txtDescription.Text = " ";
            txtDate.Text = " ";
            txtcalltime.Text = " ";
            lkpWorker.EditValue = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }
        private void GetData ()
        {
            tblMngOutofCareCallBindingSource.DataSource = dc.tblMngOut_of_CareCalls.ToList();
        }
        private void frmOutcall_Load(object sender, EventArgs e)
        {
             tblMngTelecommunicationPersonnelBindingSource.DataSource = dc.tblMngTelecommunicationPersonnels.ToList();

             tblMngOutofCareCallBindingSource.DataSource = dc.tblMngOut_of_CareCalls.ToList();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}