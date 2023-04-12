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
using SecurityLoginsAndAccessControl;

namespace OMOApp.Dialogs
{
    public partial class frmDocumentResult : BaseForm
    {
        public ViewType FormType;

        public Document CurrentDocument { get; set; }

        public DocumentResult CurrentResult { get; set; }
        IMClassesDataContext dc = new IMClassesDataContext();

        public frmDocumentResult(Document doc)
        {
            InitializeComponent();
            CurrentDocument = dc.Documents.FirstOrDefault(c => c.ID == doc.ID);
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
                documentResultBindingSource.EndEdit();
                Validate();
                if (dxErrorProvider1.HasErrors)
                {
                    throw new Exception("موارد الزامی در فرم وارد نشده اند\n لطفاً ابتدا آن ها را وارد نمایید و سپس مجدداً سعی کنید");
                }
                if (MainModule.DataContextChanged(dc))
                {
                    if (FormType == ViewType.Edit)
                    {
                        var CurrentR = documentResultBindingSource.Current as DocumentResult;
                        CurrentR.ModificationDate = MainModule.GetPersianDate(DateTime.Now);
                        CurrentR.ModificationUser = MainModule.UserID;
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

        private void frmDocumentResult_Load(object sender, EventArgs e)
        {
            this.FormType = CurrentDocument.DocumentResults.Any() ? ViewType.Edit : ViewType.New;


            var today = MainModule.GetPersianDate(DateTime.Now);
            var now = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");


            workLimitConditionBindingSource1.DataSource = dc.WorkLimitConditions;
            evaluationResultBindingSource.DataSource = dc.EvaluationResults;

            switch (FormType)
            {
                case ViewType.New:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    var res = new DocumentResult()
                    {

                        Deleted = false,
                        CreationUser = MainModule.UserID,
                        CreationDate = today,
                        DoctorID = MainModule.UserID,
                        EvaluationResult = dc.EvaluationResults.First(),
                        NextReferDate = MainModule.GetPersianDate(MainModule.GetDateFromPersianString(today).AddYears(1)),
                    };
                    CurrentDocument.DocumentResults.Add(res);
                    CurrentResult = res;
                    
                    break;
                case ViewType.View:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    CurrentResult = CurrentDocument.DocumentResults.First();

                    MainModule.MakeReadOnly(layoutControlGroup1);
                    break;
                case ViewType.Edit:
                    CurrentDocument = dc.Documents.Single(c => c == CurrentDocument);
                    CurrentResult = CurrentDocument.DocumentResults.First();
                    break;
                default:
                    break;
            }
            documentResultBindingSource.DataSource = CurrentResult;
            documentResultRecommendationBindingSource.DataSource = CurrentResult.DocumentResultRecommendations.Where(c => c.Definition.ParentID == 2).ToList();
            documentResultRecommendationBindingSource1.DataSource = CurrentResult.DocumentResultRecommendations.Where(c => c.Definition.ParentID == 1).ToList();

            var secDC = new SecurityControlClassesDataContext();
            var creator = secDC.tblUsers.FirstOrDefault(c => c.UserID == CurrentResult.CreationUser);
            doctorIDLookUpEdit.EditValue = creator == null ? "" : creator.FirstName + " " + creator.LastName;
            var modificator = secDC.tblUsers.FirstOrDefault(c => c.UserID == CurrentResult.ModificationUser);
            txtLastEditor.EditValue = modificator == null ? "" : modificator.FirstName + " " + modificator.LastName;
            
            
            RefreshTreeData();
            RefreshTreeData2();
            RefreshTreeData3();
        }

        private void RefreshTreeData()
        {

            documentResultBindingSource.EndEdit();
            documentResultConditionsBindingSource.EndEdit();

            var CurrentM = documentResultBindingSource.Current as DocumentResult;
            if (CurrentM != null)
            {
                var items = CurrentM.DocumentResultConditions.Select(c => c.WorkLimitCondition.ID).Distinct();
                workLimitConditionBindingSource.DataSource = dc.WorkLimitConditions.Except(dc.WorkLimitConditions.Where(c => items.Contains(c.ID)));
            }
            else
            {
                workLimitConditionBindingSource.DataSource = dc.WorkLimitConditions;
            }

            treeList1.ExpandAll();
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            var node = treeList1.CalcHitInfo(e.Location).Node;
            if (node != null)
            {
                var workLimit = workLimitConditionBindingSource.Current as WorkLimitCondition;

                if (workLimit.WorkLimitConditions.Any())
                {

                    node.ExpandAll();
                    return;
                }

                documentResultConditionsBindingSource.EndEdit();
                documentResultBindingSource.EndEdit();

                var CurrentM = documentResultBindingSource.Current as DocumentResult;
                var newD = documentResultConditionsBindingSource.AddNew() as DocumentResultCondition;
                newD.WorkLimitCondition = workLimit;
                newD.DocumentResult = CurrentM;
                
                
                dc.DocumentResultConditions.InsertOnSubmit(newD);
                documentResultConditionsGridControl.Focus();

                RefreshTreeData();
            }
        }

        private void treeList1_MouseMove(object sender, MouseEventArgs e)
        {
            var tl = treeList1 as DevExpress.XtraTreeList.TreeList;
            if (tl == null)
                return;

            if (tl.CalcHitInfo(e.Location).Node != null)
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks > 1 && gridView1.GetRow(e.RowHandle) != null)
            {
                documentResultBindingSource.EndEdit();
                dc.DocumentResultConditions.DeleteOnSubmit(documentResultConditionsBindingSource.Current as DocumentResultCondition);
                documentResultConditionsBindingSource.RemoveCurrent();
                RefreshTreeData();
            }
        }

        private void documentResultConditionsGridControl_KeyDown(object sender, KeyEventArgs e)
        {
            MainModule.GridViewRightToLeft(sender, e);
        }

        private void nameTextEdit_Validating(object sender, CancelEventArgs e)
        {
            if (((DevExpress.XtraEditors.BaseEdit)sender).EditValue == DBNull.Value)
            {
                e.Cancel = true;
            }
            else
                try
                {
                    if (((DevExpress.XtraEditors.BaseEdit)sender).EditValue.ToString().Length == 0 || (int)((DevExpress.XtraEditors.BaseEdit)sender).EditValue == 0)
                        e.Cancel = true;
                }
                catch (Exception) { }

            if (e.Cancel)
            {
                e.Cancel = false;
                dxErrorProvider1.SetError((DevExpress.XtraEditors.BaseEdit)sender, "نمیتواند خالی باشد\nلطفاً مقدار را وارد نمایید", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
            {
                dxErrorProvider1.SetError((DevExpress.XtraEditors.BaseEdit)sender, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            }
        }

        private void treeList2_MouseClick(object sender, MouseEventArgs e)
        {
            var node = treeList2.CalcHitInfo(e.Location).Node;
            if (node != null)
            {
                var def = definitionBindingSource.Current as Definition;

                if (def.Definitions.Any())
                {
                    node.ExpandAll();
                    return;
                }

                documentResultRecommendationBindingSource.EndEdit();
                documentResultBindingSource.EndEdit();

                var CurrentM = documentResultBindingSource.Current as DocumentResult;
                var newD =  new DocumentResultRecommendation();
                newD.Definition = def;
                newD.DocumentResult = CurrentM;
                CurrentM.DocumentResultRecommendations.Add(newD);
                dc.DocumentResultRecommendations.InsertOnSubmit(newD);
                gridControl1.Focus();

                documentResultRecommendationBindingSource.DataSource = CurrentResult.DocumentResultRecommendations.Where(c => c.Definition.ParentID == 2).ToList();

                RefreshTreeData2();
            }
        }

        private void RefreshTreeData2()
        {
            documentResultBindingSource.EndEdit();
            documentResultRecommendationBindingSource.EndEdit();

            var CurrentM = documentResultBindingSource.Current as DocumentResult;
            if (CurrentM != null)
            {
                var items = CurrentM.DocumentResultRecommendations.Select(c => c.Definition.ID).Distinct();
                definitionBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 2).Except(dc.Definitions.Where(c => items.Contains(c.ID)));
            }
            else
            {
                definitionBindingSource1.DataSource = dc.Definitions.Where(c => c.ParentID == 2);
            }

            treeList2.ExpandAll();
        }

        private void treeList3_MouseClick(object sender, MouseEventArgs e)
        {
            var node = treeList3.CalcHitInfo(e.Location).Node;
            if (node != null)
            {
                var def = definitionBindingSource1.Current as Definition;

                if (def.Definitions.Any())
                {
                    node.ExpandAll();
                    return;
                }

                documentResultRecommendationBindingSource1.EndEdit();
                documentResultBindingSource.EndEdit();

                var CurrentM = documentResultBindingSource.Current as DocumentResult;
                var newD = new DocumentResultRecommendation();
                newD.Definition = def;
                newD.DocumentResult = CurrentM;
                CurrentM.DocumentResultRecommendations.Add(newD);
                dc.DocumentResultRecommendations.InsertOnSubmit(newD);
                gridControl2.Focus();
                
                
                documentResultRecommendationBindingSource1.DataSource = CurrentResult.DocumentResultRecommendations.Where(c => c.Definition.ParentID == 1).ToList();

                RefreshTreeData3();
            }
        }

        private void RefreshTreeData3()
        {
            documentResultBindingSource.EndEdit();
            documentResultRecommendationBindingSource1.EndEdit();

            var CurrentM = documentResultBindingSource.Current as DocumentResult;
            if (CurrentM != null)
            {
                var items = CurrentM.DocumentResultRecommendations.Select(c => c.Definition.ID).Distinct();
                definitionBindingSource1.DataSource = dc.Definitions.Where(c => c.ParentID == 1).Except(dc.Definitions.Where(c => items.Contains(c.ID)));
            }
            else
            {
                definitionBindingSource1.DataSource = dc.Definitions.Where(c => c.ParentID == 1);
            }

            treeList3.ExpandAll();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks > 1 && gridView2.GetRow(e.RowHandle) != null)
            {
                documentResultBindingSource.EndEdit();
                var drr = documentResultRecommendationBindingSource.Current as DocumentResultRecommendation;
                CurrentResult.DocumentResultRecommendations.Remove(drr);
                dc.DocumentResultRecommendations.DeleteOnSubmit(drr);
                documentResultRecommendationBindingSource.RemoveCurrent();
                RefreshTreeData2();
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks > 1 && gridView3.GetRow(e.RowHandle) != null)
            {
                documentResultBindingSource.EndEdit();
                var drr = documentResultRecommendationBindingSource1.Current as DocumentResultRecommendation;
                CurrentResult.DocumentResultRecommendations.Remove(drr);
                dc.DocumentResultRecommendations.DeleteOnSubmit(drr);
                documentResultRecommendationBindingSource1.RemoveCurrent();
                RefreshTreeData3();
            }
        }
    }
}