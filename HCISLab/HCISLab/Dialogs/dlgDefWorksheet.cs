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
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgDefWorksheet : DevExpress.XtraEditors.XtraForm
    {
        public HCISLabClassesDataContext dc { get; set; }
        public LabWorksheet EditingWorksheet { get; set; }

        public List<LabWorksheetService> lstWS { get; set; }
        private List<Service> lstServices;

        public dlgDefWorksheet()
        {
            InitializeComponent();
        }

        private void dlgDefWorksheet_Load(object sender, EventArgs e)
        {
            if (EditingWorksheet == null)
            {
                EditingWorksheet = new LabWorksheet();
            }
            else
            {
                txtName.Text = EditingWorksheet.Name;
            }

            lstWS = EditingWorksheet.LabWorksheetServices.OrderBy(x => x.Service.OldID).ToList();
            labWorksheetServicesBindingSource.DataSource = lstWS;

            var lst = dc.LabGroups.Where(x => x.LabSubGroups.Any()).OrderBy(x => x.GoupName).ToList();
            groupsBindingSource.DataSource = lst;
            lkpGroup.EditValue = lst.FirstOrDefault();
        }

        private void lkpGroup_EditValueChanged(object sender, EventArgs e)
        {
            var gp = lkpGroup.EditValue as LabGroup;
            if (gp == null)
            {
                subGroupsBindingSource.DataSource = null;
                servicesBindingSource.DataSource = null;
                return;
            }
            var lst = dc.LabSubGroups.Where(x => x.LabGroupID  == gp.ID).OrderBy(x => x.SubGroupName).ToList();
            subGroupsBindingSource.DataSource = lst;
            lkpSubGroup.EditValue = lst.FirstOrDefault();
            lkpSubGroup_EditValueChanged(null, null);
        }

        private void lkpSubGroup_EditValueChanged(object sender, EventArgs e)
        {
            var chGp = lkpSubGroup.EditValue as LabSubGroup;
            if (chGp == null)
            {
                servicesBindingSource.DataSource = null;
                return;
            }
            lstServices = dc.LabTestGroups.Where(x =>
           x.LabSubGroupID == chGp.ID).Select(x => x.Service)
           .OrderBy(x => x.OldID).ToList();

            servicesBindingSource.DataSource = lstServices;
            for (int i = 0; i < lstServices.Count; i++)
            {
                var x = lstServices.ElementAt(i);
                if (lstWS.Any(y => y.ServiceID == x.ID))
                {
                    int handle = gridView2.GetRowHandle(i);
                    gridView2.SelectRow(handle);
                }
            }

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (lstServices == null || !lstServices.Any())
            {
                return;
            }

            var selectedHandles = gridView2.GetSelectedRows();
            if (selectedHandles == null || !selectedHandles.Any())
            {
                MessageBox.Show("ابتدا یک یا چند آزمایش را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            for (int i = 0; i < selectedHandles.Length; i++)
            {

                var srv = gridView2.GetRow(selectedHandles[i]) as Service;
                if (srv == null)
                {
                    MessageBox.Show("خطا در دریافت اطلاعات", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (lstWS.Any(x => x.ServiceID == srv.ID))
                {
                    continue;
                }

                lstWS.Add(new LabWorksheetService() { Service = srv });
            }
            gridControl1.RefreshDataSource();
        }

        private void btnRemove_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var cur = gridView1.GetFocusedRow() as LabWorksheetService;
            if (cur == null)
                return;
            cur.LabWorksheet = null;
            cur.Service = null;
            gridView1.DeleteSelectedRows();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("نام برگه کار وارد نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                txtName.Select();
                return;
            }
            if (!lstWS.Any())
            {
                if (MessageBox.Show("هیچ آزمایشی برای این برگه کار ثبت نشده است؟\nآیا مایل به ثبت برگه کار هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
            }

            EditingWorksheet.Name = txtName.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}