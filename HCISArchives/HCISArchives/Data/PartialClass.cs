using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCISArchives.Classes;

namespace HCISArchives.Data
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

    public partial class Vw_PathologyResult
    {
        private string _ResultText;

        public string ResultText
        {
            get
            {
                if (_ResultText == null)
                {
                    if (RtfResult != null && !string.IsNullOrWhiteSpace(RtfResult))
                    {
                        if (RtfResult.StartsWith(@"{\rtf"))
                        {
                            System.Windows.Forms.RichTextBox richEditControl1 = new System.Windows.Forms.RichTextBox();
                            richEditControl1.Rtf = RtfResult;
                            richEditControl1.Refresh();
                            _ResultText = richEditControl1.Text.Trim();
                        }
                        else
                        {
                            _ResultText = RtfResult.Trim();
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
    }

    public partial class Vw_CountHospitalization
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AdmitDate))
                {
                    DischargeDate = "";
                }
                else
                {

                    var admit = MainModule.GetDateFromPersianString(AdmitDate.Trim());
                    var add = admit.AddDays(count);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class Spu_ArchiveSpecificICD10Result
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(tarikhebastari))
                {
                    DischargeDate = "";
                }
                else
                {

                    var admit = MainModule.GetDateFromPersianString(tarikhebastari.Trim());
                    var add = admit.AddDays((double)CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class spu_ArchiveBastariPatientResult
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(tarikhebastari))
                {
                    DischargeDate = "";
                }
                else
                {
                    var admit = MainModule.GetDateFromPersianString(tarikhebastari.Trim());
                    var add = admit.AddDays((double)CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class Spu_DishchargeBaMeyleShakhsiResult
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Date))
                {
                    DischargeDate = "";
                }
                else
                {
                    var admit = MainModule.GetDateFromPersianString(Date.Trim());
                    var add = admit.AddDays((double)CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class Spu_DishchargeBehbodeNesbiResult
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Date))
                {
                    DischargeDate = "";
                }
                else
                {
                    var admit = MainModule.GetDateFromPersianString(Date.Trim());
                    var add = admit.AddDays((double)CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class Spu_CountBastariPatientResult
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(tarikhebastari))
                {
                    DischargeDate = "";
                }
                else
                {
                    var admit = MainModule.GetDateFromPersianString(tarikhebastari.Trim());
                    var add = admit.AddDays(CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }

    public partial class ArchiveDashboard
    {
        private bool _FocusColorBit;

        public bool FocusColorBit
        {
            get { return _FocusColorBit; }
            set { _FocusColorBit = value; }
        }
    }
}
