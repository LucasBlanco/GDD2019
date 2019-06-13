namespace FrbaCrucero.CompraReservaPasaje
{
    partial class InformePago
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cabinasDGW = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.crucero = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.medio_pago = new System.Windows.Forms.Label();
            this.nro_tarjeta = new System.Windows.Forms.Label();
            this.cant_cuotas = new System.Windows.Forms.Label();
            this.cod_pasaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cabinasDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha viaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Crucero:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cabinas";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // cabinasDGW
            // 
            this.cabinasDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cabinasDGW.Location = new System.Drawing.Point(16, 78);
            this.cabinasDGW.Name = "cabinasDGW";
            this.cabinasDGW.Size = new System.Drawing.Size(240, 150);
            this.cabinasDGW.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Medio pago:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nro. tarjeto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Cant. cuotas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Cod. pasaje:";
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Location = new System.Drawing.Point(90, 13);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(62, 13);
            this.fecha.TabIndex = 0;
            this.fecha.Text = "Fecha viaje";
            // 
            // crucero
            // 
            this.crucero.AutoSize = true;
            this.crucero.Location = new System.Drawing.Point(66, 37);
            this.crucero.Name = "crucero";
            this.crucero.Size = new System.Drawing.Size(47, 13);
            this.crucero.TabIndex = 0;
            this.crucero.Text = "Crucero:";
            this.crucero.Click += new System.EventHandler(this.label2_Click);
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(58, 247);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(34, 13);
            this.total.TabIndex = 2;
            this.total.Text = "Total:";
            // 
            // medio_pago
            // 
            this.medio_pago.AutoSize = true;
            this.medio_pago.Location = new System.Drawing.Point(86, 269);
            this.medio_pago.Name = "medio_pago";
            this.medio_pago.Size = new System.Drawing.Size(66, 13);
            this.medio_pago.TabIndex = 2;
            this.medio_pago.Text = "Medio pago:";
            // 
            // nro_tarjeta
            // 
            this.nro_tarjeta.AutoSize = true;
            this.nro_tarjeta.Location = new System.Drawing.Point(90, 295);
            this.nro_tarjeta.Name = "nro_tarjeta";
            this.nro_tarjeta.Size = new System.Drawing.Size(62, 13);
            this.nro_tarjeta.TabIndex = 2;
            this.nro_tarjeta.Text = "Nro. tarjeto:";
            // 
            // cant_cuotas
            // 
            this.cant_cuotas.AutoSize = true;
            this.cant_cuotas.Location = new System.Drawing.Point(90, 317);
            this.cant_cuotas.Name = "cant_cuotas";
            this.cant_cuotas.Size = new System.Drawing.Size(70, 13);
            this.cant_cuotas.TabIndex = 2;
            this.cant_cuotas.Text = "Cant. cuotas:";
            // 
            // cod_pasaje
            // 
            this.cod_pasaje.AutoSize = true;
            this.cod_pasaje.Location = new System.Drawing.Point(90, 339);
            this.cod_pasaje.Name = "cod_pasaje";
            this.cod_pasaje.Size = new System.Drawing.Size(66, 13);
            this.cod_pasaje.TabIndex = 2;
            this.cod_pasaje.Text = "Cod. pasaje:";
            // 
            // InformePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 395);
            this.Controls.Add(this.cod_pasaje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cant_cuotas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nro_tarjeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.medio_pago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cabinasDGW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crucero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label1);
            this.Name = "InformePago";
            this.Text = "InformePago";
            ((System.ComponentModel.ISupportInitialize)(this.cabinasDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView cabinasDGW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label crucero;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label medio_pago;
        private System.Windows.Forms.Label nro_tarjeta;
        private System.Windows.Forms.Label cant_cuotas;
        private System.Windows.Forms.Label cod_pasaje;
    }
}