namespace FrbaCrucero.GeneracionViaje
{
    partial class GenerarViaje
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
            this.cmbCruceros = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickerInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPickerFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRecorrido = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCruceros
            // 
            this.cmbCruceros.FormattingEnabled = true;
            this.cmbCruceros.Location = new System.Drawing.Point(127, 104);
            this.cmbCruceros.Name = "cmbCruceros";
            this.cmbCruceros.Size = new System.Drawing.Size(358, 21);
            this.cmbCruceros.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crucero";
            // 
            // dtPickerInicio
            // 
            this.dtPickerInicio.Location = new System.Drawing.Point(127, 52);
            this.dtPickerInicio.Name = "dtPickerInicio";
            this.dtPickerInicio.Size = new System.Drawing.Size(358, 20);
            this.dtPickerInicio.TabIndex = 2;
            this.dtPickerInicio.ValueChanged += new System.EventHandler(this.dtPickerInicio_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha fin";
            // 
            // dtPickerFin
            // 
            this.dtPickerFin.Location = new System.Drawing.Point(127, 78);
            this.dtPickerFin.Name = "dtPickerFin";
            this.dtPickerFin.Size = new System.Drawing.Size(358, 20);
            this.dtPickerFin.TabIndex = 4;
            this.dtPickerFin.ValueChanged += new System.EventHandler(this.dtPickerFin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Recorrido";
            // 
            // cmbRecorrido
            // 
            this.cmbRecorrido.FormattingEnabled = true;
            this.cmbRecorrido.Location = new System.Drawing.Point(127, 131);
            this.cmbRecorrido.Name = "cmbRecorrido";
            this.cmbRecorrido.Size = new System.Drawing.Size(358, 21);
            this.cmbRecorrido.TabIndex = 6;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(410, 158);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // GenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 219);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRecorrido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtPickerFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPickerInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCruceros);
            this.Name = "GenerarViaje";
            this.Text = "Generar viaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCruceros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickerInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPickerFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRecorrido;
        private System.Windows.Forms.Button btnGenerar;
    }
}