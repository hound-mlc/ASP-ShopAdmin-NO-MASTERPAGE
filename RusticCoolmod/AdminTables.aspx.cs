using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RusticCoolmod
{
    public partial class AdminTables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = Servicio.getInstance().getProductos();
            GridView1.DataBind();
            GridView2.DataSource = Servicio.getInstance().getFabricantes();
            GridView2.DataBind();
        }
    }
}