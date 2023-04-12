using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCISShareLibrary.Data;

namespace HCISShareLibrary
{
    class GodClass
    {
        public Guid AdmitSearchPerson(String Code, ref Boolean cancelflag)
        {
            Person MyPerson = new Person();
            if (Code.Length < 10)
                MyPerson = Program.MainClinet.SearchWithMedicalID(Code, ref cancelflag);
            else
                MyPerson = Program.MainClinet.SearchWithNationalCode(Code, ref cancelflag);
            return MyPerson.ID;
        }
        public Boolean AllowChooseInsure(string InsuranceName)
        {
            using (HCISDataDataContext dc = new HCISDataDataContext())
            {
                var allowObj = dc.Insurances.FirstOrDefault(c => c.Name.CompareTo(InsuranceName) == 0);
                Boolean allow = false;
                if (allowObj != null)
                    allow = allowObj.AllowChoose;
                return allow;
            };

        }
    }
}
