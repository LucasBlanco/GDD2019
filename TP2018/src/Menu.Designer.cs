namespace PalcoNet
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
            this.label1 = new System.Windows.Forms.Label();
            this.abm_rol = new System.Windows.Forms.Button();
            this.abm_usuario = new System.Windows.Forms.Button();
            this.abm_cliente = new System.Windows.Forms.Button();
            this.abm_empresa = new System.Windows.Forms.Button();
            this.abm_publicacion = new System.Windows.Forms.Button();
            this.abm_grado = new System.Windows.Forms.Button();
            this.historial_del_cliente = new System.Windows.Forms.Button();
            this.canje_y_administracion_de_puntos = new System.Windows.Forms.Button();
            this.generar_pago_de_comisiones = new System.Windows.Forms.Button();
            this.listado_estadistico = new System.Windows.Forms.Button();
            this.comprar = new System.Windows.Forms.Button();
            this.log_out = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ABMs";
            // 
            // abm_rol
            // 
            this.abm_rol.Location = new System.Drawing.Point(41, 53);
            this.abm_rol.Name = "abm_rol";
            this.abm_rol.Size = new System.Drawing.Size(75, 23);
            this.abm_rol.TabIndex = 2;
            this.abm_rol.Text = "Rol";
            this.abm_rol.UseVisualStyleBackColor = true;
            this.abm_rol.Click += new System.EventHandler(this.rol_Click);
            // 
            // abm_usuario
            // 
            this.abm_usuario.Location = new System.Drawing.Point(122, 53);
            this.abm_usuario.Name = "abm_usuario";
            this.abm_usuario.Size = new System.Drawing.Size(75, 23);
            this.abm_usuario.TabIndex = 2;
            this.abm_usuario.Text = "Usuario";
            this.abm_usuario.UseVisualStyleBackColor = true;
            this.abm_usuario.Click += new System.EventHandler(this.usuario_Click);
            // 
            // abm_cliente
            // 
            this.abm_cliente.Location = new System.Drawing.Point(203, 53);
            this.abm_cliente.Name = "abm_cliente";
            this.abm_cliente.Size = new System.Drawing.Size(75, 23);
            this.abm_cliente.TabIndex = 2;
            this.abm_cliente.Text = "Cliente";
            this.abm_cliente.UseVisualStyleBackColor = true;
            this.abm_cliente.Click += new System.EventHandler(this.cliente_Click);
            // 
            // abm_empresa
            // 
            this.abm_empresa.Location = new System.Drawing.Point(41, 95);
            this.abm_empresa.Name = "abm_empresa";
            this.abm_empresa.Size = new System.Drawing.Size(75, 23);
            this.abm_empresa.TabIndex = 3;
            this.abm_empresa.Text = "Empresa";
            this.abm_empresa.UseVisualStyleBackColor = true;
            this.abm_empresa.Click += new System.EventHandler(this.empresa_Click);
            // 
            // abm_publicacion
            // 
            this.abm_publicacion.Location = new System.Drawing.Point(122, 95);
            this.abm_publicacion.Name = "abm_publicacion";
            this.abm_publicacion.Size = new System.Drawing.Size(75, 23);
            this.abm_publicacion.TabIndex = 3;
            this.abm_publicacion.Text = "Publicacion";
            this.abm_publicacion.UseVisualStyleBackColor = true;
            this.abm_publicacion.Click += new System.EventHandler(this.publicacion_Click);
            // 
            // abm_grado
            // 
            this.abm_grado.Location = new System.Drawing.Point(203, 95);
            this.abm_grado.Name = "abm_grado";
            this.abm_grado.Size = new System.Drawing.Size(75, 23);
            this.abm_grado.TabIndex = 3;
            this.abm_grado.Text = "Grado";
            this.abm_grado.UseVisualStyleBackColor = true;
            this.abm_grado.Click += new System.EventHandler(this.grado_Click);
            // 
            // historial_del_cliente
            // 
            this.historial_del_cliente.Location = new System.Drawing.Point(122, 191);
            this.historial_del_cliente.Name = "historial_del_cliente";
            this.historial_del_cliente.Size = new System.Drawing.Size(75, 23);
            this.historial_del_cliente.TabIndex = 4;
            this.historial_del_cliente.Text = "Historial";
            this.historial_del_cliente.UseVisualStyleBackColor = true;
            this.historial_del_cliente.Click += new System.EventHandler(this.historial_Click);
            // 
            // canje_y_administracion_de_puntos
            // 
            this.canje_y_administracion_de_puntos.Location = new System.Drawing.Point(203, 191);
            this.canje_y_administracion_de_puntos.Name = "canje_y_administracion_de_puntos";
            this.canje_y_administracion_de_puntos.Size = new System.Drawing.Size(75, 23);
            this.canje_y_administracion_de_puntos.TabIndex = 4;
            this.canje_y_administracion_de_puntos.Text = "Canjear";
            this.canje_y_administracion_de_puntos.UseVisualStyleBackColor = true;
            this.canje_y_administracion_de_puntos.Click += new System.EventHandler(this.canjear_Click);
            // 
            // generar_pago_de_comisiones
            // 
            this.generar_pago_de_comisiones.Location = new System.Drawing.Point(41, 230);
            this.generar_pago_de_comisiones.Name = "generar_pago_de_comisiones";
            this.generar_pago_de_comisiones.Size = new System.Drawing.Size(156, 23);
            this.generar_pago_de_comisiones.TabIndex = 5;
            this.generar_pago_de_comisiones.Text = "Pago comision";
            this.generar_pago_de_comisiones.UseVisualStyleBackColor = true;
            this.generar_pago_de_comisiones.Click += new System.EventHandler(this.pago_comision_Click);
            // 
            // listado_estadistico
            // 
            this.listado_estadistico.Location = new System.Drawing.Point(203, 230);
            this.listado_estadistico.Name = "listado_estadistico";
            this.listado_estadistico.Size = new System.Drawing.Size(75, 23);
            this.listado_estadistico.TabIndex = 4;
            this.listado_estadistico.Text = "Estadisticas";
            this.listado_estadistico.UseVisualStyleBackColor = true;
            this.listado_estadistico.Click += new System.EventHandler(this.estadisticas_Click);
            // 
            // comprar
            // 
            this.comprar.Location = new System.Drawing.Point(41, 191);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(75, 23);
            this.comprar.TabIndex = 2;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
            // 
            // log_out
            // 
            this.log_out.Location = new System.Drawing.Point(44, 307);
            this.log_out.Name = "log_out";
            this.log_out.Size = new System.Drawing.Size(75, 23);
            this.log_out.TabIndex = 6;
            this.log_out.Text = "Log out";
            this.log_out.UseVisualStyleBackColor = true;
            this.log_out.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 345);
            this.Controls.Add(this.log_out);
            this.Controls.Add(this.listado_estadistico);
            this.Controls.Add(this.generar_pago_de_comisiones);
            this.Controls.Add(this.canje_y_administracion_de_puntos);
            this.Controls.Add(this.historial_del_cliente);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.abm_grado);
            this.Controls.Add(this.abm_publicacion);
            this.Controls.Add(this.abm_empresa);
            this.Controls.Add(this.abm_cliente);
            this.Controls.Add(this.abm_usuario);
            this.Controls.Add(this.abm_rol);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button abm_rol;
        private System.Windows.Forms.Button abm_usuario;
        private System.Windows.Forms.Button abm_cliente;
        private System.Windows.Forms.Button abm_empresa;
        private System.Windows.Forms.Button abm_publicacion;
        private System.Windows.Forms.Button abm_grado;

        private System.Windows.Forms.Button comprar;

        private System.Windows.Forms.Button historial_del_cliente;
        private System.Windows.Forms.Button canje_y_administracion_de_puntos;
        private System.Windows.Forms.Button generar_pago_de_comisiones;
        private System.Windows.Forms.Button listado_estadistico;
        private System.Windows.Forms.Button log_out;

    }
}