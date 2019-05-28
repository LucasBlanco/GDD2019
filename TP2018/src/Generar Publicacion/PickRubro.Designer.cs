namespace PalcoNet.Generar_Publicacion
{
    partial class PickRubro
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
            this.elegir = new System.Windows.Forms.Button();
            this.elegirDGV = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.elegirDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // elegir
            // 
            this.elegir.Location = new System.Drawing.Point(279, 224);
            this.elegir.Name = "elegir";
            this.elegir.Size = new System.Drawing.Size(110, 34);
            this.elegir.TabIndex = 3;
            this.elegir.Text = "Elegir";
            this.elegir.UseVisualStyleBackColor = true;
            this.elegir.Click += new System.EventHandler(this.elegir_Click);
            // 
            // elegirDGV
            // 
            this.elegirDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elegirDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descripcion});
            this.elegirDGV.Location = new System.Drawing.Point(46, 48);
            this.elegirDGV.Name = "elegirDGV";
            this.elegirDGV.Size = new System.Drawing.Size(343, 150);
            this.elegirDGV.TabIndex = 2;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 200;
            // 
            // PickRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 284);
            this.Controls.Add(this.elegir);
            this.Controls.Add(this.elegirDGV);
            this.Name = "PickRubro";
            this.Text = "Elegir Rubro";
            ((System.ComponentModel.ISupportInitialize)(this.elegirDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button elegir;
        private System.Windows.Forms.DataGridView elegirDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}