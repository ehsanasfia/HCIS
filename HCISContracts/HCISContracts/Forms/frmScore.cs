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
using DevExpress.XtraEditors.DXErrorProvider;

namespace HCISContracts.Forms
{
    public partial class frmScore : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContexDataContext dc = new HCISDataContexDataContext();
        bool isedit;
        public QualitativePoint qu { get; set; }

        public frmScore()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void Getdata()
        {
            if (isedit == true)
            {
                if(qu.Staff.Offical)
                {
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    spnPhsicRas.Text = qu.PhysicalPresence + "";
                    spnEduRas.Text = qu.Education + "";
                    spnQualityRas.Text = qu.WorkQuality + "";
                    spnTheoryRas.Text = qu.ResponsibleTheory + "";
                    spnHistoryRas.Text = qu.WorkExperience + "";
                }
                else
                {
                    layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    spnPhsicPer.Text = qu.PhysicalPresence + "";
                    spnEduPer.Text = qu.Education + "";
                    spnTheoryPer.Text = qu.ResponsibleTheory + "";
                    spnQualityPer.Text = qu.WorkQuality + "";
                    spnAdamSarfeJoyiPer.Text = qu.Nosave + "";
                    spnAdamRezayatPer.Text = qu.Patientdissatisfaction + "";
                }
            }
            string a = "";
            if (cmbMonth1.Text == "فروردین")
                a = txtYear1.Text + "/" + "01";
            else if (cmbMonth1.Text == "اردیبهشت")
                a = txtYear1.Text + "/" + "02";
            else if (cmbMonth1.Text == "خرداد")
                a = txtYear1.Text + "/" + "03";
            else if (cmbMonth1.Text == "تیر")
                a = txtYear1.Text + "/" + "04";
            else if (cmbMonth1.Text == "مرداد")
                a = txtYear1.Text + "/" + "05";
            else if (cmbMonth1.Text == "شهریور")
                a = txtYear1.Text + "/" + "06";
            else if (cmbMonth1.Text == "مهر")
                a = txtYear1.Text + "/" + "07";
            else if (cmbMonth1.Text == "آبان")
                a = txtYear1.Text + "/" + "08";
            else if (cmbMonth1.Text == "آذر")
                a = txtYear1.Text + "/" + "09";
            else if (cmbMonth1.Text == "دی")
                a = txtYear1.Text + "/" + "10";
            else if (cmbMonth1.Text == "بهمن")
                a = txtYear1.Text + "/" + "11";
            else if (cmbMonth1.Text == "اسفند")
                a = txtYear1.Text + "/" + "12";

            qualitativePointBindingSource.DataSource = dc.QualitativePoints.Where(x => x.Date == a);

            if(checkEdit1.Checked)
            {
                staffBindingSource.DataSource = dc.Staffs.Where(x => x.Offical == true).ToList();
            }
            else
            {
                staffBindingSource.DataSource = dc.Staffs.Where(x => x.Offical == false).ToList();
            }
        }

        private void frmScore_Load(object sender, EventArgs e)
        {
            layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            Getdata();
        }

        private void btnConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == true)
            {
                MessageBox.Show("بر روی پایان ویرایش کلیک کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            string a = "";
            try
            {
                if (cmbMonth1.Text == "")
                {
                    ConditionValidationRule notEmpty = new ConditionValidationRule();
                    notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
                    notEmpty.ErrorText = ".ماه را انتخاب کنید";
                    dxValidationProvider1.SetValidationRule(cmbMonth1, notEmpty);
                    dxValidationProvider1.Validate();
                    return;
                }

                if (cmbMonth1.Text == "فروردین")
                    a = txtYear1.Text + "/" + "01";
                else if (cmbMonth1.Text == "اردیبهشت")
                    a = txtYear1.Text + "/" + "02";
                else if (cmbMonth1.Text == "خرداد")
                    a = txtYear1.Text + "/" + "03";
                else if (cmbMonth1.Text == "تیر")
                    a = txtYear1.Text + "/" + "04";
                else if (cmbMonth1.Text == "مرداد")
                    a = txtYear1.Text + "/" + "05";
                else if (cmbMonth1.Text == "شهریور")
                    a = txtYear1.Text + "/" + "06";
                else if (cmbMonth1.Text == "مهر")
                    a = txtYear1.Text + "/" + "07";
                else if (cmbMonth1.Text == "آبان")
                    a = txtYear1.Text + "/" + "08";
                else if (cmbMonth1.Text == "آذر")
                    a = txtYear1.Text + "/" + "09";
                else if (cmbMonth1.Text == "دی")
                    a = txtYear1.Text + "/" + "10";
                else if (cmbMonth1.Text == "بهمن")
                    a = txtYear1.Text + "/" + "11";
                else if (cmbMonth1.Text == "اسفند")
                    a = txtYear1.Text + "/" + "12";

                var stf = slkpDoc.EditValue as Staff;
                if (stf == null)
                {
                    ConditionValidationRule notEmpty = new ConditionValidationRule();
                    notEmpty.ConditionOperator = ConditionOperator.IsNotBlank;
                    notEmpty.ErrorText = ".لطفا دکتر را انتخاب کنید";
                    dxValidationProvider1.SetValidationRule(slkpDoc, notEmpty);
                    dxValidationProvider1.Validate();
                    return;
                }
                if (dc.QualitativePoints.Any(x => x.StaffID == stf.ID && x.Date == a))
                {
                    MessageBox.Show("برای این پزشک در ماه انتخاب شده امتیاز دهی انجام شده است");
                    return;
                }

                var cur = slkpDoc.EditValue as Staff;
                if (cur == null)
                    return;

                if (cur.Offical)
                {
                    int c = int.Parse(spnPhsicRas.Value.ToString()) + int.Parse(spnEduRas.Value.ToString()) + int.Parse(spnQualityRas.Value.ToString()) + int.Parse(spnTheoryRas.Value.ToString()) + int.Parse(spnHistoryRas.Value.ToString());
                    double b = c / 100;
                    var quality = new QualitativePoint()
                    {
                        PhysicalPresence = int.Parse(spnPhsicRas.Value.ToString()),
                        Education = int.Parse(spnEduRas.Value.ToString()),
                        WorkQuality = int.Parse(spnQualityRas.Value.ToString()),
                        ResponsibleTheory = int.Parse(spnTheoryRas.Value.ToString()),
                        WorkExperience = int.Parse(spnHistoryRas.Value.ToString()),
                        CreatorUserFullName = Classes.MainModule.UserFullName,
                        CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Total = int.Parse(spnPhsicRas.Value.ToString()) + int.Parse(spnEduRas.Value.ToString()) + int.Parse(spnQualityRas.Value.ToString()) + int.Parse(spnTheoryRas.Value.ToString()) + int.Parse(spnHistoryRas.Value.ToString()),
                        Staff = stf,
                        TotalPoint = b,
                        Date = a,
                    };

                    dc.QualitativePoints.InsertOnSubmit(quality);
                }
                else
                {
                    int c = int.Parse(spnPhsicPer.Value.ToString()) + int.Parse(spnEduPer.Value.ToString()) + int.Parse(spnTheoryPer.Value.ToString()) + int.Parse(spnQualityPer.Value.ToString()) - (int.Parse(spnAdamSarfeJoyiPer.Value.ToString()) + int.Parse(spnAdamRezayatPer.Value.ToString()));
                    double b = c / 100;
                    var quality = new QualitativePoint()
                    {
                        PhysicalPresence = int.Parse(spnPhsicPer.Value.ToString()),
                        Education = int.Parse(spnEduPer.Value.ToString()),
                        ResponsibleTheory = int.Parse(spnTheoryPer.Value.ToString()),
                        WorkQuality = int.Parse(spnQualityPer.Value.ToString()),
                        Nosave = int.Parse(spnAdamSarfeJoyiPer.Value.ToString()),
                        Patientdissatisfaction = int.Parse(spnAdamRezayatPer.Value.ToString()),
                        CreatorUserFullName = Classes.MainModule.UserFullName,
                        CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                        CreationTime = DateTime.Now.ToString("HH:mm"),
                        Total = int.Parse(spnPhsicPer.Value.ToString()) + int.Parse(spnEduPer.Value.ToString()) + int.Parse(spnTheoryPer.Value.ToString()) + int.Parse(spnQualityPer.Value.ToString()) - (int.Parse(spnAdamSarfeJoyiPer.Value.ToString()) + int.Parse(spnAdamRezayatPer.Value.ToString())),
                        Staff = stf,
                        TotalPoint = b,
                        Date = a,
                    };

                    dc.QualitativePoints.InsertOnSubmit(quality);
                }

                dc.SubmitChanges();
                Getdata();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void cmbMonth1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getdata();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cu = qualitativePointBindingSource.Current as QualitativePoint;
            if (cu == null)
            {
                return;
            }
            isedit = true;
            qu = cu;
            Getdata();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isedit == true)
            {
                if (qu.Staff.Offical)
                {
                    int cr = int.Parse(spnPhsicRas.Value.ToString()) + int.Parse(spnEduRas.Value.ToString()) + int.Parse(spnQualityRas.Value.ToString()) + int.Parse(spnTheoryRas.Value.ToString()) + int.Parse(spnHistoryRas.Value.ToString());
                    double br = cr / 100;
                    
                    qu.PhysicalPresence = int.Parse(spnPhsicRas.Value.ToString());
                    qu.Education = int.Parse(spnEduRas.Value.ToString());
                    qu.WorkQuality = int.Parse(spnQualityRas.Value.ToString());
                    qu.ResponsibleTheory = int.Parse(spnTheoryRas.Value.ToString());
                    qu.WorkExperience = int.Parse(spnHistoryRas.Value.ToString());

                    qu.Total = int.Parse(spnPhsicRas.Value.ToString()) + int.Parse(spnEduRas.Value.ToString()) + int.Parse(spnQualityRas.Value.ToString()) + int.Parse(spnTheoryRas.Value.ToString()) + int.Parse(spnHistoryRas.Value.ToString());
                    qu.TotalPoint = br;

                    dc.SubmitChanges();
                    Getdata();
                    isedit = false;
                    MessageBox.Show("ویرایش به اتمام رسید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    spnPhsicRas.Text = "";
                    spnEduRas.Text = "";
                    spnQualityRas.Text = "";
                    spnTheoryRas.Text = "";
                    spnHistoryRas.Text = "";
                }
                else
                {
                    int cp = int.Parse(spnPhsicPer.Value.ToString()) + int.Parse(spnEduPer.Value.ToString()) + int.Parse(spnTheoryPer.Value.ToString()) + int.Parse(spnQualityPer.Value.ToString()) - (int.Parse(spnAdamSarfeJoyiPer.Value.ToString()) + int.Parse(spnAdamRezayatPer.Value.ToString()));
                    double bp = cp / 100;

                    qu.PhysicalPresence = int.Parse(spnPhsicPer.Value.ToString());
                    qu.Education = int.Parse(spnEduPer.Value.ToString());
                    qu.ResponsibleTheory = int.Parse(spnTheoryPer.Value.ToString());
                    qu.WorkQuality = int.Parse(spnQualityPer.Value.ToString());
                    qu.Nosave = int.Parse(spnAdamSarfeJoyiPer.Value.ToString());
                    qu.Patientdissatisfaction = int.Parse(spnAdamRezayatPer.Value.ToString());

                    qu.Total = int.Parse(spnPhsicPer.Value.ToString()) + int.Parse(spnEduPer.Value.ToString()) + int.Parse(spnTheoryPer.Value.ToString()) + int.Parse(spnQualityPer.Value.ToString()) - (int.Parse(spnAdamSarfeJoyiPer.Value.ToString()) + int.Parse(spnAdamRezayatPer.Value.ToString()));
                    qu.TotalPoint = bp;

                    dc.SubmitChanges();
                    Getdata();
                    isedit = false;
                    MessageBox.Show("ویرایش به اتمام رسید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    spnPhsicPer.Text = "";
                    spnEduPer.Text = "";
                    spnTheoryPer.Text = "";
                    spnQualityPer.Text = "";
                    spnAdamSarfeJoyiPer.Text = "";
                    spnAdamRezayatPer.Text = "";
                }
            }
        }

        private void slkpDoc_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkpDoc.EditValue as Staff;
            if (cur == null)
                return;

            if (cur.Offical)
            {
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void spnPhsicPer_EditValueChanged(object sender, EventArgs e)
        {
            txtSumPer.Text = (spnPhsicPer.Value + spnEduPer.Value + spnTheoryPer.Value + spnQualityPer.Value - (spnAdamSarfeJoyiPer.Value + spnAdamRezayatPer.Value)) + "";
        }

        private void spnPhsicRas_EditValueChanged(object sender, EventArgs e)
        {
            txtSumRas.Text = (spnPhsicRas.Value + spnEduRas.Value + spnQualityRas.Value + spnTheoryRas.Value + spnHistoryRas.Value) + "";
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                staffBindingSource.DataSource = dc.Staffs.Where(x => x.Offical == true).ToList();
            }
            else
            {
                staffBindingSource.DataSource = dc.Staffs.Where(x => x.Offical == false).ToList();
            }
        }
    }
}