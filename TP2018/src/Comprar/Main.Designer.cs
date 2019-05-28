namespace PalcoNet.Comprar
{
    partial class Main
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
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.buscar = new System.Windows.Forms.Button();
            this.categorias = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ubicaciones = new System.Windows.Forms.CheckedListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.publicaciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tarjetaRadio = new System.Windows.Forms.RadioButton();
            this.efectivoRadio = new System.Windows.Forms.RadioButton();
            this.tarjetaTB = new System.Windows.Forms.TextBox();
            this.tajetaLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nro_pagina = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publicaciones)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechaHasta);
            this.groupBox1.Controls.Add(this.fechaDesde);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.categorias);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.descripcion);
            this.groupBox1.Location = new System.Drawing.Point(55, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Filtrar Publicaciones";
            // 
            // fechaHasta
            // 
            this.fechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaHasta.Location = new System.Drawing.Point(110, 189);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(200, 20);
            this.fechaHasta.TabIndex = 9;
            this.fechaHasta.Value = new System.DateTime(2018, 12, 10, 11, 57, 44, 0);
            // 
            // fechaDesde
            // 
            this.fechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaDesde.Location = new System.Drawing.Point(110, 163);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.fechaDesde.TabIndex = 9;
            this.fechaDesde.Value = new System.DateTime(2018, 12, 10, 11, 56, 58, 0);
            this.fechaDesde.ValueChanged += new System.EventHandler(this.fechaDesde_ValueChanged);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(315, 219);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(144, 23);
            this.buscar.TabIndex = 5;
            this.buscar.Text = "Filtrar Publicaciones";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // categorias
            // 
            this.categorias.FormattingEnabled = true;
            this.categorias.Location = new System.Drawing.Point(110, 24);
            this.categorias.Name = "categorias";
            this.categorias.Size = new System.Drawing.Size(286, 79);
            this.categorias.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha desde:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Categoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descripcion:";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(110, 125);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(223, 20);
            this.descripcion.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(68, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "< ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(315, 253);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(417, 253);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ubicaciones);
            this.groupBox2.Location = new System.Drawing.Point(561, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 368);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Elegir ubicaciones";
            // 
            // ubicaciones
            // 
            this.ubicaciones.FormattingEnabled = true;
            this.ubicaciones.Location = new System.Drawing.Point(6, 24);
            this.ubicaciones.Name = "ubicaciones";
            this.ubicaciones.Size = new System.Drawing.Size(250, 334);
            this.ubicaciones.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(687, 669);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Comprar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nro_pagina);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.publicaciones);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(55, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 339);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Publicaciones";
            // 
            // publicaciones
            // 
            this.publicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.publicaciones.Location = new System.Drawing.Point(16, 20);
            this.publicaciones.Name = "publicaciones";
            this.publicaciones.Size = new System.Drawing.Size(443, 227);
            this.publicaciones.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Buscar Ubicaciones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tarjetaRadio);
            this.groupBox4.Controls.Add(this.efectivoRadio);
            this.groupBox4.Controls.Add(this.tarjetaTB);
            this.groupBox4.Controls.Add(this.tajetaLabel);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(561, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 216);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info de pago";
            // 
            // tarjetaRadio
            // 
            this.tarjetaRadio.AutoSize = true;
            this.tarjetaRadio.Location = new System.Drawing.Point(21, 85);
            this.tarjetaRadio.Name = "tarjetaRadio";
            this.tarjetaRadio.Size = new System.Drawing.Size(93, 17);
            this.tarjetaRadio.TabIndex = 7;
            this.tarjetaRadio.TabStop = true;
            this.tarjetaRadio.Text = "Tarjeta credito";
            this.tarjetaRadio.UseVisualStyleBackColor = true;
            // 
            // efectivoRadio
            // 
            this.efectivoRadio.AutoSize = true;
            this.efectivoRadio.Location = new System.Drawing.Point(21, 61);
            this.efectivoRadio.Name = "efectivoRadio";
            this.efectivoRadio.Size = new System.Drawing.Size(64, 17);
            this.efectivoRadio.TabIndex = 6;
            this.efectivoRadio.TabStop = true;
            this.efectivoRadio.Text = "Efectivo";
            this.efectivoRadio.UseVisualStyleBackColor = true;
            // 
            // tarjetaTB
            // 
            this.tarjetaTB.Location = new System.Drawing.Point(16, 157);
            this.tarjetaTB.Name = "tarjetaTB";
            this.tarjetaTB.Size = new System.Drawing.Size(239, 20);
            this.tarjetaTB.TabIndex = 5;
            // 
            // tajetaLabel
            // 
            this.tajetaLabel.AutoSize = true;
            this.tajetaLabel.Location = new System.Drawing.Point(18, 130);
            this.tajetaLabel.Name = "tajetaLabel";
            this.tajetaLabel.Size = new System.Drawing.Size(43, 13);
            this.tajetaLabel.TabIndex = 4;
            this.tajetaLabel.Text = "Tarjeta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Forma de pago:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pagina:";
            // 
            // nro_pagina
            // 
            this.nro_pagina.AutoSize = true;
            this.nro_pagina.Location = new System.Drawing.Point(240, 258);
            this.nro_pagina.Name = "nro_pagina";
            this.nro_pagina.Size = new System.Drawing.Size(13, 13);
            this.nro_pagina.TabIndex = 8;
            this.nro_pagina.Text = "1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 706);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Comprar Localidades";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publicaciones)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.CheckedListBox categorias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.CheckedListBox ubicaciones;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView publicaciones;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tarjetaTB;
        private System.Windows.Forms.Label tajetaLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton tarjetaRadio;
        private System.Windows.Forms.RadioButton efectivoRadio;
        private System.Windows.Forms.Label nro_pagina;
        private System.Windows.Forms.Label label6;
    }
}