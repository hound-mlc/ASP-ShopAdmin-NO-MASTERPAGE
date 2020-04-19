using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RusticCoolmod
{
    public partial class AdminAddFabr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Servicio.getInstance().insertarFabricante(TextBox2.Text);
                TextBox2.Text = "";
                Panel1.Visible = true;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!Servicio.getInstance().fabricanteRepetido(TextBox2.Text))
            {
                args.IsValid = true;
            }
            else args.IsValid = false;
        }
    }
}