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
using HCISManagementDashboard.Data;
using DevExpress.XtraEditors.DXErrorProvider;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace HCISManagementDashboard.Forms
{
    public partial class frmAdmitted : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();

        public frmAdmitted()
        {
            InitializeComponent();
        }
        
        private void frmAdmitted_Load(object sender, EventArgs e)
        {
            var today = MainModule.today;
            txtFromDate.Text = MainModule.month_start;
            txtToDate.Text = today;
            spnYear1.Value = MainModule.year_num;
            spnYear2.Value = MainModule.year_num;
            cmbMonths.Properties.Items.Clear();
            cmbMonths.Properties.Items.AddRange(MainModule.all_months_names);
            txtFromDate.Select();
            var amount = dc.AllDayVisits.Where(x => x.Date == today).FirstOrDefault();
            if (amount == null || amount.Count == null)
            {
                txtToday.Text = "0";
                return;
            }
            else
                txtToday.Text = amount.Count.ToString();
        }

        private void btnFromTo_Click(object sender, EventArgs e)
        {
            var lst = dc.AllDayVisits.Where(x => x.Date.CompareTo(txtFromDate.Text) >= 0 && x.Date.CompareTo(txtToDate.Text) <= 0).ToList();
            int? amount;
            if(lst.Any())
            {
                amount = lst.Sum(c => c.Count);
                if (amount == null)
                {
                    amount = 0;
                }
            }
            else
            {
                amount = 0;
            }
            txtAmountFromTO.Text = amount.ToString();
            spnYear1.Select();
        }

        private void btnSByMonth_Click(object sender, EventArgs e)
        {
            string MonthNumber = MainModule.GetPersianDate(DateTime.Now).Substring(5, 2);
            //var monthName = MainModule.GetPersianMonthName(DateTime.Now);
            //if (monthName == "فروردین")
            //    MonthNumber = "01";
            //if (monthName == "اردیبهشت")
            //    MonthNumber = "02";
            //if (monthName == "خرداد")
            //    MonthNumber = "03";
            //if (monthName == "تیر")
            //    MonthNumber = "04";
            //if (monthName == "مرداد")
            //    MonthNumber = "05";
            //if (monthName == "شهریور")
            //    MonthNumber = "06";
            //if (monthName == "مهر")
            //    MonthNumber = "07";
            //if (monthName == "آبان")
            //    MonthNumber = "08";
            //if (monthName == "آذر")
            //    MonthNumber = "09";
            //if (monthName == "دی")
            //    MonthNumber = "10";
            //if (monthName == "بهمن")
            //    MonthNumber = "11";
            //if (monthName == "اسفند")
            //    MonthNumber = "12";

            allMonthVisitBindingSource.DataSource = dc.AllMonthVisits.Where(x => x.Year == spnYear1.Text && x.MontNum.CompareTo(MonthNumber) <= 0).OrderBy(c => c.MontNum);
            cmbMonths.Select();
        }

        private void btnSByDay_Click(object sender, EventArgs e)
        {
            ConditionValidationRule notEmpty = new ConditionValidationRule();
            notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty.ErrorText = ".ماه را انتخاب کنید";

            dxValidationProvider1.SetValidationRule(cmbMonths, notEmpty);
            if (!dxValidationProvider1.Validate())
                return;

            var lst = dc.AllDayVisits.Where(x => x.Date != null && x.Date.Substring(0, 4) == spnYear2.Text && x.Month == cmbMonths.Text).ToList();
            if (lst.Any())
            {
                int year = int.Parse(spnYear2.Text);
                int month = int.Parse(lst.ElementAt(0).Date.Substring(5, 2));
                var days = (int)MainModule.GetPersianLastDayOfMonth(year, month);
                for (int i = 1; i <= days; i++)
                {
                    if (!lst.Any(x => x.DayNum == i))
                    {
                        lst.Add(new AllDayVisit()
                        {
                            DayNum = i,
                            Count = 0
                        });
                    }
                }
            }

            allDayVisitBindingSource.DataSource = lst;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chartControl1.ExportToPdf("D:Doc1.pdf");
            string filename = "D:Doc1.pdf";
            System.Diagnostics.Process.Start(filename);
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {
            btnShowRadialMenu_ItemClick(null, null);
        }

        private void btnShowRadialMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Display Radial Menu
            if (RightChartMenu == null) return;
            Point pt = this.Location;
            pt.Offset(this.Width / 2, this.Height / 2);
            RightChartMenu.ShowPopup(pt);
        }
        private void btnShowRadialMenu2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Display Radial Menu
            if (LeftChartMenu == null) return;
            Point pt = this.Location;
            pt.Offset(this.Width / 2, this.Height / 2);
            LeftChartMenu.ShowPopup(pt);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            chartControl1.ExportToXlsx("D:Doc1.xlsx");
            string filename = "D:Doc1.xlsx";
            System.Diagnostics.Process.Start(filename);

            //SaveFileDialog sf = new SaveFileDialog();
            //sf.ShowDialog();
            //string savePath = Path.GetDirectoryName(sf.FileName);
            //savePath.Replace(@"\",":");
            //chartControl1.ExportToXlsx(savePath);
            //System.Diagnostics.Process.Start(savePath);
        }

        private void chartControl2_Click(object sender, EventArgs e)
        {
            btnShowRadialMenu2_ItemClick(null, null);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            chartControl2.ExportToXlsx("D:Doc2.xlsx");
            string filename = "D:Doc2.xlsx";
            System.Diagnostics.Process.Start(filename);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            chartControl2.ExportToPdf("D:Doc2.pdf");
            string filename = "D:Doc2.pdf";
            System.Diagnostics.Process.Start(filename);
        }

        private void RightChartImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            chartControl1.ExportToImage("D:Doc3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string filename = "D:Doc3.jpg";
            System.Diagnostics.Process.Start(filename);
        }

        private void cmbMonths_EditValueChanged(object sender, EventArgs e)
        {
            btnSByDay_Click(null,null);
        }
    }
}