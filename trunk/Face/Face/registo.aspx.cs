﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassesUtil;

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
            int imagelen;
            System.Text.ASCIIEncoding converte = new System.Text.ASCIIEncoding();


            Gestor user = new Gestor();
            try
            {
                string consulta = "Select * from Users Where email LIKE @parEmail";
                bool userValidado = user.verificaUser(TxtEmail.Text.Trim(), txtPass.Text.Trim(), strConexao, consulta);
                if (userValidado)
                {
                    lblUserValidado.Visible = true;
                    lblUserValidado.Text = "Este email já se encontra a ser utilizado!";
                }
                else
                {
                    if (fupImagem.PostedFile.InputStream.Length > 0)
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
                    int registoValido = user.efectuaRegisto(campos, strConexao, imageData);
                    if (registoValido != 0)
                    {
                        Response.Redirect("principal.aspx", false);
                    }
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