﻿namespace Primeira_api.Models
{
    public class Autentificacao
    {
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