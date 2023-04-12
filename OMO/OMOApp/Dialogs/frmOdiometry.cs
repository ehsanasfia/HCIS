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
    public partial class frmOdiometry : BaseDialog
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmOdiometry(ViewType FormViewType)
        {
            InitializeComponent();
            this.FormType = FormViewType;
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

        private void frmOdiometry_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
           var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            switch (FormType)
            {
                case ViewType.New:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var odio = new Odiometry()
                    {

                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        HearingDetectionDate = today,
                        HearingDetectionDone = MainModule.UserID,
                        HearingDetectionInterpreter = MainModule.UserID,
                        HearingDetectionTime = now,
                        OdiometryDate = today,
                        OdiometryDone = MainModule.UserID,
                        OdiometryInterpreter = MainModule.UserID,
                        OdiometryTime = now,
                    };

                    CurrentDocument.Odiometries.Add(odio);
                    OdiometryBindingSource.DataSource = odio;
                    break;
                case ViewType.View:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    OdiometryBindingSource.DataSource = CurrentDocument.Odiometries.First();
                    MainModule.MakeReadOnly(layoutControlGroup1);

                    break;
                case ViewType.Edit:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    OdiometryBindingSource.DataSource = CurrentDocument.Odiometries.First();
                    break;
                default:
                    break;
            }
        }
    }
}