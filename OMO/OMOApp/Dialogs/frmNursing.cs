using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using OMOApp.Data.IMData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class frmNursing : BaseDialog
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmNursing(Document Document,ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();

            CurrentDocument = dc.Documents.FirstOrDefault(c => c.ID == Document.ID);
            if (FormViewType == ViewType.View)
            {
                this.FormType = FormViewType;
                return;
            }
            if (CurrentDocument.NurseDiagnoses.Any() && FormViewType == ViewType.New)
                FormType = ViewType.Edit;
            else
                this.FormType = FormViewType;

        }

        public enum ViewType
        {
            New,
            View,
            Edit,
            EditBloodPressure
        }

        internal bool SaveChanges(bool ShowMessage)
        {
            bool result = false;
            try
            {
                Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                        CurrentDocument.NurseDiagnoses.First().CreationUser = MainModule.UserID;


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

        private void frmNursing_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
           var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            switch (FormType)
            {
                case ViewType.New:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var nursy = new NurseDiagnose()
                    {

                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        Date = today,
                        Time = now
                    };

                    CurrentDocument.NurseDiagnoses.Add(nursy);
                    NursingBindingSource.DataSource = nursy;
                    break;
                case ViewType.View:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    NursingBindingSource.DataSource = CurrentDocument.NurseDiagnoses.First();
                    MainModule.MakeReadOnly(layoutControlGroup1);
                    break;
                case ViewType.Edit:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    NursingBindingSource.DataSource = CurrentDocument.NurseDiagnoses.First();
                    break;
                case ViewType.EditBloodPressure:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    NursingBindingSource.DataSource = CurrentDocument.NurseDiagnoses.First();
                    //MainModule.MakeReadOnly(layoutControlGroup1);
                    //bPDiastolySpinEdit.Properties.ReadOnly = false;
                    //bPSistolySpinEdit.Properties.ReadOnly = false;
                    break;
                default:
                    break;
            }
        }

        private void heghtSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var h = heghtSpinEdit.Value / 100;
                lblBMI.Text = String.Format("{0}", weightSpinEdit.Value / (h * h));
            }
            catch (Exception)
            {
                lblBMI.Text = "";
            }
        }
    }
}