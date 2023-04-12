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
using HCISEmergency.Classes;

namespace HCISEmergency.Forms
{
    public partial class frmFamilyInformation : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        List<Service> DrugAllergy = new List<Service>();
        List<Service> DrugHistory = new List<Service>();
        List<Service> Waksan = new List<Service>();

        List<QA> Parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        List<QA> FilterdChild = new List<QA>();

        List<QA> tenageSrv = new List<QA>();

        public frmFamilyInformation()
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
            var today = MainModule.GetPersianDate(DateTime.Now);
           // givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 15 && x.CreationDate == today && x.Confirm != true).ToList();
            DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
            DrugBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            WaksanBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 15 && x.Service1.Name == "واکسن");
            var Sabeghe = dc.Services.Where(x => x.ParentID == null && x.CategoryID == 18).ToList();
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
            var gsm =MainModule.GSM_Set;
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
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;

                }
                dc.QAs.InsertOnSubmit(item);

            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource.DataSource = null;
            qABindingSource1.DataSource = null;
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
                    srv.MResult = dlg.Answer;
           
        }
    }
}