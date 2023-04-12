using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISDrugStore.Data;

namespace HCISDrugStore.Dialogs
{
    public partial class dlgDrugSpeciality : DevExpress.XtraEditors.XtraForm
    {
        HCISDrugStoreClassesDataContext dc = new HCISDrugStoreClassesDataContext();
        List<SpecialityDrug> New = new List<SpecialityDrug>();
        List<SpecialityDrug> all = new List<SpecialityDrug>();
        public dlgDrugSpeciality()
        {
            InitializeComponent();
        }

        private void dlgDrugSpeciality_Load(object sender, EventArgs e)
        {
            GetData();
            gridControl2.DataSource = all;
        }

        private void GetData()
        {

            specialityBindingSource.DataSource = dc.Specialities.ToList();
            serviceBindingSource.DataSource = dc.Services.Where(x => x.ServiceCategory.ID == 4).ToList();
            var spe = lookUpEdit1.EditValue as Speciality;
            if (spe == null)
                return;
            else
                all.AddRange(dc.SpecialityDrugs.Where(x => x.SpecialityID == spe.ID));

        }

        private void add()
        {
            var current = serviceBindingSource.Current as Service;
            var spe = lookUpEdit1.EditValue as Speciality;
            if (current == null)
                return;
            if (spe == null)
            {
                MessageBox.Show("لطفا تخصص را مشخص کنید");
                return;
            }
            if (all.Any())
            {
                if (all.Any(x => x.DrugID == current.ID))
                {
                    MessageBox.Show("این دارو را انتخاب کرده اید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }
                var fs = new SpecialityDrug()
                {
                    SpecialityID = spe.ID,
                    DrugID = current.ID
                };
                New.Add(fs);
                all.Add(fs);
            }
            else
            {
                var fs = new SpecialityDrug()
                {
                    SpecialityID = spe.ID,
                    DrugID = current.ID
                };
                New.Add(fs);
                all.Add(fs);
            }
            gridControl2.DataSource = all;
            gridControl2.RefreshDataSource();
            gridControl2.Refresh();
            gridView2.RefreshData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            add();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            gridView2.DeleteSelectedRows();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (all == null)
            {
                MessageBox.Show("ابتدا یک مورد را انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }
            else
            {
                try
                {
                    dc.SpecialityDrugs.InsertAllOnSubmit(New);
                    dc.SubmitChanges();
                    MessageBox.Show("تغییرات با موفقیت ثبت  گردیدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا در ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var spe = lookUpEdit1.EditValue as Speciality;
            if (spe == null)
                return;
            else
            {
                all.AddRange(dc.SpecialityDrugs.Where(x => x.SpecialityID == spe.ID));
                gridControl2.DataSource = all;
                gridControl2.RefreshDataSource();
            }

        }

        private void specialityBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void specialityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            lookUpEdit1_EditValueChanged(null, null);
        }
    }
}