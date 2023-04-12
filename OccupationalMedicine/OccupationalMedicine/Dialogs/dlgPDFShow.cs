using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OccupationalMedicine.Forms;
using System.Data.Linq;
using System.IO;
using DevExpress.Pdf;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgPDFShow : DevExpress.XtraEditors.XtraForm
    {
        public Binary bin { get; set; }
        public bool HasDocument { get; set; }
        public dlgPDFShow()
        {
            InitializeComponent();
        }

        private void dlgFileShow_Load(object sender, EventArgs e)
        {
            if (bin != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = bin.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pdfViewer1.LoadDocument(ms);
                    HasDocument = true;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            pdfViewer1.CloseDocument();
            HasDocument = false;
        }

        private void btnPrintDpf_Click(object sender, EventArgs e)
        {

          //  PdfPrinterSettings g = new PdfPrinterSettings();
            pdfViewer1.Print();
        }
    }
}