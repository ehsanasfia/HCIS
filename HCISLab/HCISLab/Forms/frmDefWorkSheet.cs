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
using HCISLab.Dialogs;
using HCISLab.Data;

namespace HCISLab.Forms
{
    public partial class frmDefWorksheet : DevExpress.XtraEditors.XtraForm
    {
        HCISLabClassesDataContext dc = new HCISLabClassesDataContext();
        bool firstLoad = true;

        public frmDefWorksheet()
        {
            InitializeComponent();
        }

        private void frmDefWorksheet_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {
                var lst = dc.LabWorksheets.OrderBy(x => x.Name).ToList();
                if (firstLoad)
                {
                    foreach (var item in lst)
                    {
                        var wsServices = item.LabWorksheetServices;
                        item.Tests = "";
                        for (int i = 0; i < wsServices.Count; i++)
                        {
                            var srv = wsServices.ElementAt(i);
                            item.Tests += srv.Service.LaboratoryServiceDetail == null ? (srv.Service.Name_En ?? srv.Service.Name) : srv.Service.LaboratoryServiceDetail.AbbreviationName + "";
                            if (i != wsServices.Count - 1)
                            {
                                item.Tests += " و ";
                            }
                        }
                    }
                    firstLoad = false;
                }
                labWorksheetsBindingSource.DataSource = lst;
                grdWorksheet.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dlg = new dlgDefWorksheet() { dc = dc };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dlg.lstWS.ForEach(x =>
                    {
                        x.LabWorksheet = dlg.EditingWorksheet;
                    });
                    dlg.EditingWorksheet.LabWorksheetServices.AddRange(dlg.lstWS);

                    dc.LabWorksheets.InsertOnSubmit(dlg.EditingWorksheet);
                    dc.SubmitChanges();

                    var wsServices = dlg.EditingWorksheet.LabWorksheetServices;
                    dlg.EditingWorksheet.Tests = "";
                    for (int i = 0; i < wsServices.Count; i++)
                    {
                        var srv = wsServices.ElementAt(i);
                        dlg.EditingWorksheet.Tests += srv.Service.LaboratoryServiceDetail == null ? (srv.Service.Name_En ?? srv.Service.Name) : srv.Service.LaboratoryServiceDetail.AbbreviationName + "";
                        if (i != wsServices.Count - 1)
                        {
                            dlg.EditingWorksheet.Tests += " و ";
                        }
                    }

                    GetData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var cur = labWorksheetsBindingSource.Current as LabWorksheet;
                if (cur == null)
                {
                    MessageBox.Show("ابتدا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                var dlg = new dlgDefWorksheet() { dc = dc, EditingWorksheet = cur };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dlg.EditingWorksheet.LabWorksheetServices.Clear();
                    dc.LabWorksheetServices.DeleteAllOnSubmit(dc.LabWorksheetServices.Where(x => x.LabWorksheetID == dlg.EditingWorksheet.ID));

                    dlg.lstWS.ForEach(x =>
                    {
                        x.LabWorksheet = dlg.EditingWorksheet;
                    });
                    
                    dlg.EditingWorksheet.LabWorksheetServices.AddRange(dlg.lstWS);
                    dc.LabWorksheetServices.InsertAllOnSubmit(dlg.lstWS);
                    dc.SubmitChanges();

                    var wsServices = dlg.EditingWorksheet.LabWorksheetServices;
                    dlg.EditingWorksheet.Tests = "";
                    for (int i = 0; i < wsServices.Count; i++)
                    {
                        var srv = wsServices.ElementAt(i);
                        dlg.EditingWorksheet.Tests += srv.Service.LaboratoryServiceDetail == null ? (srv.Service.Name_En ?? srv.Service.Name) : srv.Service.LaboratoryServiceDetail.AbbreviationName + "";
                        if (i != wsServices.Count - 1)
                        {
                            dlg.EditingWorksheet.Tests += " و ";
                        }
                    }

                    GetData();
                }
                else
                {
                    if (dlg.EditingWorksheet != null)
                        dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.EditingWorksheet);
                    dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, dlg.lstWS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var cur = labWorksheetsBindingSource.Current as LabWorksheet;
                if (cur == null)
                {
                    MessageBox.Show("ابتدا یک مورد را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                if (MessageBox.Show("آیا از حذف اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                    return;

                var lst = cur.LabWorksheetServices.ToList();
                lst.ForEach(x =>
                {
                    x.Service = null;
                    x.LabWorksheet = null;
                });
                cur.LabWorksheetServices.Clear();
                dc.LabWorksheetServices.DeleteAllOnSubmit(dc.LabWorksheetServices.Where(x => x.LabWorksheetID == cur.ID));
                dc.LabWorksheets.DeleteOnSubmit(cur);
                dc.SubmitChanges();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}