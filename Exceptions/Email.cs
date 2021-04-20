using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Primeira_api.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException() { }
        public EmailException(string message) : base(message) { }
    }
}