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

        public Boolean verificaUser(string email, string password, string ligacao)
        {
            this.ligacao = ligacao;

            string consulta = "Select * from Users Where email LIKE @parMail";
            SqlParameter[] parametros = new SqlParameter[1];

            parametros[0] = new SqlParameter("@parMail", SqlDbType.NVarChar);
            parametros[0].Value = email;



            SqlDataReader canal = seleccionaDadosParametros(consulta, parametros);
            if (canal.HasRows)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public int efectuaRegisto(IEnumerable<string> campos, string ligacao, byte[] imagem)
        {
            this.ligacao = ligacao;

            string consultaUser = "insert into Users(email, password,idPais) Values(@parEmail, @parPassword, @parIdPais)";


            SqlParameter[] parametrosUser = new SqlParameter[3];

            parametrosUser[0] = new SqlParameter("@parEmail", SqlDbType.NVarChar);
            parametrosUser[0].Value = campos[0];

            parametrosUser[1] = new SqlParameter("@parPassword", SqlDbType.NVarChar);
            parametrosUser[1].Value = campos[1];

            parametrosUser[2] = new SqlParameter("@paridPais", SqlDbType.Int);
            parametrosUser[2].Value = Convert.ToInt32(campos[2]);

            int dadosInseridos = insereDados(consultaUser, parametrosUser);

            if (dadosInseridos != 0)
            {
                string consultaCadastro = "insert into Cadastro(nome, apelido, sexo, dataNascimento, email, imagem)" +
           "Values(@parNome, @parApelido, @parSexo, @parDataNascimento, @parEmail, @parImagem)";

                List<SqlParameter> parametrosCadastro = new List<SqlParameter>();

                parametrosCadastro.Add(new SqlParameter("@parNome", SqlDbType.NVarChar) { Value = campos[3] });

               parametrosCadastro.Add(new SqlParameter("@parApelido", SqlDbType.NVarChar) { Value = campos[4]});

                parametrosCadastro.Add(new SqlParameter("@parSexo", SqlDbType.NVarChar) { Value = campos[5]});
 
               parametrosCadastro.Add(new SqlParameter("@parDataNascimento", SqlDbType.Date) { Value = campos[6]});
 
                parametrosCadastro.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos[0]});

                parametrosCadastro.Add(new SqlParameter("@parImagem", SqlDbType.VarBinary) { Value = imagem});
 
                return insereDados(consultaCadastro, parametrosCadastro);

            }
            return 0;

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
            //cria um objeto command a partir da stored procedure
            //SqlCommand cmd = new SqlCommand(strSP, cn);
            SqlCommand comando = new SqlCommand(strConsulta, ligacao);

            foreach (SqlParameter par in cmdParametros)
            {
                comando.Parameters.Add(par);
                par.Direction = System.Data.ParameterDirection.Input;
            }
            //int num = cmd.ExecuteNonQuery();
            SqlDataReader canal = comando.ExecuteReader();

            return canal;

        }

        #endregion

        #region Inserts



        public int insereDados(string strConsulta, IEnumerable<SqlParameter> cmdParametros)
        {
            //obtem a string de ligacao
            SqlConnection ligacao = getligacao();
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

        #endregion



    }
}

