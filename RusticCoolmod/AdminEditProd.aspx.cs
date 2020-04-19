using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RusticCoolmod
{
    public partial class AdminEditProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> listaFabricantes;
            if (!IsPostBack)
            {
                rellenarCodigos();
                listaFabricantes = Servicio.getInstance().getNombresFabricantes();
                for (int i = 0; i < listaFabricantes.Count; i++)
                {
                    DropDownList2.Items.Add(listaFabricantes[i]);
                }

                if (DropDownList1.Items.Count > 0)
                    cargarInfo();
            }
            Panel1.Visible = false;
        }

        public void rellenarCodigos()
        {
            List<int> codigos = Servicio.getInstance().getCodigosProducto();
            codigos.Sort();
            DropDownList1.Items.Clear();
            for (int i = 0; i < codigos.Count; i++)
            {
                DropDownList1.Items.Add(codigos[i].ToString());
            }
        }

        public void cargarInfo()
        {
            List<Object> info = Servicio.getInstance().getInfoProducto(Int32.Parse(DropDownList1.SelectedItem.ToString()));
            if (info.Count > 0)
            {
                TextBox1.Text = info[0].ToString();
                TextBox2.Text = info[1].ToString();
                DropDownList2.SelectedValue = Servicio.getInstance().getNombreFabricante(Int32.Parse(info[2].ToString()));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarInfo();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count > 0)
            {
                Servicio.getInstance().actualizarProducto(Int32.Parse(DropDownList1.SelectedItem.ToString()),TextBox1.Text,double.Parse(TextBox2.Text),DropDownList2.SelectedItem.ToString());
                rellenarCodigos();
                cargarInfo();
                Panel1.Visible = true;
            }
        }
    }
}