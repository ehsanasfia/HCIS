using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Inventory.Data;
namespace Inventory.Dialogs
{
    public partial class dlgUserB : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public Person Pe { get; set; }
        public bool usero { get; set; }
        public dlgUserB()
        {
            InitializeComponent();
        }

        private void dlgUserB_Load(object sender, EventArgs e)
        {
            G();
        }
        public void G()
        {
            personBindingSource.DataSource = dc.Persons.Where(c => c.Boss == true).OrderBy(c=> c.Organ.Name).ToList();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var row = personBindingSource.Current as Person;
            if(row == null)
            {
                return;
            }
            dc.Dispose();
            dc = new DataClassesDataContext();
            row = dc.Persons.FirstOrDefault(x => x.ID == row.ID);

            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;



            dc.Persons.DeleteOnSubmit(row);

            dc.SubmitChanges();
            G();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}