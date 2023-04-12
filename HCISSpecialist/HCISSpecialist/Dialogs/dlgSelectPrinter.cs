using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgSelectPrinter : DevExpress.XtraEditors.XtraForm
    {
        public dlgSelectPrinter()
        {
            InitializeComponent();
        }

        private void dlgSelectPrinter_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Properties.Items.Add(printer);
            }

            
            cmbPrinter.SelectedItem = Properties.Settings.Default.PrinterName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrinterName = cmbPrinter.SelectedItem as string;

            Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }
    }
}