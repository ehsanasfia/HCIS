using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class frmMenopauseF : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lstPrs;
        List<QAPlus> lstEsteo;
        List<QAPlus> lstMammo;
        List<QAPlus> lstSwix;
        List<QAPlus> lstImportant;
        List<QAPlus> lstReferences;
        List<QAPlus> lstEducation;

        public frmMenopauseF()
        {
            InitializeComponent();
        }

        private void frmMenopauseF_Load(object sender, EventArgs e)
        {
            if (lstPrs == null)
                lstPrs = new List<QAPlus>();

            if (lstEsteo == null)
                lstEsteo = new List<QAPlus>();

            if (lstMammo == null)
                lstMammo = new List<QAPlus>();

            if (lstSwix == null)
                lstSwix = new List<QAPlus>();

            if (lstImportant == null)
                lstImportant = new List<QAPlus>();

            if (lstReferences == null)
                lstReferences = new List<QAPlus>();

            if (lstEducation == null)
                lstEducation = new List<QAPlus>();

            var srvList0 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("9ffddb28-a7ad-4efe-aae1-794aa7b017a6")).ToList();
            foreach (var item in srvList0)
            {
                var qa0 = new QAPlus()
                {
                    PQuestionnaire = item,
                };
                lstPrs.Add(qa0);
            }
            PersonalQABindingSource.DataSource = lstPrs.OrderBy(c => c.PQuestionnaire.SortCol);

            var srvList1 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("3f0d9c46-21ea-49bd-86e7-29221b88a0cc")).ToList();
            foreach (var item in srvList1)
            {
                var qa1 = new QAPlus()
                {
                    PQuestionnaire = item,
                };
                lstEsteo.Add(qa1);
            }
            EsteoQABindingSource.DataSource = lstEsteo.OrderBy(c => c.PQuestionnaire.SortCol);

            var srvList2 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("ff2c08fe-d6a8-4749-a84c-d5f6054b3219")).ToList();
            foreach (var item in srvList2)
            {
                var qa2 = new QAPlus()
                {
                    PQuestionnaire = item,
                };
                lstMammo.Add(qa2);
            }
            MammoQABindingSource.DataSource = lstMammo.OrderBy(c => c.PQuestionnaire.SortCol);

            var srvList3 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("b2b66602-8612-4dcf-afbb-a6fe2efff631")).ToList();
            foreach (var item in srvList3)
            {
                var qa3 = new QAPlus()
                {
                    PQuestionnaire = item,
                };
                lstSwix.Add(qa3);
            }
            SwixQABindingSource.DataSource = lstSwix.OrderBy(c => c.PQuestionnaire.SortCol);

            var srvList4 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("b972eb02-4afd-433a-a6ef-cead2227b8e3")).ToList();
            foreach (var item in srvList4)
            {
                var qa4 = new QAPlus()
                {
                    PQuestionnaire = item,
                };
                lstImportant.Add(qa4);
            }
            ImportantQABindingSource.DataSource = lstImportant.OrderBy(c => c.PQuestionnaire.SortCol);
        }

        private void tabbedControlGroup1_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (tabbedControlGroup1.SelectedTabPageIndex == 1)
            {
                var srvList1 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("e26d83d4-c868-4ca9-8e4d-ed8c5456ea80")).ToList();
                foreach (var item in srvList1)
                {
                    var qa1 = new QAPlus()
                    {
                        PQuestionnaire = item,
                    };
                    lstReferences.Add(qa1);
                }
                ReferenceQABindingSource.DataSource = lstReferences.OrderBy(c => c.PQuestionnaire.SortCol);
            }
            if (tabbedControlGroup1.SelectedTabPageIndex == 2)
            {
                var srvList2 = dc.Questionnaires.Where(x => x.IDGroup == Guid.Parse("b9612ce5-5bfd-462b-934f-5896c506ee2d")).ToList();
                foreach (var item in srvList2)
                {
                    var qa2 = new QAPlus()
                    {
                        PQuestionnaire = item,
                    };
                    lstEducation.Add(qa2);
                }
                EducationQABindingSource.DataSource = lstEducation.OrderBy(c => c.PQuestionnaire.SortCol);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از درستی اطلاعات وارد شده اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            try
            {
                var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
                if (gsm == null)
                    return;

                if (tabbedControlGroup1.SelectedTabPageIndex == 0)
                {
                    foreach (var item in lstPrs)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstEsteo)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstMammo)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstSwix)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }
                    foreach (var item in lstImportant)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    PersonalQABindingSource.DataSource = null;
                    EsteoQABindingSource.DataSource = null;
                    MammoQABindingSource.DataSource = null;
                    SwixQABindingSource.DataSource = null;
                    ImportantQABindingSource.DataSource = null;
                }
                if (tabbedControlGroup1.SelectedTabPageIndex == 1)
                {
                    foreach (var item in lstReferences)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    ReferenceQABindingSource.DataSource = null;
                }
                if (tabbedControlGroup1.SelectedTabPageIndex == 2)
                {
                    foreach (var item in lstEducation)
                    {
                        if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                        {
                            item.Questionnaire = item.PQuestionnaire;
                            item.GivenServiceM = gsm;
                            item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                            item.CreationUser = MainModule.UserID;
                            dc.QAPlus.InsertOnSubmit(item);
                        }
                    }

                    dc.SubmitChanges();
                    EducationQABindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}