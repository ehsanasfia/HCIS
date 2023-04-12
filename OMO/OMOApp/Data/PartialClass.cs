using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMOApp.Classes;

namespace OMOApp.Data
{
    public class SurveillanceReport
    {
        public Company CompanyName { get; set; }
        public ManageMent ManageMentName { get; set; }
        public SubCompany SubCompanyName { get; set; }
        public Unit UnitName { get; set; }
        public float CountMoayeneShodeha { get; set; }
        public float CountShaghelin { get; set; }
        public int CountBimaran { get; set; }
        public float Shioue { get; set; }
        public float Borouz { get; set; }
        public Definition SicknessName { get; set; }
    }

    public class JobStatusReport
    {
        public Company CompanyName { get; set; }
        public SubCompany SubCompanyName { get; set; }
        public float CountShaghelin { get; set; }
        public float CountMoayeneShodeha { get; set; }
        public float CountResult { get; set; }
    }

    public partial class Visit
    {
        private bool _EndOfVisit;

        public bool EndOfVisit
        {
            get{ return _EndOfVisit; }
            set { _EndOfVisit = value; }
        }

        private string _CompanyFullName;

        public string CompanyFullName
        {
            get { return _CompanyFullName; }
            set { _CompanyFullName = value; }
        }
    }

    public partial class QAPlus
    {
        private Questionnaire _PQuestionnaire;

        public Questionnaire PQuestionnaire
        {
            get { return _PQuestionnaire; }
            set { _PQuestionnaire = value; }
        }

        private string _SortName;

        public string SortName
        {
            get { return _SortName; }
            set { _SortName = value; }
        }

        private string _QusetionnairGroup;

        public string QusetionnairGroup
        {
            get { return _QusetionnairGroup; }
            set { _QusetionnairGroup = value; }
        }
        private string _QuestionnaireName;

        public string QuestionnaireName
        {
            get { return this._QuestionnaireName; /*= this.Questionnaire.Name;*/ }
            set { _QuestionnaireName = value; }
        }
    }

    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public Guid? OMOID { get; set; }
        public Guid? JamiatID { get; set; }
        public Guid? HCISID { get; set; }
        public Person OmoPerson { get; set; }
        public PersonTbl JamiatPerson { get; set; }
    }
}
