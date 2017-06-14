using System;

namespace SmartphoneDSS.Exceptions
{
    class EmptyListException : Exception
    {
        public EmptyListException(string message) : base(message)
        {
        }
    }
}
