﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data;
using OMOApp.Dialogs;

namespace OMOApp.Forms
{
    public partial class frmSystemDefinitions : DevExpress.XtraEditors.XtraForm
    {
     OMOClassesDataContext db = new OMOClassesDataContext();
        public frmSystemDefinitions()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard       
        //    stiReport1.StoreImagesInResources = false;

        }
        static public Definition DefinationField;
        private void GetData()
        {
            try
            {


                gridView1.CloseEditor();
                grdDefinition.RefreshDataSource();

                definitionBindingSource.DataSource = db.Definitions.Where(c => c.ParentID == DefinationField.ID);

                if (definitionBindingSource.Count == 0)
                    btnEdit.Enabled = btnRemove.Enabled = btnPrint.Enabled = false;
                else
                    btnEdit.Enabled = btnRemove.Enabled = btnPrint.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dialogs.dlgNewSystemDefinitions dlg = new Dialogs.dlgNewSystemDefinitions()
            {
                db = db,
                Text = "جدید"
            };
            
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                GetData();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Definition = definitionBindingSource.Current as Definition;
            var dlg = new dlgNewSystemDefinitions()
            {
                db = db,
                ObjDef = Definition
            };
            dlg.Text = "ویرایش";
            dlg.ShowDialog();

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmSystemDefinitions_Load(object sender, EventArgs e)
        {
            if (definitionBindingSource.Count == 0)
                btnEdit.Enabled = btnRemove.Enabled = btnPrint.Enabled = false;

            //var a = db.Definitions.Where(c => c.ParentID == null).FirstOrDefault();
            definitionBindingSource1.DataSource = db.Definitions.Where(c => c.ParentID == null);
            DefinationField = db.Definitions.FirstOrDefault(c => c.ParentID == null);
            lkpKindofDefinition.EditValue = DefinationField;
        }

        private void lkpKindofDefinition_EditValueChanged(object sender, EventArgs e)
        {
            DefinationField = lkpKindofDefinition.EditValue as Definition;
            GetData();

        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Definition = new Definition();
            Definition = definitionBindingSource.Current as Definition;

            if (MessageBox.Show("آیا از حذف این رکورد اطمینان دارید؟\n اطلاعات قابل برگشت نمی باشد.", "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    db.Definitions.DeleteOnSubmit(Definition);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "خطا در ثبت تغییرات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }

            GetData();
        }

        void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.IsGetData)
            //    e.Value = e.ListSourceRowIndex + 1;
        }

        private void gridView1_CustomUnboundColumnData_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            if (e.Column.FieldName == "counter")
            {
                e.Value = (e.ListSourceRowIndex + 1).ToString();
            }


        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var mydata = from c in (IQueryable<Definition>)(definitionBindingSource.DataSource)
                         select new
                         {
                             c.Name
                         };
            //stireport1.regdata("mydata", mydata);
            //stireport1.compile();
            ////  stireport1.compiledreport.storeimagesinresources = false;
            //stireport1.compiledreport["datenow"] = classes.mainmodule.getpersiandate(datetime.now);
            //stireport1.compiledreport["definitiontype"] = lkpkindofdefinition.text;

            ////stireport1.design();
            ////stireport1.compiledreport.design();
            //stireport1.compiledreport.show();

        }

        private void biHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var str = Application.StartupPath;
            System.Diagnostics.Process.Start(str + "\\Resources\\htarifsystem.pdf");
        }
    }
}