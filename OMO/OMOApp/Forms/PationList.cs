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
using OMOApp.Data.HCISData;

namespace OMOApp.Forms
{
    public partial class PationList : DevExpress.XtraEditors.XtraForm
    {
        JamiatClassesDataContext dc = new Data.JamiatClassesDataContext();
        OMOClassesDataContext OMOdc = new Data.OMOClassesDataContext();
        HCISClassesDataContext hdc = new HCISClassesDataContext();

        public Data.PersonTbl PT { get; set; }
        public Data.MemberPhoto MPH { get; set; }
        public Data.Person P { get; set; }
        public string PCode { get; set; }
        public string NationalCode { get; set; }

        private static string FromDate;
        private static string ToDate;

        public PationList()
        {
            InitializeComponent();
        }

        private void PationList_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FromDate))
            {
                FromDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            }
            if (string.IsNullOrWhiteSpace(ToDate))
            {
                ToDate = Classes.MainModule.GetPersianDate(DateTime.Now);
            }
            txtFromDate.Text = FromDate;
            txtToDate.Text = ToDate;

            GetData();
        }

        private void GetData()
        {
          vwvisitDetailBindingSource.DataSource = OMOdc.Vw_visitDetails.Where(c => c.AdmitDate.CompareTo(FromDate) >= 0 && c.AdmitDate.CompareTo(ToDate) <= 0)
                .OrderByDescending(c => c.AdmitDate).ThenByDescending(c => c.AdmitTime).ToList();
            gridControl1.RefreshDataSource();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = vwvisitDetailBindingSource.Current as Vw_visitDetail;
            if (current == null)
                return;

            Classes.MainModule.VST_Set =OMOdc.Visits.FirstOrDefault(x=>x.ID== current.ID);
            barButtonItem1_ItemClick(null, null);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtFromDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text.Length == 10)
            {
                FromDate = txtFromDate.Text;
                GetData();
            }
        }

        private void txtToDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtToDate.Text.Length == 10)
            {
                ToDate = txtToDate.Text;
                GetData();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var current = vwvisitDetailBindingSource.Current as Vw_visitDetail;
            if (current == null)
                return;

           
            barStaticItem1.Caption = current.FirstName;
            barStaticItem2.Caption = current.LastName;
            try
            {
                if (current.Photo != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = current.Photo.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        barEditItem1.EditValue = Image.FromStream(ms);
                    }
                }
                else if (current.Photo == null)
                {
                    barEditItem1.EditValue = null;
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var current = vwvisitDetailBindingSource.Current as Vw_visitDetail;
            if (current == null)
                return;

            Classes.MainModule.VST_Set = OMOdc.Visits.FirstOrDefault(x => x.ID == current.ID);
     
            barButtonItem1_ItemClick(null, null);
        }

        private void btnLabPanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = vwvisitDetailBindingSource.Current as Vw_visitDetail;
            if (current == null)
                return;
            

            if (Classes.MainModule.ConnectToHcis == true)
            {
                var a = new Dialogs.dlgLabPanelList();
                a.ObjectVST =OMOdc.Visits.FirstOrDefault(x=>x.ID== current.ID);
                a.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void btnLabTestList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Classes.MainModule.ConnectToHcis == true)
            {
                var cur = vwvisitDetailBindingSource.Current as Vw_visitDetail;
                if (cur == null)
                    return;

                var gsm = hdc.GivenServiceMs.Where(x => x.Person != null && x.Person.NationalCode == cur.NationalCode && x.ServiceCategoryID == 1).ToList();
                //var TestGSMs = cur.Dossier.GivenServiceMs.Where(c => c.ServiceCategoryID == 1).ToList();

                if (gsm.Count == 0)
                {
                    MessageBox.Show("برای این بیمار آزمایشی ثبت نشده است");
                    return;
                }
                var ff= OMOdc.Visits.FirstOrDefault(x => x.ID == cur.ID);
                var dlg = new Dialogs.dlgAllPateintTest() { dc = hdc, TestGSM = gsm, EditingVisit = ff, ShowLabelPrint = true };
                dlg.ShowDialog();
            }
            else
                MessageBox.Show("امکان وصل شدن به HIS وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void bbiPint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ClearDocument();
            var hf = printableComponentLink1.PageHeaderFooter as DevExpress.XtraPrinting.PageHeaderFooter;
            hf.Header.Content[1] = String.Format("[Image 0]\r\nگزارش وضعیت پرونده ها\r\nاز تاریخ {0} لغایت {1}", txtFromDate.Text, txtToDate.Text);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

        }
    }
}