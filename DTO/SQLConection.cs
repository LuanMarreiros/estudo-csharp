using Primeira_api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Primeira_api.DTO
{
    public class SQLConection
    {
        private static SqlConnection _conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["BDO_conection"].ConnectionString);
        private static SqlCommand _comando = new SqlCommand("", _conexao);

        public static List<Usuario> Select(string comando)
        {
            SqlDataReader result;
            List<Usuario> resultList = new List<Usuario>();

            _comando.CommandText = comando;

            try
            {
                _conexao.Open();

                result = _comando.ExecuteReader();

                while (result.Read())
                {
                    resultList.Add(new Usuario(result));
                }

                _conexao.Close();
            }
            catch (Exception erro)
            {
                _conexao.Close();

                throw erro;
            }

            return resultList;
        }

        public static bool Post(string comando)
        {
            _comando.CommandText = comando;

            try
            {
                _conexao.Open();
                _comando.ExecuteNonQuery();
                _conexao.Close();
            }
            catch (Exception erro)
            {
                _conexao.Close();

                throw erro;
            }

            return true;
        }
    }
}