using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BaseResponse
    {
        public sbyte result { get; set; }
        public string message { get; set; } = string.Empty;
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }

    }
}
