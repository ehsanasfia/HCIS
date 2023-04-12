using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;

namespace DrugManagement.Dialogs
{
    public partial class dlgRequestPermission : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; }
        public RequestPermission RP { get; set; }
        public bool isEdit { get; set; }
        List<RequestPermission> lst = new List<RequestPermission>();
        public dlgRequestPermission()
        {
            InitializeComponent();
        }

        private void dlgRequestPermission_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            if (RP == null)
            {
                RP = new RequestPermission();
            }
            if (isEdit == true)
            {

                try
                {
                    lkpFromUnit.EditValue = RP.FromUnit;
                    lkpToUnit.EditValue = RP.ToUnit;
                }
                catch
                {

                }
            }

            departmentBindingSource.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID && c.Name != "انبار").ToList();
            departmentBindingSource1.DataSource = dc.Departments.Where(c => c.TypeID == 12 && c.Pharmacy.ID == c.ID).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //foreach (var item in lst)
            //{
            //    if (item.FromUnit && item.ToUnit == Guid.Parse(lkpFromUnit.EditValue.ToString()) && Guid.Parse(lkpToUnit.EditValue.ToString())))
            //    {
            //        { MessageBox.Show("کالا قبلا به لیست اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
            //    }
                if (isEdit == true)
                {
                    var fr = Guid.Parse(lkpFromUnit.EditValue.ToString());
                    RP.FromUnit = fr;
                    var tu = Guid.Parse(lkpToUnit.EditValue.ToString());
                    RP.ToUnit = tu;
                    RP.Permission = RP.Permission;
                    dc.SubmitChanges();
                }
                else
                {
                    RequestPermission u = new RequestPermission();
                 // if (dc.RequestPermissions.Any(c => c.Department == Guid.Parse(lkpFromUnit.EditValue.ToString()) && c.Department1 == Guid.Parse(lkpToUnit.EditValue.ToString()))))) { MessageBox.Show("دارو قبلا به داروخانه اضافه شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); return; }
                    u.FromUnit = Guid.Parse(lkpFromUnit.EditValue.ToString());
                    u.ToUnit = Guid.Parse(lkpToUnit.EditValue.ToString());
                    u.Permission = true;
                    dc.RequestPermissions.InsertOnSubmit(u);
                    dc.SubmitChanges();
                }
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;

            }

        }

    }