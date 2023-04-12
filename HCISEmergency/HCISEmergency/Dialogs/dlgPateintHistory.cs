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

namespace HCISEmergency.Dialogs
{
    public partial class dlgPateintHistory : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public Guid PersonID { set; get; }
        public bool drug, test, diag = false;
        Person CurrentPC;
        Person CurrentNC;

        public dlgPateintHistory()
        {
            InitializeComponent();
        }

        private void PateintHistory_Load(object sender, EventArgs e)
        {
            dossierBindingSource.DataSource = dc.Dossiers.Where(c => c.PersonID == PersonID && c.IOtype == 1).ToList();
            var per = dc.Persons.Where(x => x.ID == PersonID).FirstOrDefault();

            spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(per.NationalCode).ToList();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var dosseir = dossierBindingSource.Current as Dossier;
            if (dosseir == null)
            {
                vwDoctorInstractionBindingSource.DataSource = null;
                return;
            }
            vwDoctorInstractionBindingSource.DataSource = dc.VwDoctorInstractions.Where(c => c.DossierID == dosseir.ID).ToList();
        }

        private void spuFullLabHistoryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPersonalCode.Text))
            {
                var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
                if (current == null)
                    return;
                spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(CurrentPC.NationalCode).Where(x => x.ID == current.ID);
                gridView5.ExpandAllGroups();
            }
            else if (!string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
                if (current == null)
                    return;
                spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(CurrentNC.NationalCode).Where(x => x.ID == current.ID);
                gridView5.ExpandAllGroups();
            }
            else
            {
                var per = dc.Persons.Where(x => x.ID == PersonID).FirstOrDefault();
                var current = spuFullLabHistoryResultBindingSource.Current as Spu_FullLabHistoryResult;
                if (current == null)
                    return;
                spuFullLabHistoryResultBindingSource1.DataSource = dc.Spu_FullLabHistory(per.NationalCode).Where(x => x.ID == current.ID);
                gridView5.ExpandAllGroups();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var cur = spuDiagnosticServiceHistoryResultBindingSource.Current as Spu_DiagnosticService_HistoryResult;
            //var image = im.Studies.Where(x => x.PatientId.Contains(cur.SerialNumber.ToString())).ToList();


            var result = "http://172.30.1.80/metric/hisintegration.aspx?ID=";
            result += cur.SerialNumber.ToString();
            System.Diagnostics.Process.Start(result);

            //if (cur.Studies.Count == 1)
            //{
            //    var list = cur.Studies.FirstOrDefault();
            //    var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
            //    result += list.StudyInstanceUid;
            //    System.Diagnostics.Process.Start(result);
            //}

            //else
            //{
            //    var dlg = new Dialogs.dlgImages();
            //    dlg.serial = cur.SerialNumber.ToString();
            //    dlg.lstStudy = cur.Studies;
            //    dlg.ShowDialog();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtPersonalCode.Text))
            {
                var dlg = new dlgSameCode();
                dlg.dc = dc;
                dlg.PersonalC = txtPersonalCode.Text;
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    CurrentPC = dlg.Current;
                    dossierBindingSource.DataSource = dc.Dossiers.Where(c => c.PersonID == CurrentPC.ID && c.IOtype == 1).ToList();
                    var per = dc.Persons.Where(x => x.ID == CurrentPC.ID).FirstOrDefault();

                    spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(per.NationalCode).ToList();
                }
                diag = false;
                drug = false;
            }
            else if(!string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                CurrentNC = dc.Persons.FirstOrDefault(c => c.NationalCode == txtNationalCode.Text);
                dossierBindingSource.DataSource = dc.Dossiers.Where(c => c.PersonID == CurrentNC.ID && c.IOtype == 1).ToList();
                var per = dc.Persons.Where(x => x.ID == CurrentNC.ID).FirstOrDefault();

                spuFullLabHistoryResultBindingSource.DataSource = dc.Spu_FullLabHistory(per.NationalCode).ToList();
                diag = false;
                drug = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView6_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var d = (bool?)gridView6.GetRowCellValue(e.FocusedRowHandle, gridColumn7);
            if (d == true)
                simpleButton1.Enabled = true;
            else
                simpleButton1.Enabled = false;
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPersonalCode.Text))
            {
                if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                {
                    if (!drug)
                    {
                        spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(CurrentPC.NationalCode);

                    }
                    drug = true;
                }
                else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                {
                    if (!diag)
                    {
                        spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(CurrentPC.NationalCode);
                    }
                    diag = true;
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                {
                    if (!drug)
                    {
                        spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(CurrentNC.NationalCode);

                    }
                    drug = true;
                }
                else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                {
                    if (!diag)
                    {
                        spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(CurrentNC.NationalCode);
                    }
                    diag = true;
                }
            }
            else
            {
                var per = dc.Persons.Where(x => x.ID == PersonID).FirstOrDefault();

                if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                {
                    if (!drug)
                    {
                        spuDrugHistoryResultBindingSource.DataSource = dc.Spu_DrugHistory(per.NationalCode);

                    }
                    drug = true;
                }
                //else if (tabbedControlGroup1.SelectedTabPageIndex == 2)
                //{
                //    if (!test)
                //    {


                //    }
                //    test = true;
                //}
                else if (tabbedControlGroup1.SelectedTabPageIndex == 3)
                {
                    if (!diag)
                    {
                        spuDiagnosticServiceHistoryResultBindingSource.DataSource = dc.Spu_DiagnosticService_History(per.NationalCode);
                    }
                    diag = true;
                }
            }
        }
    }
}