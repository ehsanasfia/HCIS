using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISOnCall.Data;

namespace HCISOnCall.Forms
{
    public partial class frmHead : DevExpress.XtraEditors.XtraForm
    {
        HCISOnCallDataContext dc = new HCISOnCallDataContext();

        public frmHead()
        {
            InitializeComponent();
        }

        private void frmHead_Load(object sender, EventArgs e)
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            vwSecUserAppBindingSource.DataSource = dc.VwUserIDNames.ToList();
            GetData();
        }

        private void GetData()
        {
            specialityBindingSource.DataSource = dc.Specialities.ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var u = slkGroupName.EditValue as Speciality;
            if (u == null)
            {
                MessageBox.Show("تخصص را انتخاب کنید.");
                return;
            }

            var user = slkGroupHead.EditValue as Staff;
            if (user == null)
            {
                MessageBox.Show("مسئول را انتخاب کنید.");
                return;
            }

            u.HeadUserID = user.UserID;

            dc.SubmitChanges();

            GetData();

            //     lkpHeadName.Text = " ";
            //    txtGroup.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");
        }

        private void slkGroupName_EditValueChanged(object sender, EventArgs e)
        {
            var spc = slkGroupName.EditValue as Speciality;
            if (spc == null)
            {
                personBindingSource.DataSource = null;
                return;
            }

            int a = spc.ID;

            var qq = from pp in dc.Staffs
                     where pp.SpecialityID == a
                     select pp.Person;
            personBindingSource.DataSource = qq.ToList();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}