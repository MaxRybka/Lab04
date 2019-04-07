using System;

namespace Lab04.Exceptions
{
    class InvalidEmailException : Exception
    {
        private string _Message = "Invalid Email!";

        public InvalidEmailException()
        {

        }

        public InvalidEmailException(string message)
            : base(message)
        {
            _Message = message;
        }

        public InvalidEmailException(string message, Exception inner)
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
