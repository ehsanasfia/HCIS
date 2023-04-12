using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HCISLab.Data;

namespace HCISLab.Forms
{

    public partial class frmDefTests : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        public LaboratoryServiceDetail EditingTest { get; set; }
        public LabTestGroup EditingTestGroup { get; set; }
        public Service EditingService { get; set; }

        private int? FocusedLabTestGroupID;

        public frmDefTests()
        {
            InitializeComponent();
        }

        private void frmDefTests_Load(object sender, EventArgs e)
        {
            bbiCancel_ItemClick(null, null);
        }

        private void EndEdit()
        {
            ServiceBindingSource.EndEdit();
            LaboratoryServiceDetailBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();
                if (EditingService == null)
                {
                    EditingService = new Service();
                }
                if (EditingTest == null)
                {
                    EditingTest = new LaboratoryServiceDetail()
                    {
                        TestNo = 0,
                        TestType = "تست",
                        TestOnly = false,
                        Show = true
                    };
                }
                if (EditingTestGroup == null)
                {
                    EditingTestGroup = new LabTestGroup();
                }

                ServiceBindingSource.DataSource = EditingService;
                LaboratoryServiceDetailBindingSource.DataSource = EditingTest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                #region Old
                //if (EditingService != null)
                //{
                //    if (EditingService.ID == Guid.Empty || !dc.Services.Any(x => x.ID == EditingService.ID))
                //    {
                //        EditingService.CategoryID = null;
                //        EditingService.ServiceCategory = null;
                //        EditingService.LaboratoryServiceDetail = null;
                //        EditingService.Service1 = null;
                //        EditingService.ParentID = null;
                //        EditingService = null;
                //    }
                //    else
                //    {
                //        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingService);
                //    }
                //}
                //if (EditingTest != null)
                //{
                //    if (EditingTest.ID == Guid.Empty || !dc.LaboratoryServiceDetails.Any(x => x.ID == EditingTest.ID))
                //    {
                //        EditingTest.Service = null;
                //        EditingTest = null;
                //    }
                //    else
                //    {
                //        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingTest);
                //    }
                //}
                //if (EditingTestGroup != null)
                //{
                //    if (EditingTestGroup.ID == 0 || !dc.LabTestGroups.Any(x => x.ID == EditingTestGroup.ID))
                //    {
                //        EditingTest.Service = null;
                //        EditingTest = null;
                //    }
                //    else
                //    {
                //        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingTestGroup);
                //    }
                //}

                #endregion

                EditingService = null;
                EditingTest = null;
                EditingTestGroup = null;

                dc.Dispose();
                dc = new HCISLabClassesDataContext();

                var lst = dc.LabTestGroups.Where(x => x.Service != null && x.Service.LaboratoryServiceDetail != null).OrderBy(x => x.Service.LaboratoryServiceDetail.AbbreviationName).ToList();
                labTestGroupsBindingSource.DataSource = lst;
                gridControl1.RefreshDataSource();
                if (FocusedLabTestGroupID != null)
                {
                    var fcs = lst.FirstOrDefault(x => x.ID == FocusedLabTestGroupID);
                    if (fcs != null)
                    {
                        gridView1.FocusedRowHandle = gridView1.GetRowHandle(labTestGroupsBindingSource.IndexOf(fcs));

                        gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
                    }
                }

                var lstGroups = dc.LabGroups.OrderBy(x => x.GoupName).ToList();
                GroupServicesBindingSource.DataSource = lstGroups;
                //lkpGroup.EditValue = lstGroups.FirstOrDefault();
                lkpGroup_EditValueChanged(null, null);

                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void bbiOk_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (lkpChildGroup.EditValue == null)
                {
                    MessageBox.Show("لطفا گروه و زیرگروه را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (string.IsNullOrWhiteSpace(EditingService.Name))
                {
                    if (string.IsNullOrWhiteSpace(EditingTest.AbbreviationName))
                    {
                        MessageBox.Show("لطفا نام یا نام اختصاری آزمایش را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    else
                    {
                        EditingService.Name = EditingTest.AbbreviationName;
                    }
                }
                else if (string.IsNullOrWhiteSpace(EditingTest.AbbreviationName))
                {
                    if (string.IsNullOrWhiteSpace(EditingService.Name))
                    {
                        MessageBox.Show("لطفا نام یا نام اختصاری آزمایش را وارد کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        return;
                    }
                    else
                    {
                        EditingTest.AbbreviationName = EditingService.Name;
                    }
                }


                EditingTestGroup.LabSubGroup = lkpChildGroup.EditValue as LabSubGroup;
                EditingTestGroup.Service = EditingService;
                EndEdit();
                EditingService.CategoryID = (int)Category.آزمایش;

                if (EditingService.ID == Guid.Empty)
                {
                    EditingService.LaboratoryServiceDetail = EditingTest;
                    dc.Services.InsertOnSubmit(EditingService);
                }
                else if (!dc.LaboratoryServiceDetails.Any(x => x.ID == EditingService.ID))
                {
                    EditingTest.ID = EditingService.ID;
                    dc.LaboratoryServiceDetails.InsertOnSubmit(EditingTest);
                }
                dc.SubmitChanges();

                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                
                bbiCancel_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var ltg = labTestGroupsBindingSource.Current as LabTestGroup;
            if (ltg == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            FocusedLabTestGroupID = ltg.ID;

            if (EditingService != null)
            {
                if (EditingService.ID == Guid.Empty)
                {
                    EditingService.CategoryID = null;
                    EditingService.ServiceCategory = null;
                    EditingService.LaboratoryServiceDetail = null;
                    EditingService.Service1 = null;
                    EditingService.ParentID = null;
                    if (dc.GetChangeSet().Inserts.Contains(EditingService))
                        dc.Services.DeleteOnSubmit(EditingService);
                    EditingService = null;
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingService);
                }
            }
            if (EditingTest != null)
            {
                if (EditingTest.ID == Guid.Empty)
                {
                    EditingTest.Service = null;

                    if (dc.GetChangeSet().Inserts.Contains(EditingService))
                        dc.Services.DeleteOnSubmit(EditingService);
                    EditingTest = null;
                }
                else
                {
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, EditingTest);
                }
            }
            EditingService = null;
            EditingTest = null;

            if (ltg.LabSubGroup != null)
            {
                lkpGroup.EditValue = ltg.LabSubGroup.LabGroup;
                lkpChildGroup.EditValue = ltg.LabSubGroup;
            }

            EditingService = ltg.Service;
            EditingTest = ltg.Service.LaboratoryServiceDetail;
            EditingTestGroup = ltg;

            GetData();
        }

        private void lkpGroup_EditValueChanged(object sender, EventArgs e)
        {
            var gp = lkpGroup.EditValue as LabGroup;
            if (gp == null)
            {
                ChildGroupServiceBindingSource.DataSource = null;
                return;
            }

            var lst = dc.LabSubGroups.Where(x => x.LabGroupID == gp.ID).OrderBy(x => x.SubGroupName).ToList();
            ChildGroupServiceBindingSource.DataSource = lst;
            //if (EditingService != null)
            //    EditingService.Service1 = lst.FirstOrDefault();
            //else
                //lkpChildGroup.EditValue = lst.FirstOrDefault();
        }

        private void btnRemove_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var srv = labTestGroupsBindingSource.Current as Service;
                if (srv == null)
                {
                    MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (srv.Agendas.Any() || srv.GivenServiceDs.Any() || srv.Services.Any() || srv.Tariffs.Any())
                {
                    MessageBox.Show("برای این آزمایش اطلاعات وارد شده است و قابل حذف نیست.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;
                if (srv.LaboratoryServiceDetail != null)
                    dc.LaboratoryServiceDetails.DeleteOnSubmit(srv.LaboratoryServiceDetail);
                dc.Services.DeleteOnSubmit(srv);
                dc.SubmitChanges();

                MessageBox.Show("آزمایش انتخاب شده با موفقیت حذف شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                var cur = labTestGroupsBindingSource.Current as LabTestGroup;
                FocusedLabTestGroupID = cur.ID;
                bbiCancel_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در حذف اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;

            btnEdit_ButtonClick(null, null);
        }
    }
}