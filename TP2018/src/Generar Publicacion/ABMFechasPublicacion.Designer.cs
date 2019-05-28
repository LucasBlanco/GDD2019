namespace PalcoNet.Generar_Publicacion
{
    partial class ABMFechasPublicacion
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
            this.guardarCambiosBTN = new System.Windows.Forms.Button();
            this.guardarFechasBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaDP = new System.Windows.Forms.DateTimePicker();
            this.fechasDGV = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechasDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione una fecha para modificarla";
            // 
            // guardarCambiosBTN
            // 
            this.guardarCambiosBTN.Location = new System.Drawing.Point(253, 459);
            this.guardarCambiosBTN.Name = "guardarCambiosBTN";
            this.guardarCambiosBTN.Size = new System.Drawing.Size(100, 23);
            this.guardarCambiosBTN.TabIndex = 2;
            this.guardarCambiosBTN.Text = "Guardar Cambios";
            this.guardarCambiosBTN.UseVisualStyleBackColor = true;
            this.guardarCambiosBTN.Click += new System.EventHandler(this.guardarCambiosBTN_Click);
            // 
            // guardarFechasBTN
            // 
            this.guardarFechasBTN.Location = new System.Drawing.Point(187, 61);
            this.guardarFechasBTN.Name = "guardarFechasBTN";
            this.guardarFechasBTN.Size = new System.Drawing.Size(100, 23);
            this.guardarFechasBTN.TabIndex = 5;
            this.guardarFechasBTN.Text = "Guardar Fecha";
            this.guardarFechasBTN.UseVisualStyleBackColor = true;
            this.guardarFechasBTN.Click += new System.EventHandler(this.guardarFechasBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechaDP);
            this.groupBox1.Controls.Add(this.guardarFechasBTN);
            this.groupBox1.Location = new System.Drawing.Point(21, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // fechaDP
            // 
            this.fechaDP.CustomFormat = "HH:mm dd/MM/yyyy";
            this.fechaDP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaDP.Location = new System.Drawing.Point(47, 19);
            this.fechaDP.Name = "fechaDP";
            this.fechaDP.Size = new System.Drawing.Size(240, 20);
            this.fechaDP.TabIndex = 6;
            // 
            // fechasDGV
            // 
            this.fechasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fechasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha});
            this.fechasDGV.Location = new System.Drawing.Point(46, 38);
            this.fechasDGV.Name = "fechasDGV";
            this.fechasDGV.Size = new System.Drawing.Size(244, 267);
            this.fechasDGV.TabIndex = 10;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.Width = 200;
            // 
            // ABMFechasPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 492);
            this.Controls.Add(this.fechasDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guardarCambiosBTN);
            this.Controls.Add(this.label1);
            this.Name = "ABMFechasPublicacion";
            this.Text = "ABMFechasPublicacion";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fechasDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardarCambiosBTN;
        private System.Windows.Forms.Button guardarFechasBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fechaDP;
        private System.Windows.Forms.DataGridView fechasDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}