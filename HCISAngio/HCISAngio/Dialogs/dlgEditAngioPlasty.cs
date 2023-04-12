using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISAngio.Data;
using HCISAngio.Classes;

namespace HCISAngio.Dialogs
{
    public partial class dlgEditAngioPlasty : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSD;
        Angio ObjectANG;

        public dlgEditAngioPlasty()
        {
            InitializeComponent();
        }

        private void EndEdit()
        {
            AngioPBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (ObjectANG == null)
                {
                    ObjectANG = new Angio();
                }

                GSDAngioPBindingSource.DataSource = ObjectGSD;
                AngioPBindingSource.DataSource = ObjectANG;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void dlgEditAngioPlasty_Load(object sender, EventArgs e)
        {
            personPBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            servicePBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوپلاستی).ToList();
            servicePSalamatCodeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوپلاستی).ToList();

            GivenServiceM GSMP = null;
            GSMP = ObjectGSD.GivenServiceM;

            if (GSMP != null)
            {
                ObjectANG = GSMP.Angio;
            }
            GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}