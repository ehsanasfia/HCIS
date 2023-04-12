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
using HCISSpecialist.Data;

namespace HCISSpecialist.Dialogs
{
    public partial class dlgUsefulservice : DevExpress.XtraEditors.XtraForm
    {
        HCISSpecialistClassesDataContext dc = new HCISSpecialistClassesDataContext();
        List<FavoriteService> New = new List<FavoriteService>();
        List<FavoriteService> all = new List<FavoriteService>();
        List<FavoriteService> isInDb = new List<FavoriteService>();

        List<FavoriteService> shouldDelete = new List<FavoriteService>();
        List<Service> lstServices;
        public dlgUsefulservice()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgUsefulservice_Load(object sender, EventArgs e)
        {
            if (rdgType.SelectedIndex == 0)
            {
                int user;
                using (var sq = new SeqdbmlDataContext())
                {
                    user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
                }
                var myStaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID;
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "رادیوگرافی").ToList();
                all.AddRange(dc.FavoriteServices.Where(x => x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID));
                isInDb.AddRange(all);
                rdgType_SelectedIndexChanged(null, null);
            }
        }

        private void rdgType_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdgType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int user;
            using (var sq = new SeqdbmlDataContext())
            {
                user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            }
            var myStaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID;
            if (rdgType.SelectedIndex == 0)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "رادیوگرافی");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "رادیوگرافی" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();
            }
            else if (rdgType.SelectedIndex == 1)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "سونوگرافی");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "سونوگرافی" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();
            }
            else if (rdgType.SelectedIndex == 2)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "MRI");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "MRI" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();

            }
            else if (rdgType.SelectedIndex == 3)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "CT");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "CT" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();

            }
            else if (rdgType.SelectedIndex == 4)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "سنگ شکن");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "سنگ شکن" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();

            }
            else if (rdgType.SelectedIndex == 5)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "EKG");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "EKG" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();

            }
            else if (rdgType.SelectedIndex == 6)
            {
                serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.خدمات_تشخیصی && x.Service1.Name == "EMG");
                favoriteServicesBindingSource.DataSource = all.Where(x => x.Service.Service1.Name == "EMG" && x.Service.ServiceCategory.ID == (int)Category.خدمات_تشخیصی && x.StaffID == myStaffID);
                grdUseful.RefreshDataSource();

            }

        }

        private void add()
        {
            int user;
            using (var sq = new SeqdbmlDataContext())
            {
                user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            }
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;
            if (all.Any(x => x.ServiceID == current.ID))
            {
                MessageBox.Show("این خدمات  را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            FavoriteService fs = isInDb.FirstOrDefault(x => x.ServiceID == current.ID /* && x.StaffID == myStaffID */);
            if (fs == null)
            {
                fs = new FavoriteService()
                {
                    Service = current,
                    StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID
                };
                New.Add(fs);
            }
            all.Add(fs);
            shouldDelete.RemoveAll(x => x.ServiceID == fs.ServiceID && x.StaffID == fs.StaffID);
            rdgType_SelectedIndexChanged(null, null);
            grdUseful.RefreshDataSource();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fs = gridView2.GetFocusedRow() as FavoriteService;
            if (fs == null)
                return;

            int user;
            using (var sq = new SeqdbmlDataContext())
            {
                user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            }
            var myStaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID;
            New.RemoveAll(x => x.ServiceID == fs.ServiceID && x.StaffID == fs.StaffID);
            if (isInDb.Any(x => x.ServiceID == fs.ServiceID && x.StaffID == myStaffID))
                shouldDelete.Add(fs);
            gridView2.DeleteSelectedRows(); // mosavi ast ba all.Remove(fs)
        }

        private void grdUseful_Click(object sender, EventArgs e)
        {
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            int user;
            using (var sq = new SeqdbmlDataContext())
            {
                user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            }
            var myStaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID;
            shouldDelete.ForEach(x => { x.Service = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var srv in lstServices)
            {
                if (all.Any(x => x.ServiceID == srv.ID && x.StaffID == myStaffID))
                    continue;

                FavoriteService fs = isInDb.FirstOrDefault(x => x.ServiceID == srv.ID  && x.StaffID == myStaffID);
                if (fs == null)
                {
                    fs = new FavoriteService()
                    {
                        Service = srv
                    };
                    New.Add(fs);
                }
                all.Add(fs);
            }
            grdUseful.RefreshDataSource();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            int user;
            using (var sq = new SeqdbmlDataContext())
            {
                user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            }
            var myStaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID;
            shouldDelete.ForEach(x => { x.Service = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var fs in all)
            {
                if (isInDb.Any(x => x.ServiceID == fs.ServiceID  && x.StaffID == myStaffID ))
                    shouldDelete.Add(fs);
            }
            all.Clear();
            New.Clear();
            gridView2.RefreshData();
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            add();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnDelete_Click(null, null);
        }
    }
}