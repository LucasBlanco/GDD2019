namespace FrbaCrucero.ListadoEstadistico
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
            this.anio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.primerSemestre = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.segundoSemestre = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.anio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(93, 30);
            this.anio.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(144, 20);
            this.anio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Semestre";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // primerSemestre
            // 
            this.primerSemestre.AutoSize = true;
            this.primerSemestre.Location = new System.Drawing.Point(108, 66);
            this.primerSemestre.Name = "primerSemestre";
            this.primerSemestre.Size = new System.Drawing.Size(60, 17);
            this.primerSemestre.TabIndex = 2;
            this.primerSemestre.TabStop = true;
            this.primerSemestre.Text = "Primero";
            this.primerSemestre.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.segundoSemestre);
            this.groupBox1.Controls.Add(this.primerSemestre);
            this.groupBox1.Controls.Add(this.anio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 103);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // segundoSemestre
            // 
            this.segundoSemestre.AutoSize = true;
            this.segundoSemestre.Location = new System.Drawing.Point(186, 66);
            this.segundoSemestre.Name = "segundoSemestre";
            this.segundoSemestre.Size = new System.Drawing.Size(68, 17);
            this.segundoSemestre.TabIndex = 3;
            this.segundoSemestre.TabStop = true;
            this.segundoSemestre.Text = "Segundo";
            this.segundoSemestre.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Recorridos con mas pasajes comprados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(355, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Recorridos con mas cabinas libres";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(25, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(355, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cruceros con mayor cantidad de dias fuera de servicio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 271);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.anio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown anio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton primerSemestre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton segundoSemestre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}