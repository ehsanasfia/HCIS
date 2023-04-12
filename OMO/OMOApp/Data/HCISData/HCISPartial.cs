using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMOApp.Data.HCISData
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
                if (_HasImage == null)
                {
                    var stds = Classes.MainModule.StudiesOf(SerialNumber);
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

    public partial class Service
    {
        private string _Comment;
        private float _Amount;
        private float _Number;
        private DrugFrequencyUsage _HIX;
        private string _O2Comment;
        private string _BloodComment;

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
                    this._Comment = value;
                }
            }
        }
        public string O2Comment
        {
            get
            {
                return this._O2Comment;
            }
            set
            {
                if ((this._O2Comment != value))
                {
                    this._O2Comment = value;
                }
            }
        }

        public string BloodComment
        {
            get
            {
                return this._BloodComment;
            }
            set
            {
                if ((this._BloodComment != value))
                {
                    this._BloodComment = value;
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
                    this._HIX = value;
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
                    this._Amount = value;
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
                    this._Number = value;
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
