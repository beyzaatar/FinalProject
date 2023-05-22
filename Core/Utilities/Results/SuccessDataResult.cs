using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //data için bir şey döndürmek istemeyebiliriz. T için o anki default değeri döndürmüş oluruz default ile
        public SuccessDataResult(string message) : base(default, true, message) //çalıştığımız T'nin default'udur. default dataya karşılık gelir
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
