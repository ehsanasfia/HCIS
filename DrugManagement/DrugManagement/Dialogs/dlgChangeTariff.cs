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
using HCISInsurance.Data;

namespace HCISInsurance.Dialogs
{
    public partial class dlgChangeTariff : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext dc = new HCISClassesDataContext();
        public Tariff lastTrf { get; set; }
        public bool LastTRFEdited { get; set; }

        public ViewTariffComplete row { get; set; }

        private bool RowEdited;
        List<Tariff> lst;

        private void dlgChangeTariff_Load(object sender, EventArgs e)
        {
            lst = dc.Tariffs.Where(c => c.ServiceID == row.ServiceID && c.InsuranceID == row.InsuranceID).OrderByDescending(x => x.Date).ToList();
            foreach (var tf in lst)
            {
                tf.Lock = true;
            }

            tariffsBindingSource.DataSource = lst;
            if (lst.Any())
                lastTrf = lst.ElementAt(0);
        }


        public dlgChangeTariff()
        {
            InitializeComponent();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            RowEdited = true;
            if (e.Column == colLock)
                return;
            var row = gridView1.GetRow(e.RowHandle) as Tariff;
            row.OrganizationShare = row.TotalPrice - row.PatientShare;

            //gridView1.SetRowCellValue(e.RowHandle, colInsurePart, row.OrganizationShare);
            //paRow.Lock = row.Lock.Value;

            if (row.Date == null)
                row.Date = MainModule.GetPersianDate(DateTime.Now);
            if (row.ID == lastTrf.ID)
            {
                LastTRFEdited = true;
            }
        }
        
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedColumn == colLock)
                return;
            var row = gridView1.GetFocusedRow() as Tariff;
            if (row == null)
                return;

            if (row.Lock)
                e.Cancel = true;
        }

        private void dlgChangeTariff_FormClosing(object sender, FormClosingEventArgs e)
        {
            tariffsBindingSource.EndEdit();
            try
            {
                if (MainModule.DataContextChanged(dc))
                {
                    lst.ForEach(x => x.Lock = true);
                    dc.SubmitChanges();
                    lastTrf = lst.ElementAt(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                if (RowEdited)
                {
                    var row = gridView1.GetRow(e.RowHandle) as Tariff;
                    if (row == null)
                        return;

                    row.Lock = true;
                    RowEdited = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}