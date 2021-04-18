using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Primeira_api.Models;
using System.Threading.Tasks;

namespace Primeira_api.Controllers
{
    public class AutentificacaoController : ApiController
    {
        private Response _response = new Response();

        public async Task<IHttpActionResult> Post([FromBody] Login login)
        {
            if (Validacao.ValidarEmail(login))
            {
                Autentificacao auth = new Autentificacao();

                return Content(HttpStatusCode.OK, auth.GetToken(login));
            }

            _response.SetResponse("O email inserido está incorreto.", "email", "Solicitação inválida.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

    }
}