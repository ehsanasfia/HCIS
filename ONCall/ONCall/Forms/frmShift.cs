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
using ONCall.Data;
using ONCall.Forms;

namespace ONCall.Forms
{
    public partial class frmShift : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OncallDataClassesDataContext dc = new OncallDataClassesDataContext();
        public frmShift()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            shiftBindingSource.DataSource = dc.Shifts.ToList();

            gridControl1.RefreshDataSource();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Shift u = new Shift();


            u.FTime = txtfromClock.Text;
            u.ToTime = txtToClock.Text;
            u.ShiftName = cmbShift.Text;

            dc.Shifts.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            //     lkpHeadName.Text = " ";
            //    txtGroup.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}