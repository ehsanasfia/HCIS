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
using Inventory.Data;
using Inventory.Dialogs;

namespace Inventory.Forms
{
    public partial class UnitManager : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        List<RequestD> lstRd = new List<RequestD>();
        List<RequestD> lst = new List<RequestD>();
        List<Person> lstp = new List<Person>();
        public UnitManager()
        {
            InitializeComponent();
        }

        private void UnitManager_Load(object sender, EventArgs e)
        {
            GetData();
            txtFromDate.Text = MainModule.GetPersianDate(DateTime.Now);
            txtToDate.Text = MainModule.GetPersianDate(DateTime.Now);
        }
        private void GetData()
        {
            try {
                //var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                //var orID = x.IDOrgan;
                //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
                requestMBindingSource.DataSource = dc.RequestMs.Where(c =>/* c.IDPerson != null && */c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
                }
            catch
            {
                MessageBox.Show(" واحد شما مشخص نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;

            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;

            bool trueFound = false;
            foreach (var item in lstRd)
            {
            
                if (item.OrganBoss == true)
                {
                    item.UMDate = MainModule.GetPersianDate(DateTime.Now);
                    item.UMtime = DateTime.Now.ToString("HH:mm");
                    item.UMUser = MainModule.RoleName + "";
                    curent.OrganBoss = true;
                    curent.UMDate = MainModule.GetPersianDate(DateTime.Now);
                    curent.UMtime = DateTime.Now.ToString("HH:mm");
                    curent.UMUser = MainModule.RoleName + "";
                    trueFound = true;
                }
                 else
                {
                    item.UMDate = "";
                    item.UMtime = "";
                    item.UMUser = "";

                    if (trueFound ==false)
                        curent.OrganBoss = false;
                  }
              }
            dc.SubmitChanges();
            GetData();
            lst = lstRd = dc.RequestDs.Where(x => x.IDRequestM == curent.ID).ToList();
            requestDBindingSource.DataSource = lstRd = lst;
            if (curent.OrganBoss == true)
            {
                MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
        }

        
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

            var q = from u in lst
                    where u.OrganBoss == true
                        select new { Product = u.Product == null ? "" : u.Product.FaName, u.AmountRequest, u.LastModificationDate, u.RequestM.Person.LastName, u.Product.MESC };
            stiReport1.RegData("Drugs", q);
            stiReport1.Compile();
            stiReport1.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            stiReport1.Dictionary.Variables.Add("GDateNow", MainModule.GetPersianDate(DateTime.Now));
            stiReport1.CompiledReport.ShowWithRibbonGUI();
          //  stiReport1.Design();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            var curent = requestMBindingSource.Current as RequestM;
            if (curent == null)
                return;
           lst = lstRd = dc.RequestDs.Where(x => x.IDRequestM == curent.ID ).ToList();
            requestDBindingSource.DataSource = lstRd = lst;
       
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                //var orID = x.IDOrgan;
                //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
                requestMBindingSource.DataSource = dc.RequestMs.Where(c => /*c.IDPerson != null &&*/ c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
            }
            catch
            {
                return;

            }
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //var x = dc.Persons.Where(c => c.UserID == MainModule.UserID).FirstOrDefault();
                //var orID = x.IDOrgan;
                //var m = dc.Organs.Where(c => c.ID == orID).FirstOrDefault();
                requestMBindingSource.DataSource = dc.RequestMs.Where(c => /*c.IDPerson != null &&*/ c.LocationUnit == Properties.Settings.Default.Install && c.RequestDate.CompareTo(txtFromDate.Text) >= 0 && c.RequestDate.CompareTo(txtToDate.Text) <= 0).OrderByDescending(c => c.RequestDate).ThenByDescending(c => c.RequestTime).ToList();
            }
            catch
            {
                return;

            }
        }
    }
}