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
using HCISSecondWard.Classes;

namespace HCISSecondWard.Dialogs
{
    public partial class dlgEditDates : DevExpress.XtraEditors.XtraForm
    {
        public HCISDataContext dc { get; set; }
        public GivenServiceM fromGSM { get; set; }

        Discharge EditingDischarge = null;
        List<GivenServiceM> lst = null;
        public dlgEditDates()
        {
            InitializeComponent();
        }

        private void dlgEditDates_Load(object sender, EventArgs e)
        {
            lst = dc.GivenServiceMs.Where(x => x.ServiceCategoryID == 10 && x.DossierID == fromGSM.DossierID).OrderBy(x => x.AdmitDate).ToList();
            givenServiceMsBindingSource.DataSource = lst;
            gridControl1.RefreshDataSource();

            EditingDischarge = fromGSM.Dossier.Discharge1;

            if (EditingDischarge == null)
            {
                layoutControlGroup2.Enabled = false;
                layoutControlGroup2.Text = "ویرایش ترخیص (بیمار هنوز ترخیص نشده است)";
            }
            else
            {
                txtDischargeDate.Text = EditingDischarge.DischargeDate;
                txtDischargeTime.Text = EditingDischarge.DischargeTime;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (layoutControlGroup2.Enabled)
            {
                if (string.IsNullOrWhiteSpace( txtDischargeDate.Text) )
                {
                    MessageBox.Show("تاریخ ترخیص را وارد کنید");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDischargeTime.Text))
                {
                    MessageBox.Show("ساعت ترخیص را وارد کنید");
                    return;
                }


                var disDt = txtDischargeDate.Text.Trim();
                var disTm = txtDischargeTime.Text.Trim();

                var maxAdmit = lst.Max(x => x.AdmitDate);

                if (disDt.CompareTo(maxAdmit) < 0)
                {
                    MessageBox.Show("تاریخ تاریخ باید پس از تاریخ پذیرش باشد");
                    return;
                }


                EditingDischarge.DischargeDate = disDt;
                EditingDischarge.DischargeTime = disTm;
            }


            dc.SubmitChanges();

            DialogResult = DialogResult.OK;
        }
    }
}