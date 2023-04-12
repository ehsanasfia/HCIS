using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace HCISAdmission.Dialogs
{
    public partial class dlgWardDocChange : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public dlgWardDocChange()
        {
            InitializeComponent();
        }

        private void dlgWardTrasport_Load(object sender, EventArgs e)
        {
            textEdit1.Text = MainModule.GetPersianDate(DateTime.Now);
            staffBindingSource.DataSource = dc.Staffs.Where(c => c.UserType == "دکتر");
            GetData();
        }

        private void GetData()
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10  && x.Admitted == false && x.Confirm != true && x.Date == textEdit1.Text && x.Department.Name != "اورژانس").ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var Doc = lookUpEdit1.EditValue as Staff;
            if (Doc == null)
            {
                MessageBox.Show("لطفا پزشک مورد نظر رانتخاب کنید ");
                return;
            }
            if (MessageBox.Show("آیا میخواهید بیماران را انتقال دهید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            foreach (var item in gridView1.GetSelectedRows())
            {
                var gsm = gridView1.GetRow(item) as GivenServiceM;
                gsm.RequestStaffID = Doc.ID;
                gsm.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsm.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsm.LastModificator = MainModule.UserID;
            }
            dc.SubmitChanges();
            MessageBox.Show("بیماران با موفقیت انتقال یافتند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;

        }
    }
}