namespace PalcoNet.Editar_Publicacion
{
    partial class EditarPublicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.nro = new System.Windows.Forms.TextBox();
            this.limpiarBTN = new System.Windows.Forms.Button();
            this.guardarBTN = new System.Windows.Forms.Button();
            this.calle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ubicacionesBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.grados = new System.Windows.Forms.ComboBox();
            this.rubros = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fecha_evento = new System.Windows.Forms.DateTimePicker();
            this.nota = new System.Windows.Forms.Label();
            this.estadoLbl = new System.Windows.Forms.Label();
            this.estadoCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nro:";
            // 
            // nro
            // 
            this.nro.Location = new System.Drawing.Point(471, 84);
            this.nro.Name = "nro";
            this.nro.Size = new System.Drawing.Size(203, 20);
            this.nro.TabIndex = 36;
            // 
            // limpiarBTN
            // 
            this.limpiarBTN.Location = new System.Drawing.Point(121, 256);
            this.limpiarBTN.Name = "limpiarBTN";
            this.limpiarBTN.Size = new System.Drawing.Size(113, 23);
            this.limpiarBTN.TabIndex = 32;
            this.limpiarBTN.Text = "Limpiar campos";
            this.limpiarBTN.UseVisualStyleBackColor = true;
            this.limpiarBTN.Click += new System.EventHandler(this.limpiarBTN_Click);
            // 
            // guardarBTN
            // 
            this.guardarBTN.Location = new System.Drawing.Point(500, 256);
            this.guardarBTN.Name = "guardarBTN";
            this.guardarBTN.Size = new System.Drawing.Size(135, 23);
            this.guardarBTN.TabIndex = 31;
            this.guardarBTN.Text = "Modificar";
            this.guardarBTN.UseVisualStyleBackColor = true;
            this.guardarBTN.Click += new System.EventHandler(this.guardarBTN_Click);
            // 
            // calle
            // 
            this.calle.Location = new System.Drawing.Point(471, 48);
            this.calle.Name = "calle";
            this.calle.Size = new System.Drawing.Size(203, 20);
            this.calle.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Calle:";
            // 
            // ubicacionesBTN
            // 
            this.ubicacionesBTN.Location = new System.Drawing.Point(471, 130);
            this.ubicacionesBTN.Name = "ubicacionesBTN";
            this.ubicacionesBTN.Size = new System.Drawing.Size(203, 23);
            this.ubicacionesBTN.TabIndex = 26;
            this.ubicacionesBTN.Text = "Ubicaciones";
            this.ubicacionesBTN.UseVisualStyleBackColor = true;
            this.ubicacionesBTN.Click += new System.EventHandler(this.ubicacionesBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Descripcion:";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(152, 48);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(202, 20);
            this.descripcion.TabIndex = 24;
            // 
            // grados
            // 
            this.grados.FormattingEnabled = true;
            this.grados.Location = new System.Drawing.Point(152, 120);
            this.grados.Name = "grados";
            this.grados.Size = new System.Drawing.Size(202, 21);
            this.grados.TabIndex = 38;
            // 
            // rubros
            // 
            this.rubros.FormattingEnabled = true;
            this.rubros.Location = new System.Drawing.Point(152, 166);
            this.rubros.Name = "rubros";
            this.rubros.Size = new System.Drawing.Size(202, 21);
            this.rubros.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Grado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rubro:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Fecha de Evento:";
            // 
            // fecha_evento
            // 
            this.fecha_evento.CustomFormat = "dd/MM/yyyy HH:mm";
            this.fecha_evento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha_evento.Location = new System.Drawing.Point(150, 84);
            this.fecha_evento.Name = "fecha_evento";
            this.fecha_evento.Size = new System.Drawing.Size(204, 20);
            this.fecha_evento.TabIndex = 39;
            // 
            // nota
            // 
            this.nota.AutoSize = true;
            this.nota.Location = new System.Drawing.Point(66, 309);
            this.nota.Name = "nota";
            this.nota.Size = new System.Drawing.Size(524, 13);
            this.nota.TabIndex = 40;
            this.nota.Text = "Nota: Una vez que una publicacion pase a estado de \'Publicada\', solo se permitira" +
    "n modificaciones de estado";
            // 
            // estadoLbl
            // 
            this.estadoLbl.AutoSize = true;
            this.estadoLbl.Location = new System.Drawing.Point(424, 178);
            this.estadoLbl.Name = "estadoLbl";
            this.estadoLbl.Size = new System.Drawing.Size(43, 13);
            this.estadoLbl.TabIndex = 27;
            this.estadoLbl.Text = "Estado:";
            // 
            // estadoCB
            // 
            this.estadoCB.FormattingEnabled = true;
            this.estadoCB.Location = new System.Drawing.Point(472, 168);
            this.estadoCB.Name = "estadoCB";
            this.estadoCB.Size = new System.Drawing.Size(202, 21);
            this.estadoCB.TabIndex = 38;
            // 
            // EditarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 338);
            this.Controls.Add(this.nota);
            this.Controls.Add(this.fecha_evento);
            this.Controls.Add(this.estadoCB);
            this.Controls.Add(this.rubros);
            this.Controls.Add(this.grados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nro);
            this.Controls.Add(this.limpiarBTN);
            this.Controls.Add(this.guardarBTN);
            this.Controls.Add(this.calle);
            this.Controls.Add(this.estadoLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ubicacionesBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descripcion);
            this.Name = "EditarPublicacion";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nro;
        private System.Windows.Forms.Button limpiarBTN;
        private System.Windows.Forms.Button guardarBTN;
        private System.Windows.Forms.TextBox calle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ubicacionesBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.ComboBox grados;
        private System.Windows.Forms.ComboBox rubros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker fecha_evento;
        private System.Windows.Forms.Label nota;
        private System.Windows.Forms.Label estadoLbl;
        private System.Windows.Forms.ComboBox estadoCB;
    }
}