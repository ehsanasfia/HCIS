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
    public partial class dlgParaService : DevExpress.XtraEditors.XtraForm
    {
        public HCISSpecialistClassesDataContext dc { get; set; }
        public GivenServiceM checkup { get; set; }
        public GivenServiceM ObjectGSM { get; set; }

        public dlgParaService()
        {
            InitializeComponent();
        }

        private void dlgParaService_Load(object sender, EventArgs e)
        {
            servicesBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.پاراکلینیکی);
            givenServiceDsBindingSourceSecondTab.DataSource = dc.GivenServiceDs.Where(x => x.Service.CategoryID == (int)Category.پاراکلینیکی && x.Payed == true && x.GivenServiceM != null && x.GivenServiceM.Person == checkup.Person && x.GivenServiceM.Staff == checkup.Staff && x.GivenServiceM.ParentID == checkup.ID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var srv = lkpServices.EditValue as Service;
            if(srv == null)
            {
                MessageBox.Show("لطفا خدمت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            if(ObjectGSM == null)
            {
                ObjectGSM = new GivenServiceM();
            }

            ObjectGSM.ServiceCategoryID = (int)Category.پاراکلینیکی;
            ObjectGSM.Person = checkup.Person;
            ObjectGSM.Staff = checkup.Staff;
            ObjectGSM.GivenServiceM1 = checkup;
            ObjectGSM.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSM.LastModificationTime = DateTime.Now.ToString("HH:mm");
            ObjectGSM.InsuranceID = checkup.InsuranceID;
            ObjectGSM.RequestStaffID = checkup.RequestStaffID;
            ObjectGSM.RequestDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSM.RequestTime = DateTime.Now.ToString("HH:mm");
            ObjectGSM.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectGSM.CreationTime = DateTime.Now.ToString("HH:mm");
            
            //ObjectGSM.Date = dtpDate.Date;
            //ObjectGSM.Time = txtClock.Text.Trim();
            var gsd = new GivenServiceD();
            gsd.Service = srv;
            gsd.GivenServiceM = ObjectGSM;
            ObjectGSM.GivenServiceDs.Add(gsd);
            givenServiceDsBindingSource.DataSource = ObjectGSM.GivenServiceDs.ToList();
            gridControl1.RefreshDataSource();
            //dc.GivenServiceMs.InsertOnSubmit(ObjectGSM);
            //dc.GivenServiceDs.InsertAllOnSubmit(ObjectGSM.GivenServiceDs);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var gsd = e.Row as GivenServiceD;
            if(gsd != null)
            {
                gsd.GivenServiceM.Date = MainModule.GetPersianDate(DateTime.Now);
            }
        }
    }
}