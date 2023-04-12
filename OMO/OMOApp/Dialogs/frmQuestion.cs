using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.IMData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class frmQuestion : BaseForm
    {
        public ViewType FormType;

        public Person CurrentPerson { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmQuestion(Person currentPerson, ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();
            this.CurrentPerson = dc.Persons.FirstOrDefault(c => c.ID == currentPerson.ID);
            if (FormViewType == ViewType.View)
            {
                this.FormType = FormViewType;
                return;
            }

            if (CurrentPerson.QuestionResultMs.Any())
                FormType = ViewType.Edit;
            else
                FormType = ViewType.New;
        }

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
                //Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                    {
                        var currentM = questionResultMBindingSource.Current as QuestionResultM;
                        currentM.ModificationDate = MainModule.GetPersianDate(DateTime.Now); ;
                        currentM.ModificationUser = MainModule.UserID;
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
            }
            return result;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");


            switch (FormType)
            {
                case ViewType.New:
                    CurrentPerson = dc.Persons.Single(c => c == CurrentPerson);
                    var questionM = new QuestionResultM()
                    {
                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        Date = today,
                        Time = now,
                    };

                    foreach (Question item in dc.Questions)
                        questionM.QuestionResultDs.Add(new QuestionResultD()
                        {
                            Question = item,
                            Yes = false
                        });


                    CurrentPerson.QuestionResultMs.Add(questionM);
                    questionResultMBindingSource.DataSource = questionM;
                    break;
                case ViewType.View:
                    CurrentPerson = dc.Persons.Single(c => c == CurrentPerson);
                    questionResultMBindingSource.DataSource = CurrentPerson.QuestionResultMs.First();

                    MainModule.MakeReadOnly(layoutControlGroup1);
                    break;
                case ViewType.Edit:
                    CurrentPerson = dc.Persons.Single(c => c == CurrentPerson);
                    var currentM = CurrentPerson.QuestionResultMs.First();
                    questionResultMBindingSource.DataSource = currentM;

                    foreach (Question item in dc.Questions.Except(dc.Questions.Where(c=>currentM.QuestionResultDs.Select(d=>d.QuestionID).Contains(c.ID))))
                    {
                        currentM.QuestionResultDs.Add(
                        new QuestionResultD()
                        {
                            Question = item
                        });
                    }
                    break;
                default:
                    break;
            }
            questionBindingSource.DataSource = dc.Questions;
            //gridView1.BestFitColumns();
        }

        private void questionResultGridControl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            MainModule.GridViewRightToLeft(sender, e);
        }

        private void questionResultGridControl_Enter(object sender, EventArgs e)
        {
            MainModule.GridEnterRightToLeft(sender, e);
        }

        private void dateTextEdit_Validating(object sender, CancelEventArgs e)
        {
            MainModule.EditorValidate(sender, dxErrorProvider1, e);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as QuestionResultD;
            if (row == null)
                return;

            /*colPacketYear.Visible=*/
            colSigarretCount.OptionsColumn.AllowEdit = colSigarretCount.OptionsColumn.AllowFocus = colYears.OptionsColumn.AllowEdit = colYears.OptionsColumn.AllowFocus =
                row.QuestionID == 15 || row.QuestionID == 26;
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as QuestionResultD;

            if (row == null)
                return;

            if (e.Column == colSigarretCount)
            {
                var years = Convert.ToDouble(row.YearCount ?? 0.0);

                row.PacketYear = Convert.ToInt16((Convert.ToDouble(e.Value ?? 0.0) / 20.0) * years);
            }
            else if (e.Column == colYears)
            {

                var sigarCount = Convert.ToDouble(row.SigarretCount ?? 0.0) / 20.0;

                row.PacketYear = Convert.ToInt16(Convert.ToDouble(e.Value ?? 0.0) * sigarCount);
            }
        }
    }
}
