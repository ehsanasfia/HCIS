using System;
using DevExpress.Xpo;

namespace DrugManagement.Data
{

    public class DataContexSECr : XPObject
    {
        public DataContexSECr() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public DataContexSECr(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}