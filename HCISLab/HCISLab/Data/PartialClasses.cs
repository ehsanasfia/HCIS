using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISLab.Data
{
    partial class Person
    {
        private string _FullName;

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }

    public partial class LabWorksheet
    {
        private string _Tests;
        public string Tests
        {
            get
            {
                return this._Tests;
            }
            set
            {
                if ((this._Tests != value))
                {
                    this._Tests = value;
                }
            }
        }
    }

    public partial class ViewLabGroupby
    {
        private string _Tests;
        public string Tests
        {
            get
            {
                return this._Tests;
            }
            set
            {
                if ((this._Tests != value))
                {
                    this._Tests = value;
                }
            }
        }

        private bool _GetSample;
        public bool GetSample
        {
            get
            {
                return this._GetSample;
            }
            set
            {
                if ((this._GetSample != value))
                {
                    this._GetSample = value;
                }
            }
        }

        private Guid? _FirstGSDID;
        public Guid? FirstGSDID
        {
            get
            {
                return this._FirstGSDID;
            }
            set
            {
                if ((this._FirstGSDID != value))
                {
                    this._FirstGSDID = value;
                }
            }
        }

        private GivenServiceM _GivenServiceM;
        public GivenServiceM GivenServiceM
        {
            get
            {
                return this._GivenServiceM;
            }
            set
            {
                if ((this._GivenServiceM != value))
                {
                    this._GivenServiceM = value;
                }
            }
        }

        private List<GivenServiceD> _GivenServiceDs;
        public List<GivenServiceD> GivenServiceDs
        {
            get
            {
                return this._GivenServiceDs;
            }
            set
            {
                if ((this._GivenServiceDs != value))
                {
                    this._GivenServiceDs = value;
                }
            }
        }

    }

    public partial class LabAntiBiogram
    {
        private bool _Sensitive;

        public bool Sensitive
        {
            get { return _Sensitive; }
            set { _Sensitive = value; }
        }

        private bool _Intermediate;

        public bool Intermediate
        {
            get { return _Intermediate; }
            set { _Intermediate = value; }
        }

        private bool _Resistance;

        public bool Resistance
        {
            get { return _Resistance; }
            set { _Resistance = value; }
        }

    }

    public partial class GivenServiceD
    {
        private string _PatientWorkListInfo;

        public string PatientWorkListInfo
        {
            get
            {
                if (GivenServiceM != null && GivenServiceM.Person != null)
                {
                    return ((GivenServiceM.Person.PersonalCode == null 
                        ? "" 
                        : GivenServiceM.Person.PersonalCode) 
                        + 
                        Environment.NewLine + 
                        (string.IsNullOrWhiteSpace(GivenServiceM.Person.FirstName) ? GivenServiceM.Person.LastName : GivenServiceM.Person.FirstName)).Trim();
                }
                else
                {
                    return "";
                }
            }
            set { _PatientWorkListInfo = value; }
        }

    }

    public partial class GivenServiceM
    {
        private int _LineNumber;

        public int LineNumber
        {
            get { return _LineNumber; }
            set { _LineNumber = value; }
        }


        private string _WorkListDate;

        public string WorkListDate
        {
            get
            {
                return (TurningDate == null || TurningDate.Length != 10 
                    ? (AdmitDate == null || AdmitDate.Length != 10 ? "" : AdmitDate.Substring(5)) 
                    : TurningDate.Substring(5));
            }
            set { _WorkListDate = value; }
        }


        private string _DoctorDepartment;

        public string DoctorDepartment
        {
            get
            {
                return ((Staff == null || Staff.Person == null || Staff.Person.LastName == null ? "" : Staff.Person.LastName.Length > 10 ? Staff.Person.LastName.Substring(0, 10) : Staff.Person.LastName) 
                    + " " 
                    + (FromDepartment.Length > 10 ? FromDepartment.Substring(0, 10) : FromDepartment)).Trim();
            }
            set { _DoctorDepartment = value; }
        }

        private string _FromDepartment;

        public string FromDepartment
        {
            get
            {
                Department dep = null;
                if (GivenServiceM1 != null && GivenServiceM1.Agenda != null && GivenServiceM1.Agenda.Department != null)
                {
                    dep = GivenServiceM1.Agenda.Department;
                }
                else if (GivenServiceM1 != null && GivenServiceM1.Department != null)
                {
                    dep = GivenServiceM1.Department;
                }
                else if (Dossier != null && Dossier.Department != null)
                {
                    dep = Dossier.Department;
                }
                else if (Department != null)
                {
                    dep = Department;
                }
                string res = "";
                if (dep != null)
                {
                    var parentDep = dep.Department1;
                    res += dep.Name.Replace("درمانگاه", "").Trim();
                    if (parentDep != null && !res.Contains("آزمایشگاه"))
                        res += " " + (parentDep.Name.Replace("درمانگاه", "").Trim());

                    res = res.Trim();
                }
                return res;
            }
            set { _FromDepartment = value; }
        }

        private Department _FromDepartmentObject;

        public Department FromDepartmentObject
        {
            get
            {
                Department dep = null;
                if (GivenServiceM1 != null && GivenServiceM1.Agenda != null && GivenServiceM1.Agenda.Department != null)
                {
                    dep = GivenServiceM1.Agenda.Department;
                }
                else if (GivenServiceM1 != null && GivenServiceM1.Department != null)
                {
                    dep = GivenServiceM1.Department;
                }
                else if (Dossier != null && Dossier.Department != null)
                {
                    dep = Dossier.Department;
                }
                else if (Department != null)
                {
                    dep = Department;
                }

                return dep;
            }
            set { _FromDepartmentObject = value; }
        }


    }

    public partial class Service
    {
        private int? _TestsCount;

        public int? TestsCount
        {
            get { return _TestsCount; }
            set { _TestsCount = value; }
        }

        private string _TestCodeAndAbbr;

        public string TestCodeAndAbbr
        {
            get
            {
                return (OldID == null || !OldID.HasValue ? "" : OldID.Value.ToString("0000")) 
                    + "\n" 
                    + (LaboratoryServiceDetail == null || string.IsNullOrWhiteSpace(LaboratoryServiceDetail.AbbreviationName) 
                        ? (string.IsNullOrWhiteSpace(Name_En) ? Name : Name_En.Trim() ) 
                        : LaboratoryServiceDetail.AbbreviationName.Trim());
            }
            set { _TestCodeAndAbbr = value; }
        }


    }
}
