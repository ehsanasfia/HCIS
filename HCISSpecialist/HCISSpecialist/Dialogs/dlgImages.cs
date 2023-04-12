using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSpecialist.Data;
using System.IO;

namespace HCISSpecialist.Dialogs
{

    public partial class dlgImages : DevExpress.XtraEditors.XtraForm
    {
        ImageServerdbmlDataContext Im = new ImageServerdbmlDataContext();
        public string serial { get; set; }
        public List<Study> lstStudy { get; set; }

        public dlgImages()
        {
            InitializeComponent();
        }

        private void dlgImages_Load(object sender, EventArgs e)
        {
            if (lstStudy != null)
                studyBindingSource.DataSource = lstStudy;
            else
                studyBindingSource.DataSource = Im.Studies.Where(x => x.PatientId.Contains(serial)).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var cur = studyBindingSource.Current as Study;
            ShowDicomImage(cur);
        }

        private void ShowDicomImage(Study study)
        {

            try
            {
                CCNaftAhvaz.CCViewerControl ViewerControl = new CCNaftAhvaz.CCViewerControl();
                ViewerControl.StartViewer();
                string StudyOpened = "false";
                int counter = 0;
                while (StudyOpened != "true" && counter++ < 15)
                {
                    StudyOpened = ViewerControl.OpenStudy(study.StudyInstanceUid);
                    System.Threading.Thread.Sleep(1000);
                }
                if (StudyOpened != "true")
                {
                    MessageBox.Show("خطا در نمایش تصویر، لطفاً دوباره سعی کنید.\r\nدر صورتی که پس از سعی مجدد خطا همچنان وجود داشت با مدیر سیستم تماس بگیرید. متن خطا :\r\n" + StudyOpened, "خطا در نمایش تصاویر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    //var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
                    //result += study.StudyInstanceUid;
                    //System.Diagnostics.Process.Start(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در نمایش تصویر، لطفاً دوباره سعی کنید.\r\nدر صورتی که پس از سعی مجدد خطا همچنان وجود داشت با مدیر سیستم تماس بگیرید. متن خطا :\r\n" + ex.Message, "خطا در نمایش تصاویر", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }


            //if (File.Exists(@"C:\DicomViewer\showimage.bat"))
            //{
            //    File.WriteAllText(@"C:\DicomViewer\studyuid.txt", study.StudyInstanceUid);
            //    System.Diagnostics.Process.Start(@"C:\DicomViewer\showimage.bat");
            //}
            //else
            //{
            //    var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
            //    result += study.StudyInstanceUid;
            //    System.Diagnostics.Process.Start(result);
            //}

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = studyBindingSource.Current as Study;
            ShowDicomImage(cur);
        }
    }
}