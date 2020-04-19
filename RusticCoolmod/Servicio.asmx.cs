using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace RusticCoolmod
{
    /// <summary>
    /// Descripción breve de Servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicio : System.Web.Services.WebService
    {
        private static Servicio serv = null;

        private Servicio()
        {
            DBConnection.getInstance().Conectar();
        }
        [WebMethod]
        public static Servicio getInstance()
        {
            if (serv == null) serv = new Servicio();
            return serv;
        }


        [WebMethod]
        public Boolean usuarioExiste(String usuario)
        {
            return DBConnection.getInstance().existeUsuario(usuario);
        }

        [WebMethod]
        public Boolean puedeLogin(String usuario, String pass)
        {
            return DBConnection.getInstance().logeo(usuario, pass);
        }

        [WebMethod]
        public DataTable getTabla(String tabla, String campo, String cadena)
        {
            return DBConnection.getInstance().consultaDinamica(tabla, campo, cadena);
        }

        [WebMethod]
        public DataTable getProductos()
        {
            return DBConnection.getInstance().getProductos();
        }

        [WebMethod]
        public DataTable getFabricantes()
        {
            return DBConnection.getInstance().getFabricates();
        }

        [WebMethod]
        public List<String> getNombresFabricantes()
        {
            return DBConnection.getInstance().getNombresFabricantes();
        }

        [WebMethod]
        public String getNombreFabricante(int codigo)
        {
            return DBConnection.getInstance().getNombreFabricante(codigo);
        }

        [WebMethod]
        public List<Object> getInfoProducto(int codigo)
        {
            return DBConnection.getInstance().getInfoProducto(codigo);
        }

        [WebMethod]
        public List<int> getCodigosProducto()
        {
            return DBConnection.getInstance().getCodigosProducto();
        }

        [WebMethod]
        public List<int> getCodigosFabricante()
        {
            return DBConnection.getInstance().getCodigosFabricante();
        }

        [WebMethod]
        public void insertarProducto(String nombre, double precio, String fabricante)
        {
            DBConnection.getInstance().addProducto(nombre, precio, fabricante);
        }

        [WebMethod]
        public void deleteProducto(int codigo)
        {
            DBConnection.getInstance().deleteProducto(codigo);
        }

        [WebMethod]
        public void deleteFabricante(int codigo)
        {
            DBConnection.getInstance().deleteFabricante(codigo);
        }

        [WebMethod]
        public Boolean fabricanteRepetido(String fabricante)
        {
            return DBConnection.getInstance().fabricanteRepetido(fabricante);
        }

        [WebMethod]
        public void insertarFabricante(String fabricante)
        {
            DBConnection.getInstance().addFabricante(fabricante);
        }

        [WebMethod]
        public void actualizarProducto(int cod, String nombre, double precio, String fabricante)
        {
            DBConnection.getInstance().actualizarProducto(cod, nombre, precio, fabricante);
        }

        [WebMethod]
        public void actualizarFabricante(int cod, String nombre)
        {
            DBConnection.getInstance().actualizarFabricante(cod, nombre);
        }
    }
}
