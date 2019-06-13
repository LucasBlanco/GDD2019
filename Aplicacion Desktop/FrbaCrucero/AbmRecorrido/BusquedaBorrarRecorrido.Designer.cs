namespace FrbaCrucero.AbmRecorrido
{
    partial class BusquedaBorrarRecorrido
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filtroInicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filtroDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filtroCodigo = new System.Windows.Forms.TextBox();
            this.recorridosDGW = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recorridosDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.filtroCodigo);
            this.groupBox1.Controls.Add(this.filtroDestino);
            this.groupBox1.Controls.Add(this.filtroInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(34, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de recorrido";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Limpiar filtros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(579, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Filtrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inicio";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // filtroInicio
            // 
            this.filtroInicio.FormattingEnabled = true;
            this.filtroInicio.Location = new System.Drawing.Point(89, 39);
            this.filtroInicio.Name = "filtroInicio";
            this.filtroInicio.Size = new System.Drawing.Size(121, 21);
            this.filtroInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destino";
            // 
            // filtroDestino
            // 
            this.filtroDestino.FormattingEnabled = true;
            this.filtroDestino.Location = new System.Drawing.Point(299, 39);
            this.filtroDestino.Name = "filtroDestino";
            this.filtroDestino.Size = new System.Drawing.Size(121, 21);
            this.filtroDestino.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Codigo";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // filtroCodigo
            // 
            this.filtroCodigo.Location = new System.Drawing.Point(536, 39);
            this.filtroCodigo.Name = "filtroCodigo";
            this.filtroCodigo.Size = new System.Drawing.Size(121, 20);
            this.filtroCodigo.TabIndex = 3;
            // 
            // recorridosDGW
            // 
            this.recorridosDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recorridosDGW.Location = new System.Drawing.Point(34, 164);
            this.recorridosDGW.Name = "recorridosDGW";
            this.recorridosDGW.Size = new System.Drawing.Size(730, 258);
            this.recorridosDGW.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Se mostraran los recorridos que tengan como inicio y destino los campos seleccion" +
    "ados ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "\'o\'  los recorridos cuyo codigo contenga el codigo ingresado";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 450);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(527, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 2;
            this.button4.Text = "Inhabilitar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(648, 450);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 28);
            this.button5.TabIndex = 3;
            this.button5.Text = "Habilitar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BusquedaBorrarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 501);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.recorridosDGW);
            this.Controls.Add(this.groupBox1);
            this.Name = "BusquedaBorrarRecorrido";
            this.Text = "BusquedaBorrarRecorrido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recorridosDGW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox filtroDestino;
        private System.Windows.Forms.ComboBox filtroInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox filtroCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView recorridosDGW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}