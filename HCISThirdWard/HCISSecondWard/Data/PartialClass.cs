using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISSecondWard.Data
{

    public partial class Spu_DiagnosticService_HistoryResult
    {
        private string _ResultText;
        private bool? _HasImage;
        public string ResultText
        {
            get
            {
                if (_ResultText == null)
                {
                    if (Note != null && !string.IsNullOrWhiteSpace(Note))
                    {
                        if (Note.StartsWith(@"{\rtf"))
                        {
                            System.Windows.Forms.RichTextBox richEditControl1 = new System.Windows.Forms.RichTextBox();
                            richEditControl1.Rtf = Note;
                            richEditControl1.Refresh();
                            _ResultText = richEditControl1.Text.Trim();
                        }
                        else
                        {
                            _ResultText = Note.Trim();
                        }
                    }
                    else
                        _ResultText = "";
                }
                return _ResultText;
            }
            set
            {
                _ResultText = value;
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
                        var stds =Classes.MainModule.GetServerMarkoPacs(SerialNumber.ToString());
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

        private int age;
        public int Age

        {
            set { this.age = value; /*Classes.MainModule.GetAge(Classes.MainModule.GetDateFromPersianString(this.BirthDate))*/; }
            get { return this.age = Classes.MainModule.GetAge(Classes.MainModule.GetDateFromPersianString(this.BirthDate)); }
        }
    }
    public partial class Service
    {
        private string _Comment;
        private float _Amount;
        private float _Number;
        private DrugFrequencyUsage _HIX;
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
        private bool _MustHavePrice;

        public bool MustHavePrice
        {
            get { return _MustHavePrice; }
            set { _MustHavePrice = value; }
        }
        public DrugFrequencyUsage HIX
        {
            get
            {
                return this._HIX;
            }
            set
            {
                if ((this._HIX != value))
                {
                    this.SendPropertyChanging();
                    this._HIX = value;
                    this.SendPropertyChanged("HIX");
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

        public float Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                if ((this._Number != value))
                {
                    this.OnNameChanging(value.ToString());
                    this.SendPropertyChanging();
                    this._Number = value;
                    this.SendPropertyChanged("Number");
                    this.OnNameChanged();
                }
            }
        }

        private Service _Partial_LabParent;

        public Service Partial_LabParent
        {
            get { return _Partial_LabParent; }
            set { _Partial_LabParent = value; }
        }

        private bool _isNIS;

        public bool IsNIS
        {
            get { return _isNIS; }
            set { _isNIS = value; }
        }


        public string Date { get; set; }
        public string Time { get; set; }
    }
    public partial class VwDoctorInstraction
    {
        private Boolean _IsNew;
        public Boolean IsNew
        {
            get
            {
                return this._IsNew;
            }
            set
            {
                if ((this._IsNew != value))
                {

                    this._IsNew = value;
                }
            }
        }
        private string _ResultText;
        public string ResultText
        {
            get
            {
                if (_ResultText == null)
                {
                    if (Result != null && !string.IsNullOrWhiteSpace(Result))
                    {
                        if (Result.StartsWith(@"{\rtf"))
                        {
                            System.Windows.Forms.RichTextBox richEditControl1 = new System.Windows.Forms.RichTextBox();
                            richEditControl1.Rtf = Result;
                            richEditControl1.Refresh();
                            _ResultText = richEditControl1.Text.Trim();
                        }
                        else
                        {
                            _ResultText = Result.Trim();
                        }
                    }
                    else
                        _ResultText = "";
                }
                return _ResultText;
            }
            set
            {
                this._ResultText = value;
            }
        }
    }

    public partial class GivenServiceD
    {
        private bool _Used;
        public bool Used
        {
            get
            {
                return this._Used;
            }
            set
            {
                if ((this._Used != value))
                {
                    this.SendPropertyChanging();
                    this._Used = value;
                    this.SendPropertyChanged("Used");
                }
            }
        }

        private double _EditabelAmount;
        public double EditabelAmount
        {
            get
            {
                return this._EditabelAmount;
            }
            set
            {
                if ((this._EditabelAmount != value))
                {
                    this.SendPropertyChanging();
                    this._EditabelAmount = value;
                    this.SendPropertyChanged("EditabelAmount");
                }
            }
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
}
