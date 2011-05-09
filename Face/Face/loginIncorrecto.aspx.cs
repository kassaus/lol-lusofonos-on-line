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
    public partial class loginIncorrecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginValido;
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Gestor user = new Gestor();
            try
            {
                string consulta = "Select * from Users Where email LIKE @parEmail and password LIKE @parPassword";
                loginValido = user.verificaUser(txtEmailErro.Text, TxtPasswordErro.Text, strConexao, consulta);
                if (loginValido)
                {
                    SqlDataReader canal;
                    string consultaCadastro = "select * from Cadastro Where email LIKE @parEmail";
                    canal = user.DadosUser(txtEmailErro.Text, strConexao, consultaCadastro);
                    if (canal.HasRows)
                    {
                        bool admin;
                        canal.Read();
                        Session["userEmail"] = canal["email"];
                        Session["userId"] = canal["idUser"];
                        Session.Timeout = 1;
                        admin = user.administrador(Convert.ToInt32(canal["idUser"]), strConexao);
                        if (admin)
                        {
                            Response.Redirect("principalAdmin.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("principal.aspx", false);
                        }
                    }
                }
                else
                {
                    Response.Redirect("loginIncorrecto.aspx", false);

                }
            }
            catch (Exception ex)
            {
                lblErro.Visible = true;
                lblErro.Text = ex.ToString();
            }
        }
    }
}