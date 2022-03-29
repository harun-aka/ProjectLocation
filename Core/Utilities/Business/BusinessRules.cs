using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules                        //Araç olduğu için interface den türetmeye gerek yok çünkü sadece araç olarak kulanıyoruz.Static.
    {
        public static IResult Run(params IResult[] logics)  //Bir araç olduğu için static oluşturduk metodunu. params sayesinde istediğimiz kadar parametre geçebiliriz.Bu işe yarar.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;   //Parametre ile gönderdiğimiz iş kurallarında hatalı olanı geri döndürür.
                }
            }
            return null;
        }
    }
}
