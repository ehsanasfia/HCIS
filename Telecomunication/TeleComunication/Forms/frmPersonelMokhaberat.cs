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
using TeleComunication.Data;

namespace TeleComunication.Forms
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

            var q = from d in dc.Definitions
                    where (d.Parent == 45)
                    select d;
            definitionBindingSource.DataSource = q;
          
        }

        private void GetData()
        {
            tblMngTelecomunicationPersonnelBindingSource.DataSource = dc.tblMngTelecomunicationPersonnels.ToList();
        }
        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {

            tblMngTelecomunicationPersonnel u = new tblMngTelecomunicationPersonnel();

           u.EmploymentType =Int32.Parse( lkpHireType.EditValue.ToString()); 
            u.FName = aa.Text;
            u.LName = txtLname.Text; 

            dc.tblMngTelecomunicationPersonnels.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtLname.Text = " ";
            aa.Text = " ";
            lkpHireType.Text = " ";
           
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}