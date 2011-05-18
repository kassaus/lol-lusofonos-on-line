using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesUtil;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Face
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpCookie cookie = Request.Cookies["userId"];
            if (cookie != null)
            {  
                TxtEmailLogin.Text = cookie.Value.ToString();             
            }
        }

        protected void btnIniciarSessao_Click(object sender, EventArgs e)
        {
            bool loginValido;
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Gestor user = new Gestor();
            try
            {
                string consulta = "Select * from Users Where email LIKE @parEmail and password LIKE @parPassword";
                loginValido = user.verificaUser(TxtEmailLogin.Text, TxtPassLogin.Text, strConexao, consulta);
                if (loginValido)
                {
                    SqlDataReader canal;
                    string consultaCadastro = "select * from Cadastro Where email LIKE @parEmail";
                    canal = user.DadosUser(TxtEmailLogin.Text, strConexao, consultaCadastro);
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

        protected void chksessao_CheckedChanged(object sender, EventArgs e)
        {
            if (chksessao.Checked)
            {
                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookie = new HttpCookie("userId");
                //Define o valor do cookie
                cookie.Value = TxtEmailLogin.Text;
                //Time para expiração (1 min)
                DateTime dtNow = DateTime.Now;
                TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
                cookie.Expires = dtNow + tsMinute;
                //Adiciona o cookie
                Response.Cookies.Add(cookie);
            }
        }

        protected void lbtnpass_Click(object sender, EventArgs e)
        {
            Response.Redirect("recuperarPassword.aspx", false);
        }
    }
}