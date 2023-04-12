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
using System.IO;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgPicture : DevExpress.XtraEditors.XtraForm
    {
        public System.Data.Linq.Binary bin { get; set; }
        public Image img { get; set; }
        public dlgPicture()
        {
            InitializeComponent();
        }

        private void dlgPicture_Load(object sender, EventArgs e)
        {
            if (bin != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var data = bin.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    pic.Image = Image.FromStream(ms);
                }
            }
            else if (img != null)
                pic.Image = img;
            else
                pic.Image = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pic.Image = null;
            Close();
        }
    }
}