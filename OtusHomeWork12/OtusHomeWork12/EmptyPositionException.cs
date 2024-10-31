using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12
{
    internal class EmptyPositionException : Exception
    {
        public EmptyPositionException(string message) : base(message) { }
    }
}
