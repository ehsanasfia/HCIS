using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgClientSubset : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Department> lstDep;

        public dlgClientSubset()
        {
            InitializeComponent();
        }

        private void dlgClientSubset_Load(object sender, EventArgs e)
        {
            if (lstDep == null)
                lstDep = new List<Department>();

            ClientConfigBindingSource.DataSource = dc.ClientConfigs.OrderBy(c => c.Name).ToList();
            DepartmentBindingSource.DataSource = dc.Departments.Where(x => x.Parent == null).OrderBy(c => c.Name).ToList();
        }

        private void slkClientCon_EditValueChanged(object sender, EventArgs e)
        {
            var cc = slkClientCon.EditValue as ClientConfig;
            lstDep = dc.Departments.Where(x => x.ClientID == cc.ID).OrderBy(c => c.Name).ToList();
            SelectedDepartmentBindingSource.DataSource = lstDep;
            gridControl2.RefreshDataSource();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var cc = slkClientCon.EditValue as ClientConfig;
                var dep = DepartmentBindingSource.Current as Department;

                if (!lstDep.Any(x => x.ID == dep.ID))
                {
                    dep.ClientConfig = cc;
                    dc.SubmitChanges();

                    SelectedDepartmentBindingSource.DataSource = dc.Departments.Where(x => x.ClientID == cc.ID).OrderBy(c => c.Name).ToList();
                    gridControl2.RefreshDataSource();
                }
                else
                    return;
            }
        }

        private void DeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var DC = SelectedDepartmentBindingSource.Current as Department;
            gridView2.DeleteSelectedRows();
            var dp = dc.Departments.Where(x => x.ID == DC.ID).FirstOrDefault();
            dp.ClientConfig = null;
            dc.SubmitChanges();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}