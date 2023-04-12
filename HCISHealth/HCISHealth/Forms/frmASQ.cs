using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmASQ : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();

        List<QA> parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        List<QA> FilterChild = new List<QA>();
        public frmASQ()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("22ac871a-0952-4b45-83ef-dd12b19d0a80")).ToList();
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

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {

            foreach (var item in AllChild)
            {
                if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
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
        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup1.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFather.Caption = "نام پدر: " + person.FatherName;
            lblNationalCod.Caption = "کد ملی: " + person.NationalCode;
            lblBirthday.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmASQ_Load(object sender, EventArgs e)
        {
            GetPersonInfo();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource1.DataSource = FilterChild;
            gridControl1.RefreshDataSource();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}