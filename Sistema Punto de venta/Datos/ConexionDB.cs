using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema_Punto_de_venta
{
    public class BaseDatos
    {
        private string servidor = "localhost";
        private string baseDatos = "TIENDITA";
        private string usuario = "root";
        private string password = "rico";
        private string puerto = "3306";
        
        private MySqlConnection conexion;

        public BaseDatos()
        {
        }

        public MySqlConnection ObtenerConexion()
        {
            string cadenaConexion = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};", servidor, puerto, baseDatos, usuario, password);

            conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }

        public void AbrirConexion()
        {
            if (conexion != null && conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}