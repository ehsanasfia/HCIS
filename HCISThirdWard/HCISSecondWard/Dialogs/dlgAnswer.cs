using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgAnswer : DevExpress.XtraEditors.XtraForm
    {
        public QA qa { get; set; }
        public HCISDataContext dc { get; set; }
        public string Answer { get; set; }
        public dlgAnswer()
        {
            InitializeComponent();
        }

        private void dlgAnswer_Load(object sender, EventArgs e)
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