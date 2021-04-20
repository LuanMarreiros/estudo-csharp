using Primeira_api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Primeira_api.Exceptions;

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

            throw new EmailException("O email inserido está incorreto.");
        }

    }
}