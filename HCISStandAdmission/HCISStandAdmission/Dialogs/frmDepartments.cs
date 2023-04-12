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
using HCISStandAdmission.Data;

namespace HCISStandAdmission.Dialogs
{
    public partial class frmDepartments : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Department SelectedDep { get; set; }

        public frmDepartments()
        {
            InitializeComponent();
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.Where(x => x.Parent == Classes.MainModule.InstallLocation.ID && (x.Name == "OPD" || x.Name == "دندانپزشکی")).ToList();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = departmentBindingSource.Current as Department;
            if (current == null)
                return;
            if (MessageBox.Show("آیا میخواهید برای این کلینیک پذیرش شوید؟","توجه",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            SelectedDep = current;
            DialogResult = DialogResult.OK;           
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            repositoryItemButtonEdit1_ButtonClick(null, null);
        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            repositoryItemButtonEdit1_ButtonClick(null, null);
        }
    }
}