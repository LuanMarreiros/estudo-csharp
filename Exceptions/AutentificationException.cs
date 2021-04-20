using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Primeira_api.Exceptions
{
    public class AutentificationException : Exception
    {
        public AutentificationException() { }
        public AutentificationException(string message) : base(message) { }
    }
}