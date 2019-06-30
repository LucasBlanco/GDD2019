namespace FrbaCrucero.AbmCrucero
{
    partial class EditarCrucero
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.piso = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.cabinas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tipo_servicio = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.marca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.identificador = new System.Windows.Forms.TextBox();
            this.modelo = new System.Windows.Forms.TextBox();
            this.crucero = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.piso);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numero);
            this.groupBox1.Controls.Add(this.cabinas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tipo_servicio);
            this.groupBox1.Location = new System.Drawing.Point(48, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 277);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabinas";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Borrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Crear cabina";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Piso:";
            // 
            // piso
            // 
            this.piso.Location = new System.Drawing.Point(86, 51);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(95, 20);
            this.piso.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nº:";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(81, 77);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(100, 20);
            this.numero.TabIndex = 13;
            // 
            // cabinas
            // 
            this.cabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cabinas.Location = new System.Drawing.Point(204, 22);
            this.cabinas.Name = "cabinas";
            this.cabinas.Size = new System.Drawing.Size(303, 219);
            this.cabinas.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo servicio:";
            // 
            // tipo_servicio
            // 
            this.tipo_servicio.FormattingEnabled = true;
            this.tipo_servicio.Location = new System.Drawing.Point(86, 22);
            this.tipo_servicio.Name = "tipo_servicio";
            this.tipo_servicio.Size = new System.Drawing.Size(95, 21);
            this.tipo_servicio.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(490, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Modificar crucero";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Marca:";
            // 
            // marca
            // 
            this.marca.FormattingEnabled = true;
            this.marca.Location = new System.Drawing.Point(383, 53);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(162, 21);
            this.marca.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Identificador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Modelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Crucero:";
            // 
            // identificador
            // 
            this.identificador.Location = new System.Drawing.Point(132, 27);
            this.identificador.Name = "identificador";
            this.identificador.Size = new System.Drawing.Size(173, 20);
            this.identificador.TabIndex = 24;
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(132, 59);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(173, 20);
            this.modelo.TabIndex = 23;
            // 
            // crucero
            // 
            this.crucero.Location = new System.Drawing.Point(383, 27);
            this.crucero.Name = "crucero";
            this.crucero.Size = new System.Drawing.Size(162, 20);
            this.crucero.TabIndex = 22;
            // 
            // EditarCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.identificador);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.crucero);
            this.Name = "EditarCrucero";
            this.Text = "EditarCrucero";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox piso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.DataGridView cabinas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox tipo_servicio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox marca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox identificador;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.TextBox crucero;

    }
}