using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Face
{
    public partial class Mensagens : System.Web.UI.UserControl
    {

        public string data;
        public string categoriaMensagem;
        public string mensagem;
        public string tipoMensagem;
        public string idUser;

        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = categoriaMensagem;
            Label2.Text = categoriaMensagem;
            Label3.Text = mensagem;

            Image1.ImageUrl = "~/LogoUser.ashx?idUser=" + "2"; //martelado, deveríamos receber


            switch (tipoMensagem) {
                case "T": MultiView1.ActiveViewIndex = 1;
                    break;
                case "U":
                    break;
            }


            MultiView1.ActiveViewIndex = 0;

        }
    }
}