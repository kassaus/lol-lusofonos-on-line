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
            BD login = new BD();
            try
            {
                loginValido = login.verificaUser(TxtEmailLogin.Text, TxtPassLogin.Text, strConexao);
                if (loginValido)
                {
                    Session["user"] = "Paulo Luís";
                    Session.Timeout = 1;
                    Response.Redirect("principal.aspx", false);
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
    }
}