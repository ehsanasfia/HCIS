using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Forms
{
    public partial class frmFamilyInformation : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
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
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 15 && x.CreationDate == today && x.Confirm != true).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = givenServiceMBindingSource.Current as GivenServiceM;
            if (current == null)
                return;
            txtBirthDay.Text = current.Person.BirthDate;
            txtCellularPhone.Text = current.Person.CellularPhone;
            txtFname.Text = current.Person.FirstName;
            txtLname.Text = current.Person.LastName;
            cmbEducation.Text = current.Person.Education;
            txtJob.Text = current.Person.CurrentJob;
            txtWorkAddress.Text = current.Person.WorkAddress;
            txtAdrress.Text = current.Person.Address;
            txtJobphone.Text = current.Person.WorkPhone;
            slkDoc.EditValue = current.Person.Person1;
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var person = givenServiceMBindingSource.Current as GivenServiceM;
            if (person == null)
            {
                MessageBox.Show(".بیماری انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("آیا میخواهید اطلاعات " + person.Person.FirstName + " " + person.Person.LastName + " " + "را ثبت کنید؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                var doc = (slkDoc.EditValue as Person);
                if (doc == null)
                {
                    MessageBox.Show(".پزشکی انتخاب نشده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;

                }

                person.Person.BirthDate = txtBirthDay.Text;
                person.Person.CellularPhone = txtCellularPhone.Text;
                person.Person.Education = cmbEducation.Text;
                person.Person.CurrentJob = txtJob.Text;
                person.Person.WorkAddress = txtWorkAddress.Text;
                person.Person.WorkPhone = txtJobphone.Text;
                person.Person.Person1 = doc;
               
                person.Person.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                person.Person.LastModificationTime = DateTime.Now.ToString("HH:mm");
                person.Person.LastModificator = MainModule.UserID;

                dc.SubmitChanges();

                txtBirthDay.Text = "";
                txtWorkAddress.Text = "";
                txtCellularPhone.Text = "";
                txtFname.Text = "";
                txtLname.Text = "";
                cmbEducation.Text = "";
                txtJob.Text = "";
                txtAdrress.Text = "";
                txtJobphone.Text = "";
            }
            else
                return;
        }

        private void frmFamilyInformation_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 15 && x.CreationDate == today && x.Confirm != true).ToList();
            DocBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر" && x.Speciality.Speciality1 == "عمومی").Select(x => x.Person);
            DrugBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).ToList();
            WaksanBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 15 && x.Service1.Name == "واکسن");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            givenServiceMBindingSource.DataSource = null;
            txtBirthDay.Text = "";
            txtCellularPhone.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtWorkAddress.Text = "";
            cmbEducation.Text = "";
            txtJob.Text = "";
            txtAdrress.Text = "";
            txtJobphone.Text = "";
        }


        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            gridView1_DoubleClick(null, null);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var current = DrugBindingSource.Current as Service;
            if (current == null)
                return;
            if (!DrugAllergy.Contains(current))
            {
                DrugAllergy.Add(current);
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            AllergyBindingSource.DataSource = DrugAllergy;
            gridControl3.RefreshDataSource();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            gridView3.DeleteSelectedRows();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView8_DoubleClick(object sender, EventArgs e)
        {
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;
            if (!DrugHistory.Contains(current))
            {
                DrugHistory.Add(current);
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            DrugHistoryBindingSource.DataSource = DrugHistory;
            gridControl4.RefreshDataSource();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            gridView4.DeleteSelectedRows();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = givenServiceMBindingSource.Current as GivenServiceM;
                if (gsm == null)
                    return;
                if (DrugAllergy.Any())
                {
                    DrugAllergy.ForEach(x =>
                    {
                        var DA = new DrugAllergy()
                        {
                            PersonID = gsm.Person.ID,
                            DrugID = x.ID,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.DrugAllergies.InsertOnSubmit(DA);

                    });
                    dc.SubmitChanges();
                    AllergyBindingSource.DataSource = null;
                    DrugAllergy.Clear();
                }
                if (DrugHistory.Any())
                {
                    DrugHistory.ForEach(x =>
                    {
                        var DH = new DrugHistory()
                        {
                            PersonID = gsm.Person.ID,
                            DrugID = x.ID,
                            CreatorUserID = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                            CreationTime = DateTime.Now.ToString("HH:mm"),
                        };
                        dc.DrugHistories.InsertOnSubmit(DH);
                    });
                    dc.SubmitChanges();
                    DrugHistoryBindingSource.DataSource = null;
                    DrugHistory.Clear();
                }
                if (Waksan.Any())
                {
                    Waksan.ForEach(x =>
                    {
                        var qa = new QA()
                        {
                            IDGivenServiceM = gsm.ID,
                            ParentID = x.Service1.ID,
                            QuestionnariID = x.ID,
                            CreationUser = MainModule.UserID,
                            CreationDate = MainModule.GetPersianDate(DateTime.Now),
                        };
                        dc.QAs.InsertOnSubmit(qa);

                    });
                    dc.SubmitChanges();
                    WaksanHistoryBindingSource.DataSource = null;
                    Waksan.Clear();
                }

                if (radioGroup1.SelectedIndex != 0)
                {
                    var parent = Guid.Parse("385d3eb3-65ec-483b-a5c6-602fee02a55a");
                    var question = Guid.Parse("82ebc174-df72-48f3-8060-85c1b59ab773");
                    var qa = new QA()
                    {
                        ParentID = parent,
                        IDGivenServiceM = gsm.ID,
                        QuestionnariID = question,

                    };
                }
                if (radioGroup2.SelectedIndex != 0)
                {

                }
                if (radioGroup3.SelectedIndex != 0)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
            {
                MessageBox.Show("ابتدا بیمار را مشخص کنید");
                return;
            }
            var dlg = new Dialogs.dlgDrugHistory();
            dlg.dc = dc;
            dlg.CurPerson = gsm.Person;
            dlg.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
            {
                MessageBox.Show("ابتدا بیمار را مشخص کنید");
                return;
            }
            var dlg = new Dialogs.dlgMedicalAllergyHistory();
            dlg.dc = dc;
            dlg.CurPerson = gsm.Person;
            dlg.ShowDialog();
        }

        private void gridView7_DoubleClick(object sender, EventArgs e)
        {
            var current = WaksanBindingSource.Current as Service;
            if (current == null)
                return;
            if (!Waksan.Contains(current))
            {
                Waksan.Add(current);
            }
            else
            {
                MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            WaksanHistoryBindingSource.DataSource = Waksan;
            gridControl5.RefreshDataSource();
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
            var form4Service = dc.Services.Where(x => x.Service1.Name == "فرم شماره چهار_طرح غربللگری").ToList();
            foreach (var item in form4Service)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);

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
            qABindingSource.DataSource = Parents;
            //gridControl6.DataSource = Parents;
            gridControl6.RefreshDataSource();
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
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
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
                    item.GivenServiceM = gsm;
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
            var gsm = givenServiceMBindingSource.Current as GivenServiceM;
            if (gsm == null)
            {
                MessageBox.Show("ابتدا بیمار را انتخاب کنید");
                return;
            }
            if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            foreach (var item in tenageSrv)
            {
                if (!string.IsNullOrWhiteSpace(item.Date) || !string.IsNullOrWhiteSpace(item.MResult))
                {
                    item.GivenServiceM = gsm;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;
                }
                dc.QAs.InsertOnSubmit(item);

            }
            dc.SubmitChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            qABindingSource2.DataSource = null;
        }

        private void givenServiceMBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            gridView1_DoubleClick(null, null);
        }
    }
}