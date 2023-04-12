using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Data.IMData;
using OMOApp.Data;
using OMOApp.Classes;

namespace OMOApp.Dialogs
{
    public partial class dlgOldHistory : DevExpress.XtraEditors.XtraForm
    {
        IMClassesDataContext dc = new IMClassesDataContext();
        public OMOApp.Data.Person SelectedPrs;
        public bool MedicalHis, Checkup, Surveillance, ElameNatije, Nurse, Binaei, Shenawaei, Rawani, Rie = false;
        bool shouldClose = false;

        public dlgOldHistory()
        {
            InitializeComponent();
        }

        private void dlgOldHistory_Shown(object sender, EventArgs e)
        {
            if (shouldClose)
            {
                Close();
            }
        }

        private void dlgOldHistory_Load(object sender, EventArgs e)
        {
            try
            {

                documentBindingSource.DataSource = dc.Documents.Where(x => x.Person != null && x.Person.NationalCode == SelectedPrs.NationalCode).OrderByDescending(c => c.ReferralDate).ToList();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("network-related"))
                {
                    MessageBox.Show("امکان دسترسی به اطلاعات قبلی وجود ندارد.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    shouldClose = true;
                }
                else
                {
                    MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در دریافت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2)
            {
                var doc = documentBindingSource.Current as Document;
                if (doc == null)
                    return;

                if(MedicalHis)
                {
                    var f = new Dialogs.frmQuestion(doc.Person);
                    f.Show();
                }
                if(Checkup)
                {
                    var f = new Dialogs.frmDoctorDiagnosis(doc);
                    f.Show();
                }
                if(Surveillance)
                {
                    var f = new Dialogs.frmSurveillance(doc);
                    f.Show();
                }
                if(ElameNatije)
                {
                    var f = new Dialogs.frmDocumentResult(doc);
                    f.Show();
                }
                if(Nurse)
                {
                    if (!doc.NurseDiagnoses.Any())
                        return;
                    var f = new frmNursing(doc, frmNursing.ViewType.View);
                    f.ShowDialog();
                }
                if(Binaei)
                {
                    if (!doc.Optometries.Any())
                        return;
                    var f = new frmOptometry(frmOptometry.ViewType.View)
                    {
                        CurrentDocument = doc
                    };
                    f.ShowDialog();
                }
                if(Shenawaei)
                {
                    if (!doc.Odiometries.Any())
                        return;
                    var f = new frmOdiometry(frmOdiometry.ViewType.View)
                    {
                        CurrentDocument = doc
                    };
                    f.ShowDialog();
                }
                if(Rawani)
                {
                    if (!doc.PsychologyTests.Any())
                        return;
                    var f = new frmPsychology(doc, frmPsychology.ViewType.View);
                    f.ShowDialog();
                }
                if (Rie)
                {
                    if (!doc.Espirometries.Any())
                        return;
                    var f = new frmEspirometry(doc, frmEspirometry.ViewType.View);
                    f.ShowDialog();
                }
            }
            else
                return;
        }
    }
}