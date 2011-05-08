using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using ClassesUtil;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Face
{
    /// <summary>
    /// Summary description for image
    /// </summary>
    public class image : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Data.SqlClient.SqlDataReader canal = null;
            BD acessoBd = new BD();
            try
            {
                string consulta = "select imagem from Cadastro where email LIKE @parEmail";
                List<SqlParameter> parametrosImg = new List<SqlParameter>();
                parametrosImg.Add(new SqlParameter("@parEmail", SqlDbType.NVarChar) { Value = context.Request.QueryString["email"] });
                acessoBd.setligacao(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                canal = acessoBd.seleccionaDadosParametros(consulta, parametrosImg);
                if (canal.HasRows)
                {
                    while (canal.Read())
                    {
                        context.Response.ContentType = "imagem/jpg";
                        context.Response.BinaryWrite((byte[])canal["imagem"]);
                    }
                }
            }
            catch
            {
                // Alguma coisa................
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}