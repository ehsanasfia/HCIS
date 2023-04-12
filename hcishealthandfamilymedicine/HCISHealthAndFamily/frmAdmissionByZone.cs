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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class frmAdmissionByZone : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        IMPHOClassesDataContext im = new IMPHOClassesDataContext();

        List<Tbl_ValidCenterZone> lstValidZones = new List<Tbl_ValidCenterZone>();
        List<Tbl_ValidCenter> lstValidCenters = new List<Tbl_ValidCenter>();

        public string NationalCode { get; set; }
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public frmAdmissionByZone()
        {
            InitializeComponent();
        }

        private void frmAdmissionByZone_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            lstValidZones = im.Tbl_ValidCenterZones.OrderBy(x => x.Name).ToList();
            lstValidCenters = im.Tbl_ValidCenters.ToList();

            tbl_ValidCenterZonesBindingSource.DataSource = lstValidZones;
        }

        private void slkCity_EditValueChanged(object sender, EventArgs e)
        {
            var cur = slkCity.EditValue as Tbl_ValidCenterZone;
            if (cur == null)
            {
                tbl_ValidCentersBindingSource.DataSource = null;
                return;
            }

            tbl_ValidCentersBindingSource.DataSource = lstValidCenters.Where(x => x.IDValidCenterZone == cur.IDValidCenterZone).OrderBy(x => x.Name).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var vl = slkCenter.EditValue as Tbl_ValidCenter;
                if (vl == null)
                {
                    MessageBox.Show("ابتدا منطقه درمانی را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                view_IMPHO_PersonsBindingSource.DataSource = dc.View_IMPHO_Persons
                    .Where(x => x.IDValidCenter == vl.IDValidCenter && x.NationalCode != null && x.NationalCode.Trim() != "" && x.PersonnelNo != null && x.PersonnelNo.Trim() != "" && x.PersonnelNo.Trim() != "0")
                    .OrderBy(x => x.PersonnelNo).ThenBy(x => x.NationalCode).ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var cur = view_IMPHO_PersonsBindingSource.Current as View_IMPHO_Person;
            if (cur == null)
            {
                MessageBox.Show("ابتدا بیمار را جستجو کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            NationalCode = cur.NationalCode;
            var frm = new frmOutDoor() { NationalCode = NationalCode };
            frm.Show();
            frm.brbOk.PerformClick();
            frm.Close();
            DialogResult = DialogResult.OK;
        }
    }
}