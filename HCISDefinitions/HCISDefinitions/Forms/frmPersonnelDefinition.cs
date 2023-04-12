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
using HCISDefinitions.Data;
using HCISDefinitions.Dialogs;

namespace HCISDefinitions.Forms
{
    public partial class frmPersonnelDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmPersonnelDefinition()
        {
            InitializeComponent();
        }

        private void frmPersonnelDefinition_Load(object sender, EventArgs e)
        {
            GetData();
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
                personBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null).OrderBy(c => c.LastName).OrderBy(c => c.Staff.UserType).ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            while (true)
            {
                var a = new dlgPersonnelDefinition();
                a.dc = dc;
                a.Text = "تعریف پرسنل";
                a.isEdit = false;
                if (a.ShowDialog() == DialogResult.OK)
                    GetData();
                else
                    break;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = personBindingSource.Current as Person;
            if (current == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var a = new dlgPersonnelDefinition();
            a.dc = dc;
            a.stff = current.Staff;
            a.Text = "ویرایش پرسنل";
            a.isEdit = true;
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = personBindingSource.Current as Person;
            dc.Dispose();
            dc = new HCISDataClassesDataContext();
            row = dc.Persons.FirstOrDefault(x => x.ID == row.ID);
            if (row.GivenServiceMs.Any() || row.Payments.Any())
            {
                MessageBox.Show("برای این شخص اطلاعات ثبت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var row2 = dc.Staffs.FirstOrDefault(x => x.ID == row.ID);
            if (row2 != null)
            {
                if (row2.Agendas.Any(x => x.Deleted == true) || row2.FavoriteServices.Any() || row2.GivenServiceMs.Any() || row2.GivenServiceMs1.Any() || row2.GivenServiceMs2.Any() || row2.Payments.Any() || row2.References.Any())
                {
                    MessageBox.Show("برای این شخص اطلاعات ثبت شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                dc.Staffs.DeleteOnSubmit(row2);
            }

            dc.Persons.DeleteOnSubmit(row);

            dc.SubmitChanges();
            GetData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnEdit_ItemClick(null, null);
        }
    }
}