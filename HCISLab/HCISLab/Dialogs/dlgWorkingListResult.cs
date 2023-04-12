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
using HCISLab.Data;

namespace HCISLab.Dialogs
{
    public partial class dlgWorkingListResult : DevExpress.XtraEditors.XtraForm
    {
        public HCISLabClassesDataContext dc { get; set; }
        public List<Service> selectedTests { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool EMG { get; set; }
        public int? FromSN { get; set; }
        public int? ToSN { get; set; }
        public int? FromDN { get; set; }
        public int? ToDN { get; set; }
        public bool OnlyNotConfirmed { get; set; }

        List<GivenServiceD> GSDList = new List<GivenServiceD>();
        public dlgWorkingListResult()
        {
            InitializeComponent();
        }

        private void dlgWorkingListResult_Load(object sender, EventArgs e)
        {
            List<int?> oldIDs = selectedTests.Select(x => x.OldID).ToList();

            GSDList = dc.GivenServiceDs.Where(x =>
                (OnlyNotConfirmed ? !x.Confirm : true)
                && x.Service != null
                && x.Service.CategoryID == (int)Category.آزمایش
                && x.GivenServiceM != null
                && x.GivenServiceM.DepartmentID == MainModule.InstallLocation.ID
                //  && x.GivenServiceM.TurningDate != null
                && x.GivenServiceM.ServiceCategoryID == (int)Category.آزمایش
               // && x.GivenServiceM.SendToDr == true
               // && x.GivenLaboratoryServiceD.GetSampel == true
                && (EMG ? x.GivenServiceM.Priority == true : true)
                && x.GivenServiceM.Admitted
                && x.GivenServiceM.TurningDate != null
                && x.GivenServiceM.TurningDate.CompareTo(FromDate) >= 0
                && x.GivenServiceM.TurningDate.CompareTo(ToDate) <= 0
                && (FromSN == null ? true : (x.GivenServiceM.SerialNumber >= FromSN))
                && (ToSN == null ? true : (x.GivenServiceM.SerialNumber <= ToSN))
                && (FromDN == null ? true : (x.GivenServiceM.DailySN >= FromDN))
                && (ToDN == null ? true : (x.GivenServiceM.DailySN <= ToDN))
                && oldIDs.Contains(x.Service.OldID)
                ).OrderBy(x => x.Service.OldID).OrderBy(x => x.GivenServiceM.SerialNumber).OrderBy(x => x.GivenServiceM.DailySN).ToList().OrderBy(x => x.GivenServiceM.WorkListDate).ToList();

            var i = 1;
            GSDList.Select(x => x.GivenServiceM).Distinct().ToList().ForEach(x => x.LineNumber = i++);

            givenServiceDsBindingSource.DataSource = GSDList;

            //pivotGridControl1.BestFit();
            //fieldPerson.BestFit();
            //fieldGivenServiceMWorkListDate.BestFit();
            //fieldGivenServiceMSerialNumber.BestFit();
            //fieldDailySN.BestFit();
            fieldGivenServiceMDoctorDepartment.Appearance.Header.Font = new Font("Tahoma", 7.5F);
            fieldGivenServiceMDoctorDepartment.Appearance.Header.Options.UseFont = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pivotGridControl1.ShowRibbonPrintPreview();
        }
    }
}