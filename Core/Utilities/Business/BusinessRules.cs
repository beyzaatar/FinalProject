using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params ile istediğimiz kadar ıresult parametresi gönderebiliriz buraya
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    //kurala uymayanı döndür
                    return logic; //parametreyle gönderdiğimiz iş kurallarından(logics) başarısız olanı business'a bildiriyoruz
                }
            }
            return null;
        }
    }
}
