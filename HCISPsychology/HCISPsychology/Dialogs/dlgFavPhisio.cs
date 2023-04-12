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
using HCISPsychology.Data;

namespace HCISPsychology.Dialogs
{
    public partial class dlgFavPhisio : DevExpress.XtraEditors.XtraForm
    {
        HCISPsychologyClassesDataContext dc = new HCISPsychologyClassesDataContext();
        SeqdbmlDataContext sq = new SeqdbmlDataContext();
        List<FavoriteService> New = new List<FavoriteService>();
        List<FavoriteService> all = new List<FavoriteService>();
        List<FavoriteService> isInDb = new List<FavoriteService>();
        List<FavoriteService> shouldDelete = new List<FavoriteService>();
        List<Service> lstServices;

        public dlgFavPhisio()
        {
            InitializeComponent();
        }

        private void dlgDrug_Load(object sender, EventArgs e)
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            all.AddRange(dc.FavoriteServices.Where(x => x.Service.CategoryID == (int)Category.فیزیوتراپی && x.Staff.UserID == user));
            isInDb.AddRange(all);
            grdControl2.DataSource = all;
            lstServices = dc.Services.Where(x => x.CategoryID == (int)Category.فیزیوتراپی).ToList();
            serviceBindingSource.DataSource = lstServices;
        }

        private void add()
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;

            if (all.Any(x => x.ServiceID == current.ID))
            {
                MessageBox.Show("این دارو را قبلا انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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
            grdControl2.RefreshDataSource();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            shouldDelete.ForEach(x => { x.Service = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var srv in lstServices)
            {
                if (all.Any(x => x.ServiceID == srv.ID /* && x.StaffID == myStaffID*/))
                    continue;

                FavoriteService fs = isInDb.FirstOrDefault(x => x.ServiceID == srv.ID /* && x.StaffID == myStaffID */);
                if (fs == null)
                {
                    fs = new FavoriteService()
                    {
                        Service = srv,
                        StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID
                    };
                    New.Add(fs);
                }
                all.Add(fs);
            }
            grdControl2.RefreshDataSource();
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
            gridView2.RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fs = gridView2.GetFocusedRow() as FavoriteService;
            if (fs == null)
                return;
            New.RemoveAll(x => x.ServiceID == fs.ServiceID && x.StaffID == fs.StaffID);
            if (isInDb.Any(x => x.ServiceID == fs.ServiceID /* && x.StaffID == myStaffID */))
                shouldDelete.Add(fs);
            gridView2.DeleteSelectedRows(); // mosavi ast ba all.Remove(fs)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
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