using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RusticCoolmod
{
    public partial class Invitado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add("Producto");
                DropDownList1.Items.Add("Fabricante");
                DropDownList2.Items.Add("Nombre");
                DropDownList2.Items.Add("Precio");
            }
            GridView1.DataSource = null;
            GridView1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedIndex == 0)
            {
                DropDownList2.Items.Add("Nombre");
                DropDownList2.Items.Add("Precio");
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                DropDownList2.Items.Add("Nombre");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                DataTable res = Servicio.getInstance().getTabla(DropDownList1.Text, DropDownList2.Text, TextBox1.Text);
                if (res.ToString() == "")
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    GridView1.DataSource = res;
                    GridView1.DataBind();
                }
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DropDownList2.SelectedItem.ToString() == "Precio")
            {
                if (float.TryParse(TextBox1.Text, out float num) && num > 0)
                {
                    args.IsValid = true;
                }
                else args.IsValid = false;
            }
            else args.IsValid = true;
        }
    }
}