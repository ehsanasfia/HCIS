using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISHealthAndFamily.Classes
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
