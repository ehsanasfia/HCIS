using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealth.Data;
using HCISHealth.Classes;

namespace HCISHealth.Forms
{
    public partial class frmTanzim : DevExpress.XtraEditors.XtraForm
    {
        DataClassesHCISHealthDataContext dc = new DataClassesHCISHealthDataContext();

        List<QA> parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        List<QA> FilterChild = new List<QA>();

        public frmTanzim()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void GetPersonInfo()
        {
            var person = Classes.MainModule.PRS_SET; ribbonPageGroup1.Visible = true;

            lblName.Caption = "نام: " + person.FirstName;
            lblLname.Caption = "نام خانوادگی: " + person.LastName;
            lblFatherName.Caption = "نام پدر: " + person.FatherName;
            lblNationalNo.Caption = "کد ملی: " + person.NationalCode;
            lblBirthdate.Caption = "تاریخ تولد: " + person.BirthDate;
            lblPersonalID.Caption = "کد پرسنلی: " + person.PersonalCode;
        }
        private void frmTanzim_Load(object sender, EventArgs e)
        {
            GetPersonInfo();

        }

        private void layoutControlGroup3_Click(object sender, EventArgs e)
        {
           
        }

        private void layoutControlGroup4_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("a83ef4dc-9ebb-4a00-95b2-a4f63bcc191b")).ToList();
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
            qABindingSource1.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl3.RefreshDataSource();
        }

        private void layoutControlGroup5_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("85bfd94a-bdf0-496c-a673-0eca43df7a01")).ToList();
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
            qABindingSource2.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl8.RefreshDataSource();
        }

        private void layoutControlGroup6_Click(object sender, EventArgs e)
        {

            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("7daf23ad-82c0-493f-b413-2afa4f8b8f27")).ToList();
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
            qABindingSource3.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl12.RefreshDataSource();
        }

        private void layoutControlGroup7_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("39e6bf7f-9143-4149-805f-b9f631386681")).ToList();
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
            qABindingSource4.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl10.RefreshDataSource();
        }

        private void layoutControlGroup8_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("347ee852-2670-4794-b1d7-f6ef883df6fe")).ToList();
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
            qABindingSource5.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl13.RefreshDataSource();
        }

        private void layoutControlGroup9_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("95a87696-7277-4ae2-bff6-6999edfc9410")).ToList();
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
            qABindingSource6.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl15.RefreshDataSource();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        private void GetData()
        {
            var q4 = from p4 in dc.QAs//مشاوره انتخاب و آغاز استفاده از روش پیشگیری
                     where p4.ParentID == Guid.Parse("a83ef4dc-9ebb-4a00-95b2-a4f63bcc191b") && p4.GivenServiceM.PersonID == MainModule.GSM_SET.PersonID
                     orderby p4.Service1.ResultType
                     select p4;
            bindingSource9.DataSource = q4;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var q = from p in dc.Services//مشاوره انتخاب و آغاز استفاده از روش پیشگیری
                    where p.ParentID == Guid.Parse("a83ef4dc-9ebb-4a00-95b2-a4f63bcc191b")
                    orderby p.Service1.ResultType
                    select new { p };


            foreach (var item in q)
            {
                QA u = new QA();
                u.ParentID = item.p.ParentID;
                u.QuestionnariID = item.p.ID;
                u.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                u.CreationUser = MainModule.UserID;
                u.IDGivenServiceM = MainModule.GSM_SET.ID;

                dc.QAs.InsertOnSubmit(u);
                dc.SubmitChanges();
                GetData();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (var item in dc.QAs)
            {
                if (item.ResultN == null & item.Description == null & item.MResult == null & item.ResultCHK == null)
                {
                    dc.QAs.DeleteOnSubmit(item);
                }
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void gridView6_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource1.DataSource = FilterChild;
           
            gridControl6.RefreshDataSource();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("79326c0b-ccc8-4918-92e1-19e66f3462d0")).ToList();
            
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                parents.Add(p);

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
        
            gridControl6.RefreshDataSource();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("95a87696-7277-4ae2-bff6-6999edfc9410")).ToList();

            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                parents.Add(p);

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
            qABindingSource6.DataSource = parents;

            gridControl15.RefreshDataSource();
        }

        private void gridView15_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource6.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource7.DataSource = FilterChild;

            gridControl15.RefreshDataSource();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
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
            qABindingSource6.DataSource = null;
            bindingSource7.DataSource = null;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("39e6bf7f-9143-4149-805f-b9f631386681")).ToList();
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
            qABindingSource4.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl10.RefreshDataSource();
        }

        private void gridView10_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource4.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource5.DataSource = FilterChild;

            gridControl10.RefreshDataSource();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("58c25743-431d-4e2b-850f-a8975b642178")).ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                parents.Add(p);

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
            qABindingSource1.DataSource = parents;

            gridControl3.RefreshDataSource();
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource1.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource2.DataSource = FilterChild;
            gridControl2.RefreshDataSource();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
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
            qABindingSource1.DataSource = null;
            bindingSource2.DataSource = null;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
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
            qABindingSource4.DataSource = null;
            bindingSource5.DataSource = null;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("85bfd94a-bdf0-496c-a673-0eca43df7a01")).ToList();
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
            qABindingSource2.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl8.RefreshDataSource();
        }

        private void gridView8_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource2.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource3.DataSource = FilterChild;
            gridControl8.RefreshDataSource();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
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
            qABindingSource2.DataSource = null;
            bindingSource3.DataSource = null;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("7daf23ad-82c0-493f-b413-2afa4f8b8f27")).ToList();
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
            qABindingSource3.DataSource = parents;
            //gridControl6.DataSource = Parents;
            gridControl12.RefreshDataSource();
        }

        private void gridView12_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource3.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource4.DataSource = FilterChild;
            gridControl12.RefreshDataSource();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
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
            qABindingSource3.DataSource = null;
            bindingSource4.DataSource = null;
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            parents.Clear();
            var form4Service = dc.Services.Where(x => x.Service1.ID == Guid.Parse("347ee852-2670-4794-b1d7-f6ef883df6fe")).ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                parents.Add(p);

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
            qABindingSource5.DataSource = parents;
        
            gridControl13.RefreshDataSource();
        }

        private void gridView13_Click(object sender, EventArgs e)
        {
            var cur = qABindingSource5.Current as QA;
            if (cur == null)
                return;

            FilterChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            bindingSource6.DataSource = FilterChild;
            gridControl13.RefreshDataSource();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
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
            qABindingSource5.DataSource = null;
            bindingSource6.DataSource = null;
        }
    }
}
    