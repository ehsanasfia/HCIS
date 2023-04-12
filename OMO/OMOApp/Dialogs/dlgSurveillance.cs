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
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgSurveillance : DevExpress.XtraEditors.XtraForm
    {
        public OMOClassesDataContext dc { get; set; }
        public Surveillance ObjectSRV;

        public dlgSurveillance()
        {
            InitializeComponent();
        }

        private void dlgSurveillance_Load(object sender, EventArgs e)
        {
            MainModule.VST_Set = dc.Visits.FirstOrDefault(c => c.ID == MainModule.VST_Set.ID);

            definitionBindingSource.DataSource = dc.Definitions.Where(x => x.ParentID == 4).OrderBy(c => c.Name).ToList();
            definitionBindingSource1.DataSource = dc.Definitions.Where(x => x.ParentID == 5).OrderBy(c => c.Name).ToList();
            definitionBindingSource2.DataSource = dc.Definitions.Where(x => x.ParentID == 6).OrderBy(c => c.Name).ToList();

            if (ObjectSRV == null)
            {
                ObjectSRV = new Surveillance();
                ObjectSRV.Active = true;

                if (MainModule.VST_Set.AdmitDate.Length > 0)
                {
                    var a = Int32.Parse(MainModule.VST_Set.AdmitDate.Substring(0, 4));
                    a++;
                    var NextDate = a.ToString() + MainModule.VST_Set.AdmitDate.Substring(4);

                    ObjectSRV.NextVisitDate = NextDate;
                }
                ObjectSRV.FirstDiagnosisDate = MainModule.GetPersianDate(DateTime.Now);
                rdgActive.EditValue = true;
                SurveillanceBindingSource.DataSource = ObjectSRV;
                ObjectSRV.Definition1 = dc.Definitions.FirstOrDefault(c => c.ID == 80);
                lkpSickType.EditValue = dc.Definitions.FirstOrDefault(c => c.ID == 80);
                ObjectSRV.Definition2 = dc.Definitions.FirstOrDefault(c => c.ID == 81); ;
                lkpSickSeverity.EditValue = dc.Definitions.FirstOrDefault(c => c.ID == 81);

            }
            else
            SurveillanceBindingSource.DataSource = ObjectSRV;
      }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectSRV.CreationDate = MainModule.GetPersianDate(DateTime.Now);
            ObjectSRV.CreationTime = DateTime.Now.ToString("HH:mm");
            ObjectSRV.CreatorUserID = MainModule.UserID;
            ObjectSRV.Visit = MainModule.VST_Set;

            if (ObjectSRV.ID == Guid.Empty)
            {
                ObjectSRV.Deleted = false;
                dc.Surveillances.InsertOnSubmit(ObjectSRV);
            }

            MainModule.VST_Set.ToDoList.Surveillance = true;
            dc.SubmitChanges();
            DialogResult = DialogResult.OK;
        }
    }
}