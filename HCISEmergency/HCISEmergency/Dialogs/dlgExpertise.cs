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
using HCISEmergency.Data;
using HCISEmergency.Classes;

namespace HCISEmergency.Dialogs
{
    public partial class dlgExpertise : DevExpress.XtraEditors.XtraForm
    {
        private HCISDataContext dc = new HCISDataContext();
        public GivenServiceM visit { get; set; }
        public Guid? GsmID { get; set; }
        public dlgExpertise()
        {
            InitializeComponent();
        }

        private void dlgExpertise_Load(object sender, EventArgs e)
        {
            visit = dc.GivenServiceMs.FirstOrDefault(x => x.ID == GsmID);
            var Hospital = Guid.Parse("ebf1cf0a-702c-46c8-a6a5-71404eb43a9e");
            referenceBindingSource.DataSource = dc.References.Where(x => x.GivenServiceMID == visit.ID).OrderByDescending(x => x.CreationTime).OrderByDescending(x => x.CreationDate).ToList();
            specialityBindingSource.DataSource = dc.Departments.Where(x => x.TypeID == 10 && x.Parent == Hospital).ToList();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((lkpExperties.EditValue as Guid?) == null)
            {
                MessageBox.Show("ابتدا یک کلینیک را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (visit.References.Any(x => x.GivenServiceMID == visit.ID && x.DepartmentID == (lkpExperties.EditValue as Guid?) && x.Confirm != true))
            {
                MessageBox.Show(".این بیمار به این کلینیک ارجاع داده شده است", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var today = MainModule.GetPersianDate(DateTime.Now);
            DateTime sugestdate = DateTime.Now;

            var sug = today;
            var end = sugestdate.AddDays(7);
            var endLincence = MainModule.GetPersianDate(end);
            var start = sugestdate.AddDays(-7);
            var startLincence = MainModule.GetPersianDate(start);
            try
            {
                var reffer = new Reference()
                {
                    GivenServiceM = visit,
                    DepartmentID = lkpExperties.EditValue as Guid?,
                    DestinationWard = lkpExperties.EditValue as Guid?,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    SuggestedDate = sug,
                    EndDateLicense = endLincence,
                    StartDateLicense = startLincence,
                    Staff = visit.Staff,
                    Comment = memComment.Text
                };
                if (checkEdit1.Checked == true)
                    reffer.Priority = true;
                dc.References.InsertOnSubmit(reffer);
                dc.SubmitChanges();
                MessageBox.Show(".بیمار با موفقیت ارجاع داده شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

        }
    }
}