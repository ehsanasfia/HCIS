using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using OMOApp.Data.IMData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class frmPsychology : BaseDialog
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        public frmPsychology(Document Document,ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();

            CurrentDocument = dc.Documents.FirstOrDefault(c => c.ID == Document.ID);
            if (FormViewType == ViewType.View)
            {
                this.FormType = FormViewType;
                return;
            }
            if (CurrentDocument.PsychologyTests.Any() && FormViewType == ViewType.New)
                FormType = ViewType.Edit;
            else
                this.FormType = FormViewType;
        }
        IMClassesDataContext dc = new IMClassesDataContext();
        public enum ViewType
        {
            New,
            View,
            Edit
        }


        internal bool SaveChanges(bool ShowMessage)
        {
            bool result = false;
            try
            {
                Validate();
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                    {
                        CurrentDocument.PsychologyTests.First().ModificationUser = MainModule.UserID;
                        CurrentDocument.PsychologyTests.First().ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                    }


                    dc.SubmitChanges();
                    if (ShowMessage)
                        MessageBox.Show("اطلاعات وارد شده با موفقیت ذخیره گردید", "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                //RejectChanges();
            }
            return result;
        }

        private void DepressionScoreSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            DepressionResultComboBoxEdit.SelectedIndex = GetDepressionResultFromScore(Convert.ToByte(DepressionScoreSpinEdit.EditValue));
        }

        private byte GetDepressionResultFromScore(byte score)
        {
            byte result = 0;
            if (score <= 9)
                result = 0;
            else if (score <= 13)
                result = 1;
            else if (score <= 20)
                result = 2;
            else if (score <= 27)
                result = 3;
            else
                result = 4;

            return result;
        }

        private void AnxietyScoreSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            AnxietyResultComboBoxEdit.SelectedIndex = GetAnxietyResultFromScore(Convert.ToByte(AnxietyScoreSpinEdit.EditValue));
        }

        private int GetAnxietyResultFromScore(byte score)
        {
            byte result = 0;
            if (score <= 7)
                result = 0;
            else if (score <= 9)
                result = 1;
            else if (score <= 14)
                result = 2;
            else if (score <= 19)
                result = 3;
            else
                result = 4;

            return result;
        }

        private void StressScoreSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            StressResultComboBoxEdit.SelectedIndex = GetResultStressFromScore(Convert.ToByte(StressScoreSpinEdit.EditValue));
        }

        private int GetResultStressFromScore(byte score)
        {
            byte result = 0;
            if (score <= 14)
                result = 0;
            else if (score <= 18)
                result = 1;
            else if (score <= 25)
                result = 2;
            else if (score <= 33)
                result = 3;
            else
                result = 4;

            return result;
        }

        private void frmPsychology_Load(object sender, EventArgs e)
        {

            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            switch (FormType)
            {
                case ViewType.New:
                    var psy = new PsychologyTest()
                    {
                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        DASS42Date = today,
                        DASS42Time = now,
                    };

                    CurrentDocument.PsychologyTests.Add(psy);
                    psychologyTestBindingSource.DataSource = psy;
                    break;
                case ViewType.View:
                    psychologyTestBindingSource.DataSource = CurrentDocument.PsychologyTests.First();
                    MainModule.MakeReadOnly(layoutControlGroup1);

                    break;
                case ViewType.Edit:
                    psychologyTestBindingSource.DataSource = CurrentDocument.PsychologyTests.First();
                    break;
                default:
                    break;
            }
        }
    }
}