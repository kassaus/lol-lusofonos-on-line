using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassesUtil;
using System.Drawing;
using System.IO;

namespace Face
{
    public partial class registo : System.Web.UI.Page
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



        protected void btnRegisto_Click1(object sender, EventArgs e)
        {
            byte[] imageData = null;
            List<string> campos = new List<string>();
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            int imagelen, registoValido = 0;
            int camposValidos = 0;
            bool userValidado = false;
            System.Text.ASCIIEncoding converte = new System.Text.ASCIIEncoding();


            Gestor user = new Gestor();

            try
            {

                if (user.contemNumero(txtNome.Text))
                {
                    lblValidaNome.Visible = true;
                    lblValidaNome.Text = "O nome não pode conter números";
                    txtNome.BorderColor = Color.Red;
                }
                else
                {
                    txtNome.BorderColor = Color.Empty;
                    lblValidaNome.Visible = false;
                    camposValidos++;
                }


                if (user.contemNumero(TxtApelido.Text))
                {
                    lblValidaApelido.Visible = true;
                    lblValidaApelido.Text = "O apelido não pode conter números";
                    TxtApelido.BorderColor = Color.Red;
                }
                else
                {
                    TxtApelido.BorderColor = Color.Empty;
                    lblValidaApelido.Visible = false;
                    camposValidos++;

                }

                if (user.comparadatas(Convert.ToDateTime(txtDataNascimento.Text)))
                {
                    lblValidaData.Visible = true;
                    lblValidaData.Text = "A data tem que ser menor ou igual à data actual!";
                    txtDataNascimento.BorderColor = Color.Red;
                }
                else
                {
                    txtDataNascimento.BorderColor = Color.Empty;
                    lblValidaData.Visible = false;
                    camposValidos++;

                }




                string consulta = "Select * from Users Where email LIKE @parEmail";
                userValidado = user.verificaUser(TxtEmail.Text.Trim(), txtPass.Text.Trim(), strConexao, consulta);
                if (userValidado)
                {
                    lblUserValidado.Visible = true;
                    lblUserValidado.Text = "Este email já se encontra a ser utilizado!";
                    TxtEmail.BorderColor = Color.Red;

                }
                else
                {
                    TxtEmail.BorderColor = Color.Empty;
                    lblUserValidado.Visible = false;
                    camposValidos++;

                }


                if (camposValidos == 4)
                {
                    if (fupImagem.PostedFile.InputStream.Length == 0)
                    {
                        // cria o object imagem com o nome e camimho completo do arquivo
                        System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("~/images/user.png"));
                        // cria a memory stream para trabalhar com os bytes da imagem
                        MemoryStream imageStream = new MemoryStream();
                        // coloca a imagem na memory stream
                        image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // cria um array de bytes com o tamanho da imagem
                        imageData = new Byte[imageStream.Length];
                        // rebobina a memory stream
                        imageStream.Position = 0;
                        // carrega o array de bytes com a imagem
                        imageStream.Read(imageData, 0, (int)imageStream.Length);
                    }
                    else
                    {
                        imageData = new byte[fupImagem.PostedFile.InputStream.Length];
                        imagelen = fupImagem.PostedFile.InputStream.Read(imageData, 0, Convert.ToInt32(fupImagem.PostedFile.InputStream.Length));
                    }
                    campos.Add(TxtEmail.Text);
                    campos.Add(txtPass.Text);
                    campos.Add(ddCidade.SelectedValue);
                    campos.Add(txtNome.Text);
                    campos.Add(TxtApelido.Text);
                    campos.Add(ddSexo.SelectedValue);
                    campos.Add(txtDataNascimento.Text);
                    registoValido = user.efectuaRegisto(campos, strConexao, imageData);

                }

                if (registoValido != 0)
                {
                    Response.Redirect("principal.aspx", false);

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