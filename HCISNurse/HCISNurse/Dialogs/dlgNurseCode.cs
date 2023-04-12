using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgNurseCode : DevExpress.XtraEditors.XtraForm
    {
        public Staff SelectedStaff { get; set; }
        private DataClasses1DataContext dc;

        public dlgNurseCode(DataClasses1DataContext dc)
        {
            InitializeComponent();
            this.dc = dc;
        }

        private void dlgNurseCode_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textEdit1.Text))
            {
                MessageBox.Show("لطفا فیلد را پر کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            var txt = textEdit1.Text.Trim();
            int id = -1;
            bool valid = int.TryParse(txt, out id);
            if (!valid || id == -1)
            {
                MessageBox.Show("لطفا فقط عدد وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var stf = dc.Staffs.FirstOrDefault(x => x.UserID == id && x.UserType == "پرستار");
            if (stf == null)
            {
                MessageBox.Show("کد وارد شده نامعتبر است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            SelectedStaff = stf;
            DialogResult = DialogResult.OK;

        }
    }
}