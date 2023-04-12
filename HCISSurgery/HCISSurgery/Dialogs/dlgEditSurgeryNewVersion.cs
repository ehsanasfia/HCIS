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
    public partial class dlgEditSurgeryNewVersion : DevExpress.XtraEditors.XtraForm
    {
        public HCISSurgeryDataClassesDataContext dc { get; set; }
        public GivenServiceD ObjectGSDSurgery { get; set; }
        public Surgery ObjectSurgery { get; set; }
        public List<ModularService> lstDelete { get; set; }

        private bool isLoading = false;

        public dlgEditSurgeryNewVersion()
        {
            InitializeComponent();
        }

        private void dlgEditSurgeryNewVersion_Load(object sender, EventArgs e)
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

            if (e.PropertyName == "Joze_Fanni")
            {
                ChangeValueS();
            }
            else if (e.PropertyName == "Joze_Herfei")
            {
                ChangeValueS();
            }
        }

        private void ChangeValueS()
        {
            if (isLoading)
                return;

            if (ObjectSurgery != null && ObjectSurgery.Joze_Fanni != null && ObjectSurgery.Joze_Herfei != null)
            {
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
            }
            else
            {
                ObjectSurgery.UltimateSurgicalUnit = null;
            }

            ObjectSurgery.ConfirmUltimateSurgicalUnit = ObjectSurgery.UltimateSurgicalUnit;
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
                    ObjectSurgery.Joze_Fanni = 0;
                    ObjectSurgery.Joze_Herfei = 0;
                    ObjectSurgery.UltimateSurgicalUnit = 0;
                }
                else
                {
                    double? jf = 0;
                    double? jh = 0;
                    //if (ObjectSurgery.Joze_Fanni == null || ObjectSurgery.Joze_Fanni == 0.0 || ObjectSurgery.Joze_Herfei == null || ObjectSurgery.Joze_Herfei == 0.0)
                    //{
                        var jfh = dc.RVUs.FirstOrDefault(x => x.NationalID == ObjectGSDSurgery.Service.SalamatBookletCode);
                        if (jfh == null)
                        {
                            jf = 0;
                            jh = 0;
                        }
                        else
                        {
                            jf = jfh.Joze_Fanni_27 == null ? 0 : jfh.Joze_Fanni_27;
                            jh = jfh.Joze_Herfeyi_26 == null ? 0 : jfh.Joze_Herfeyi_26;
                        }
                    //}
                    var prc = ObjectGSDSurgery.TadilArea.TadilpercentValue / 100.0d;
                    ObjectSurgery.Joze_Fanni = jf * prc;
                    ObjectSurgery.Joze_Herfei = jh * prc;
                    ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
                }
            }
            else
            {
                ObjectGSDSurgery.Service = null;
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
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
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
            }
            else if (cur == null)
            {
                ObjectSurgery.Joze_Fanni = 0;
                ObjectSurgery.Joze_Herfei = 0;
                ObjectSurgery.UltimateSurgicalUnit = 0;
            }
            else
            {
                double? jf = 0;
                double? jh = 0;
                //if (ObjectSurgery.Joze_Fanni == null || ObjectSurgery.Joze_Fanni == 0.0 || ObjectSurgery.Joze_Herfei == null || ObjectSurgery.Joze_Herfei == 0.0)
                //{
                    var jfh = dc.RVUs.FirstOrDefault(x => x.NationalID == ObjectGSDSurgery.Service.SalamatBookletCode);
                    if (jfh == null)
                    {
                        jf = 0;
                        jh = 0;
                    }
                    else
                    {
                        jf = jfh.Joze_Fanni_27 == null ? 0 : jfh.Joze_Fanni_27;
                        jh = jfh.Joze_Herfeyi_26 == null ? 0 : jfh.Joze_Herfeyi_26;
                    }
                //}
                var prc = cur.TadilpercentValue / 100.0d;
                ObjectSurgery.Joze_Fanni = jf * prc;
                ObjectSurgery.Joze_Herfei = jh * prc;
                ObjectSurgery.UltimateSurgicalUnit = ObjectSurgery.Joze_Fanni + ObjectSurgery.Joze_Herfei;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}