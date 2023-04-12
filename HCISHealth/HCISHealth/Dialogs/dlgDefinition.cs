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
using HCISHealth.Data;

namespace HCISHealth.Dialogs
{
    public partial class dlgDefinition : DevExpress.XtraEditors.XtraForm

    { DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        public dlgDefinition()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Service u = new Service();


            u.CategoryID = 15;
            u.ParentID = Guid.Parse(lkpParent.EditValue.ToString());
            u.Name = txtChild.Text;
           


            dc.Services.InsertOnSubmit(u);
            dc.SubmitChanges();

            txtChild.Text = " ";



            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void dlgDefinition_Load(object sender, EventArgs e)
        {
            var q = from p in dc.Services
                    where p.CategoryID == 15
                    select p;
            serviceBindingSource.DataSource = q;
        }
    }
}