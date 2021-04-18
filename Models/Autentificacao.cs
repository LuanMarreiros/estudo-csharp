using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Primeira_api.DTO;

namespace Primeira_api.Models
{
    public class Autentificacao
    {
        private List<Token> _tokenLoginList = new List<Token>();
        private List<object> _token = new List<object>();
        private static string _token64 = "";
        private static byte[] _bytes;

        public static bool ValidarToken(string token)
        {
            Token tokenDeserialized;

            _bytes = Convert.FromBase64String(token.Replace("Bearer ", ""));

            tokenDeserialized = JsonConvert.DeserializeObject<Token>(System.Text.Encoding.UTF8.GetString(_bytes));

            if (tokenDeserialized.verificado)
            {
                return true;
            }

            return false;
        }

        public List<object> GetToken(Login login) {

            if (Token.ValidarToken(login))
            {
                this._tokenLoginList.Add(new Token(login, true));

                _bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(this._tokenLoginList[0]));

                _token64 = Convert.ToBase64String(_bytes);

                this._token.Add(new { token = _token64 });

                return this._token;
            }
            else
            {
                this._tokenLoginList.Add(new Token(login, false));

                _bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(this._tokenLoginList[0]));

                _token64 = Convert.ToBase64String(_bytes);

                this._token.Add(new { token = _token64 });

                return this._token;
            }
        }
    }
}