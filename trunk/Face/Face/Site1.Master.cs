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

        }

        protected void btnIniciarSessao_Click(object sender, EventArgs e)
        {
            bool loginValido;
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            BD login = new BD();
            try
            {
                loginValido  = login.verificaUser(TxtEmailLogin.Text, TxtPassLogin.Text, strConexao);
                if (loginValido)
                {
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
    }
}