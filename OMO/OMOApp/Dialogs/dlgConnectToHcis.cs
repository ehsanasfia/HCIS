using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgConnectToHcis : DevExpress.XtraEditors.XtraForm
    {
        public dlgConnectToHcis()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var Connect = Boolean.Parse(radioGroup1.EditValue.ToString());

            if (Connect)
                MainModule.ConnectToHcis = true;
            else
                MainModule.ConnectToHcis = false;

            Properties.Settings.Default.ConnectToHcis = Connect;
            Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

        private void dlgConnectToHcis_Load(object sender, EventArgs e)
        {

            var Connect = Properties.Settings.Default.ConnectToHcis;
            if (Connect)
            {
                radioGroup1.EditValue = true;
            }
            else
            {
                radioGroup1.EditValue = false;
            }
        
        }
    }
}