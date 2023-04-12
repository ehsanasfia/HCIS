using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISCash.Data
{
    class PartialClasses
    {
    }
    partial class Staff
    {
        private string _FullName;

        public string FullName
        {
            get { return this.Person. FirstName + " " + this.Person.LastName; }
        }

    }
    partial class Dossier
    {
        private string _WardName;

        public string WardName
        {
            get {
                var GsmList = this.GivenServiceMs.Where(x => x.ServiceCategoryID == 10).ToList();
                string Ward = "";
                if (GsmList.Count > 0)
                  Ward=GsmList.OrderBy(x => x.SerialNumber).FirstOrDefault().Department.Name;
 return Ward;
            }
        }

    }

    public partial class Service
    {
        
        private bool _MustHavePrice;

        public bool MustHavePrice
        {
            get { return _MustHavePrice; }
            set { _MustHavePrice = value; }
        }
    }
    //public partial class GivenServiseM
    //{
    //    private string _DepName;
    //    public string ServiceCatName
    //    {
    //        get
    //        {
    //            return this._DepName = this.Equals + " " + this.LastName;
    //        }
    //        set
    //        {
    //            if ((this._DepName != value))
    //            {

    //                this._DepName = value;
    //            }
    //        }
    //    }
    //}
}
