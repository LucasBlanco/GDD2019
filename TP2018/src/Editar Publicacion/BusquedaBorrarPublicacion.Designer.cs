namespace PalcoNet.Editar_Publicacion
{
    partial class BusquedaBorrarPublicacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grados = new System.Windows.Forms.ComboBox();
            this.rubros = new System.Windows.Forms.ComboBox();
            this.fechaEvento = new System.Windows.Forms.DateTimePicker();
            this.fechaPublicacion = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.publicaciones = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.nro_calle = new System.Windows.Forms.TextBox();
            this.calle = new System.Windows.Forms.TextBox();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(563, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Modificar Publicacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grados);
            this.groupBox1.Controls.Add(this.rubros);
            this.groupBox1.Controls.Add(this.fechaEvento);
            this.groupBox1.Controls.Add(this.fechaPublicacion);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.publicaciones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nro_calle);
            this.groupBox1.Controls.Add(this.calle);
            this.groupBox1.Controls.Add(this.descripcion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.grado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 530);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda Publicacion";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // grados
            // 
            this.grados.FormattingEnabled = true;
            this.grados.Location = new System.Drawing.Point(438, 68);
            this.grados.Name = "grados";
            this.grados.Size = new System.Drawing.Size(196, 21);
            this.grados.TabIndex = 15;
            // 
            // rubros
            // 
            this.rubros.FormattingEnabled = true;
            this.rubros.Location = new System.Drawing.Point(438, 33);
            this.rubros.Name = "rubros";
            this.rubros.Size = new System.Drawing.Size(196, 21);
            this.rubros.TabIndex = 15;
            // 
            // fechaEvento
            // 
            this.fechaEvento.CustomFormat = "dd/MM/yyyy HH:mm";
            this.fechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaEvento.Location = new System.Drawing.Point(124, 100);
            this.fechaEvento.Name = "fechaEvento";
            this.fechaEvento.Size = new System.Drawing.Size(200, 20);
            this.fechaEvento.TabIndex = 14;
            // 
            // fechaPublicacion
            // 
            this.fechaPublicacion.CustomFormat = "dd/MM/yyyy HH:mm";
            this.fechaPublicacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaPublicacion.Location = new System.Drawing.Point(124, 68);
            this.fechaPublicacion.Name = "fechaPublicacion";
            this.fechaPublicacion.Size = new System.Drawing.Size(200, 20);
            this.fechaPublicacion.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(438, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Limpiar filtros";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(534, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Filtrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // publicaciones
            // 
            this.publicaciones.AllowUserToAddRows = false;
            this.publicaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.publicaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.publicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.publicaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.publicaciones.Location = new System.Drawing.Point(0, 214);
            this.publicaciones.Name = "publicaciones";
            this.publicaciones.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.publicaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.publicaciones.Size = new System.Drawing.Size(664, 310);
            this.publicaciones.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha evento:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // nro_calle
            // 
            this.nro_calle.Location = new System.Drawing.Point(587, 107);
            this.nro_calle.Name = "nro_calle";
            this.nro_calle.Size = new System.Drawing.Size(47, 20);
            this.nro_calle.TabIndex = 7;
            this.nro_calle.TextChanged += new System.EventHandler(this.razon_social_TextChanged);
            // 
            // calle
            // 
            this.calle.Location = new System.Drawing.Point(438, 106);
            this.calle.Name = "calle";
            this.calle.Size = new System.Drawing.Size(113, 20);
            this.calle.TabIndex = 7;
            this.calle.TextChanged += new System.EventHandler(this.razon_social_TextChanged);
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(124, 33);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(200, 20);
            this.descripcion.TabIndex = 7;
            this.descripcion.TextChanged += new System.EventHandler(this.razon_social_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Publicacion";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Calle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Descripcion";
            // 
            // grado
            // 
            this.grado.AutoSize = true;
            this.grado.Location = new System.Drawing.Point(385, 68);
            this.grado.Name = "grado";
            this.grado.Size = new System.Drawing.Size(36, 13);
            this.grado.TabIndex = 0;
            this.grado.Text = "Grado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rubro";
            // 
            // BusquedaBorrarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 629);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BusquedaBorrarPublicacion";
            this.Text = "Modificar Publicacion";
            this.Load += new System.EventHandler(this.BusquedaBorrarPublicacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publicaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView publicaciones;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox grados;
        private System.Windows.Forms.ComboBox rubros;
        private System.Windows.Forms.DateTimePicker fechaEvento;
        private System.Windows.Forms.DateTimePicker fechaPublicacion;
        private System.Windows.Forms.TextBox calle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label grado;
        private System.Windows.Forms.TextBox nro_calle;
        private System.Windows.Forms.Label label6;
    }
}