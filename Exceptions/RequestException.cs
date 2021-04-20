using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

namespace Primeira_api.Exceptions
{
    public class RequestException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage hrm = new HttpResponseMessage();

            hrm.StatusCode = HttpStatusCode.NoContent;
            hrm.Content = null;
            context.Response = hrm;
        }
    }
}