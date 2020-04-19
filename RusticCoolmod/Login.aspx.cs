using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RusticCoolmod
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            loading.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "aaa", "move(0);", true);
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Boolean res = Servicio.getInstance().puedeLogin(textBox1.Text, textBox2.Text);
            if (!res)
            {
                args.IsValid = false;
                return;
            }
            else args.IsValid = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Session["usuario"] = textBox1.Text.ToString();
                Response.Redirect("AdminIndex.aspx");
            }
        }
    }
}