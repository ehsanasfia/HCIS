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
using System.IO;
using OccupationalMedicine.Classes;
using Excel = Microsoft.Office.Interop.Excel;
using EI = OccupationalMedicine.Classes.ExcelIndexes;
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Forms
{
    public partial class frmReciption : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();
        Person EditingPerson;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public frmReciption()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmReciption_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            GetData();
            EditingPerson = new Person() { Sex = "مرد", MaritalStatus = "متأهل", MilitaryServiceStatus = "خدمت کرده" };
            personBindingSource.DataSource = EditingPerson;
            SexRdg.SelectedIndex = 0;
            gridControl1_Enter(null, null);
        }
        private void EndEdit()
        {
          
            personBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                gridControl1_Enter(null, null);
                PersonalCodeTxt.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }


        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EditingPerson.Name) || EditingPerson.Name.GetType() == typeof(DBNull))
            {
                MessageBox.Show("نام را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (string.IsNullOrWhiteSpace(EditingPerson.LastName) || EditingPerson.LastName.GetType() == typeof(DBNull))
            {
                MessageBox.Show("نام خانوادگی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if (string.IsNullOrWhiteSpace(EditingPerson.PersonalCode) || EditingPerson.PersonalCode.GetType() == typeof(DBNull))
            {
                MessageBox.Show("کد ملی را وارد کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (EditingPerson.Sex == "مرد")
            {
                if (EditingPerson.MilitaryServiceStatus == "خدمت کرده")
                    EditingPerson.MedicalReason = null;
                else if (EditingPerson.MilitaryServiceStatus == "معافیت پزشکی")
                    EditingPerson.ServingCommunities = null;
            }
            else if (EditingPerson.Sex == "زن")
            {
                EditingPerson.MilitaryServiceStatus = null;
                EditingPerson.MedicalReason = null;
                EditingPerson.ServingCommunities = null;
            }
            if (PersonalPicturePic.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap objBitmap = new Bitmap(PersonalPicturePic.Image, 120, 120);

                    objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    // PersonalPicturePic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                    EditingPerson.PersonalPicture = binary;
                }
            }
            else
                EditingPerson.PersonalPicture = null;
            try
            {

                EndEdit();
                EditingPerson.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                EditingPerson.ModificationUserId = MainModule.UserID;
                EditingPerson.ModificationUserFullName = MainModule.UserFullName;
                EditingPerson.Password = EditingPerson.BirthDate;
                if (!dc.Persons.Any(x => x.ID == EditingPerson.ID))
                {
                    EditingPerson.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingPerson.CreationUserId = MainModule.UserID;
                    EditingPerson.CreationUserFullName = MainModule.UserFullName;
                    //if (dc.Persons.Any(d => d.PersonalCode == PersonalCodeTxt.Text))
                    //{
                    //    MessageBox.Show("شماره پرسنلی تکراری است", "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    //    return;
                    //}
                    if (dc.Persons.Any(x => x.PersonalCode == EditingPerson.PersonalCode))
                    {
                        MessageBox.Show("کد ملی تکراری است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    //if (EditingPerson.Visits.Any())
                    //{
                    //    foreach (var item in EditingPerson.Visits.Where(p => p.PersonalCode == EditingPerson.PersonalCode))
                    //    { }
                    //}

                    dc.Persons.InsertOnSubmit(EditingPerson);
                }

                dc.SubmitChanges();
                EditingPerson = new Person() { Sex = "مرد", MaritalStatus = "متأهل", MilitaryServiceStatus = "خدمت کرده" };
                personBindingSource.DataSource = EditingPerson;
                GetData();
                //   MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                dc.Dispose();
                dc = new OccupationalMedicineClassesDataContext();
                EditingPerson = new Person() { Sex = "مرد", MaritalStatus = "متأهل", MilitaryServiceStatus = "خدمت کرده" };
                PersonalPicturePic.Image = null;
                personBindingSource.DataSource = EditingPerson;
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void SexRdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SexRdg.SelectedIndex == 0)
            {
                MilitaryServiceStatusRdg.Enabled = ServingCommunitiesTxt.Enabled = MedicalReasonTxt.Enabled = true;
                EditingPerson.MilitaryServiceStatus = "خدمت کرده";
            }
            else if (SexRdg.SelectedIndex == 1)
            {
                MilitaryServiceStatusRdg.Enabled = ServingCommunitiesTxt.Enabled = MedicalReasonTxt.Enabled = false;
            }
            MilitaryServiceStatusRdg_SelectedIndexChanged(null, null);
        }

        private void MilitaryServiceStatusRdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MilitaryServiceStatusRdg.Enabled)
            {
                if (MilitaryServiceStatusRdg.SelectedIndex == 0)
                {
                    ServingCommunitiesTxt.Enabled = true;
                    MedicalReasonTxt.Enabled = false;
                    EditingPerson.MedicalReason = null;
                }
                else if (MilitaryServiceStatusRdg.SelectedIndex == 1)
                {
                    ServingCommunitiesTxt.Enabled = false;
                    EditingPerson.ServingCommunities = null;
                    MedicalReasonTxt.Enabled = true;
                }
            }
            else
            {
                ServingCommunitiesTxt.Enabled = MedicalReasonTxt.Enabled = false;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = personsTopResultBindingSource.Current;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            Person person = null;
            if (cur.GetType() == typeof(Person))
                person = cur as Person;
            else if (cur.GetType() == typeof(Persons_TopResult))
            {
                var ptr = cur as Persons_TopResult;
                person = dc.Persons.FirstOrDefault(x => x.ID == ptr.ID);
            }

            dc.Dispose();
            dc = new OccupationalMedicineClassesDataContext();
            EditingPerson = dc.Persons.FirstOrDefault(x => x.ID == person.ID);
            personBindingSource.DataSource = EditingPerson;
            if (EditingPerson.PersonalPicture != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = EditingPerson.PersonalPicture.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    PersonalPicturePic.Image = Image.FromStream(ms);
                }
            }
            else
                PersonalPicturePic.Image = null;

            //if (EditingPerson.Visits.Any())
            //{
            //    PersonalCodeTxt.ReadOnly = true;
            //    return;
            //}
            gridControl1_Enter(null, null);
        }

      

        private void gridShowRdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void PersonalPicturePic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || PersonalPicturePic.Image == null)
                return;

            var dlg = new Dialogs.dlgPicture() { img = PersonalPicturePic.Image };
            dlg.ShowDialog();
        }

        private void btnImportFromExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog1.Title = "فایل اکسل را انتخاب کنید";

                openFileDialog1.CheckPathExists = true;
                openFileDialog1.CheckFileExists = true;

                openFileDialog1.DefaultExt = "xlsx";
                openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                if (!splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.ShowWaitForm();
                string path = openFileDialog1.FileName;
                //string text = File.ReadAllText(path);
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path, ReadOnly: true);
                Excel._Worksheet xlWorksheet = xlWorkBook.Sheets[1];
                Excel.Range xl = xlWorksheet.UsedRange;
                //MessageBox.Show(xl.Columns.Count + "\r\n" + xl.Rows.Count);
                if (xl.Columns.Count != 15 || xl.Rows.Count < 1 || xl.Cells[1, EI.شماره_پرونده].Value2.ToString().Trim() != "01-شماره پرونده")
                {
                    MessageBox.Show("فرمت فایل اکسل صحیح نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var colCount = xl.Columns.Count;
                var rowCount = xl.Rows.Count;
                var c = xl.Cells;

                List<Person> lstPersons = new List<Person>();

                for (int i = 2; i <= rowCount; i++)
                {
                    var prs = new Person()
                    {
                        FileNumber = valueOf(c[i, EI.شماره_پرونده]),
                        Name = valueOf(c[i, EI.نام]),
                        LastName = valueOf(c[i, EI.نام_خانوادگی]),
                        FatherName = valueOf(c[i, EI.نام_پدر]),
                        WorkPhone = valueOf(c[i, EI.تلفن_محل_کار]),
                        WorkAddress = valueOf(c[i, EI.آدرس_محل_کار]),
                        ServingCommunities = valueOf(c[i, EI.رسته_خدمت]),
                        MedicalReason = valueOf(c[i, EI.علت_معافیت_پزشکی]),
                        ExcelIndex = i,
                    };

                    if (string.IsNullOrWhiteSpace(prs.Name))
                    {
                        prs.InComplete = true;
                        prs.InCompleteIndexes.Add((int)EI.نام);
                    }

                    if (string.IsNullOrWhiteSpace(prs.LastName))
                    {
                        prs.InComplete = true;
                        prs.InCompleteIndexes.Add((int)EI.نام_خانوادگی);
                    }

                    string NationalCode = null;
                    if (hasValue(c[i, EI.شماره_پرسنلی]))
                    {
                        NationalCode = valueOf(c[i, 2]).Replace("-", "").Replace("_", "").Replace(" ", "");
                        prs.NationalCode = NationalCode;
                    }

                    string PersonalCode = null;
                    if (hasValue(c[i, EI.کد_ملی]))
                    {
                        PersonalCode = valueOf(c[i, EI.کد_ملی]).Replace("-", "").Replace("_", "").Replace(" ", "");
                        if (string.IsNullOrWhiteSpace(PersonalCode) || PersonalCode.Length != 10)
                        {
                            prs.InComplete = true;
                            prs.InCompleteIndexes.Add((int)EI.کد_ملی);
                        }
                        else
                        {
                            prs.PersonalCode = PersonalCode;
                        }
                    }
                    else
                    {
                        prs.InComplete = true;
                        prs.InCompleteIndexes.Add((int)EI.کد_ملی);
                    }


                    string Sex = null;
                    if (hasValue(c[i, EI.جنسیت]))
                    {
                        Sex = valueOf(c[i, EI.جنسیت]);
                        if (Sex != "مرد" && Sex != "زن")
                        {
                            if (Sex == "مرذ" || Sex == "مذکر" || Sex == "آقا" || Sex == "آقای")
                            {
                                Sex = "مرد";
                                prs.Sex = Sex;
                            }
                            else if (Sex == "ذن" || Sex == "رن" || Sex == "مونث" || Sex == "مؤنث" || Sex == "خانم")
                            {
                                Sex = "زن";
                                prs.Sex = Sex;
                            }
                            else
                            {
                                prs.InCompleteIndexes.Add((int)EI.جنسیت);
                            }
                        }
                        else
                        {
                            prs.Sex = Sex;
                        }
                    }

                    string MaritalStatus = null;
                    if (hasValue(c[i, EI.وضعیت_تاهل]))
                    {
                        MaritalStatus = valueOf(c[i, EI.وضعیت_تاهل]);
                        if (MaritalStatus != "مجرد" && MaritalStatus != "متاهل")
                        {
                            if (MaritalStatus == "مجرذ")
                            {
                                MaritalStatus = "مجرد";
                                prs.MaritalStatus = MaritalStatus;
                            }
                            else if (MaritalStatus == "متاهل" || MaritalStatus == "متأهل")
                            {
                                MaritalStatus = "متأهل";
                                prs.MaritalStatus = MaritalStatus;
                            }
                            else
                            {
                                prs.InCompleteIndexes.Add((int)EI.وضعیت_تاهل);
                            }
                        }
                        else
                        {
                            prs.MaritalStatus = MaritalStatus;
                        }
                    }

                    string ChildCount = null;
                    if (hasValue(c[i, EI.تعداد_فرزند]))
                    {
                        ChildCount = valueOf(c[i, EI.تعداد_فرزند]);
                        int result = 0;
                        if (int.TryParse(ChildCount, out result))
                        {
                            prs.ChildCount = result;
                        }
                        else
                        {
                            prs.InCompleteIndexes.Add((int)EI.تعداد_فرزند);
                        }
                    }

                    string BirthDate = null;
                    if (hasValue(c[i, EI.سال_تولد]))
                    {
                        BirthDate = valueOf(c[i, EI.سال_تولد]).Replace("-", "").Replace("_", "").Replace("/", "").Replace(" ", "");
                        if (string.IsNullOrWhiteSpace(BirthDate))
                        {
                            prs.InCompleteIndexes.Add((int)EI.سال_تولد);
                        }
                        else if (BirthDate.Length == 2)
                        {
                            BirthDate = "13" + BirthDate;
                            prs.BirthDate = BirthDate;
                        }
                        else if (BirthDate.Length == 8)
                        {
                            BirthDate = BirthDate.Substring(0, 4);
                            prs.BirthDate = BirthDate;
                        }
                        else if (BirthDate.Length == 4)
                        {
                            prs.BirthDate = BirthDate;
                        }
                        else
                        {
                            prs.InCompleteIndexes.Add((int)EI.سال_تولد);
                        }
                    }

                    //TODO check values 
                    string MilitaryServiceStatus = null;
                    if (hasValue(c[i, EI.وضعیت_نظام_وظیفه]))
                    {
                        MilitaryServiceStatus = valueOf(c[i, EI.وضعیت_نظام_وظیفه]);
                        if (MilitaryServiceStatus != "خدمت کرده" && MilitaryServiceStatus != "معافیت پزشکی")
                        {
                            MilitaryServiceStatus = MilitaryServiceStatus.Replace("_", "").Replace(" ", "").Replace("ذ", "د").Replace("ز", "ر").Replace("ي", "ی").Replace("ك", "ک");
                            if (MilitaryServiceStatus == "خدمتکرده")
                            {
                                MilitaryServiceStatus = "خدمت کرده";
                                prs.MilitaryServiceStatus = MilitaryServiceStatus;
                            }
                            else if (MilitaryServiceStatus == "معافیتپرشکی")
                            {
                                MilitaryServiceStatus = "معافیت پزشکی";
                                prs.MilitaryServiceStatus = MilitaryServiceStatus;
                            }
                            else
                            {
                                prs.InCompleteIndexes.Add((int)EI.وضعیت_نظام_وظیفه);
                            }
                        }
                        else
                        {
                            prs.MilitaryServiceStatus = MilitaryServiceStatus;
                        }
                    }

                    lstPersons.Add(prs);

                }

                var dlg = new dlgExcelPersons() { lstPersons = lstPersons, dc = dc };
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
        }

        private bool hasValue(dynamic obj)
        {
            if (obj == null)
                return false;

            if (obj.Value2 == null || string.IsNullOrWhiteSpace(obj.Value2.ToString()))
                return false;

            return true;
        }

        private string valueOf(dynamic cell)
        {
            if (!hasValue(cell))
                return null;

            return cell.Value2.ToString().Trim();
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            if (gridControl1.Focused)
                btnEdit.Enabled = true;
            else
                btnEdit.Enabled = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCodeForSearch.Text.Length == 10)
                personsTopResultBindingSource.DataSource = dc.Persons.Where(c => c.PersonalCode == txtCodeForSearch.Text).ToList();
            else
                MessageBox.Show("کد ملی به درستی وارد نشده");
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            if (txtNameForSearch.Text.Trim() != "" && txtLNameForSearch.Text.Trim() == "")
                personsTopResultBindingSource.DataSource = dc.Persons.Where(c => c.Name .Contains( txtNameForSearch.Text) ).ToList();
            else
                if (txtNameForSearch.Text.Trim() != "" && txtLNameForSearch.Text.Trim() != "")
                personsTopResultBindingSource.DataSource = dc.Persons.Where(c => c.Name.Contains(txtNameForSearch.Text) && c.LastName.Contains(txtLNameForSearch.Text)).ToList();
            else if (txtNameForSearch.Text.Trim() == "" && txtLNameForSearch.Text.Trim() != "")
                personsTopResultBindingSource.DataSource = dc.Persons.Where(c => c.LastName.Contains(txtLNameForSearch.Text)).ToList();
            else
            MessageBox.Show("نام یا نام خانوادگی به درستی وارد نشده");
         }
    }
}