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

        public int efectuaRegisto(IEnumerable<string> campos, string ligacao)
        {
            this.ligacao = ligacao;
            System.Text.ASCIIEncoding converte = new System.Text.ASCIIEncoding();

            

            string consultaUser = "insert into Users(email, password) Values(@parEmail, @parPassword)";

            List<SqlParameter> parametrosUser = new List<SqlParameter>();

            parametrosUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });

            parametrosUser.Add(new SqlParameter("@parPassword", SqlDbType.NVarChar) { Value = campos.ElementAt(1) });

            int dadosInseridos = insereDados(consultaUser, parametrosUser);

            if (dadosInseridos != 0)
            {
                List<SqlParameter> parametrosConsultaIdUser = new List<SqlParameter>();
                string consultaIdUser = "select * from Users where email LIKE @parEmail";
                parametrosConsultaIdUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });
               // parametrosConsultaIdUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = "pppluis@gmail.com" });
                SqlDataReader canal = seleccionaDadosParametros(consultaIdUser, parametrosConsultaIdUser);
                
                if (canal.HasRows)
                {
                    canal.Read();
                    string teste = canal["idUser"].ToString();

                }
                string consultaCadastro = "insert into Cadastro(idUser, idCidade, nome, apelido, sexo, dataNascimento, email, imagem)" +
           "Values(@parIdUser, @parIdCidade, @parNome, @parApelido, @parSexo, @parDataNascimento, @parEmail, @parImagem)";

                List<SqlParameter> parametrosCadastro = new List<SqlParameter>();

                parametrosCadastro.Add(new SqlParameter("@parIdCidade", SqlDbType.Int) { Value = campos.ElementAt(2) });

                parametrosCadastro.Add(new SqlParameter("@parNome", SqlDbType.NVarChar) { Value = campos.ElementAt(3) });

                parametrosCadastro.Add(new SqlParameter("@parApelido", SqlDbType.NVarChar) { Value = campos.ElementAt(4) });

                parametrosCadastro.Add(new SqlParameter("@parSexo", SqlDbType.NVarChar) { Value = campos.ElementAt(5) });

                parametrosCadastro.Add(new SqlParameter("@parDataNascimento", SqlDbType.Date) { Value = campos.ElementAt(6) });

                parametrosCadastro.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });

                parametrosCadastro.Add(new SqlParameter("@parImagem", SqlDbType.VarBinary) { Value = converte.GetBytes(campos.ElementAt(7)) });

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

