using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISAngio.Data
{
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

    public partial class GivenServiceM
    {
        private string _FromDepartment;

        public string FromDepartment
        {
            get
            {
                Department dep = null;
                if (GivenServiceM1 != null && GivenServiceM1.Department != null)
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
                if (GivenServiceM1 != null && GivenServiceM1.Department != null)
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
}
