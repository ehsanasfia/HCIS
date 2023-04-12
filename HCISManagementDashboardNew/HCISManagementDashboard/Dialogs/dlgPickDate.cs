using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISManagementDashboard.Data;

namespace HCISManagementDashboard.Dialogs
{
    public partial class dlgPickDate : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public dlgPickDate()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (spnYear.Value == 0 || string.IsNullOrWhiteSpace(cmbMonth.Text))
            {
                MessageBox.Show("لطفا اطلاعات را با دقت وارد کنید");
                return;
            }

            var From = spnYear.Value.ToString() + "/" + cmbMonth.Text + "/01";
            var engDate = MainModule.GetDateFromPersianString(From);
            var EndDate = MainModule.GetPersianLastDateOfMonth(engDate);

            //splashScreenManager2.ShowWaitForm();
            //try
            //{
            dc.CommandTimeout = 100000;
            var lst = dc.Spu_ExcelReport(From, EndDate).ToList();

            //بستری ویزیت
            var VisitBakhshSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت های بستری") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitBakhshSherkati", VisitBakhshSherkati.C);

            var VisitBakhshBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت های بستری") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitBakhshBazneshaste", VisitBakhshBazneshaste.C);

            var VisitBakhshQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت های بستری") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("VisitBakhshQeyreSherkati", VisitBakhshQeyreSherkati.C);

            //بستری مشاوره
            var MoshavereBakhshSherkati = lst.FirstOrDefault(x => x.CatName.Contains("مشاوره در بخش") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("MoshavereBakhshSherkati", MoshavereBakhshSherkati.C);

            var MoshavereBakhshBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("مشاوره در بخش") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("MoshavereBakhshBazneshaste", MoshavereBakhshBazneshaste.C);

            var MoshavereBakhshQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("مشاوره در بخش") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("MoshavereBakhshQeyreSherkati", MoshavereBakhshQeyreSherkati.C);

            //هتلینگ عادی

            var HotelingNormalSherkati = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ عادی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("HotelingNormalSherkati", HotelingNormalSherkati.C);

            var HotelingNormalBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ عادی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("HotelingNormalBazneshaste", HotelingNormalBazneshaste.C);

            var HotelingNormalQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ عادی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("HotelingNormalQeyreSherkati", HotelingNormalQeyreSherkati.C);

            //هتلینگ ویژه

            var HotelingSpecialSherkati = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ ویژه") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("HotelingSpecialSherkati", HotelingSpecialSherkati.C);

            var HotelingSpecialBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ ویژه") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("HotelingSpecialBazneshaste", HotelingSpecialBazneshaste.C);

            var HotelingSpeciallQeyreSherkat = lst.FirstOrDefault(x => x.CatName.Contains("هتلینگ ویژه") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("HotelingSpeciallQeyreSherkat", HotelingSpeciallQeyreSherkat.C);

            //خدمات تخصصی گروه داخلی	

            var WardServiceSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در بخش") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("WardServiceSherkati", WardServiceSherkati.C);

            var WardServiceBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در بخش") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("WardServiceBazneshaste", WardServiceBazneshaste.C);

            var WardServiceQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در بخش") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("WardServiceQeyreSherkati", WardServiceQeyreSherkati.C);

            //حق العمل جراح

            var SurgerySherkati = lst.FirstOrDefault(x => x.CatName.Contains("جراحی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("SurgerySherkati", SurgerySherkati.C);

            var SurgeryBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("جراحی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("SurgeryBazneshaste", SurgeryBazneshaste.C);

            var SurgeryQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("جراحی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("SurgeryQeyreSherkati", SurgeryQeyreSherkati.C);

            //حق العمل بیهوشی

            var AnastisiaSherkati = lst.FirstOrDefault(x => x.CatName.Contains("بیهوشی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("AnastisiaSherkati", AnastisiaSherkati.C);

            var AnastisiaBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("بیهوشی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("AnastisiaBazneshaste", AnastisiaBazneshaste.C);

            var AnastisiaQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("بیهوشی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("AnastisiaQeyreSherkati", AnastisiaQeyreSherkati.C);

            //ویزیت عمومی

            var VisitOmomiSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت عمومی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitOmomiSherkati", VisitOmomiSherkati.C);

            var VisitOmomiBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت عمومی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitOmomiBazneshaste", VisitOmomiBazneshaste.C);

            var VisitOmomiQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت عمومی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("VisitOmomiQeyreSherkati", VisitOmomiQeyreSherkati.C);

            //ویزیت متخصص

            var VisitMotekhasesSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت متخصص") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitMotekhasesSherkati", VisitMotekhasesSherkati.C);

            var VisitMotekhasesBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت متخصص") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitMotekhasesBazneshaste", VisitMotekhasesBazneshaste.C);

            var VisitMotekhasesQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت متخصص") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("VisitMotekhasesQeyreSherkati", VisitMotekhasesQeyreSherkati.C);

            //ویزیت فوق تخصص

            var VisitFoqeMotekhasesSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت فوق تخصص") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitFoqeMotekhasesSherkati", VisitFoqeMotekhasesSherkati.C);

            var VisitFoqeMotekhasesBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت فوق تخصص") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("VisitFoqeMotekhasesBazneshaste", VisitFoqeMotekhasesBazneshaste.C);

            var VisitFoqeMotekhasesQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("ویزیت فوق تخصص") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("VisitFoqeMotekhasesQeyreSherkati", VisitFoqeMotekhasesQeyreSherkati.C);

            //دندانپزشک

            var DentistSherkati = lst.FirstOrDefault(x => x.CatName.Contains("دندانپزشکی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DentistSherkati", DentistSherkati.C);

            var DentistBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("دندانپزشکی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DentistBazneshaste", DentistBazneshaste.C);

            var DentistQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("دندانپزشکی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("DentistQeyreSherkati", DentistQeyreSherkati.C);

            //آزمایشگاه

            var TestSherkati = lst.FirstOrDefault(x => x.CatName.Contains("آزمایشات") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("TestSherkati", TestSherkati.C);

            var TestBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("آزمایشات") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("TestBazneshaste", TestBazneshaste.C);

            var TestQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("آزمایشات") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("TestQeyreSherkati", TestQeyreSherkati.C);

            //تصویربرداری

            var DsSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات تشخیصی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DsSherkati", DsSherkati.C);

            var DsBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("خدمات تشخیصی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DsBazneshaste", DsBazneshaste.C);

            var DsQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات تشخیصی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("DsQeyreSherkati", DsQeyreSherkati.C);

            //داروخانه 

            var DrugSherkati = lst.FirstOrDefault(x => x.CatName.Contains("داروهای مصرفی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DrugSherkati", DrugSherkati.Price);

            var DrugBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("داروهای مصرفی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("DrugBazneshaste", DrugBazneshaste.Price);

            var DrugQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("داروهای مصرفی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("DrugQeyreSherkati", DrugQeyreSherkati.Price);

            //لوازم مصرفی

            var ConsumSherkati = lst.FirstOrDefault(x => x.CatName.Contains("لوازم مصرفی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("ConsumSherkati", ConsumSherkati.Price);

            var ConsumBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("لوازم مصرفی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("ConsumBazneshaste", ConsumBazneshaste.Price);

            var ConsumQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("لوازم مصرفی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("ConsumQeyreSherkati", ConsumQeyreSherkati.Price);

            //خدمات تخصصی گروه داخلی

            var ParaSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در کلینیک") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("ParaSherkati", ParaSherkati.C);

            var ParaBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در کلینیک") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("ParaBazneshaste", ParaBazneshaste.C);

            var ParaQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("خدمات پاراکلینیکی انجام شده در کلینیک") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("ParaQeyreSherkati", ParaQeyreSherkati.C);

            //اتاق عمل سرپایی

            var StandSurgerySherkati = lst.FirstOrDefault(x => x.CatName.Contains("عمل های سرپایی") && x.insurance.Contains("شاغلین و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("StandSurgerySherkati", StandSurgerySherkati.C);

            var StandSurgeryBazneshaste = lst.FirstOrDefault(x => x.CatName.Contains("عمل های سرپایی") && x.insurance.Contains("بازنشسته و تحت تکفل"));
            ExcelReport.Dictionary.Variables.Add("StandSurgeryBazneshaste", StandSurgeryBazneshaste.C);

            var StandSurgeryQeyreSherkati = lst.FirstOrDefault(x => x.CatName.Contains("عمل های سرپایی") && x.insurance.Contains("غیرشرکتی"));
            ExcelReport.Dictionary.Variables.Add("StandSurgeryQeyreSherkati", StandSurgeryQeyreSherkati.C);

            ExcelReport.Dictionary.Variables.Add("FromDate", From);
            ExcelReport.Dictionary.Variables.Add("ToDate", EndDate);

            //ExcelReport.Design();
            ExcelReport.Dictionary.Synchronize();
            ExcelReport.Compile();
            ExcelReport.Render();
            ExcelReport.ShowWithRibbonGUI();

            //}
            //finally
            //{
            //    splashScreenManager2.CloseWaitForm();
            //}


        }

        private void dlgPickDate_Load(object sender, EventArgs e)
        {

            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;


        }
    }
}