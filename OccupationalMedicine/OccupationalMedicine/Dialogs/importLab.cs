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
using System.IO;
using OccupationalMedicine.Classes;
using Excel = Microsoft.Office.Interop.Excel;
using LabEI = OccupationalMedicine.Classes.LabExcelIndexes;
using OccupationalMedicine.Dialogs;

namespace OccupationalMedicine.Dialogs
{
    public partial class importLab : DevExpress.XtraEditors.XtraForm
    {
        public importLab()
        {
            InitializeComponent();
        }
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        private void simpleButton1_Click(object sender, EventArgs e)

        {
            try
            {
                if (slkContract.EditValue == null)
                {
                    MessageBox.Show("لطفا قرارداد را انتخاب کنید.");
                    return;
                }
                MainModule.DefaultContarct = slkContract.EditValue as Contract;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog1.Title = "فایل اکسل را انتخاب کنید";
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                if (!splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.ShowWaitForm();

                splashScreenManager2.SetWaitFormDescription("در حال باز کردن فایل..");
                string path = openFileDialog1.FileName;
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path, ReadOnly: true);
                Excel._Worksheet xlWorksheet = xlWorkBook.Sheets[1];
                Excel.Range xl = xlWorksheet.UsedRange;
                if (xl.Rows.Count < 1)
                {
                    MessageBox.Show("فرمت فایل اکسل صحیح نیست", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                ///// add ExelFile in List

                splashScreenManager2.SetWaitFormDescription("در حال خواندن اطلاعات از فایل...");
                List<TestAnswerFile> TafList = new List<TestAnswerFile>();

                for (int i = 2; i < xl.Rows.Count; i++)
                {
                    TestAnswerFile taf = new TestAnswerFile();
                    taf.SerialNumber = valueOf(xl.Cells[i, LabEI.شماره_پذیرش]);
                    taf.Index = i;
                    //  taf.Name = valueOf( xl.Cells[i, LabEI.نام_آزمایش]);
                    //   taf.Answer = valueOf(xl.Cells[i, LabEI.جواب]);
                    //   taf.Cat = valueOf(xl.Cells[i, LabEI.بخش]);
                    TafList.Add(taf);
                }
                TafList.OrderBy(c => c.SerialNumber);
                ///// add ExelFile in List
                splashScreenManager2.SetWaitFormDescription("در حال وارد کردن اطلاعات...");
                var MyVisits = dc.Visits.Where(c => c.ContractNumber == MainModule.DefaultContarct.ContractNumber).ToList();
                MyVisits.OrderBy(c => c.LabCode);
                /////Find and insert data in dc
                foreach (var item in MyVisits)
                {
                    var lst = TafList.Where(c => c.SerialNumber == item.LabCode).ToList();
                    if (lst.Count != 0)
                    {
                        var labItem = item.LabTests.FirstOrDefault() == null ? new LabTest() : item.LabTests.FirstOrDefault();

                        foreach (var test in lst)
                        {

                            setLabItem(test.Index, ref labItem, xl);
                        }
                        labItem.Visit = item;

                        labItem.ContractNumber = MainModule.DefaultContarct.ContractNumber;
                        labItem.PersonalCode = item.PersonalCode;
                        if (labItem.ID == 0)
                            dc.LabTests.InsertOnSubmit(labItem);
                    }
                }

                splashScreenManager2.SetWaitFormDescription("در حال ذخیره اطلاعات...");
                dc.SubmitChanges();

                /////Find and insert data in dc

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
                MessageBox.Show("ثبت آزمایشات با موفقیت انجام شد.");
            }
        }

        private void setLabItem(int index, ref LabTest labItem, Excel.Range xl)
        {
            for (int y = 7; y < xl.Columns.Count; y++)
            {

                switch ((String)(valueOf(xl.Cells[1, y])))
                {
                    case ("802000-WBC"):
                        {
                            labItem.CWBC = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800200-WBC")://Urin
                        {
                            labItem.UWBC = (String)(valueOf(xl.Cells[index, y]));
                            if (!string.IsNullOrWhiteSpace(labItem.UWBC) && labItem.UWBC.Trim().ToLower() == "many")
                            {
                                labItem.UWBC = ">=10";
                            }
                            break;
                        }
                    case ("802000-RBC"):
                        {
                            labItem.CRBC = (String)(valueOf(xl.Cells[index, y])); ;

                            break;
                        }
                    case ("800200-RBC"):
                        {
                            labItem.URBC = (String)(valueOf(xl.Cells[index, y])); ;
                            if (!string.IsNullOrWhiteSpace(labItem.URBC) && labItem.URBC.Trim().ToLower() == "many")
                            {
                                labItem.URBC = ">=10";
                            }
                            break;
                        }

                    case ("802000-Hb"):
                        {
                            labItem.CHb = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("802000-Hct"):
                        {
                            labItem.CHCT = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("802000-Plat"):
                        {
                            labItem.CPlt = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800400-FBS"):
                        {
                            labItem.FBS = decimal.Parse((String)(valueOf(xl.Cells[index, y])));
                            break;
                        }
                    case ("800415-BUN"):
                        {
                            labItem.BUN = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800420-Cr"):
                        {
                            labItem.Cr = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800425-Uric Acid"):
                        {
                            labItem.URICAcid = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800435-Chol"):
                        {
                            labItem.TotalChol = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800430-TG"):
                        {
                            labItem.TG = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800440-HDL"):
                        {
                            labItem.HDL = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800445-LDL"):
                        {
                            labItem.LDL = decimal.Parse((String)(valueOf(xl.Cells[index, y])));
                            break;
                        }
                    case ("800530-SGOT"):
                        {
                            labItem.AST = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800535-SGPT"):
                        {
                            labItem.ALT = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800540-ALK"):
                        {
                            labItem.ALKPh = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800200-Protein"):
                        {
                            labItem.UProt = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800200-Glucose"):
                        {
                            labItem.UGlu = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800200-Blood"):
                        {
                            labItem.UBlood = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("800200-Bacteria"):
                        {
                            labItem.UBact = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                 case ("803205-HBSAg(ECL)")://HBSAg 
                        {
                            labItem.HBSAg = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }


                    case ("800800-HbA1c")://HbA1C
                        {
                            labItem.HbA1C = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("803220-HBSAb(ECL)")://HBSAb
                        {
                            labItem.HBSAb = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("801415-TSH")://TSH
                        {
                            labItem.TSH = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("PPD")://PPD
                        {
                            labItem.PPD = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }

                    case ("801820-PSA"):
                        {
                            labItem.PSA = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("SE,OB"):
                        {
                            labItem.SEOB = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }
                    case ("VitD3"):
                        {
                            labItem.VitD3 = (String)(valueOf(xl.Cells[index, y]));
                            break;
                        }

                }
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

        private String valueOf(dynamic cell)
        {
            if (!hasValue(cell))
                return null;

            return cell.Value2.ToString().Trim();
        }
        private void setLabItem(string TestName, string TestAnswer, string CatTest, ref Data.LabTest LabItem)
        {

            switch (TestName)
            {
                case ("WBC"):
                    {
                        if (CatTest != "Urine Analysis")
                            LabItem.CWBC = TestAnswer;
                        else
                        {
                            LabItem.UWBC = TestAnswer;
                            if (!string.IsNullOrWhiteSpace(LabItem.UWBC) && LabItem.UWBC.Trim().ToLower() == "many")
                            {
                                LabItem.UWBC = ">=10";
                            }
                        }
                        break;
                    }
                case ("RBC"):
                    {
                        if (CatTest != "Urine Analysis")
                            LabItem.CRBC = TestAnswer;
                        else
                        {
                            LabItem.URBC = TestAnswer;
                            if (!string.IsNullOrWhiteSpace(LabItem.URBC) && LabItem.URBC.Trim().ToLower() == "many")
                            {
                                LabItem.URBC = ">=10";
                            }
                        }
                        break;
                    }

                case ("Hb"):
                    {
                        LabItem.CHb = TestAnswer;
                        break;
                    }
                case ("Hct"):
                    {
                        LabItem.CHCT = TestAnswer;
                        break;
                    }
                case ("Plat"):
                    {
                        LabItem.CPlt = TestAnswer;
                        break;
                    }
                case ("FBS"):
                    {
                        LabItem.FBS = decimal.Parse(TestAnswer);
                        break;
                    }
                case ("BUN"):
                    {
                        LabItem.BUN = TestAnswer;
                        break;
                    }
                case ("Cr"):
                    {
                        LabItem.Cr = TestAnswer;
                        break;
                    }
                case ("Uric Acid"):
                    {
                        LabItem.URICAcid = TestAnswer;
                        break;
                    }
                case ("Chol"):
                    {
                        LabItem.TotalChol = TestAnswer;
                        break;
                    }
                case ("TG"):
                    {
                        LabItem.TG = TestAnswer;
                        break;
                    }
                case ("HDL"):
                    {
                        LabItem.HDL = TestAnswer;
                        break;
                    }
                case ("LDL"):
                    {
                        LabItem.LDL = decimal.Parse(TestAnswer);
                        break;
                    }
                case ("SGOT"):
                    {
                        LabItem.AST = TestAnswer;
                        break;
                    }
                case ("SGPT"):
                    {
                        LabItem.ALT = TestAnswer;
                        break;
                    }
                case ("ALK"):
                    {
                        LabItem.ALKPh = TestAnswer;
                        break;
                    }
                case ("Protein"):
                    {
                        LabItem.UProt = TestAnswer;
                        break;
                    }
                case ("Glucose"):
                    {
                        LabItem.UGlu = TestAnswer;
                        break;
                    }
                case ("Blood"):
                    {
                        LabItem.UBlood = TestAnswer;
                        break;
                    }
                case ("Bacteria"):
                    {
                        LabItem.UBact = TestAnswer;
                        break;
                    }
                case ("HBSAg"):
                    {
                        LabItem.HBSAg = TestAnswer;
                        break;
                    }


                case ("HbA1C"):
                    {
                        LabItem.HbA1C = TestAnswer;
                        break;
                    }
                case ("HBSAb"):
                    {
                        LabItem.HBSAb = TestAnswer;
                        break;
                    }
                case ("TSH"):
                    {
                        LabItem.TSH = TestAnswer;
                        break;
                    }
                case ("PPD"):
                    {
                        LabItem.PPD = TestAnswer;
                        break;
                    }

                case ("PSA"):
                    {
                        LabItem.PSA = TestAnswer;
                        break;
                    }
                case ("SE,OB"):
                    {
                        LabItem.SEOB = TestAnswer;
                        break;
                    }
                case ("VitD3"):
                    {
                        LabItem.VitD3 = TestAnswer;
                        break;
                    }

            }


        }

        Data.OccupationalMedicineClassesDataContext dc = new OccupationalMedicineClassesDataContext();

        private void importLab_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            contractBindingSource.DataSource = dc.Contracts.ToList();
        }
    }

}