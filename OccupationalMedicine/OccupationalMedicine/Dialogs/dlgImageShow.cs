using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgImageShow : DevExpress.XtraEditors.XtraForm
    {
        public System.Data.Linq.Binary bin { get; set; }
        public Image img { get; set; }
        public bool HasDocument
        {
            get
            {
                return picSpi.Image != null;
            }
        }
        public dlgImageShow()
        {
            InitializeComponent();
        }

        private void dlgImageShow_Load(object sender, EventArgs e)
        {
            if (bin != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = bin.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    picSpi.Image = Image.FromStream(ms);
                }
            }
            else if (img != null)
            {
                picSpi.Image = img;
            }
            else
            {
                picSpi.Image = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            picSpi.Image = null;
        }
    }
}