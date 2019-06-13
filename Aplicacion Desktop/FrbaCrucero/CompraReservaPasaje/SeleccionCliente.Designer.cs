namespace FrbaCrucero.CompraReservaPasaje
{
    partial class SeleccionCliente
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
            this.clientesDGW = new System.Windows.Forms.DataGridView();
            this.Clientes = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientesDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // clientesDGW
            // 
            this.clientesDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesDGW.Location = new System.Drawing.Point(38, 51);
            this.clientesDGW.Name = "clientesDGW";
            this.clientesDGW.Size = new System.Drawing.Size(266, 150);
            this.clientesDGW.TabIndex = 0;
            // 
            // Clientes
            // 
            this.Clientes.AutoSize = true;
            this.Clientes.Location = new System.Drawing.Point(45, 26);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(44, 13);
            this.Clientes.TabIndex = 1;
            this.Clientes.Text = "Clientes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeleccionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Clientes);
            this.Controls.Add(this.clientesDGW);
            this.Name = "SeleccionCliente";
            this.Text = "SeleccionCliente";
            ((System.ComponentModel.ISupportInitialize)(this.clientesDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientesDGW;
        private System.Windows.Forms.Label Clientes;
        private System.Windows.Forms.Button button1;
    }
}