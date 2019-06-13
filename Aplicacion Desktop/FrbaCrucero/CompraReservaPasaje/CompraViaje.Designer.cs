namespace FrbaCrucero.CompraReservaPasaje
{
    partial class CompraViaje
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
            this.codigo_reserva = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.credito = new System.Windows.Forms.RadioButton();
            this.efectivo = new System.Windows.Forms.RadioButton();
            this.In = new System.Windows.Forms.GroupBox();
            this.debito = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unaCuota = new System.Windows.Forms.RadioButton();
            this.dosCuotas = new System.Windows.Forms.RadioButton();
            this.tresCuotas = new System.Windows.Forms.RadioButton();
            this.Pagar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nro_tarjeta = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.codigo_seguridad = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.codigo_reserva)).BeginInit();
            this.In.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nro_tarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigo_seguridad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo reserva";
            // 
            // codigo_reserva
            // 
            this.codigo_reserva.Location = new System.Drawing.Point(158, 30);
            this.codigo_reserva.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.codigo_reserva.Name = "codigo_reserva";
            this.codigo_reserva.Size = new System.Drawing.Size(206, 20);
            this.codigo_reserva.TabIndex = 1;
            this.codigo_reserva.ValueChanged += new System.EventHandler(this.codigo_reserva_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Medio de pago:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // credito
            // 
            this.credito.AutoSize = true;
            this.credito.Location = new System.Drawing.Point(112, 27);
            this.credito.Name = "credito";
            this.credito.Size = new System.Drawing.Size(93, 17);
            this.credito.TabIndex = 3;
            this.credito.TabStop = true;
            this.credito.Text = "Tarjeta credito";
            this.credito.UseVisualStyleBackColor = true;
            this.credito.CheckedChanged += new System.EventHandler(this.credito_CheckedChanged);
            // 
            // efectivo
            // 
            this.efectivo.AutoSize = true;
            this.efectivo.Location = new System.Drawing.Point(309, 27);
            this.efectivo.Name = "efectivo";
            this.efectivo.Size = new System.Drawing.Size(64, 17);
            this.efectivo.TabIndex = 3;
            this.efectivo.TabStop = true;
            this.efectivo.Text = "Efectivo";
            this.efectivo.UseVisualStyleBackColor = true;
            this.efectivo.CheckedChanged += new System.EventHandler(this.efectivo_CheckedChanged);
            // 
            // In
            // 
            this.In.Controls.Add(this.codigo_seguridad);
            this.In.Controls.Add(this.nro_tarjeta);
            this.In.Controls.Add(this.label5);
            this.In.Controls.Add(this.label3);
            this.In.Controls.Add(this.debito);
            this.In.Controls.Add(this.efectivo);
            this.In.Controls.Add(this.credito);
            this.In.Controls.Add(this.label2);
            this.In.Location = new System.Drawing.Point(12, 71);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(400, 123);
            this.In.TabIndex = 4;
            this.In.TabStop = false;
            this.In.Text = "Medio de pago";
            // 
            // debito
            // 
            this.debito.AutoSize = true;
            this.debito.Location = new System.Drawing.Point(211, 27);
            this.debito.Name = "debito";
            this.debito.Size = new System.Drawing.Size(90, 17);
            this.debito.TabIndex = 4;
            this.debito.TabStop = true;
            this.debito.Text = "Tarjeta debito";
            this.debito.UseVisualStyleBackColor = true;
            this.debito.CheckedChanged += new System.EventHandler(this.debito_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cuotas:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tresCuotas);
            this.groupBox1.Controls.Add(this.dosCuotas);
            this.groupBox1.Controls.Add(this.unaCuota);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(14, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 56);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuotas";
            // 
            // unaCuota
            // 
            this.unaCuota.AutoSize = true;
            this.unaCuota.Location = new System.Drawing.Point(112, 23);
            this.unaCuota.Name = "unaCuota";
            this.unaCuota.Size = new System.Drawing.Size(31, 17);
            this.unaCuota.TabIndex = 6;
            this.unaCuota.TabStop = true;
            this.unaCuota.Text = "1";
            this.unaCuota.UseVisualStyleBackColor = true;
            // 
            // dosCuotas
            // 
            this.dosCuotas.AutoSize = true;
            this.dosCuotas.Location = new System.Drawing.Point(161, 23);
            this.dosCuotas.Name = "dosCuotas";
            this.dosCuotas.Size = new System.Drawing.Size(31, 17);
            this.dosCuotas.TabIndex = 6;
            this.dosCuotas.TabStop = true;
            this.dosCuotas.Text = "3";
            this.dosCuotas.UseVisualStyleBackColor = true;
            // 
            // tresCuotas
            // 
            this.tresCuotas.AutoSize = true;
            this.tresCuotas.Location = new System.Drawing.Point(211, 25);
            this.tresCuotas.Name = "tresCuotas";
            this.tresCuotas.Size = new System.Drawing.Size(31, 17);
            this.tresCuotas.TabIndex = 6;
            this.tresCuotas.TabStop = true;
            this.tresCuotas.Text = "6";
            this.tresCuotas.UseVisualStyleBackColor = true;
            // 
            // Pagar
            // 
            this.Pagar.Location = new System.Drawing.Point(337, 306);
            this.Pagar.Name = "Pagar";
            this.Pagar.Size = new System.Drawing.Size(75, 23);
            this.Pagar.TabIndex = 7;
            this.Pagar.Text = "Pagar";
            this.Pagar.UseVisualStyleBackColor = true;
            this.Pagar.Click += new System.EventHandler(this.Pagar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro. tarjeta:";
            // 
            // nro_tarjeta
            // 
            this.nro_tarjeta.Location = new System.Drawing.Point(116, 55);
            this.nro_tarjeta.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.nro_tarjeta.Name = "nro_tarjeta";
            this.nro_tarjeta.Size = new System.Drawing.Size(152, 20);
            this.nro_tarjeta.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cod. seguridad";
            // 
            // codigo_seguridad
            // 
            this.codigo_seguridad.Location = new System.Drawing.Point(117, 82);
            this.codigo_seguridad.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.codigo_seguridad.Name = "codigo_seguridad";
            this.codigo_seguridad.Size = new System.Drawing.Size(152, 20);
            this.codigo_seguridad.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total:";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(110, 278);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(35, 13);
            this.total.TabIndex = 9;
            this.total.Text = "label7";
            // 
            // CompraViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 373);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Pagar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.In);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigo_reserva);
            this.Name = "CompraViaje";
            this.Text = "ReservaViaje";
            this.Load += new System.EventHandler(this.CompraViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.codigo_reserva)).EndInit();
            this.In.ResumeLayout(false);
            this.In.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nro_tarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigo_seguridad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown codigo_reserva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton credito;
        private System.Windows.Forms.RadioButton efectivo;
        private System.Windows.Forms.GroupBox In;
        private System.Windows.Forms.RadioButton debito;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nro_tarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton tresCuotas;
        private System.Windows.Forms.RadioButton dosCuotas;
        private System.Windows.Forms.RadioButton unaCuota;
        private System.Windows.Forms.Button Pagar;
        private System.Windows.Forms.NumericUpDown codigo_seguridad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label total;
    }
}