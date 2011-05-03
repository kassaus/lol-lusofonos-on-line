using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassesUtil;

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
            BD login = new BD();
            try
            {
                loginValido = login.verificaUser(txtEmailErro.Text, TxtPasswordErro.Text, strConexao);
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