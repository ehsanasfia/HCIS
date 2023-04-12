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
    public partial class frmPersonelMokhaberat : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public frmPersonelMokhaberat()
        {
            InitializeComponent();
        }

        private void frmPersonelMokhaberat_Load(object sender, EventArgs e)
        {
            GetData();

        }

        private void GetData()
        {
            tblMngTelecommunicationPersonnelBindingSource.DataSource = dc.tblMngTelecommunicationPersonnels.ToList();
        }
        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {

            tblMngTelecommunicationPersonnel u = new tblMngTelecommunicationPersonnel();

            u.EmploymentType = cmbHireType.Text;
            u.FName = txtName.Text;
            u.LName = txtLname.Text; 

            dc.tblMngTelecommunicationPersonnels.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtLname.Text = " ";
            txtName.Text = " ";
            cmbHireType.Text = " ";
           
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();

        }
    }
}