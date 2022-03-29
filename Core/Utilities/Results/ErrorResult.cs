using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)// Base class Result olduğu için Result a yollar bu değerleri.
        {
        }
        public ErrorResult() : base(false) // Base classda 2 tane ctor olduğu için biz de öyle yazmalıyız.
        {
        }
    }
}
