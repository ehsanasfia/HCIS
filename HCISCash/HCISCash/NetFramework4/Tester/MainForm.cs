using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sep.Pc2Pos.Desktop.Tester;
using SSP1126.PcPos;
using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System.Security.Cryptography;

namespace SSP1126.Pc2Pos.Desktop.Tester
{
    public partial class MainForm : Form
    {

        #region Fields

        private PcPosFactory _PcPosFactory;
        private MediaType _mediaType;
        private AccountType _accountType;
        private ResponseLanguage _responseLanguage;
        private AsyncType _asyncType;

        private ReportAction _reportAction;
        private ReportFilterType _reportFilterType;

        private Dictionary<string, string> PrintList;

        private TransactionType _tracsactionType;
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
            GetReady();

            if (PrintList == null)
                PrintList = new Dictionary<string, string>();

            #region Additional Data
            txtAdditionalData.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                          "<List>" +
                                          "<print>" +
                                          "<item>123</item>" +
                                          "<value>a</value>" +
                                          "<alignment>0</alignment>" +
                                          "<receipttype>0</receipttype>" +
                                          "</print>" +
                                          "<print>" +
                                          "<item>456</item>" +
                                          "<value>c</value>" +
                                          "<alignment>1</alignment>" +
                                          "<receipttype>1</receipttype>" +
                                          "</print>" +
                                          "</List>";
            txtAdditionalDataBill.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                        "<List>" +
                                        "<print>" +
                                        "<item>123</item>" +
                                        "<value>a</value>" +
                                        "<alignment>0</alignment>" +
                                        "<receipttype>0</receipttype>" +
                                        "</print>" +
                                        "<print>" +
                                        "<item>456</item>" +
                                        "<value>c</value>" +
                                        "<alignment>1</alignment>" +
                                        "<receipttype>1</receipttype>" +
                                        "</print>" +
                                        "</List>";
            txtAdditionalDataMCI.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                        "<List>" +
                                        "<print>" +
                                        "<item>123</item>" +
                                        "<value>a</value>" +
                                        "<alignment>0</alignment>" +
                                        "<receipttype>0</receipttype>" +
                                        "</print>" +
                                        "<print>" +
                                        "<item>456</item>" +
                                        "<value>c</value>" +
                                        "<alignment>1</alignment>" +
                                        "<receipttype>1</receipttype>" +
                                        "</print>" +
                                        "</List>";
            txtAdditionalDataTCI.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                        "<List>" +
                                        "<print>" +
                                        "<item>123</item>" +
                                        "<value>a</value>" +
                                        "<alignment>0</alignment>" +
                                        "<receipttype>0</receipttype>" +
                                        "</print>" +
                                        "<print>" +
                                        "<item>456</item>" +
                                        "<value>c</value>" +
                                        "<alignment>1</alignment>" +
                                        "<receipttype>1</receipttype>" +
                                        "</print>" +
                                        "</List>";
            txtAdditionalDataCharge.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                        "<List>" +
                                        "<print>" +
                                        "<item>123</item>" +
                                        "<value>a</value>" +
                                        "<alignment>0</alignment>" +
                                        "<receipttype>0</receipttype>" +
                                        "</print>" +
                                        "<print>" +
                                        "<item>456</item>" +
                                        "<value>c</value>" +
                                        "<alignment>1</alignment>" +
                                        "<receipttype>1</receipttype>" +
                                        "</print>" +
                                        "</List>";
            //txtAdditionalDataSrvPay.Text = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            //                          "<List>" +
            //                          "<print>" +
            //                          "<item>123</item>" +
            //                          "<value>a</value>" +
            //                          "<alignment>0</alignment>" +
            //                          "<receipttype>0</receipttype>" +
            //                          "</print>" +
            //                          "<print>" +
            //                          "<item>456</item>" +
            //                          "<value>c</value>" +
            //                          "<alignment>1</alignment>" +
            //                          "<receipttype>1</receipttype>" +
            //                          "</print>" +
            //                          "</List>";
            #endregion

            Text = string.Format("PC to POS (Version: {0})", Assembly.GetAssembly(typeof(PcPosFactory)).GetName().Version);
            numAmountPurchase.Value = 1000;

            cmbMediaType.DataSource = Enum.GetValues(typeof(MediaType))
                                            .Cast<MediaType>()
                                            .Select(v => v.ToString())
                                            .ToList();
            cmbMediaType.SelectedIndex = 0;

            cmbAccountsType.DataSource = Enum.GetValues(typeof(AccountType))
                                           .Cast<AccountType>()
                                           .Select(v => v.ToString())
                                           .ToList();

            cmbAccountsType.SelectedIndex = 0;

            cmbLanguage.DataSource = Enum.GetValues(typeof(ResponseLanguage))
                                         .Cast<ResponseLanguage>()
                                         .Select(v => v.ToString())
                                         .ToList();

            cmbLanguage.SelectedIndex = 0;

            cmbAsyncType.DataSource = Enum.GetValues(typeof(AsyncType))
                                         .Cast<AsyncType>()
                                         .Select(v => v.ToString())
                                         .ToList();

            cmbAsyncType.SelectedIndex = 1;//Avand changes it from 0

            cmbBillType.DataSource = Enum.GetValues(typeof(PhoneBillType))
                                      .Cast<PhoneBillType>()
                                      .Select(v => v.ToString())
                                      .ToList();

            cmbBillType.SelectedIndex = 0;

            cmbTCIBillType.DataSource = Enum.GetValues(typeof(PhoneBillType))
                                    .Cast<PhoneBillType>()
                                    .Select(v => v.ToString())
                                    .ToList();

            cmbTCIBillType.SelectedIndex = 0;

            cmbReportTransactionType.DataSource = Enum.GetValues(typeof(ReportAction))
                                   .Cast<ReportAction>()
                                   .Select(v => v.ToString())
                                   .ToList();

            cmbReportTransactionType.SelectedIndex = 0;

            cmbReportFilterType.DataSource = Enum.GetValues(typeof(ReportFilterType))
                                  .Cast<ReportFilterType>()
                                  .Select(v => v.ToString())
                                  .ToList();

            cmbReportFilterType.SelectedIndex = 0;


            tabMain.SelectedTab = tabPurchase;

            if (_PcPosFactory == null)
                _PcPosFactory = new PcPosFactory();

            //Assign Events
            _PcPosFactory.CardSwiped += _PosClient_CardSwiped;
            _PcPosFactory.PosResultReceived += _PosClient_PosResultReceived;

            txtStatus.Text = "Ready.";

        }

        /// <summary>
        /// Find Active SSP1126 ComPorts 
        /// </summary>
       private  void    DetectPorts()
        {
            List<string> ports=new List<string>();
            progressBar.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            foreach (var port in System.IO.Ports.SerialPort.GetPortNames().Reverse())
            {
                try
                {                    
                    ResetResult();
                    _PcPosFactory.SetCom(port);
                    _PcPosFactory.Initialization(_responseLanguage, 0, AsyncType.Sync);                    
                    PosResult posResult = _PcPosFactory.ConnectionTest();
                    if (posResult.ResponseCode=="00")
                    {
                        ports.Add(port);
                        break;
                    }
                }
                catch (Exception)
                {                    
                }
            }
            cmbPort.DataSource = ports;
            Cursor.Current = Cursors.Default;
            //MessageBox.Show(ports.Aggregate(new StringBuilder(),(sb, val) => sb.AppendLine(val),sb => sb.ToString())+ " is connected");
        }
       /// <summary>
       /// Find Active ComPorts 
       /// </summary>
        private void LoadComPorts()
        {
            string defaultPort = "COM4";

            cmbPort.DataSource = System.IO.Ports.SerialPort.GetPortNames();

            if (((string[])cmbPort.DataSource).Count() > 0)
                cmbPort.SelectedIndex = 0;

            if (((string[])cmbPort.DataSource).Any(s => s == defaultPort))
                cmbPort.SelectedItem = defaultPort;
        }
        private void ResetForm()
        {
            pnlSwipeCardPurchase.Enabled = true;
            txtPANPurchase.Text = "######-**-####";
            numAmountPurchase.Value = 1000;
            txtResponseCode.Clear();
            txtMessage.Clear();
            txtCardNumberMask.Text = txtPANPurchase.Text;
            txtCardNumberHash.Clear();
            txtTraceNumber.Clear();
            txtTerminalID.Clear();
            txtSersialId.Clear();
            txtTerminalID1Purchase.Clear();
            picResult.Image = null;
            pnlResult.Enabled = false;
            progressBar.Visible = false;
            txtStatus.Text = "Ready.";
            btnStartPurchase.Focus();
            lstBoxAmountsPurchase.Items.Clear();
            numSumAmountPurchase.Value = 0;
            numAmountPurchase.Value = 1000;
            numAddAmountPurchase.Value = 1000;
            pnlStartBalance.Enabled = true;
            txtAmount.Clear();
            txtAffectiveAmount.Clear();
            pnlBill.Enabled = true;
            txtBillAmount.Clear();
            txtBillType.Clear();
            txtPayID.Clear();
            txtBillID.Clear();
            //txtMCINumber.Clear();
            //txtTopupMobileNumber.Clear();
            txtChargePin.Clear();
            txtChargeEergencyNum.Clear();
            txtChargeSerial.Clear();
            txtTransactionDate.Clear();
            txtPOS_Version.Clear();
            txtRRN.Clear();
            grpPurchaseTypes.Controls.Clear();
            txtHashPanSha1.Clear();
            txtHashPanSha2.Clear();
            txtTCINumber.Clear();
            chkBill.Checked = false;
            chkMCIBill.Checked = false;
            chkPinCharge.Checked = false;
            chkTopup.Checked = false;
            chkPurchase.Checked = false;
            chkReport.Checked = false;
            chkBalance.Checked = false;
            chkTCIBill.Checked = false;
            chkSrvPayment.Checked = false;
            btnAddAmountPurchase.Enabled = true;
            ClearGroupBox(grpSrvPay);
        }
        private void ResetResult()
        {
            pnlResult.Enabled = false;
            txtResponseCode.Clear();
            txtMessage.Clear();
            txtCardNumberMask.Text = txtPANPurchase.Text;
            txtCardNumberHash.Clear();
            txtTraceNumber.Clear();
            txtTerminalID.Clear();
            txtSersialId.Clear();
            txtAmount.Clear();
            txtAffectiveAmount.Clear();
            picResult.Image = null;
            progressBar.Visible = false;
            txtStatus.Text = "Ready.";
            txtTransactionDate.Clear();
            txtPOS_Version.Clear();
            txtRRN.Clear();
        }
        private void GetReady()
        {
            txtPANPurchase.Text = "######-**-####";
            numAmountPurchase.Value = 1000;
            txtResponseCode.Clear();
            txtMessage.Clear();
            txtCardNumberMask.Text = txtPANPurchase.Text;
            txtCardNumberHash.Clear();
            txtTraceNumber.Clear();
            txtTerminalID.Clear();
            txtSersialId.Clear();
            txtTerminalID1Purchase.Clear();
            picResult.Image = null;
            pnlResult.Enabled = false;
            pnlSwipeCardPurchase.Enabled = true;
            lstBoxAmountsPurchase.Items.Clear();
            numSumAmountPurchase.Value = 0;
            numAmountPurchase.Value = 1000;
            numAddAmountPurchase.Value = 1000;
            pnlBill.Enabled = true;
            txtTransactionDate.Clear();
            txtPOS_Version.Clear();
            txtRRN.Clear();
        }
        private bool TransactionMediaInitialization()
        {
            if (_mediaType == MediaType.Com)
            {
                SerialPort selectedPort = null;

                if (SerialPort.GetPortNames().Any(p => p == cmbPort.SelectedItem.ToString()))
                    selectedPort = new SerialPort((string)cmbPort.SelectedItem);
                if (selectedPort == null)
                {
                    MessageBox.Show("There is no selected Port in configurations.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }
                _PcPosFactory.SetCom(selectedPort.PortName);
            }
            if (_mediaType == MediaType.Network)
            {
                if (string.IsNullOrEmpty(txtPosIP.Text))
                {
                    MessageBox.Show("There is no value for Pos IP in configurations.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }
                _PcPosFactory.SetLan(txtPosIP.Text);
            }

            _PcPosFactory.Initialization(_responseLanguage, 0, _asyncType);

            txtStatus.Text = "Waiting for EFT-POS...";
            return false;
        }
        private void BalanceResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                            posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                        posResult.TraceNumber);
                }
            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"",
                            posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtRRN.Text = posResult.RRN;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtSersialId.Text = posResult.SerialId;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtCardNumberMask.Text = posResult.CardNumberMask;
                txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                txtTraceNumber.Text = posResult.TraceNumber;
                txtTransactionDate.Text = posResult.TxnDate;
                txtRRN.Text = posResult.RRN;
                txtTerminalID.Text = posResult.TerminalId;
                txtSersialId.Text = posResult.SerialId;
                txtAmount.Text = posResult.ReqAmount;
                txtAffectiveAmount.Text = posResult.AffectiveAmount;
                pnlResult.Enabled = true;
                progressBar.Visible = false;
            }
        }
        private void PurchaseCardSwiped(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (txtPANPurchase.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    GetReady();
                    txtPANPurchase.Text = posResult.CardNumberMask;
                    txtHashPanSha1.Text = posResult.CardNumberHash_Sha1;
                    txtHashPanSha2.Text = posResult.CardNumberHash_Sha2;
                    txtTerminalID1Purchase.Text = posResult.TerminalId;
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    progressBar.Visible = false;
                    txtStatus.Text =
                        string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);

                    // Show Segment Types
                    int y = 17;
                    if (posResult.PurchaseTypesDictionary != null)
                    {
                        foreach (var item in posResult.PurchaseTypesDictionary)
                        {
                            var radio = new RadioButton();
                            radio.Text = item.Value;
                            radio.Tag = item.Key;
                            radio.Location = new Point(5, y);
                            radio.CheckedChanged += Radio_CheckedChanged;
                            y = y + 20;
                            grpPurchaseTypes.Controls.Add(radio);
                        }
                    }
                    pnlSwipeCardPurchase.Enabled = true;
                    btnSendAmountPurchase.Focus();
                }));
            else
            {
                GetReady();
                txtPANPurchase.Text = posResult.CardNumberMask;
                txtHashPanSha1.Text = posResult.CardNumberHash_Sha1;
                txtHashPanSha2.Text = posResult.CardNumberHash_Sha2;
                txtTerminalID1Purchase.Text = posResult.TerminalId;
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                progressBar.Visible = false;
                txtStatus.Text =
                    string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);

                // Show Segment Types
                int y = 17;
                if (posResult.PurchaseTypesDictionary != null)
                {
                    foreach (var item in posResult.PurchaseTypesDictionary)
                    {
                        var radio = new RadioButton();
                        radio.Text = item.Value;
                        radio.Tag = item.Key;
                        radio.Location = new Point(5, y);
                        radio.CheckedChanged += Radio_CheckedChanged;
                        y = y + 20;
                        grpPurchaseTypes.Controls.Add(radio);
                    }
                }
                pnlSwipeCardPurchase.Enabled = true;
                btnSendAmountPurchase.Focus();
            }
        }
        private void PurchaseResultReceived(PosResult posResult)
        {
            ClearGroupBox(grpSrvPay);
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                }

            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtRRN.Text = posResult.RRN;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtSersialId.Text = posResult.SerialId;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;

                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                    pnlStartPurchase.Enabled = true;
                    btnStartPurchase.Focus();
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtCardNumberMask.Text = posResult.CardNumberMask;
                txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                txtTraceNumber.Text = posResult.TraceNumber;
                txtTransactionDate.Text = posResult.TxnDate;
                txtRRN.Text = posResult.RRN;
                txtTerminalID.Text = posResult.TerminalId;
                txtSersialId.Text = posResult.SerialId;
                txtAmount.Text = posResult.ReqAmount;
                txtAffectiveAmount.Text = posResult.AffectiveAmount;

                pnlResult.Enabled = true;
                progressBar.Visible = false;
                pnlStartPurchase.Enabled = true;
                btnStartPurchase.Focus();
            }
        }
        private void BillPaymentResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                            posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                        posResult.TraceNumber);
                }
            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"",
                            posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtRRN.Text = posResult.RRN;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtSersialId.Text = posResult.SerialId;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;
                    txtBillType.Text = posResult.BillType;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtCardNumberMask.Text = posResult.CardNumberMask;
                txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                txtTraceNumber.Text = posResult.TraceNumber;
                txtTransactionDate.Text = posResult.TxnDate;
                txtRRN.Text = posResult.RRN;
                txtTerminalID.Text = posResult.TerminalId;
                txtSersialId.Text = posResult.SerialId;
                txtAmount.Text = posResult.ReqAmount;
                txtAffectiveAmount.Text = posResult.AffectiveAmount;
                txtBillType.Text = posResult.BillType;
                pnlResult.Enabled = true;
                progressBar.Visible = false;
            }
        }
        private void BillPropertiesResultReceived(PosResult posResult)
        {
            if (posResult != null)
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtBillAmount.Text = posResult.BillAmount;
                        txtBillType.Text = posResult.BillType;
                        txtResponseCode.Text = posResult.ResponseCode;
                        txtMessage.Text = posResult.ResponseDescription;
                        pnlResult.Enabled = true;
                        progressBar.Visible = false;
                    }));
                else
                {
                    txtBillAmount.Text = posResult.BillAmount;
                    txtBillType.Text = posResult.BillType;
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                }
            }
        }
        private void GenerateBillResultReceived(PosResult posResult)
        {
            if (posResult != null)
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtBillID.Text = posResult.BillId;
                        txtPayID.Text = posResult.PayId;
                    }));
                else
                {
                    txtBillID.Text = posResult.BillId;
                    txtPayID.Text = posResult.PayId;
                }
            }
        }
        private void PhoneBillPropertiesResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                            posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                        posResult.TraceNumber);
                }
            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"",
                            posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }
            if (posResult != null)
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtResponseCode.Text = posResult.ResponseCode;
                        txtMessage.Text = posResult.ResponseDescription;
                        txtCardNumberMask.Text = posResult.CardNumberMask;
                        txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                        txtTraceNumber.Text = posResult.TraceNumber;
                        txtTransactionDate.Text = posResult.TxnDate;
                        txtRRN.Text = posResult.RRN;
                        txtTerminalID.Text = posResult.TerminalId;
                        txtSersialId.Text = posResult.SerialId;
                        txtAmount.Text = posResult.ReqAmount;
                        txtAffectiveAmount.Text = posResult.AffectiveAmount;
                        pnlResult.Enabled = true;
                        progressBar.Visible = false;
                    }));
                else
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtRRN.Text = posResult.RRN;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtSersialId.Text = posResult.SerialId;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                }
            }
        }
        private void PhoneBillPaymentResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                            posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"",
                        posResult.TraceNumber);
                }
            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"",
                            posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }
            if (posResult != null)
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtResponseCode.Text = posResult.ResponseCode;
                        txtMessage.Text = posResult.ResponseDescription;
                        txtCardNumberMask.Text = posResult.CardNumberMask;
                        txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                        txtTransactionDate.Text = posResult.TxnDate;
                        txtTerminalID.Text = posResult.TerminalId;
                        txtTraceNumber.Text = posResult.TraceNumber;
                        txtSersialId.Text = posResult.SerialId;
                        txtRRN.Text = posResult.RRN;
                        txtAmount.Text = posResult.ReqAmount;
                        txtAffectiveAmount.Text = posResult.AffectiveAmount;
                        pnlResult.Enabled = true;
                        progressBar.Visible = false;
                    }));
                else
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtSersialId.Text = posResult.SerialId;
                    txtRRN.Text = posResult.RRN;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                }
            }
        }

        private void DrawPaymentsItems(PosResult posResult)
        {
            int y = 17;
            if (posResult.PurchaseTypesDictionary != null)
            {
                foreach (var item in posResult.PurchaseTypesDictionary)
                {
                    byte gap = 50;
                    var _title = new Label();
                    _title.Name = "lbl_PaymentService_" + item.Key.ToString();
                    _title.Text = item.Value;
                    _title.Width = 200;
                    _title.Tag = item.Key;
                    _title.Location = new Point(5, y);
                    //_title.AutoSize = true;
                    _title.Parent = grpSrvPay;
                    grpSrvPay.Controls.Add(_title);


                    var _txtPrice = new NumericUpDown();
                    _title.Name = item.Key.ToString();
                    _txtPrice.Enter += _txtBox_Enter;
                    _txtPrice.Leave += _txt_Leave;
                    _txtPrice.Width = 150;
                    _txtPrice.Maximum = 9999999999999;
                    _txtPrice.ThousandsSeparator = true;
                    _txtPrice.Location = new Point(5 + _title.Width + gap, y);
                    _txtPrice.KeyPress += _txtPrice_KeyPress;
                    _txtPrice.Tag = item.Key;
                    _txtPrice.Parent = grpSrvPay;
                    grpSrvPay.Controls.Add(_txtPrice);
                    y = y + 30;
                }
            }
        }
        private void PaymentServiceCardSwiped(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (txtPANPurchase.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    GetReady();
                    txtPANPurchase.Text = posResult.CardNumberMask;
                    txtHashPanSha1.Text = posResult.CardNumberHash_Sha1;
                    txtHashPanSha2.Text = posResult.CardNumberHash_Sha2;
                    txtTerminalID1Purchase.Text = posResult.TerminalId;
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    progressBar.Visible = false;
                    txtStatus.Text =string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);
                    ClearGroupBox(grpSrvPay);
                    // Show Segment Types
                    DrawPaymentsItems(posResult);
                    pnlSwipeCardPurchase.Enabled = true;
                    btnSendAmountPurchase.Focus();
                }));
            else
            {
                GetReady();
                txtPANPurchase.Text = posResult.CardNumberMask;
                txtHashPanSha1.Text = posResult.CardNumberHash_Sha1;
                txtHashPanSha2.Text = posResult.CardNumberHash_Sha2;
                txtTerminalID1Purchase.Text = posResult.TerminalId;
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                progressBar.Visible = false;
                txtStatus.Text =
                    string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);

                // Show Segment Types
                DrawPaymentsItems(posResult);               
                pnlSwipeCardPurchase.Enabled = true;
                btnSendAmountPurchase.Focus();
            }
        }

        void _txt_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = Color.White;
            }
            else if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = Color.White;
            }
            else
            {
                // etc
            }

        }

        void _txtBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = Color.Yellow;
            }
            else if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = Color.Yellow;
            }
            else
            {
                // etc
            }

        }

        void _txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ChargeResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                }

            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtCardNumberMask.Text = posResult.CardNumberMask;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTraceNumber.Text = posResult.TraceNumber;
                    txtTransactionDate.Text = posResult.TxnDate;
                    txtRRN.Text = posResult.RRN;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtSersialId.Text = posResult.SerialId;
                    txtAmount.Text = posResult.ReqAmount;
                    txtAffectiveAmount.Text = posResult.AffectiveAmount;
                    txtChargePin.Text = posResult.ChargePin;
                    txtChargeEergencyNum.Text = posResult.ChargeEmergencyNumber;
                    txtChargeSerial.Text = posResult.ChargeSerial;

                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                    pnlStartPurchase.Enabled = true;
                    btnStartPurchase.Focus();
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtCardNumberMask.Text = posResult.CardNumberMask;
                txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                txtTraceNumber.Text = posResult.TraceNumber;
                txtTransactionDate.Text = posResult.TxnDate;
                txtRRN.Text = posResult.RRN;
                txtTerminalID.Text = posResult.TerminalId;
                txtSersialId.Text = posResult.SerialId;
                txtAmount.Text = posResult.ReqAmount;
                txtAffectiveAmount.Text = posResult.AffectiveAmount;
                txtChargePin.Text = posResult.ChargePin;
                txtChargeEergencyNum.Text = posResult.ChargeEmergencyNumber;
                txtChargeSerial.Text = posResult.ChargeSerial;

                pnlResult.Enabled = true;
                progressBar.Visible = false;
                pnlStartPurchase.Enabled = true;
                btnStartPurchase.Focus();
            }
        }
        private void ReportResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                }

            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtReportOutput.Text = posResult.ReportXml;

                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                    pnlStartPurchase.Enabled = true;
                    btnStartPurchase.Focus();
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtTerminalID.Text = posResult.TerminalId;
                txtReportOutput.Text = posResult.ReportXml;

                pnlResult.Enabled = true;
                progressBar.Visible = false;
                pnlStartPurchase.Enabled = true;
                btnStartPurchase.Focus();
            }
        }
        private void GetAuthorizedOperationsResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                }

            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    chkBill.Checked = posResult.IsBillValidOperation;
                    chkMCIBill.Checked = posResult.IsMCIBillValidOperation;
                    chkPinCharge.Checked = posResult.IsPinChargeValidOperation;
                    chkTopup.Checked = posResult.IsTopupChargeValidOperation;
                    chkPurchase.Checked = posResult.IsPurchaseValidOperation;
                    chkReport.Checked = posResult.IsGetReportValidOperation;
                    chkBalance.Checked = posResult.IsBalanceValidOperation;
                    chkTCIBill.Checked = posResult.IsTCIBillValidOperation;
                    chkSrvPayment.Checked = posResult.IsPaymentServiceOperation;
                    txtPOS_Version.Text = posResult.POS_Version;
                    pnlResult.Enabled = true;
                    progressBar.Visible = false;
                    pnlStartPurchase.Enabled = true;
                    btnStartPurchase.Focus();
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                chkBill.Checked = posResult.IsBillValidOperation;
                chkMCIBill.Checked = posResult.IsMCIBillValidOperation;
                chkPinCharge.Checked = posResult.IsPinChargeValidOperation;
                chkTopup.Checked = posResult.IsTopupChargeValidOperation;
                chkPurchase.Checked = posResult.IsPurchaseValidOperation;
                chkReport.Checked = posResult.IsGetReportValidOperation;
                chkBalance.Checked = posResult.IsBalanceValidOperation;
                chkTCIBill.Checked = posResult.IsTCIBillValidOperation;
                chkSrvPayment.Checked = posResult.IsPaymentServiceOperation;
                txtPOS_Version.Text = posResult.POS_Version;
                pnlResult.Enabled = true;
                progressBar.Visible = false;
                pnlStartPurchase.Enabled = true;
                btnStartPurchase.Focus();
            }
        }
        private void GetEchoTestResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                picResult.Image = Resource.Successful;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Successful Transaction.");
                    }));
                else
                {
                    txtStatus.Text = string.Format("Successful Transaction");
                }

            }
            else
            {
                picResult.Image = Resource.Error;
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtStatus.Text = string.Format("Transaction Error");
                    }));
                else
                {
                    txtStatus.Text = string.Format("Transaction Error");
                }
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    txtResponseCode.Text = posResult.ResponseCode;
                    txtMessage.Text = posResult.ResponseDescription;
                    txtTerminalID.Text = posResult.TerminalId;
                }));
            else
            {
                txtResponseCode.Text = posResult.ResponseCode;
                txtMessage.Text = posResult.ResponseDescription;
                txtTerminalID.Text = posResult.TerminalId;
            }
        }
        #endregion

        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadComPorts();

            //txtPosIP.Text = "192.168.14.106";
            txtMCINumber.Text = "09122375008";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComPorts();
        }
        private void picLogo_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://sep.ir/");
            Process.Start(sInfo);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            pnlStartPurchase.Enabled = true;
            ResetForm();
            _PcPosFactory.Dispose();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            _PcPosFactory.Dispose();
            this.Close();
        }

        #region Dll
        private void _PosClient_CardSwiped(PosResult posResult)
        {
            _tracsactionType = _PcPosFactory.GetTransactionType();

            if (_tracsactionType == TransactionType.Purchase)
            {
                #region Purchase

                PurchaseCardSwiped(posResult);

                #endregion
            }
            else if (_tracsactionType == TransactionType.PaymentService)
            {
                #region PaymentService

                PaymentServiceCardSwiped(posResult);

                #endregion
            }
            else
            {
                string maskedPan = posResult.CardNumberMask;
                if (txtPANPurchase.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        txtCardNumberMask.Text = maskedPan;
                        txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                        txtTerminalID.Text = posResult.TerminalId;
                        txtStatus.Text =
                            string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);
                    }));
                else
                {
                    txtCardNumberMask.Text = maskedPan;
                    txtCardNumberHash.Text = posResult.CardNumberHash_Sha1;
                    txtTerminalID.Text = posResult.TerminalId;
                    txtStatus.Text =
                        string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);
                }
            }
        }
        private void _PosClient_PosResultReceived(PosResult posResult)
        {
            _tracsactionType = _PcPosFactory.GetTransactionType();
            if (_tracsactionType == TransactionType.Purchase || _tracsactionType == TransactionType.PaymentService)
            {
                PurchaseResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.Balance)
            {
                BalanceResultReceived(posResult);
            }

            else if (_tracsactionType == TransactionType.BillPay || _tracsactionType == TransactionType.BillRequest)
            {
                BillPaymentResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.MCIBillInquery || _tracsactionType == TransactionType.TCIBillInquery)
            {
                PhoneBillPropertiesResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.MCIBillPay || _tracsactionType == TransactionType.TCIBillPay ||
                    _tracsactionType == TransactionType.TCIBillRequest || _tracsactionType == TransactionType.MCIBillRequest)
            {
                PhoneBillPaymentResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.PinCharge || _tracsactionType == TransactionType.TopupCarge)
            {
                ChargeResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.GetReport)
            {
                ReportResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.GetAuthorizedOperations)
            {
                GetAuthorizedOperationsResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.EchoTest)
            {
                GetEchoTestResultReceived(posResult);
            }

        }
        #endregion

        #region Config
        private void cmbMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem.ToString() == MediaType.Com.ToString())
            {
                _mediaType = MediaType.Com;
                cmbPort.Enabled = true;
                btnRefresh.Enabled = true;
                btnDetectPort.Enabled = true;
                txtPosIP.Enabled = false;
            }
            else
            {
                if (comboBox != null && comboBox.SelectedItem.ToString() == MediaType.Network.ToString())
                {
                    _mediaType = MediaType.Network;
                    cmbPort.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnDetectPort.Enabled = false;
                    txtPosIP.Enabled = true;
                }
            }
        }
        private void cmbAccountsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == AccountType.Single.ToString())
            {
                _accountType = AccountType.Single;
                tabCtrlAmountsPurchase.SelectedTab = tabCtrlAmountsPurchase.TabPages[0];
            }
            else if ((sender as ComboBox).SelectedItem.ToString() == AccountType.Share.ToString())
            {
                _accountType = AccountType.Share;
                tabCtrlAmountsPurchase.SelectedTab = tabCtrlAmountsPurchase.TabPages[1];
            }
        }
        private void cmbAsyncType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem.ToString() == AsyncType.Async.ToString())
                _asyncType = AsyncType.Async;
            else if (comboBox != null && comboBox.SelectedItem.ToString() == AsyncType.Sync.ToString())
                _asyncType = AsyncType.Sync;
        }
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == ResponseLanguage.Persian.ToString())
            {
                _responseLanguage = ResponseLanguage.Persian;
            }
            else if ((sender as ComboBox).SelectedItem.ToString() == ResponseLanguage.English.ToString())
            {
                _responseLanguage = ResponseLanguage.English;
            }
        }
        private void btnGetAuthorizedOperations_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            _tracsactionType = TransactionType.GetAuthorizedOperations;
            ResetResult();
            if (TransactionMediaInitialization()) return;

            PosResult posResult = _PcPosFactory.GetAuthorizedOperations();
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                GetAuthorizedOperationsResultReceived(posResult);
            }
        }
        #endregion

        #region Balance
        private void btnStartBalance_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            ResetResult();
            if (TransactionMediaInitialization()) return;
           
            PosResult posResult = _PcPosFactory.Balance();

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                BalanceResultReceived(posResult);
            }
        }

        #endregion

        #region Purchase
        private void btnStartPurchase_Click(object sender, EventArgs e)
        {
            ResetResult();

            ClearGroupBox(grpPurchaseTypes);
            if (PurchaseInitialization()) return;
            PosResult posResult = _PcPosFactory.PosStarterPurchaseInit();

            if (_asyncType == AsyncType.Sync && posResult != null)
            {
                PurchaseCardSwiped(posResult);
            }
        }
        private bool PurchaseInitialization()
        {
            //ResetForm();
            _tracsactionType = TransactionType.Purchase;
            progressBar.Visible = true;

            if (TransactionMediaInitialization()) return false;

            _PcPosFactory.Initialization(_responseLanguage, 0, _asyncType);
            return false;
        }
        private void btnSendAmount_Click(object sender, EventArgs e)
        {
            List<string> lstAmnts = new List<string>();
            PosResult posResult = new PosResult();

            //pnlSwipeCardPurchase.Enabled = false;
            progressBar.Visible = true;
            txtStatus.Text = string.Format("Waiting for ETF-POS to respond.");

            #region Send Selected Purchase Type Key
            var firstOrDefault = grpPurchaseTypes.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            int purchaseTypeKey = -1;
            if (firstOrDefault != null)
                purchaseTypeKey = Int32.Parse(firstOrDefault.Tag.ToString());
            #endregion
            string TID = null;
            if (txtValidTerminalID.Text.Length > 0)
                TID = txtValidTerminalID.Text;
            string PurchaseID = txtPurchaseID.Text.Trim();
            if (_accountType == AccountType.Single)
            {
                posResult = _PcPosFactory.PosStarterPurchase(numAmountPurchase.Value.ToString(), string.Empty, txtAdditionalData.Text, txtReferenceDataPurchase.Text, purchaseTypeKey, TID, PurchaseID);
            }

            else
            {
                lstAmnts.AddRange(lstBoxAmountsPurchase.Items.Cast<string>().ToList());
                string amn = string.Join(",", lstAmnts.ToArray());
                posResult = _PcPosFactory.PosStarterPurchase(numSumAmountPurchase.Value.ToString(), amn, txtAdditionalData.Text, txtReferenceDataPurchase.Text, purchaseTypeKey, TID, PurchaseID);
            }

            if (_asyncType == AsyncType.Sync && posResult != null)
                PurchaseResultReceived(posResult);
        }
        private void btnSendAmountPcStater_Click(object sender, EventArgs e)
        {
            ResetResult();
            if (PurchaseInitialization()) return;

            List<string> lstAmnts = new List<string>();
            PosResult posResult = new PosResult();

            //pnlSwipeCardPurchase.Enabled = false;
            progressBar.Visible = true;
            txtStatus.Text = string.Format("Waiting for ETF-POS to respond.");
            string TID = null;
            if (txtValidTerminalID.Text.Length > 0)
                TID = txtValidTerminalID.Text;

            string PurchaseID = txtPurchaseID.Text.Trim();
            if (_accountType == AccountType.Single)
            {
                posResult = _PcPosFactory.PcStarterPurchase(numAmountPurchase.Value.ToString(), string.Empty, txtAdditionalData.Text, txtReferenceDataPurchase.Text, TID, PurchaseID);
            }

            else
            {
                lstAmnts.AddRange(lstBoxAmountsPurchase.Items.Cast<string>().ToList());
                string amn = string.Join(",", lstAmnts.ToArray());
                posResult = _PcPosFactory.PcStarterPurchase(numSumAmountPurchase.Value.ToString(), amn, txtAdditionalData.Text, txtReferenceDataPurchase.Text, TID, PurchaseID);
            }

            if (_asyncType == AsyncType.Sync && posResult != null)
                PurchaseResultReceived(posResult);
        }
        private void btnAddAmount_Click(object sender, EventArgs e)
        {
            lstBoxAmountsPurchase.Items.Add(numAddAmountPurchase.Value.ToString());
            if (lstBoxAmountsPurchase.Items.Count == 9)
                btnAddAmountPurchase.Enabled = false;
            lstBoxAmountsPurchase.SelectedIndex = lstBoxAmountsPurchase.Items.Count - 1;
            numSumAmountPurchase.Value = 0;
            if (lstBoxAmountsPurchase != null && lstBoxAmountsPurchase.Items != null)
                lstBoxAmountsPurchase.Items.Cast<string>().ToList().ForEach(x => numSumAmountPurchase.Value += decimal.Parse(x));
        }
        private void btnRemoveAmount_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstBoxAmountsPurchase.SelectedIndex;

            try
            {
                lstBoxAmountsPurchase.Items.RemoveAt(selectedIndex);
                if (lstBoxAmountsPurchase.Items.Count < 9)
                    btnAddAmountPurchase.Enabled = true;
                lstBoxAmountsPurchase.SelectedIndex = lstBoxAmountsPurchase.Items.Count - 1;

                numSumAmountPurchase.Value = 0;
                if (lstBoxAmountsPurchase != null && lstBoxAmountsPurchase.Items != null)
                    lstBoxAmountsPurchase.Items.Cast<string>().ToList().ForEach(x => numSumAmountPurchase.Value += Int32.Parse(x));
            }
            catch
            {
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region Bill
        private void btnBillProperties_Click(object sender, EventArgs e)
        {
            ResetResult();

            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.GetBillProperties(txtBillID.Text, txtPayID.Text);
            BillPropertiesResultReceived(posResult);
        }
        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            ResetResult();

            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.GetGenerateBill();
            GenerateBillResultReceived(posResult);
        }
        private void btnPayBill_Click(object sender, EventArgs e)
        {
            ResetResult();

            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.BillPayment(txtBillID.Text, txtPayID.Text, txtAdditionalDataBill.Text, txtReferenceDataBill.Text);
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                BillPaymentResultReceived(posResult);
            }
        }
        private void btnBillPaymentRequest_Click(object sender, EventArgs e)
        {
            ResetResult();
         
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.BillRequest();

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                BillPaymentResultReceived(posResult);
            }
        }
        #endregion

        #region MCI Bill
        private void btnGetMCIBill_Click(object sender, EventArgs e)
        {
            ResetResult();
      
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.MCIBillInquery(txtMCINumber.Text, (PhoneBillType)(cmbBillType.SelectedIndex + 1));
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPropertiesResultReceived(posResult);
            }
        }
        private void btnPayMCIBill_Click(object sender, EventArgs e)
        {
            ResetResult();
   
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.MCIBillPayment(txtMCINumber.Text, (PhoneBillType)(cmbBillType.SelectedIndex + 1), txtAdditionalDataMCI.Text, txtReferenceDataMCI.Text);
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPaymentResultReceived(posResult);
            }
        }
        private void btnMCIBillRequest_Click(object sender, EventArgs e)
        {
            ResetResult();
     
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.MCIBillRequest();
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPaymentResultReceived(posResult);
            }
        }
        #endregion

        #region TCI Bill
        private void btnGetPhoneBill_Click(object sender, EventArgs e)
        {
            ResetResult();
         
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.TCIBillInquery(txtTCINumber.Text, (PhoneBillType)(cmbTCIBillType.SelectedIndex + 1));

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPropertiesResultReceived(posResult);
            }
        }
        private void btnPayPhoneBill_Click(object sender, EventArgs e)
        {
            ResetResult();

            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.TCIBillPayment(txtTCINumber.Text, (PhoneBillType)(cmbTCIBillType.SelectedIndex + 1), txtAdditionalDataTCI.Text, txtReferenceDataTCI.Text);
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPaymentResultReceived(posResult);
            }
        }
        private void btnTCIBillRequest_Click(object sender, EventArgs e)
        {
            ResetResult();
  
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.TCIBillRequest();

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PhoneBillPaymentResultReceived(posResult);
            }
        }
        #endregion

        #region Charge
        private void btnPinCharge_Click(object sender, EventArgs e)
        {
            ResetResult();
    
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.PinCharge(txtAdditionalDataCharge.Text, txtReferenceDataCharge.Text);

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                ChargeResultReceived(posResult);
            }
        }
        private void btnTopupCharge_Click(object sender, EventArgs e)
        {
            ResetResult();
        
            if (TransactionMediaInitialization()) return;
            PosResult posResult = _PcPosFactory.TopupCharge(txtTopupMobileNumber.Text, txtAdditionalDataCharge.Text, txtReferenceDataCharge.Text);

            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                ChargeResultReceived(posResult);
            }
        }
        #endregion

        #region Report
        private void cmbReportTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _reportAction = (ReportAction)Enum.Parse(typeof(ReportAction), (sender as ComboBox).SelectedItem.ToString());
            if (_reportAction == ReportAction.Sum)
            {
                cmbReportFilterType.SelectedIndex = 1;
                cmbReportFilterType.Enabled = false;
            }
            else
            {
                cmbReportFilterType.Enabled = true;
            }
        }
        private void cmbReportFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem.ToString() == ReportFilterType.BySerial.ToString())
            {
                _reportFilterType = ReportFilterType.BySerial;
                txtReportFromDate.Enabled = false;
                txtReportToDate.Enabled = false;
                txtReportSerialNum.Enabled = true;
                txtToTime.Enabled = false;
                txtFromTime.Enabled = false;
            }
            else if (comboBox != null && comboBox.SelectedItem.ToString() == ReportFilterType.ByDate.ToString())
            {
                _reportFilterType = ReportFilterType.ByDate;
                txtReportFromDate.Enabled = true;
                txtReportToDate.Enabled = true;
                txtReportSerialNum.Enabled = false;
                txtToTime.Enabled = false;
                txtFromTime.Enabled = false;
            }
            else if (comboBox != null && comboBox.SelectedItem.ToString() == ReportFilterType.ByTime.ToString())
            {
                _reportFilterType = ReportFilterType.ByTime;
                txtReportFromDate.Enabled = true;
                txtReportToDate.Enabled = false;
                txtReportSerialNum.Enabled = false;
                txtToTime.Enabled = true;
                txtFromTime.Enabled = true;
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        { 
            ResetResult();
            txtReportOutput.Clear();
         
            if (TransactionMediaInitialization()) 
                return;
            PosResult posResult = _PcPosFactory.GetReport(_reportAction, _reportFilterType, txtReportFromDate.Text, txtReportToDate.Text, txtReportSerialNum.Text, txtTerminalPin.Text, txtFromTime.Text, txtToTime.Text);
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                ReportResultReceived(posResult);
            }
        }
        #endregion

        #region Echo
        private void btnEchoTest_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            ResetResult();
            if (TransactionMediaInitialization()) return;

            PosResult posResult = _PcPosFactory.ConnectionTest();
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                GetEchoTestResultReceived(posResult);
            }else
            {                
                
            }
        }
        #endregion

        #region PaymentService

        private void btnSrvPayStart_Click(object sender, EventArgs e)
        {            
            ResetResult();
            if (TransactionMediaInitialization()) return;
            ClearGroupBox(grpSrvPay);
            PosResult posResult = _PcPosFactory.PaymentServiceRequest();
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                PaymentServiceCardSwiped(posResult);
            }
        }
        private void btnSrvPaySendAmount_Click(object sender, EventArgs e)
        {
            PosResult posResult = new PosResult();
            Decimal SumOfValue = 0;
            var TextBoxes = grpSrvPay.Controls.OfType<NumericUpDown>();
            string IDs = "";
            string amounts = "";
            foreach (NumericUpDown tb in TextBoxes)
            {
                if (tb.Value >0)
                {
                    SumOfValue += tb.Value;
                    amounts += Convert.ToString(tb.Value)+",";
                    IDs     +=  tb.Tag.ToString()+",";
                }else
                {
                    tb.Focus();
                    return;
                }
            }
            amounts = amounts.Trim(',');
            IDs     = IDs.Trim(',');
            amounts = string.Format("{0},|,{1}", amounts,IDs);
            posResult=_PcPosFactory.PaymentServiceSendAmount(SumOfValue.ToString(), amounts, string.Empty, txtReferenceDataSrvPay.Text);
            if (_asyncType == AsyncType.Sync && posResult != null)
                PurchaseResultReceived(posResult);
        }
        private void ClearGroupBox(GroupBox Container)
        {
            if (Container.InvokeRequired)
            {
                Container.Invoke(new MethodInvoker(delegate { Container.Controls.Clear(); }));
            }
            else
            {
                Container.Controls.Clear();
            }
            
        }
        #endregion
        
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create(); //or use MD5.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        private void btnGetHash_Click(object sender, EventArgs e)
        {

            tbHashResult.Text = GetHashString(tbHashInput.Text);
        }

        #endregion

        private void Compare_Click(object sender, EventArgs e)
        {
            if(tbTextInput1.Text.CompareTo(tbtextinput2.Text)==0)
            {
                PicResult2.Image = Resource.Successful;
            }else
            {
                PicResult2.Image = Resource.Failed;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pnlStartPurchase.Enabled = true;
            ResetForm();
            _PcPosFactory.Dispose();
        }

        private void btnDetectPort_Click(object sender, EventArgs e)
        {
            DetectPorts();
        }
    }
}
