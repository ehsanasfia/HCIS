using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BloodBank.Data;
namespace BloodBank.Dialogs
{
    public partial class dlgRequest : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc { get; set; }
        public Vw_BloodBankMain Doc { get; set; }
        List<QA> Parents = new List<QA>();
        List<QA> AllChild = new List<QA>();
        public bool isEditt { get; set; }
        List<QA> FilterdChild = new List<QA>();
        List<QA> lst = new List<QA>();
        // List<DossierDentall> lst = new List<DossierDentall>();
        // public DossierDentall DD { get; set; }
        public dlgRequest()
        {
            InitializeComponent();
        }

        private void dlgRequest_Load(object sender, EventArgs e)
        {
            txtNationalcode.Text = Doc.NationalCode;
            textEdit1.Text = Doc.FirstName;
            textEdit2.Text = Doc.LastName;
            txtdossier.Text = Doc.Expr1+"";
            vwBloodBankBindingSource.DataSource = dc.Vw_BloodBanks.Where(c => c.ID == Doc.ID).ToList();
            var today = MainModule.GetPersianDate(DateTime.Now);
            var req = dc.QAs.Where(c => c.GivenServiceDID == Doc.ID && c.Service.Service1.OldID==1).ToList();
            
            if (req.Count > 0)
            {
                MessageBox.Show("شما قبلا این درخواست را پاسخ داده اید");
                simpleButton3.Enabled = false;
                lst = req;
                qABindingSource1.DataSource = req = lst;
                //var myreq1 = dc.Services.Where(x => x.ParentID == null && x.OldID == 1 && x.CategoryID == 18).ToList();
                //foreach (var item in myreq1)
                //{
                //    var p = new QA()
                //    {
                //        Service = item,
                //    };
                //    Parents.Add(p);

                //    foreach (var service in item.Services)
                //    {

                //        var qa2 = new QA()
                //        {
                //            Service = service,
                //        };
                //        AllChild.Add(qa2);
                //    }

                //}
                //qABindingSource.DataSource = Parents;

                //gridControl6.RefreshDataSource();
                return;
            }
            var myreq = dc.Services.Where(x => x.ParentID == null && x.OldID == 1 && x.CategoryID == 18).ToList();
            foreach (var item in myreq)
            {
                var p = new QA()
                {
                    Service = item,
                };
                Parents.Add(p);

                foreach (var service in item.Services)
                {

                    var qa2 = new QA()
                    {
                        Service = service,
                    };
                    AllChild.Add(qa2);
                }

            }
            qABindingSource.DataSource = Parents;

            gridControl6.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (var item in AllChild)
            {
                if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                {
                    // item.IDGivenServiceM = gsm.ID;
                    item.GivenServiceDID = Doc.ID;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationUser = MainModule.UserID;
                }
                dc.QAs.InsertOnSubmit(item);
            }
            dc.SubmitChanges();
            MessageBox.Show("اطلاعات با موفقيت ثبت  گرديد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            qABindingSource.DataSource = null;
            qABindingSource1.DataSource = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var q = from u in lst
                    select new
                    {
                        u.ResultCHK
                    };
            stiReport2.Dictionary.Variables.Add("firstname", Doc.FirstName);
            stiReport2.Dictionary.Variables.Add("LastName", Doc.LastName);
            stiReport2.Dictionary.Variables.Add("NationalCode", Doc.NationalCode);
            stiReport2.Dictionary.Variables.Add("FatherName", Doc.FatherName);
            stiReport2.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            stiReport2.Dictionary.Variables.Add("BirthDate", Doc.BirthDate);
            stiReport2.Dictionary.Variables.Add("dosseirnum", Doc.Expr1);
            var rptData = dc.View_BloodBankReports.Where(c => c.ID == Doc.ID).ToList();
            stiReport2.RegData("Drugs", q.ToList());
            stiReport2.Compile();

            var a1 = rptData.SingleOrDefault(c => c.Name == "گروه خون وRH بیمار");
            stiReport2.CompiledReport["a1"] = a1 == null ? "" : a1.Description;
            var a2 = rptData.SingleOrDefault(c => c.Name == "نام فرآورده درخواستی توسط پزشک و تعداد");
            stiReport2.CompiledReport["a2"] = a2 == null ? "" : a2.Description;
            var a3 = rptData.SingleOrDefault(c => c.Name == "تاریخ نیاز به تزریق خون یا فرآورده");
            stiReport2.CompiledReport["a3"] = a3 == null ? "" : a3.Description;
            var a4 = rptData.SingleOrDefault(c => c.Name == "ساعت نیاز به تزریق خون یا فرآورده");
            stiReport2.CompiledReport["a6"] = a4 == null ? "" : a4.Description;


            var a5 = rptData.SingleOrDefault(c => c.Name == "تاریخ ارسال فرآورده");
            stiReport2.CompiledReport["a5"] = a5 == null ? "" : a5.Description;
            var a6 = rptData.SingleOrDefault(c => c.Name == "ساعت ارسال فرآورده");
            stiReport2.CompiledReport["a6"] = a6 == null ? "" : a6.Description;
            var a7 = rptData.SingleOrDefault(c => c.Name == "نام و نام خانوادگی تحویل گیرنده");
            stiReport2.CompiledReport["a7"] = a7 == null ? "" : a7.Description;
            var a8 = rptData.SingleOrDefault(c => c.Name == "بخش");
            stiReport2.CompiledReport["a8"] = a8 == null ? "" : a8.Description;
            var jensiyat = rptData.SingleOrDefault(c => c.Name == "جنسیت");
            stiReport2.CompiledReport["chkSex"] = jensiyat == null ? false : jensiyat.ResultCHK;
            var jensiyat1 = rptData.SingleOrDefault(c => c.Name == "جنسیت");
             stiReport2.CompiledReport["chkSex"] = jensiyat1 == null ? false : jensiyat1.ResultCHK;
            //  stiReport2.RegData("Drugs", q.ToList());
            //  stiReport2.Compile();
            stiReport2.CompiledReport.ShowWithRibbonGUI();
            //  stiReport2.ShowWithRibbonGUI();
           // stiReport2.Design();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var q = from u in lst
                    select new
                    {
                        u.ResultCHK
                    };
            stiReport1.Dictionary.Variables.Add("firstname", Doc.FirstName);
            stiReport1.Dictionary.Variables.Add("LastName", Doc.LastName);
            stiReport1.Dictionary.Variables.Add("NationalCode", Doc.NationalCode);
            stiReport1.Dictionary.Variables.Add("FatherName", Doc.FatherName);
            stiReport1.Dictionary.Variables.Add("BirthDate", Doc.BirthDate);
            stiReport1.Dictionary.Variables.Add("dosseirnum", Doc.Expr1);
            stiReport1.Dictionary.Variables.Add("UserFullName", MainModule.UserFullName);
            var rptData = dc.View_BloodBankReports.Where(c => c.ID == Doc.ID).ToList();
            stiReport1.RegData("Drugs", q.ToList());
            stiReport1.Compile();
            var nameFaravardeh = rptData.SingleOrDefault(c => c.Name == "نام فرآورده");
            stiReport1.CompiledReport["nameFaravardeh"] = nameFaravardeh == null ? "" : nameFaravardeh.Description;

            var tarikh = rptData.SingleOrDefault(c => c.Name == "تاریخ انقضا فرآورده ");
            stiReport1.CompiledReport["expiredate"] = tarikh == null ? "" : tarikh.Description;
            //////خودم
            var a3 = rptData.SingleOrDefault(c => c.Name == "شماره کیسه");
            stiReport1.CompiledReport["a3"] = a3 == null ? "" : a3.Description;
            var a4 = rptData.SingleOrDefault(c => c.Name == "گروه خون و Rh فرآورده ی ارسالی از بانک خون");
            stiReport1.CompiledReport["a4"] = a4 == null ? "" : a4.Description;
            var a5 = rptData.SingleOrDefault(c => c.Name == "AntibodyScreening");
            stiReport1.CompiledReport["a5"] = a5 == null ? "" : a5.Description;
            var a6 = rptData.SingleOrDefault(c => c.Name == "گروه خون و RH بیمار");
            stiReport1.CompiledReport["a6"] = a6 == null ? "" : a6.Description;
            var a7 = rptData.SingleOrDefault(c => c.Name == "Cross match");
            stiReport1.CompiledReport["a7"] = a7 == null ? "" : a7.Description;
            var a8 = rptData.SingleOrDefault(c => c.Name == "تاریخ انجام آزمایش");
            stiReport1.CompiledReport["a8"] = a8 == null ? "" : a8.Description;
            var a12 = rptData.SingleOrDefault(c => c.Name == "بخش");
            stiReport1.CompiledReport["a12"] = a12 == null ? "" : a12.Description;
            var a13 = rptData.SingleOrDefault(c => c.Name == "تاریخ و ساعت نیاز به تزریق خون ");
            stiReport1.CompiledReport["a13"] = a13 == null ? "" : a13.Description;
            var a14 = rptData.SingleOrDefault(c => c.Name == "نام فرآورده درخواستی توسط پزشک");
            stiReport1.CompiledReport["a14"] = a14 == null ? "" : a14.Description;
            var a15 = rptData.SingleOrDefault(c => c.Name == "انجام دهنده ی آزمایش");
            stiReport1.CompiledReport["a15"] = a15 == null ? "" : a15.Description;
            var a16 = rptData.SingleOrDefault(c => c.Name == "تاریخ ارسال فرآورده");
            stiReport1.CompiledReport["a16"] = a16 == null ? "" : a16.Description;
            var a17 = rptData.SingleOrDefault(c => c.Name == "ساعت ارسال فرآورده");
            stiReport1.CompiledReport["a17"] = a17 == null ? "" : a17.Description;
            var a18 = rptData.SingleOrDefault(c => c.Name == "نام فرد تحویل گیرنده");
            stiReport1.CompiledReport["a18"] = a18 == null ? "" : a18.Description;
            /////خودم
            var jensiyat = rptData.SingleOrDefault(c => c.Name == "جنسیت");
            stiReport1.CompiledReport["chkSex"] = jensiyat == null ? false : jensiyat.ResultCHK;
         
            stiReport1.CompiledReport.ShowWithRibbonGUI();
            //  stiReport1.ShowWithRibbonGUI();
           // stiReport1.Design();
        }

        private void gridView6_Click(object sender, EventArgs e)
        {
            //var cu = qABindingSource.Current as QA;
            //var req = dc.QAs.Where(c => c.GivenServiceDID == Doc.ID ).ToList();
            //if (req.Count > 0)
            //{
               
            //    simpleButton3.Enabled = false;
            //    lst = req;
            //    qABindingSource1.DataSource = req;
            //}
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}