using Primeira_api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Primeira_api.Exceptions;

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

            throw new AutentificationException("Usuário não autorizado.");
        }

        public async Task<IHttpActionResult> Get(string filter)
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                return Content(HttpStatusCode.OK, Usuario.SelectUsuario(filter));
            }

            throw new AutentificationException("Usuário não autorizado.");
        }

        public async Task<IHttpActionResult> Get(string filter, string orderBy)
        {
            this._response = new Response();

            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                return Content(HttpStatusCode.OK, Usuario.SelectUsuario(filter, orderBy));
            }

            throw new AutentificationException("Usuário não autorizado.");
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

                throw new EmailException("O email inserido está incorreto.");
            }

            throw new AutentificationException("Usuário não autorizado.");
        }

        public void Put([FromBody] Usuario usuario)
        {
        }

        public void Delete(int id)
        {
        }
    }
}