using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISDiagnosticServices.Data
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
                if (_HasImage == null)
                {
                    var stds = MainModule.StudiesOf(SerialNumber);
                    _HasImage = stds.Any();
                    Studies = stds;
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

    public partial class GivenServiceM
    {
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
        private float _Amount;

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
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                }
            }
        }
    }
}
