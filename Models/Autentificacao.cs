namespace Primeira_api.Models
{
    public class Autentificacao
    {
        public string token { get; set; }

        public static bool ValidarToken(string token)
        {
            if (token == "Bearer teste")
            {
                return true;
            }
            return false;
        }
    }
}