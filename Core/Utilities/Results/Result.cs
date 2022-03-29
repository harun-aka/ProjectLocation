using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Ctor get olan propu set edebilir.
        public Result(bool success, string message):this(success)  //Ctor önce successi yollayıp çalıştırır sonra message ı gelip çalıştırır.
        {
            Message = message;
            //Success = success;      Bunun için ctor var zaten kod tekrarının önüne geçmek için burada o ctora yollarız.
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; } 
        public string Message { get; }
    }
}
