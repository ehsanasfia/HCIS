using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgPresentation : DevExpress.XtraEditors.XtraForm
    {
        public dlgPresentation()
        {
            InitializeComponent();
        }
        public HCISDataContext dc { get; set; }
        public bool fromarchive { get; set; }
        private void dlgPresentation_Load(object sender, EventArgs e)
        {
            if (fromarchive)
                layoutControlItem2.Enabled = false;

            var Presentation = dc.GivenServiceMs.FirstOrDefault(c => c.ID == MainModule.GSM_Set.ID).Presentation;
            if (Presentation != null)
            {
                presentationBindingSource.DataSource = Presentation;
            }
            else
                presentationBindingSource.DataSource = new Presentation();

            
            if (dc.Visits.Any(x=> x.ID == MainModule.GSM_Set.ID))
            {
                comboBoxEdit1.EditValue = MainModule.GSM_Set.Visit.ChiefComplaint;
                comboBoxEdit3.EditValue = MainModule.GSM_Set.Visit.Ago;
                comboBoxEdit2.EditValue = MainModule.GSM_Set.Visit.Since;
                memoEdit23.Text = MainModule.GSM_Set.Visit.Comment;
                if (MainModule.GSM_Set.Visit.RO == true)
                    chkRO.Checked = true;
                else chkRO.Checked = false;
                slkIMP.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Visit.IMP);
                slkDDx1.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Visit.DDx1);
                slkDDx2.EditValue = MainModule.icd.FirstOrDefault(x => x.ID == MainModule.GSM_Set.Visit.DDx2);
            }

            iCD10BindingSource.DataSource = MainModule.icd;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // clinicStaff = new SecurityControlDBDataContext().tblUsers.FirstOrDefault(c => c.tblApplication.ApplicationName == "HCISSpecialist" && c.UserName == MainModule.UserName).UserID;

         //var   MyStaff = MainModule.MyStaff;
         //   if (MessageBox.Show("این تشخیص به نام دکتر" + MyStaff.Person.FirstName + " " + MyStaff.Person.LastName + " " + "ثبت میگردند آیا از ثبت اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
         //   {
         //       var dlg = new Dialogs.dlgSelectDr();
         //       dlg.ShowDialog();
         //       if (dlg.DialogResult == DialogResult.OK)
         //       {
         //           MyStaff = MainModule.MyStaff;
         //           //lblCurentDoc.Text = "پزشک انتخابی: " + MyStaff.Person.FirstName + " " + MyStaff.Person.LastName;
         //       }
         //   }
            presentationBindingSource.EndEdit();
            var myPresent = presentationBindingSource.Current as Presentation;
            myPresent.GivenServiceM = MainModule.GSM_Set;
            if (!dc.Presentations.Any(c => c.ID == MainModule.GSM_Set.ID))
                dc.Presentations.InsertOnSubmit(myPresent);
            if(!dc.Visits.Any(c => c.ID == MainModule.GSM_Set.ID))
            {
                short s = -1;
                bool cor = false;
                if (comboBoxEdit2.EditValue == null)
                {
                    cor = false;
                }
                else
                {
                    cor = short.TryParse(comboBoxEdit2.EditValue.ToString(), out s);
                }
                short? snc = null;
                if (cor)
                    snc = s;

                var visit = new Visit()
                {
                    ID = MainModule.GSM_Set.ID,
                    RO = chkRO.Checked,
                    Comment = memoEdit23.Text,
                    Ago = comboBoxEdit3.EditValue == null ? null : comboBoxEdit3.EditValue.ToString(),
                    Since = snc,
                    ChiefComplaint = comboBoxEdit1.EditValue == null ? null : comboBoxEdit1.EditValue.ToString(),
                    IMP = slkIMP.EditValue == null ? null : (int?)(slkIMP.EditValue as ICD10).ID,
                    DDx1 = slkDDx1.EditValue == null ? null : (int?)(slkDDx1.EditValue as ICD10).ID,
                    DDx2 = slkDDx2.EditValue == null ? null : (int?)(slkDDx2.EditValue as ICD10).ID,
                };
                visit.AccompanyingDocument = "";
                for (int i = 0; checkedListBoxControl1.ItemCount > i; i++)
                {
                    if (!(checkedListBoxControl1.Items[i].CheckState.ToString() == "Unchecked"))
                        visit.AccompanyingDocument += checkedListBoxControl1.Items[i].Description.ToString() + ",";
                }
                if (visit.AccompanyingDocument.Length > 0)
                    visit.AccompanyingDocument = visit.AccompanyingDocument.Substring(0, visit.AccompanyingDocument.Length - 1);
                if (visit.ID != Guid.Empty && !dc.Visits.Any(g => g.ID == visit.ID))
                    dc.Visits.InsertOnSubmit(visit);
            }

            else
            {
                short s = -1;
                bool cor = false;
                if (comboBoxEdit2.EditValue == null)
                {
                    cor = false;
                }
                else
                {
                    cor = short.TryParse(comboBoxEdit2.EditValue.ToString(), out s);
                }
                short? snc = null;
                if (cor)
                    snc = s;
                MainModule.GSM_Set.Visit.RO = chkRO.Checked;
                MainModule.GSM_Set.Visit.Comment = memoEdit23.Text;
                MainModule.GSM_Set.Visit.Ago = comboBoxEdit3.EditValue == null ? null : comboBoxEdit3.EditValue.ToString();
                MainModule.GSM_Set.Visit.Since = snc;
                MainModule.GSM_Set.Visit.ChiefComplaint = comboBoxEdit1.EditValue == null ? null : comboBoxEdit1.EditValue.ToString();
                MainModule.GSM_Set.Visit.IMP = slkIMP.EditValue == null ? null : (int?)(slkIMP.EditValue as ICD10).ID;
                MainModule.GSM_Set.Visit.DDx1 = slkDDx1.EditValue == null ? null : (int?)(slkDDx1.EditValue as ICD10).ID;
                MainModule.GSM_Set.Visit.DDx2 = slkDDx2.EditValue == null ? null : (int?)(slkDDx2.EditValue as ICD10).ID;
            }

            dc.SubmitChanges();
            MessageBox.Show("شرح حال و معاینه بیمار ثبت گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            this.DialogResult = DialogResult.OK;

        }
       
        private void breastCheckCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}