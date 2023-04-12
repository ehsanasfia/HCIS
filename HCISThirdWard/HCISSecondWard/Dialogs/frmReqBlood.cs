using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Forms
{
    public partial class frmReqBlood : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<Service> DrugAllergy = new List<Service>();
        List<Service> DrugHistory = new List<Service>();
        List<Service> Waksan = new List<Service>();
        public Vw_BloodBankMain Doc1 { get; set; }
        List<QA> Parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        List<QA> FilterdChild = new List<QA>();
        List<QA> lst = new List<QA>();
        List<QA> tenageSrv = new List<QA>();
        Guid idgsd;
       
        public frmReqBlood()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
          //  givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 15 && x.CreationDate == today && x.Confirm != true).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        //    var person = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (person == null)
        //    {
        //        MessageBox.Show(".بیماری انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //        return;
        //    }

        //    if (MessageBox.Show("آیا میخواهید اطلاعات " + person.Person.FirstName + " " + person.Person.LastName + " " + "را ثبت کنید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
        //    {
        //        var doc = (slkDoc.EditValue as Person);
        //        if (doc == null)
        //        {
        //            MessageBox.Show(".پزشکی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //            return;

        //        }

        //        person.Person.BirthDate = txtBirthDay.Text;
        //        person.Person.CellularPhone = txtCellularPhone.Text;
        //        person.Person.Education = cmbEducation.Text;
        //        person.Person.CurrentJob = txtJob.Text;
        //        person.Person.WorkAddress = txtWorkAddress.Text;
        //        person.Person.WorkPhone = txtJobphone.Text;
        //        person.Person.Person1 = doc;
               
        //        person.Person.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
        //        person.Person.LastModificationTime = DateTime.Now.ToString("HH:mm");
        //        person.Person.LastModificator = MainModule.UserID;

        //        dc.SubmitChanges();

        //        txtBirthDay.Text = "";
        //        txtWorkAddress.Text = "";
        //        txtCellularPhone.Text = "";
        //        txtFname.Text = "";
        //        txtLname.Text = "";
        //        cmbEducation.Text = "";
        //        txtJob.Text = "";
        //        txtAdrress.Text = "";
        //        txtJobphone.Text = "";
        //    }
        //    else
        //        return;
        }

        private void frmFamilyInformation_Load(object sender, EventArgs e)
        {
            // parsifar
            lblName.Text = MainModule.GSM_Set.Person.FullName + " - "
           + MainModule.GSM_Set.Person.Age.ToString() + "ساله - "
           + (MainModule.GSM_Set.Bed == null ? "" : "شماره تخت :"
           + " " + MainModule.GSM_Set.Bed.BedNumber);
            labelControl1.Text = "پزشک : " + MainModule.GSM_Set.Staff.Person.FirstName + " " + MainModule.GSM_Set.Staff.Person.LastName;
            labelControl2.Text = "کد ملی" + " " + MainModule.GSM_Set.Person.NationalCode;
            lblDossier.Text = "شماره پرونده: " + MainModule.GSM_Set.DossierID.ToString() + " " + "تاریخ پذیرش: " + MainModule.GSM_Set.Dossier.Date;
            lbleM.Text = "تشخیص: " + (MainModule.GSM_Set.Presentation != null ? MainModule.GSM_Set.Presentation.PrimDiag : "");
            var LastDiet = dc.Diets.Where(p => p.ParentID == null && p.GivenServiceD.GivenServiceM == MainModule.GSM_Set).OrderByDescending(x => x.GivenServiceD.Date).OrderByDescending(x => x.GivenServiceD.Time).FirstOrDefault();
            if (LastDiet != null && LastDiet.Service != null)
                lblDiet.Text = "رژیم غذایی بیمار: " + LastDiet.Service.Name;

          //  از اینجاگرید
            vwBloodBankMainBindingSource.DataSource = dc.Vw_BloodBankMains.Where(c=> c.NationalCode == MainModule.GSM_Set.Person.NationalCode)
                .OrderByDescending(c => c.Date).ThenByDescending(c => c.Time  ).ToList();
            //\\parsifar



            var today = MainModule.GetPersianDate(DateTime.Now);
           // givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 15 && x.CreationDate == today && x.Confirm != true).ToList();
            DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
            DrugBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            WaksanBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 15 && x.Service1.Name == "واکسن");
            var Sabeghe = dc.Services.Where(x => x.ParentID == null && x.OldID==null && x.CategoryID == 18).ToList();
            foreach (var item in Sabeghe)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);

                //var srv = dc.Services.Where(x => x.Service1.Name == item.Name);
                foreach (var service in item.Services)
                {
                    //if (service.Services.Any())
                    //{
                    //    foreach (var child in service.Services)
                    //    {
                    //        var qa3 = new QA()
                    //        {
                    //            Service = child,
                    //        };
                    //        AllChild.Add(qa3);
                    //    }
                    //}
                    //else
                    //{
                    var qa2 = new QA()
                    {
                        Service = service,
                    };
                    AllChild.Add(qa2);
                    // }
                }

            }
            qABindingSource.DataSource = Parents;
            //gridControl6.DataSource = Parents;
            gridControl6.RefreshDataSource();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           }


        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            gridView1_DoubleClick(null, null);
        }

      

       
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

      

       

     
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            //if (gsm == null)
            //{
            //    MessageBox.Show("ابتدا بیمار را مشخص کنید");
            //    return;
            //}
            //var dlg = new Dialogs.dlgDrugHuistory();
            //dlg.dc = dc;
            //dlg.CurPerson = gsm.Person;
            //dlg.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            //if (gsm == null)
            //{
            //    MessageBox.Show("ابتدا بیمار را مشخص کنید");
            //    return;
            //}
            //var dlg = new Dialogs.dlgDrugAllergyHistory();
            //dlg.dc = dc;
            //dlg.CurPerson = gsm.Person;
            //dlg.ShowDialog();
        }

      
        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView6_DoubleClick(object sender, EventArgs e)
        {
            var cur = qABindingSource.Current as QA;
            if (cur == null)
                return;

            FilterdChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            qABindingSource1.DataSource = FilterdChild;
            gridControl9.RefreshDataSource();
        }

        private void qABindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            var gsm = MainModule.GSM_Set;
            var gsd = new GivenServiceD()
            {
                GivenServiceMID = gsm.ID,
                ServiceID = Guid.Parse("bde86db7-3d1e-4662-bea8-a1753e1df7a2"),
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
               // Staff = MyStaff
            };
            var tarefee = dc.Tariffs.Where(z => z.ServiceID == gsd.ServiceID && z.InsuranceID == MainModule.GSM_Set.InsuranceID).OrderByDescending(y => y.Date).FirstOrDefault();
            if (tarefee == null)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = 0;
                gsd.TotalPrice = 0;
            }

            else if (tarefee.PatientShare == 0)
            {
                gsd.Payed = true;
                gsd.PaymentPrice = 0;
                gsd.PatientShare = 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                gsd.TotalPrice = gsd.InsuranceShare;
            }
            else
            {
                gsd.PaymentPrice = tarefee.PatientShare ?? 0;
                gsd.PatientShare = tarefee.PatientShare ?? 0;
                gsd.InsuranceShare = tarefee.OrganizationShare ?? 0;
                gsd.TotalPrice = gsd.InsuranceShare + gsd.PatientShare;
            }
            dc.GivenServiceDs.InsertOnSubmit(gsd);
                if (gsm == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید");
                return;
            }
            if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            foreach (var item in AllChild)
            {
                if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                {
                    item.IDGivenServiceM = gsm.ID;
                    item.GivenServiceD = gsd;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;
                }
                dc.QAs.InsertOnSubmit(item);

            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource.DataSource = null;
            qABindingSource1.DataSource = null;
            idgsd = gsd.ID;
            ///parsifar
            vwBloodBankMainBindingSource.DataSource = dc.Vw_BloodBankMains.Where(c => c.NationalCode == MainModule.GSM_Set.Person.NationalCode)
          .OrderByDescending(c => c.Date).ThenByDescending(c => c.Time).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var form4Service = dc.Services.Where(x => x.Service1.Name == "فرم سلامت نوجوان").ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                tenageSrv.Add(p);
            }
            qABindingSource2.DataSource = tenageSrv;
        }

        private void gridView11_DoubleClick(object sender, EventArgs e)
        {
            var srv = qABindingSource2.Current as QA;
            if (srv == null)
            {
                return;
            }
            var dlg = new Dialogs.dlgAnswer();
            dlg.dc = dc;
            dlg.qa = srv;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                srv.MResult = dlg.Answer;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        //    var gsm = givenServiceMBindingSource.Current as GivenServiceM;
        //    if (gsm == null)
        //    {
        //        MessageBox.Show("ابتدا بیمار را انتخاب کنید");
        //        return;
        //    }
        //    if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
        //        return;

        //    foreach (var item in tenageSrv)
        //    {
        //        if (!string.IsNullOrWhiteSpace(item.Date) || !string.IsNullOrWhiteSpace(item.MResult))
        //        {
        //            item.GivenServiceM = gsm;
        //            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
        //            item.CreationUser = MainModule.UserID;
        //        }
        //        dc.QAs.InsertOnSubmit(item);

        //    }
        //    dc.SubmitChanges();
        //    MessageBox.Show("با موفقیت ثبت شد");
        //    qABindingSource2.DataSource = null;
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            gridView1_DoubleClick(null, null);
        }

        private void gridControl9_DoubleClick(object sender, EventArgs e)
        {
            var srv = qABindingSource1.Current as QA;
            if (srv == null)
            {
                return;
            }
            var li = dc.Services.Where(x => x.ParentID == srv.QuestionnariID).ToList();
            if (li.Count == 0)
                return;
                var dlg = new Dialogs.dlgAnswer();
                dlg.dc = dc;
                dlg.qa = srv;
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                    srv.Description = dlg.Answer;
           
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var cu1 = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
            if (cu1 == null)
            {
                return;
            }

            var q = from u in lst
                    select new
                    {
                        u.ResultCHK
                    };
            var rptData = dc.View_BloodBankReports.Where(c => c.ID == cu1.ID).ToList();
        
            stiReport1.Dictionary.Variables.Add("firstname1", cu1.FirstName);
            stiReport1.Dictionary.Variables.Add("LastName1", cu1.LastName);
            stiReport1.Dictionary.Variables.Add("NationalCode1", cu1.NationalCode);
            stiReport1.Dictionary.Variables.Add("FatherName1", cu1.FatherName);
            stiReport1.Dictionary.Variables.Add("BirthDate1", cu1.BirthDate);
            stiReport1.Dictionary.Variables.Add("dosseirnum1", cu1.Expr1);
            stiReport1.Dictionary.Variables.Add("UserFullName1", MainModule.UserFullName);
            stiReport1.RegData("ali", q.ToList());
            stiReport1.Compile();
            var sabeghetazrigh = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("62eaecbe-158f-4e9f-a4af-f7c3ac1f2bea"));
            stiReport1.CompiledReport["sabeghetazrigh"] = sabeghetazrigh == null ? false : sabeghetazrigh.ResultCHK;
            var sabeghetazrigh1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("41f226aa-1438-42cf-a191-86445e89d2c4"));
            stiReport1.CompiledReport["sabeghetazrigh1"] = sabeghetazrigh1 == null ? false : sabeghetazrigh1.ResultCHK;
            var sabeghetazrigh2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("3c7b190b-0547-45ce-bf91-92341304f557"));
            stiReport1.CompiledReport["sabeghetazrigh2"] = sabeghetazrigh2 == null ? false : sabeghetazrigh2.ResultCHK;
            var sabeghetazrigh3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("ebacbb6e-47da-4d4d-807f-b99929f874f9"));
            stiReport1.CompiledReport["sabeghetazrigh3"] = sabeghetazrigh3 == null ? false : sabeghetazrigh3.ResultCHK;

            var sabeghetazrigh4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("14ee3a9b-39a3-4cdb-b5c9-004dea5590b0"));
            stiReport1.CompiledReport["sabeghetazrigh4"] = sabeghetazrigh4 == null ? false : sabeghetazrigh4.ResultCHK;

            var a1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("1bcf43dd-b07b-402b-ba3f-c8d07d209e52"));
            stiReport1.CompiledReport["a1"] = a1 == null ? "" : a1.Description;
            var a2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("e5fb3302-3434-4534-a3be-e1d6150ce46c"));
            stiReport1.CompiledReport["a2"] = a2 == null ? "" : a2.Description;
            var elatniyaz1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("b22ae65a-6356-49af-9d29-13f95d3a7f88"));
            stiReport1.CompiledReport["elatniyaz1"] = elatniyaz1 == null ? false : elatniyaz1.ResultCHK;
            var elatniyaz2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("ec6da83c-1f89-443a-a339-ffda044a665b"));
            stiReport1.CompiledReport["elatniyaz2"] = elatniyaz2 == null ? false : elatniyaz2.ResultCHK;
            var elatniyaz3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("aa477bb0-e3a9-41fd-ae7a-1b6a584058ff"));
            stiReport1.CompiledReport["elatniyaz3"] = elatniyaz3 == null ? false : elatniyaz3.ResultCHK;
            var elatniyaz4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("db5de486-47d5-49f0-a2dd-ac7bd6fda9fb"));
            stiReport1.CompiledReport["elatniyaz4"] = elatniyaz4 == null ? false : elatniyaz4.ResultCHK;
            var elatniyaz5 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("061d7731-cd74-4969-8eb2-8dd029786a92"));
            stiReport1.CompiledReport["elatniyaz5"] = elatniyaz5 == null ? false : elatniyaz5.ResultCHK;
            var elatniyaz6 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("774ea1a4-e50a-40be-b271-10884edb328a"));
            stiReport1.CompiledReport["elatniyaz6"] = elatniyaz6 == null ? false : elatniyaz6.ResultCHK;
            var elatniyaz7= rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("1735bb56-01e7-450a-9ccb-b61ec47435f0"));
            stiReport1.CompiledReport["elatniyaz7"] = elatniyaz7 == null ? false : elatniyaz7.ResultCHK;
            var a3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("1735bb56-01e7-450a-9ccb-b61ec47435f0"));
            stiReport1.CompiledReport["a3"] = a3 == null ? "" : a3.Description;
            var a4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("cda1b453-01ad-4e44-878c-ab9478f6c216"));
            stiReport1.CompiledReport["a4"] = a4 == null ? "" : a4.Description;
            var a5 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("143b8a67-0790-422b-8974-a2972c2fb10d"));
            stiReport1.CompiledReport["a5"] = a5 == null ? "" : a5.Description;
            var a6 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("3d7a91af-79d8-4280-9a48-90e3b8e9b4b7"));
            stiReport1.CompiledReport["a6"] = a6 == null ? "" : a6.Description;
            var a7 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("d2245e9d-bc9f-4891-a866-e470e5cbae39"));
            stiReport1.CompiledReport["a7"] = a7 == null ? "" : a7.Description;

            ///فرآورده های درخواستی
            var faravardedarkhasti1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("60482bfb-6b52-4ada-8568-b55cefa7a003"));
            stiReport1.CompiledReport["faravardedarkhasti1"] = faravardedarkhasti1 == null ? false : faravardedarkhasti1.ResultCHK;
            var f1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("60482bfb-6b52-4ada-8568-b55cefa7a003"));
            stiReport1.CompiledReport["f1"] = f1 == null ? "" : f1.Description;
            var faravardedarkhasti2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("a1101f84-d38a-471f-be1b-6817105226f2"));
            stiReport1.CompiledReport["faravardedarkhasti2"] = faravardedarkhasti2 == null ? false : faravardedarkhasti2.ResultCHK;
            var f2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("a1101f84-d38a-471f-be1b-6817105226f2"));
            stiReport1.CompiledReport["f2"] = f2 == null ? "" : f2.Description;

            var faravardedarkhasti3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("b5f6b5f1-5d31-4347-99ef-019090675c65"));
            stiReport1.CompiledReport["faravardedarkhasti3"] = faravardedarkhasti3 == null ? false : faravardedarkhasti3.ResultCHK;
            var f3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("b5f6b5f1-5d31-4347-99ef-019090675c65"));
            stiReport1.CompiledReport["f3"] = f3 == null ? "" : f3.Description;
            var faravardedarkhasti4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("952f88c1-1bf1-4387-9329-eb9fa07f4121"));
            stiReport1.CompiledReport["faravardedarkhasti4"] = faravardedarkhasti4 == null ? false : faravardedarkhasti4.ResultCHK;
            var f4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("952f88c1-1bf1-4387-9329-eb9fa07f4121"));
            stiReport1.CompiledReport["f4"] = f4 == null ? "" : f4.Description;
            var faravardedarkhasti5 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("cc587c6d-ad17-456e-9dc5-d83e1e463e08"));
            stiReport1.CompiledReport["faravardedarkhasti5"] = faravardedarkhasti5 == null ? false : faravardedarkhasti5.ResultCHK;
            var f5 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("cc587c6d-ad17-456e-9dc5-d83e1e463e08"));
            stiReport1.CompiledReport["f5"] = f5 == null ? "" : f5.Description;
            var faravardedarkhasti6 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("baad2279-85a4-4886-9677-d1e4bb486fea"));
            stiReport1.CompiledReport["faravardedarkhasti6"] = faravardedarkhasti6 == null ? false : faravardedarkhasti6.ResultCHK;
            var f6 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("baad2279-85a4-4886-9677-d1e4bb486fea"));
            stiReport1.CompiledReport["f6"] = f6 == null ? "" : f6.Description;
            var faravardedarkhasti7 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("c5cd148b-45f4-4b12-b78b-eec84696f020"));
            stiReport1.CompiledReport["faravardedarkhasti7"] = faravardedarkhasti7 == null ? false : faravardedarkhasti7.ResultCHK;
            var f7 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("c5cd148b-45f4-4b12-b78b-eec84696f020"));
            stiReport1.CompiledReport["f7"] = f7 == null ? "" : f7.Description;
            var faravardedarkhasti8 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("447a0cd6-aa5b-45f4-836c-dc850dcdff48"));
            stiReport1.CompiledReport["faravardedarkhasti8"] = faravardedarkhasti8 == null ? false : faravardedarkhasti8.ResultCHK;
            var f8 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("447a0cd6-aa5b-45f4-836c-dc850dcdff48"));
            stiReport1.CompiledReport["f8"] = f8 == null ? "" : f8.Description;
            var faravardedarkhasti9 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("157b51e5-8a73-4f6a-bc87-2afdd7ea0326"));
            stiReport1.CompiledReport["faravardedarkhasti9"] = faravardedarkhasti9 == null ? false : faravardedarkhasti9.ResultCHK;
            var f9 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("157b51e5-8a73-4f6a-bc87-2afdd7ea0326"));
            stiReport1.CompiledReport["f9"] = f9 == null ? "" : f9.Description;
            var faravardedarkhasti10 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("f8d1764f-5170-4435-9ae3-f3a01d2fa898"));
            stiReport1.CompiledReport["faravardedarkhasti10"] = faravardedarkhasti10 == null ? false : faravardedarkhasti10.ResultCHK;
            var f10 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("f8d1764f-5170-4435-9ae3-f3a01d2fa898"));
            stiReport1.CompiledReport["f10"] = f10 == null ? "" : f10.Description;
            //هدف از درخواست خون
            var hadaf1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("2b13b808-ec8e-4545-9fcd-045ef6c23f32"));
            stiReport1.CompiledReport["hadaf1"] = hadaf1 == null ? false : hadaf1.ResultCHK;
            var hadaf2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("61cc77e4-a5fd-4e3a-9252-45b54193a4b5"));
            stiReport1.CompiledReport["hadaf2"] = hadaf2 == null ? false : hadaf2.ResultCHK;
            var hadaf3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("aa853d74-7608-4740-b87a-89312555b13e"));
            stiReport1.CompiledReport["hadaf3"] = hadaf3 == null ? false : hadaf3.ResultCHK;
            var h1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("0b4faa79-6195-49ce-866a-3177b6ede7ab"));
            stiReport1.CompiledReport["h1"] = h1 == null ? "" : h1.Description;
            var h2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("6d426232-e187-465d-9933-e53f70def2bc"));
            stiReport1.CompiledReport["h2"] = h2 == null ? "" : h2.Description;
            var h3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("f86e163e-348a-4808-9167-9156926453dc"));
            stiReport1.CompiledReport["h3"] = h3 == null ? "" : h3.Description;
            // مشخصات نمونه گیر
            var n1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("bd822847-1694-4576-bdbc-e513c4e1b124"));
            stiReport1.CompiledReport["n1"] = n1 == null ? "" : n1.Description;
            var n2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("ee6f211d-44fc-4043-8a44-0c2d024e8e9c"));
            stiReport1.CompiledReport["n2"] = n2 == null ? "" : n2.Description;
            var n3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("1ea8602d-8583-4d76-a20e-67e6fffe48ec"));
            stiReport1.CompiledReport["n3"] = n3 == null ? "" : n3.Description;
            var nemonegir1 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("4fb07ea3-a306-4b84-bbfe-8d7ec6da0dd8"));
            stiReport1.CompiledReport["nemonegir1"] = nemonegir1 == null ? false : nemonegir1.ResultCHK;

            var nemonegir2 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("5f461e1a-5f56-470f-afb3-9f691219a831"));
            stiReport1.CompiledReport["nemonegir2"] = nemonegir2 == null ? false : nemonegir2.ResultCHK;

            var nemonegir3 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("cc2dd0b6-4176-429b-bf93-10f77ce48ed6"));
            stiReport1.CompiledReport["nemonegir3"] = nemonegir3 == null ? false : nemonegir3.ResultCHK;

            var nemonegir4 = rptData.SingleOrDefault(c => c.sERVICEID == Guid.Parse("29830bfd-9d57-450c-a6bc-7f75d50e7672"));
            stiReport1.CompiledReport["nemonegir4"] = nemonegir4 == null ? false : nemonegir4.ResultCHK;
            stiReport1.CompiledReport.ShowWithRibbonGUI();
         
    //    stiReport1.Design();


        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            ///parsifar
            var cu = vwBloodBankMainBindingSource.Current as Vw_BloodBankMain;
            if(cu == null)
            {
                return;
            }
          
            vwBloodBankBindingSource.DataSource = dc.Vw_BloodBanks.Where(c => c.ID == cu.ID).ToList();
          //  Doc = cu;
        }

        private void gridView6_DoubleClick_1(object sender, EventArgs e)
        {
            var cur = qABindingSource.Current as QA;
            if (cur == null)
                return;

            FilterdChild = AllChild.Where(x => x.Service.ParentID == cur.QuestionnariID || (x.Service.Service1 != null && x.Service.Service1.ParentID == cur.QuestionnariID)).ToList();
            qABindingSource1.DataSource = FilterdChild;
            gridControl9.RefreshDataSource();
        }
    }
}