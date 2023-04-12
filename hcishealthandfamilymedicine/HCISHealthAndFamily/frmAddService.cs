using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISHealthAndFamily.Dialogs;
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily
{
    public partial class frmAddService : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<QAPlus> lst = new List<QAPlus>();

        public frmAddService()
        {
            InitializeComponent();
        }

        private void frmAddService_Load(object sender, EventArgs e)
        {
            questionnaireBindingSource.DataSource = dc.Questionnaires.Where(c => c.IDGroup == Guid.Parse("b7293c96-a4c9-4a49-8843-fc5a60f92f5a")).ToList();
            gridControl2.RefreshDataSource();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var row = questionnaireBindingSource.Current as Questionnaire;
            if (row == null)
                return;

            if (lst.Any(c => c.QuestionnariID == row.ID))
            {
                MessageBox.Show("این خدمت قبلا وارد شده است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var qa = new QAPlus();
            qa.Questionnaire = row;
            qa.ResultCHK = true;

            lst.Add(qa);
            qAPlusBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var gsm = dc.GivenServiceMs.FirstOrDefault(x => x.ID == MainModule.GSM_Set.ID);
            if (gsm == null)
                return;

            foreach (var item in lst)
            {
                if (item.ResultCHK == true || !string.IsNullOrWhiteSpace(item.Description))
                {
                    item.GivenServiceM = gsm;
                    item.CreationDate = MainModule.GetPersianDate(DateTime.Now);
                    item.CreationTime = DateTime.Now.ToString("HH:mm");
                    item.CreationUser = MainModule.UserID;
                    item.Date = MainModule.GetPersianDate(DateTime.Now);
                    if (item.ID == 0)
                        dc.QAPlus.InsertOnSubmit(item);
                }
            }

            dc.SubmitChanges();
            MessageBox.Show("ثبت با موفقیت انجام شد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            qAPlusBindingSource.DataSource = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}