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
using HCISHealth.Data;
using HCISHealth.Forms;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmTeenagerFood : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();
        List<QA> parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        List<QA> FilterChild = new List<QA>();
        
        public frmTeenagerFood()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            //var q = from p in dc.QAs
            //        where p.ParentID == Guid.Parse("750783b2-9ffd-4914-867f-16b5efb68028") && p.GivenServiceM.PersonID == MainModule.GSM.PersonID//غربالگری تغذیه ایی نوجوانان
            //        select p;
            //qABindingSource.DataSource = q;

            
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup10.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthDay.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("750783b2-9ffd-4914-867f-16b5efb68028")).ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                parents.Add(p);

                //var srv = dc.Services.Where(x => x.Service1.Name == item.Name);
                foreach (var service in item.Services)
                {
                    if (service.Services.Any())
                    {
                        foreach (var child in service.Services)
                        {
                            var qa3 = new QA()
                            {
                                Service = child,
                            };
                            AllChild.Add(qa3);
                        }
                    }
                    else
                    {
                        var qa2 = new QA()
                        {
                            Service = service,
                        };
                        AllChild.Add(qa2);
                    }
                }

            }
            qABindingSource.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl1.RefreshDataSource();

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in AllChild)
            {
                if (item.ResultCHK == true )
                {
                    item.IDGivenServiceM = MainModule.GSM_SET.ID;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;

                }
                dc.QAs.InsertOnSubmit(item);

            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource.DataSource = null;
            bindingSource1.DataSource = null;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBTraning_Load(object sender, EventArgs e)
        {
            GetData();
            GetPersonInfo();
            txtDate.Text =Classes. MainModule.GetPersianDate(DateTime.Now);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
           
        }
    }
}