using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISInsurance.Data;

namespace HCISInsurance.Dialogs
{
    public partial class dlgInsuranceServiceDef : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;

        public dlgInsuranceServiceDef()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            serviceCategoryBindingSource.DataSource = dc.ServiceCategories.ToList();
            insuranceBindingSource.DataSource = dc.Insurances.Where(x=>x.ParentID!=null).ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x=>!(x.CategoryID==(int)Category.دارو || x.CategoryID==15 || x.CategoryID == 21 || x.CategoryID == 25 || x.CategoryID == 18)).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgInsuranceServiceDef_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(Forms.WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;

            GetData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtPercentage.Text))
            {
                MessageBox.Show("لطفا درصد را وارد کنید.");
                return;
            }
            if (!splashScreenManager2.IsSplashFormVisible)
                splashScreenManager2.ShowWaitForm();
            try
            {
                List<Service> lstService = new List<Service>();
                List<Insurance> lstIns = new List<Insurance>();
                foreach (var item in gridView1.GetSelectedRows())
                {
                    lstService.Add(gridView1.GetRow(item) as Service);
                }
                foreach (var ins in gridView2.GetSelectedRows())
                {
                    lstIns.Add(gridView2.GetRow(ins) as Insurance);
                }

                List<ServiceInsuranc> lst = new List<ServiceInsuranc>();
                foreach (var ins in lstIns)
                {
                    lst.AddRange(dc.ServiceInsurancs.Where(x => x.Insurance == ins).ToList());
                }
                foreach (var srv in lstService)
                    foreach (var ins in lstIns)
                    {
                        var Current = lst.FirstOrDefault(x => x.Insurance == ins && x.Service == srv);
                        if (Current == null)
                        {
                            var ServiceInsurance = new ServiceInsuranc()
                            {
                                InsuranceCode = ins.ID,
                                ServiceCode = srv.ID,
                                Perecentge = double.Parse(txtPercentage.Text),
                                Date = MainModule.GetPersianDate(DateTime.Now),
                                Time = DateTime.Now.ToString("HH:mm"),
                            };
                            dc.ServiceInsurancs.InsertOnSubmit(ServiceInsurance);
                        }
                        else
                        {
                            Current.Perecentge = double.Parse(txtPercentage.Text);
                            Current.Date = MainModule.GetPersianDate(DateTime.Now);
                            Current.Time = DateTime.Now.ToString("HH:mm");
                        }
                    }

                dc.SubmitChanges();
                MessageBox.Show("با موفقیت ثبت شد");
            }
            catch (Exception ex)
            { }
            finally
            {
                if (splashScreenManager2.IsSplashFormVisible)
                    splashScreenManager2.CloseWaitForm();

            }
        }
    }
}