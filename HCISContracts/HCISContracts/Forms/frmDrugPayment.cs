using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;
using HCISContracts.Dialogs;
using HCISContracts.Classes;
using DevExpress.XtraSplashScreen;

namespace HCISContracts.Forms
{
    public partial class frmDrugPayment : DevExpress.XtraEditors.XtraForm
    {
        Data.HCISDataContexDataContext dc = new Data.HCISDataContexDataContext();
        List<Staff> lst = new List<Staff>();
        List<DoctorFunction> drf = new List<DoctorFunction>();
        List<Service> srv = new List<Service>();
        private bool loading;

        SplashScreenManager splashScreenManager2;

        public frmDrugPayment()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = doctorFunctionBindingSource.Current as DoctorFunction;
            if (cur == null)
                return;
            cur.ClinicalOfficerConfirm = true;
            dc.SubmitChanges();
        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = specialityBindingSource.Current as Speciality;
            if (current == null)
                return;

            //dc.CreateDoctorFunctions(txtYear.Text + "/" + lkpMounth.Text, current.ID);
            //doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.Staff.Speciality == current  && x.Date == txtYear.Text + "/" + lkpMounth.Text);
            //doctorFunctionBindingSource1.DataSource = dc.DoctorFunctions.Where(x => x.Staff.Speciality == current && x.Date == txtYear.Text + "/" + lkpMounth.Text);
            lst = dc.Staffs.Where(x => x.SpecialityID == current.ID).ToList();
            staffBindingSource.DataSource = lst;
            gridControl2.RefreshDataSource();
        }

        private void frmClinicPayment_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm2), true, true);
            splashScreenManager2.ClosingDelay = 500;
            loading = true;
            serviceBindingSource.DataSource = dc.Services.ToList();
            specialityBindingSource.DataSource = dc.Specialities.Where(x => x.ID == 38).ToList();
            vwMemGroupBindingSource.DataSource = dc.vwMemGroups.ToList();
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
            loading = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var curent = staffBindingSource.Current as Staff;
            if (curent == null)
            {
                MessageBox.Show("ابتدا پزشک را انتخاب نمایید");
                return;
            }
            DoctorFunction u = new DoctorFunction();
            u.Amount = Int32.Parse(txtAmount.Text);
            u.ConfirmedAmount = Int32.Parse(txtAmount.Text);
            u.Date = txtYear.Text + "/" + lkpMounth.Text;
            u.StaffID = curent.ID;
            u.ServiceID = Guid.Parse(lkpServiceName.EditValue.ToString());
            u.ClinicalOfficerConfirm = true;
            dc.DoctorFunctions.InsertOnSubmit(u);

            dc.SubmitChanges();

            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
            txtAmount.Text = " ";
            lkpDoctor.EditValue = null;
            lkpServiceName.EditValue = null;
            lkpServiceType.EditValue = null;
            staffBindingSource_CurrentChanged(null, null);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var item in dc.DoctorFunctions)
            {
                DoctorFunction b = new DoctorFunction();
                //var b = doctorFunctionBindingSource.Current as DoctorFunction;
                if (b == null)
                    return;
                if (b.ClinicalOfficerConfirm == false)
                {
                    b.ClinicalOfficerConfirm = true;
                }
                b.Date = txtYear.Text + "/" + lkpMounth.Text;
                dc.DoctorFunctions.InsertOnSubmit(b);
                dc.SubmitChanges();
            }
          ;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView3.CloseEditor();
                doctorFunctionBindingSource.EndEdit();
                dc.SubmitChanges();
                MessageBox.Show("تغییرات با موفقیت ذخیره شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }

        private void staffBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var curent = staffBindingSource.Current as Staff;
            //if (curent == null)
            //    return;
            //dc.CreateDoctorFunctions(txtYear.Text + "/" + lkpMounth.Text, curent.ID);
            //drf = dc.DoctorFunctions.Where(x => x.StaffID == curent.ID && x.Date == txtYear.Text + "/" + lkpMounth.Text).ToList();
            //doctorFunctionBindingSource.DataSource = drf;
            //gridControl3.RefreshDataSource();
        }

        private void lkpServiceType_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpServiceType.EditValue == null)
                return;
            var curr = int.Parse(lkpServiceType.EditValue.ToString());

            srv = dc.Services.Where(x => x.ServiceCategory.ID == curr).ToList();
            serviceBindingSource.DataSource = srv;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var curent = staffBindingSource.Current as Staff;
            if (curent == null)
                return;
            string Month = "";
            if (lkpMounth.Text == "01")
                Month = "فروردین";
            else if (lkpMounth.Text == "02")
                Month = "اردیبهشت";
            else if (lkpMounth.Text == "03")
                Month = "خرداد";
            else if (lkpMounth.Text == "04")
                Month = "تیر";
            else if (lkpMounth.Text == "05")
                Month = "مرداد";
            else if (lkpMounth.Text == "06")
                Month = "شهریور";
            else if (lkpMounth.Text == "07")
                Month = "مهر";
            else if (lkpMounth.Text == "08")
                Month = "آبان";
            else if (lkpMounth.Text == "09")
                Month = "آذر";
            else if (lkpMounth.Text == "10")
                Month = "دی";
            else if (lkpMounth.Text == "11")
                Month = "بهمن";
            else if (lkpMounth.Text == "12")
                Month = "اسفند";

            printableComponentLink1.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink1.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کارکرد دکتر {0} در کلینیک در {1}", curent.Person.LastName, Month + " " + txtYear.Text);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var curent = staffBindingSource.Current as Staff;
            if (curent == null)
                return;
            string Month = "";
            if (lkpMounth.Text == "01")
                Month = "فروردین";
            else if (lkpMounth.Text == "02")
                Month = "اردیبهشت";
            else if (lkpMounth.Text == "03")
                Month = "خرداد";
            else if (lkpMounth.Text == "04")
                Month = "تیر";
            else if (lkpMounth.Text == "05")
                Month = "مرداد";
            else if (lkpMounth.Text == "06")
                Month = "شهریور";
            else if (lkpMounth.Text == "07")
                Month = "مهر";
            else if (lkpMounth.Text == "08")
                Month = "آبان";
            else if (lkpMounth.Text == "09")
                Month = "آذر";
            else if (lkpMounth.Text == "10")
                Month = "دی";
            else if (lkpMounth.Text == "11")
                Month = "بهمن";
            else if (lkpMounth.Text == "12")
                Month = "اسفند";

            printableComponentLink2.ClearDocument();
            ((DevExpress.XtraPrinting.PageHeaderFooter)printableComponentLink2.PageHeaderFooter).Header.Content[1] = String.Format("گزارش کارکرد دکتر {0} در بخش در {1}", curent.Person.LastName, Month + " " + txtYear.Text);
            printableComponentLink2.CreateDocument();
            printableComponentLink2.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var df = (doctorFunctionBindingSource.Current as DoctorFunction);
            var p = df.Staff.DoctorSalaryParams.Where(x => x.Date == df.Date);

            stiReport1.Dictionary.Variables.Add("FName", p.First().Staff.Person.FirstName);
            stiReport1.Dictionary.Variables.Add("LName", p.First().Staff.Person.LastName);
            stiReport1.Dictionary.Variables.Add("Specialty", p.First().Staff.Speciality.Speciality1);
            stiReport1.Dictionary.Variables.Add("MedicalSystemCode", p.First().Staff.MedicalSystemCode);
            stiReport1.Dictionary.Variables.Add("Date", p.First().Date);
            stiReport1.Dictionary.Variables.Add("QulitativePointTotal", (double)p.First().Staff.QualitativePoints.Where(x => x.Date == p.First().Date).First().Total);

            //stiReport1.Dictionary.Variables.Add("GrossPayment", p.First().GrossPayment);
            //stiReport1.Dictionary.Variables.Add("EmpContrib", p.First().EmpContrib);
            //stiReport1.Dictionary.Variables.Add("NetPayment", p.First().NetPayment);

            var q = from c in dc.DoctorFunctions where c.StaffID == df.StaffID && c.Date == df.Date select new { c.Amount, c.UnitPrice, c.Multiplier, c.TotalPrice, c.Service.Name };

            //stiReport1.RegBusinessObject("DoctorFunctions", q.ToList());
            stiReport1.RegData("DoctorFunctions", q.ToList());

            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.Show();
            //stiReport1.Design();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {

            splashScreenManager2.ShowWaitForm();
            try
            {

                var curent = staffBindingSource.Current as Staff;
                if (curent == null)
                {
                    MessageBox.Show("لطفا پزشک را انتخاب کنید");
                    return;
                }

                var YM = txtYear.Text + "/" + lkpMounth.Text;
                if (string.IsNullOrWhiteSpace(YM))
                {
                    MessageBox.Show("لطفا تاریخ را با دقت وارد کنید");
                    return;
                }
                var from = YM + "/01";
                var to = MainModule.GetPersianLastDateOfMonth(MainModule.GetDateFromPersianString(from));

                var NoskheService = dc.Services.FirstOrDefault(x => x.SalamatBookletCode == "902020");
                if (!dc.DoctorFunctions.Any(x => x.Service.SalamatBookletCode == "902020" && x.StaffID == curent.ID && x.Date == YM))
                {
                    var df = new DoctorFunction()
                    {
                        Date = YM,
                        StaffID = curent.ID,
                        ServiceID = NoskheService.ID,
                        Amount = 1,
                    };
                    dc.DoctorFunctions.InsertOnSubmit(df);
                    dc.SubmitChanges();
                }

                //dc.CommandTimeout = 10000;

                //var MustDelete = dc.DoctorFunctions.Where(x => x.StaffID == curent.ID && x.Date == YM && x.ClinicalOfficerConfirm != true).ToList();

                //var notInsert = dc.DoctorFunctions.Where(x => x.StaffID == curent.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();

                //var lstWard = dc.Spu_DocWardVisitCount(from, to, curent.ID).ToList();
                //var lstAnasthesia = dc.Spu_DocAnasthesiaCount(from, to, curent.ID).ToList();
                //var lstDentist = dc.Spu_DentistServiceCount(from, to, curent.ID).ToList();
                //var lstVisit = dc.Spu_DocVisitCount(from, to, curent.ID).ToList();
                //var lstAngio = dc.Spu_DocAngiosCount(from, to, curent.ID).ToList();
                //var lstPara = dc.Spu_DocParaCount(from, to, curent.ID).ToList();
                //var lstSurgery = dc.Spu_DocSurgeryCount(from, to, curent.ID).ToList();
                //var lstDiagnostic = dc.Spu_DocDiagnosticCount(from, to, curent.ID).ToList();

                //dc.DoctorFunctions.DeleteAllOnSubmit(MustDelete);
                //dc.SubmitChanges();

                //if (lstWard.Count() > 0)
                //{
                //    foreach (var item in lstWard)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.Count,
                //                JozeHerfeyi = item.JozHefeyi,
                //                TotalK = item.TotalK
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}


                //if (lstAnasthesia.Count() > 0)
                //{
                //    foreach (var item in lstAnasthesia)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.count,
                //                JozeHerfeyi = item.JozeHerfeyi,
                //                TotalK = item.TotalK

                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}


                //if (lstDentist.Count() > 0)
                //{
                //    foreach (var item in lstDentist)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.Count,
                //                JozeHerfeyi = item.JozeHrefyi,
                //                TotalK = item.TotalK
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}

                //if (lstVisit.Count() > 0)
                //{
                //    foreach (var item in lstVisit)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.Count,
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}


                //if (lstAngio.Count() > 0)
                //{
                //    foreach (var item in lstAngio)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.count,
                //                JozeHerfeyi = item.JozeHefreyi,
                //                TotalK = item.TotalK

                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}

                //if (lstPara.Count() > 0)
                //{
                //    foreach (var item in lstPara)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.Count,
                //                JozeHerfeyi = item.JozeHerfeyi,
                //                TotalK = item.TotalK
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}


                //if (lstSurgery.Count() > 0)
                //{
                //    foreach (var item in lstSurgery)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.count,
                //                JozeHerfeyi = item.JozeHerfeyi,
                //                TotalK = item.TotalK
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}

                //if (lstDiagnostic.Count() > 0)
                //{
                //    foreach (var item in lstDiagnostic)
                //    {
                //        if (!notInsert.Any(x => x.ServiceID == item.ServiceID))
                //        {
                //            var DF = new DoctorFunction()
                //            {
                //                Date = YM,
                //                StaffID = curent.ID,
                //                ServiceID = item.ServiceID,
                //                Amount = (double)item.count,
                //                JozeHerfeyi = item.JozeHerfeyi,
                //                TotalK = item.TotalK
                //            };
                //            dc.DoctorFunctions.InsertOnSubmit(DF);
                //        }
                //    }
                //}
                //dc.SubmitChanges();
                doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.StaffID == curent.ID && x.Date == YM).ToList();
                gridView1.BestFitColumns();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }


        private void gridView3_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //if (e.Clicks < 2)
            //    return;
            //if (gridView3.IsValidRowHandle(e.RowHandle))
            //    return;
            if (gridView3.IsGroupRow(e.RowHandle))
                return;
            var YM = txtYear.Text + "/" + lkpMounth.Text;
            if (string.IsNullOrWhiteSpace(YM))
            {
                MessageBox.Show("لطفا تاریخ را با دقت وارد کنید");
                return;
            }
            var from = YM + "/01";
            var to = MainModule.GetPersianLastDateOfMonth(MainModule.GetDateFromPersianString(from));

            var current = doctorFunctionBindingSource.Current as DoctorFunction;
            if (current == null)
                return;

            var dlg = new Dialogs.dlgReportBeRiz();
            dlg.dc = dc;
            dlg.DocFunc = current;
            dlg.From = from;
            dlg.To = to;
            dlg.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var YM = txtYear.Text + "/" + lkpMounth.Text;
            if (string.IsNullOrWhiteSpace(YM))
            {
                MessageBox.Show("لطفا تاریخ را با دقت وارد کنید");
                return;
            }
            var from = YM + "/01";

            var NoskheService = dc.Services.FirstOrDefault(x => x.SalamatBookletCode == "902020");
            var lst = dc.Staffs.Where(x => x.SpecialityID == 38).ToList();
            foreach (var item in lst)
            {
                if (!dc.DoctorFunctions.Any(x => x.Service.SalamatBookletCode == "902020" && x.StaffID == item.ID && x.Date == YM))
                {
                    var df = new DoctorFunction()
                    {
                        Date = YM,
                        StaffID = item.ID,
                        ServiceID = NoskheService.ID,
                        Amount = 1,
                        ClinicalOfficerConfirm = true
                    };
                    dc.DoctorFunctions.InsertOnSubmit(df);
                    dc.SubmitChanges();
                }
            }
            doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.Service.ID == NoskheService.ID && x.Date == YM).ToList();
            gridView1.BestFitColumns();
        }
    }
}