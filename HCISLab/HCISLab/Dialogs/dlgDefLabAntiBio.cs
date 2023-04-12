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
    public partial class dlgDefLabAntiBio : DevExpress.XtraEditors.XtraForm
    {
        private HCISLabClassesDataContext dc;
        public LabAntiBiogram EditingLA { get; set; }
        public dlgDefLabAntiBio(HCISLabClassesDataContext dc)
        {
            InitializeComponent();
            this.dc = dc;
        }

        private void dlgDefLabAntiBio_Load(object sender, EventArgs e)
        {
            if (EditingLA != null)
            {
                txtName.Text = EditingLA.Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var name = txtName.Text.Trim();

                if (name.Length >= 50)
                {
                    MessageBox.Show("نام باید کمتر از 50 کاراکتر باشد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (EditingLA == null)
                {
                    EditingLA = new LabAntiBiogram() { Name = name, Active = true };
                    dc.LabAntiBiograms.InsertOnSubmit(EditingLA);
                }
                else
                {
                    EditingLA.Name = name;
                }

                dc.SubmitChanges();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}