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
using HCISEmail.Data;

namespace HCISEmail.Form
{
    public partial class frmFolder : DevExpress.XtraEditors.XtraForm
    {
        EmaildbDataContext dc = new EmaildbDataContext();

        public frmFolder()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new Dialog.dlgFolder();
            frm.ShowDialog();
            GetData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curentFolder = userFolderBindingSource.Current as UserFolder;
            if (curentFolder == null)
                return;
            var frmnew = new Dialog.dlgFolder();
            frmnew.isEdit = true;
            frmnew.EditingFolder = curentFolder;
            GetData();
        }

        private void GetData()
        {
            var user = dc.Users.FirstOrDefault(x => x.SecurityUserID == Classes.MainModule.UserID);
            if (user == null)
                return;
            userFolderBindingSource.DataSource = dc.UserFolders.Where(x => x.UserID == user.IDUser);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmFolder_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}