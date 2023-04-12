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
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgTest : DevExpress.XtraEditors.XtraForm
    {
        OMOApp.Data.HCISData.HCISClassesDataContext dc = new Data.HCISData.HCISClassesDataContext();
        OMOClassesDataContext om = new OMOClassesDataContext();
        List<Data.HCISData.FavoriteService> New = new List<Data.HCISData.FavoriteService>();
        List<Data.HCISData.FavoriteService> all = new List<Data.HCISData.FavoriteService>();
        List<Data.HCISData.FavoriteService> isInDb = new List<Data.HCISData.FavoriteService>();
        List<Data.HCISData.FavoriteService> shouldDelete = new List<Data.HCISData.FavoriteService>();
        List<Data.HCISData.Service> lstServices;

        View_SecurityUser myUser;

        public dlgTest()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgTest_Load(object sender, EventArgs e)
        {
            myUser = om.View_SecurityUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationName == "OMOApp");
            var userID = myUser.UserID;
            all.AddRange(dc.FavoriteServices.Where(x => x.Service.CategoryID == (int)Category.آزمایش && x.UserID == myUser.UserID && x.Service.LaboratoryServiceDetail.Show == true));
            isInDb.AddRange(all);
            grdUseful.DataSource = all;
            lstServices = dc.Services.Where(x => x.CategoryID == (int)Category.آزمایش && x.LaboratoryServiceDetail.Show == true).OrderBy(x => x.LaboratoryServiceDetail.AbbreviationName).ToList();
            serviceBindingSource.DataSource = lstServices;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            shouldDelete.ForEach(x => { x.Service = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var srv in lstServices)
            {
                if (all.Any(x => x.ServiceID == srv.ID /* && x.StaffID == myStaffID*/))
                    continue;

                Data.HCISData.FavoriteService fs = isInDb.FirstOrDefault(x => x.ServiceID == srv.ID /* && x.StaffID == myStaffID */);
                if (fs == null)
                {
                    fs = new Data.HCISData.FavoriteService()
                    {
                        Service = srv,
                        //StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == myUser.UserID).ID
                        UserID = myUser.UserID,
                    };
                    New.Add(fs);
                }
                all.Add(fs);
            }
            grdUseful.RefreshDataSource();
        }

        private void add()
        {
            var current = serviceBindingSource.Current as Data.HCISData.Service;
            if (current == null)
                return;

            if (all.Any(x => x.ServiceID == current.ID))
            {
                MessageBox.Show("این آزمایش را قبلا انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            Data.HCISData.FavoriteService fs = isInDb.FirstOrDefault(x => x.ServiceID == current.ID /* && x.StaffID == myStaffID */);
            if (fs == null)
            {
                fs = new Data.HCISData.FavoriteService()
                {
                    Service = current,
                    //StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == myUser.UserID).ID
                    UserID = myUser.UserID,
                };
                New.Add(fs);
            }
            all.Add(fs);
            shouldDelete.RemoveAll(x => x.ServiceID == fs.ServiceID && x.UserID == fs.UserID);
            grdUseful.RefreshDataSource();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            shouldDelete.ForEach(x => { x.Service = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var fs in all)
            {
                if (isInDb.Any(x => x.ServiceID == fs.ServiceID /* && x.StaffID == myStaffID */))
                    shouldDelete.Add(fs);
            }
            all.Clear();
            New.Clear();
            grdTest2.RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fs = grdTest2.GetFocusedRow() as Data.HCISData.FavoriteService;
            if (fs == null)
                return;

            New.RemoveAll(x => x.ServiceID == fs.ServiceID && x.UserID == fs.UserID);
            if (isInDb.Any(x => x.ServiceID == fs.ServiceID /* && x.StaffID == myStaffID */))
                shouldDelete.Add(fs);
            grdTest2.DeleteSelectedRows(); // mosavi ast ba all.Remove(fs)
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (all == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                try
                {
                    dc.FavoriteServices.DeleteAllOnSubmit(shouldDelete);
                    dc.FavoriteServices.InsertAllOnSubmit(New);
                    dc.SubmitChanges();
                    MessageBox.Show("تغییرات با موفقیت ثبت  گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }

        private void grdTest2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnDelete_Click(null, null);
        }

        private void grdTest1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            add();
        }
    }
}