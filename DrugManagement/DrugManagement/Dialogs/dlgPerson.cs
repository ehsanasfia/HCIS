using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DrugManagement.Data;
namespace DrugManagement.Dialogs
{
    public partial class dlgPerson : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContexDataContext dc { get; set; } 
        public string PCode { get; set; }
        public string NationalCode { get; set; }
        List<Person> Pe = new List<Person>();

        public dlgPerson()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void dlgPerson_Load(object sender, EventArgs e)
        {
         
            
            personBindingSource.DataSource = dc.Persons.Where(c=> (c.PersonalCode == PCode) ||  (c.NationalCode == PCode)).ToList();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            NationalCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NationalCode").ToString();
            DialogResult = DialogResult.OK;
        }
    }
}