using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;
using HCISDefinitions.Forms;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgDoctorInsuranceForWP : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<DoctorInsurance> lstDI;
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        public dlgDoctorInsuranceForWP()
        {
            InitializeComponent();
        }
        List<Staff> lstDoc = new List<Staff>();
        private void dlgDoctorInsurance_Load(object sender, EventArgs e)
        {
            splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager.ClosingDelay = 500;

            if (lstDI == null)
                lstDI = new List<DoctorInsurance>();

            insuranceBindingSource.DataSource = dc.Insurances.Where(x => x.ParentID == null).OrderBy(c => c.Name).ToList();
            lstDoc = dc.Staffs.Where(x => x.UserType == "دکتر").OrderBy(c => c.Person.LastName).ToList();
            staffBindingSource.DataSource = lstDoc;
        }
  
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
              //  var ins = slkInsurance.EditValue as Insurance;
                var doc = staffBindingSource.Current as Staff;

                if (!lstDI.Any(x => x.Staff.ID == doc.ID))
                {
                    var DI = new DoctorInsurance()
                    {
                        StaffID = doc.ID,
                     //   InsuranceID = ins.ID,
                    };
                    dc.DoctorInsurances.InsertOnSubmit(DI);
                    dc.SubmitChanges();
                    
                    gridControl2.RefreshDataSource();
                }
                else
                    return;
            }
        }

        private void DeleteG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var DI = doctorInsuranceBindingSource.Current as DoctorInsurance;
            gridView2.DeleteSelectedRows();
            dc.DoctorInsurances.DeleteOnSubmit(DI);
            dc.SubmitChanges();
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!splashScreenManager.IsSplashFormVisible)
                splashScreenManager.ShowWaitForm();
            try
            {
                List<Staff> lstStaff = new List<Staff>();
                List<Insurance> lstInsurance = new List<Insurance>();
                foreach (var item in gridView2.GetSelectedRows())
                {
                    var Parentinsure = gridView2.GetRow(gridView2.GetRowHandle(item)) as Insurance;
                    lstInsurance.AddRange(dc.Insurances.Where(x => x.ParentID == Parentinsure.ID).ToList());
                }
                foreach (var item in gridView1.GetSelectedRows())
                {
                    lstStaff.Add(gridView1.GetRow(gridView1.GetRowHandle(item)) as Staff);
                }


                foreach (var item in lstInsurance)
                {

                    foreach (var itm in lstStaff)
                    {
                        var DrInsurance = new DoctorInsurance();
                        DrInsurance.InsuranceID = item.ID;
                        DrInsurance.StaffID = itm.ID;
                        var Exist = dc.DoctorInsurances.FirstOrDefault(x => x.InsuranceID == item.ID && x.StaffID == itm.ID);
                        if (Exist != null)
                            continue;
                        else
                            dc.DoctorInsurances.InsertOnSubmit(DrInsurance);
                    }
                }
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (splashScreenManager.IsSplashFormVisible)
                    splashScreenManager.CloseWaitForm();
            }

        }
    }
}