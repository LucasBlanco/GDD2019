namespace PalcoNet.Generar_Publicacion
{
    partial class PickGrado
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
            this.elegirDGV = new System.Windows.Forms.DataGridView();
            this.elegir = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.elegirDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // elegirDGV
            // 
            this.elegirDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elegirDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.comision,
            this.prioridad});
            this.elegirDGV.Location = new System.Drawing.Point(38, 33);
            this.elegirDGV.Name = "elegirDGV";
            this.elegirDGV.Size = new System.Drawing.Size(343, 150);
            this.elegirDGV.TabIndex = 0;
            // 
            // elegir
            // 
            this.elegir.Location = new System.Drawing.Point(271, 259);
            this.elegir.Name = "elegir";
            this.elegir.Size = new System.Drawing.Size(110, 34);
            this.elegir.TabIndex = 1;
            this.elegir.Text = "Elegir";
            this.elegir.UseVisualStyleBackColor = true;
            this.elegir.Click += new System.EventHandler(this.elegir_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // comision
            // 
            this.comision.DataPropertyName = "comision";
            this.comision.HeaderText = "comision";
            this.comision.Name = "comision";
            // 
            // prioridad
            // 
            this.prioridad.DataPropertyName = "prioridad";
            this.prioridad.HeaderText = "prioridad";
            this.prioridad.Name = "prioridad";
            // 
            // PickGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 322);
            this.Controls.Add(this.elegir);
            this.Controls.Add(this.elegirDGV);
            this.Name = "PickGrado";
            this.Text = "Elegir un Grado";
            ((System.ComponentModel.ISupportInitialize)(this.elegirDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView elegirDGV;
        private System.Windows.Forms.Button elegir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridad;
    }
}