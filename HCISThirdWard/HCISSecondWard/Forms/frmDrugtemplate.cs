using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSecondWard.Data;

namespace HCISSecondWard.Forms
{
    public partial class frmDrugtemplate : DevExpress.XtraEditors.XtraForm
    {
        HCISDataContext dc = new HCISDataContext();
        public string str = "";
        public frmDrugtemplate()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var current = serviceBindingSource.Current as Service;
            if (current == null)
                return;
            if (dc.DrugTempelateForWards.Any(x => x.DrugID == current.ID && x.WardID == Classes.MainModule.MyDepartment.ID))
            {
                MessageBox.Show("این دارو برای بخش ثبت شده است");
                return;
            }

            var a = new Dialogs.dlgDrugTempIns();

            a.Text = " دستور دارویی";
            a.selecteddrug = current;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;

            str = "";

            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.txtLkp)) ? "" : (a.txtLkp).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim();
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;


            var DT = new DrugTempelateForWard()
            {
                DrugID = current.ID,
                Comment = str,
                DrugFrequencyUsage = (a.lookUpEdit9.EditValue as DrugFrequencyUsage),
                WardID = Classes.MainModule.MyDepartment.ID,
                Amount = decimal.ToInt32(a.spnAmount.Value)
            };

            dc.DrugTempelateForWards.InsertOnSubmit(DT);
            dc.SubmitChanges();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID).OrderBy(x => x.Service.Name);

        }

        private void frmDrugtemplate_Load(object sender, EventArgs e)
        {
            serviceBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == 4).OrderBy(x => x.Name);
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID && x.Service.CategoryID == 4).OrderBy(x => x.Service.Name);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cur = drugTempelateForWardBindingSource.Current as DrugTempelateForWard;
            if (cur == null)
                return;

            if (MessageBox.Show("آیا مایل به حذف میباشید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
                return;

            dc.DrugTempelateForWards.DeleteOnSubmit(cur);
            dc.SubmitChanges();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID).OrderBy(x => x.Service.Name);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var curent = drugTempelateForWardBindingSource.Current as DrugTempelateForWard;
            if (curent == null)
                return;

            var a = new Dialogs.dlgDrugTempIns();

            a.Text = " دستور دارویی";
            a.selecteddrug = curent.Service;
            a.dc = dc;
            if (a.ShowDialog() != DialogResult.OK)
                return;

            str = "";

            if (a.radioButton1.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit1.EditValue as string)) ? "" : (a.lookUpEdit1.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit2.EditValue as string)) ? "" : (a.lookUpEdit2.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.txtLkp)) ? "" : (a.txtLkp).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim();
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit4.EditValue as string)) ? "" : (a.lookUpEdit4.EditValue as string).Trim();
                str = str.Trim();
            }
            else if (a.radioButton2.Checked)
            {
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit5.EditValue as string)) ? "" : (a.lookUpEdit5.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit6.EditValue as string)) ? "" : (a.lookUpEdit6.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.memoEdit1.Text as string)) ? "" : (a.memoEdit1.Text as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit7.EditValue as string)) ? "" : (a.lookUpEdit7.EditValue as string).Trim() + ", ";
                str += (string.IsNullOrWhiteSpace(a.lookUpEdit8.EditValue as string)) ? "" : (a.lookUpEdit8.EditValue as string).Trim();
                str = str.Trim();
            }
            else
                return;

            curent.Comment = str;
            curent.DrugFrequencyUsage = (a.lookUpEdit9.EditValue as DrugFrequencyUsage);
            curent.Amount = decimal.ToInt32(a.spnAmount.Value);
            dc.SubmitChanges();
            drugTempelateForWardBindingSource.DataSource = dc.DrugTempelateForWards.Where(x => x.WardID == Classes.MainModule.MyDepartment.ID).OrderBy(x => x.Service.Name);
        }
    }
}