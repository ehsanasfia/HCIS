using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISPsychology.Data
{

    public partial class Spu_DrugHistoryResult
    {
        private bool _Color;

        public bool Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

    }
    public partial class Optometry
    {
        private bool _Lock;

        public bool Lock
        {
            get { return _Lock; }
            set { _Lock = value; }
        }
    }

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
    public partial class Service
    {
        private string _Comment;
        private string _Organ;
        private float _Amount;
        private string _NameAndShape;
        private string _Test;
        private DrugFrequencyUsage _HIX;
        public string NameAndShape
        {
            get
            {
                return this.Name + " - " + Shape;
            }

        }
        public string Test
        {
            get
            {
                return this.LaboratoryServiceDetail.AbbreviationName + "  " + "(" + Name + ")";
            }

        }

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
                    this.SendPropertyChanging();
                    this._Comment = value;
                    this.SendPropertyChanged("Comment");
                }
            }
        }
        public string Organ
        {
            get
            {
                return this._Organ;
            }
            set
            {
                if ((this._Organ != value))
                {
                    this.SendPropertyChanging();
                    this._Organ = value;
                    this.SendPropertyChanged("Organ");
                }
            }
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
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                }
            }
        }

        private bool _MustHavePrice;

        public bool MustHavePrice
        {
            get { return _MustHavePrice; }
            set { _MustHavePrice = value; }
        }

    }
    public partial class Person
    {
        private int _age;

        public int Age
        {

            get
            {

                if (this._BirthDate != null)
                {
                    try
                    {
                        var now = MainModule.GetPersianFirstDateOfYear(DateTime.Now);
                        this._age = int.Parse(now.Substring(0, 4)) - int.Parse(BirthDate.Substring(0, 4));
                    }
                    catch (Exception)
                    {


                    }


                }
                return this._age;
            }


        }



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


