using Primeira_api.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Primeira_api.Models
{
    public class Usuario : SQLConection
    {
        private static Response _response;
        public int id_usuario { get; set; }
        public string nomeCompleto { get; set; }
        public int idade { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public Usuario() { }
        public Usuario(string nomeCompleto, int idade, string email, string telefone)
        {
            this.nomeCompleto = nomeCompleto;
            this.idade = idade;
            this.email = email;
            this.telefone = telefone;
        }
        public Usuario(int id_usuario, string nomeCompleto, int idade, string email, string telefone)
        {
            this.id_usuario = id_usuario;
            this.nomeCompleto = nomeCompleto;
            this.idade = idade;
            this.email = email;
            this.telefone = telefone;
        }

        public Usuario(SqlDataReader result)
        {
            this.id_usuario = Convert.ToInt32(result["id_usuario"].ToString().Trim());
            this.nomeCompleto = result["nomeCompleto"].ToString().Trim();
            this.idade = Convert.ToInt32(result["idade"].ToString().Trim());
            this.email = result["email"].ToString().Trim();
            this.telefone = result["telefone"].ToString().Trim();
        }
        public static List<Usuario> SelectUsuario()
        {
            List<Usuario> result = SQLConection.Select("select * from Usuario");

            return result;
        }


        public static List<Usuario> SelectUsuario(string filter)
        {
            List<Usuario> result = SQLConection.Select(string.Format("select * from Usuario order by {0}", filter));

            return result;
        }

        public static List<Usuario> SelectUsuario(string filter, string orderBy)
        {
            List<Usuario> result = SQLConection.Select(string.Format("select * from Usuario order by {0} {1}", filter, orderBy));

            return result;
        }

        public static bool SelectUsuarioByEmail(string email)
        {
            List<Usuario> result = SQLConection.Select(String.Format("select * from Usuario where email = '{0}'", email));

            if (result.Count != 0)
            {
                return true;
            }

            return false;
        }

        public static object PostUsuario(Usuario usuario)
        {
            _response = new Response();

            if (SQLConection.Post(String.Format("insert into Usuario (nomeCompleto, idade, email, telefone) values ('{0}', {1}, '{2}', '{3}');", usuario.nomeCompleto, usuario.idade, usuario.email, usuario.telefone)))
            {
                _response.SetResponse("Cadastro realizado com sucesso.");

                return _response.GetResponse();
            }

            _response.SetResponse("Não foi possível realizar o cadastro.");

            return _response.GetResponse();
        }
    }
}