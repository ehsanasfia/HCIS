using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISNurse.Classes
{
    public class MyMedicalRecord
    {
        private string _ItemName;

        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private bool _Answer;

        public bool Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }
    }
}
