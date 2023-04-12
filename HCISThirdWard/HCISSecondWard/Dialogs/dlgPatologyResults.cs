using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISSecondWard.Dialogs
{
    
    public partial class dlgPatologyResults : DevExpress.XtraEditors.XtraForm
    {
        public string rtf { get; set; }
        public dlgPatologyResults()
        {
            InitializeComponent();
        }

        private void dlgPatologyResults_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = rtf;
        }
    }
}