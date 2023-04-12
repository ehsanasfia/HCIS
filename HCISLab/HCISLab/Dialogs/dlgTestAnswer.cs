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
using DevExpress.XtraEditors.Repository;

namespace HCISLab.Dialogs
{
    public partial class dlgTestAnswer : DevExpress.XtraEditors.XtraForm
    {
        private HCISLabClassesDataContext dc;
        public List<Guid> selectedTestIDs { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool EMG { get; set; }
        public int? FromSN { get; set; }
        public int? ToSN { get; set; }
        public int? labGpID { get; set; }
        public bool Grouping { get; set; }

        public List<GivenServiceM> GSMlist { get; set; }

        public bool byGSM { get; set; }
        private GivenServiceM EditingGSM;
        private bool loadingFromDB;

        public dlgTestAnswer()
        {
            InitializeComponent();
        }

        private void dlgTestAnswer_Load(object sender, EventArgs e)
        {
            dc = new HCISLabClassesDataContext();
            if (!Grouping)
            {
                gridView2.ClearGrouping();
                colService.Visible = false;
                colService.VisibleIndex = -1;
            }

            viewSecurityUserBindingSource.DataSource = dc.View_SecurityUsers.ToList();

            GetData();
        }

        private void GetData()
        {
            if (byGSM) //بر اساس یک تسخه
            {
                GSMlist = dc.GivenServiceMs.Where(x => x.ID == GSMlist.FirstOrDefault().ID).ToList();
                givenServiceMsBindingSource.DataSource = GSMlist;
            }
            else
            {
                if (labGpID == null) // بر اساس تست های انتخابی
                {
                    if (chkOnlyNotConfirmed.Checked) //فقط آزمایشات ناقص
                    {
                        GSMlist = dc.GivenServiceMs.Where(x =>
                            x.ServiceCategoryID == (int)Category.آزمایش
                            && x.GivenServiceDs.Any()
                            && (EMG ? x.Priority == true : true)
                            && x.Admitted
                            && x.TurningDate != null
                            && x.TurningDate.CompareTo(FromDate) >= 0
                            && x.TurningDate.CompareTo(ToDate) <= 0
                            && x.DepartmentID == MainModule.InstallLocation.ID
                            && (FromSN == null ? true : (x.DailySN >= FromSN))
                            && (ToSN == null ? true : (x.DailySN <= ToSN))
                            && x.GivenServiceDs.Any(g => g.Service != null && selectedTestIDs.Contains(g.Service.ID))
                            && x.GivenServiceDs.Any(g => !g.Confirm || g.GivenLaboratoryServiceD == null || g.GivenLaboratoryServiceD.Result == null || g.GivenLaboratoryServiceD.Result.Trim() == "")
                            ).ToList();

                        givenServiceMsBindingSource.DataSource = GSMlist;
                    }
                    else
                    {
                        GSMlist = dc.GivenServiceMs.Where(x =>
                            x.ServiceCategoryID == (int)Category.آزمایش
                            && x.GivenServiceDs.Any()
                            && (EMG ? x.Priority == true : true)
                            && x.Admitted
                            && x.TurningDate != null
                            && x.TurningDate.CompareTo(FromDate) >= 0
                            && x.TurningDate.CompareTo(ToDate) <= 0
                            && x.DepartmentID == MainModule.InstallLocation.ID
                            && (FromSN == null ? true : (x.DailySN >= FromSN))
                            && (ToSN == null ? true : (x.DailySN <= ToSN))
                            && x.GivenServiceDs.Any(g => g.Service != null && selectedTestIDs.Contains(g.Service.ID))
                            ).ToList();

                        givenServiceMsBindingSource.DataSource = GSMlist;
                    }
                }
                else //بر اساس زیرگروه آزمایشی
                {
                    if (chkOnlyNotConfirmed.Checked) //فقط آزمایشات ناقص
                    {
                        GSMlist = dc.GivenServiceMs.Where(x =>
                            x.ServiceCategoryID == (int)Category.آزمایش
                            && x.GivenServiceDs.Any()
                            && (EMG ? x.Priority == true : true)
                            && x.Admitted
                            && x.TurningDate != null
                            && x.TurningDate.CompareTo(FromDate) >= 0
                            && x.TurningDate.CompareTo(ToDate) <= 0
                            && x.DepartmentID == MainModule.InstallLocation.ID
                            && (FromSN == null ? true : (x.DailySN >= FromSN))
                            && (ToSN == null ? true : (x.DailySN <= ToSN))
                            && x.GivenServiceDs.Any(g => g.Service != null && g.Service.LabTestGroups.Any(c => c.LabSubGroup.LabGroupID == labGpID))
                            && x.GivenServiceDs.Any(g => !g.Confirm || g.GivenLaboratoryServiceD == null || g.GivenLaboratoryServiceD.Result == null || g.GivenLaboratoryServiceD.Result.Trim() == "")
                            ).ToList();
                        givenServiceMsBindingSource.DataSource = GSMlist;
                    }
                    else
                    {
                        GSMlist = dc.GivenServiceMs.Where(x =>
                            x.ServiceCategoryID == (int)Category.آزمایش
                            && x.GivenServiceDs.Any()
                            && (EMG ? x.Priority == true : true)
                            && x.Admitted
                            && x.TurningDate != null
                            && x.TurningDate.CompareTo(FromDate) >= 0
                            && x.TurningDate.CompareTo(ToDate) <= 0
                            && x.DepartmentID == MainModule.InstallLocation.ID
                            && (FromSN == null ? true : (x.DailySN >= FromSN))
                            && (ToSN == null ? true : (x.DailySN <= ToSN))
                            && x.GivenServiceDs.Any(g => g.Service != null && g.Service.LabTestGroups.Any(c => c.LabSubGroup.LabGroupID == labGpID))
                            ).ToList();
                        givenServiceMsBindingSource.DataSource = GSMlist;
                    }
                }
            }

            givenServiceMsBindingSource_CurrentChanged(null, null);
        }

        private void givenServiceMsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!GSMlist.Any())
            {
                givenServiceDsBindingSource.DataSource = null;
                return;
            }
            var cur = givenServiceMsBindingSource.Current as GivenServiceM;
            if (cur == null)
            {
                givenServiceDsBindingSource.DataSource = null;
                return;
            }

            EditingGSM = cur;
            calcsSearched = false;
            loadingFromDB = true;
            if (byGSM) //بر اساس یک نسخه
            {
                if (chkOnlyNotConfirmed.Checked) //فقط آزمایشات ناقص
                    givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.Where(x => 
                    x.Service != null 
                    && (x.GivenLaboratoryServiceD == null || x.GivenLaboratoryServiceD.Result == null || x.GivenLaboratoryServiceD.Result.Trim() == ""))
                    .OrderBy(x => x.Service.OldID);
                else
                    givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs
                        .Where(x => x.Service != null)
                        .OrderBy(x => x.Service.OldID);
            }
            else
            {
                if (labGpID == null) //بر اساس تست های انتخابی
                {
                    if (chkOnlyNotConfirmed.Checked) //فقط آزمایشات ناقص
                        givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs
                            .Where(x => x.Service != null 
                            && (x.GivenLaboratoryServiceD == null || x.GivenLaboratoryServiceD.Result == null || x.GivenLaboratoryServiceD.Result.Trim() == "")
                            && selectedTestIDs.Contains(x.Service.ID)).OrderBy(x => x.Service.OldID);
                    else
                        givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs
                            .Where(x => selectedTestIDs.Contains(x.Service.ID))
                            .OrderBy(x => x.Service.OldID);
                }
                else //بر اساس زیرگروه آزمایشی
                {
                    if (chkOnlyNotConfirmed.Checked) //فقط آزمایشات ناقص
                        givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.Where(x => x.Service != null
                        && (x.GivenLaboratoryServiceD == null || string.IsNullOrWhiteSpace(x.GivenLaboratoryServiceD.Result))
                        && x.Service.LabTestGroups.Any(c => c.LabSubGroup.LabGroupID == labGpID)).OrderBy(x => x.Service.OldID);
                    else
                        givenServiceDsBindingSource.DataSource = EditingGSM.GivenServiceDs.Where(x => x.Service != null
                        && x.Service.LabTestGroups.Any(c => c.LabSubGroup.LabGroupID == labGpID)).OrderBy(x => x.Service.OldID);
                }
            }

            if (givenServiceDsBindingSource.Count > 0)
            {
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, (IEnumerable<GivenServiceD>)givenServiceDsBindingSource.DataSource);
                dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, ((IEnumerable<GivenServiceD>)givenServiceDsBindingSource.DataSource).Where(x => x.GivenLaboratoryServiceD != null).Select(x => x.GivenLaboratoryServiceD));
            }

            gridControl2.RefreshDataSource();
            loadingFromDB = false;
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var gsd = e.Row as GivenServiceD;
            SaveGSD(gsd);
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var gsd = gridView2.GetRow(e.RowHandle) as GivenServiceD;
            if (gsd == null)
                return;
            if (gsd.GivenLaboratoryServiceD == null)
            {
                gsd.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { ID = gsd.ID };
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var gsd = gridView2.GetRow(e.RowHandle) as GivenServiceD;
            if (gsd != null)
            {
                gsd.LastModificator = MainModule.UserID;

                if (e.Column != colConfirm)
                {
                    if (gsd.GivenLaboratoryServiceD != null && !string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result))
                    {
                        gsd.Confirm = true;
                    }
                }
            }


            if (!loadingFromDB && e.Column == colResult)
            {
                CalculateLabTests();
                SaveGSD(gsd);
            }
        }

        private void btnConfirmAll_Click(object sender, EventArgs e)
        {
            if (givenServiceDsBindingSource.DataSource == null)
            {
                return;
            }
            foreach (var gsd in (IEnumerable<GivenServiceD>)givenServiceDsBindingSource.DataSource)
            {
                gsd.Confirm = true;
            }
        }

        private void chkOnlyNotConfirmed_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.End)
            {
                gridView2.CloseEditor();
                gridView2.UpdateCurrentRow();
                gridView1.MoveNext();
                gridView2.MoveFirst();
                return true;
            }
            else if (keyData == Keys.Home)
            {
                gridView2.CloseEditor();
                gridView2.UpdateCurrentRow();
                gridView1.MovePrev();
                gridView2.MoveFirst();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                //if (gridView2.IsLastRow)
                //{
                //    gridView2.CloseEditor();
                //    gridView2.UpdateCurrentRow();
                //    gridView1.MoveNext();
                //    gridView2.MoveFirst();
                //    return true;
                //}
                //else
                if (gridControl2.ContainsFocus)
                {

                    if (gridView2.IsEditing)
                    {
                        if (gridView2.FocusedColumn == colResult)
                        {
                            var gsd = givenServiceDsBindingSource.Current as GivenServiceD;
                            if (gsd == null
                                || gsd.GivenLaboratoryServiceD == null
                                || string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result)
                                || !gsd.GivenLaboratoryServiceD.Result.Trim().Contains("\n"))
                            {
                                gridView2.CloseEditor();
                                gridView2.UpdateCurrentRow();
                                gridView2.MoveNext();
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            gridView2.CloseEditor();
                            gridView2.UpdateCurrentRow();
                            gridView2.MoveNext();
                            return true;
                        }
                    }
                    else
                    {
                        gridView2.CloseEditor();
                        gridView2.UpdateCurrentRow();
                        gridView2.MoveNext();
                        return true;
                    }
                }
            }
            else if (keyData == Keys.Up)
            {
                if (gridControl2.ContainsFocus)
                {
                    if (gridView2.IsEditing)
                    {
                        if (gridView2.FocusedColumn == colResult)
                        {
                            var gsd = givenServiceDsBindingSource.Current as GivenServiceD;
                            if (gsd == null
                                || gsd.GivenLaboratoryServiceD == null
                                || string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result)
                                || !gsd.GivenLaboratoryServiceD.Result.Trim().Contains("\n"))
                            {
                                gridView2.CloseEditor();
                                gridView2.UpdateCurrentRow();
                                gridView2.MovePrev();
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            gridView2.CloseEditor();
                            gridView2.UpdateCurrentRow();
                            gridView2.MovePrev();
                            return true;
                        }
                    }
                    else
                    {
                        gridView2.CloseEditor();
                        gridView2.UpdateCurrentRow();
                        gridView2.MovePrev();
                        return true;
                    }
                }
                else if (gridControl1.ContainsFocus)
                {
                    if (gridView1.IsEditing)
                    {
                        gridView1.CloseEditor();
                        gridView1.UpdateCurrentRow();
                        //gridView1.ShowEditor();
                        gridView1.MovePrev();
                        return true;
                    }
                }
            }
            else if (keyData == Keys.Enter)
            {
                if (gridControl2.ContainsFocus)
                {

                    if (gridView2.IsEditing)
                    {
                        if (gridView2.FocusedColumn == colResult)
                        {
                            var gsd = givenServiceDsBindingSource.Current as GivenServiceD;
                            if (gsd == null
                                || gsd.GivenLaboratoryServiceD == null
                                || string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result)
                                || !gsd.GivenLaboratoryServiceD.Result.Trim().Contains("\n"))
                            {
                                gridView2.CloseEditor();
                                gridView2.UpdateCurrentRow();
                                gridView2.MoveNext();
                                return true;
                            }
                            else
                            {
                                return base.ProcessCmdKey(ref msg, keyData);
                            }
                        }
                        else
                        {
                            gridView2.CloseEditor();
                            gridView2.UpdateCurrentRow();
                            gridView2.MoveNext();
                            return true;
                        }
                    }
                    else
                    {
                        gridView2.CloseEditor();
                        gridView2.UpdateCurrentRow();
                        gridView2.MoveNext();
                        return true;
                    }
                }
            }
            else if (keyData == (Keys.Control | Keys.B))
            {
                if (!gridControl2.ContainsFocus)
                    return base.ProcessCmdKey(ref msg, keyData);

                var gsd = givenServiceDsBindingSource.Current as GivenServiceD;
                if (gsd == null
                    || gsd.Service == null
                    || gsd.Service.LaboratoryServiceDetail == null
                    || gsd.Service.LaboratoryServiceDetail.TestType == "توضيحي")
                    return base.ProcessCmdKey(ref msg, keyData);

                gridView2.CloseEditor();
                //gridView2.UpdateCurrentRow();
                var dlg = new dlgAntiBio() { dc = dc };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //if (gsd.GivenLaboratoryServiceD == null)
                    //{
                    //    gsd.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { ID = gsd.ID };
                    //}

                    var str = gsd.GivenLaboratoryServiceD.Result ?? "";

                    gsd.GivenLaboratoryServiceD.Result = (str + Environment.NewLine + dlg.Result).Trim();

                    gsd.GivenLaboratoryServiceD.NormalRange = gsd.Service.LaboratoryServiceDetail == null ? null : gsd.Service.LaboratoryServiceDetail.NormalRange;
                    gsd.Confirm = !string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result);
                    SaveGSD(gsd);
                    gridControl2.RefreshDataSource();
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Q))
            {
                if (!gridControl2.ContainsFocus)
                    return base.ProcessCmdKey(ref msg, keyData);

                if (gridView2.IsEditing)
                {
                    gridView2.CloseEditor();
                    //gridView2.UpdateCurrentRow();
                }

                foreach (var gsd in (IEnumerable<GivenServiceD>)givenServiceDsBindingSource.DataSource)
                {
                    if (gsd.Service == null)
                        continue;
                    if (gsd.Service.OldID != 432
                        && gsd.Service.OldID != 433
                        && gsd.Service.OldID != 435
                        && gsd.Service.OldID != 436
                        && gsd.Service.OldID != 437
                        && gsd.Service.OldID != 438
                        && gsd.Service.OldID != 439
                        && gsd.Service.OldID != 440
                        && gsd.Service.OldID != 441
                        && gsd.Service.OldID != 442
                        )
                        continue;

                    //if (gsd.GivenLaboratoryServiceD == null)
                    //{
                    //    gsd.GivenLaboratoryServiceD = new GivenLaboratoryServiceD() { ID = gsd.ID };
                    //}

                    if (string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result)
                        && gsd.Service.LaboratoryServiceDetail != null)
                    {
                        gsd.GivenLaboratoryServiceD.Result = gsd.Service.LaboratoryServiceDetail.NormalRange;
                    }

                    SaveGSD(gsd);
                }
                gridControl2.RefreshDataSource();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void SaveGSD(GivenServiceD gsd)
        {
            if (gsd == null)
                return;
            if (gsd.GivenLaboratoryServiceD != null)
            {
                if (!string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result))
                {
                    gsd.Confirm = true;
                }
                else
                {
                    gsd.Confirm = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result) && gsd.GivenLaboratoryServiceD.Result.Trim().ElementAt(0) == '/')
            {
                var ResultTerm = gsd.GivenLaboratoryServiceD.Result.Trim();
                var re = dc.LabTerms.FirstOrDefault(c => c.ShortcutKey != null && c.ShortcutKey.Trim() == ResultTerm);
                if (re != null)
                    gsd.GivenLaboratoryServiceD.Result = re.TermText;
            }
            //dc.Refresh()
            gsd.GivenLaboratoryServiceD.NormalRange = gsd.Service.LaboratoryServiceDetail == null ? null : gsd.Service.LaboratoryServiceDetail.NormalRange;

            bool setAnsweringDate = false;
            if (EditingGSM != null && string.IsNullOrWhiteSpace(EditingGSM.AnsweringDate))
            {
                EditingGSM.AnsweringDate = MainModule.GetPersianDate(DateTime.Now);
                setAnsweringDate = true;
            }

            gsd.LastModificator = MainModule.UserID;

            //dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, gsd);
            //dc.Refresh(System.Data.Linq.RefreshMode.KeepChanges, gsd.GivenLaboratoryServiceD);

            //dc.SubmitChanges();
            dc.Spu_SetTestAnwer(gsd.GivenLaboratoryServiceD.ID, 
                string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result) ? null : gsd.GivenLaboratoryServiceD.Result.Trim(), 
                string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.NormalRange) ? null : gsd.GivenLaboratoryServiceD.NormalRange.Trim(), 
                gsd.LastModificator, 
                gsd.Confirm, 
                setAnsweringDate ? EditingGSM.ID : null as Guid?, 
                setAnsweringDate ? EditingGSM.AnsweringDate : null);

            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd);
            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, gsd.GivenLaboratoryServiceD);
        }

        #region Test Values Calcuations


        private GivenServiceD gsd483;
        private GivenServiceD gsd485;
        private GivenServiceD gsd486;
        private GivenServiceD gsd484;
        private GivenServiceD gsd487;
        private GivenServiceD gsd488;
        private GivenServiceD gsd64;
        private GivenServiceD gsd59;
        private GivenServiceD gsd58;
        private GivenServiceD gsd61;
        private GivenServiceD gsd60;
        private GivenServiceD gsd334;
        private GivenServiceD gsd331;
        private GivenServiceD gsd333;
        private GivenServiceD gsd100;
        private GivenServiceD gsd98;
        private GivenServiceD gsd99;
        private GivenServiceD gsd62;
        private GivenServiceD gsd63;
        private bool calcsSearched = false;
        private void CalculateLabTests()
        {
            if (EditingGSM == null || !EditingGSM.GivenServiceDs.Any())
                return;
            var lstGsd = (givenServiceDsBindingSource.DataSource as IEnumerable<GivenServiceD>).ToList();
            if (!calcsSearched)
            {
                gsd483 = lstGsd.FirstOrDefault(x => TestIsValid(x, "R.B.C"));
                gsd485 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Hematocrit"));
                gsd486 = lstGsd.FirstOrDefault(x => TestIsValid(x, "MCV"));
                gsd484 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Hemoglobin"));
                gsd487 = lstGsd.FirstOrDefault(x => TestIsValid(x, "MCH"));
                gsd488 = lstGsd.FirstOrDefault(x => TestIsValid(x, "MCHC"));
                gsd64 = lstGsd.FirstOrDefault(x => TestIsValid(x, "VLDL"));
                gsd59 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Triglyceride"));
                gsd58 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Cholesterol"));
                gsd61 = lstGsd.FirstOrDefault(x => TestIsValid(x, "LDL-Cholestrol"));
                gsd60 = lstGsd.FirstOrDefault(x => TestIsValid(x, "HDL-cholestrol"));
                gsd334 = lstGsd.FirstOrDefault(x => TestIsValid(x, "FTI"));
                gsd331 = lstGsd.FirstOrDefault(x => TestIsValid(x, "T4.Chemi"));
                gsd333 = lstGsd.FirstOrDefault(x => TestIsValid(x, "T3.Chemi"));
                gsd100 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Globulines Serum"));
                gsd98 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Protein(Total)"));
                gsd99 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Albumin Serum"));
                gsd62 = lstGsd.FirstOrDefault(x => TestIsValid(x, "LDL/HDL"));
                gsd63 = lstGsd.FirstOrDefault(x => TestIsValid(x, "Chol./HDL"));
                calcsSearched = true;
            }


            if (gsd486 != null && TestHasValue(gsd483) && TestHasValue(gsd485))
                MCV_486(gsd486, gsd483, gsd485);

            if (gsd487 != null && TestHasValue(gsd484) && TestHasValue(gsd483))
                MCH_487(gsd487, gsd484, gsd483);

            if (gsd488 != null && TestHasValue(gsd484) && TestHasValue(gsd485))
                MCHC_488(gsd488, gsd484, gsd485);

            if (gsd64 != null && TestHasValue(gsd59))
                VLDL_64(gsd64, gsd59);

            if (gsd61 != null && TestHasValue(gsd58) && TestHasValue(gsd60) && TestHasValue(gsd64))
                LDL_61(gsd61, gsd58, gsd60, gsd64);

            if (gsd334 != null && TestHasValue(gsd331) && TestHasValue(gsd333))
                FTI_334(gsd334, gsd331, gsd333);

            if (gsd100 != null && TestHasValue(gsd98) && TestHasValue(gsd99))
                Globulin_100(gsd100, gsd98, gsd99);

            if (gsd63 != null && TestHasValue(gsd58) && TestHasValue(gsd60))
                ChoHdl_63(gsd63, gsd58, gsd60);

            if (gsd62 != null && TestHasValue(gsd61) && TestHasValue(gsd60))
                LDLHDL_62(gsd62, gsd61, gsd60);

            gridControl2.RefreshDataSource();
        }

        private bool TestIsValid(GivenServiceD gsd, string TestName = null)
        {
            if (gsd == null
                || gsd.Service == null
                || string.IsNullOrWhiteSpace(gsd.Service.Name)
                || gsd.Service.CategoryID != (int)Category.آزمایش
                )
            {
                return false;
            }

            if (TestName == null)
                return true;

            if (gsd.Service.Name.Trim().ToLower()
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace(",", "")
                    .Replace("_", "")
                    .Replace(".", "")
                    .Replace("\\", "")
                    .Replace("/", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    !=
                    TestName.Trim().ToLower()
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace(",", "")
                    .Replace("_", "")
                    .Replace(".", "")
                    .Replace("\\", "")
                    .Replace("/", "")
                    .Replace("(", "")
                    .Replace(")", ""))
            {
                return false;
            }
            return true;
        }

        private bool TestHasValue(GivenServiceD gsd)
        {
            double res;
            if (gsd == null
                || gsd.GivenLaboratoryServiceD == null
                || string.IsNullOrWhiteSpace(gsd.GivenLaboratoryServiceD.Result)
                || !double.TryParse(gsd.GivenLaboratoryServiceD.Result, out res))
            {
                return false;
            }

            return true;
        }

        private void MCV_486(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t2 / t1) * 10, 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void MCH_487(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 / t2) * 10, 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void MCHC_488(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 / t2) * 100, 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void VLDL_64(GivenServiceD tstRes, GivenServiceD tst1)
        {
            double t1, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);

            t3 = Math.Round(t1 / 5, 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void LDL_61(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2, GivenServiceD tst3)
        {
            double t1, t2, t3, t4;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);
            t3 = double.Parse(tst3.GivenLaboratoryServiceD.Result);


            t4 = Math.Round(t1 - (t2 + t3), 2);
            tstRes.GivenLaboratoryServiceD.Result = t4 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void FTI_334(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 * t2) / 100, 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void Globulin_100(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 - t2), 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void ChoHdl_63(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 / t2), 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        private void LDLHDL_62(GivenServiceD tstRes, GivenServiceD tst1, GivenServiceD tst2)
        {
            double t1, t2, t3;
            t1 = double.Parse(tst1.GivenLaboratoryServiceD.Result);
            t2 = double.Parse(tst2.GivenLaboratoryServiceD.Result);

            t3 = Math.Round((t1 / t2), 2);
            tstRes.GivenLaboratoryServiceD.Result = t3 + "";
            tstRes.Confirm = true;

            SaveGSD(tstRes);
        }

        #endregion

        private void btnHistory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var EditingPerson = EditingGSM.Person;
                if (EditingGSM == null || EditingPerson.ID == Guid.Empty || EditingGSM == null || EditingGSM.ID == Guid.Empty)
                {
                    MessageBox.Show(" هیچ بیماری انتخاب نشده است یا بیمار وارد شده، ثبت و پذیرش نشده است.\r\nلطفا بیمار را از طریق جستجوی پذیرش یا کد ملی انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (string.IsNullOrWhiteSpace(EditingPerson.NationalCode) && string.IsNullOrWhiteSpace(EditingPerson.MedicalID))
                {
                    MessageBox.Show("بیمار، کد ملی و شناسه پزشکی ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var cur = givenServiceDsBindingSource.Current as GivenServiceD;
                if (cur == null)
                    return;
                if (cur.Service == null)
                    return;

                string nat = string.IsNullOrWhiteSpace(EditingPerson.NationalCode) ? null : EditingPerson.NationalCode.Trim();
                string med = string.IsNullOrWhiteSpace(EditingPerson.MedicalID) ? null : EditingPerson.MedicalID.Trim();
                var ID = EditingPerson.ID;

                //var lst = dc.Spu_LabHistory(nat, med).Where(x => x.OldID != null && x.OldID == cur.Service.OldID).ToList();
                var lst = dc.Spu_LabHistoryByID(ID, med).Where(x => x.OldID != null && x.OldID == cur.Service.OldID).ToList();

                var answer =
                    from c in lst
                    select new
                    {
                        c.SerialNumber,
                        c.Result,
                        c.AdmitDate,
                        c.Abbr
                    };

                stiHistory.Dictionary.Variables.Add("TestName", cur.Service.LaboratoryServiceDetail == null ? (cur.Service.Name_En ?? cur.Service.Name) : cur.Service.LaboratoryServiceDetail.AbbreviationName);
                stiHistory.Dictionary.Variables.Add("Person", "");
                stiHistory.Dictionary.Variables.Add("DateNow", MainModule.GetPersianDate(DateTime.Now));

                stiHistory.Dictionary.Variables.Add("Person", EditingPerson.FirstName + " " + EditingPerson.LastName);
                if (EditingGSM.Staff != null)
                {
                    stiHistory.Dictionary.Variables.Add("Doctor", EditingGSM.Staff.Person.FirstName + " " + EditingGSM.Staff.Person.LastName);
                }
                stiHistory.Dictionary.Variables.Add("Date", EditingGSM.AnsweringDate);


                stiHistory.RegData("Answer", answer);
                stiHistory.Dictionary.Synchronize();
                stiHistory.Compile();
                stiHistory.CompiledReport.ShowWithRibbonGUI();
                //stiHistory.Design();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void givenServiceDsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (gridControl2.ContainsFocus)
            {
                gridView2.ShowEditor();
            }
        }
    }
}