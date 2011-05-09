using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassesUtil;
using System.Data.SqlClient;

namespace Face
{
    public partial class mensagens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Gestor user = new Gestor();
            SqlDataReader canal = null;
            string consulta = "Select nome, apelido, sexo, dataNascimento, cidade, pais from DadosUser Where email LIKE @parEmail";
            canal = user.DadosUser(Session["userEmail"].ToString(), strConexao, consulta);
            if (canal.HasRows)
            {
                canal.Read();
                lblNome.Text = canal["nome"].ToString() + " " + canal["apelido"].ToString();
                lblPerfil.Text = "Sexo: " + canal["sexo"].ToString() + " Data de Nascimento: " + canal["dataNascimento"].ToString() +
                    " Cidade: " + canal["cidade"].ToString() + " País:" + canal["pais"].ToString();
                
            }
            
          


        }
    }
}