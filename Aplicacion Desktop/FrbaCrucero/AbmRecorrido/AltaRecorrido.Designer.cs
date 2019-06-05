namespace FrbaCrucero.AbmRecorrido
{
    partial class AltaRecorrido
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
            this.codigo = new System.Windows.Forms.TextBox();
            this.Tramos = new System.Windows.Forms.GroupBox();
            this.precio = new System.Windows.Forms.NumericUpDown();
            this.tramosDGW = new System.Windows.Forms.DataGridView();
            this.inicioTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.inicio = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Tramos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tramosDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(80, 18);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(487, 20);
            this.codigo.TabIndex = 1;
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
            this.Tramos.Location = new System.Drawing.Point(12, 60);
            this.Tramos.Name = "Tramos";
            this.Tramos.Size = new System.Drawing.Size(594, 268);
            this.Tramos.TabIndex = 2;
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
            this.tramosDGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inicioTramo,
            this.destinoTramo,
            this.precioTramo});
            this.tramosDGW.Location = new System.Drawing.Point(242, 32);
            this.tramosDGW.Name = "tramosDGW";
            this.tramosDGW.Size = new System.Drawing.Size(313, 195);
            this.tramosDGW.TabIndex = 4;
            // 
            // inicioTramo
            // 
            this.inicioTramo.Frozen = true;
            this.inicioTramo.HeaderText = "Inicio";
            this.inicioTramo.Name = "inicioTramo";
            // 
            // destinoTramo
            // 
            this.destinoTramo.Frozen = true;
            this.destinoTramo.HeaderText = "Destino";
            this.destinoTramo.Name = "destinoTramo";
            // 
            // precioTramo
            // 
            this.precioTramo.Frozen = true;
            this.precioTramo.HeaderText = "Precio";
            this.precioTramo.Name = "precioTramo";
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
            this.inicio.Location = new System.Drawing.Point(68, 35);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(143, 21);
            this.inicio.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(512, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Alta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(425, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Borrar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AltaRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 442);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Tramos);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.label1);
            this.Name = "AltaRecorrido";
            this.Text = "AltaRecorrido";
            this.Tramos.ResumeLayout(false);
            this.Tramos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tramosDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.GroupBox Tramos;
        private System.Windows.Forms.DataGridView tramosDGW;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.ComboBox inicio;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicioTramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoTramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioTramo;
        private System.Windows.Forms.NumericUpDown precio;
    }
}