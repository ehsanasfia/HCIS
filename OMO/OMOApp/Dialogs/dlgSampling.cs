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
using OMOApp.Data.HCISData;
using OMOApp.Forms;

namespace OMOApp.Dialogs
{
    public partial class dlgSampling : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        public GivenServiceM SelectedGSM { get; set; }
        public List<ViewLabGroupby> lstItems { get; set; }

        private bool PrintLabels;

        public dlgSampling(bool printLabels)
        {
            PrintLabels = printLabels;
            InitializeComponent();
        }

        private void dlgSampling_Load(object sender, EventArgs e)
        {

            if (PrintLabels)
            {
                layoutBtnOk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                colGivenLaboratoryServiceD.Visible = false;
                colGivenLaboratoryServiceD.VisibleIndex = -1;
                colGivenLaboratoryServiceD.OptionsColumn.ShowInCustomizationForm = false;
            }

            var person = SelectedGSM.Person;
            lblName.Text += " " + person.FirstName + " " + person.LastName;
            lblDailySN.Text += " " + SelectedGSM.DailySN;
            lblSerialNumber.Text += " " + SelectedGSM.SerialNumber;
            lblTurningDate.Text += " " + SelectedGSM.TurningDate + "-" + SelectedGSM.TurningTime;
            lblAdmitDate.Text += " " + SelectedGSM.AdmitDate + "-" + SelectedGSM.AdmitTime;

            lstItems = dc.ViewLabGroupbies.Where(x => x.GivenServiceMID == SelectedGSM.ID).ToList();

            bool confirmAll = true;
            foreach (var item in lstItems)
            {
                List<GivenServiceD> gsds;

                gsds = SelectedGSM.GivenServiceDs.Where(x => x.Service != null 
                        && x.Service.LaboratoryServiceDetail != null
                        && x.Service.LaboratoryServiceDetail.GroupID == item.GroupID).ToList();

                item.GivenServiceDs = gsds;
                var firstGSD = gsds.FirstOrDefault();
                if (firstGSD != null)
                    item.FirstGSDID = firstGSD.ID;
                item.GivenServiceM = SelectedGSM;
                item.Tests = "";
                for (int i = 0; i < gsds.Count; i++)
                {
                    var gsd = gsds.ElementAt(i);
                    if (gsd == null)
                        continue;
                    if (gsd.GivenLaboratoryServiceD == null)
                    {
                        gsd.GivenLaboratoryServiceD = new GivenLaboratoryServiceD();
                    }

                    item.Tests += gsd.Service.LaboratoryServiceDetail == null
                        ? (string.IsNullOrWhiteSpace(gsd.Service.Name_En) ? gsd.Service.Name : gsd.Service.Name_En)
                        : gsd.Service.LaboratoryServiceDetail.AbbreviationName + "";
                    if (i != gsds.Count - 1)
                    {
                        item.Tests += " | ";
                    }
                    if (gsd.GivenLaboratoryServiceD.GetSampel)
                    {
                        confirmAll = false;
                        item.GetSample = true;
                    }
                }
            }

            // "HB-A1C" Test
            //GivenServiceD gsdHBA1C = SelectedGSM.GivenServiceDs.FirstOrDefault(x => x.Service != null && x.Service.OldID == 93);
            //if (gsdHBA1C != null)
            //{
            //    foreach (var gp in lstItems)
            //    {
            //        var gsdOldHba1c = gp.GivenServiceDs.FirstOrDefault(x => x.Service != null && x.Service.OldID == 93);
            //        if (gsdOldHba1c != null)
            //            gp.GivenServiceDs.Remove(gsdOldHba1c);
            //    }
            //    var item = lstItems.FirstOrDefault(x => x.GroupID == 13);

            //    if (item == null)
            //    {
            //        item = new ViewLabGroupby()
            //        {
            //            PersonID = SelectedGSM.PersonID,
            //            SerialNumber = SelectedGSM.SerialNumber,
            //            GroupID = 13,
            //            GroupName = "بیو شیمی 1",
            //            GivenServiceMID = SelectedGSM.ID,
            //            EName = "biochemistry 1",
            //        };
            //        item.FirstGSDID = gsdHBA1C.ID;
            //        item.GivenServiceM = SelectedGSM;
            //        item.GivenServiceDs = new List<GivenServiceD>();
            //        item.GivenServiceDs.Add(gsdHBA1C);
            //        item.Tests = "";
            //        lstItems.Add(item);
            //    }

                
            //    if (gsdHBA1C.GivenLaboratoryServiceD == null)
            //    {
            //        gsdHBA1C.GivenLaboratoryServiceD = new GivenLaboratoryServiceD();
            //    }

            //    item.Tests += gsdHBA1C.Service.LaboratoryServiceDetail == null
            //            ? (string.IsNullOrWhiteSpace(gsdHBA1C.Service.Name_En) ? gsdHBA1C.Service.Name : gsdHBA1C.Service.Name_En)
            //            : gsdHBA1C.Service.LaboratoryServiceDetail.AbbreviationName + "";
            //    if (gsdHBA1C.GivenLaboratoryServiceD.GetSampel)
            //    {
            //        confirmAll = false;
            //        item.GetSample = true;
            //    }
            //}


            if (confirmAll)
            {
                foreach (var item in lstItems)
                {
                    item.GetSample = true;
                }
            }

            viewLabGroupbiesBindingSource.DataSource = lstItems;
            gridControl1.RefreshDataSource();
            if (PrintLabels)
                btnPrintAllLabels.PerformClick();
        }

        private void btnPrintLabel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var cur = gridView1.GetFocusedRow() as ViewLabGroupby;
                if (cur == null)
                    return;

                var lst = new List<ViewLabGroupby>();
                lst.Add(cur);

                var LabelList = from c in lst
                                select new
                                {
                                    ID = c.FirstGSDID == null ? "" : c.FirstGSDID.ToString(),
                                    c.GivenServiceM.Person.FirstName,
                                    c.GivenServiceM.Person.LastName,
                                    c.Tests,
                                    c.GivenServiceM.SerialNumber,
                                    GroupName = c.EName,
                                    DailySN = SelectedGSM.DailySN == null ? "" : SelectedGSM.DailySN.ToString(),
                                    AdmitDate = c.GivenServiceM.AdmitDate ?? ""
                                };

                stiLabel.RegData("LabelList", LabelList);
                stiLabel.Compile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (chkPreview.Checked)
            {
                stiLabel.CompiledReport.ShowWithRibbonGUI();
                //stiLabel.Design();
            }
            else
            {
                //bool found = false;
                //var myPrnt = Properties.Settings.Default.LabelPrinterName;
                //if (!string.IsNullOrWhiteSpace(myPrnt))
                //{
                //    foreach (string prnt in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //    {
                //        if (myPrnt == prnt)
                //        {
                //            found = true;
                //            break;
                //        }
                //    }
                //}

                //if (found)
                //{
                //    stiLabel.CompiledReport.PrinterSettings.PrinterName = myPrnt;
                //    stiLabel.CompiledReport.Print(false);
                //}
                //else
                //{
                //    MessageBox.Show("چاپگر انتخاب شده برای برچسب، متصل نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                //    stiLabel.CompiledReport.Print(true);
                //    return;
                //}
            }

        }

        private void btnPrintAllLabels_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstItems == null || !lstItems.Any())
                {
                    MessageBox.Show("لیست خالی است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var LabelList = from c in lstItems
                                select new
                                {
                                    ID = c.FirstGSDID == null ? "" : c.FirstGSDID.ToString(),
                                    c.GivenServiceM.Person.FirstName,
                                    c.GivenServiceM.Person.LastName,
                                    c.Tests,
                                    c.GivenServiceM.SerialNumber,
                                    GroupName = c.EName,
                                    DailySN = SelectedGSM.DailySN == null ? "" : SelectedGSM.DailySN.ToString(),
                                    AdmitDate = c.GivenServiceM.AdmitDate ?? ""
                                };

                stiLabel.RegData("LabelList", LabelList);
                stiLabel.Compile();


                // do sampling when print all
                lstItems.ForEach(x =>
                {
                    x.GivenServiceDs.Where(c => c != null).ToList().ForEach(y => y.GivenLaboratoryServiceD.GetSampel = x.GetSample);
                });
                SelectedGSM.SendToDr = true;
                ///////////////////

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!PrintLabels)
                stiLabel.CompiledReport.ShowWithRibbonGUI();
            else
            {
                DialogResult = DialogResult.OK;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}