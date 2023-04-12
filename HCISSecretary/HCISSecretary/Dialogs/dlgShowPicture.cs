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
using HCISSecretary.Data;
using System.IO;

namespace HCISSecretary.Dialogs
{
    public partial class dlgShowPicture : DevExpress.XtraEditors.XtraForm
    {

       // public PatientInfo_tbl getPic { get; set; }
        public System.Data.Linq.Binary binary { get; set; }
        public Image image { get; set; }
        public dlgShowPicture()
        {
            InitializeComponent();
        }

        private void dlgShowPicture_Load(object sender, EventArgs e)
        {
            if (binary != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = binary.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pictureEdit1.Image = Image.FromStream(ms);
                }
            }
            else if (image != null)
                pictureEdit1.Image = image;
            else
                pictureEdit1.Image = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}