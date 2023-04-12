using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Data;
using EI = OccupationalMedicine.Classes.ExcelIndexes;
using OccupationalMedicine.Forms;
using OccupationalMedicine.Classes;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgExcelPersons : DevExpress.XtraEditors.XtraForm
    {
        public List<Person> lstPersons { get; set; }
        public OccupationalMedicineClassesDataContext dc { get; set; }
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public dlgExcelPersons()
        {
            InitializeComponent();
        }

        private void dlgExcelPersons_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            splashScreenManager2.ShowWaitForm();
            try
            {
                foreach (var col in gridView1.Columns.ToList())
                {
                    if (col.FieldName == "FileNumber")
                    {
                        col.Tag = EI.شماره_پرونده;
                    }
                    else if (col.FieldName == "Name")
                    {
                        col.Tag = EI.نام;
                    }
                    else if (col.FieldName == "LastName")
                    {
                        col.Tag = EI.نام_خانوادگی;
                    }
                    else if (col.FieldName == "FatherName")
                    {
                        col.Tag = EI.نام_پدر;
                    }
                    else if (col.FieldName == "BirthDate")
                    {
                        col.Tag = EI.سال_تولد;
                    }
                    else if (col.FieldName == "Sex")
                    {
                        col.Tag = EI.جنسیت;
                    }
                    else if (col.FieldName == "MaritalStatus")
                    {
                        col.Tag = EI.وضعیت_تاهل;
                    }
                    else if (col.FieldName == "ChildCount")
                    {
                        col.Tag = EI.تعداد_فرزند;
                    }
                    else if (col.FieldName == "PersonalCode")
                    {
                        col.Tag = EI.کد_ملی;
                    }
                    else if (col.FieldName == "MilitaryServiceStatus")
                    {
                        col.Tag = EI.وضعیت_نظام_وظیفه;
                    }
                    else if (col.FieldName == "ServingCommunities")
                    {
                        col.Tag = EI.رسته_خدمت;
                    }
                    else if (col.FieldName == "MedicalReason")
                    {
                        col.Tag = EI.علت_معافیت_پزشکی;
                    }
                    else if (col.FieldName == "WorkPhone")
                    {
                        col.Tag = EI.تلفن_محل_کار;
                    }
                    else if (col.FieldName == "WorkAddress")
                    {
                        col.Tag = EI.آدرس_محل_کار;
                    }
                }
                gridControl1.DataSource = lstPersons;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                Close();
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var prs = gridView1.GetRow(e.RowHandle) as Person;
            if (prs == null)
                return;


            if (e.Column == null || e.Column.Tag == null || e.Column.Tag.GetType() != typeof(EI))
                return;

            var colIndex = (EI)e.Column.Tag;

            if (prs.InCompleteIndexes.Contains((int)colIndex))
            {
                if (colIndex == EI.کد_ملی || colIndex == EI.نام || colIndex == EI.نام_خانوادگی)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 128, 128);
                    e.Appearance.BackColor2 = Color.FromArgb(255, 128, 128);
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Options.UseBackColor = true;
                    e.Appearance.Options.UseForeColor = true;
                }
                else
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 128);
                    e.Appearance.BackColor2 = Color.FromArgb(255, 255, 128);
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.Options.UseBackColor = true;
                    e.Appearance.Options.UseForeColor = true;
                }
            }
            else
            {
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.BackColor2 = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                gridView1.CloseEditor();
                var today = MainModule.GetPersianDate(DateTime.Now);
                var now = DateTime.Now.ToString("HH:mm");
                bool hasError = false;
                string errorStr = "";
                foreach (var prs in lstPersons)
                {
                    if (prs.InComplete)
                    {
                        if (prs.InCompleteIndexes.Contains((int)EI.کد_ملی) && (string.IsNullOrWhiteSpace(prs.PersonalCode) || prs.PersonalCode.Length != 10))
                        {
                            hasError = true;
                            errorStr += "لطفا کد ملی ردیف " + prs.ExcelIndex + " را به طور صحیح وارد کنید." + "\n";
                        }
                        if (prs.InCompleteIndexes.Contains((int)EI.نام) && string.IsNullOrWhiteSpace(prs.Name))
                        {
                            hasError = true;
                            errorStr += "لطفا نام ردیف " + prs.ExcelIndex + " را وارد کنید." + "\n";
                        }
                        if (prs.InCompleteIndexes.Contains((int)EI.نام_خانوادگی) && string.IsNullOrWhiteSpace(prs.LastName))
                        {
                            hasError = true;
                            errorStr += "لطفا نام خانوادگی ردیف " + prs.ExcelIndex + " را وارد کنید." + "\n";
                        }
                    }

                    if (prs.Sex == "مرد")
                    {
                        if (prs.MilitaryServiceStatus == "خدمت کرده")
                            prs.MedicalReason = null;
                        else if (prs.MilitaryServiceStatus == "معافیت پزشکی")
                            prs.ServingCommunities = null;
                    }
                    else if (prs.Sex == "زن")
                    {
                        prs.MilitaryServiceStatus = null;
                        prs.MedicalReason = null;
                        prs.ServingCommunities = null;
                    }

                    if (!string.IsNullOrWhiteSpace(prs.PersonalCode) && prs.PersonalCode.Length == 10 && (lstPersons.Any(x => x.PersonalCode == prs.PersonalCode && x.GetHashCode() != prs.GetHashCode()) || dc.Persons.Any(x => x.PersonalCode == prs.PersonalCode) ))
                    {
                        hasError = true;
                        errorStr += "کد ملی ردیف " + prs.ExcelIndex + " تکراری است." + "\n";
                    }

                    prs.ModificationDate = today;
                    prs.ModificationUserId = MainModule.UserID;
                    prs.ModificationUserFullName = MainModule.UserFullName;
                    prs.Password = prs.BirthDate;
                    prs.CreationDate = today;
                    prs.CreationUserId = MainModule.UserID;
                    prs.CreationUserFullName = MainModule.UserFullName;
                }

                if (hasError)
                {
                    if (splashScreenManager2.IsSplashFormVisible)
                        splashScreenManager2.CloseWaitForm();
                    MessageBox.Show(errorStr.Trim(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                dc.Persons.InsertAllOnSubmit(lstPersons);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var prs = gridView1.GetRow(e.RowHandle) as Person;
            if (prs == null)
                return;

            if (e.Column == null || e.Column.Tag == null || e.Column.Tag.GetType() != typeof(EI))
                return;

            var colIndex = (EI)e.Column.Tag;
            if (colIndex == EI.نام)
            {
                if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    prs.InComplete = true;
                    prs.InCompleteIndexes.Add((int)EI.نام);
                }
                else
                {
                    prs.InCompleteIndexes.Remove((int)EI.نام);
                    if (!prs.InCompleteIndexes.Any())
                        prs.InComplete = false;
                }
            }
            else if (colIndex == EI.نام_خانوادگی)
            {
                if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    prs.InComplete = true;
                    prs.InCompleteIndexes.Add((int)EI.نام_خانوادگی);
                }
                else
                {
                    prs.InCompleteIndexes.Remove((int)EI.نام_خانوادگی);
                    if (!prs.InCompleteIndexes.Any())
                        prs.InComplete = false;
                }
            }
            else if (colIndex == EI.کد_ملی)
            {
                if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()) || e.Value.ToString().Trim().Length != 10)
                {
                    prs.InComplete = true;
                    prs.InCompleteIndexes.Add((int)EI.کد_ملی);
                }
                else
                {
                    prs.InCompleteIndexes.Remove((int)EI.کد_ملی);
                    if (!prs.InCompleteIndexes.Any())
                        prs.InComplete = false;
                }
            }
            else
            {
                prs.InCompleteIndexes.Remove((int)colIndex);
                if (!prs.InCompleteIndexes.Any())
                    prs.InComplete = false;
            }
            gridView1.RefreshRowCell(e.RowHandle, e.Column);
        }

        private void btnRemove_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }
    }
}