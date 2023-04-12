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
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class frmElamenatije : DevExpress.XtraEditors.XtraForm
    {

        OMOClassesDataContext dc = new OMOClassesDataContext();
        private Visit EditingVisit;
        public frmElamenatije()
        {
            InitializeComponent();
        }

        private void frmElamenatije_Load(object sender, EventArgs e)
        {
            try
            {
                if (Classes.MainModule.VST_Set.Person.Photo != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = Classes.MainModule.VST_Set.Person.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        barEditItem1.EditValue = Image.FromStream(ms);
                    }
                }
                else if (Classes.MainModule.VST_Set.Person.Photo == null)
                {
                    barEditItem1.EditValue = null;
                }
            }
            catch
            { }


            DefinitionLimitationBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 7).ToList();
            DefinitionIndividualProtectionBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 8).ToList();
            DefinitionAdviseBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 161).ToList();
            DefinitionResultBindingSource.DataSource = dc.Definitions.Where(c => c.ParentID == 11).ToList();
            var lstDoc = dc.Staffs.Where(a=>a.Hide != true).Select(x => x.Person).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            personBindingSource.DataSource = lstDoc;
            personBindingSource1.DataSource = lstDoc;

            if (Classes.MainModule.VST_Set == null)
            {


            }
            else
            {
                EditingVisit = dc.Visits.FirstOrDefault(c => c.ID == Classes.MainModule.VST_Set.ID);
                if (EditingVisit.NextVisitDate == null)
                    if (EditingVisit.AdmitDate.Length > 0)
                    {
                        var a = Int32.Parse(EditingVisit.AdmitDate.Substring(0, 4));
                        a++;
                        var NextDate = a.ToString() + EditingVisit.AdmitDate.Substring(4);

                        EditingVisit.NextVisitDate = NextDate;
                    }
                if (EditingVisit.ResultOpinionID == null)
                {
                    EditingVisit.ResultOpinionID = 12;
                    lkpResultOpinionID.EditValue = 12;
                }
                visitBindingSource.DataSource = EditingVisit;

                barStaticItem1.Caption = "نام: " + Classes.MainModule.VST_Set.Person.FirstName ?? "";
                barStaticItem2.Caption = "نام خانوادگی: " + Classes.MainModule.VST_Set.Person.LastName ?? "";
                GetDataLoad();
            }

            var date = DateTime.Now.AddYears(1);
            txtNextMorajeeDate.Text = Classes.MainModule.GetPersianDate(date);
            txtAcceptDate.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            slkAcceptDoctor.EditValue = lstDoc.FirstOrDefault(x => x.ID == Classes.MainModule.VST_Set.ResultDocStaffID);
            slkSpecialist.EditValue = lstDoc.FirstOrDefault(x => x.ID == Classes.MainModule.VST_Set.SpecialistDocStaffID);

            if (lstDoc.Any(c => c.Staff.UserID == MainModule.UserID))
            {
                var stf = lstDoc.FirstOrDefault(c => c.Staff.UserID == MainModule.UserID).Staff;
                if (stf.Definition.Name == "پزشک سلامت کار")
                {
                    slkAcceptDoctor.EditValue = stf.Person;
                }
                else if (stf.Definition.Name == "متخصص طب کار")
                {
                    slkSpecialist.EditValue = stf.Person;
                }
                else if (stf.Definition.Name == "هر دو")
                {
                    slkAcceptDoctor.EditValue = stf.Person;
                    slkSpecialist.EditValue = stf.Person;
                }
            }
        }

        private void GetDataLoad()
        {
            ResultDetailLimitationBindingSource.DataSource = dc.ResultDetails.Where(c => c.VisitID == Classes.MainModule.VST_Set.ID && c.FinalOpinionTypeID == 221).ToList();
            ResultDetailIPBindingSource.DataSource = dc.ResultDetails.Where(c => c.VisitID == Classes.MainModule.VST_Set.ID && c.FinalOpinionTypeID == 222).ToList();
            ResultDetailAdviceBindingSource.DataSource = dc.ResultDetails.Where(c => c.VisitID == Classes.MainModule.VST_Set.ID && c.FinalOpinionTypeID == 223).ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void grdLimit_DoubleClick(object sender, EventArgs e)
        {
            var cur = DefinitionLimitationBindingSource.Current as Definition;
            if (cur == null)
                return;
            else
            {
                var resultD = new ResultDetail()
                {
                    VisitID = Classes.MainModule.VST_Set.ID,
                    CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                    CreatorUserID = Classes.MainModule.UserID,
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    FinalOpinionTypeID = 221,
                    ItemID = cur.ID
                };
                dc.ResultDetails.InsertOnSubmit(resultD);
                dc.SubmitChanges();
                GetDataLoad();
            }
        }

        private void grdConsum_DoubleClick(object sender, EventArgs e)
        {
            var cur = DefinitionIndividualProtectionBindingSource.Current as Definition;
            if (cur == null)
                return;
            else
            {
                var resultD = new ResultDetail()
                {
                    VisitID = Classes.MainModule.VST_Set.ID,
                    CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                    CreatorUserID = Classes.MainModule.UserID,
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    FinalOpinionTypeID = 222,
                    ItemID = cur.ID
                };
                dc.ResultDetails.InsertOnSubmit(resultD);
                dc.SubmitChanges();
                GetDataLoad();
            }
        }

        private void gridControl6_DoubleClick(object sender, EventArgs e)
        {
            var cur = DefinitionAdviseBindingSource.Current as Definition;
            if (cur == null)
                return;
            else
            {
                var resultD = new ResultDetail()
                {
                    VisitID = Classes.MainModule.VST_Set.ID,
                    CreationDate = Classes.MainModule.GetPersianDate(DateTime.Now),
                    CreatorUserID = Classes.MainModule.UserID,
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    FinalOpinionTypeID = 223,
                    ItemID = cur.ID
                };
                dc.ResultDetails.InsertOnSubmit(resultD);
                dc.SubmitChanges();
                GetDataLoad();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                visitBindingSource.EndEdit();
                ResultDetailLimitationBindingSource.EndEdit();
                ResultDetailIPBindingSource.EndEdit();
                if (EditingVisit.ToDoList.ResultUserID == null)
                {
                    EditingVisit.ToDoList.ResultDate = MainModule.GetPersianDate(DateTime.Now);
                    EditingVisit.ToDoList.ResultUserID = MainModule.UserID;
                    EditingVisit.ToDoList.ResultTime = DateTime.Now.ToString("HH:mm");
                }
                EditingVisit.ToDoList.Result = true;

                var prsDoc = slkAcceptDoctor.EditValue as Person;
                var prsSpec = slkSpecialist.EditValue as Person;

                if (prsDoc != null)
                {
                    EditingVisit.Staff = prsDoc.Staff;
                    EditingVisit.ResultDocFullName = prsDoc.FirstName + " " + prsDoc.LastName;
                    EditingVisit.ResultDocUser = prsDoc.Staff.UserID;
                    EditingVisit.AcceptDoctor = true;
                }
                else
                {
                    EditingVisit.Staff = null;
                    EditingVisit.ResultDocFullName = null;
                    EditingVisit.ResultDocUser = null;
                    EditingVisit.AcceptDoctor = false;
                }

                if (prsSpec != null)
                {
                    EditingVisit.Staff1 = prsSpec.Staff;
                    EditingVisit.SpecialistDocFullName = prsSpec.FirstName + " " + prsSpec.LastName;
                    EditingVisit.AcceptSpecialist = true;
                }
                else
                {
                    EditingVisit.Staff1 = null;
                    EditingVisit.SpecialistDocFullName = null;
                    EditingVisit.AcceptSpecialist = false;
                }

                dc.SubmitChanges();
                MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);
                MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtAcceptDate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((ButtonEdit)sender).Text = MainModule.GetPersianDate(DateTime.Now);
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var cur = ResultDetailIPBindingSource.Current as ResultDetail;
            if (cur == null)
                return;

            dc.ResultDetails.DeleteOnSubmit(cur);
            ResultDetailIPBindingSource.RemoveCurrent();
            // dc.SubmitChanges();
        }

        private void btnOldHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(x => x.ID == MainModule.VST_Set.ID);

            var dlg = new Dialogs.dlgOldHistory();
            dlg.SelectedPrs = MainModule.VST_Set.Person;
            dlg.ElameNatije = true;
            dlg.ShowDialog();
        }

        private void bbiVisitHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Dialogs.dlgVisitHistory() { dc = dc };
            dlg.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var cur = ResultDetailLimitationBindingSource.Current as ResultDetail;

            if (cur == null)
                return;

            dc.ResultDetails.DeleteOnSubmit(cur);
            ResultDetailLimitationBindingSource.RemoveCurrent();
            // dc.SubmitChanges();
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف اطمینان دارید ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var cur = ResultDetailAdviceBindingSource.Current as ResultDetail;

            if (cur == null)
                return;

            dc.ResultDetails.DeleteOnSubmit(cur);
            ResultDetailAdviceBindingSource.RemoveCurrent();
            // dc.SubmitChanges();
        }

        private void frmElamenatije_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ذخیره ی تغییرات هستید؟", "توجه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == DialogResult.Yes)
            {
                barButtonItem6_ItemClick(null, null);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnRefferToDoctor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainModule.ConnectToHcis == true)
            {
                var dlg = new Dialogs.dlgExpertise();
                dlg.Operson = MainModule.VST_Set.Person;
                dlg.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
    }

}