﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Primeira_api.DTO;

namespace Primeira_api.Models
{
    public class Token : Login
    {
        public bool verificado { get; set; }
        public DateTime horaLogin { get; set; }

        public Token()
        {
         
        }

        public Token(Login login)
        {
            this.nomeCompleto = login.nomeCompleto;
            this.email = login.email;
        }

        public Token(Login login, bool verificao)
        {
            if (verificao)
            {
                this.nomeCompleto = login.nomeCompleto;
                this.email = login.email;
                this.verificado = verificao;
                this.horaLogin = new DateTime().Date;
            }
            else
            {
                this.nomeCompleto = "";
                this.email = "";
                this.verificado = verificao;
                this.horaLogin = new DateTime().Date;
            }
        }

        public static bool ValidarToken(Login login) {

            var result = SQLConection.Select(String.Format("select * from Usuario where email = '{0}' and nomeCompleto = '{1}'", login.email, login.nomeCompleto));

            if(result.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}