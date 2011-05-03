using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesUtil;
using System.Configuration;
using System.IO;

namespace Face
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddPais.DataBind();
            }
            ddCidade.DataBind();

            ddCidade.Visible = true;

            if (ddCidade.Items.Count == 0)
            {
                ddCidade.Visible = false;
            }

        }

        protected void btnRegisto_Click(object sender, EventArgs e)
        {
            byte[] imageData = null;
            String[] campos = new String[7];
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            int imagelen;
            BD registo = new BD();
            try
            {
                bool userValidado = registo.verificaUser(TxtEmail.Text.Trim(), txtPass.Text.Trim(), strConexao);
                if (userValidado)
                {
                    lblErroUserRegistado.Visible = true;
                    lblErroUserRegistado.Text = "Este email já se encontra a ser utilizado!";
                }
                else
                {
                    if (fupImagem.PostedFile.InputStream.Length > 0)
                    {
                        imageData = new byte[fupImagem.PostedFile.InputStream.Length];
                        imagelen = fupImagem.PostedFile.InputStream.Read(imageData, 0, Convert.ToInt32(fupImagem.PostedFile.InputStream.Length));
                    }
                    campos[0] = TxtEmail.Text;
                    campos[1] = txtPass.Text;
                    campos[2] = ddPais.SelectedValue;
                    campos[3] = txtNome.Text;
                    campos[4] = TxtApelido.Text;
                    campos[5] = ddSexo.SelectedValue;
                    campos[6] = txtDataNascimento.Text;
                    registo.efectuaRegisto(campos, strConexao, imageData);
                }

            }
            catch (Exception ex)
            {
                ((Label)Master.FindControl("lblErro")).Visible = true;
                ((Label)Master.FindControl("lblErro")).Text = ex.ToString();
            }
        }
       
    }
}