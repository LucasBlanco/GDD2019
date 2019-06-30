namespace FrbaCrucero.AbmCrucero
{
    partial class TablaCrucero
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
            this.cruceros = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.filtro_nombre = new System.Windows.Forms.TextBox();
            this.filtro_identificador = new System.Windows.Forms.TextBox();
            this.filtro_modelo = new System.Windows.Forms.TextBox();
            this.filtro_marcaCB = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cruceros)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cruceros
            // 
            this.cruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cruceros.Location = new System.Drawing.Point(43, 164);
            this.cruceros.Name = "cruceros";
            this.cruceros.Size = new System.Drawing.Size(445, 196);
            this.cruceros.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Establecer fuera de servicio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(391, 381);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "Termino vida util";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.filtro_marcaCB);
            this.groupBox1.Controls.Add(this.filtro_modelo);
            this.groupBox1.Controls.Add(this.filtro_identificador);
            this.groupBox1.Controls.Add(this.filtro_nombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(42, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Identificador";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Marca";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // filtro_nombre
            // 
            this.filtro_nombre.Location = new System.Drawing.Point(71, 24);
            this.filtro_nombre.Name = "filtro_nombre";
            this.filtro_nombre.Size = new System.Drawing.Size(141, 20);
            this.filtro_nombre.TabIndex = 2;
            // 
            // filtro_identificador
            // 
            this.filtro_identificador.Location = new System.Drawing.Point(306, 27);
            this.filtro_identificador.Name = "filtro_identificador";
            this.filtro_identificador.Size = new System.Drawing.Size(124, 20);
            this.filtro_identificador.TabIndex = 3;
            // 
            // filtro_modelo
            // 
            this.filtro_modelo.Location = new System.Drawing.Point(73, 58);
            this.filtro_modelo.Name = "filtro_modelo";
            this.filtro_modelo.Size = new System.Drawing.Size(138, 20);
            this.filtro_modelo.TabIndex = 4;
            // 
            // filtro_marcaCB
            // 
            this.filtro_marcaCB.FormattingEnabled = true;
            this.filtro_marcaCB.Location = new System.Drawing.Point(306, 58);
            this.filtro_marcaCB.Name = "filtro_marcaCB";
            this.filtro_marcaCB.Size = new System.Drawing.Size(121, 21);
            this.filtro_marcaCB.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(355, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(274, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Limpiar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TablaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cruceros);
            this.Name = "TablaCrucero";
            this.Text = "TablaCrucero";
            ((System.ComponentModel.ISupportInitialize)(this.cruceros)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView cruceros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox filtro_marcaCB;
        private System.Windows.Forms.TextBox filtro_modelo;
        private System.Windows.Forms.TextBox filtro_identificador;
        private System.Windows.Forms.TextBox filtro_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}