using Primeira_api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primeira_api.Controllers
{
    public class UsuarioController : ApiController
    {
        private Response _response;

        public async Task<IHttpActionResult> Get()
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                return Content(HttpStatusCode.OK, Usuario.SelectUsuario());
            }

            _response.SetResponse("Falha na autentificação.", "Authorization", "Usuário não autorizado.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

        public async Task<IHttpActionResult> Get(string filter)
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                return Content(HttpStatusCode.OK, Usuario.SelectUsuario(filter));
            }

            _response.SetResponse("Falha na autentificação.", "Authorization", "Usuário não autorizado.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

        public async Task<IHttpActionResult> Get(string filter, string orderBy)
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                return Content(HttpStatusCode.OK, Usuario.SelectUsuario(filter, orderBy));
            }

            _response.SetResponse("Falha na autentificação.", "Authorization", "Usuário não autorizado.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

        public async Task<IHttpActionResult> Post([FromBody] Usuario usuario)
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                if (Validacao.ValidarEmail(usuario))
                {
                    return Ok(Usuario.PostUsuario(usuario));
                }

                _response.SetResponse("O email inserido está incorreto.", "email", "Solicitação inválida.");

                return Content(HttpStatusCode.BadRequest, _response.GetResponse());
            }

            _response.SetResponse("Falha na autentificação.", "Authorization", "Usuário não autorizado.");

            return Content(HttpStatusCode.Unauthorized, _response.GetResponse());
        }

        public void Put([FromBody] Usuario usuario)
        {
        }

        public void Delete(int id)
        {
        }
    }
}