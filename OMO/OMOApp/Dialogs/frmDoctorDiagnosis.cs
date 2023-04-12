using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.IMData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class frmDoctorDiagnosis : BaseForm
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmDoctorDiagnosis(Document currentDocument, ViewType FormViewType = ViewType.New)
        {
            InitializeComponent();
            this.CurrentDocument = dc.Documents.FirstOrDefault(c => c.ID == currentDocument.ID);
            if (FormViewType == ViewType.View)
            {
                this.FormType = FormViewType;
                return;
            }

            if (CurrentDocument.DoctorDiagnosisMs.Any())
                FormType = frmDoctorDiagnosis.ViewType.Edit;
            else
                FormType = frmDoctorDiagnosis.ViewType.New;
        }

        public enum ViewType
        {
            New,
            View,
            Edit
        }

        internal bool SaveChanges(bool ShowMessage)
        {
            bool result = false;
            try
            {
                //Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                    {
                        var currentDiag = doctorDiagnosisMBindingSource.Current as DoctorDiagnosisM;
                        currentDiag.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        currentDiag.ModificationUser = MainModule.UserID;
                    }

                    dc.SubmitChanges();
                    if (ShowMessage)
                        MessageBox.Show("اطلاعات وارد شده با موفقیت ذخیره گردید", "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            return result;
        }

        private void frmDoctorDiagnosis_Load(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");


            diagnosisItemBindingSource1.DataSource = dc.DiagnosisItems;

            switch (FormType)
            {
                case ViewType.New:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var docdiag = new DoctorDiagnosisM()
                    {

                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        Date = today,
                        Time = now,
                        DoctorID = MainModule.UserID,

                    };
                    /*
                    dc.DiagnosisItems.Where(c => c.DiagnosisItem1 == null).ToList().ForEach(d =>
                    {
                        if (!docdiag.DoctorDiagnosisDs.Any(m => m.DiagnosisItem == d))
                        {
                            dc.DoctorDiagnosisDs.InsertOnSubmit(new DoctorDiagnosisD()
                            {
                                DoctorDiagnosisM = docdiag,
                                DiagnosisItem = d
                            });
                        }
                    });
                     */
                    CurrentDocument.DoctorDiagnosisMs.Add(docdiag);
                    doctorDiagnosisMBindingSource.DataSource = docdiag;
                    break;
                case ViewType.View:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    doctorDiagnosisMBindingSource.DataSource = CurrentDocument.DoctorDiagnosisMs.First();
                    
                    MainModule.MakeReadOnly(layoutControlGroup1);
                    break;
                case ViewType.Edit:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var currentDiag = CurrentDocument.DoctorDiagnosisMs.First();
                    doctorDiagnosisMBindingSource.DataSource = currentDiag;
                    break;
                default:
                    break;
            }
            RefreshDiagItems();
        }

        private void RefreshDiagItems()
        {
            doctorDiagnosisMBindingSource.EndEdit();
            doctorDiagnosisDsBindingSource.EndEdit();
            var DiagnosisM = doctorDiagnosisMBindingSource.Current as DoctorDiagnosisM;
            if (DiagnosisM != null)
            {
                var items = DiagnosisM.DoctorDiagnosisDs.Select(c => c.DiagnosisItem.ID).Distinct();
                
                diagnosisItemBindingSource.DataSource = dc.DiagnosisItems.Except(dc.DiagnosisItems.Where(c => items.Contains(c.ID)));            //doctorDiagnosisDsBindingSource.DataSource = CurrentDocument.DoctorDiagnosisMs.First().DoctorDiagnosisDs;
                
            }
            else
            {
                diagnosisItemBindingSource.DataSource = dc.DiagnosisItems;
            }
            
            treeList1.ExpandAll();
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            var node = treeList1.CalcHitInfo(e.Location).Node;
            AddNode(node);
        }

        private void AddNode(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            if (node == null)
                return;
            var diagItem = diagnosisItemBindingSource.Current as DiagnosisItem;

            if (diagItem.DiagnosisItems.Any())
            {
                node.ExpandAll();
                return;
            }



            var DiagnosisM = doctorDiagnosisMBindingSource.Current as DoctorDiagnosisM;

            var newD = doctorDiagnosisDsBindingSource.AddNew() as DoctorDiagnosisD;
            newD.DiagnosisItem = diagItem;
            newD.DoctorDiagnosisM = DiagnosisM;
            //if (newD.DiagnosisItem.DiagnosisItem1.Name.ToLower().Contains("sign"))
            //    newD.Description = "بدون علامت";
            //else if (newD.DiagnosisItem.DiagnosisItem1.Name.ToLower().Contains("symptom"))
            //    newD.Description = "بدون نشانه";

            dc.DoctorDiagnosisDs.InsertOnSubmit(newD);
            //doctorDiagnosisDsGridControl.Focus();

            RefreshDiagItems();
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks > 1 && gridView3.GetRow(e.RowHandle) != null)
            {
                doctorDiagnosisDsBindingSource.EndEdit();
                dc.DoctorDiagnosisDs.DeleteOnSubmit(doctorDiagnosisDsBindingSource.Current as DoctorDiagnosisD);
                doctorDiagnosisDsBindingSource.RemoveCurrent();
                RefreshDiagItems();
            }
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            if (treeList1.CalcHitInfo(e.Location).Node != null)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void treeList1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void doctorDiagnosisDsGridControl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            MainModule.GridViewRightToLeft(sender, e);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView3.SetFocusedRowCellValue(colDescription, "");
        }


        private void repositoryItemMemoEdit1_Click(object sender, EventArgs e)
        {
            var edit = sender as MemoEdit;
            edit.SelectAll();
        }

        private void frmDoctorDiagnosis_Shown(object sender, EventArgs e)
        {
            treeList1.Focus();
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !(e.KeyCode == Keys.Alt || e.KeyCode == Keys.Control || e.KeyCode == Keys.Shift))
                AddNode(treeList1.FocusedNode);          
        }
    }
}