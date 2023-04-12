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
using HCISStandAdmission.Classes;

namespace HCISStandAdmission.Dialogs
{
    public partial class dlgDoctors : DevExpress.XtraEditors.XtraForm
    {
        public Department Dep { get; set; }
        public Staff stf { get; set; }
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public dlgDoctors()
        {
            InitializeComponent();
        }

        private void dlgDoctors_Load(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            var staff = dc.Agendas.Where(c => c.DepartmentID == Dep.ID && c.Date.CompareTo(date) == 0).Select(d => d.Staff).Distinct();
            staffBindingSource.DataSource = staff.ToList();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
                return;
            if (MessageBox.Show("آیا میخواهید برای این پزشک پذیرش شوید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            stf = current;
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