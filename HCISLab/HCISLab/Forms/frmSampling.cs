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
using HCISLab.Data;
using HCISLab.Dialogs;

namespace HCISLab.Forms
{
    public partial class frmSampling : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        public frmSampling()
        {
            InitializeComponent();
        }

        private void frmSampling_Load(object sender, EventArgs e)
        {
            //givenServiceDsBindingSource.DataSource = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.Service != null); / test---------
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            bbiDateSearch_ItemClick(null, null);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiDateSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                givenServiceMsBindingSource.DataSource = dc.GivenServiceMs.Where(x =>
                    x.ServiceCategoryID == (int)Category.آزمایش
                    && x.GivenServiceDs.Any()
                    && !x.Confirm
                    && (x.Payed || (x.GivenServiceM1 != null
                                        && x.GivenServiceM1.Department != null
                                        && x.GivenServiceM1.Department.TypeID == 11
                                        && x.GivenServiceM1.Department.Name != "اورژانس"))
                    && x.DailySN != null
                    && x.DepartmentID == MainModule.InstallLocation.ID
                    //&& x.SendToDr != true
                    && x.TurningDate.CompareTo(dtpFrom.Date) >= 0
                    && x.TurningDate.CompareTo(dtpTo.Date) <= 0)
                    .OrderByDescending(x => x.SerialNumber)
                    .OrderBy(x => x.DailySN).ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnPrintLabel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            /*
            splashScreenManager2.ShowWaitForm();
            var currant = givenServiceDsBindingSource.Current as GivenServiceD;
            if (currant.GivenLaboratoryServiceD.SampelCounter < 1)
            {
                currant.GivenLaboratoryServiceD.SampelCounter = 1;
                currant.GivenLaboratoryServiceD.GetSampel = true;
            }
            else
                if (MessageBox.Show("آیادر حال انجام ازمایش تکراری هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                currant.GivenLaboratoryServiceD.SampelCounter++;
            givenServiceDsBindingSource.EndEdit();

            dc.SubmitChanges();
            try
            {
                var gsd = givenServiceDsBindingSource.Current as GivenServiceD;
                if (gsd == null)
                {
                    return;
                }

                stiLabel.Dictionary.Variables.Add("Name", gsd.GivenServiceM.Person.FirstName + " " + gsd.GivenServiceM.Person.LastName);
                stiLabel.Dictionary.Variables.Add("TestName", gsd.Service.LaboratoryServiceDetail.AbbreviationName);
                stiLabel.Dictionary.Variables.Add("GSDID", gsd.ID);

                stiLabel.Dictionary.Synchronize();
                stiLabel.Compile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
            stiLabel.CompiledReport.ShowWithRibbonGUI();
            */
        }

        private void bbiPrintSamplingList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                List<GivenServiceD> mylist = new List<GivenServiceD>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    var dataRow = gridView1.GetRow(gridView1.GetVisibleRowHandle(i));
                    mylist.Add((GivenServiceD)dataRow);

                }
                 if (mylist.Count()==0 || !mylist.Any())
                {
                    MessageBox.Show("لیست خالی است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var azmayesh =
                    from c in mylist
                    select new
                    {
                        DailySN = c.GivenServiceM.DailySN == null ? null : c.GivenServiceM.DailySN + "",
                        Person = c.GivenServiceM.Person.FirstName + " " + c.GivenServiceM.Person.LastName + " " + c.GivenServiceM.Person.NationalCode,
                        TurningDate = c.GivenServiceM.TurningDate,
                        TestName = c.Service.LaboratoryServiceDetail == null ? c.Service.Name_En : c.Service.LaboratoryServiceDetail.AbbreviationName,
                        Result = c.GivenLaboratoryServiceD == null ? null : c.GivenLaboratoryServiceD.Result,
                        ID = c.ID.ToString()
                    };
                stiSamplingList.RegData("azmayesh", azmayesh);
                //stiSamplingList.Design();
                stiSamplingList.Compile();
                stiSamplingList.CompiledReport.ShowWithRibbonGUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnGSMSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dlgGSM = new dlgGSMSearch() { };
                if (dlgGSM.ShowDialog() == DialogResult.OK && dlgGSM.SelectedGSM_ID != null)
                {
                    var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == dlgGSM.SelectedGSM_ID);
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsm);


                    if (gsm.GivenServiceDs.Any())
                    {
                        foreach (var gsd in gsm.GivenServiceDs)
                        {
                            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd);
                            if (gsd.GivenLaboratoryServiceD != null)
                                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd.GivenLaboratoryServiceD);
                        }
                    }
                    if (gsm.Admitted == false)
                    {
                        MessageBox.Show("نسخه ی انتخاب شده هنوز پذیرش نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (gsm.Payed == false && (gsm.GivenServiceM1 == null
                || gsm.GivenServiceM1.Department == null || gsm.GivenServiceM1.Department.TypeID != 11 || gsm.GivenServiceM1.Department.Name == "اورژانس"))
                    {
                        MessageBox.Show("نسخه ی انتخاب شده هنوز پرداخت نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    if (gsm.TurningDate == null)
                    {
                        MessageBox.Show("نسخه ی انتخاب شده هنوز نوبت دهی نشده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }

                    var lst = new List<GivenServiceM>();
                    lst.Add(gsm);
                    givenServiceMsBindingSource.DataSource = lst;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var current = givenServiceMsBindingSource.Current as GivenServiceM;
                if (current == null)
                {
                    return;
                }
                bool wasConfirmed = current.SendToDr;

                var dlg = new dlgSampling(false) { SelectedGSM = current, dc = dc };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dlg.lstItems.ForEach(x =>
                    {
                        x.GivenServiceDs.ForEach(y => y.GivenLaboratoryServiceD.GetSampel = x.GetSample);
                    });

                    dlg.SelectedGSM.SendToDr = true;
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}