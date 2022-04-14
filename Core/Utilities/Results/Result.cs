using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success) 
        {
            Message = message; 
            //Get'ler ctor içinde set edilebilir
            //Success yazmak yerine this kullanarak alttaki ctora succesi yolladık çok kod yazmaktan kaçındık ve kendimizi tekrar etmedik.

        }
        public Result(bool success) 
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
