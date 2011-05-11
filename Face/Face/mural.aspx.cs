using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ClassesUtil;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Face
{
    public partial class mensagens : System.Web.UI.Page
    {

        
        
        BD data = new BD(strConexao);
        Gestor user = new Gestor();
        SqlDataReader canal = null;
        private static string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddCategoriaMensagem.DataBind();
            }

            

            string consulta = "Select nome, apelido, sexo, dataNascimento, cidade, pais from DadosUser Where email LIKE @parEmail";
            canal = user.DadosUser(Session["userEmail"].ToString(), strConexao, consulta);
            if (canal.HasRows)
            {                
                canal.Read();
                DateTime dataFormatada = DateTime.Parse(canal["dataNascimento"].ToString());
                lblNome.Text = canal["nome"].ToString() + " " + canal["apelido"].ToString();
                lblPerfil.Text = "Sexo: " + canal["sexo"].ToString() + " Data de Nascimento: " + dataFormatada.ToString("dd MMM yyyy") +
                    " Cidade: " + canal["cidade"].ToString() + " País:" + canal["pais"].ToString();
                
            }



            try
            {
                consulta = "SELECT * FROM ViewMensagensCategorias WHERE idUser LIKE @parIdUser ORDER BY horaDataMensagem DESC";
                List<SqlParameter> parametrosMensagem = new List<SqlParameter>();
                
                parametrosMensagem.Add(new SqlParameter("@parIdUser", SqlDbType.Int) { Value = Convert.ToInt32(Session["userId"]) });


                canal = data.seleccionaDadosParametros(consulta, parametrosMensagem);

                
                while (canal.Read()) {

                    TableRow linha = new TableRow();
                    linha.Cells.Add(new TableCell());
                    linha.Cells[0].Font.Size = 8;
                    linha.Cells[0].Width = new Unit("100%");
                    linha.Cells[0].ForeColor = Color.Red;
                    linha.Cells[0].Font.Bold = true;
                    linha.Cells[0].Text = lblNome.Text;
                    Table1.Rows.Add(linha);

                    linha = new TableRow();
                    linha.Cells.Add(new TableCell());
                    linha.Cells[0].Font.Size = 10;
                    linha.Cells[0].Width = new Unit("100%");
                    linha.Cells[0].ForeColor = Color.Navy;
                    linha.Cells[0].Font.Bold = false;
                    linha.Cells[0].Text = canal["mensagem"].ToString();
                    Table1.Rows.Add(linha);

                    linha = new TableRow();
                    linha.Cells.Add(new TableCell());
                    linha.Cells[0].Font.Size = 7;
                    linha.Cells[0].Width = new Unit("100%");
                    linha.Cells[0].ForeColor = Color.Red;
                    linha.Cells[0].Font.Bold = false;
                    linha.Cells[0].Text = canal["horaDataMensagem"].ToString();
                    Table1.Rows.Add(linha);

                    linha = new TableRow();
                    linha.Cells.Add(new TableCell());
                    linha.Cells.Add(new TableCell());
                    linha.Cells[0].ColumnSpan = 2;
                    Table1.Rows.Add(linha);

                    //HyperLink link = new HyperLink();
                    //link.ForeColor = Color.BlueViolet;
                    //link.Font.Size = 6;
                    //link.Text = "Comentários";
                    //link.NavigateUrl = "Comentarios.aspx?id=" + dr["idMensagens"].ToString();

                    //linha.Cells[0].Controls.Add(link);
                    //linha.Cells[0].HorizontalAlign = HorizontalAlign.Right;





                
                }

                


            }
            catch (Exception ex) { 
            
            }






    }


        protected void btnEstado_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 0;
            MultiView1.Visible = true;
            MultiView3.Visible = true;
        }

        protected void btnFotos_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 1;
            MultiView1.Visible = true;
            MultiView3.Visible = true;
        }

        protected void btnVideos_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex = 2;
            MultiView1.Visible = true;
            MultiView3.Visible = true;
        }

        protected void btnPartilhar_Click(object sender, EventArgs e)
        {

            //string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //BD data = new BD(strConexao);
            //Gestor user = new Gestor();

            DateTime dataMensagem = DateTime.Now ;    

            string insere = "INSERT INTO Mensagens (idUser, idCategoria, idTipoMensagem, mensagem, horaDataMensagem)  VALUES (@parIdUser, @parIdCategoria, @parIdTipoMensagem, @parMensagem, @parHoraDataMensagem)";
            


            List<SqlParameter> parametrosMensagem = new List<SqlParameter>();



            parametrosMensagem.Add(new SqlParameter("@parIdUser", SqlDbType.Int) { Value = Convert.ToInt32(Session["userId"]) });
            parametrosMensagem.Add(new SqlParameter("@parIdCategoria", SqlDbType.Int) { Value = ddCategoriaMensagem.SelectedValue });
            parametrosMensagem.Add(new SqlParameter("@parIdTipoMensagem", SqlDbType.Int) { Value = 1 });
            parametrosMensagem.Add(new SqlParameter("@parMensagem", SqlDbType.NVarChar) { Value = txtMensagens.Text });
            parametrosMensagem.Add(new SqlParameter("@parHoraDataMensagem", SqlDbType.DateTime) { Value =  dataMensagem});

            if (txtMensagens.Text.Length > 0) //apenas se a mensagem não fôrvazia
            {

                if (data.insereDados(insere, parametrosMensagem) == 0)
                {

                    Response.Write("Erro na introdução de mensagem");

                }
                else
                {
                    Response.Redirect("mural.aspx", false);

                }
            }
            else 
            { 

                lblErroPartilhar.Text = "A mensagem não pode ser vazia";
                lblErroPartilhar.Visible = true;
            
            }  
 
               

        }
    }
}