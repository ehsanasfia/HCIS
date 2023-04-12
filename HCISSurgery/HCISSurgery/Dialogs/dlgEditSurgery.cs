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
    public partial class dlgEditSurgery : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSDSurgery { get; set; }
        public Surgery ObjectSurgery { get; set; }
        public List<ModularService> lstDelete { get; set; }

        private bool isLoading = false;

        public dlgEditSurgery()
        {
            InitializeComponent();
        }

        private void dlgEditSurgery_Load(object sender, EventArgs e)
        {
            tadilAreaBindingSource.DataSource = dc.TadilAreas.ToList();
            personSurgeryBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            staffSurgeryCodeBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            serviceSurgeryBindingSource.DataSource = MainModule.DepSRV;
            //personAnesthesiaBindingSource.DataSource = dc.Persons.Where(x => x.Staff != null && x.Staff.UserType == "دکتر").ToList();
            //staffAnesthesiaCodeBindingSource.DataSource = dc.Staffs.Where(x => x.UserType == "دکتر").ToList();
            //serviceAnesthesiaBindingSource.DataSource = dc.Services.Where(x => x.CategoryID == (int)Category.بیهوشی && x.ParentID != null && x.Service1.Name == "عمل").ToList();
            //serviceAnesthesiaCodeBindingSource.DataSource = dc.DiagnosticServiceDetails.Where(x => x.Service != null && x.Service.CategoryID == (int)Category.بیهوشی).ToList();

            isLoading = true;
            ObjectSurgery.PropertyChanged += ObjectSurgery_PropertyChanged;
            
            GivenServiceDBindingSource.DataSource = ObjectGSDSurgery;
            SurgeryBindingSource.DataSource = ObjectSurgery;
            isLoading = false;
        }

        private void ObjectSurgery_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (isLoading)
                return;

            if (e.PropertyName == "Other")
            {
                ChangeValueS();
            }
            else if (e.PropertyName == "SupplementaryUnit")
            {
                ChangeValueS();
            }
            else if (e.PropertyName == "BasicSurgicalUnit")
            {
                ChangeValueS();
            }
        }

        private void ChangeValueS()
        {
            if (isLoading)
                return;

            if (ObjectSurgery != null && ObjectSurgery.Other != null && ObjectSurgery.BasicSurgicalUnit != null)
            {
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Other + ObjectSurgery.BasicSurgicalUnit;
            }
            else
            {
                ObjectSurgery.UltimateSurgicalUnit = null;
            }

            if (ObjectSurgery != null && ObjectSurgery.Other != null && ObjectSurgery.SupplementaryUnit != null)
            {
                ObjectSurgery.FinalSupplementalUnit = ObjectSurgery.Other + ObjectSurgery.SupplementaryUnit;
            }
            else
            {
                ObjectSurgery.FinalSupplementalUnit = null;
            }
            ObjectSurgery.ConfirmBasicSurgicalUnit = ObjectSurgery.BasicSurgicalUnit;
            ObjectSurgery.ConfirmOther = ObjectSurgery.Other;
            ObjectSurgery.ConfirmSupplementaryUnit = ObjectSurgery.SupplementaryUnit;
            ObjectSurgery.ConfirmUltimateSurgicalUnit = ObjectSurgery.UltimateSurgicalUnit;
            ObjectSurgery.ConfirmFinalSupplementalUnit = ObjectSurgery.FinalSupplementalUnit;
        }

        private void slkSurgeon_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            var vluID = slkSurgeon.EditValue as Guid?;
            if (vluID != null)
            {
                var vlu = dc.Services.FirstOrDefault(x => x.ID == vluID);
                ObjectGSDSurgery.Service = vlu;

                if (ObjectGSDSurgery.TadilArea == null)
                {
                    ObjectSurgery.BasicSurgicalUnit = 0;
                    ObjectSurgery.SupplementaryUnit = 0;
                    ObjectSurgery.Other = 0;
                    ObjectSurgery.UltimateSurgicalUnit = 0;
                    ObjectSurgery.FinalSupplementalUnit = 0;
                }
                else
                {
                    var prc = ObjectGSDSurgery.TadilArea.TadilpercentValue / 100.0d;
                    ObjectSurgery.BasicSurgicalUnit = ObjectGSDSurgery.Service.BasicK * prc;
                    ObjectSurgery.SupplementaryUnit = ObjectGSDSurgery.Service.SupplementBasicK * prc;
                    ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.BasicSurgicalUnit;
                    ObjectSurgery.FinalSupplementalUnit = ObjectSurgery.SupplementaryUnit;
                    ObjectSurgery.Other = ObjectGSDSurgery.ModularServices.Sum(x => x.K);
                    ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.BasicSurgicalUnit + ObjectSurgery.Other;
                    ObjectSurgery.FinalSupplementalUnit = ObjectSurgery.SupplementaryUnit + ObjectSurgery.Other;
                }
            }
            else
            {
                ObjectGSDSurgery.Service = null;
                ObjectSurgery.BasicSurgicalUnit = 0;
                ObjectSurgery.SupplementaryUnit = 0;
                ObjectSurgery.Other = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
                ObjectSurgery.FinalSupplementalUnit = 0;
            }
        }

        private void lkpSurgeonCode_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;
            var vluID = lkpSurgeonCode.EditValue as Guid?;
            if (vluID != null)
            {
                var vlu = dc.Services.FirstOrDefault(x => x.ID == vluID);
                ObjectGSDSurgery.Service = vlu;
            }
            else
            {
                ObjectGSDSurgery.Service = null;
            }
        }

        private void slkDetail_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;
            var cur = slkDetail.EditValue as TadilArea;
            if (ObjectGSDSurgery.Service == null)
            {
                ObjectSurgery.BasicSurgicalUnit = 0;
                ObjectSurgery.SupplementaryUnit = 0;
                ObjectSurgery.Other = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
                ObjectSurgery.FinalSupplementalUnit = 0;
            }
            else if (cur == null)
            {
                ObjectSurgery.BasicSurgicalUnit = 0;
                ObjectSurgery.SupplementaryUnit = 0;
                ObjectSurgery.Other = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
                ObjectSurgery.FinalSupplementalUnit = 0;
            }
            else
            {
                var prc = cur.TadilpercentValue / 100.0d;
                ObjectSurgery.BasicSurgicalUnit = ObjectGSDSurgery.Service.BasicK * prc;
                ObjectSurgery.SupplementaryUnit = ObjectGSDSurgery.Service.SupplementBasicK * prc;
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.BasicSurgicalUnit;
                ObjectSurgery.FinalSupplementalUnit = ObjectSurgery.SupplementaryUnit;
                ObjectSurgery.Other = ObjectGSDSurgery.ModularServices.Sum(x => x.K);
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.BasicSurgicalUnit + ObjectSurgery.Other;
                ObjectSurgery.FinalSupplementalUnit = ObjectSurgery.SupplementaryUnit + ObjectSurgery.Other;
            }
        }

        private void btnSurgeryOthers_Click(object sender, EventArgs e)
        {
            var dlg = new dlgSurgeryOthers();
            dlg.dc = dc;
            dlg.GSD = ObjectGSDSurgery;
            dlg.isEdit = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ObjectSurgery.Other = dlg.sum;
                //lstMSS = dlg.lstMSS;
                lstDelete = dlg.lstDel;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lstDelete != null && lstDelete.Any())
            {
                dc.ModularServices.DeleteAllOnSubmit(lstDelete);
            }
            DialogResult = DialogResult.OK;
        }
    }
}