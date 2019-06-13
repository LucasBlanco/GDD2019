namespace FrbaCrucero.CompraReservaPasaje
{
    partial class InformeCodigoReserva
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
            this.codigo_reserva = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cabinasDGW = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cabinasDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo reserva:";
            // 
            // codigo_reserva
            // 
            this.codigo_reserva.AutoSize = true;
            this.codigo_reserva.Location = new System.Drawing.Point(126, 36);
            this.codigo_reserva.Name = "codigo_reserva";
            this.codigo_reserva.Size = new System.Drawing.Size(35, 13);
            this.codigo_reserva.TabIndex = 1;
            this.codigo_reserva.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pagar reserva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cabinasDGW
            // 
            this.cabinasDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cabinasDGW.Location = new System.Drawing.Point(29, 98);
            this.cabinasDGW.Name = "cabinasDGW";
            this.cabinasDGW.Size = new System.Drawing.Size(240, 150);
            this.cabinasDGW.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cabinas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total:";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(101, 270);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(35, 13);
            this.total.TabIndex = 6;
            this.total.Text = "label4";
            // 
            // InformeCodigoReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 364);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cabinasDGW);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codigo_reserva);
            this.Controls.Add(this.label1);
            this.Name = "InformeCodigoReserva";
            this.Text = "InformeCodigoReserva";
            ((System.ComponentModel.ISupportInitialize)(this.cabinasDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label codigo_reserva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView cabinasDGW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label total;
    }
}