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
using HCISEmail.Classes;
using DevExpress.XtraNavBar;
using DevExpress.Images;
using System.Security.Cryptography;
using System.IO;
using DevExpress.XtraSplashScreen;
using HCISEmail.Dialog;

namespace HCISEmail.Form
{
    public partial class frmInbox : DevExpress.XtraEditors.XtraForm
    {
        public frmInbox()
        {
            InitializeComponent();
        }

        EmaildbDataContext dc = new EmaildbDataContext();
        SplashScreenManager splashScreenManager2;
        public string MyFolderName { get; set; }
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;
        private void frmNewMail_Load(object sender, EventArgs e)
        {
            splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            splashScreenManager2.ClosingDelay = 500;
            //listi sakhtim.data ra rikhtim to list.agar tedad barabar ba sefr va msg neshon bede dar qeyre in
            //sorat harchi k to list hst bezar to grid
            var lst = dc.sp_Email_Data_Recovery(1, 1).ToList();
            var user = dc.Users.FirstOrDefault(x => x.SecurityUserID == MainModule.UserID);
            if (user == null)
            {
                return;
            }

            navGpPerson.Caption = "کارتابل " + user.FName + " " + user.LName;

            var lstFolders = dc.Folders.Where(x => x.DefaultFolder).ToList();
            lstFolders.AddRange(dc.UserFolders.Where(x => x.UserID == user.IDUser).Select(x => x.Folder).ToList());

            var lstItems = new List<NavBarItem>();
            foreach (var folder in lstFolders)
            {
                var nbi = new NavBarItem() { Caption = folder.Name, Tag = folder };
                if (!string.IsNullOrWhiteSpace(folder.IconAddress))
                {
                    var img = ImageResourceCache.Default.GetImage(folder.IconAddress);
                    nbi.SmallImage = img;
                }

                if (nbi.SmallImage == null)
                {
                    nbi.SmallImage = ImageResourceCache.Default.GetImage("images/business%20objects/bofolder_16x16.png");
                }

                nbi.LinkClicked += NavBarItem_LinkClicked;
                lstItems.Add(nbi);
            }

            navBarControl1.Items.AddRange(lstItems.ToArray());
            navGpPerson.ItemLinks.AddRange(lstItems.Select(x => new NavBarItemLink(x)).ToArray());
            GetData("صندوق دریافت");
            MyFolderName = "صندوق دریافت";
        }

        private void GetData(string Foldername)
        {
            var user = dc.Users.FirstOrDefault(x => x.SecurityUserID == MainModule.UserID);
            if (Foldername == "صندوق دریافت")
                spEmailDataRecoveryResultBindingSource.DataSource = dc.sp_Email_Data_Recovery(user.IDUser, 1);
            else if (Foldername == "صندوق ارسال")
                spEmailDataRecoveryResultBindingSource.DataSource = dc.sp_Email_Data_Recovery(user.IDUser, 2);
            else if (Foldername == "حذف شده ها")
                spEmailDataRecoveryResultBindingSource.DataSource = dc.sp_Email_Data_Recovery(user.IDUser, 4);
            else
                spEmailDataRecoveryResultBindingSource.DataSource = dc.sp_Email_Data_Recovery(user.IDUser, 1).Where(x => x.FolderName == Foldername);
        }

        private void NavBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var nbi = sender as NavBarItem;
            if (nbi == null)
                return;

            var folder = nbi.Tag as Folder;
            if (folder == null)
                return;
            MyFolderName = folder.Name;
            GetData(folder.Name);
        }

        private void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                var frm = new Dialog.dlgMessage();
                frm.dc = dc;
                frm.ShowDialog();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;

            if (current == null)
                return;

            richEditControl1.RtfText = current.Description;
        }

        private void spEmailDataRecoveryResultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            if (current.PrivacyLevel)
            {
                btnPass.Enabled = true;
                return;
            }
            else
            {
                btnPass.Enabled = false;
                lblDateTime.Text = current.CreationDate + " " + current.CreationTime;
                lblFNamLName.Text = current.FName + " " + current.LName;
                lblSubject.Text = current.Subject;
                richEditControl1.RtfText = current.Description;
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow && e.HitInfo.InDataRow)
            {
                if (radialMenu1 == null)
                    return;
                Point pt = this.Location;
                pt.Offset(Cursor.Position.X, Cursor.Position.Y);
                radialMenu1.ShowPopup(pt);
            }
        }

        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            try
            {
                if (e.Column == gridColumn1)
                {
                    object val1 = gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex1, colCreationDate);
                    object val2 = gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex2, colCreationDate);
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(val2, val1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;
            mail.Deleted = true;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelet_ItemClick(null, null);
        }

        private void btnReadunread_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;
            if (mail.Seen)
                mail.Seen = false;
            else
                mail.Seen = true;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;
            if (mail.Seen)
                mail.Seen = false;
            else
                mail.Seen = true;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu1.Collapse(true);
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;

            var dlg = new Dialog.dlgChooseFolder();
            dlg.dc = dc;
            dlg.CurrentEmail = mail;
            dlg.ShowDialog();
        }

        private void btnAnswer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            try
            {
                //Replay
                var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
                if (current == null)
                    return;

                var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
                if (mail == null)
                    return;

                var frm = new Dialog.dlgMessage();
                frm.dc = dc;
                frm.IsReplay = true;
                frm.CurrentEmail = mail;
                frm.Show();
            }
            finally
            {
                splashScreenManager2.CloseWaitForm();
            }
        }

        private void btnGuidance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Forward
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;
            var frm = new Dialog.dlgMessage();
            frm.dc = dc;
            frm.IsForward = true;
            frm.CurrentEmail = mail;
            frm.Show();

        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Fori
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;

            mail.Priority = 14;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Mamoli
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;

            mail.Priority = 17;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Kam
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;

            var mail = dc.EmailUsers.FirstOrDefault(x => x.IDEmailUser == current.IDEmailUser);
            if (mail == null)
                return;

            mail.Priority = 16;
            dc.SubmitChanges();
            GetData(MyFolderName);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItem25_ItemClick(null, null);

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItem32_ItemClick(null, null);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonItem33_ItemClick(null, null);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnAnswer_ItemClick(null, null);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            btnGuidance_ItemClick(null, null);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAnswer_ItemClick(null, null);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGuidance_ItemClick(null, null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var current = spEmailDataRecoveryResultBindingSource.Current as sp_Email_Data_RecoveryResult;
            if (current == null)
                return;
            var dlg = new Dialog.dlgPassword();
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                var password = dlg.pass;
                lblDateTime.Text = current.CreationDate + " " + current.CreationTime;
                lblFNamLName.Text = current.FName + " " + current.LName;
                lblSubject.Text = current.Subject;
                richEditControl1.RtfText = Decrypt(current.Description, password);
            }
            else
                return;
        }
    }
}