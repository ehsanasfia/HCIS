﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgSuppliesPanelDefinition : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { set; get; }
        public PatternM ObjectPTM;
        List<PatternD> lstPTD;
        public bool isEdit = false;
        List<Service> lstService;

        public dlgSuppliesPanelDefinition()
        {
            InitializeComponent();
        }

        private void dlgPanelDefinition_Load(object sender, EventArgs e)
        {
            if (ObjectPTM == null)
            {
                ObjectPTM = new PatternM();
            }
            if (lstPTD == null)
            {
                lstPTD = new List<PatternD>();
            }
            var mdName = MainModule.MyDepartment.Name;
            AngioBindingSource.DataSource = ObjectPTM;
            lstService = dc.Services.Where(x => (x.CategoryID == (int)Category.خدمات_جراحی && x.ParentID != null && x.Service1.Name == mdName) || x.CategoryID == (int)Category.بیهوشی).ToList();
            serviceBindingSource.DataSource = lstService;
            serviceCodeBindingSource.DataSource = lstService;
            drugsBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.لوازم_مصرفی).ToList();

            if (isEdit == true)
            {
                ObjectPTM.Date = MainModule.GetPersianDate(DateTime.Now);
                ObjectPTM.Time = DateTime.Now.ToString("HH:mm");
                AngioBindingSource.DataSource = ObjectPTM;
                foreach (var item in ObjectPTM.PatternDs)
                {
                    lstPTD.Add(item);
                }
                patternDBindingSource.DataSource = lstPTD;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectPTM.Date = MainModule.GetPersianDate(DateTime.Now);
                ObjectPTM.Time = DateTime.Now.ToString("HH:mm");
                foreach (var item in lstPTD)
                {
                    item.PatternM = ObjectPTM;
                }
                dc.PatternDs.DeleteAllOnSubmit(ObjectPTM.PatternDs.Except(lstPTD));
                var ptm = dc.PatternMs.Where(x => x.ServiceMID == (lkpName.EditValue as Service).ID).Count();
                ObjectPTM.PatternNumber = ptm + 1;
                if(ObjectPTM.ID == 0)
                    dc.PatternMs.InsertOnSubmit(ObjectPTM);

                dc.SubmitChanges();
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
            var cur = drugsBindingSource.Current as Service;
            if (cur == null)
                return;
            var ptd = new PatternD() { Service = cur };
            lstPTD.Add(ptd);
            patternDBindingSource.DataSource = lstPTD;
            gridControl1.RefreshDataSource();
        }

        private void btnGDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }
    }
}