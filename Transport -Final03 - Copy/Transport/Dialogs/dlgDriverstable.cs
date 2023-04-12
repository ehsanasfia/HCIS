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
    public partial class dlgDriverstable : DevExpress.XtraEditors.XtraForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public dlgDriverstable()
        {
            InitializeComponent();
        }

        private void GetData()
        {
          //  tblMngLeaseDriverBindingSource.DataSource = dc.tblMngLeaseDrivers.ToList();
        }
        private void dlgDriverstable_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //tblMngLeaseDriver u = new tblMngLeaseDriver();

            //u.Description = txtMore.Text;
            //u.Family = txtLname.Text;
            //u.FName = txtName.Text;          
            //u.Kind_Car = txtCarType.Text;
            //u.Lease_No = txtStijariNum.Text;
            //u.Service_Location = txtHireLocation.Text;
            //u.Time_OprationCar = txtCarClock.Text;
           

            //dc.tblMngLeaseDrivers.InsertOnSubmit(u);
            //dc.SubmitChanges();

            GetData();

            txtCarClock.Text = " ";
            txtCarType.Text = " ";
            txtHireLocation.Text = " ";
            txtLname.Text = " ";
            txtMore.Text = " ";
            txtName.Text = " ";
            txtStijariNum.Text = " ";           

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}