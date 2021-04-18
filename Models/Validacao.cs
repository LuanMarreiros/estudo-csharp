﻿namespace Primeira_api.Models
{
    public class Validacao
    {
        public static bool ValidarEmail(Usuario usuario)
        {
            if (usuario.email.Contains("@"))
            {
                return true;
            }

            return false;
        }

        public static bool ValidarEmail(Login login)
        {
            if (login.email.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}