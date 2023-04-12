using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISEmergency.Data;
using System.IO;

namespace HCISEmergency.Forms
{
    public partial class frmAdmissionList : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public frmAdmissionList()
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
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10 && x.Department == Classes.MainModule.MyDepartment && x.Admitted == false  && x.Confirm != true && x.Dossier.AdvancePaymentPayed == true).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            if (MessageBox.Show("آیا میخواهید بیمار را پذیرش کنید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) != DialogResult.Yes)
                return;
            else
            {
                current.Admitted = true;
                current.AdmitDate = Classes.MainModule.GetPersianDate(DateTime.Now);
                current.AdmitTime = DateTime.Now.ToString("HH:mm");
                //current.Bed.Condition = "پر";
                dc.SubmitChanges();
                Getdata();
                givenServiceMBindingSource_CurrentChanged(null, null);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            barButtonItem1_ItemClick(null, null);
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