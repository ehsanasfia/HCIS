using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISAngio.Data;
using System.IO;
using HCISAngio.Classes;
using HCISAngio.Dialogs;

namespace HCISAngio.Forms
{
    public partial class frmWaitingList : DevExpress.XtraEditors.XtraForm
    {
        HCISAngioDataClassesDataContext dc = new HCISAngioDataClassesDataContext();
        public frmWaitingList()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmAdmissionList_Load(object sender, EventArgs e)
        {
            Getdata();
            givenServiceMBindingSource_CurrentChanged(null, null);
        }

        private void Getdata()
        {
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == (int)Category.خدمات_انجام_شده_در_بخش_بستری && x.Department != null && x.Department.Name != null && (x.Department.Name.Contains("آنژیوگرافی") || x.Department.Name.Contains("آنژیوپلاستی")) && x.Admitted == false && x.Confirm == false && x.Payed == true).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            var dlg = new dlgBed() { dc = dc};
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                current.Admitted = true;
                current.AdmitDate = MainModule.GetPersianDate(DateTime.Now);
                current.AdmitTime = DateTime.Now.ToString("HH:mm");
                current.Bed = dlg.SelectedBed;
                if(current.Bed != null)
                    current.Bed.Condition = "پر";
                dc.SubmitChanges();
                Getdata();
                givenServiceMBindingSource_CurrentChanged(null, null);
            }
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
            {
                barStaticItem1.Caption = "نام بیمار";
                barEditItem1.EditValue = null;
                return;
            }
            barStaticItem1.Caption = "نام:" + " " + current.Person.FirstName + " " + current.Person.LastName;
            if (current.Person.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = current.Person.Photo.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    barEditItem1.EditValue = Image.FromStream(ms);
                }
            }
            else
            {
                barEditItem1.EditValue = null;
            }
        }
    }
}