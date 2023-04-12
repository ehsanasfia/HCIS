using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HCISShareLibrary.Data;
namespace HCISShareLibrary
{
    interface IClinetProcess
    {
        Person SearchWithNationalCode(string Code, ref Boolean cancelflag);
        Person SearchWithMedicalID(string Code, ref Boolean cancelflag);
    }

}
