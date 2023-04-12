using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HCISAdmission.Dialogs
{
    public partial class dlgExport : DevExpress.XtraEditors.XtraForm
    {
        public DataClasses1DataContext dc { get; set; }
        public Agenda agnToChange { get; set; }
        public Department dep { get; set; }

        List<Agenda> lstAgn;

        public dlgExport()
        {
            InitializeComponent();
        }

        private void dlgExport_Load(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ID == 19).ToList();
            givenServiceMBindingSource.DataSource = dc.GivenServiceMs.Where(x => x.AgendaID == agnToChange.ID && x.Confirm != true && x.Cancelled != true);
            lstAgn = dc.Agendas.Where(c => c.DepartmentID == dep.ID && c.Date.CompareTo(date) >= 0 && (c.Deleted == null || c.Deleted == false)).ToList();
            agendasBindingSource.DataSource = lstAgn;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var date = MainModule.GetPersianDate(DateTime.Now);
            var agn = (searchLookUpEdit1.EditValue as Agenda);
            if (agn == null)
            {
                MessageBox.Show("لطفا ابتدا پزشک راانتخاب کنید");
                return;
            }
            var lstGsm = gridView1.GetSelectedRows().ToList().Select(x => (gridView1.GetRow(x) as GivenServiceM)).ToList();
            var cntHozoori = lstGsm.Count(x => x.VisitType != 19);
            var cntGheyreHozoori = lstGsm.Count(x => x.VisitType == 19);
            dc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, agn);

            if ((cntHozoori > agn.RemainingInteger) || (cntGheyreHozoori > agn.RemainingInaccessibleInteger))
            {
                MessageBox.Show("تعداد بیماران انتخاب شده از ظرفیت تقویم این روز پزشک بیشتر میباشد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("آیا میخواهید بیماران را انتقال دهید؟\n لطفا به پزشک اطلاع دهید", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            foreach (var gsm in lstGsm)
            {
                gsm.Staff = agn.Staff;
                gsm.Agenda = agn;
                gsm.LastModificationDate = MainModule.GetPersianDate(DateTime.Now);
                gsm.LastModificationTime = DateTime.Now.ToString("HH:mm");
                gsm.LastModificator = MainModule.UserID;
            }
            dc.SubmitChanges();
            MessageBox.Show("بیماران با موفقیت انتقال یافتند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            var dlg = new Dialogs.dlgChooseAgendas() { lstAgn = lstAgn, SelectedAgenda = (searchLookUpEdit1.EditValue as Agenda) };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                searchLookUpEdit1.EditValue = dlg.SelectedAgenda;
            }
        }
    }
}