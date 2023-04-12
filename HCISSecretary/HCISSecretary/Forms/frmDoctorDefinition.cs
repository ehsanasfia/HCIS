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
using HCISSecretary.Data;
using HCISSecretary.Dialogs;

namespace HCISSecretary.Forms
{
    public partial class frmDoctorDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public string parentName { get; set; }

        public frmDoctorDefinition()
        {
            InitializeComponent();
        }
        private void EndEdit()
        {
            personBindingSource.EndEdit();
        }

        public void GetData()
        {
            try
            {
                EndEdit();
                personBindingSource.DataSource = dc.Persons.Where(x => x.Staff.UserType == "دکتر").OrderBy(c => c.LastName).ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            while (true)
            {
                var a = new dlgDoctorDefinition();
                a.parentName = parentName;
                a.dc = dc;
                a.Text = "تعریف دکتر";
                a.isEdit = false;
                if (a.ShowDialog() == DialogResult.OK)
                    GetData();
                else
                    break;
            }
        }

        private void frmDoctorDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new dlgDoctorDefinition();
            a.dc = dc;
            a.isEdit = true;
            var current = personBindingSource.Current as Person;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            a.doctor = current.Staff;
            a.Text = "ویرایش دکتر";
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = personBindingSource.Current as Person;
            dc.Dispose();
            dc = new HCISDataContext();
            row = dc.Persons.FirstOrDefault(x => x.ID == row.ID);
            if (row.GivenServiceMs.Any() || row.Payments.Any())
            {
                MessageBox.Show("برای این پزشک اطلاعات ثبت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var row2 = dc.Staffs.FirstOrDefault(x => x.ID == row.ID);
            if (row2 != null)
            {
                if (row2.Agendas.Any(x => x.Deleted == true) || row2.FavoriteServices.Any() || row2.GivenServiceMs.Any() || row2.GivenServiceMs1.Any() || row2.GivenServiceMs2.Any() || row2.Payments.Any() || row2.References.Any())
                {
                    MessageBox.Show("برای این پزشک اطلاعات ثبت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                dc.Staffs.DeleteOnSubmit(row2);
            }

            dc.Persons.DeleteOnSubmit(row);

            dc.SubmitChanges();
            GetData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnEdit_ItemClick(null, null);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}