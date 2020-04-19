using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RusticCoolmod
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        protected string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"].ToString() == "")
            {
                Response.Redirect("Main.aspx");
            }
            else
            {
                this.usuario = Session["usuario"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}