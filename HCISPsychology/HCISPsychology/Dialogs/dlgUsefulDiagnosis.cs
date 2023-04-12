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
    public partial class dlgUsefulDiagnosis : DevExpress.XtraEditors.XtraForm
    {
        HCISPsychologyClassesDataContext dc = new HCISPsychologyClassesDataContext();
        public SeqdbmlDataContext sq = new SeqdbmlDataContext();
        List<FavoriteICD10> New = new List<FavoriteICD10>();
        List<FavoriteICD10> all = new List<FavoriteICD10>();
        List<FavoriteICD10> isInDb = new List<FavoriteICD10>();

        List<FavoriteICD10> shouldDelete = new List<FavoriteICD10>();
        List<ICD10> lstServices;
        
        public dlgUsefulDiagnosis()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add()
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            var current = serviceBindingSource.Current as ICD10;
            if (current == null)
                return;

            if (all.Any(x => x.ICD10ID == current.ID))
            {
                MessageBox.Show("این دارو را قبلا انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            FavoriteICD10 fs = isInDb.FirstOrDefault(x => x.ICD10ID == current.ID /* && x.StaffID == myStaffID */);
            if (fs == null)
            {
                fs = new FavoriteICD10()
                {
                    ICD10 = current,
                    StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID
                };
                New.Add(fs);
            }
            all.Add(fs);
            shouldDelete.RemoveAll(x => x.ICD10ID == fs.ICD10ID && x.StaffID == fs.StaffID);

            grdUseful.RefreshDataSource();
        }


        private void dlgUsefulDiagnosis_Load(object sender, EventArgs e)
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            all.AddRange(dc.FavoriteICD10s.Where(x => x.Staff.UserID == user));
            grdUseful.DataSource = all;
            serviceBindingSource.DataSource = dc.ICD10s.ToList();
            gridView1.RefreshData();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var user = sq.tblUsers.FirstOrDefault(x => x.UserName == MainModule.UserName && x.ApplicationID == 3087).UserID;
            shouldDelete.ForEach(x => { x.ICD10ID = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var srv in lstServices)
            {
                if (all.Any(x => x.ICD10ID == srv.ID /* && x.StaffID == myStaffID*/))
                    continue;

                FavoriteICD10 fs = isInDb.FirstOrDefault(x => x.ICD10ID == srv.ID /* && x.StaffID == myStaffID */);
                if (fs == null)
                {
                    fs = new FavoriteICD10()
                    {
                        ICD10 = srv,
                        StaffID = dc.Staffs.FirstOrDefault(x => x.UserID == user).ID
                    };
                    New.Add(fs);
                }
                all.Add(fs);
            }
            grdUseful.RefreshDataSource();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            shouldDelete.ForEach(x => { x.ICD10 = null; x.Staff = null; });
            shouldDelete.Clear();
            foreach (var fs in all)
            {
                if (isInDb.Any(x => x.ICD10ID == fs.ICD10ID /* && x.StaffID == myStaffID */))
                    shouldDelete.Add(fs);
            }
            all.Clear();
            New.Clear();
            gridView2.RefreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fs = gridView2.GetFocusedRow() as FavoriteICD10;
            if (fs == null)
                return;

            New.RemoveAll(x => x.ICD10ID == fs.ICD10ID && x.StaffID == fs.StaffID);
            if (isInDb.Any(x => x.ICD10ID == fs.ICD10ID /* && x.StaffID == myStaffID */))
                shouldDelete.Add(fs);
            gridView2.DeleteSelectedRows(); // mosavi ast ba all.Remove(fs)
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
                    dc.FavoriteICD10s.DeleteAllOnSubmit(shouldDelete);
                    dc.FavoriteICD10s.InsertAllOnSubmit(New);
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

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            add();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            btnDelete_Click(null, null);
        }
    }
}