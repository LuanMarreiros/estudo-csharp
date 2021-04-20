using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Primeira_api.Exceptions
{
    public class RequestException : ExceptionFilterAttribute
    {
        private HttpStatusCode ValidarException(Exception exception)
        {
            Type type = exception.GetType();

            switch (type.Name)
            {
                case "AutentificationException":
                    return HttpStatusCode.Unauthorized;

                case "EmailException":
                    return HttpStatusCode.Forbidden;
            }

            return HttpStatusCode.BadRequest;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage hrm = new HttpResponseMessage();

            hrm.StatusCode = ValidarException(context.Exception);
            hrm.Content = new StringContent(JsonConvert.SerializeObject(new { message = context.Exception.Message }));

            context.Response = hrm;
            context.Response.Content.Headers.Remove("Content-Type");
            context.Response.Content.Headers.Add("Content-Type", "application/json; charset=utf-8");
        }
    }
}