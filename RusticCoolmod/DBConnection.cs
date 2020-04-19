using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace RusticCoolmod
{
    public class DBConnection
    {

        private MySqlConnection cnx;
        private static DBConnection db = null;
        private DBConnection()
        {
            cnx = new MySqlConnection("SERVER=localhost;DATABASE=tienda;UID=root;PWD=''");
        }

        public static DBConnection getInstance()
        {
            if (db == null) db = new DBConnection();
            return db;
        }

        public int Conectar()
        {
            int resultado = -1;
            try
            {
                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                    resultado = 1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Problema al conectar:" + ex.Message);
            }
            return resultado;
        }

        public int Desconectar()
        {
            int resultado = -1;
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
                resultado = 1;
            }
            return resultado;
        }

        public Boolean existeUsuario(String usuario)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            Boolean resultado = false;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT NOMBRE_USUARIO FROM usuario";
                d = c.ExecuteReader();
                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        if (!d.IsDBNull(0))
                        {
                            if (d.GetString(0).Equals(usuario))
                            {
                                resultado = true;
                                break;
                            }
                        }
                    }
                }
                d.Close();
                return resultado;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Boolean logeo(String usuario, String pass)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            Boolean res = false;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT NOMBRE_USUARIO, PASSWORD FROM usuario";
                d = c.ExecuteReader();
                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        if (!d.IsDBNull(0))
                            if (d.GetString(0).Equals(usuario))
                                if (d.GetString(1).Equals(pass))
                                {
                                    res = true;
                                    break;
                                }
                    }
                }
                d.Close();
                return res;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable getProductos()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            DataTable t = null;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT * FROM PRODUCTO";
                d = c.ExecuteReader();
                t = new DataTable();

                if (d.HasRows)
                {
                    t.Load(d);
                }

                d.Close();
                return t;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return t;
            }
        }

        public DataTable getFabricates()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            DataTable t = null;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT * FROM FABRICANTE";
                d = c.ExecuteReader();
                t = new DataTable();

                if (d.HasRows)
                {
                    t.Load(d);
                }

                d.Close();
                return t;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return t;
            }
        }

        public DataTable consultaDinamica(String tabla, String campo, String cadena)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            DataTable t = null;
            try
            {
                c.Connection = cnx;
                if (campo == "Precio")
                {
                    if (cadena == "") c.CommandText = "SELECT * FROM " + tabla;
                    else
                    {
                        double precio = double.Parse(cadena);
                        c.CommandText = "SELECT * FROM " + tabla + " WHERE precio = @precio";
                        c.Parameters.AddWithValue("@precio", precio);
                    }
                }
                else {
                    c.CommandText = "SELECT * FROM " + tabla + " WHERE " + campo + " LIKE '%" + cadena + "%'";
                }
                d = c.ExecuteReader();
                t = new DataTable();

                if (d.HasRows)
                {
                    t.Load(d);
                }

                d.Close();
                return t;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return t;
            }
        }

        public List<String> getNombresFabricantes()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            List<String> lista = new List<String>();
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT nombre FROM fabricante";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        lista.Add(d.GetString(0));
                    }
                }
                d.Close();
                return lista;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }

        public List<int> getCodigosProducto()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            List<int> lista = new List<int>();
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT codigo FROM producto";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        lista.Add(d.GetInt32(0));
                    }
                }
                d.Close();
                return lista;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }

        public List<int> getCodigosFabricante()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            List<int> lista = new List<int>();
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT codigo FROM fabricante";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        lista.Add(d.GetInt32(0));
                    }
                }
                d.Close();
                return lista;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }

        public int getMaxCodProducto()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            int codigo=0;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT MAX(codigo) FROM producto";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    if (d.Read())
                    
                        codigo = d.GetInt32(0);
                    
                }
                d.Close();
                return codigo+1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return codigo;
            }
        }

        public int getMaxCodFabricante()
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            int codigo = 0;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT MAX(codigo) FROM fabricante";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    if (d.Read())

                        codigo = d.GetInt32(0);

                }
                d.Close();
                return codigo + 1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return codigo;
            }
        }

        public int addProducto(String nombre, double precio, String fabricante)
        {
            int resultado = -1;

            MySqlCommand c = new MySqlCommand();
            try
            {
                c.Connection = cnx;
                c.CommandText = "INSERT INTO PRODUCTO (codigo, nombre , precio, codigo_fabricante) VALUES (@cod , @nombre, @precio, @fabr)";

                c.Parameters.AddWithValue("@cod", getMaxCodProducto());
                c.Parameters.AddWithValue("@nombre", nombre);
                c.Parameters.AddWithValue("@precio", precio);
                c.Parameters.AddWithValue("@fabr", getCodFabricante(fabricante));
                int r = c.ExecuteNonQuery();
                if (r == 1)
                    resultado = r;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            return resultado;
        }

        public int addFabricante(String fabricante)
        {
            int resultado = -1;

            MySqlCommand c = new MySqlCommand();
            try
            {
                c.Connection = cnx;
                c.CommandText = "INSERT INTO FABRICANTE (codigo, nombre) VALUES (@cod , @nombre)";

                c.Parameters.AddWithValue("@cod", getMaxCodFabricante());
                c.Parameters.AddWithValue("@nombre", fabricante);
                int r = c.ExecuteNonQuery();
                if (r == 1)
                    resultado = r;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            return resultado;
        }

        public int getCodFabricante(String fabricante)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            int codigo = 0;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT codigo FROM fabricante WHERE nombre='"+fabricante+"'";
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    if (d.Read())
                        codigo = d.GetInt32(0);
                }
                d.Close();
                return codigo;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return codigo;
            }
        }

        public String getNombreFabricante(int codigo)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            String nombre = "";
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT nombre FROM fabricante WHERE codigo=" + codigo;
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    if (d.Read())
                        nombre = d.GetString(0);
                }
                d.Close();
                return nombre;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return nombre;
            }
        }

        public List<Object> getInfoProducto(int codigo)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            List<Object> lista = new List<Object>();
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT nombre,precio,codigo_fabricante FROM producto WHERE codigo=" + codigo;
                d = c.ExecuteReader();

                if (d.HasRows)
                {
                    if (d.Read())
                    {
                        if (!d.IsDBNull(0) && !d.IsDBNull(1) && !d.IsDBNull(2))
                        {
                            lista.Add(d.GetString(0));
                            lista.Add(d.GetDouble(1));
                            lista.Add(d.GetInt32(2));
                        }
                    }
                        
                }
                d.Close();
                return lista;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lista;
            }
        }

        public int deleteProducto(int codigo)
        {
            int resultado = -1;
            MySqlCommand c = new MySqlCommand();
            try
            {
                
                c.Connection = cnx;
                c.CommandText = "DELETE FROM producto WHERE codigo =" +codigo;
                resultado = c.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resultado = -1;
                MessageBox.Show(ex.ToString());
            }
            return resultado;
        }

        public int deleteFabricante(int codigo)
        {
            int resultado = -1;
            MySqlCommand c = new MySqlCommand();
            try
            {

                c.Connection = cnx;
                c.CommandText = "DELETE FROM fabricante WHERE codigo =" + codigo;
                resultado = c.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resultado = -1;
                MessageBox.Show(ex.ToString());
            }
            return resultado;
        }

        public Boolean fabricanteRepetido(String fabricante)
        {
            MySqlCommand c = new MySqlCommand();
            MySqlDataReader d;
            Boolean res = false;
            try
            {
                c.Connection = cnx;
                c.CommandText = "SELECT * FROM fabricante WHERE nombre = '"+fabricante+"'";
                d = c.ExecuteReader();
                if (d.HasRows)
                {
                   if (d.Read())
                    {
                        if (!d.IsDBNull(0))
                                    res = true;
                    }
                }
                d.Close();
                return res;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Existe un problema con la BBDD: " + ex.ToString(), "Error MySQL.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int actualizarProducto(int cod, String nombre, double precio, String fabricante)
        {
            int resultado = -1;
            int codFabricante = getCodFabricante(fabricante);
            MySqlCommand c = new MySqlCommand();
            try
            {
                c.Connection = cnx;
                c.CommandText = "UPDATE producto SET nombre=@nombre, precio=@precio, codigo_fabricante=@fabr WHERE codigo=@cod";

                c.Parameters.AddWithValue("@cod", cod);
                c.Parameters.AddWithValue("@nombre", nombre);
                c.Parameters.AddWithValue("@precio", precio);
                c.Parameters.AddWithValue("@fabr", codFabricante);
                int r = c.ExecuteNonQuery();
                if (r == 1)
                    resultado = r;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            return resultado;
        }

        public int actualizarFabricante(int cod, String nombre)
        {
            int resultado = -1;
            MySqlCommand c = new MySqlCommand();
            try
            {
                c.Connection = cnx;
                c.CommandText = "UPDATE fabricante SET nombre=@nombre WHERE codigo=@cod";

                c.Parameters.AddWithValue("@cod", cod);
                c.Parameters.AddWithValue("@nombre", nombre);
                int r = c.ExecuteNonQuery();
                if (r == 1)
                    resultado = r;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            return resultado;
        }
    }
}