﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;


namespace ClassesUtil
{
    public class Gestor
    {
        string ligacao = null;

        public Gestor()
        {

        }

        BD acessoBd = new BD();         



        public bool comparadatas(DateTime data)
        {
            bool res = false;
            if (data > DateTime.Today)
            {
                res = true;
               
            }
            else
            {
                res = false;                
            }
            return res;
        } 


        /* Verifica se uma string contem um caractere numérico*/
        public bool contemNumero(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        } 


        /* devolve todos os dados da tabela referida na consulta referentes ao utilizador identificado pelo email passado
            por argumento*/
        public SqlDataReader DadosUser(string email, string ligacao, string consulta)
        {
            acessoBd.setligacao(ligacao);             
            List<SqlParameter> parametrosUser = new List<SqlParameter>();
            parametrosUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = email });
            return acessoBd.seleccionaDadosParametros(consulta, parametrosUser);
        }

        //Verifica se o utilizador está registado na base de dados, devolve true se existir.
        public Boolean verificaUser(string email, string password, string ligacao, string consulta)
        {
            acessoBd.setligacao(ligacao);
            List<SqlParameter> parametrosUser = new List<SqlParameter>();
            parametrosUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = email });
            if (password != null)
            {
                parametrosUser.Add(new SqlParameter("@parPassword", SqlDbType.NVarChar) { Value = password });
            }

            SqlDataReader canal = acessoBd.seleccionaDadosParametros(consulta, parametrosUser);
            if (canal.HasRows)
            {
                return true;
            }
            else
            {
                return false;

            }
        }



        // Retorna true caso o user seja administrador
        public Boolean administrador(int userId, string ligacao)
        {
            acessoBd.setligacao(ligacao);
            string consulta = "Select tipoAdmin from Administração Where idUser LIKE @parIdUser";
            List<SqlParameter> parametrosUser = new List<SqlParameter>();

            parametrosUser.Add(new SqlParameter("@parIdUser", SqlDbType.Int) { Value = userId });
            SqlDataReader canal = acessoBd.seleccionaDadosParametros(consulta, parametrosUser);
            if (canal.HasRows)
            {
                return true;
            }
            else
            {
                return false;

            }
        }


        public int efectuaRegisto(IEnumerable<string> campos, string ligacao, byte[] image)
        {
            this.ligacao = ligacao;

            string consultaUser = "insert into Users(email, password) Values(@parEmail, @parPassword)";

            List<SqlParameter> parametrosUser = new List<SqlParameter>();

            parametrosUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });
            parametrosUser.Add(new SqlParameter("@parPassword", SqlDbType.NVarChar) { Value = campos.ElementAt(1) });

            int dadosInseridos = acessoBd.insereDados(consultaUser, parametrosUser);

            if (dadosInseridos != 0)
            {
                List<SqlParameter> parametrosConsultaIdUser = new List<SqlParameter>();
                string consultaIdUser = "select * from Users where email LIKE @parEmail";
                parametrosConsultaIdUser.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });
                SqlDataReader canal = acessoBd.seleccionaDadosParametros(consultaIdUser, parametrosConsultaIdUser);

                List<SqlParameter> parametrosCadastro = new List<SqlParameter>();
                string consultaCadastro = "insert into Cadastro(idUser, idCidade, nome, apelido, sexo, dataNascimento, email, imagem)" +
         "Values(@parIdUser, @parIdCidade, @parNome, @parApelido, @parSexo, @parDataNascimento, @parEmail, @parImagem)";

                if (canal.HasRows)
                {
                    canal.Read();
                    parametrosCadastro.Add(new SqlParameter("@parIdUser", SqlDbType.Int) { Value = canal["idUser"] });
                    parametrosCadastro.Add(new SqlParameter("@parIdCidade", SqlDbType.Int) { Value = campos.ElementAt(2) });
                    parametrosCadastro.Add(new SqlParameter("@parNome", SqlDbType.NVarChar) { Value = campos.ElementAt(3) });
                    parametrosCadastro.Add(new SqlParameter("@parApelido", SqlDbType.NVarChar) { Value = campos.ElementAt(4) });
                    parametrosCadastro.Add(new SqlParameter("@parSexo", SqlDbType.NVarChar) { Value = campos.ElementAt(5) });
                    parametrosCadastro.Add(new SqlParameter("@parDataNascimento", SqlDbType.Date) { Value = campos.ElementAt(6) });
                    parametrosCadastro.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = campos.ElementAt(0) });
                    parametrosCadastro.Add(new SqlParameter("@parImagem", SqlDbType.VarBinary) { Value = (object)image });

                    return acessoBd.insereDados(consultaCadastro, parametrosCadastro);
                }
            }

            return 0;
        }
    }
}
