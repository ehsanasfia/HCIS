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
using HCISHealthAndFamily.Data;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily.Dialogs
{
    public partial class dlgAlarm : DevExpress.XtraEditors.XtraForm
    {
        HCISDataClassesDataContext dc = new HCISDataClassesDataContext();
        List<Person> lstPRS = new List<Person>();
        List<Person> lstSelect = new List<Person>();

        public dlgAlarm()
        {
            InitializeComponent();
        }

        private void dlgAlarm_Load(object sender, EventArgs e)
        {
            alarmBindingSource.DataSource = dc.Alarms.Where(x => x.Disable == false).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var alm = slkName.EditValue as Alarm;
            if (alm == null)
            {
                MessageBox.Show("توجه", "لطفا نام اعلان را انتخاب کنید.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var today = int.Parse(MainModule.GetPersianDate(DateTime.Now).Substring(0, 4));
            var yearf = today - alm.FAge;
            var yeart = today - alm.TAge;

            lstPRS = dc.Persons.Where(x => x.Sex == alm.Sex && x.BirthDate != null && x.BirthDate.Trim().Length == 10 && x.BirthDate.Trim().Substring(0, 4).CompareTo(yearf) <= 0 && x.BirthDate.Trim().Substring(0, 4).CompareTo(yeart) >= 0).ToList();

            bool IsLabTest = alm.AlarmDetails.Any(c => c.Service != null && c.Service.CategoryID == 1);
            bool IsDiagnostic = alm.AlarmDetails.Any(c => c.Service != null && c.Service.CategoryID == 5);
            bool IsQ = alm.AlarmDetails.Any(c => c.Questionnaire != null);

            List<AlarmDetail> lstALD = new List<AlarmDetail>();
            if (IsLabTest)
                lstALD = alm.AlarmDetails.Where(c => c.Service != null && c.Service.CategoryID == 1).ToList();
            else if (IsDiagnostic)
                lstALD = alm.AlarmDetails.Where(c => c.Service != null && c.Service.CategoryID == 5).ToList();
            else if (IsQ)
                lstALD = alm.AlarmDetails.Where(c => c.Questionnaire != null).ToList();

            foreach (var item in lstPRS)
            {
                bool valid = true;
                if (IsLabTest)
                {
                    foreach (var tst in lstALD)
                    {
                        if (!dc.GivenServiceDs.Any(x => x.GivenLaboratoryServiceD != null && x.Service != null && x.GivenServiceM != null && x.GivenServiceM.ServiceCategoryID == 1 && x.GivenServiceM.PersonID == item.ID && x.Service.ID == tst.Service.ID && x.GivenLaboratoryServiceD.Result.CompareTo(tst.FResult) >= 0 && x.GivenLaboratoryServiceD.Result.CompareTo(tst.TResult) <= 0))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                        continue;

                    lstSelect.Add(item);
                }
                else if (IsDiagnostic)
                {
                    foreach (var tst in lstALD)
                    {
                        if (!dc.GivenServiceDs.Any(x => x.Normal == true && x.Service != null && x.GivenServiceM != null && x.GivenServiceM.ServiceCategoryID == 5 && x.GivenServiceM.PersonID == item.ID && x.Service.ID == tst.Service.ID ))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                        continue;

                    lstSelect.Add(item);
                }
                else if (IsQ)
                {
                    foreach (var tst in lstALD)
                    {
                        if (!dc.QAPlus.Any(x => x.Questionnaire != null && x.GivenServiceM != null && x.GivenServiceM.PersonID == item.ID && x.Questionnaire.QuestionnaireGroup != null && x.Questionnaire.QuestionnaireGroup.ID == tst.Questionnaire.QuestionnaireGroup.ID && x.Questionnaire.ID == tst.Questionnaire.ID && (x.ResultCHK == tst.ResultCHK || x.Description == tst.Result)))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                        continue;

                    lstSelect.Add(item);
                }
            }
            
            personBindingSource.DataSource = lstSelect;
            gridControl1.RefreshDataSource();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}