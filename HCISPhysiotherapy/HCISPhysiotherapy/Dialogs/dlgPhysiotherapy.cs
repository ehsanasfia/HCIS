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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgPhysiotherapy : DevExpress.XtraEditors.XtraForm
    {
        public List<Service> patientRecService = new List<Service>();
        public HCISClassesDataContext dc { get; set; }
        public GivenServiceM GSM { get; set; }

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
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == (int)Category.فیزیوتراپی && x.Hide != true).OrderBy(c=>c.OldID).ToList();
            grdSelected.DataSource = patientRecService;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GSM.ServiceCategoryID = (int)Category.فیزیوتراپی;
            GSM.RequestedTime = int.Parse(spnDays.Text.ToString()) <= 0 ? 1 : int.Parse(spnDays.Text.ToString());
            GSM.NumberOfOrgans = int.Parse(spinEdit1.Text.ToString()) <= 0 ? 1 : int.Parse(spinEdit1.Text.ToString());
            GSM.RequestTime = DateTime.Now.ToString("HH:mm");
            GSM.Comment = mem.Text.Trim();

            patientRecService.ForEach(x =>
            {
                var gsd = new GivenServiceD()
                {
                    GivenServiceM = GSM,
                    Service = x,
                    LastModificationDate = MainModule.GetPersianDate(DateTime.Now),
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                    LastModificator = MainModule.UserID,
                    Position = x.Comment,
                    Amount = Convert.ToDouble(GSM.NumberOfOrgans),
                    GivenAmount = Convert.ToDouble(GSM.NumberOfOrgans),
                    Date = MainModule.GetPersianDate(DateTime.Now),
                    Time = DateTime.Now.ToString("HH:mm"),
                };

                dc.GivenServiceDs.InsertOnSubmit(gsd);
            });

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
            add();
        }

        private void add()
        {
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

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                add();
            }
            else if (e.KeyChar == (char)Keys.Tab)
            {
                spnDays.Select();
            }
        }
    }
}