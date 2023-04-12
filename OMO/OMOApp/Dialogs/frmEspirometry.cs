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
    public partial class frmEspirometry : BaseDialog
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmEspirometry(Document document,ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();
            this.CurrentDocument = dc.Documents.FirstOrDefault(c => c.ID == document.ID);
            this.FormType = FormViewType;
            if (FormType == ViewType.View)
                return;
            if (dc.Espirometries.Where(c => c.Document == CurrentDocument).Any())
                FormType = frmEspirometry.ViewType.Edit;
            else
                FormType = frmEspirometry.ViewType.New;

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
                Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
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

        private void frmEspirometry_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
           var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            switch (FormType)
            {
                case ViewType.New:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var espiro = new Espirometry()
                    {

                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        EspirometricDate = today,
                        EspirometricDone = MainModule.UserID,
                        EspirometricInterpreter = MainModule.UserID,
                        EspirometricPFTDate = today,
                        EspirometricPFTDone = MainModule.UserID,
                        EspirometricPFTInterpreter = MainModule.UserID,
                        EspirometricPFTTime = now,
                        EspirometricTime = now,
                        MTCDate = today,
                        MTCDone = MainModule.UserID,
                        MTCInterpreter = MainModule.UserID,
                        MTCTime = now,
                        PietysmographyDate = today,
                        PietysmographyDone = MainModule.UserID,
                        PietysmographyInterpreter = MainModule.UserID,
                        PietysmographyTime = now
                    };

                    CurrentDocument.Espirometries.Add(espiro);
                    espirometryBindingSource.DataSource = espiro;
                    break;
                case ViewType.View:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    espirometryBindingSource.DataSource = CurrentDocument.Espirometries.First();
                    MainModule.MakeReadOnly(layoutControlGroup1);

                    break;
                case ViewType.Edit:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    espirometryBindingSource.DataSource = CurrentDocument.Espirometries.First();
                    break;
                default:
                    break;
            }
        }
    }
}