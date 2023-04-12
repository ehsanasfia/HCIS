using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCISShareLibrary.Data;


namespace HCISShareLibrary
{
   public abstract class Client
    {
        //  Department MyClient { set; get; }
  public   abstract   Person SearchWithNationalCode(string Code, ref Boolean cancelflag);
 public   abstract    Person SearchWithMedicalID(string Code, ref Boolean cancelflag);
      

    }
}
