namespace FrbaCrucero.CompraReservaPasaje
{
    partial class ReservaViaje
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
            this.cantPasajes = new System.Windows.Forms.NumericUpDown();
            this.buscarViaje = new System.Windows.Forms.Button();
            this.filtroDestino = new System.Windows.Forms.ComboBox();
            this.filtroOrigen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filtroFecha = new System.Windows.Forms.DateTimePicker();
            this.crucerosDGW = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cliente_nacimiento = new System.Windows.Forms.DateTimePicker();
            this.cliente_dni = new System.Windows.Forms.NumericUpDown();
            this.cliente_telefono = new System.Windows.Forms.TextBox();
            this.cliente_mail = new System.Windows.Forms.TextBox();
            this.cliente_apellido = new System.Windows.Forms.TextBox();
            this.cliente_direccion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cliente_nombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cabinasCBL = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantPasajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crucerosDGW)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cliente_dni)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cantPasajes);
            this.groupBox1.Controls.Add(this.buscarViaje);
            this.groupBox1.Controls.Add(this.filtroDestino);
            this.groupBox1.Controls.Add(this.filtroOrigen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.filtroFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda viajes";
            // 
            // cantPasajes
            // 
            this.cantPasajes.Location = new System.Drawing.Point(357, 63);
            this.cantPasajes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantPasajes.Name = "cantPasajes";
            this.cantPasajes.Size = new System.Drawing.Size(173, 20);
            this.cantPasajes.TabIndex = 4;
            this.cantPasajes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buscarViaje
            // 
            this.buscarViaje.Location = new System.Drawing.Point(479, 97);
            this.buscarViaje.Name = "buscarViaje";
            this.buscarViaje.Size = new System.Drawing.Size(83, 21);
            this.buscarViaje.TabIndex = 3;
            this.buscarViaje.Text = "Buscar";
            this.buscarViaje.UseVisualStyleBackColor = true;
            this.buscarViaje.Click += new System.EventHandler(this.buscarViaje_Click);
            // 
            // filtroDestino
            // 
            this.filtroDestino.FormattingEnabled = true;
            this.filtroDestino.Location = new System.Drawing.Point(357, 29);
            this.filtroDestino.Name = "filtroDestino";
            this.filtroDestino.Size = new System.Drawing.Size(173, 21);
            this.filtroDestino.TabIndex = 2;
            // 
            // filtroOrigen
            // 
            this.filtroOrigen.FormattingEnabled = true;
            this.filtroOrigen.Location = new System.Drawing.Point(65, 29);
            this.filtroOrigen.Name = "filtroOrigen";
            this.filtroOrigen.Size = new System.Drawing.Size(200, 21);
            this.filtroOrigen.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cantidad";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Destino";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origen";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // filtroFecha
            // 
            this.filtroFecha.Location = new System.Drawing.Point(65, 63);
            this.filtroFecha.Name = "filtroFecha";
            this.filtroFecha.Size = new System.Drawing.Size(200, 20);
            this.filtroFecha.TabIndex = 0;
            // 
            // crucerosDGW
            // 
            this.crucerosDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crucerosDGW.Location = new System.Drawing.Point(12, 181);
            this.crucerosDGW.Name = "crucerosDGW";
            this.crucerosDGW.Size = new System.Drawing.Size(283, 200);
            this.crucerosDGW.TabIndex = 1;
            this.crucerosDGW.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.crucerosDGW_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cruceros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cabinas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cliente_nacimiento);
            this.groupBox2.Controls.Add(this.cliente_dni);
            this.groupBox2.Controls.Add(this.cliente_telefono);
            this.groupBox2.Controls.Add(this.cliente_mail);
            this.groupBox2.Controls.Add(this.cliente_apellido);
            this.groupBox2.Controls.Add(this.cliente_direccion);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cliente_nombre);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(30, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 137);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // cliente_nacimiento
            // 
            this.cliente_nacimiento.Location = new System.Drawing.Point(73, 89);
            this.cliente_nacimiento.Name = "cliente_nacimiento";
            this.cliente_nacimiento.Size = new System.Drawing.Size(200, 20);
            this.cliente_nacimiento.TabIndex = 3;
            // 
            // cliente_dni
            // 
            this.cliente_dni.Location = new System.Drawing.Point(437, 34);
            this.cliente_dni.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cliente_dni.Name = "cliente_dni";
            this.cliente_dni.Size = new System.Drawing.Size(120, 20);
            this.cliente_dni.TabIndex = 2;
            this.cliente_dni.ValueChanged += new System.EventHandler(this.cliente_dni_ValueChanged);
            // 
            // cliente_telefono
            // 
            this.cliente_telefono.Location = new System.Drawing.Point(437, 60);
            this.cliente_telefono.Name = "cliente_telefono";
            this.cliente_telefono.Size = new System.Drawing.Size(120, 20);
            this.cliente_telefono.TabIndex = 1;
            // 
            // cliente_mail
            // 
            this.cliente_mail.Location = new System.Drawing.Point(242, 57);
            this.cliente_mail.Name = "cliente_mail";
            this.cliente_mail.Size = new System.Drawing.Size(116, 20);
            this.cliente_mail.TabIndex = 1;
            // 
            // cliente_apellido
            // 
            this.cliente_apellido.Location = new System.Drawing.Point(242, 31);
            this.cliente_apellido.Name = "cliente_apellido";
            this.cliente_apellido.Size = new System.Drawing.Size(116, 20);
            this.cliente_apellido.TabIndex = 1;
            // 
            // cliente_direccion
            // 
            this.cliente_direccion.Location = new System.Drawing.Point(56, 57);
            this.cliente_direccion.Name = "cliente_direccion";
            this.cliente_direccion.Size = new System.Drawing.Size(116, 20);
            this.cliente_direccion.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(376, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Telefono";
            // 
            // cliente_nombre
            // 
            this.cliente_nombre.Location = new System.Drawing.Point(56, 31);
            this.cliente_nombre.Name = "cliente_nombre";
            this.cliente_nombre.Size = new System.Drawing.Size(116, 20);
            this.cliente_nombre.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mail";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Dni";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nacimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Direccion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 591);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Reservar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar cabinas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cabinasCBL
            // 
            this.cabinasCBL.FormattingEnabled = true;
            this.cabinasCBL.Location = new System.Drawing.Point(337, 183);
            this.cabinasCBL.Name = "cabinasCBL";
            this.cabinasCBL.Size = new System.Drawing.Size(261, 199);
            this.cabinasCBL.TabIndex = 8;
            this.cabinasCBL.SelectedIndexChanged += new System.EventHandler(this.cabinasCBL_SelectedIndexChanged);
            // 
            // ReservaViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 638);
            this.Controls.Add(this.cabinasCBL);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.crucerosDGW);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReservaViaje";
            this.Text = "CompraViaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantPasajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crucerosDGW)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cliente_dni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker filtroFecha;
        private System.Windows.Forms.ComboBox filtroDestino;
        private System.Windows.Forms.ComboBox filtroOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buscarViaje;
        private System.Windows.Forms.DataGridView crucerosDGW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker cliente_nacimiento;
        private System.Windows.Forms.NumericUpDown cliente_dni;
        private System.Windows.Forms.TextBox cliente_telefono;
        private System.Windows.Forms.TextBox cliente_mail;
        private System.Windows.Forms.TextBox cliente_apellido;
        private System.Windows.Forms.TextBox cliente_direccion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cliente_nombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown cantPasajes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox cabinasCBL;
    }
}