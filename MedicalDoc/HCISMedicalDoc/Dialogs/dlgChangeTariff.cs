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
using HCISMedicalDoc.Data;
using HCISMedicalDoc.Classes;

namespace HCISMedicalDoc.Dialogs
{
    public partial class dlgChangeTariff : DevExpress.XtraEditors.XtraForm
    {
        OccupationalMedicineOilDataContexDataContext dc = new OccupationalMedicineOilDataContexDataContext();
        public Tariff lastTrf { get; set; }
        public bool LastTRFEdited { get; set; }

        public ViewTariffComplete row { get; set; }

        private bool RowEdited;
        private bool DateEdited;
        List<Tariff> lst;

        private void dlgChangeTariff_Load(object sender, EventArgs e)
        {
            lst = dc.Tariffs.Where(c => c.ServiceID == row.ServiceID && c.InsuranceID == row.InsuranceID).OrderByDescending(x => x.Date).ToList();
            foreach (var tf in lst)
            {
                tf.Lock = true;
            }

            tariffsBindingSource.DataSource = lst;
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

            if (string.IsNullOrWhiteSpace(row.Date))
            {
                row.Date = MainModule.today;
                DateEdited = true;
            }

            if (e.Column == colDate)
            {
                DateEdited = true;
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

                    if (DateEdited)
                    {
                        if (lst.Any(x => x.ID != row.ID && x.Date == row.Date))
                        {
                            MessageBox.Show("تاریخ تعرفه ی دیگری برابر با این تاریخ میباشد و این کار مجاز نمیباشد.\nلطفا تاریخ را تغییر دهید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            e.Allow = false;
                            return;
                        }
                    }

                    row.Lock = true;
                    RowEdited = false;
                    DateEdited = false;
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