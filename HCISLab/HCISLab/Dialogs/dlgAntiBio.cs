using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgAntiBio : BaseDialog
    {
        public HCISLabClassesDataContext dc { get; set; }
        public string Result { get; set; }

        private List<LabAntiBiogram> lst;
        public dlgAntiBio()
        {
            InitializeComponent();
        }

        private void dlgAntiBio_Load(object sender, EventArgs e)
        {
            lst = dc.LabAntiBiograms.OrderBy(x => x.Name).ToList();
            lst.ForEach(x => x.Sensitive = x.Resistance = x.Intermediate = false);
            labAntiBiogramsBindingSource.DataSource = lst;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool hasSensitive = false, hasIntermediate = false, hasResistance = false;
            string Sensitive = "Sensitive = ";
            string Intermediate = "Intermediate = ";
            string Resistance = "Resistance = ";

            foreach (var item in lst)
            {
                if (item.Sensitive)
                {
                    hasSensitive = true;
                    Sensitive += item.Name + ", ";
                }

                if (item.Intermediate)
                {
                    hasIntermediate = true;
                    Intermediate += item.Name + ", ";
                }

                if (item.Resistance)
                {
                    hasResistance = true;
                    Resistance += item.Name + ", ";
                }
            }

            Result = "";

            if (hasSensitive)
            {
                Sensitive = Sensitive.Trim();
                if (Sensitive.LastOrDefault() == ',')
                    Sensitive = Sensitive.Remove(Sensitive.Length - 1);
                Result += Sensitive + Environment.NewLine;
            }

            if (hasIntermediate)
            {
                Intermediate = Intermediate.Trim();
                if (Intermediate.LastOrDefault() == ',')
                    Intermediate = Intermediate.Remove(Intermediate.Length - 1);
                Result += Intermediate + Environment.NewLine;
            }

            if (hasResistance)
            {
                Resistance = Resistance.Trim();
                if (Resistance.LastOrDefault() == ',')
                    Resistance = Resistance.Remove(Resistance.Length - 1);
                Result += Resistance;
            }

            Result = Result.Trim();

            if (Result.Length > 500)
            {
                MessageBox.Show("تعداد دارو های انتخاب شده بیش از اندازه است.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                Result = null;
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}