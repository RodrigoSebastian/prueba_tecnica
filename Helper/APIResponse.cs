using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Helper
{
    public class APIResponse<T>
    {
        public int StatusCode { get; set; } = 200;
        public T? Result { get; set; }
        public string Message { get; set; } = "OK";
    }
}