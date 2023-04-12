using Sep.Pc2Pos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sep.Pc2Pos.Desktop.Tester
{
    
    public partial class MainForm : Form
    {
       

        #region Fields
        //private PosClient _PosClientRS232;
        //private PosClientLan _PosClientLan;

        private PosClientBase _posClient;

        private MediaType _mediaType;
        private AccountType _accountType;
        private ClientLanguage _language;

        private string _AuthorizationId;

       

        private Dictionary<string, string> PrintList;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void InitializeForm()
        {
            int defaultListenPort = 1197;

            if (PrintList == null)
                PrintList = new Dictionary<string, string>();

            #region Gridview
            PrintList.Add("1", " ");
            PrintList.Add("2", " ");
            PrintList.Add("3", " ");
            PrintList.Add("4", " ");
            PrintList.Add("5", " ");
            PrintList.Add("6", " ");
            PrintList.Add("7", " ");
            PrintList.Add("8", " ");
            PrintList.Add("9", " ");
            grdViewPrintItem.AllowUserToAddRows = true;
            grdViewPrintItem.DataSource = PrintList.Values.ToList();
            grdViewPrintItem.Columns["Length"].Visible = false;

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Name = "Alignment";
            col.DataSource = Enum.GetValues(typeof(Alignment));
            col.ValueType = typeof(Alignment);
            col.Width = 60;
            grdViewPrintItem.Columns.Add(col);

            col = new DataGridViewComboBoxColumn();
            col.Name = "ReceiptType";
            col.DataSource = Enum.GetValues(typeof(ReceiptType));
            col.ValueType = typeof(ReceiptType);
            col.Width = 80;
            grdViewPrintItem.Columns.Add(col);


            grdViewPrintItem.Rows[0].Cells["Item"].Value = "آیتم شماره 1";
            grdViewPrintItem.Rows[0].Cells["Value"].Value = "123";
            grdViewPrintItem.Rows[0].Cells["Alignment"].Value = Alignment.Right;
            grdViewPrintItem.Rows[0].Cells["ReceiptType"].Value = ReceiptType.Customer;

            grdViewPrintItem.Rows[1].Cells["Item"].Value = "آیتم شماره 2";
            grdViewPrintItem.Rows[1].Cells["Value"].Value = "456";
            grdViewPrintItem.Rows[1].Cells["Alignment"].Value = Alignment.Right;
            grdViewPrintItem.Rows[1].Cells["ReceiptType"].Value = ReceiptType.Merchant;

            grdViewPrintItem.Rows[2].Cells["Item"].Value = "آیتم شماره 3";
            grdViewPrintItem.Rows[2].Cells["Value"].Value = "789";
            grdViewPrintItem.Rows[2].Cells["Alignment"].Value = Alignment.Left;
            grdViewPrintItem.Rows[2].Cells["ReceiptType"].Value = ReceiptType.Both;

            grdViewPrintItem.Rows[3].Cells["Item"].Value = "آیتم شماره 4";
            grdViewPrintItem.Rows[3].Cells["Value"].Value = "";
            grdViewPrintItem.Rows[3].Cells["Alignment"].Value = Alignment.Center;
            grdViewPrintItem.Rows[3].Cells["ReceiptType"].Value = ReceiptType.Both;
            #endregion

            Text = string.Format("PC to POS (Version: {0})", Assembly.GetAssembly(typeof(PosClientBase)).GetName().Version);
            numAmount.Value = 1000;

            //Find IPs
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            cmbIP.DataSource = ipHostInfo.AddressList;
            cmbIP.SelectedIndex = 0;

            cmbMediaType.DataSource = Enum.GetValues(typeof(MediaType))
                                            .Cast<MediaType>()
                                            .Select(v => v.ToString())
                                            .ToList();
            cmbMediaType.SelectedIndex = 1;
            
            cmbAccountsType.DataSource = Enum.GetValues(typeof(AccountType))
                                           .Cast<AccountType>()
                                           .Select(v => v.ToString())
                                           .ToList();

            cmbAccountsType.SelectedIndex = 0;

            cmbLanguage.DataSource = Enum.GetValues(typeof(ClientLanguage))
                                           .Cast<ClientLanguage>()
                                           .Select(v => v.ToString())
                                           .ToList();
            cmbLanguage.SelectedIndex = 1;

            txtPort.Text = defaultListenPort.ToString();

            //Create PosClientBase instance
            if (_posClient == null)
            {
                _posClient = new PosClientBase();
            }
            //Assign Events
            _posClient.CardSwiped += _PosClient_CardSwiped;
            _posClient.PosResultReceived += _PosClient_PosResultReceived;
            _posClient.ErrorReceived += _PosClient_ErrorReceived;

            txtStatus.Text = "Ready.";

        }
        private void StartTransaction()
        {
            int port;
            string portName = "";
            string ip = "";
            ClientLanguage lang;
            SerialPort selectedPort = null;

            if (SerialPort.GetPortNames().Any(p => p == cmbPort.SelectedItem.ToString()))
                selectedPort = new SerialPort((string)cmbPort.SelectedItem);

            if (string.IsNullOrEmpty(txtPort.Text) && _mediaType == MediaType.Network)
            {
                MessageBox.Show("There is no value for Port in configurations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedPort == null && _mediaType == MediaType.COM)
            {
                MessageBox.Show("There is no selected Port in configurations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_mediaType == MediaType.COM)
                portName = selectedPort.PortName;

            try
            {
                port = Int32.Parse(txtPort.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter numeric value for port in configurations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ip = cmbIP.SelectedItem.ToString();
            if (_posClient == null)
            {
                _posClient = new PosClientBase();
            }
            if (_mediaType == MediaType.Network)
                _posClient.Init(_accountType, _language, port, ip);
            else if (_mediaType == MediaType.COM)
                _posClient.Init(_accountType, _language, portName);





            //timeout = 10 sec
            _posClient.WaitForPos(0);
        }
        private void LoadComPorts()
        {
            string defaultPort = "COM5";

            cmbPort.DataSource = System.IO.Ports.SerialPort.GetPortNames();

            if (((string[])cmbPort.DataSource).Count() > 0)
                cmbPort.SelectedIndex = 0;

            if (((string[])cmbPort.DataSource).Any(s => s == defaultPort))
                cmbPort.SelectedItem = defaultPort;
        }
        private void ResetForm()
        {
            txtPAN.Text = "######-**-####";
            numAmount.Value = 1000;
            txtResponseCode.Clear();
            txtMessage.Clear();
            txtPAN2.Text = txtPAN.Text;
            txtTraceNumber.Clear();
            txtTerminalID.Clear();
            txtSersialId.Clear();
            txtRRN.Clear();
            txtTerminalID1.Clear();
            picResult.Image = null;
            pnlResult.Enabled = false;
            progressBar.Visible = false;
            txtStatus.Text = "Ready.";
            btnStart.Focus();
            lstBoxAmounts.Items.Clear();
            numSumAmount.Value = 0;
            numAmount.Value = 1000;
            numAddAmount.Value = 1000;
            pnlSwipeCard.Enabled = true;
            txtPIdAmt.Clear();
            dataGridViewPurchase.Rows.Clear();
        }
        private void GetReady()
        {
            txtPAN.Text = "######-**-####";
            numAmount.Value = 1000;
            txtResponseCode.Clear();
            txtMessage.Clear();
            txtPAN2.Text = txtPAN.Text;
            txtTraceNumber.Clear();
            txtTerminalID.Clear();
            txtSersialId.Clear();
            txtRRN.Clear();
            txtTerminalID1.Clear();
            picResult.Image = null;
            pnlResult.Enabled = false;
            pnlSwipeCard.Enabled = false;
            lstBoxAmounts.Items.Clear();
            numSumAmount.Value = 0;
            numAmount.Value = 1000;
            numAddAmount.Value = 1000;

        }
        private string GetMasked(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return string.Empty;

            if (pan.Length == 16)
            {
                return pan.Substring(0, 6) + "-**-" + pan.Substring(pan.Length - 4, 4);
            }
            else if (pan.Length == 19)
            {
                if (pan.Substring(16, 3) != "000")
                    return pan.Substring(0, 6) + "-**-" + pan.Substring(pan.Length - 4, 4);
                else
                    return pan.Substring(0, 6) + "-**-" + pan.Substring(pan.Length - 7, 4);
            }
            else
            {
                return pan;
            }
        }
        private void ResultReceived(PosResultEventArgs e)
        {
            //Successful result
            if (e!= null && e.IsSuccessful && e.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(
                        new MethodInvoker(
                            () =>
                            {
                                txtStatus.Text =
                                    string.Format("Successful Transaction. Trace#: \"{0}\", Authorization ID: \"{1}\"",
                                        e.TraceNumber, e.AuthorizationId);
                            }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\", Authorization ID: \"{1}\"",
                        e.TraceNumber, e.AuthorizationId);
                }
            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(
                        new MethodInvoker(
                            () => { txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", e.SerialId); }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", e.SerialId);
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = e.ResponseCode;
                    txtMessage.Text = e.ResponseDescription;
                    txtPAN2.Text = GetMasked(e.ReturnPAN);
                    txtTraceNumber.Text = e.TraceNumber;
                    txtTerminalID.Text = e.TerminalID;
                    txtSersialId.Text = e.SerialId;
                    txtRRN.Text = e.RRN;

                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                    pnlStart.Enabled = true;
                    btnStart.Focus();
                }));
            else
            {
                txtResponseCode.Text = e.ResponseCode;
                txtMessage.Text = e.ResponseDescription;
                txtPAN2.Text = GetMasked(e.ReturnPAN);
                txtTraceNumber.Text = e.TraceNumber;
                txtTerminalID.Text = e.TerminalID;
                txtSersialId.Text = e.SerialId;
                txtRRN.Text = e.RRN;
                pnlResult.Enabled = true;
                progressBar.Visible = false;
                pnlStart.Enabled = true;
                btnStart.Focus();
            }

            if (_posClient != null)
                _posClient.Dispose();
        }
        #endregion

        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadComPorts();
        }
        private void _PosClient_CardSwiped(IPCPOS sender, CardSwipedEventArgs e)
        {
            string maskedPan = GetMasked(e.CardNumber);
            _AuthorizationId = e.AuthorizationId;
            Debug.WriteLine("ThreadID4: " + Thread.CurrentThread.ManagedThreadId);
            if (txtPAN.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    GetReady();
                    txtPAN.Text = maskedPan;
                    txtTerminalID1.Text = e.TerminalId;
                    progressBar.Visible = false;
                    txtStatus.Text = string.Format("Card swiped with \"{0}\" card number, and Authorization ID is: \"{1}\"", GetMasked(e.CardNumber), _AuthorizationId);
                    pnlSwipeCard.Enabled = true;
                    btnSendAmount.Focus();
                    if (chkAutoAmount.Checked)
                        btnSendAmount.PerformClick();
                }));
            else
            {

                GetReady();
                txtPAN.Text = maskedPan;
                txtTerminalID1.Text = e.TerminalId;
                progressBar.Visible = false;
                txtStatus.Text = string.Format("Card swiped with \"{0}\" card number, and Authorization ID is: \"{1}\"", GetMasked(e.CardNumber), _AuthorizationId);
                pnlSwipeCard.Enabled = true;
                btnSendAmount.Focus();
                if (chkAutoAmount.Checked)
                    btnSendAmount.PerformClick();
            }
        }
        private void _PosClient_PosResultReceived(IPCPOS sender, PosResultEventArgs e)
        {
            ResultReceived(e);
        }
        private void _PosClient_ErrorReceived(IPCPOS sender, ErrorReceivedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    pnlResult.Enabled = true;
                    txtPAN2.Text = "######-**-####";
                    txtTraceNumber.Clear();
                    txtTerminalID.Clear();
                    txtSersialId.Clear();
                    txtRRN.Clear();
                    txtStatus.Text = string.Format("Transaction failed. Error Code: \"{0}\", Error Message: \"{1}\"", e.ErrorCode, e.ErrorDescription);
                    txtResponseCode.Text = e.ErrorCode;
                    txtMessage.Text = e.ErrorDescription;
                    picResult.Image = Resource.Failed;
                    pnlStart.Enabled = true;
                    pnlSwipeCard.Enabled = false;
                    progressBar.Visible = false;
                    btnStart.Focus();
                }));
            else
            {
                pnlResult.Enabled = true;
                txtPAN2.Text = "######-**-####";
                txtTraceNumber.Clear();
                txtTerminalID.Clear();
                txtSersialId.Clear();
                txtRRN.Clear();
                txtStatus.Text = string.Format("Transaction failed. Error Code: \"{0}\", Error Message: \"{1}\"", e.ErrorCode, e.ErrorDescription);
                txtResponseCode.Text = e.ErrorCode;
                txtMessage.Text = e.ErrorDescription;
                picResult.Image = Resource.Failed;
                pnlStart.Enabled = true;
                progressBar.Visible = false;
                pnlSwipeCard.Enabled = false;
                btnStart.Focus();
            }
            if (_posClient != null)
                _posClient.Dispose();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComPorts();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (radioButtonMultiPurchase.Checked)
            {
                int line = dataGridViewPurchase.RowCount;

                if (line == 1)
                {
                    System.Windows.Forms.MessageBox.Show("لطفا اطلاعات مربوط به شناسه خرید را وارد نمایید", "", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
            }
            StartTransaction();
            progressBar.Visible = true;
            pnlStart.Enabled = false;
            GetReady();
            txtStatus.Text = "Waiting for EFT-POS to swipe the card...";
            btnAddAmount.Enabled = true;
            txtPIdAmt.Clear();//amount in purchase id case
           
            //return true;
        }
        private void btnSendAmount_Click(object sender, EventArgs e)
        {
            List<string> lstAmnts = new List<string>();
            List<PrintItemResult> prntItemResults = new List<PrintItemResult>();

            //txtPIdAmt.Clear();

            if (radioButton1.Checked)
            {
                string PurchaseID = null;
                //  if (txtPurchaseID.TextLength == 30)
                // {
                PurchaseID = txtPurchaseID.Text;
               
                // }
                if ((txtPurchaseID.TextLength != 30) && (txtPurchaseID.TextLength != 0))//s.hosseini
                {
                    System.Windows.Forms.MessageBox.Show("شناسه خرید باید خالی و یا 30 رقم باشد", "", System.Windows.Forms.MessageBoxButtons.OK);
                    // return;
                }


                foreach (DataGridViewRow dr in grdViewPrintItem.Rows)
                {
                    var item = dr.Cells["Item"].Value == null ? "" : dr.Cells["Item"].Value.ToString();
                    var value = dr.Cells["Value"].Value == null ? "" : dr.Cells["Value"].Value.ToString();
                    var alignment = dr.Cells["Alignment"].Value == null ? "" : dr.Cells["Alignment"].Value.ToString();
                    var receiptType = dr.Cells["ReceiptType"].Value == null ? "" : dr.Cells["ReceiptType"].Value.ToString();
                    if (alignment == "")
                        alignment = "Center";
                    if (receiptType == "")
                        receiptType = "Both";
                    if (item != "")
                    {
                          prntItemResults.Add(new PrintItemResult(item, value,
                          (Alignment) Enum.Parse(typeof (Alignment), alignment, true),
                          (ReceiptType) Enum.Parse(typeof (ReceiptType), receiptType, true)));
                    }
                    else
                        break;
                }
           
                if (_accountType == AccountType.Single)
                {
                    lstAmnts.Add(numAmount.Value.ToString());
                    _posClient.SendAmount(lstAmnts, _AuthorizationId, prntItemResults, 0, PurchaseID);
                }

                else
                {
                    lstAmnts.AddRange(lstBoxAmounts.Items.Cast<string>().ToList());
                    lstAmnts.Add(numSumAmount.Value.ToString());
                    _posClient.SendAmount(lstAmnts, _AuthorizationId, prntItemResults, 0, PurchaseID);
                }
            }//s.hosseini for multi purchase
            else
            {
                
                string GridPurchaseID = null;
                int j = 0, i = 0;
                int line = dataGridViewPurchase.RowCount;
                string Amnt = null, Iban = null;
                //string SumAmn = null;
                //  if (txtPurchaseID.TextLength == 30)
                int SumAmn1 = 0;
                string SumAmn = null;
                string PurchaseID = null;
                //if (line == 1)
                //{
                //    System.Windows.Forms.MessageBox.Show("لطفا اطلاعات مربوط به شناسه خرید را وارد نمایید", "", System.Windows.Forms.MessageBoxButtons.OK);
                //    return;
                //}
                for (i = 0; i < line - 1; i++)
                {
                    GridPurchaseID = dataGridViewPurchase.Rows[i].Cells[0].Value.ToString();
                    Amnt = dataGridViewPurchase.Rows[i].Cells[1].Value.ToString();
                    Iban = dataGridViewPurchase.Rows[i].Cells[2].Value.ToString();
                    string PA = GridPurchaseID + ":" + Amnt + ":" + Iban + ";";
                    //txtMultiPurchase.Text = txtMultiPurchase.Text + PA;
                    PurchaseID = PurchaseID + PA;
                }



               for (j = 0; j < dataGridViewPurchase.Rows.Count; j++)
                {
                    SumAmn1 += Convert.ToInt32(dataGridViewPurchase.Rows[j].Cells[1].Value);
                   
               }
               SumAmn = SumAmn1.ToString();
                foreach (DataGridViewRow dr in grdViewPrintItem.Rows)
                {
                    var item = dr.Cells["Item"].Value == null ? "" : dr.Cells["Item"].Value.ToString();
                    var value = dr.Cells["Value"].Value == null ? "" : dr.Cells["Value"].Value.ToString();
                    var alignment = dr.Cells["Alignment"].Value == null ? "" : dr.Cells["Alignment"].Value.ToString();
                    var receiptType = dr.Cells["ReceiptType"].Value == null ? "" : dr.Cells["ReceiptType"].Value.ToString();
                    if (alignment == "")
                        alignment = "Center";
                    if (receiptType == "")
                        receiptType = "Both";
                    if (item != "")
                    {
                         prntItemResults.Add(new PrintItemResult(item, value,
                         (Alignment) Enum.Parse(typeof (Alignment), alignment, true),
                         (ReceiptType) Enum.Parse(typeof (ReceiptType), receiptType, true)));
                    }
                    else
                        break;
                }
                txtPIdAmt.Text = SumAmn;
 
                if (_accountType == AccountType.Single)
                {
                   
                    _posClient.SendAmountMultiPurchase(SumAmn, _AuthorizationId, prntItemResults, 0, PurchaseID);
                }

                else
                {
                    lstAmnts.AddRange(lstBoxAmounts.Items.Cast<string>().ToList());
                    lstAmnts.Add(numSumAmount.Value.ToString());
                    _posClient.SendAmount(lstAmnts, _AuthorizationId, prntItemResults, 0, PurchaseID);
                }
            }//
            pnlSwipeCard.Enabled = false;
            progressBar.Visible = true;
            txtStatus.Text = string.Format("Waiting for ETF-POS to respond. \"{0}\" as spent amount, sent to EFT-POS for payment. Authorization ID is: \"{1}\"", numAmount.Value.ToString(), _AuthorizationId);
        }
        private void btnAddAmount_Click(object sender, EventArgs e)
        {
            lstBoxAmounts.Items.Add(numAddAmount.Value.ToString());
            if (lstBoxAmounts.Items.Count == 10)
                btnAddAmount.Enabled = false;
            lstBoxAmounts.SelectedIndex = lstBoxAmounts.Items.Count - 1;
            numSumAmount.Value = 0;
            if (lstBoxAmounts != null && lstBoxAmounts.Items != null)
                lstBoxAmounts.Items.Cast<string>().ToList().ForEach(x => numSumAmount.Value += Int32.Parse(x));
        }
        private void btnRemoveAmount_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstBoxAmounts.SelectedIndex;

            try
            {
                lstBoxAmounts.Items.RemoveAt(selectedIndex);
                if (lstBoxAmounts.Items.Count < 10)
                    btnAddAmount.Enabled = true;
                lstBoxAmounts.SelectedIndex = lstBoxAmounts.Items.Count - 1;

                numSumAmount.Value = 0;
                if (lstBoxAmounts != null && lstBoxAmounts.Items != null)
                    lstBoxAmounts.Items.Cast<string>().ToList().ForEach(x => numSumAmount.Value += Int32.Parse(x));
            }
            catch
            {
            }
        }
        private void picLogo_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://sep.ir/");
            Process.Start(sInfo);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            pnlStart.Enabled = true;
            ResetForm();
            _posClient.Dispose();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedValue).ToString() == MediaType.COM.ToString())
            {
                _mediaType = MediaType.COM;
                txtPort.Enabled = false;
                cmbPort.Enabled = true;
                btnRefresh.Enabled = true;
                cmbIP.Enabled = false;
            }
            else if (((sender as ComboBox).SelectedValue).ToString() == MediaType.Network.ToString())
            {
                _mediaType = MediaType.Network;
                txtPort.Enabled = true;
                cmbPort.Enabled = false;
                btnRefresh.Enabled = false;
                cmbIP.Enabled = true;
            }
            //else
            //{
            //    _MediaType = MediaType.None;
            //    txtPort.Enabled = false;
            //    cmbPort.Enabled = false;
            //    btnRefresh.Enabled = false;
            //}
        }
        private void cmbAccountsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == AccountType.Single.ToString())
            {
                _accountType = AccountType.Single;
                tabCtrlAmounts.SelectedTab = tabCtrlAmounts.TabPages[0];
                chkAutoAmount.Enabled = true;
            }
            else if ((sender as ComboBox).SelectedItem.ToString() == AccountType.Share.ToString())
            {
                _accountType = AccountType.Share;
                tabCtrlAmounts.SelectedTab = tabCtrlAmounts.TabPages[1];
                chkAutoAmount.Enabled = false;
            }
        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem.ToString() == ClientLanguage.English.ToString())
            {
                _language = ClientLanguage.English;
            }
            else if (comboBox != null && comboBox.SelectedItem.ToString() == ClientLanguage.Persian.ToString())
            {
                _language = ClientLanguage.Persian;
            }
        }

        private void btnBlockingSendAmount_Click(object sender, EventArgs e)  //s.hosseini
        {
            List<string> lstAmnts = new List<string>();
            List<PrintItemResult> prntItemResults = new List<PrintItemResult>();

            if (radioButton1.Checked)
            {
                string PurchaseID = null; //s.hosseini
                // if (txtPurchaseID.TextLength == 30)
                // {
                PurchaseID = txtPurchaseID.Text;
                // }
                if ((txtPurchaseID.TextLength != 30) && (txtPurchaseID.TextLength != 0))//s.hosseini
                {
                    System.Windows.Forms.MessageBox.Show("شناسه خرید باید خالی و یا 30 رقم باشد", "", System.Windows.Forms.MessageBoxButtons.OK);
                    // return;
                }
                // 
                progressBar.Visible = true;
                foreach (DataGridViewRow dr in grdViewPrintItem.Rows)
                {
                    var item = dr.Cells["Item"].Value == null ? "" : dr.Cells["Item"].Value.ToString();
                    var value = dr.Cells["Value"].Value == null ? "" : dr.Cells["Value"].Value.ToString();
                    var alignment = dr.Cells["Alignment"].Value == null ? "" : dr.Cells["Alignment"].Value.ToString();
                    var receiptType = dr.Cells["ReceiptType"].Value == null ? "" : dr.Cells["ReceiptType"].Value.ToString();
                    if (alignment == "")
                        alignment = "Center";
                    if (receiptType == "")
                        receiptType = "Both";
                    if (item != "")
                    {
                        prntItemResults.Add(new PrintItemResult(item, value,
                            (Alignment)Enum.Parse(typeof(Alignment), alignment, true),
                            (ReceiptType)Enum.Parse(typeof(ReceiptType), receiptType, true)));
                    }
                    else
                        break;
                }
                tabMain.Enabled = false;
                PosResultEventArgs posResult = null;
                StartTransaction();
                if (_accountType == AccountType.Single)
                {
                    lstAmnts.Add(numAmount.Value.ToString(CultureInfo.InvariantCulture));
                    posResult = _posClient.BlockingTransaction(lstAmnts, prntItemResults, 60, PurchaseID);//s.hosseini
                }

                else
                {
                    foreach (var item in lstBoxAmounts.Items)
                    {
                        lstAmnts.Add(item.ToString());
                    }
                    lstAmnts.Add(numSumAmount.Value.ToString(CultureInfo.InvariantCulture));
                    posResult = _posClient.BlockingTransaction(lstAmnts, prntItemResults, 0, PurchaseID);//s.hosseini
                }
                tabMain.Enabled = true;

                pnlSwipeCard.Enabled = false;
                progressBar.Visible = false;

                ResultReceived(posResult);
            }
            else if (radioButtonMultiPurchase.Checked)
            {
                string GridPurchaseID = null;
                int j = 0, i = 0;
                int line = dataGridViewPurchase.RowCount;
                string Amnt = null, Iban = null;
                //string SumAmn = null;
                //  if (txtPurchaseID.TextLength == 30)
                int SumAmn1 = 0;
                string SumAmn = null;
                string PurchaseID = null;
                if (line == 1)
                {
                    System.Windows.Forms.MessageBox.Show("لطفا اطلاعات مربوط به شناسه خرید را وارد نمایید", "", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
                for (i = 0; i < line - 1; i++)
                {
                    GridPurchaseID = dataGridViewPurchase.Rows[i].Cells[0].Value.ToString();
                    Amnt = dataGridViewPurchase.Rows[i].Cells[1].Value.ToString();
                    Iban = dataGridViewPurchase.Rows[i].Cells[2].Value.ToString();
                    string PA = GridPurchaseID + ":" + Amnt + ":" + Iban + ";";
                    //txtMultiPurchase.Text = txtMultiPurchase.Text + PA;
                    PurchaseID = PurchaseID + PA;
                }



                for (j = 0; j < dataGridViewPurchase.Rows.Count; j++)
                {
                    SumAmn1 += Convert.ToInt32(dataGridViewPurchase.Rows[j].Cells[1].Value);

                }
                SumAmn = SumAmn1.ToString();
                progressBar.Visible = true;
                foreach (DataGridViewRow dr in grdViewPrintItem.Rows)
                {
                    var item = dr.Cells["Item"].Value == null ? "" : dr.Cells["Item"].Value.ToString();
                    var value = dr.Cells["Value"].Value == null ? "" : dr.Cells["Value"].Value.ToString();
                    var alignment = dr.Cells["Alignment"].Value == null ? "" : dr.Cells["Alignment"].Value.ToString();
                    var receiptType = dr.Cells["ReceiptType"].Value == null ? "" : dr.Cells["ReceiptType"].Value.ToString();
                    if (alignment == "")
                        alignment = "Center";
                    if (receiptType == "")
                        receiptType = "Both";
                    if (item != "")
                    {
                        prntItemResults.Add(new PrintItemResult(item, value,
                            (Alignment)Enum.Parse(typeof(Alignment), alignment, true),
                            (ReceiptType)Enum.Parse(typeof(ReceiptType), receiptType, true)));
                    }
                    else
                        break;
                }
                txtPIdAmt.Text = SumAmn;
                tabMain.Enabled = false;
                PosResultEventArgs posResult = null;
                StartTransaction();
                if (_accountType == AccountType.Single)
                {
                   // lstAmnts.Add(numAmount.Value.ToString(CultureInfo.InvariantCulture));
                    posResult = _posClient.BlockingTransactionMultiPurchase(SumAmn, prntItemResults, 60, PurchaseID);//s.hosseini
                }

                tabMain.Enabled = true;

                pnlSwipeCard.Enabled = false;
                progressBar.Visible = false;

                ResultReceived(posResult);
            }
        }
        private void tabSyncType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ese = sender as TabControl;
            if (ese != null && ese.SelectedIndex == 1) //Sync
            {
                btnSendAmount.Visible = false;
                this.pnlSwipeCard.Enabled = true;
            }

            else if (ese != null && ese.SelectedIndex == 0) //Async
            {
                btnSendAmount.Visible = true;
                this.pnlSwipeCard.Enabled = true;
            }
        }

        #endregion

        private void txtSersialId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseID_TextChanged(object sender, EventArgs e)
        {

        }
        //s.hosseini added for purchaseID
        private void txtPurchaseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&  (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                System.Windows.Forms.MessageBox.Show("لطفا فقط عدد وارد نمایید", "", System.Windows.Forms.MessageBoxButtons.OK);
            }
          
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int l = dataGridViewPurchase.RowCount;
            string k = dataGridViewPurchase.Rows[1].Cells[1].Value.ToString();     
            dataGridViewPurchase.Rows[1].Cells[1].Value.ToString();
        }

        private void pnlConfiguration_Paint(object sender, PaintEventArgs e)
        {

        }
        //s.hosseini added for multi purchase
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb1 = sender as RadioButton;
            if (rb1.Checked == true)
            {
              
                txtPurchaseID.Enabled = true;
                label14.Enabled = true;
                dataGridViewPurchase.Enabled = false;
                dataGridViewPurchase.Rows.Clear();
                }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb2 = sender as RadioButton;
            if (rb2.Checked == true)
            { 
                dataGridViewPurchase.Enabled = true;
                txtPurchaseID.Enabled = false;
                txtPurchaseID.Text = "";
                label14.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewPurchase.Rows.Clear();
           // string PurchaseID,Amnt;
           // int line = dataGridViewPurchase.RowCount;
           // int i = 0,j = 0;
           // int SumAmn = 0;
           // string Iban ="";
           // txtMultiPurchase.Text = "";
            
           // for (i = 0; i < line-1; i++)
           // {
           //     PurchaseID = dataGridViewPurchase.Rows[i].Cells[0].Value.ToString();
           //     Amnt = dataGridViewPurchase.Rows[i].Cells[1].Value.ToString();
           //     Iban = dataGridViewPurchase.Rows[i].Cells[2].Value.ToString();
           //     string PA = PurchaseID + ":" + Amnt + ":" + Iban + ";";
           //     txtMultiPurchase.Text = txtMultiPurchase.Text + PA;
               
           // }
            
           // for ( j = 0; j < dataGridViewPurchase.Rows.Count; ++j)
           // {
           //     SumAmn += Convert.ToInt32(dataGridViewPurchase.Rows[j].Cells[1].Value);
           // }
           //// txtMultiPurchase.Text = txtMultiPurchase.Text.Remove(txtMultiPurchase.Text.Length - 1);//todo
           //// dataGridViewPurchase.Rows.Clear();
           // label15.Text = SumAmn.ToString();
           //// _MSumAmt = SumAmn.ToString(); ;
           //   // string SumAmn1 =  SumAmn.ToString();
           // //Common. = SumAmn.ToString();

             
        }

     
        //

    }
}
