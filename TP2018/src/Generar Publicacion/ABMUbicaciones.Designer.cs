namespace PalcoNet.Generar_Publicacion
{
    partial class ABMUbicaciones
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
            this.guardarBTN = new System.Windows.Forms.Button();
            this.limpiarBTN = new System.Windows.Forms.Button();
            this.ubicacionesDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.agregarBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fila = new System.Windows.Forms.TextBox();
            this.asiento = new System.Windows.Forms.TextBox();
            this.precio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.descripcion = new System.Windows.Forms.ComboBox();
            this.ubicacionesGB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionesDGV)).BeginInit();
            this.ubicacionesGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione una fila y haga click el Suprimir para borrarla";
            // 
            // guardarBTN
            // 
            this.guardarBTN.Location = new System.Drawing.Point(376, 492);
            this.guardarBTN.Name = "guardarBTN";
            this.guardarBTN.Size = new System.Drawing.Size(119, 23);
            this.guardarBTN.TabIndex = 4;
            this.guardarBTN.Text = "Guardar";
            this.guardarBTN.UseVisualStyleBackColor = true;
            this.guardarBTN.Click += new System.EventHandler(this.guardarBTN_Click);
            // 
            // limpiarBTN
            // 
            this.limpiarBTN.Location = new System.Drawing.Point(34, 492);
            this.limpiarBTN.Name = "limpiarBTN";
            this.limpiarBTN.Size = new System.Drawing.Size(119, 23);
            this.limpiarBTN.TabIndex = 5;
            this.limpiarBTN.Text = "Limpiar Campos:";
            this.limpiarBTN.UseVisualStyleBackColor = true;
            this.limpiarBTN.Click += new System.EventHandler(this.limpiarBTN_Click);
            // 
            // ubicacionesDGV
            // 
            this.ubicacionesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ubicacionesDGV.Location = new System.Drawing.Point(51, 53);
            this.ubicacionesDGV.Name = "ubicacionesDGV";
            this.ubicacionesDGV.Size = new System.Drawing.Size(444, 218);
            this.ubicacionesDGV.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descripcion:";
            // 
            // agregarBTN
            // 
            this.agregarBTN.Location = new System.Drawing.Point(387, 39);
            this.agregarBTN.Name = "agregarBTN";
            this.agregarBTN.Size = new System.Drawing.Size(108, 23);
            this.agregarBTN.TabIndex = 9;
            this.agregarBTN.Text = "Agregar Ubicacion";
            this.agregarBTN.UseVisualStyleBackColor = true;
            this.agregarBTN.Click += new System.EventHandler(this.agregarBTN_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Precio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Asiento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fila:";
            // 
            // fila
            // 
            this.fila.Location = new System.Drawing.Point(61, 17);
            this.fila.Name = "fila";
            this.fila.Size = new System.Drawing.Size(100, 20);
            this.fila.TabIndex = 13;
            // 
            // asiento
            // 
            this.asiento.Location = new System.Drawing.Point(61, 62);
            this.asiento.Name = "asiento";
            this.asiento.Size = new System.Drawing.Size(100, 20);
            this.asiento.TabIndex = 14;
            // 
            // precio
            // 
            this.precio.Location = new System.Drawing.Point(252, 62);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(100, 20);
            this.precio.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Haga doble click sobre una celda para modificarla:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Cargar tipos de ubicacion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // descripcion
            // 
            this.descripcion.FormattingEnabled = true;
            this.descripcion.Location = new System.Drawing.Point(252, 18);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(99, 21);
            this.descripcion.TabIndex = 18;
            this.descripcion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ubicacionesGB
            // 
            this.ubicacionesGB.Controls.Add(this.descripcion);
            this.ubicacionesGB.Controls.Add(this.precio);
            this.ubicacionesGB.Controls.Add(this.asiento);
            this.ubicacionesGB.Controls.Add(this.fila);
            this.ubicacionesGB.Controls.Add(this.label5);
            this.ubicacionesGB.Controls.Add(this.agregarBTN);
            this.ubicacionesGB.Controls.Add(this.label4);
            this.ubicacionesGB.Controls.Add(this.label3);
            this.ubicacionesGB.Controls.Add(this.label2);
            this.ubicacionesGB.Location = new System.Drawing.Point(16, 349);
            this.ubicacionesGB.Name = "ubicacionesGB";
            this.ubicacionesGB.Size = new System.Drawing.Size(522, 115);
            this.ubicacionesGB.TabIndex = 19;
            this.ubicacionesGB.TabStop = false;
            this.ubicacionesGB.Text = "Ubicacion";
            // 
            // ABMUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 547);
            this.Controls.Add(this.ubicacionesGB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ubicacionesDGV);
            this.Controls.Add(this.limpiarBTN);
            this.Controls.Add(this.guardarBTN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "ABMUbicaciones";
            this.Text = "ABMUbicaciones";
            this.Load += new System.EventHandler(this.ABMUbicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionesDGV)).EndInit();
            this.ubicacionesGB.ResumeLayout(false);
            this.ubicacionesGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardarBTN;
        private System.Windows.Forms.Button limpiarBTN;
        private System.Windows.Forms.DataGridView ubicacionesDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button agregarBTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fila;
        private System.Windows.Forms.TextBox asiento;
        private System.Windows.Forms.TextBox precio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox descripcion;
        private System.Windows.Forms.GroupBox ubicacionesGB;
    }
}