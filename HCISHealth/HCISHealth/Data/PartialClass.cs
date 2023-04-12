using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCISHealth.Classes;

namespace HCISHealth.Data
{
    public partial class Spu_DiagnosticService_HistoryResult
    {
        //private string _ResultText;
        private bool? _HasImage;

        //public string ResultText
        //{
        //    get
        //    {
        //        if (this.Note != null)
        //        {
        //            DevExpress.XtraRichEdit.RichEditControl richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
        //            richEditControl1.RtfText = this.Note;
        //            richEditControl1.Refresh();
        //            var _ResultText = richEditControl1.Text;
        //            return _ResultText;
        //        }
        //        else return "";
        //    }
        //    set
        //    {
        //        this._ResultText = value;

        //    }
        //}

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

    public partial class QA
    {
        private Service _PService;

        public Service PService
        {
            get { return _PService; }
            set { _PService = value; }
        }
    }
}
