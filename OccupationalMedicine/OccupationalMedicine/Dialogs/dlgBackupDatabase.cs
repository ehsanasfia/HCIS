using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Threading;

namespace OccupationalMedicine.Dialogs
{
    public partial class dlgBackupDatabase : DevExpress.XtraEditors.XtraForm
    {
        private bool backuping = false;

        public dlgBackupDatabase()
        {
            InitializeComponent();
        }

        private void dlgBackupDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPath.Text) && Directory.Exists(txtPath.Text))
            {
                folderBrowserDialog1.SelectedPath = txtPath.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private string FindDataSourceFromConnectionString(string DatabaseName)
        {
            var lstConns =
                System.Configuration.ConfigurationManager.ConnectionStrings;

            System.Configuration.ConnectionStringSettings settings = null;
            string serverNameString = null;

            foreach (var item in lstConns)
            {
                settings = item as System.Configuration.ConnectionStringSettings;
                if (settings == null)
                    continue;

                string connectString = settings.ConnectionString;
                //Console.WriteLine("Original: {0}", connectString);

                // Create a new SqlConnectionStringBuilder based on the
                // partial connection string retrieved from the config file.
                System.Data.SqlClient.SqlConnectionStringBuilder builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(connectString);

                if (builder.InitialCatalog == "OccupationalMedicine".Trim() && !string.IsNullOrWhiteSpace(builder.DataSource))
                {
                    serverNameString = builder.DataSource;
                    break;
                }
            }
            return serverNameString;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

            string userName = "artp";
            string password = "506070";
            string DestPath = txtPath.Text;
            string databaseName = "OccupationalMedicine";
            string serverName = FindDataSourceFromConnectionString(databaseName);

            if (string.IsNullOrWhiteSpace(DestPath))
            {
                MessageBox.Show("مسیر را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            
            DestPath = DestPath.Trim();
            
                        
            //Define a Backup object variable.    
            Backup sqlBackup = new Backup();

            var now = DateTime.Now;

            ////Specify the type of backup, the description, the name, and the database to be backed up.    
            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "BackUp of " + databaseName + " by User in the app, on " 
                + now.ToString("yyyy-MM-dd") 
                + " at " + now.ToString("HH:mm:ss");
            sqlBackup.BackupSetName = databaseName + "-Full Database Backup";
            sqlBackup.Database = databaseName;

            ////Declare a BackupDeviceItem    
            string destinationPath = DestPath;
            string backupfileName = databaseName + now.ToString("_yyyy-MM-dd_HH-mm-ss-fff") + ".bak";
            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\" + backupfileName, DeviceType.File);
            ////Define Server connection    

            //ServerConnection connection = new ServerConnection(frm.serverName, frm.userName, frm.password);    
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            ////To Avoid TimeOut Exception    
            Server sqlServer = new Server(connection);
            sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
            Database db = sqlServer.Databases[databaseName];

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            ////Add the device to the Backup object.    
            sqlBackup.Devices.Add(deviceItem);
            ////Set the Incremental property to False to specify that this is a full database backup.    
            sqlBackup.Incremental = false;

            sqlBackup.CompressionOption = BackupCompressionOptions.On;
            ////Specify that the log must be truncated after the backup is complete.
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;
            sqlBackup.PercentComplete += SqlBackup_PercentComplete;

            mmProgress.Text = "";
            ////Run SqlBackup to perform the full database backup on the instance of SQL Server.    
            sqlBackup.Complete += SqlBackup_Complete;
            sqlBackup.Information += SqlBackup_Information;
            new Thread(() =>
            {
                backuping = true;
                btnBackup.Invoke((MethodInvoker)delegate
                {
                    btnBackup.Enabled = false;
                    btnBackup.Text = "در حال پشتیبان گیری...";
                });

                try
                {
                    sqlBackup.SqlBackup(sqlServer); ////Remove the backup device from the Backup object.    
                    sqlBackup.Devices.Remove(deviceItem);
                    mmProgress.Invoke((MethodInvoker)delegate
                    {
                        log("Backup successfully completed and saved to " + backupfileName);
                        log("پشتیبان گیری با موفقیت انجام شد");
                    });
                }
                catch (Exception ex)
                {
                    log("Exception: " + ex.Message);
                }
                finally
                {
                    backuping = false;
                    btnBackup.Invoke((MethodInvoker)delegate
                    {
                        btnBackup.Enabled = true;
                        btnBackup.Text = "شروع پشتیبان گیری";
                    });
                }
            }).Start();

        }

        private void SqlBackup_Information(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
                log("Information: " + e.Error.Message);
        }

        private void SqlBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
                log("Complete: " + e.Error.Message);
        }

        private void SqlBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl1.EditValue = e.Percent;
        }

        private void log(string message)
        {
            if (mmProgress.Text == null)
            {
                mmProgress.Invoke((MethodInvoker)delegate {
                    mmProgress.Text = "";
                });
            }

            if (string.IsNullOrWhiteSpace(message))
                return;



            mmProgress.Invoke((MethodInvoker)delegate {
                mmProgress.Text += "-" + message.Trim() + Environment.NewLine;
            });
        }

        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                SetSelection();
            }));
        }
        private void SetSelection()
        {
            mmProgress.SelectionStart = mmProgress.Text.Length;
            mmProgress.ScrollToCaret();
        }

        private void dlgBackupDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
                return;


            if (backuping)
            {
                e.Cancel = true;
                MessageBox.Show("برنامه در حال پشتیبان گیری است. لطفا تا تمام شدن آن صبر کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}