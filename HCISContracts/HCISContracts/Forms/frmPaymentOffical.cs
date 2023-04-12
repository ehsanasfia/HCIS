using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISContracts.Data;
using HCISContracts.Classes;

namespace HCISContracts.Forms
{
    public partial class frmPaymentOffical : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public List<DoctorPaymentsAndDeduction> lstpay = new List<DoctorPaymentsAndDeduction>();
        public List<DoctorFunction> lstDocFunc = new List<DoctorFunction>();

        public decimal pay { get; set; }
        public frmPaymentOffical()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            specialityBindingSource.DataSource = dc.Specialities.Where(x => x.HideInDocPayemnt == false).OrderBy(x => x.Speciality1).ToList();
            lstpay.AddRange(dc.DoctorPaymentsAndDeductions.Where(x => x.ForOffical == true).ToList());
        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curent = specialityBindingSource.Current as Speciality;
            if (curent == null)
                return;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.SpecialityID == curent.ID && x.Offical == true).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }

            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;

            if (!dc.QualitativePoints.Any(x => x.StaffID == current.ID && x.Date == YM))
            {
                MessageBox.Show("لطفا ابتدا ارزشیابی این ماه پزشک را وارد کنید");
                return;
            }

            doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();
            var Qp = dc.QualitativePoints.FirstOrDefault(x => x.StaffID == current.ID && x.Date == YM);
            lblScore.Text = "ارزشیابی پزشک : " + Qp.Total + "%";

            lstDocFunc.Clear();
            var lst = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();
            lstDocFunc = lst;
            pay = 0;
            foreach (var item in lst)
            {
                pay += (decimal)(item.Zarib ?? 0) * (decimal)item.AmountForPayment * (item.Price);
            }
            if (lst.Count != 0)
            {
                if (dc.DoctorSalaryParams.Any(x => x.StaffID == current.ID && x.Date == YM))
                {
                    doctorSalaryParamBindingSource.DataSource = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM);
                }
                else
                {
                    string From = YM + "/01";
                    string to = YM + "/30";

                    var docM = dc.DoctorContractMs.FirstOrDefault(x => x.StaffID == current.ID && x.StartDate.CompareTo(From) <= 0 && x.EndDate.CompareTo(to) >= 0);
                    if (docM == null)
                    {
                        MessageBox.Show("قراردادی برای این پزشک در بازه مورد نظر وارد نشده است");
                        return;
                    }

                    var DocSalItem = dc.DoctorSalaryAdditionalItems.FirstOrDefault(x => x.FromDate.CompareTo(From) <= 0 && x.ToDate.CompareTo(to) >= 0);
                    if (DocSalItem == null)
                    {
                        MessageBox.Show("آیتم های قراردادی در این بازه وارد نشده اند");
                        return;
                    }
                    var weather = docM.SalaryBase * ((decimal)DocSalItem.Weather / 100); //بدی آب و هوا
                    var SuperSpecial = (docM.SalaryBase + weather) * ((decimal)DocSalItem.SuperSpecial / 100); //فوق العاده ویژه
                    var Deprivation = (docM.SalaryBase + weather) * ((decimal)DocSalItem.Deprivation / 100); //محرومیت
                    var SuperWorkshop = (docM.SalaryBase + weather) * ((decimal)DocSalItem.SuperWorkshop / 100); // فوق العاده کارگاهی
                    var SuperAbsorption = (docM.SalaryBase + weather + SuperSpecial) * ((decimal)DocSalItem.SuperAbsorption / 100); // فوق العاده جذب عمومی
                    var mizanjazb = (docM.SalaryBase) * (decimal)(docM.PositionPercentage / 100) * (decimal)1.625; // میزان جذب قابل کسر
                    var fogholadeKarane = ((((decimal)Qp.Total / 100) * (pay * (decimal)0.6)) - mizanjazb); // فوق العاده کارانه
                    //if (docM.AbsorptionPercentage != 0 || docM.AbsorptionPercentage != null)
                    //{
                    //    var foqolademazaya = ((decimal)docM.SalaryBase * (decimal)1.625 * (decimal)docM.AbsorptionPercentage) * -1;//فوق العاده مزایا کسورات
                    //}
                    if (fogholadeKarane < 0)
                        fogholadeKarane = 0;

                    var WorkerPart = fogholadeKarane * (decimal)0.1; //سهم کارکنان

                    var WeatherPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "بدی آب و هوا",
                        Date = YM,
                        ParamValue = weather ?? 0,
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(WeatherPayment);

                    var SuperSpecialPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "فوق العاده ویژه",
                        Date = YM,
                        ParamValue = SuperSpecial ?? 0,
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(SuperSpecialPayment);

                    var DeprivationPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "محرومیت",
                        Date = YM,
                        ParamValue = Deprivation ?? 0,
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(DeprivationPayment);

                    var SuperWorkshopPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "فوق العاده کارگاهی",
                        Date = YM,
                        ParamValue = SuperWorkshop ?? 0,
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(SuperWorkshopPayment);

                    var SuperAbsorptionPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "فوق العاده جذب عمومی",
                        Date = YM,
                        ParamValue = SuperAbsorption ?? 0,
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(SuperAbsorptionPayment);

                    var mizanjazbPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "میزان جذب قابل کسر",
                        Date = YM,
                        ParamValue = -mizanjazb ?? 0,
                        ConfirmPayment = true
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(mizanjazbPayment);

                    var WorkPartPayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "سهم کارکنان",
                        Date = YM,
                        ParamValue = WorkerPart ?? 0,
                        ConfirmPayment = true
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(WorkPartPayment);

                    var salaryBase = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "پایه حقوق",
                        Date = YM,
                        ParamValue = docM.SalaryBase ?? 0,
                        ConfirmPayment = true,

                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(salaryBase);
                    var fogholadeKaranePayment = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "فوق العاده کارانه",
                        Date = YM,
                        ParamValue = fogholadeKarane ?? 0,
                        ConfirmPayment = true
                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(fogholadeKaranePayment);
                    dc.SubmitChanges();

                    foreach (var item in lstpay)
                    {
                        if (item.Amount == null && item.Percentage != null)
                        {
                            var payment = new DoctorSalaryParam()
                            {
                                Staff = current,
                                ParamName = item.Description,
                                Date = YM,
                                ParamValue = item.LowOff ? -pay * (decimal)item.Percentage / 100 : pay * (decimal)item.Percentage / 100,

                            };
                            dc.DoctorSalaryParams.InsertOnSubmit(payment);
                        }
                        else if (item.Amount != null && item.Percentage == null)
                        {
                            var payment = new DoctorSalaryParam()
                            {
                                Staff = current,
                                ParamName = item.Description,
                                Date = YM,
                                ParamValue = item.Amount ?? 0,
                            };
                            dc.DoctorSalaryParams.InsertOnSubmit(payment);
                        }
                    }

                    if (dc.QualitativePoints.Any(x => x.StaffID == current.ID && x.Date == YM))
                    {
                        lblScore.Text = "ارزشیابی پزشک : " + Qp.Total + "%";
                        var nakhales = new DoctorSalaryParam()
                        {
                            Staff = current,
                            ParamName = "نا خالص",
                            Date = YM,
                            ParamValue = ((decimal)Qp.Total / 100) * (pay * (decimal)0.6),

                        };
                        dc.DoctorSalaryParams.InsertOnSubmit(nakhales);
                    }
                    var amalkardfani = new DoctorSalaryParam()
                    {
                        Staff = current,
                        ParamName = "60% عملکرد کمی",
                        Date = YM,
                        ParamValue =  (pay * (decimal)0.6),

                    };
                    dc.DoctorSalaryParams.InsertOnSubmit(amalkardfani);
                    dc.SubmitChanges();
                    doctorSalaryParamBindingSource.DataSource = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM);
                }
            }
            gridView3.BestFitColumns();
            gridView4.BestFitColumns();
            lblScore.Text = "ارزشیابی پزشک : " + Qp.Total + "%";
            if (lstDocFunc.Count != 0)
                btnConfirmPayment.Enabled = true;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }
            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;
            if (checkEdit1.Checked == true)
            {
                doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();
            }
            else
            {
                doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM).ToList();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }

            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;
            var dlg = new Dialogs.dlgDoctorSalaryParams() { dc = dc, staffID = (staffBindingSource.Current as Staff).ID, date = string.Format("{0}/{1}", spinEdit1.Value, comboBoxEdit1.Text) };
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                doctorSalaryParamBindingSource.DataSource = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }
            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;
            if (current.QualitativePoints.FirstOrDefault(x => x.Date == YM) == null)
            {
                MessageBox.Show("امتیاز این ماه پزشک وارد نشده است");
                return;
            }

            stiReport1.Dictionary.Variables.Add("FName", current.Person.FirstName);
            stiReport1.Dictionary.Variables.Add("LName", current.Person.LastName);
            stiReport1.Dictionary.Variables.Add("Specialty", current.Speciality.Speciality1);
            stiReport1.Dictionary.Variables.Add("MedicalSystemCode", current.MedicalSystemCode);
            stiReport1.Dictionary.Variables.Add("Date", YM);
            var Qp = dc.QualitativePoints.FirstOrDefault(x => x.StaffID == current.ID && x.Date == YM);
            stiReport1.Dictionary.Variables.Add("QulitativePointTotal", Qp.Total);
            stiReport1.Dictionary.Variables.Add("TotalPay", pay);

            var q = dc.DoctorFunctions.Where(c => c.StaffID == current.ID && c.Service.DoctorPaymentCategory1 != null && c.Date == YM && c.ClinicalOfficerConfirm == true).ToList().Select(c => new { c.AmountForPayment, c.Amount, c.PayedConfirm, c.Zarib, c.Price, c.Service.DoctorPaymentCategory1.CatName, c.Service.Name, FinalPrice = (c.Price * (decimal)c.AmountForPayment * (decimal)c.Zarib) }).ToList();

            if (q.Any(x => x.PayedConfirm != true))
            {
                var lstNotConfirm = dc.DoctorFunctions.Where(c => c.StaffID == current.ID && c.Service.DoctorPaymentCategory1 != null && c.Date == YM && c.ClinicalOfficerConfirm == true && c.PayedConfirm != true).ToList();
                foreach (var item in lstNotConfirm)
                {
                    item.PayedConfirm = true;
                    dc.SubmitChanges();

                }
            }
            var p = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM && x.ConfirmPayment == true).OrderBy(c => c.SortCol).Select(c => new { c.ParamName, c.ParamValue });
            // var p = from x in dc.DoctorSalaryParams where x.StaffID == current.ID && x.Date == YM && x.ConfirmPayment == true select new { x.ParamName, x.ParamValue };
            stiReport1.RegData("DoctorFunctions", q.ToList());
            stiReport1.RegData("DoctorParam", p.ToList());

            //stiReport1.Design();
            stiReport1.Dictionary.Synchronize();
            stiReport1.Compile();
            stiReport1.CompiledReport.ShowWithRibbonGUI();
        }

        private void gridView4_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dc.SubmitChanges();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            var current = staffBindingSource.Current as Staff;
            if (current == null)
            {
                MessageBox.Show("پزشک را انتخاب کنید");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }

            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;
            if (dc.DoctorSalaryParams.Any(x => x.StaffID == current.ID && x.Date == YM))
            {
                var lst = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM).ToList();
                foreach (var item in lst)
                {
                    dc.DoctorSalaryParams.DeleteOnSubmit(item);
                    dc.SubmitChanges();
                }
            }
            simpleButton1_Click(null, null);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                MessageBox.Show("لطفا اطلاعات را درست وارد کنید");
                return;
            }

            var YM = spinEdit1.Value.ToString() + "/" + comboBoxEdit1.Text;

            StiHe32.Dictionary.Variables.Add("Date", MainModule.GetPersianDate(DateTime.Now));
            var lst = dc.Vw_DocContractHe32s.Where(x => x.Date == YM).ToList();
            StiHe32.RegData("Params", lst.ToList());
            //StiHe32.Design();
            StiHe32.Dictionary.Synchronize();
            StiHe32.Compile();
            StiHe32.CompiledReport.ShowWithRibbonGUI();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (lstDocFunc.Count == 0)
            {
                MessageBox.Show("آیتمی برای تایید وجود ندارد لطفا یک پزشک و ماه را انتخاب کنید");
                return;
            }
            foreach (var item in lstDocFunc)
            {
                item.PayedConfirm = true;
                dc.SubmitChanges();

            }
            MessageBox.Show("آیتم های حقوقی با موفقیت تایید شدند");
        }
    }
}