using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork3
{
    internal class NegativeDiscriminantException : Exception
    {
        public override string Message { get; }
        public NegativeDiscriminantException(string message) 
        {
            Message = message;
        }
    }
}
