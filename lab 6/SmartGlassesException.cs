using System;

namespace Lab_6_OOP
{
    class SmartGlassesException : Exception
    {
        public SmartGlassesException() : base()
        {
        }

        public SmartGlassesException(string message) : base(message)
        {
        }

        public SmartGlassesException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
