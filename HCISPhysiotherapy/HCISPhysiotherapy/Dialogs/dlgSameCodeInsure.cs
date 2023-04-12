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
using HCISPhysiotherapy.Data;

namespace HCISPhysiotherapy.Dialogs
{
    public partial class dlgSameCodeInsure : BaseDialog
    {
        public dlgSameCodeInsure()
        {
            InitializeComponent();
        }

        public List<Spu_AllDBPersonResult> Paitionts = new List<Spu_AllDBPersonResult>();
        public Spu_AllDBPersonResult Current = new Spu_AllDBPersonResult();

        private void dlgSameCode_Load(object sender, EventArgs e)
        {
             spuAllDBPersonResultBindingSource.DataSource = Paitionts;
            (gridView1.FormatRules[0].Rule as FormatConditionRuleValue).Value1 = MainModule.GetPersianDate(DateTime.Now);

        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = e.ListSourceRowIndex + 1;

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (spuAllDBPersonResultBindingSource.Current != null)
            {
                btnAccept.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (spuAllDBPersonResultBindingSource.Current == null)
            {
                MessageBox.Show("لطفاً بیمار را انتخاب نمایید");
                return;
            }
            Current = spuAllDBPersonResultBindingSource.Current as Spu_AllDBPersonResult;
            if(string.IsNullOrWhiteSpace(Current.NationalCode) || Current.NationalCode.Length < 10 || Current.NationalCode.Length > 10 || Current.NationalCode == "0000000000")
            {
                if (MessageBox.Show(".کد ملی بیمار ناقص میباشد لطفا آن را اصلاح فرمایید و یا با شماره 778 تماس بگیرید" + " در ضمن مسئولیت تغییر کد ملی به عهده شما میباشد " + " " + MainModule.UserFullName, "توجه", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.OK)
                {
                    var dlg = new Dialogs.dlgNtaionalCode();
                    dlg.Text = "کد ملی " + " " + Current.Firstname + " " + Current.Lastname;
                    dlg.ShowDialog();
                    if (dlg.DialogResult != DialogResult.OK)
                        return;
                    else
                        Current.NationalCode = dlg.NationalCode;
                }
                else
                    return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnMoreSearch_Click(object sender, EventArgs e)
        {
            Current = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}