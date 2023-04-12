using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgCountCategory : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        List<Vw_NurceCountCategory> lst = new List<Vw_NurceCountCategory>();

        public dlgCountCategory()
        {
            InitializeComponent();
        }

        private void dlgCountCategory_Load(object sender, EventArgs e)
        {
            lst = dc.Vw_NurceCountCategories.Where(x => x.DepName != null && x.DepName != "" && x.DepName != " " && (x.CatName == "آزمایش"
            || x.CatName == "ویزیت"
            || x.CatName ==  "خدمات تشخیصی"
            || x.CatName == "داروهای مصرفی"
            || x.CatName == "ارجاع")).ToList();
            vwNurceCountCategoryBindingSource.DataSource = lst;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var MyData = (from c in ((IEnumerable<Vw_NurceCountCategory>)lst).ToList()
                         select new { c.Doctor , c.CatName, c.C, c.DepName, c.ym}).ToList();
            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now).ToString());
            stiReport1.RegData("MyData", MyData);
            stiReport1.Compile();
            stiReport1.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}