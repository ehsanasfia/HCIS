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
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgStart : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc = new HCISDataContext();
        public dlgStart()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 11).ToList();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {
                var row = departmentBindingSource.Current as Department;
                if (row == null)
                {
                    return;
                }

                Classes.MainModule.MyDepartment = row;
                DialogResult = DialogResult.OK;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            var row = departmentBindingSource.Current as Department;
            if (row == null)
            {
                return;
            }
            Classes.MainModule.MyDepartment = row;
            DialogResult = DialogResult.OK;
        }
    }
}