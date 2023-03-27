using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud_Shared
{
    public class ResponseAPI <T>
    {
        public bool IsCorrect { get; set; }

        public T? Value { get; set; }

        public string? Message { get; set; }
    }
}
