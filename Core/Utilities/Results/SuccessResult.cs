using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true,message)// Base class Result olduğu için Result a yollar bu değerleri.
        {
        }
        public SuccessResult():base(true) // Base classda 2 tane ctor olduğu için biz de öyle yazmalıyız.
        {
        }
    }
}
