namespace PalcoNet.Generar_Publicacion
{
    partial class AltaPublicacion
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
            this.descripcionTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ubicacionesBTN = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.direccionTB = new System.Windows.Forms.TextBox();
            this.guardarBTN = new System.Windows.Forms.Button();
            this.limpiarBTN = new System.Windows.Forms.Button();
            this.fechasBTN = new System.Windows.Forms.Button();
            this.nro_calle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grados = new System.Windows.Forms.ComboBox();
            this.rubros = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // descripcionTB
            // 
            this.descripcionTB.Location = new System.Drawing.Point(155, 47);
            this.descripcionTB.Name = "descripcionTB";
            this.descripcionTB.Size = new System.Drawing.Size(164, 20);
            this.descripcionTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripcion:";
            // 
            // ubicacionesBTN
            // 
            this.ubicacionesBTN.Location = new System.Drawing.Point(474, 129);
            this.ubicacionesBTN.Name = "ubicacionesBTN";
            this.ubicacionesBTN.Size = new System.Drawing.Size(164, 23);
            this.ubicacionesBTN.TabIndex = 2;
            this.ubicacionesBTN.Text = "Ubicaciones";
            this.ubicacionesBTN.UseVisualStyleBackColor = true;
            this.ubicacionesBTN.Click += new System.EventHandler(this.ubicacionesBTN_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Calle:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // direccionTB
            // 
            this.direccionTB.Location = new System.Drawing.Point(474, 47);
            this.direccionTB.Name = "direccionTB";
            this.direccionTB.Size = new System.Drawing.Size(164, 20);
            this.direccionTB.TabIndex = 12;
            // 
            // guardarBTN
            // 
            this.guardarBTN.Location = new System.Drawing.Point(503, 224);
            this.guardarBTN.Name = "guardarBTN";
            this.guardarBTN.Size = new System.Drawing.Size(135, 23);
            this.guardarBTN.TabIndex = 15;
            this.guardarBTN.Text = "Guardar en borrador";
            this.guardarBTN.UseVisualStyleBackColor = true;
            this.guardarBTN.Click += new System.EventHandler(this.guardarBTN_Click);
            // 
            // limpiarBTN
            // 
            this.limpiarBTN.Location = new System.Drawing.Point(139, 224);
            this.limpiarBTN.Name = "limpiarBTN";
            this.limpiarBTN.Size = new System.Drawing.Size(113, 23);
            this.limpiarBTN.TabIndex = 17;
            this.limpiarBTN.Text = "Limpiar campos";
            this.limpiarBTN.UseVisualStyleBackColor = true;
            this.limpiarBTN.Click += new System.EventHandler(this.limpiarBTN_Click);
            // 
            // fechasBTN
            // 
            this.fechasBTN.Location = new System.Drawing.Point(474, 173);
            this.fechasBTN.Name = "fechasBTN";
            this.fechasBTN.Size = new System.Drawing.Size(164, 23);
            this.fechasBTN.TabIndex = 19;
            this.fechasBTN.Text = "Fechas del espectaculo";
            this.fechasBTN.UseVisualStyleBackColor = true;
            this.fechasBTN.Click += new System.EventHandler(this.fechasBTN_Click);
            // 
            // nro_calle
            // 
            this.nro_calle.Location = new System.Drawing.Point(474, 83);
            this.nro_calle.Name = "nro_calle";
            this.nro_calle.Size = new System.Drawing.Size(164, 20);
            this.nro_calle.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nro:";
            // 
            // grados
            // 
            this.grados.FormattingEnabled = true;
            this.grados.Location = new System.Drawing.Point(155, 83);
            this.grados.Name = "grados";
            this.grados.Size = new System.Drawing.Size(164, 21);
            this.grados.TabIndex = 24;
            // 
            // rubros
            // 
            this.rubros.FormattingEnabled = true;
            this.rubros.Location = new System.Drawing.Point(152, 118);
            this.rubros.Name = "rubros";
            this.rubros.Size = new System.Drawing.Size(164, 21);
            this.rubros.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Grado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rubro:";
            // 
            // AltaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 290);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rubros);
            this.Controls.Add(this.grados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nro_calle);
            this.Controls.Add(this.fechasBTN);
            this.Controls.Add(this.limpiarBTN);
            this.Controls.Add(this.guardarBTN);
            this.Controls.Add(this.direccionTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ubicacionesBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descripcionTB);
            this.Name = "AltaPublicacion";
            this.Text = "AltaPublicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descripcionTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ubicacionesBTN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox direccionTB;
        private System.Windows.Forms.Button guardarBTN;
        private System.Windows.Forms.Button limpiarBTN;
        private System.Windows.Forms.Button fechasBTN;
        private System.Windows.Forms.TextBox nro_calle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox grados;
        private System.Windows.Forms.ComboBox rubros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}