namespace PalcoNet.Generar_Rendicion_Comisiones
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.facturas = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cant de compras a rendir:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Rendir compras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(168, 35);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(138, 20);
            this.cantidad.TabIndex = 3;
            // 
            // facturas
            // 
            this.facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturas.Location = new System.Drawing.Point(25, 84);
            this.facturas.Name = "facturas";
            this.facturas.Size = new System.Drawing.Size(455, 289);
            this.facturas.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Buscar compras";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Generar_Rendicion_Comiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 429);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.facturas);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Generar_Rendicion_Comiciones";
            this.Text = "Rendicion de Comisiones";
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.DataGridView facturas;
        private System.Windows.Forms.Button button2;
    }
}