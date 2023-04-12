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
    public partial class dlgScreening : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        Screening ObjectSCR;
        List<Screening> lst;

        public dlgScreening()
        {
            InitializeComponent();
        }

        private void dlgScreening_Load(object sender, EventArgs e)
        {
            if (ObjectSCR == null)
                ObjectSCR = new Screening();

            if (lst == null)
                lst = new List<Screening>();

            lst = dc.Screenings.OrderBy(c => c.Number).OrderBy(c => c.Date).ToList();
            screeningMBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectSCR.Number = txtNumber.Text;
            ObjectSCR.Goal = mmGoal.Text.Trim();
            ObjectSCR.Date = MainModule.GetPersianDate(DateTime.Now);
            if (lst.Any(c => c.Number == ObjectSCR.Number && c.Finish != true))
            {
                MessageBox.Show("این شماره غربالگری تکراری است.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            dc.Screenings.InsertOnSubmit(ObjectSCR);
            dc.SubmitChanges();
            ObjectSCR = null;
            txtNumber.Text = null;
            mmGoal.Text = null;
            lst = dc.Screenings.OrderBy(c => c.Number).OrderBy(c => c.Date).ToList();
            screeningMBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var crnt = screeningMBindingSource.Current as Screening;
            if (crnt == null)
                return;

            var dlg = new dlgScreeningItem();
            dlg.dc = dc;
            dlg.selectedScreening = crnt;
            dlg.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Name == "colFinish")
            {
                dc.SubmitChanges();
            }
        }
    }
}