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
using ONCall.Data;

namespace ONCall.Forms
{
    public partial class frmHead : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OncallDataClassesDataContext dc = new OncallDataClassesDataContext();
        
        public frmHead()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            var q = from p in dc.Specialities
                    select p;
            specialityBindingSource.DataSource = q;

            var qq = from pp in dc.vwSecUserApps
                     select pp;
            vwSecUserAppBindingSource.DataSource = qq;

            specialityBindingSource.DataSource = dc.Specialities.ToList();

            gridControl1.RefreshDataSource();
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Speciality u = new Speciality();

          
            u.HeadUserID = int.Parse(lkpHeadName.EditValue.ToString());

            dc.Specialities.InsertOnSubmit(u);
            dc.SubmitChanges();

            GetData();

       //     lkpHeadName.Text = " ";
        //    txtGroup.Text = " ";

            MessageBox.Show("اطلاعات با موفقیت ثبت گردید", "توجه");

        }

        private void frmHead_Load(object sender, EventArgs e)
        {
            var q = from p in dc.Specialities
                    select p;
            specialityBindingSource.DataSource = q;

            //var qq = from pp in dc.vwSecUserApps
            //         select pp;
            //vwSecUserAppBindingSource.DataSource = qq;


            var c = from d in dc.vwSTPersons
                     where d.SpecialityID == MainModule.UserID
                     select  d.SpecialityID ;
        }

        private void txtGroup_EditValueChanged(object sender, EventArgs e)
        {

            //var sp = txtGroup.EditValue as Speciality;
            //if (sp == null)
            //{
            //    vwSecUserAppBindingSource.DataSource = null;
            //    return;
            //}
            if (!string.IsNullOrEmpty(txtGroup.EditValue.ToString()))
           {
                int a = int.Parse(txtGroup.EditValue.ToString());

                var qq = from pp in dc.Persons
                         where pp.Staff.SpecialityID == a
                         select pp;
                vwSecUserAppBindingSource1.DataSource = qq;
            }          
        }
    }
}