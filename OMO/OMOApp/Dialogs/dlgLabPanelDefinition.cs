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
using OMOApp.Data;
using OMOApp.Data.HCISData;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgLabPanelDefinition : DevExpress.XtraEditors.XtraForm
    {
        HCISClassesDataContext hdc = new HCISClassesDataContext();
        OMOClassesDataContext odc = new OMOClassesDataContext();
        List<Service> lstSRV = new List<Service>();
        public bool isEdit = false;

        public dlgLabPanelDefinition()
        {
            InitializeComponent();
        }

        private void dlgLabPanelDefinition_Load(object sender, EventArgs e)
        {
            if (lstSRV == null)
            {
                lstSRV = new List<Service>();
            }

            serviceBindingSource.DataSource = hdc.Services.Where(x => x.CategoryID == 1).ToList();

            if (isEdit == true)
            {
                //ObjectPTM.Date = MainModule.GetPersianDate(DateTime.Now);
                //ObjectPTM.Time = DateTime.Now.ToString("HH:mm");
                //SurgeryBindingSource.DataSource = ObjectPTM;
                //foreach (var item in ObjectPTM.PatternDs)
                //{
                //    lstPTD.Add(item);
                //}
                //patternDBindingSource.DataSource = lstPTD;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPatternName.Text))
                {
                    MessageBox.Show("لطفا نام پنل را انتخاب کنید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var ptt = odc.Patterns.Where(x => x.PatternName == txtPatternName.Text).ToList();
                if(ptt != null && ptt.Any())
                {
                    var res = MessageBox.Show("پنلی با این نام قبلا ثبت شده است." + Environment.NewLine + "آیا مایل به اضافه شدن مورد های وارد شده به پنل قبلی می باشید؟", "توجه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    if (res == DialogResult.Cancel)
                        return;
                    else if (res == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }

                var date = MainModule.GetPersianDate(DateTime.Now);
                var time = DateTime.Now.ToString("HH:mm");
                foreach (var item in lstSRV)
                {
                    if (ptt.Any(x => x.ServiceID == item.ID))
                        continue;

                    var ptrn = new Pattern()
                    {
                        PatternName = txtPatternName.Text,
                        ServiceID = item.ID,
                        CreationDate = date,
                        CreationTime = time,
                        CreatorUserID = MainModule.UserID
                    };

                    odc.Patterns.InsertOnSubmit(ptrn);
                }
                odc.SubmitChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnOk.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Q | Keys.Control))
            {
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var cur = serviceBindingSource.Current as Service;
            if (cur == null)
                return;

            lstSRV.Add(cur);
            SelectedServiceBindingSource.DataSource = lstSRV;
            gridControl1.RefreshDataSource();
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }
    }
}