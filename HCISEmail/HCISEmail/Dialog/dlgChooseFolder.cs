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

namespace HCISEmail.Dialog
{
    public partial class dlgChooseFolder : DevExpress.XtraEditors.XtraForm
    {
        public EmaildbDataContext dc { get; set; }
        public EmailUser CurrentEmail { get; set; }
        public dlgChooseFolder()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var cur = userFolderBindingSource.Current as UserFolder;
            if (cur == null || CurrentEmail == null)
                return;

            CurrentEmail.FolderID = cur.FolderID;
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void dlgChooseFolder_Load(object sender, EventArgs e)
        {
            userFolderBindingSource.DataSource = dc.UserFolders.Where(x => x.UserID == CurrentEmail.ToUserID).ToList();
        }
    }
}