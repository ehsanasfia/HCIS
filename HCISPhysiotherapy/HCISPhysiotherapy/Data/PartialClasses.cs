using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISPhysiotherapy.Data
{
    public partial class Spu_DiagnosticService_HistoryResult
    {
        private string _ResultText;
        private bool? _HasImage;

        public string ResultText
        {
            get
            {
                if (this.Note != null)
                {
                    DevExpress.XtraRichEdit.RichEditControl richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
                    richEditControl1.RtfText = this.Note;
                    richEditControl1.Refresh();
                    var _ResultText = richEditControl1.Text;
                    return _ResultText;
                }
                else return "";
            }
            set
            {
                this._ResultText = value;

            }
        }

        public bool? HasImage
        {

            get
            {
                try
                {


                    if (_HasImage == null)
                    {
                        var stds = MainModule.GetServerMarkoPacs(SerialNumber.ToString());
                        _HasImage = (stds == "OK") ? true : false; //Boolean.Parse(stds.ToString());

                    }
                }
                catch (Exception ex)
                {
                    _HasImage = false;
                }
                return _HasImage;
            }
            set
            {

            }

        }

        private List<Study> _Studies;

        public List<Study> Studies
        {
            get { return _Studies; }
            set { _Studies = value; }
        }

    }

    public partial class Staff
    {
        private bool? _Turn;
        public bool? Turn
        {
            get
            {
                return this._Turn;
            }
            set
            {
                if ((this._Turn != value))
                {
                    this._Turn = value;
                }
            }
        }
    }
    public partial class GivenServiceM
    {
        private string _Day;
        public string Day
        {
            get
            {
                return this._Day = MainModule.GetPersianDayOfWeek(MainModule.GetDateFromPersianString(this.TurningDate).DayOfWeek);
            }
            set
            {
                if ((this._Day != value))
                {
                    this.SendPropertyChanging();
                    this._Day = value;
                    this.SendPropertyChanged("Day");
                }
            }
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
                if (_FromDepartmentObject != null)
                    return _FromDepartmentObject;

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

                _FromDepartmentObject = dep;
                return _FromDepartmentObject;
            }
            set { _FromDepartmentObject = value; }
        }
    }

    public partial class Service
    {
        private string _Comment;
        private float _Amount;
        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                if ((this._Comment != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Comment = value;
                    this.SendPropertyChanged("Comment");
                    this.OnNameChanged();
                }
            }
        }

        public float Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this.OnNameChanging(value.ToString());
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnNameChanged();
                }
            }
        }
    }
    public partial class Person
    {
        private string _FullName;
        public string FullName
        {
            get
            {
                return this._FullName = this.FirstName + " " + this.LastName;
            }
            set
            {
                if ((this._FullName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FullName = value;
                    this.SendPropertyChanged("FullName");
                    this.OnFirstNameChanged();
                }
            }
        }
    }
}
