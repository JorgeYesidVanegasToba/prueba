using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoSof
{
    class ConsultasSQL
    {
        private SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-0T2RNIV; Initial Catalog = viaje; integrated security = true");
        private DataSet ds;
        public static string nombreCompleto = "";
        public static string Usuario = "";

        public Boolean iniciarSesion(string nomus, string con) {
          
            nombreCompleto = "";
            Usuario = "";
            conexion.Open();
            SqlParameter parUsu = new SqlParameter("@nmus", nomus);
            SqlParameter parCon = new SqlParameter("@pass",con);
            SqlCommand cmd = new SqlCommand("SELECT nombreUsuario, nombre, apellido, tipoUsuario FROM usuario WHERE nombreUsuario = @nmus AND pass=@pass", conexion);
            cmd.Parameters.Add(parUsu);
            cmd.Parameters.Add(parCon);
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                nombreCompleto = lector.GetString(0) + "" + lector.GetString(1) + "" + lector.GetString(2);
                Usuario = lector.GetString(3);
            }
            lector.Close();
            conexion.Close();

            if (String.IsNullOrEmpty(Usuario))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

       


        //metodos para llenar el cmbPaisOrigen

        public void Llernarcmb(ComboBox cb)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select nombre_Pais from Pais", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["nombre_Pais"].ToString());
                }
                dr.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el comboBox"+ ex.ToString());
            }

        }

        //metodos para llenar el cmbPaisDestino

        public void LlernarPaisDestino(ComboBox cb)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select nombre_Pais from Pais", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())   
                {
                    cb.Items.Add(dr["nombre_Pais"].ToString());


                }
                dr.Close();
                conexion.Close();
                           
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el comboBox" + ex.ToString());
            }

            

        }
        //metodos para llenar el cmbCiudadOrigen

        public void LlernarCiudadOrigen(ComboBox cb)
        {
            try
            {
                conexion.Open();


                SqlCommand cmd = new SqlCommand("select Nombre_Ciudad from Ciudad", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["Nombre_Ciudad"].ToString());
                }
                dr.Close();
                conexion.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el comboBox" + ex.ToString());
            }

        }

        //metodos para llenar el cmbCiudadDestino

        public void LlernarCiudadDestino(ComboBox cb)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select Nombre_Ciudad from Ciudad", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["Nombre_Ciudad"].ToString());
                }
                dr.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el comboBox" + ex.ToString());
            }

        }

        //fin


        public DataTable mostarDatos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Registro", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable Buscar(string ciudadOrigen)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Registro where ciudadOrigen like '%{0}%'", ciudadOrigen), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public bool Insertar(string id, string ciudadOrigen, string ciudadDestino)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into Registro values ({0}, '{1}', '{2}')", new string[] { id, ciudadOrigen, ciudadDestino }), conexion);
            int filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasAfectadas > 0) return true;
            else return false;
        }

        public bool Eliminar(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("delete from Registro where id={0}", id), conexion);
            int filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasAfectadas > 0) return true;
            else return false;
        }

        public bool Actulaizar(string id, string ciudadOrigen, string ciudadDestino)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("update Registro set ciudadOrigen = '{0}', ciudadDestino = '{1}' where id = {2}", new string[] { ciudadOrigen, ciudadDestino, id }), conexion);
            int filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasAfectadas > 0) return true;
            else return false;
        }
    }
}
