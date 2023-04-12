using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OMOApp.Classes;

namespace OMOApp.Forms
{
    public partial class addttestthospittal : DevExpress.XtraEditors.XtraForm
    {
        public addttestthospittal()
        {
            InitializeComponent();
        }
        Data.OMOClassesDataContext d = new Data.OMOClassesDataContext();
        Data.hospitalDataContext h = new Data.hospitalDataContext();
        private void addttestthospittal_Load(object sender, EventArgs e)
        {
            var lstt = d.Visits.Where(x => x.AdmitDate.CompareTo("1398/01/01") >= 0 && x.AdmitDate.CompareTo("1398/06/13") <= 0 && x.ToDoList.OtherTest!=true).ToList();
            foreach (var item in lstt)
            {
                var national = item.Person.NationalCode;
                var lab = h.vw_labHospitalMapings.Where(x => x.NationalCode == national && x.ReqDate.CompareTo(item.AdmitDate) >= 0).OrderBy(x => x.ReqDate).FirstOrDefault();
                if(lab==null)
                    lab = h.vw_labHospitalMapings.Where(x => x.NationalCode == national && x.ReqDate.CompareTo(item.AdmitDate) <= 0).OrderByDescending(x => x.ReqDate).FirstOrDefault();

                if (lab != null)
                {

                    var lstlab = h.labPrescriptionDs.Where(x => x.SerialNumber == lab.SerialNumber).ToList();
                    if (lstlab.Count > 0)
                    {
                        var labQA = d.LabTestQAs.ToList();
                        foreach (var labitem in lstlab)
                        {
                            var labqamap = labQA.FirstOrDefault(z => z.IDHos == labitem.Test_ID);
                            if (labqamap != null)
                            {
                                var qs = d.Questionnaires.FirstOrDefault(x => x.ID == labqamap.QuestionnaireID);
                                if (qs != null)
                                {
                                    Data.QAPlus q = new Data.QAPlus()
                                    {
                                        VisitID = item.ID
                                   ,
                                        CreationDate = MainModule.GetPersianDate(DateTime.Now),
                                        CreationTime = DateTime.Now.ToString("HH:mm"),
                                        CreationUser = MainModule.UserID,
                                        Date = lab.ReqDate,
                                        Questionnaire = qs,
                                        QusetionnairGroup = qs.QuestionnaireGroup.Name,
                                        Description=labitem.Value,

                                    };
                                    d.QAPlus.InsertOnSubmit(q);
                                }
                            }
                        }
                    }
                    item.ToDoList.OtherTest = true;
                    d.SubmitChanges();
                }
            }
        }
    }
}