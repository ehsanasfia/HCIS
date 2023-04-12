using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Numerics;
using System.Text;
using System.Windows.Forms;


namespace GenerateAndConfirmSerialNumber
{
    public partial class frmGenerateAndConfirm : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public bool Admin { get; set; }
        public frmGenerateAndConfirm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Get HDD hardware code
            string hddCode = GetHDDSerialNumber();

            byte[] hddCodeByte = new byte[hddCode.Length];
            int counter = 0;
            foreach (char element in hddCode.ToArray())
            {
                hddCodeByte[counter] = Convert.ToByte(element.ToString());
                counter++;
            }

            txtRequestCode.Text = Convert.ToBase64String(hddCodeByte);
        }
        private string GetHDDSerialNumber()
        {
            string outs = "";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string a = queryObj["PNPDeviceID"].ToString();

                if (a.Substring(0, 3) != "USB")
                    outs = (queryObj["PNPDeviceID"]).ToString();
            }

            string s = "";
            foreach (char t in outs)
            {
                int i;
                if (int.TryParse(t.ToString(), out i))
                    s += t.ToString();
            }

            return s;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string thisComputerHddSerialNumber = GetHDDSerialNumber();
                byte[] thisComputerRequestCode = new byte[thisComputerHddSerialNumber.Length];
                int counter = 0;
                foreach (char c in thisComputerHddSerialNumber.ToArray())
                {
                    thisComputerRequestCode[counter] = Convert.ToByte(c.ToString());
                    counter++;
                }
                string thisComputerRequestCodeString = Convert.ToBase64String(thisComputerRequestCode);

                byte[] userNumberByte = Convert.FromBase64String(txtRequestCode.Text);
                string userRequestCode = "";
                foreach (byte b in userNumberByte)
                {
                    userRequestCode += b.ToString();
                }
                BigInteger userRequestCodeDouble = BigInteger.Parse(userRequestCode);

                BigInteger p1 = userRequestCodeDouble * userRequestCodeDouble - 2 * userRequestCodeDouble;
                BigInteger p2 = (userRequestCodeDouble - 2) * (userRequestCodeDouble - 1);
                BigInteger p3 = (userRequestCodeDouble + 2 * userRequestCodeDouble);

                string[] parts = txtSerialNumber.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                BigInteger p1c = BigInteger.Parse(parts[0]);
                BigInteger p2c = BigInteger.Parse(parts[1]);
                BigInteger p3c = BigInteger.Parse(parts[2]);


                if (p1c == p1 && p2c == p2 && p3c == p3 && thisComputerRequestCodeString == txtRequestCode.Text)
                {
                    var Ser = dc.SerialNumbers.FirstOrDefault(x => x.RequestNumber == txtRequestCode.Text.Trim());
                    if (Ser == null)
                    {
                        var newSerialNumber = new SerialNumber()
                        {
                            RequestNumber = txtRequestCode.Text.Trim(),
                            SerialNumber1 = txtSerialNumber.Text.Trim(),
                            Confirmation = true
                        };
                        dc.SerialNumbers.InsertOnSubmit(newSerialNumber);
                        dc.SubmitChanges();
                    }
                    else if (Ser.Confirmation != true || string.IsNullOrWhiteSpace(Ser.SerialNumber1))
                    {
                        Ser.SerialNumber1 = txtSerialNumber.Text.Trim();
                        Ser.Confirmation = true;
                        dc.SubmitChanges();
                    }

                    MessageBox.Show("OK!");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("شماره سریال اشتباه میباشد");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("لطفا دوباره امتحان کنید");
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmGenerateAndConfirm_Load(object sender, EventArgs e)
        {
            Admin = true;
            if (Admin)
            {
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                txtRequestCode.ReadOnly = false;
            }
            else
            {
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                txtRequestCode.ReadOnly = true;
            }
            simpleButton1_Click(null, null);
            var Ser = dc.SerialNumbers.FirstOrDefault(x => x.RequestNumber == txtRequestCode.Text.Trim());
            if (Ser != null)
                if (Ser.Confirmation)
                    DialogResult = DialogResult.OK;
                else if (Ser == null)
                {
                    var newSerialNumber = new SerialNumber()
                    {
                        RequestNumber = txtRequestCode.Text.Trim()
                    };
                    dc.SerialNumbers.InsertOnSubmit(newSerialNumber);
                    dc.SubmitChanges();
                }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            byte[] requestCodeByte = Convert.FromBase64String(txtRequestCode.Text);
            string requestCode = string.Empty;

            foreach (byte b in requestCodeByte)
            {
                requestCode += b.ToString();
            }

            BigInteger requestCodeDouble = BigInteger.Parse(requestCode);

            BigInteger p1 = requestCodeDouble * requestCodeDouble - 2 * requestCodeDouble;
            BigInteger p2 = (requestCodeDouble - 2) * (requestCodeDouble - 1);
            BigInteger p3 = (requestCodeDouble + 2 * requestCodeDouble);

            txtSerialNumber.Text = string.Format("{0}-{1}-{2}", p1, p2, p3);
        }
    }
}
