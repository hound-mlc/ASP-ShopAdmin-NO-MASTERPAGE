using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RusticCoolmod
{
    public partial class AdminAddProducto : System.Web.UI.Page
    {
        List<String> listaFabricantes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaFabricantes = Servicio.getInstance().getNombresFabricantes();
                for(int i=0; i < listaFabricantes.Count; i++)
                {
                    DropDownList1.Items.Add(listaFabricantes[i]);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (DropDownList1.Items.Count > 0)
                {
                    Servicio.getInstance().insertarProducto(TextBox2.Text, double.Parse(TextBox3.Text), DropDownList1.SelectedItem.ToString());
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    DropDownList1.SelectedIndex = 0;
                    Panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No puede añadir producto sin fabricante.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

    }
}