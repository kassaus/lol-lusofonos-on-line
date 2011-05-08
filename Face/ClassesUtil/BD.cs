using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Reflection.Emit;


namespace ClassesUtil
{
    public class BD
    {
        private string ligacao;

        public BD()
        {

        }

        public BD(string strligacao)
        {
            ligacao = strligacao;
        }

        public void setligacao(string ligacao)
        {
            this.ligacao = ligacao;
        }

        protected SqlConnection getligacao()
        {
            SqlConnection retLigacao;
            retLigacao = new SqlConnection(ligacao);
            retLigacao.Open();
            return retLigacao;
        }

        protected void closeligacao(SqlConnection con)
        {

            con.Close();
            con = null;
        }

        

        #region Selects

        public SqlDataReader seleccionaTodosDados(string strParametros)
        {

            //obtem a string de ligacao
            using (SqlConnection ligacao = getligacao())
            {
                SqlDataReader canal;

                //cria um objeto command a partir da stored procedure
                //SqlCommand cmd = new SqlCommand(strSP, cn);
                using (SqlCommand comando = new SqlCommand(strParametros, ligacao))
                {
                    //executa o comando e retorna o datareader
                    canal = comando.ExecuteReader();
                    return canal;
                }
            }
        }

        public SqlDataReader seleccionaDadosParametros(string strConsulta, IEnumerable<SqlParameter> cmdParametros)
        {
            SqlConnection ligacao = getligacao();
            SqlDataReader canal;
            //cria um objeto command a partir da stored procedure
            //SqlCommand cmd = new SqlCommand(strSP, cn);
            SqlCommand comando = new SqlCommand(strConsulta, ligacao);

            foreach (SqlParameter par in cmdParametros)
            {
                comando.Parameters.Add(par);
                par.Direction = System.Data.ParameterDirection.Input;
            }
            //int num = cmd.ExecuteNonQuery();
            canal = comando.ExecuteReader();

            return canal;
        }

        #endregion

        #region Inserts



        public int insereDados(string strConsulta, IEnumerable<SqlParameter> cmdParametros)
        {
            //obtem a string de ligacao
            using (SqlConnection ligacao = getligacao())
            {
                //cria um objeto command a partir da stored procedure
                //SqlCommand cmd = new SqlCommand(strSP, cn);
                SqlCommand comando = new SqlCommand(strConsulta, ligacao);

                foreach (SqlParameter par in cmdParametros)
                {
                    comando.Parameters.Add(par);
                    par.Direction = System.Data.ParameterDirection.Input;
                }

                int num = comando.ExecuteNonQuery();               
                return num;
            }
        }

        #endregion



    }
}

