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
using HCISSecondWard.Classes;


namespace HCISSecondWard.Dialogs
{
    public partial class dlgSelectDr : DevExpress.XtraEditors.XtraForm
    {
       

        public HCISDataContext dc = new HCISDataContext();
        public dlgSelectDr()
        {
            InitializeComponent();
        }

        private void dlgStart_Load(object sender, EventArgs e)
        {
           staffBindingSource.DataSource = dc.Staffs.Where(x=>x.UserType=="دکتر").ToList();
            if (staffBindingSource.Count == 1)
                gridControl1_DoubleClick(null, null);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var row = staffBindingSource.Current as Staff;
            if (row == null)
            {
                return;
            }

            MainModule.MyStaff = row;
            DialogResult = DialogResult.OK;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var row = staffBindingSource.Current as Staff;
                if (row == null)
                {
                    return;
                }

                MainModule.MyStaff = row;
                DialogResult = DialogResult.OK;
            }
        }
    }
}