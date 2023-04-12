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
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Images;
using DevExpress.XtraEditors.Controls;
using HCISEmail.Classes;

namespace HCISEmail.Dialog
{
    public partial class dlgFolder : DevExpress.XtraEditors.XtraForm
    {
        EmaildbDataContext dc = new EmaildbDataContext();
        public dlgFolder()
        {
            InitializeComponent();
        }

        public UserFolder EditingFolder { get; internal set; }
        public bool isEdit { get; internal set; }
        private void btnEnseraf_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTaeid_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                var user = dc.Users.FirstOrDefault(x => x.SecurityUserID == Classes.MainModule.UserID);
                if (user == null)
                {
                    MessageBox.Show("یوزر شما نا مشخص می باشد");
                    return;
                }
                var icon = imcbImage.EditValue.ToString();
                var newfolder = new Folder()
                {
                    Name = txtNfolder.Text,
                    DefaultFolder = false,
                    IconAddress = icon,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm")
                };
                dc.Folders.InsertOnSubmit(newfolder);
                dc.SubmitChanges();
                var newUserFolder = new UserFolder()
                {
                    UserID = 1,
                    FolderID = newfolder.IDFolder,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm")
                };

                dc.UserFolders.InsertOnSubmit(newUserFolder);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private void dlgFolder_Load(object sender, EventArgs e)
        {
            var keys = ImageResourceCache.Default.GetAllResourceKeys().Where(x => !x.StartsWith("svg") && !x.Contains("32x32")).ToList();
            var imgs = keys.Select(x => new { Name = x, Img = ImageResourceCache.Default.GetImage(x) }).OrderBy(x => x.Name).ToList();
            var i = 0;
            imgs.ForEach(x =>
            {
                imageCollection1.AddImage(x.Img, x.Name);
                imcbImage.Properties.Items.Add(new ImageComboBoxItem(x.Name, i));
                i++;
            });

            imcbImage.Properties.SmallImages = imageCollection1;
        }
    }
}