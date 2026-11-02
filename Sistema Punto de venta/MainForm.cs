using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_Punto_de_venta
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CargarEmpleados();
        }

        void Timer1Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");        
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            BaseDatos db = new BaseDatos();
            
            try
            {
                db.ObtenerConexion(); 
                db.AbrirConexion();
                
                MessageBox.Show("Conexión exitosa a TIENDITA", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la conexión:" + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CerrarConexion();
            }            
        }

        void TextBox2KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string codigo = textBox2.Text.Trim();

                if (!string.IsNullOrEmpty(codigo))
                {
                    BuscarYAgregarProducto(codigo);
                    textBox2.Clear();
                    textBox1.Text = "1";
                }
            }
        }

      private void BuscarYAgregarProducto(string codigo)
        {
            string query = "SELECT Clave, Descripcion, Precio, Stock FROM PRODUCTOS WHERE Clave = @codigo";

            BaseDatos db = new BaseDatos();

            try
            {
                using (MySqlConnection conexion = db.ObtenerConexion())
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string clave = reader["Clave"].ToString();
                                string descripcion = reader["Descripcion"].ToString();
                                decimal precio = Convert.ToDecimal(reader["Precio"]);
                                int stock = Convert.ToInt32(reader["Stock"]);
                                
                                int cantidadAgregar = 1;
                                if (!int.TryParse(textBox1.Text.Trim(), out cantidadAgregar) || cantidadAgregar <= 0)
                                {
                                    cantidadAgregar = 1;
                                }

                                bool productoExiste = false;

                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == clave)
                                    {
                                        int cantidadActual = Convert.ToInt32(row.Cells[2].Value);
                                        int nuevaCantidad = cantidadActual + cantidadAgregar;

                                        if (stock >= nuevaCantidad)
                                        {
                                            row.Cells[2].Value = nuevaCantidad;
                                            row.Cells[4].Value = precio * nuevaCantidad;
                                            CalcularTotales();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Stock insuficiente para este producto.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }

                                        productoExiste = true;
                                        break;
                                    }
                                }

                                if (!productoExiste)
                                {
                                    if (stock >= cantidadAgregar)
                                    {
                                        decimal importe = precio * cantidadAgregar;
                                        dataGridView2.Rows.Add(clave, descripcion, cantidadAgregar, precio, importe);
                                        CalcularTotales();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Stock insuficiente para este producto.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto no existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
      
		private void CalcularTotales()
		{
		    decimal subtotal = 0;
		    foreach (DataGridViewRow row in dataGridView2.Rows)
		    {
		        if (row.Cells[4].Value != null)
		        {
		            subtotal += Convert.ToDecimal(row.Cells[4].Value);
		        }
		    }
		
		    decimal iva = subtotal * 0.16m; 
		    decimal total = subtotal + iva;
		    
		    lblSubtotal.Text = subtotal.ToString("C2");
		    lblIva.Text = iva.ToString("C2");
		    lblTotal.Text = total.ToString("C2");
		}
		
		private void CargarEmpleados()
		{
		    BaseDatos db = new BaseDatos();
		    string query = "SELECT IdEmpleado, Nombre FROM EMPLEADOS";
		
		    try
		    {
		        using (MySqlConnection conexion = db.ObtenerConexion())
		        {
		            conexion.Open();
		            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
		            {
		                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
		                {
		                    DataTable dtEmpleados = new DataTable();
		                    adaptador.Fill(dtEmpleados);
		
		                    cmbEmpleados.DataSource = dtEmpleados;
		                    cmbEmpleados.DisplayMember = "Nombre";     
		                    cmbEmpleados.ValueMember = "IdEmpleado"; 
		                }
		            }
		        }
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show("Error al cargar empleados: " + ex.Message);
		    }
		}		
      
        void Button2Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0 || (dataGridView2.Rows.Count == 1 && dataGridView2.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay productos en la lista.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BaseDatos db = new BaseDatos();
            MySqlConnection conexion = db.ObtenerConexion();
            conexion.Open();
            MySqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                decimal subtotal = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[4].Value != null)
                        subtotal += Convert.ToDecimal(row.Cells[4].Value);
                }
                decimal iva = subtotal * 0.16m;
                decimal total = subtotal + iva;

                string queryVenta = "INSERT INTO VENTAS (IdEmpleado, Fecha, Subtotal, Iva, Total) VALUES (@idEmpleado, NOW(), @subtotal, @iva, @total); SELECT LAST_INSERT_ID();";
                long idVentaGenerado;

                using (MySqlCommand cmdVenta = new MySqlCommand(queryVenta, conexion, transaccion))
                {
                    cmdVenta.Parameters.AddWithValue("@idEmpleado", Convert.ToInt32(cmbEmpleados.SelectedValue));
                    cmdVenta.Parameters.AddWithValue("@subtotal", subtotal);
                    cmdVenta.Parameters.AddWithValue("@iva", iva);
                    cmdVenta.Parameters.AddWithValue("@total", total);
                    idVentaGenerado = Convert.ToInt64(cmdVenta.ExecuteScalar());
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    string clave = row.Cells[0].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells[2].Value);
                    decimal precio = Convert.ToDecimal(row.Cells[3].Value);
                    decimal importe = Convert.ToDecimal(row.Cells[4].Value);

                    string queryDetalle = "INSERT INTO DETALLES_VENTA (IdVenta, ClaveProducto, Cantidad, Precio, Importe) VALUES (@idVenta, @clave, @cantidad, @precio, @importe)";
                    using (MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conexion, transaccion))
                    {
                        cmdDetalle.Parameters.AddWithValue("@idVenta", idVentaGenerado);
                        cmdDetalle.Parameters.AddWithValue("@clave", clave);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precio", precio);
                        cmdDetalle.Parameters.AddWithValue("@importe", importe);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    string queryStock = "UPDATE PRODUCTOS SET Stock = Stock - @cantidad WHERE Clave = @clave";
                    using (MySqlCommand cmdStock = new MySqlCommand(queryStock, conexion, transaccion))
                    {
                        cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdStock.Parameters.AddWithValue("@clave", clave);
                        cmdStock.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();
                MessageBox.Show("¡Venta registrada con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.Rows.Clear();
                CalcularTotales();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                MessageBox.Show("Error al procesar la venta: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CerrarConexion();
            }
        }
    }
}
