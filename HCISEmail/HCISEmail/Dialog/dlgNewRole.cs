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
using HCISEmail.Data;


namespace HCISEmail.Dialog
{
    public partial class dlgNewRole : DevExpress.XtraEditors.XtraForm
    {
        EmaildbDataContext dc = new EmaildbDataContext();
        public User CurrentUser { get; set; }
        public dlgNewRole()
        {
            InitializeComponent();
        }

        private void dlgNewrole_Load(object sender, EventArgs e)
        {
            departmentBindingSource.DataSource = dc.Departments.ToList();
        }

        private void btnEnseraf_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTaeid_Click(object sender, EventArgs e)
        {
            if ((lkpSarshakhe.EditValue as Department) == null)
                return;

            var frm = new Role()
            {
                Name = txtName.Text,
                DepartmentID = (lkpSarshakhe.EditValue as Department).IDDepartment,
                CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm")
            };
            dc.Roles.InsertOnSubmit(frm);
            dc.SubmitChanges();
            MessageBox.Show("ثبت شد");

        }
    }
}