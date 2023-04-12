using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class dlgDiet : DevExpress.XtraEditors.XtraForm
    {

        HCISDataContext dc = new HCISDataContext();
        string Today = MainModule.GetPersianDate(DateTime.Now);

        GivenServiceM ObjectGSM;
        Service FoodService;
        public List<Diet> lstDiet { get; set; }
        public dlgDiet()
        {
            InitializeComponent();
        }

        private void frmDiet_Load(object sender, EventArgs e)
        {
           // givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10 && x.Admitted == true && x.DepartmentID == Classes.MainModule.MyDepartment.ID && x.Confirm != true).ToList();
            FoodService = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "غذا");
            var DietType = dc.Services.FirstOrDefault(x => x.CategoryID == 10 && x.Name == "نوع رژیم");
            DietTypeBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 10 && x.ParentID == DietType.ID).ToList();
            DietServiceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 10 && x.ParentID == FoodService.ID && x.ID != DietType.ID).ToList();

            var Current = MainModule.GSM_Set;

            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time).FirstOrDefault();
            if (LastDiet != null)
                txtDiet.Text =  LastDiet.Service.Name;
            else
            {
                MessageBox.Show("رژیم از طرف پزشک مشخص نشده");
                DialogResult = DialogResult.Cancel;
                return;
            }
            ObjectGSM = Current;
              getdata();
            
            lstDiet = new List<Diet>();
        }

        private void btnAddDiet_Click(object sender, EventArgs e)
        {
            try
            {
                Diet Parent;
                var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Time).OrderByDescending(x => x.GivenServiceD.Date).FirstOrDefault();
                if (LastDiet != null)
                    Parent = LastDiet;
                else
                {
                    MessageBox.Show("رژیم از طرف پزشک مشخص نشده");
                    return;
                }
                var BF = lkpBreakfast.EditValue as Service;
                var Lnch = lkpLunch.EditValue as Service;
                var Dnn = lkpDinner.EditValue as Service;
              
                if (BF != null)
                {
                    var DietBF = new Diet()
                    {
                        Service = BF,
                        GivenServiceD = Parent.GivenServiceD,
                        CreationDate = Today,
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Meal = "صبحانه",
                        ParentID=Parent.ID,
                        Along = rdgFor.EditValue as bool?,
                    };
                    lstDiet.Add(DietBF);
                }
                if (Lnch != null)
                {
                    var DietLnch = new Diet()
                    {
                        Service = Lnch,
                        GivenServiceD = Parent.GivenServiceD,
                        CreationDate = Today,
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Meal = "ناهار",
                        ParentID = Parent.ID,
                        Along = rdgFor.EditValue as bool?,
                    };
                    lstDiet.Add(DietLnch); 
                }
                if (Dnn != null)
                {
                    var DietDnn = new Diet()
                    {
                        Service = Dnn,
                        GivenServiceD = Parent.GivenServiceD,
                        CreationDate = Today,
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Meal = "شام",
                        ParentID = Parent.ID,
                        Along = rdgFor.EditValue as bool?,
                    };
                    lstDiet.Add(DietDnn);
                }  
                lkpBreakfast.EditValue = null;
                lkpDessert.EditValue = null;
                lkpDinner.EditValue = null;
                lkpLunch.EditValue = null;
                dc.SubmitChanges();
                getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ورود اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void getdata()
        {
            var gsd = ObjectGSM.GivenServiceDs.FirstOrDefault(c => c.Service == FoodService);
            if(gsd!=null)
            dietBindingSource.DataSource = gsd.Diets;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}