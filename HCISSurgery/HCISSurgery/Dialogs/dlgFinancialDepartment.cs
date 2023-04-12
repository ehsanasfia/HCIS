using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCISSurgery.Data;
using HCISSurgery.Classes;

namespace HCISSurgery.Dialogs
{
    public partial class dlgFinancialDepartment : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceM GSM;
        Surgery ObjectSRG;
        List<GivenServiceD> lstGSD;
        List<ModularService> lstMS;

        List<TadilArea> lstTadil;

        public dlgFinancialDepartment()
        {
            InitializeComponent();
        }

        private void dlgFinancialDepartment_Load(object sender, EventArgs e)
        {
            lstTadil = dc.TadilAreas.ToList();
            tadilAreaBindingSource.DataSource = lstTadil;
            serviceBindingSource.DataSource = MainModule.DepSRV;
            GetData();
        }

        private void EndEdit()
        {
            SurgeryBindingSource.EndEdit();
        }

        private void GetData()
        {
            try
            {
                EndEdit();

                if (lstGSD == null)
                    lstGSD = new List<GivenServiceD>();
                if (lstMS == null)
                    lstMS = new List<ModularService>();
                if (ObjectSRG == null)
                    ObjectSRG = new Surgery();

                lstGSD = dc.GivenServiceDs.Where(x => x.GivenServiceM != null && x.GivenServiceM.PersonID == GSM.PersonID && x.GivenServiceM.ServiceCategoryID == (int)Category.خدمات_جراحی && x.Staff != null).OrderByDescending(c => c.GivenServiceM.CreationDate).ToList();
                givenServiceDBindingSource.DataSource = lstGSD;
                lstGSD.Where(x => x.Surgery.FinanceConfirm == false).ToList().ForEach(x => 
                {
                    x.Surgery.Service = x.Service;
                    x.Surgery.TadilArea = x.TadilArea;
                });
                //foreach (var item in lstGSD)
                //{
                //    lstMS.AddRange(item.ModularServices.ToList());
                //}
                //modularServiceBindingSource.DataSource = lstMS;
                gridControl1.RefreshDataSource();
                gridControl2.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                return;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetRow(e.RowHandle) as GivenServiceD;
            if (row == null)
                return;
            if (e.Column == colGSDFinanceConfirm)
            {
                var prc = ((row.Surgery == null || row.Surgery.TadilArea == null) ? 0 : (row.Surgery.TadilArea.TadilpercentValue / 100.0d));

                if (row.Surgery != null && row.Surgery.Service != null && e.Value as bool? == false)
                {
                    //ObjectSRG.ConfirmBasicSurgicalUnit = (ObjectSRG.ConfirmBasicSurgicalUnit ?? 0) - ((row.Service.BasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmSupplementaryUnit = (ObjectSRG.ConfirmSupplementaryUnit ?? 0) - ((row.Service.SupplementBasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmUltimateSurgicalUnit = (ObjectSRG.ConfirmUltimateSurgicalUnit ?? 0) - ((row.Service.BasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmFinalSupplementalUnit = (ObjectSRG.ConfirmFinalSupplementalUnit ?? 0) - ((row.Service.SupplementBasicK ?? 0) * prc);

                    ObjectSRG.ConfirmBasicSurgicalUnit = 0;
                    ObjectSRG.ConfirmSupplementaryUnit = 0;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = 0;
                    ObjectSRG.ConfirmFinalSupplementalUnit = 0;

                    ObjectSRG.GivenServiceD.ModularServices.ToList().ForEach(x => x.FinanceConfirm = false);
                    colFinanceConfirm.OptionsColumn.AllowEdit = false;
                    colFinanceConfirm.OptionsColumn.AllowFocus = false;
                    gridControl2.RefreshDataSource();
                }
                else if (row.Surgery != null && row.Surgery.Service != null && e.Value as bool? == true)
                {
                    //ObjectSRG.ConfirmBasicSurgicalUnit = (ObjectSRG.ConfirmBasicSurgicalUnit ?? 0) + ((row.Service.BasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmSupplementaryUnit = (ObjectSRG.ConfirmSupplementaryUnit ?? 0) + ((row.Service.SupplementBasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmUltimateSurgicalUnit = (ObjectSRG.ConfirmUltimateSurgicalUnit ?? 0) + ((row.Service.BasicK ?? 0) * prc);
                    //ObjectSRG.ConfirmFinalSupplementalUnit = (ObjectSRG.ConfirmFinalSupplementalUnit ?? 0) + ((row.Service.SupplementBasicK ?? 0) * prc);

                    if (!ObjectSRG.GivenServiceD.ModularServices.Any(x => x.FinanceConfirm == true))
                    {
                        ObjectSRG.GivenServiceD.ModularServices.ToList().ForEach(x => x.FinanceConfirm = true);
                    }

                    ObjectSRG.ConfirmBasicSurgicalUnit = (row.Surgery.Service.BasicK ?? 0) * prc;
                    ObjectSRG.ConfirmSupplementaryUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = ((row.Surgery.Service.BasicK ?? 0) * prc);
                    if (ObjectSRG.ConfirmUltimateSurgicalUnit != 0)
                        ObjectSRG.ConfirmUltimateSurgicalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                    ObjectSRG.ConfirmFinalSupplementalUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    if (ObjectSRG.ConfirmFinalSupplementalUnit != 0)
                        ObjectSRG.ConfirmFinalSupplementalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                    
                    colFinanceConfirm.OptionsColumn.AllowEdit = true;
                    colFinanceConfirm.OptionsColumn.AllowFocus = true;
                    gridControl2.RefreshDataSource();
                }
            }
            else if (e.Column == colConfirmService)
            {
                if (e.Value == null)
                {
                    row.Surgery.Service = null;
                }
                else
                {
                    var vID = e.Value as Guid?;
                    var srv = dc.Services.FirstOrDefault(x => x.ID == vID);
                    row.Surgery.Service = srv;
                }

                if (row.Surgery.FinanceConfirm == false || row.Surgery.Service == null)
                {
                    ObjectSRG.ConfirmBasicSurgicalUnit = 0;
                    ObjectSRG.ConfirmSupplementaryUnit = 0;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = 0;
                    ObjectSRG.ConfirmFinalSupplementalUnit = 0;
                }
                else
                {
                    var prc = ((row.Surgery == null || row.Surgery.TadilArea == null) ? 0 : (row.Surgery.TadilArea.TadilpercentValue / 100.0d));
                    ObjectSRG.ConfirmBasicSurgicalUnit = (row.Surgery.Service.BasicK ?? 0) * prc;
                    ObjectSRG.ConfirmSupplementaryUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = ((row.Surgery.Service.BasicK ?? 0) * prc);
                    if (ObjectSRG.ConfirmUltimateSurgicalUnit != 0)
                        ObjectSRG.ConfirmUltimateSurgicalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                    ObjectSRG.ConfirmFinalSupplementalUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    if (ObjectSRG.ConfirmFinalSupplementalUnit != 0)
                        ObjectSRG.ConfirmFinalSupplementalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                }

            }
            else if (e.Column == colConfirmTadilArea)
            {
                var tdl = e.Value as TadilArea;

                if (row.Surgery.FinanceConfirm == false || row.Surgery.Service == null)
                {
                    ObjectSRG.ConfirmBasicSurgicalUnit = 0;
                    ObjectSRG.ConfirmSupplementaryUnit = 0;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = 0;
                    ObjectSRG.ConfirmFinalSupplementalUnit = 0;
                }
                else
                {
                    var prc = tdl == null ? 0 : (tdl.TadilpercentValue / 100.0d);
                    ObjectSRG.ConfirmBasicSurgicalUnit = (row.Surgery.Service.BasicK ?? 0) * prc;
                    ObjectSRG.ConfirmSupplementaryUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    ObjectSRG.ConfirmUltimateSurgicalUnit = ((row.Surgery.Service.BasicK ?? 0) * prc);
                    if (ObjectSRG.ConfirmUltimateSurgicalUnit != 0)
                        ObjectSRG.ConfirmUltimateSurgicalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                    ObjectSRG.ConfirmFinalSupplementalUnit = (row.Surgery.Service.SupplementBasicK ?? 0) * prc;
                    if (ObjectSRG.ConfirmFinalSupplementalUnit != 0)
                        ObjectSRG.ConfirmFinalSupplementalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K);
                }
            }

        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView2.GetRow(e.RowHandle) as ModularService;
            if (row == null)
                return;
            var prc = ((row.GivenServiceD.Surgery == null || row.GivenServiceD.Surgery.TadilArea == null) ? 0 : (row.GivenServiceD.Surgery.TadilArea.TadilpercentValue / 100.0d));
            if (e.Value as bool? == false)
            {
                //ObjectSRG.ConfirmUltimateSurgicalUnit = (ObjectSRG.ConfirmUltimateSurgicalUnit ?? 0) - (row.K ?? 0);
                //ObjectSRG.ConfirmFinalSupplementalUnit = (ObjectSRG.ConfirmFinalSupplementalUnit ?? 0) - (row.K ?? 0);

                ObjectSRG.ConfirmUltimateSurgicalUnit = ((row.GivenServiceD.Surgery.Service.BasicK ?? 0) * prc);
                if (ObjectSRG.ConfirmUltimateSurgicalUnit != 0)
                    ObjectSRG.ConfirmUltimateSurgicalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K) - (row.FinanceConfirm == false ? 0 : (row.K ?? 0));

                if (ObjectSRG.ConfirmUltimateSurgicalUnit < 0)
                    ObjectSRG.ConfirmUltimateSurgicalUnit = 0;

                ObjectSRG.ConfirmFinalSupplementalUnit = (row.GivenServiceD.Surgery.Service.SupplementBasicK ?? 0) * prc;
                if (ObjectSRG.ConfirmFinalSupplementalUnit != 0)
                    ObjectSRG.ConfirmFinalSupplementalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K) - (row.FinanceConfirm == false ? 0 : (row.K ?? 0));
                if (ObjectSRG.ConfirmFinalSupplementalUnit < 0)
                    ObjectSRG.ConfirmFinalSupplementalUnit = 0;

            }
            else if (e.Value as bool? == true)
            {
                //ObjectSRG.ConfirmUltimateSurgicalUnit = (ObjectSRG.ConfirmUltimateSurgicalUnit ?? 0) + (row.K ?? 0);
                //ObjectSRG.ConfirmFinalSupplementalUnit = (ObjectSRG.ConfirmFinalSupplementalUnit ?? 0) + (row.K ?? 0);

                ObjectSRG.ConfirmUltimateSurgicalUnit = ((row.GivenServiceD.Surgery.Service.BasicK ?? 0) * prc);
                if (ObjectSRG.ConfirmUltimateSurgicalUnit != 0)
                    ObjectSRG.ConfirmUltimateSurgicalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K) + (row.FinanceConfirm == true ? 0 : (row.K ?? 0));

                if (ObjectSRG.ConfirmUltimateSurgicalUnit < 0)
                    ObjectSRG.ConfirmUltimateSurgicalUnit = 0;

                ObjectSRG.ConfirmFinalSupplementalUnit = (row.GivenServiceD.Surgery.Service.SupplementBasicK ?? 0) * prc;
                if (ObjectSRG.ConfirmFinalSupplementalUnit != 0)
                    ObjectSRG.ConfirmFinalSupplementalUnit += ObjectSRG.GivenServiceD.ModularServices.Where(x => x.FinanceConfirm == true).Sum(x => x.K) + (row.FinanceConfirm == true ? 0 : (row.K ?? 0));
                if (ObjectSRG.ConfirmFinalSupplementalUnit < 0)
                    ObjectSRG.ConfirmFinalSupplementalUnit = 0;
            }
        }

        private void givenServiceDBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = givenServiceDBindingSource.Current as GivenServiceD;
            if (cur == null)
            {
                lstMS = null;
                modularServiceBindingSource.DataSource = null;
                return;
            }
            ObjectSRG = cur.Surgery;
            ObjectSRG.PropertyChanged += ObjectSRG_PropertyChanged;
            SurgeryBindingSource.DataSource = ObjectSRG;
            lstMS = cur.ModularServices.ToList();
            modularServiceBindingSource.DataSource = lstMS;
            gridControl2.RefreshDataSource();

            ObjectSRG_PropertyChanged(null, new PropertyChangedEventArgs("ConfirmUltimateSurgicalUnit"));

            if (cur.Surgery == null || cur.Surgery.FinanceConfirm == false)
            {
                colFinanceConfirm.OptionsColumn.AllowEdit = false;
                colFinanceConfirm.OptionsColumn.AllowFocus = false;
            }
            else
            {
                colFinanceConfirm.OptionsColumn.AllowEdit = true;
                colFinanceConfirm.OptionsColumn.AllowFocus = true;
            }
        }

        private void ObjectSRG_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ConfirmUltimateSurgicalUnit")
                return;

            //var sum = ObjectSRG.GivenServiceD.GivenServiceM.GivenServiceDs
            //    .Where(x => x.Surgery != null && x.Surgery.ConfirmUltimateSurgicalUnit != 0)
            //    .Select(x => x.Surgery)
            //    .Sum(x => x.ConfirmUltimateSurgicalUnit);

            var sum = lstGSD
                .Where(x => x.Surgery != null && x.Surgery.ConfirmUltimateSurgicalUnit != 0)
                .Select(x => x.Surgery)
                .Sum(x => x.ConfirmUltimateSurgicalUnit);

            txtGsmSumK.Text = sum + "";
            ObjectSRG.GivenServiceD.GivenServiceM.ConfirmFinanceSumK = sum;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}