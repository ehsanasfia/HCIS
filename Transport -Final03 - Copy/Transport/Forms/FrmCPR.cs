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
    public partial class FrmCPR : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        
        public FrmCPR()
        {
            InitializeComponent();
        }

        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
           tblMngCprGroup  u = new tblMngCprGroup();

            u.TimeWarningPage = txtTime.Text;
            u.Shift = Int32.Parse(lkpShift.EditValue.ToString());
            u.RequstTimePage = txtPageTime.Text;
            u.RequsterDepartment = cmbReq.Text;
            u.Requster = txtReqName.Text;
            u.NumberOfPaging = Int32.Parse(txtCount.Text);
            u.Description = txtDescription.Text;
            
            
            // u.TelecommunicationsEmployee =(lkpWorker.EditValue.ToString());

            dc.tblMngCprGroups.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtCount.Text = " ";
            txtDate.Text = " ";
            txtPageTime.Text = " ";
            jh.Text = " ";
            txtReqName.Text = " ";
            txtTime.Text = " ";
            lkpShift.EditValue = " ";
            cmbReq.Text = " ";
           

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        
    }

        private void GetData()
        {
            tblMngCprGroupBindingSource.DataSource = dc.tblMngCprGroups.ToList();
        }
        private void FrmCPR_Load(object sender, EventArgs e)

        {
            shiftBindingSource.DataSource = dc.Shifts.ToList();
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);
           txtTime.Text=  DateTime.Now.ToString("HH:MM");
            GetData();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();

        }
    }
}