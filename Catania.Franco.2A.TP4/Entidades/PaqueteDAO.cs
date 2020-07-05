using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor que inicializa la conexión con una cadena por defecto.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
        }

        /// <summary>
        /// Agrega el paquete recibido a la tabla Paquetes
        /// </summary>
        /// <param name="p"></param>
        /// <returns>
        /// true si pudo hacer la modificación.
        /// false si no.
        /// Si falla, lanza una excepción.
        /// </returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO.comando = new SqlCommand();

                PaqueteDAO.comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                PaqueteDAO.comando.Parameters.AddWithValue("@trackingID", p.TrackingID);

                string sql = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) ";
                sql += "VALUES (@direccionEntrega, @trackingID, 'Franco Catania')";

                PaqueteDAO.comando.CommandText = sql;
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.conexion.Open();

                if (PaqueteDAO.comando.ExecuteNonQuery() == 0)
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (PaqueteDAO.conexion.State == System.Data.ConnectionState.Open)
                    PaqueteDAO.conexion.Close();
            }

            return true;
        }

    }
}
