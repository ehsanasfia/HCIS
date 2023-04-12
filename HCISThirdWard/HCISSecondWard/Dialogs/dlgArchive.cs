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
    public partial class dlgArchive : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public dlgArchive()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var from = txtFrom.Text;
            var to = txtTo.Text;

            if(string.IsNullOrWhiteSpace(txtDossier.Text))
            {
                archiveDashboardBindingSource.DataSource = dc.ArchiveDashboards.Where(x => x.Dossier.Discharge1 != null && x.Dossier.Discharge1.DischargeDate.CompareTo(from) >= 0 && x.Dossier.Discharge1.DischargeDate.CompareTo(to) <= 0 && (x.SecretaryAccept == null || x.SecretaryAccept == false)).ToList();
            }
            else
            {
                archiveDashboardBindingSource.DataSource = dc.ArchiveDashboards.Where(x => x.Dossier.Discharge1 != null && x.Dossier.ID == double.Parse(txtDossier.Text.Trim()) && (x.SecretaryAccept == null || x.SecretaryAccept == false)).ToList();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cuurent = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (cuurent == null)
                return;

            var dlg = new dlgArchiveCheckList();
            dlg.notshow = true;
            dlg.dc = dc;
            dlg.dos = cuurent;
            dlg.ShowDialog();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            var current = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (current == null)
                return;

            memoEdit1.Text = "";
            memoEdit1.Text = current.Comment;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView1.GetSelectedRows())
            {
                var Dos = gridView1.GetRow(item) as ArchiveDashboard;
                Dos.SecretaryAccept = true;
                Dos.SecretaryAcceptDate = MainModule.GetPersianDate(DateTime.Now);
                Dos.SecretaryAcceptTime = DateTime.Now.ToString("HH:mm");
                Dos.SecretaryUserName = MainModule.UserFullName;
                dc.SubmitChanges();
            }
            MessageBox.Show("پرونده ها با موفقیت ارسال شدند");
        }

        private void dlgArchive_Load(object sender, EventArgs e)
        {
            txtTo.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            txtFrom.Text = Classes.MainModule.GetPersianDate(DateTime.Now);
            simpleButton1_Click(null, null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var cur = archiveDashboardBindingSource.Current as ArchiveDashboard;
            if (cur == null)
            {
                MessageBox.Show("ابتدا یک پرونده را مشخص کنید");
                return;
            }
            if (MessageBox.Show("آیا از ثبت اطلاعات اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;
            var from = txtFrom.Text;
            var to = txtTo.Text;
            cur.Comment = memoEdit1.Text; 
            dc.SubmitChanges();
            simpleButton1_Click(null, null);
            MessageBox.Show("توضیحات با موفقیت ثبت شد");
        }
    }
}