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
    public partial class dlgEditAngiography : DevExpress.XtraEditors.XtraForm
    {
        public HCISAngioDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSD;
        Angio ObjectANG;

        public dlgEditAngiography()
        {
            InitializeComponent();
        }

        private void EndEdit()
        {
            AngioGBindingSource.EndEdit();
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

                GSDAngioGBindingSource.DataSource = ObjectGSD;
                AngioGBindingSource.DataSource = ObjectANG;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void dlgEditAngiography_Load(object sender, EventArgs e)
        {
            personGBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            serviceGBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوگرافی).ToList();
            serviceGSalamatCodeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.آنژیوگرافی).ToList();
            angioResultBindingSource.DataSource = dc.AngioResults.ToList();

            GivenServiceM GSMG = null;
            GSMG = ObjectGSD.GivenServiceM;

            if (GSMG != null)
            {
                ObjectANG = GSMG.Angio;
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