using System;

namespace OtusHomeWork4
{
    public class StackIsEmptyException : Exception
    {
        public StackIsEmptyException(string message) : base(message)
        {
           
        }
    }
}
