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
    public partial class frmHoliday : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OncallDataClassesDataContext dc = new OncallDataClassesDataContext();
        public frmHoliday()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            holidayBindingSource.DataSource = dc.Holidays.ToList();

            gridControl1.RefreshDataSource();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            Holiday u = new Holiday();


            u.Date = txtDate.Text;
            u.Cermony = txtCermony.Text;
            u.Holiday1 = bool.Parse(chkHoliday.EditValue.ToString());

            dc.Holidays.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

            txtCermony.Text = " ";
            chkHoliday.EditValue = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void frmHoliday_Load(object sender, EventArgs e)
        {
            txtDate.Text = MainModule.GetPersianDate(DateTime.Now);

            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}