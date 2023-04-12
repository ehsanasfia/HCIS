using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;

namespace HCISHealth.Dialogs
{
    public partial class dlgEdinberg : DevExpress.XtraEditors.XtraForm
    {
        public QA qa { get; set; }
        public DataClassesHCISHealthDataContext dc { get; set; }
        public string Answer { get; set; }
        public dlgEdinberg()
        {
            InitializeComponent();
        }

        private void dlgEdinberg_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ParentID == qa.QuestionnariID);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var items = gridView1.GetSelectedRows();

            foreach (var item in items)
            {
                var service = gridView1.GetRow(item) as Service;

                Answer += service.Name + " " + "," + " ";
            }
            DialogResult = DialogResult.OK;
        }
    }
}