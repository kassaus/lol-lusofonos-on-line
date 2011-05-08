using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesUtil;
using System.Data.SqlClient;
using System.Configuration;

namespace Face
{
    public partial class LayoutFace : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Gestor dados = new Gestor();
            SqlDataReader canal = null;

            if (Session["userEmail"] == null)
            {
                Response.Redirect("entrada.aspx", false);
            }
            else
            {
                canal = dados.DadosUser(Session["userEmail"].ToString(), strConexao);
                if (canal.HasRows)
                {
                    canal.Read();
                    lblNome.Text = canal["nome"].ToString();
                    imagemLogo.ImageUrl = "~/Image.ashx?email=" + canal["email"].ToString();

                }
            }
        }
    }
}