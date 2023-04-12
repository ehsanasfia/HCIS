using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDentist.Data;

namespace HCISDentist.Dialogs
{
    
    public partial class dlgImages : DevExpress.XtraEditors.XtraForm
    {
        imageDataContext Im = new imageDataContext();
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
            var result = "http://192.168.4.251/ImageServer/Pages/Studies/View/Default.aspx?aetitle=MAINSERVER,study=";
            result += cur.StudyInstanceUid;
            System.Diagnostics.Process.Start(result);
        }
    }
}