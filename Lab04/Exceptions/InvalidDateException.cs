using System;

namespace Lab04.Exceptions
{
    class InvalidDateException : Exception
    {
        private string _Message = "Invalid Date!";

        public InvalidDateException()
        {

        }

        public InvalidDateException(string message)
            : base(message)
        {
            _Message = message;
        }

        public InvalidDateException(string message, Exception inner)
            : base(message, inner)
        {
            _Message = message;
        }

        public override string Message
        {
            get { return _Message; }
        }
    }
}
