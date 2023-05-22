using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //readonly'ler constructor'da set edilebilirler. Set de edebilirdik ama kullanıcı kafasına göre kodlamasın diye get yazarız.

        public Result(bool success,string message):this(success)
        {
            //this'i Success=success2i tekrar yazamamak için kullandık.çünkü tekrar etmeme prensibine ters oluyor
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
