namespace FrbaCrucero
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.abm_rol = new System.Windows.Forms.Button();
            this.abm_recorrido = new System.Windows.Forms.Button();
            this.abm_crucero = new System.Windows.Forms.Button();
            this.generar_viaje = new System.Windows.Forms.Button();
            this.reservar_viaje = new System.Windows.Forms.Button();
            this.pago_reserva = new System.Windows.Forms.Button();
            this.listado_estadistico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // abm_rol
            // 
            this.abm_rol.Location = new System.Drawing.Point(32, 35);
            this.abm_rol.Name = "abm_rol";
            this.abm_rol.Size = new System.Drawing.Size(93, 23);
            this.abm_rol.TabIndex = 0;
            this.abm_rol.Text = "Abm Rol";
            this.abm_rol.UseVisualStyleBackColor = true;
            this.abm_rol.Click += new System.EventHandler(this.abm_rol_Click);
            // 
            // abm_recorrido
            // 
            this.abm_recorrido.Location = new System.Drawing.Point(153, 35);
            this.abm_recorrido.Name = "abm_recorrido";
            this.abm_recorrido.Size = new System.Drawing.Size(98, 23);
            this.abm_recorrido.TabIndex = 1;
            this.abm_recorrido.Text = "Abm Recorrido";
            this.abm_recorrido.UseVisualStyleBackColor = true;
            this.abm_recorrido.Click += new System.EventHandler(this.abm_recorrido_Click);
            // 
            // abm_crucero
            // 
            this.abm_crucero.Location = new System.Drawing.Point(153, 64);
            this.abm_crucero.Name = "abm_crucero";
            this.abm_crucero.Size = new System.Drawing.Size(96, 23);
            this.abm_crucero.TabIndex = 2;
            this.abm_crucero.Text = "Abm Crucero";
            this.abm_crucero.UseVisualStyleBackColor = true;
            // 
            // generar_viaje
            // 
            this.generar_viaje.Location = new System.Drawing.Point(32, 63);
            this.generar_viaje.Name = "generar_viaje";
            this.generar_viaje.Size = new System.Drawing.Size(93, 23);
            this.generar_viaje.TabIndex = 3;
            this.generar_viaje.Text = "Generar Viaje";
            this.generar_viaje.UseVisualStyleBackColor = true;
            // 
            // reservar_viaje
            // 
            this.reservar_viaje.Location = new System.Drawing.Point(32, 93);
            this.reservar_viaje.Name = "reservar_viaje";
            this.reservar_viaje.Size = new System.Drawing.Size(93, 23);
            this.reservar_viaje.TabIndex = 4;
            this.reservar_viaje.Text = "Reservar Viaje";
            this.reservar_viaje.UseVisualStyleBackColor = true;
            this.reservar_viaje.Click += new System.EventHandler(this.reservar_viaje_Click);
            // 
            // pago_reserva
            // 
            this.pago_reserva.Location = new System.Drawing.Point(153, 94);
            this.pago_reserva.Name = "pago_reserva";
            this.pago_reserva.Size = new System.Drawing.Size(96, 23);
            this.pago_reserva.TabIndex = 5;
            this.pago_reserva.Text = "Pago Reserva";
            this.pago_reserva.UseVisualStyleBackColor = true;
            this.pago_reserva.Click += new System.EventHandler(this.pago_reserva_Click);
            // 
            // listado_estadistico
            // 
            this.listado_estadistico.Location = new System.Drawing.Point(32, 123);
            this.listado_estadistico.Name = "listado_estadistico";
            this.listado_estadistico.Size = new System.Drawing.Size(93, 23);
            this.listado_estadistico.TabIndex = 6;
            this.listado_estadistico.Text = "Estadisticas";
            this.listado_estadistico.UseVisualStyleBackColor = true;
            this.listado_estadistico.Click += new System.EventHandler(this.listado_estadistico_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 169);
            this.Controls.Add(this.listado_estadistico);
            this.Controls.Add(this.pago_reserva);
            this.Controls.Add(this.reservar_viaje);
            this.Controls.Add(this.generar_viaje);
            this.Controls.Add(this.abm_crucero);
            this.Controls.Add(this.abm_recorrido);
            this.Controls.Add(this.abm_rol);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button abm_rol;
        private System.Windows.Forms.Button abm_recorrido;
        private System.Windows.Forms.Button abm_crucero;
        private System.Windows.Forms.Button generar_viaje;
        private System.Windows.Forms.Button reservar_viaje;
        private System.Windows.Forms.Button pago_reserva;
        private System.Windows.Forms.Button listado_estadistico;
    }
}