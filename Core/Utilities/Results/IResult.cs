using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        //Sadece get yazmamızın nedeni oluştururken sadece ctorla set edip değişmesini istemeyiz.
        bool Success { get; } //interface propları zaten publictir.
        string Message { get; }

    }
}
