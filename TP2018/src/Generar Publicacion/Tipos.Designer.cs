namespace PalcoNet.Generar_Publicacion
{
    partial class Tipos
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
            this.descripcion = new System.Windows.Forms.TextBox();
            this.nro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.agregarBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tiposDGV = new System.Windows.Forms.DataGridView();
            this.limpiarBTN = new System.Windows.Forms.Button();
            this.guardarBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tiposDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(316, 297);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(100, 20);
            this.descripcion.TabIndex = 27;
            // 
            // nro
            // 
            this.nro.Location = new System.Drawing.Point(86, 297);
            this.nro.Name = "nro";
            this.nro.Size = new System.Drawing.Size(100, 20);
            this.nro.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Descripcion:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // agregarBTN
            // 
            this.agregarBTN.Location = new System.Drawing.Point(308, 346);
            this.agregarBTN.Name = "agregarBTN";
            this.agregarBTN.Size = new System.Drawing.Size(108, 23);
            this.agregarBTN.TabIndex = 21;
            this.agregarBTN.Text = "Agregar Tipo";
            this.agregarBTN.UseVisualStyleBackColor = true;
            this.agregarBTN.Click += new System.EventHandler(this.agregarBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nro:";
            // 
            // tiposDGV
            // 
            this.tiposDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tiposDGV.Location = new System.Drawing.Point(12, 12);
            this.tiposDGV.Name = "tiposDGV";
            this.tiposDGV.Size = new System.Drawing.Size(444, 261);
            this.tiposDGV.TabIndex = 19;
            // 
            // limpiarBTN
            // 
            this.limpiarBTN.Location = new System.Drawing.Point(12, 413);
            this.limpiarBTN.Name = "limpiarBTN";
            this.limpiarBTN.Size = new System.Drawing.Size(119, 23);
            this.limpiarBTN.TabIndex = 18;
            this.limpiarBTN.Text = "Limpiar Campos";
            this.limpiarBTN.UseVisualStyleBackColor = true;
            // 
            // guardarBTN
            // 
            this.guardarBTN.Location = new System.Drawing.Point(337, 413);
            this.guardarBTN.Name = "guardarBTN";
            this.guardarBTN.Size = new System.Drawing.Size(119, 23);
            this.guardarBTN.TabIndex = 17;
            this.guardarBTN.Text = "Guardar";
            this.guardarBTN.UseVisualStyleBackColor = true;
            this.guardarBTN.Click += new System.EventHandler(this.guardarBTN_Click);
            // 
            // Tipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 460);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.nro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.agregarBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tiposDGV);
            this.Controls.Add(this.limpiarBTN);
            this.Controls.Add(this.guardarBTN);
            this.Name = "Tipos";
            this.Text = "Tipos";
            ((System.ComponentModel.ISupportInitialize)(this.tiposDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.TextBox nro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button agregarBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tiposDGV;
        private System.Windows.Forms.Button limpiarBTN;
        private System.Windows.Forms.Button guardarBTN;

    }
}