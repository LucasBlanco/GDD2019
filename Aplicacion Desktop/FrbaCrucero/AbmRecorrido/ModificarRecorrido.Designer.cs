namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificarRecorrido
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
            this.modificar = new System.Windows.Forms.Button();
            this.Tramos = new System.Windows.Forms.GroupBox();
            this.precio = new System.Windows.Forms.NumericUpDown();
            this.tramosDGW = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.inicio = new System.Windows.Forms.ComboBox();
            this.codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tramos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tramosDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(533, 365);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(75, 23);
            this.modificar.TabIndex = 8;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // Tramos
            // 
            this.Tramos.Controls.Add(this.precio);
            this.Tramos.Controls.Add(this.tramosDGW);
            this.Tramos.Controls.Add(this.button1);
            this.Tramos.Controls.Add(this.button2);
            this.Tramos.Controls.Add(this.label4);
            this.Tramos.Controls.Add(this.label3);
            this.Tramos.Controls.Add(this.label2);
            this.Tramos.Controls.Add(this.destino);
            this.Tramos.Controls.Add(this.inicio);
            this.Tramos.Location = new System.Drawing.Point(24, 60);
            this.Tramos.Name = "Tramos";
            this.Tramos.Size = new System.Drawing.Size(594, 268);
            this.Tramos.TabIndex = 7;
            this.Tramos.TabStop = false;
            this.Tramos.Text = "Tramos";
            // 
            // precio
            // 
            this.precio.DecimalPlaces = 2;
            this.precio.Location = new System.Drawing.Point(68, 119);
            this.precio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(143, 20);
            this.precio.TabIndex = 5;
            // 
            // tramosDGW
            // 
            this.tramosDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tramosDGW.Location = new System.Drawing.Point(262, 32);
            this.tramosDGW.Name = "tramosDGW";
            this.tramosDGW.Size = new System.Drawing.Size(313, 195);
            this.tramosDGW.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Agregar tramo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Borrar tramo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inicio";
            // 
            // destino
            // 
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(68, 79);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(143, 21);
            this.destino.TabIndex = 0;
            // 
            // inicio
            // 
            this.inicio.FormattingEnabled = true;
            this.inicio.Location = new System.Drawing.Point(68, 32);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(143, 21);
            this.inicio.TabIndex = 0;
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(92, 18);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(487, 20);
            this.codigo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codigo";
            // 
            // ModificarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 440);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.Tramos);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.label1);
            this.Name = "ModificarRecorrido";
            this.Text = "ModificarRecorrido";
            this.Tramos.ResumeLayout(false);
            this.Tramos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tramosDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.GroupBox Tramos;
        private System.Windows.Forms.NumericUpDown precio;
        private System.Windows.Forms.DataGridView tramosDGW;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.ComboBox inicio;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label label1;

    }
}