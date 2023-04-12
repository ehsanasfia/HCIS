using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISShareLibrary.Data;
using System.Windows.Forms;
using HCISShareLibrary.Classes;
namespace HCISShareLibrary
{
   public  class CommonModule
    {
      public   CommonModule()
        {
            MainClinet = Get(0);
        }
        public static Client MainClinet;
        public static Client Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new OilClass();
                default:
                    return new DefaultClass();
            }

        }
        public Guid AdmitSearchPerson(String Code, ref Boolean cancelflag)
        {
            Person MyPerson = new Person();
            if (Code.Length < 10)
                MyPerson = MainClinet.SearchWithMedicalID(Code, ref cancelflag);
            else
                MyPerson = MainClinet.SearchWithNationalCode(Code, ref cancelflag);
            if (MyPerson == null)
                MyPerson = new Person();
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
