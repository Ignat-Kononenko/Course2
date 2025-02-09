using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyCustomException : Exception                                              // нужен для единой системы(try - catch)
    {
        public MyCustomException() { }
        public MyCustomException(string message) : base(message) { }

        public MyCustomException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class NullRefException : MyCustomException { 
        public NullRefException() { }

        public NullRefException(string message) : base(message) { }

        public NullRefException(string message, Exception exception) : base(message, exception) { }    
    }

    public class InvalidDataException : MyCustomException
    {
        public InvalidDataException() { }

        public InvalidDataException(string message) : base(message) { }

        public InvalidDataException(string message, Exception inner) : base(message, inner) { }
    }

    public class ConfirmityException: MyCustomException
    {
        public ConfirmityException() { }
        public ConfirmityException(string message) : base(message) { }
        public ConfirmityException(string message, Exception exception) : base(message, exception) { }
    }


}
