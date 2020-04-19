using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RusticCoolmod
{
    public partial class AdminEditFabr_ : System.Web.UI.Page
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
                Servicio.getInstance().actualizarFabricante(Int32.Parse(DropDownList1.SelectedItem.ToString()),TextBox1.Text);
                rellenarCodigos();
                cargarInfo();
                Panel1.Visible = true;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!Servicio.getInstance().fabricanteRepetido(TextBox1.Text))
            {
                args.IsValid = true;
            }
            else args.IsValid = false;
        }
    }
}