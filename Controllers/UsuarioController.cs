using Primeira_api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primeira_api.Controllers
{
    public class UsuarioController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            return Ok("Oi");
        }

        public async Task<IHttpActionResult> Post([FromBody] Usuario usuario, int idade)
        {
            if (Autentificacao.ValidarToken(Request.Headers.Authorization.ToString()))
            {
                if (Usuario.ValidarEmail(usuario))
                {
                    return Ok(usuario);
                }

                return Content(HttpStatusCode.BadRequest, new { message = "Email incorreto.", campo = "email" });
            }

            return Content(HttpStatusCode.Unauthorized, new { message = "Falha na autentificação." });

        }

        public void Put([FromBody] Usuario usuario)
        {
        }

        public void Delete(int id)
        {
        }
    }
}