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
using Inventory.Dialog;


namespace Inventory.Dialog
{
    public partial class frmClinic : DevExpress.XtraEditors.XtraForm
    {
        
        DataClassesDataContext dc = new DataClassesDataContext();
        public frmClinic()
        {
            InitializeComponent();
        }
        public int LocationID { get; set; }
        private void frmClinic_Load(object sender, EventArgs e)
        {
            organBindingSource.DataSource = dc.Organs.ToList();
            lkpClinic.EditValue = Properties.Settings.Default.Install;
            //lkpClinic.ForeColor = Color.White;
            //lkpClinic.BackColor = Color.Red;
            organBindingSource1.DataSource = dc.Organs.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            var OR = organBindingSource.Current as Organ;
            if(OR == null)
            {
                return;
            }
            LocationID = OR.ID;
            DialogResult = DialogResult.OK;
            Close();
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var OR = organBindingSource.Current as Organ;
            if (OR == null)
            {
                return;
            }
            LocationID = OR.ID;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}