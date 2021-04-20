﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Primeira_api.Exceptions;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace Primeira_api.Models
{
    public class Autentificacao
    {
        private List<Token> _tokenLoginList = new List<Token>();
        private List<object> _tokenObj = new List<object>();
        private static string _token64 = "";
        private static byte[] _bytes;

        public static bool ValidarToken(string token)
        {
            Token tokenDeserialized;

            if (token.Contains("Bearer "))
            {
                try
                {
                    _bytes = Convert.FromBase64String(token.Replace("Bearer ", ""));

                    tokenDeserialized = JsonConvert.DeserializeObject<Token>(System.Text.Encoding.UTF8.GetString(_bytes));
                }
                catch
                {
                    throw new AutentificationException("Usuário não autorizado.");
                }

                if (tokenDeserialized.verificado)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public List<object> GetToken(Login login)
        {

            if (Token.ValidarLogin(login))
            {
                this._tokenLoginList.Add(new Token(login, true));

                _bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(this._tokenLoginList[0]));

                _token64 = Convert.ToBase64String(_bytes);

                this._tokenObj.Add(new { token = _token64 });

                return this._tokenObj;
            }
            else
            {
                 this._tokenLoginList.Add(new Token(login, false));

                 _bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(this._tokenLoginList[0]));

                 _token64 = Convert.ToBase64String(_bytes);

                 this._tokenObj.Add(new { token = _token64 });

                 return this._tokenObj;
            }
        }
    }
}