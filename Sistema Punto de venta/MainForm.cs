using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Punto_de_venta
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");		
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
					// 1. Instanciamos tu clase de conexión
		    BaseDatos db = new BaseDatos();
		    
		    try
		    {
		        // 2. Preparamos la cadena y abrimos la conexión
		        db.ObtenerConexion(); 
		        db.AbrirConexion();
		        
		        // 3. Si llega a esta línea sin saltar al catch, la conexión fue un éxito
		        MessageBox.Show("¡Conexión exitosa a la base de datos TIENDITA!", "Prueba superada", MessageBoxButtons.OK, MessageBoxIcon.Information);
		    }
		    catch (Exception ex)
		    {
		        // Si hay un error (contraseña equivocada, servidor apagado, etc.), te lo mostrará aquí
		        MessageBox.Show("Falló la conexión:\n\n" + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		    finally
		    {
		        // 4. Cerramos la conexión para no dejarla colgada
		        db.CerrarConexion();
		    }			
		}
	}
}