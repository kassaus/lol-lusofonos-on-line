using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Face
{
    public partial class LayoutFace : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("entrada.aspx", false);
            }
            else
            {
                lblNome.Text = Session["user"].ToString();
            }

        }
    }
}