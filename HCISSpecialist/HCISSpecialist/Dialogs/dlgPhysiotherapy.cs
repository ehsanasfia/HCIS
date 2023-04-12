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
    public partial class dlgPhysiotherapy : DevExpress.XtraEditors.XtraForm
    {
        public List<Service> patientRecService = new List<Service>();
        public HCISSpecialistClassesDataContext dc { get; set; }
        public GivenServiceM visit { get; set; }


        public dlgPhysiotherapy()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dlgPhysiotherapy_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.فیزیوتراپی);
            grdSelected.DataSource = patientRecService;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            var pm = new PhysiotherapyOrderM()
            {
                Person = visit.Person,
                RequestedTime = int.Parse(spnDays.Text.ToString()),
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                CreatorUserID = MainModule.UserID,
                RequestDate = MainModule.GetPersianDate(DateTime.Now),
                RequestTime = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                LastModificator = MainModule.UserID,
                Staff = visit.Staff,
                Date = MainModule.GetPersianDate(DateTime.Now),
                Time = DateTime.Now.ToString("HH:mm"),
            };
            dc.PhysiotherapyOrderMs.InsertOnSubmit(pm);
            patientRecService.ForEach(x =>
            {
                var gsd = new PhysiotherapyOrderD()
                {
                    PhysiotherapyOrderM = pm,
                    Service = x,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    Position = x.Comment,
                };
                
                dc.PhysiotherapyOrderDs.InsertAllOnSubmit(pm.PhysiotherapyOrderDs);
                
            });
            dc.SubmitChanges();
            MessageBox.Show("خدمات با موفقیت ثبت شد");
            DialogResult = DialogResult.OK;

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            gridView2.DeleteSelectedRows();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks < 2)
                return;
            var current = serviceBindingSource.Current as Service;

            if (current == null)
                return;

            if (!patientRecService.Contains(current))
            {

                patientRecService.Add(current);

            }
            else
            {
                MessageBox.Show("این خدمت را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            serviceBindingSource2.DataSource = patientRecService;
            gridView2.RefreshData();
        }
    }
}