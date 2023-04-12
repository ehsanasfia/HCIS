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
    public partial class frmPaymentPerCase : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        public List<DoctorPaymentsAndDeduction> lstpay = new List<DoctorPaymentsAndDeduction>();

        public decimal pay { get; set; }
        public frmPaymentPerCase()
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
            lstpay.AddRange(dc.DoctorPaymentsAndDeductions.ToList());
        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curent = specialityBindingSource.Current as Speciality;
            if (curent == null)
                return;
            staffBindingSource.DataSource = dc.Staffs.Where(x => x.SpecialityID == curent.ID).ToList();
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
            string From = YM + "/01";
            string to = YM + "/30";
            if (!dc.QualitativePoints.Any(x => x.StaffID == current.ID && x.Date == YM))
            {
                MessageBox.Show("لطفا ابتدا ارزشیابی این ماه پزشک را وارد کنید");
                return;
            }


            var docM = dc.DoctorContractMs.FirstOrDefault(x => x.StaffID == current.ID && x.StartDate.CompareTo(From) <= 0 && x.EndDate.CompareTo(to) >= 0);
            if (docM == null)
            {
                MessageBox.Show("قراردادی برای این پزشک در بازه مورد نظر وارد نشده است");
                return;
            }
            doctorFunctionBindingSource.DataSource = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();
            var Qp = dc.QualitativePoints.FirstOrDefault(x => x.StaffID == current.ID && x.Date == YM);
            var lst = dc.DoctorFunctions.Where(x => x.StaffID == current.ID && x.Date == YM && x.ClinicalOfficerConfirm == true).ToList();

            foreach (var item in lst)
            {
                // pay += item.Zarib * item.ConfirmedAmount * (double?)item.Price;
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
                    foreach (var item in lstpay)
                    {
                        if (item.Description == "مالیات")
                        {
                            if (docM.TaxesPercentage != null && docM.TaxesPercentage != 0)
                            {
                                var payment = new DoctorSalaryParam()
                                {
                                    Staff = current,
                                    ParamName = item.Description,
                                    Date = YM,
                                    ParamValue = -pay * (decimal)docM.TaxesPercentage / 100

                                };
                            }
                            else
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
                        }
                        else
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

                    }

                    if (dc.QualitativePoints.Any(x => x.StaffID == current.ID && x.Date == YM))
                    {


                        lblScore.Text = "ارزشیابی پزشک : " + Qp.Total + "%";
                        var nakhales = new DoctorSalaryParam()
                        {
                            Staff = current,
                            ParamName = "نا خالص",
                            Date = YM,
                            ParamValue = ((decimal)Qp.Total / 100) * pay
                        };
                        dc.DoctorSalaryParams.InsertOnSubmit(nakhales);
                    }

                    dc.SubmitChanges();
                    doctorSalaryParamBindingSource.DataSource = dc.DoctorSalaryParams.Where(x => x.StaffID == current.ID && x.Date == YM);
                }
            }
            gridView3.BestFitColumns();
            gridView4.BestFitColumns();
            lblScore.Text = "ارزشیابی پزشک : " + Qp.Total + "%";
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

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnReCalc_Click(object sender, EventArgs e)
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
            pay = 0;
            doctorSalaryParamBindingSource.DataSource = null;
            simpleButton1_Click(null, null);
        }
    }
}