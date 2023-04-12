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
    public partial class frmNotresunit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HealthDataClassesDataContext dc = new HealthDataClassesDataContext();
        public frmNotresunit()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();

        }

        private void GetData()
        {
            tblMngNotResponseBindingSource.DataSource = dc.tblMngNotResponses.ToList();
        }
        private void btnOk_ItemClick(object sender, ItemClickEventArgs e)
        {
            tblMngNotResponse u = new tblMngNotResponse();

            u.Date = txtDate.Text;
            u.Description = txtDescription.Text;
            u.InteralNumber = txtinNO.Text;
            u.NotResponseNumber = txtCount.Text;

            dc.tblMngNotResponses.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();


            txtCount.Text = " ";
            txtDate.Text = " ";
            txtDescription.Text = " ";
            txtinNO.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void frmNotresunit_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}