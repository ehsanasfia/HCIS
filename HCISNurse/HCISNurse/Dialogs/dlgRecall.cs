using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISNurse.Data;
using HCISNurse.Classes;

namespace HCISNurse.Dialogs
{
    public partial class dlgRecall : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        List<Recall> lstRCL;

        public dlgRecall()
        {
            InitializeComponent();
        }

        private void dlgRecall_Load(object sender, EventArgs e)
        {
            if (lstRCL == null)
                lstRCL = new List<Recall>();

            screeningBindingSource.DataSource = dc.Screenings.Where(x => x.Finish != true).OrderBy(c => c.Number).OrderBy(c => c.Date).ToList();
            personBindingSource.DataSource = dc.Persons.Where(x => x.MedicalID != null).ToList();
        }

        private void slkScreening_EditValueChanged(object sender, EventArgs e)
        {
            var scrn = slkScreening.EditValue as Screening;
            lstRCL = dc.Recalls.Where(x => x.Screening == scrn).ToList();
            recallBindingSource.DataSource = lstRCL;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var scrn = slkScreening.EditValue as Screening;
            if (scrn == null)
            {
                MessageBox.Show("لطفا نوع غربالگری را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            foreach (var item in gridView2.GetSelectedRows())
            {
                var prs = gridView2.GetRow(item) as Person;
                var rcll = new Recall()
                {
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm"),
                    IDPerson = prs.ID,
                    IDScreening = scrn.ID
                };

                if (!lstRCL.Any(c => c.IDPerson == prs.ID))
                    dc.Recalls.InsertOnSubmit(rcll);
            }

            dc.SubmitChanges();
            lstRCL = dc.Recalls.Where(x => x.Screening == scrn).ToList();
            recallBindingSource.DataSource = lstRCL;
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}