using Primeira_api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primeira_api.Controllers
{
    public class AutentificacaoController : ApiController
    {
        private Response _response = new Response();

        public async Task<IHttpActionResult> Post([FromBody] Login login)
        {
            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString())){
                if (Validacao.ValidarEmail(login))
                {
                    Autentificacao auth = new Autentificacao();

                    return Content(HttpStatusCode.OK, auth.GetToken(login));
                }

                _response.SetResponse("O email inserido está incorreto.", "email", "Solicitação inválida.");

                return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
            }

            _response.SetResponse("Falha na autentificação.", "Authorization", "Usuário não autorizado.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

    }
}