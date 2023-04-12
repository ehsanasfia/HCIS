using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISDrugStore.Dialogs;
using HCISDrugStore.Data;
using SecurityLoginsAndAccessControl;


namespace HCISDrugStore
{
    public partial class frmBackService : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        List<GivenServiceM> lst = new List<GivenServiceM>();

        public frmBackService()
        {
            InitializeComponent();
        }

      
        private void bbiAdvancedSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var dlg = new Dialogs.dlgAdvancedSearch() { dc = dc };
            //if (dlg.ShowDialog() != DialogResult.OK) return;

            //dlgPayment dlgP = new Dialogs.dlgPayment();
            //dlgP.Local = true;
            //dlgP.person = dlg.EditingPerson;
            //dlgP.dc = this.dc;
            //if (dlgP.ShowDialog() == DialogResult.OK)
            //{
            //    if (MessageBox.Show("آیا مایلید قبض را دریافت کنید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            //    {
            //        dlgP.stiReport1.CompiledReport.ShowWithRibbonGUI();
            //    }
            //    getdata();
            //}
        }

        private void FrmCash_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Theme;
            var PD = MainModule.GetPersianDate(DateTime.Now);
            //  PD = "1396/01/14";
            dossierBindingSource.DataSource = dc.Dossiers.Where(y => y.GivenServiceMs.Any(d =>d.DepartmentID==MainModule.MyDepartment.ID && d.Payed == true && d.Cancelled==false && d.Reflected == false && d.ServiceCategoryID== (Int32)Category.دارو && d.CreationDate==PD));

            if (dossierBindingSource.Count > 0)
                bbiPayed.Enabled = true;
            else
                bbiPayed.Enabled = false;

          
        }

        private void bbiPayed_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Current = dossierBindingSource.Current as Dossier;
            if (Current == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
          
            else
            {
                dlgBackService dlg = new Dialogs.dlgBackService();
                dlg.Local = false;
                dlg.dossier = Current;
                dlg.person = Current.Person;
                dlg.ServiceCategory = (Int32)Category.دارو;

                dlg.dc = this.dc;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    getdata();
                }
            }
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //dlgAdvancedSearch d = new dlgAdvancedSearch();
            //d.ShowDialog();
        }
        // public struct x {string FirstName ,LastName,Name, NationalCode;};
        private void btnSearch_Click(object sender, EventArgs e)
        {

            getdata();  
        }


        void getdata()
        {
            var PD = MainModule.GetPersianDate(DateTime.Now);
            dossierBindingSource.DataSource =
                dc.Dossiers.Where(y => y.GivenServiceMs.
               Any(d => d.DepartmentID == MainModule.MyDepartment.ID && d.Reflected == true  && d.Payed == true && d.Reflected==false && d.CreationDate==PD && d.ServiceCategoryID== (Int32)Category.دارو &&
               d.Cancelled==false));
        }
        private void bbiTodayPatiant_ItemClick(object sender, ItemClickEventArgs e)
        {
            var PD = MainModule.GetPersianDate(DateTime.Now);
            dossierBindingSource.DataSource = dc.Dossiers.Where(y => 
            y.GivenServiceMs.Any(d => d.DepartmentID == MainModule.MyDepartment.ID && d.Payed == true && d.Cancelled == false 
            && d.Reflected == false && d.ServiceCategoryID == (Int32)Category.دارو &&
            d.CreationDate == PD));

            if (dossierBindingSource.Count > 0)
                bbiPayed.Enabled = true;
            else
                bbiPayed.Enabled = false;
            
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

     

      

        private void grdPersonView_DoubleClick(object sender, EventArgs e)
        {
            bbiPayed.PerformClick();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var a = new dlgPaidcatch();
            //a.dc = dc;
            //a.ShowDialog();
        }

        private void grdService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bbiPayed.PerformClick();
            }

        }

        private void btnLED_ItemClick(object sender, ItemClickEventArgs e)
        {
            var crnt = personBindingSource.Current as Person;
            if (crnt == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = crnt.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.Payed == true).ToList();
            var gsm = lst.OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).FirstOrDefault();

            stiReport1.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.Dictionary.Variables.Add("Person", gsm.Person.FirstName + " " + gsm.Person.LastName + "");
            stiReport1.Dictionary.Variables.Add("Staff", gsm.Agenda.Staff.Person.FirstName + " " + gsm.Agenda.Staff.Person.LastName + "");
            stiReport1.Dictionary.Variables.Add("Speciality", gsm.Agenda.Staff.Speciality + "");
            stiReport1.Dictionary.Variables.Add("AdmitDate", gsm.AdmitDate + "");
            stiReport1.Dictionary.Variables.Add("DailySN", gsm.DailySN + "");
            
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //stiReport1.Design();
        }

        private void btnStand_ItemClick(object sender, ItemClickEventArgs e)
        {
            var crnt = personBindingSource.Current as Person;
            if (crnt == null)
            {
                MessageBox.Show("لطفا یک بیمار را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            lst = crnt.GivenServiceMs.Where(x => x.ServiceCategoryID == 3 && x.Payed == true).ToList();
            var gsm = lst.OrderByDescending(c => c.CreationTime).OrderByDescending(c => c.CreationDate).FirstOrDefault();

            stiReport2.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport2.Dictionary.Variables.Add("AdmitDate", gsm.AdmitDate + "");
            stiReport2.Dictionary.Variables.Add("NationalCode", gsm.Person.NationalCode + "");
            stiReport2.Dictionary.Variables.Add("InsuranceNo", gsm.Person.InsuranceNo + "");

            stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            //stiReport2.Design();
        }

        private void Sking_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Theme = e.Item.Caption;
            Properties.Settings.Default.Save();
        }
    }
}