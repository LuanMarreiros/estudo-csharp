namespace Primeira_api.Models
{
    public class Login
    {
        public int id_usuario { get; set; }
        public string nomeCompleto { get; set; }
        public string email { get; set; }

        public Login() { }
        public Login(Login login)
        {
            this.nomeCompleto = login.nomeCompleto;
            this.email = login.email;
        }

        public Login(Usuario usuario)
        {
            this.nomeCompleto = usuario.nomeCompleto;
            this.email = usuario.email;
        }
    }
}