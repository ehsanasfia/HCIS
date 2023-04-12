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
using HCISPhysiotherapy.Data;
using HCISPhysiotherapy.Dialogs;

namespace HCISPhysiotherapy.Forms
{
    public partial class frmPhysiotherapistDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        public frmPhysiotherapistDefinition()
        {
            InitializeComponent();
        }

        private void frmPhysiotherapistDefinition_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void EndEdit()
        {
            personsBindingSource.EndEdit();
        }
        public void GetData()
        {
            try
            {
                EndEdit();
                personsBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "فیزیوتراپیست").OrderBy(c => c.LastName).ToList();
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
                var a = new dlgPhysiotherapistDefinition();
                a.dc = dc;
                a.Text = "جدید";
                a.isEdit = false;
                if (a.ShowDialog() == DialogResult.OK)
                    GetData();
                else
                    break;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a = new dlgPhysiotherapistDefinition();
            a.dc = dc;
            a.isEdit = true;
            var current = personsBindingSource.Current as Person;
            if (current == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            a.PHT = current.Staff;
            a.Text = "ویرایش";
            if (a.ShowDialog() == DialogResult.OK)
                GetData();
            else
            {
                dc.Dispose();
                dc = new HCISClassesDataContext();
                GetData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var row = personsBindingSource.Current as Person;
            dc.Dispose();
            dc = new HCISClassesDataContext();
            row = dc.Persons.FirstOrDefault(x => x.ID == row.ID);
            if (row.GivenServiceMs.Any() || row.Payments.Any() || row.PhysiotherapyOrderMs.Any())
            {
                MessageBox.Show("برای این فیزیوتراپیست اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            var row2 = dc.Staffs.FirstOrDefault(x => x.ID == row.ID);
            if (row2 != null)
            {
                if (row2.Agendas.Any(x => x.Deleted == true) || row2.FavoriteServices.Any() || row2.GivenServiceMs.Any() || row2.GivenServiceMs1.Any() || row2.GivenServiceMs2.Any() || row2.Payments.Any() || row2.PhysiotherapyOrderMs.Any())
                {
                    MessageBox.Show("برای این فیزیوتراپیست اطلاعات ثبت شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(null, null);
        }
    }
}