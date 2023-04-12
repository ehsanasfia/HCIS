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
using Inventory.Dialogs;
using Inventory.Forms;
namespace Inventory.Dialogs
{
    public partial class dlgProductParent : DevExpress.XtraEditors.XtraForm
    {
        public DataClassesDataContext dc { get; set; }
        public Product P { get; set; }
        public dlgProductParent()
        {
            InitializeComponent();
        }

        private void dlgProductParent_Load(object sender, EventArgs e)
        {
            LNull.Text = P.FaName;
            productBindingSource.DataSource = dc.Products.Where(c => P.ID == c.Parent).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}