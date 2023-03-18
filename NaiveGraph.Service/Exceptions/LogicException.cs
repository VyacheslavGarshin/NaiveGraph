using System;

namespace NaiveGraph.Service.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string message) : base(message)
        {
        }
    }
}
