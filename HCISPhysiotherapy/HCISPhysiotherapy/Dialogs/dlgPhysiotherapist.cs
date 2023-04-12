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
    public partial class dlgPhysiotherapist : DevExpress.XtraEditors.XtraForm
    {
        public HCISClassesDataContext dc { get; set; }
        public GivenServiceD GSD { get; set; }
        public GivenServiceM GSM { get; set; }
        public List<GivenServiceM> lstGSM { get; set; }

        bool hame = true;

        public dlgPhysiotherapist()
        {
            InitializeComponent();

            List<string> Position = new List<string>();

            Position.Add("Ap Oblik");
            Position.Add("Ap,Lat");
            Position.Add("Axial,Lat");
            Position.Add("Bending");
            Position.Add("Both");
            Position.Add("Close M");
            Position.Add("Cold Well View");
            Position.Add("Fextion,Extention");
            Position.Add("Lat");
            Position.Add("Lat Oblik");
            Position.Add("Left");
            Position.Add("Left Ap");
            Position.Add("Left Ap,Lat");
            Position.Add("Left Lat");
            Position.Add("Left Oblik");
            Position.Add("OBL");
            Position.Add("Open M");
            Position.Add("Right");
            Position.Add("Right & Left Ap");
            Position.Add("Right & Left Ap,Lat");
            Position.Add("Right & Left Lat");
            Position.Add("Right & Left");
            Position.Add("Right Ap");
            Position.Add("Right Ap,Lat");
            Position.Add("Right Lat");
            Position.Add("Right Oblik");
            Position.Add("Schuller's View");
            Position.Add("Stenver's View");
            Position.Add("Up Right");
            Position.Add("Waster View");

            lkpPosition.Properties.DataSource = Position;
        }

        private void dlgPhysiotherapist_Load(object sender, EventArgs e)
        {
            lstGSM = GSM.GivenServiceM1.GivenServiceMs.OrderBy(c => c.TurningDate).ToList();
            lblRequestedTime.Text = GSM.RequestedTime.ToString();
            lblNumberOfOrgans.Text = GSM.NumberOfOrgans.ToString();
            lblComment.Text = GSM.Comment;
            givenServiceMsBindingSource.DataSource = lstGSM;

            GSD = new GivenServiceD();
            GivenServiceDBindingSource.DataSource = GSD;
            givenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.ToList().OrderBy(x => x.Service.Name);

            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.فیزیوتراپی).ToList();
            serviceBookletBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.فیزیوتراپی).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GivenServiceDBindingSource.EndEdit();
                if (slkService.Text == "")
                {
                    MessageBox.Show("لطفا خدمت را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                GSD.Comment = lkpPosition.Text.Trim();

                GSD.GivenServiceM = GSM;
                GSM.GivenServiceDs.Add(GSD);
                dc.GivenServiceDs.InsertOnSubmit(GSD);

                GSD = new GivenServiceD();
                GivenServiceDBindingSource.DataSource = GSD;
                givenServiceDsBindingSource.DataSource = GSM.GivenServiceDs.ToList().OrderBy(x => x.Service.Name);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void faMonthView1_DoubleClick(object sender, EventArgs e)
        {
            var today = MainModule.GetPersianDate(DateTime.Now);
            if (faMonthView1.SelectedDateTime == null)
            {
                return;
            }

            var gsm = new GivenServiceM()
            {
                TurningDate = MainModule.GetPersianDate((DateTime)faMonthView1.SelectedDateTime),
                GivenServiceM1 = GSM.GivenServiceM1,
                ServiceCategoryID = GSM.ServiceCategoryID,
                Staff1 = GSM.Staff1,
                CreationDate = today,
                CreationTime = DateTime.Now.ToString("HH:mm"),
                LastModificationDate = today,
                LastModificationTime = DateTime.Now.ToString("HH:mm"),
                Person = GSM.Person,               
            };
            foreach(var gsd in GSM.GivenServiceDs)
            {
                var newGsd = new GivenServiceD()
                {
                    GivenServiceM = gsm,
                    Service = gsd.Service,
                    Comment = gsd.Comment,
                    LastModificationDate = today,
                    LastModificationTime = DateTime.Now.ToString("HH:mm"),
                };
                gsm.GivenServiceDs.Add(newGsd);
                dc.GivenServiceDs.InsertOnSubmit(newGsd);
            }
            
            dc.GivenServiceMs.InsertOnSubmit(gsm);
            lstGSM.Add(gsm);
            lstGSM = lstGSM.OrderBy(c => c.TurningDate).ToList();

            givenServiceMsBindingSource.DataSource = lstGSM;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var item in GSM.GivenServiceDs)
            {
                if(item.Confirm == true)
                {
                    hame = true;
                }
                else
                {
                    hame = false;
                    break;
                }
            }
            if(hame == true)
            {
                GSM.Confirm = true;
            }
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}