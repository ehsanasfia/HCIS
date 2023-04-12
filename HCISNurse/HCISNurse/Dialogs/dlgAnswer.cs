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

namespace HCISNurse.Dialogs
{
    public partial class dlgAnswer : DevExpress.XtraEditors.XtraForm
    {
        public QA qa { get; set; }
        public DataClasses1DataContext dc { get; set; }
        public string Answer { get; set; }

        public dlgAnswer()
        {
            InitializeComponent();
        }

        private void dlgAnswer_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.Service1 == qa.PService);
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