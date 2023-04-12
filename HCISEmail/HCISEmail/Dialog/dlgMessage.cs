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
using HCISEmail.Classes;
using System.Security.Cryptography;
using System.IO;

namespace HCISEmail.Dialog
{
    public partial class dlgMessage : DevExpress.XtraEditors.XtraForm
    {
        public EmaildbDataContext dc { get; set; }
        public bool IsForward { get; set; }
        public bool IsReplay { get; set; }
        public EmailUser CurrentEmail { get; set; }

        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public dlgMessage()
        {
            InitializeComponent();
            lkpErsalbe.Properties.View.SelectionChanged += View_SelectionChanged;
        }

        private void dlgMessage_Load(object sender, EventArgs e)
        {
            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 13);
            toggleParagraphRightToLeftItem1.PerformClick();
            toggleParagraphAlignmentRightItem1.PerformClick();
            ConditionValidationRule rangeValidationRule = new ConditionValidationRule();
            rangeValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            rangeValidationRule.ErrorType = ErrorType.Critical;
            rangeValidationRule.ErrorText = "این فیلد را پرکنید";
            dxValidationProvider1.SetValidationRule(txtSubject, rangeValidationRule);
            dxValidationProvider1.SetValidationRule(lkpErsalbe, rangeValidationRule);
            dxValidationProvider1.SetValidationRule(richEditmozo, rangeValidationRule);
            if (!IsReplay)
            {
                var lstUsers = dc.Users.ToList();
                userBindingSource.DataSource = lstUsers;
            }
            if (IsForward)
            {
                txtSubject.Text = CurrentEmail.Email.Subject;
                richEditmozo.RtfText = CurrentEmail.Email.Description;
            }

            else if (IsReplay)
            {
                var lstUsers = dc.Users.Where(x => x.IDUser == CurrentEmail.Email.UserID).ToList();
                userBindingSource.DataSource = lstUsers;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = dc.Users.FirstOrDefault(x => x.SecurityUserID == Classes.MainModule.UserID);
            if (user == null)
            {
                MessageBox.Show("یوزر شما نا مشخص می باشد");
                return;
            }
            var NewMail = new Email()
            {
                UserID = user.IDUser,
                Subject = txtSubject.Text,
                Description = richEditmozo.RtfText,
                CreationDate = MainModule.GetPersianDate(DateTime.Now),
                CreationTime = DateTime.Now.ToString("HH:mm"),
                PrivacyLevel = true
            };
            if (chkEncrypt.Checked == false)
                NewMail.Description = richEditmozo.RtfText;

            if (chkEncrypt.Checked == true)
            {
                var dlg = new Dialog.dlgPassword();
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    var password = dlg.pass;
                    NewMail.Description = Encrypt(richEditmozo.RtfText, password);
                }
                else
                    return;
            }

            if (IsForward)
                NewMail.Forward = CurrentEmail.Email.UserID;

            if (IsReplay)
                NewMail.Replay = CurrentEmail.EmailID;
            dc.Emails.InsertOnSubmit(NewMail);

            foreach (var item in lkpErsalbe.Properties.View.GetSelectedRows())
            {
                var row = lkpErsalbe.Properties.View.GetRow(item) as User;
                var priority = lookUpEdit1.EditValue as Definition;
                
                var newEmailuser = new EmailUser()
                {
                    Email = NewMail,
                    Priority = priority == null ? 17 : priority.IDDefinition,
                    ToUserID = row.IDUser,
                    CreationDate = MainModule.GetPersianDate(DateTime.Now),
                    CreationTime = DateTime.Now.ToString("HH:mm")
                };
                dc.EmailUsers.InsertOnSubmit(newEmailuser);
            }
            dc.SubmitChanges();
        }

        private void View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            var displaymember = "";
            foreach (var item in lkpErsalbe.Properties.View.GetSelectedRows())
            {
                var row = lkpErsalbe.Properties.View.GetRow(item) as User;
                displaymember += row.LName + ",";
            }
            lkpErsalbe.Properties.NullText = displaymember.ToString();
            lkpErsalbe.ShowPopup();
        }
        private void lkpErsalbe_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpErsalbe.EditValue != null)
                lkpErsalbe.EditValue = null;
        }

        private void dlgMessage_Shown(object sender, EventArgs e)
        {
            if (IsReplay)
            {
                lkpErsalbe.ShowPopup();
                lkpErsalbe.Properties.View.SelectRow(lkpErsalbe.Properties.View.GetRowHandle(0));
                //lkpErsalbe.Properties.View.SelectAll();
                lkpErsalbe.ClosePopup();
            }
        }

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
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

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
