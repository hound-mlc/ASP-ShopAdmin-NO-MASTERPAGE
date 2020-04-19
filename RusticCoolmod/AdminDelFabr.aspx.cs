using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RusticCoolmod
{
    public partial class AdminDelFabr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rellenarCodigos();
                if (DropDownList1.Items.Count > 0)
                    cargarInfo();
            }
            Panel1.Visible = false;
        }

        public void rellenarCodigos()
        {
            List<int> codigos = Servicio.getInstance().getCodigosFabricante();
            codigos.Sort();
            DropDownList1.Items.Clear();
            for (int i = 0; i < codigos.Count; i++)
            {
                DropDownList1.Items.Add(codigos[i].ToString());
            }
        }

        public void cargarInfo()
        {
            
            String nombre = Servicio.getInstance().getNombreFabricante(Int32.Parse(DropDownList1.SelectedItem.ToString()));
            if (nombre.Length > 0)
            {
                TextBox1.Text = nombre;
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
                String msg = "¿Está seguro que quiere borrar este fabricante? Todos los productos de este fabricante también se borrarán así como la información de éstos en los detalles de los pedidos que los incluyan.";
                DialogResult ds = MessageBox.Show(msg, "BORRADO ARRIESGADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    Servicio.getInstance().deleteFabricante(Int32.Parse(DropDownList1.SelectedItem.ToString()));
                    rellenarCodigos();
                    cargarInfo();
                    Panel1.Visible = true;
                }
                    
            }
        }
    }
}