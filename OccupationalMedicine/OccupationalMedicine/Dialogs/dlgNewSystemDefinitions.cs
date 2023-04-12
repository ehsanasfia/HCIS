using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Data;
using OccupationalMedicine.Dialogs;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgNewSystemDefinitions : DevExpress.XtraEditors.XtraForm
    {
        public OccupationalMedicineClassesDataContext db { get; set; }
        bool IsEdit = false;
        public Definition ObjDef { get; set; }

        public dlgNewSystemDefinitions()
        {
            InitializeComponent();
        }

        private void dlgNew_Load(object sender, EventArgs e)
        {

            if (ObjDef == null)
            {
                ObjDef = new Definition();
            }
            else
                IsEdit = true;

            definitionBindingSource.DataSource = ObjDef;

            //  ParentIDLookUpEdit.EditValue = db.Definitions.Where(c => c.ID == Id).FirstOrDefault() as Definition;
            ObjDef.Parent = Forms.frmSystemDefinitions.DefinationField.ID;

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (NameTextEdit.Text.Trim() == "")
            {
                MessageBox.Show("نام وارد نشده است، امکان ثبت وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (IsEdit)
            {

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                try
                {
                    db.Definitions.InsertOnSubmit(ObjDef);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            DialogResult = DialogResult.OK;

        }
    }
}