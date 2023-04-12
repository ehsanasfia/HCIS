using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDefinitions.Data;
using System.IO;

namespace HCISDefinitions.Dialogs
{
    public partial class dlgClient : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        ClientConfig CC;

        public dlgClient()
        {
            InitializeComponent();
        }

        private void dlgClient_Load(object sender, EventArgs e)
        {          
            clientConfigBindingSource.DataSource = dc.ClientConfigs.OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CC == null)
                CC = new ClientConfig();

            if (pic.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap objBitmap = new Bitmap(pic.Image, 120, 120);

                    objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var binary = new System.Data.Linq.Binary(ms.GetBuffer());
                    CC.ReportImage = binary;
                }
            }
            else
                CC.ReportImage = null;

            CC.Name = txtName.Text.Trim();
            CC.ReportTitle = mmTitr.Text.Trim();

            if(CC.ID == Guid.Empty)
                dc.ClientConfigs.InsertOnSubmit(CC);

            dc.SubmitChanges();
            MessageBox.Show("تغییرات با موفقیت ثبت شد.","توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            CC = null;
            txtName.Text = null;
            mmTitr.Text = null;
            pic.Image = null;

            clientConfigBindingSource.DataSource = dc.ClientConfigs.OrderBy(c => c.Name).ToList();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks >= 2)
            {
                var obj = clientConfigBindingSource.Current as ClientConfig;
                CC = obj;
                if (CC.ReportImage != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        var data = CC.ReportImage.ToArray();
                        ms.Write(data, 0, data.Length);
                        ms.Flush();
                        pic.EditValue = Image.FromStream(ms);
                    }
                }
                else
                    pic.EditValue = null;

                txtName.Text = CC.Name;
                mmTitr.Text = CC.ReportTitle;
            }
        }
    }
}