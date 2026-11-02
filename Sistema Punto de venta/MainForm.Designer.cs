/*
 * Created by SharpDevelop.
 * User: Miguel Rico
 * Date: 01/11/2026
 * Time: 11:14 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Sistema_Punto_de_venta
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.lblFecha = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descrpción = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(30, 47);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 35);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "1";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(30, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 1;
			this.label6.Text = "Cant.";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(165, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 23);
			this.label7.TabIndex = 2;
			this.label7.Text = "Cod. Producto: ";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(571, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 23);
			this.label8.TabIndex = 3;
			this.label8.Text = "Fecha:";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(571, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 4;
			this.label9.Text = "Empeado:";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(165, 50);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(250, 32);
			this.textBox2.TabIndex = 5;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox2KeyDown);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(650, 47);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(236, 32);
			this.textBox3.TabIndex = 6;
			// 
			// dataGridView2
			// 
			this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Clave,
									this.Descrpción,
									this.Cantidad,
									this.Precio,
									this.Importe});
			this.dataGridView2.Location = new System.Drawing.Point(30, 88);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 24;
			this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView2.Size = new System.Drawing.Size(945, 375);
			this.dataGridView2.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(427, 491);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 40);
			this.button2.TabIndex = 9;
			this.button2.Text = "Guardar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// lblFecha
			// 
			this.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblFecha.Location = new System.Drawing.Point(648, 10);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(100, 23);
			this.lblFecha.TabIndex = 10;
			this.lblFecha.Text = "label1";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(390, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Probar Conexión";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// Clave
			// 
			this.Clave.HeaderText = "Clave";
			this.Clave.Name = "Clave";
			// 
			// Descrpción
			// 
			this.Descrpción.HeaderText = "Descrpición";
			this.Descrpción.Name = "Descrpción";
			// 
			// Cantidad
			// 
			this.Cantidad.HeaderText = "Cantidad";
			this.Cantidad.Name = "Cantidad";
			// 
			// Precio
			// 
			this.Precio.HeaderText = "Precio";
			this.Precio.Name = "Precio";
			// 
			// Importe
			// 
			this.Importe.HeaderText = "Importe";
			this.Importe.Name = "Importe";
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(978, 543);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lblFecha);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1);
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
		private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn Descrpción;
		private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
	}
}
