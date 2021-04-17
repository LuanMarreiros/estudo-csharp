namespace Primeira_api.Models
{
    public class Usuario
    {
        public string nomeCompleto { get; set; }
        public int idade { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public static bool ValidarEmail(Usuario usuario)
        {
            if (usuario.email.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}