using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}