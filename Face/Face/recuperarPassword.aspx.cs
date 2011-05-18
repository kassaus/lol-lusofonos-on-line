using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesUtil;
using System.Configuration;

namespace Face
{
    public partial class recuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperarPass_Click(object sender, EventArgs e)
        {
            Gestor user = new Gestor();
            bool userValidado = false;
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string consulta = "Select * from Users Where email LIKE @parEmail";
            userValidado = user.verificaUser(txtEnviaEmail.Text.Trim(), "", strConexao, consulta);
            if (!userValidado)
            {
                lblEmailInvalido.Visible = true;
            }
            else
            {
                // temos de ver o que vai acontecer???????????


            }
        }
    }
}