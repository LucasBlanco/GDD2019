namespace FrbaCrucero.AbmCrucero
{
    partial class TerminoVidaUtil
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fechaBaja = new System.Windows.Forms.DateTimePicker();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancelar pasajes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(156, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Buscar reemplazante";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fechaBaja
            // 
            this.fechaBaja.Location = new System.Drawing.Point(93, 20);
            this.fechaBaja.Name = "fechaBaja";
            this.fechaBaja.Size = new System.Drawing.Size(200, 20);
            this.fechaBaja.TabIndex = 2;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(28, 26);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(60, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Fecha baja";
            // 
            // TerminoVidaUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 106);
            this.Controls.Add(this.label);
            this.Controls.Add(this.fechaBaja);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TerminoVidaUtil";
            this.Text = "TerminoVidaUtil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker fechaBaja;
        private System.Windows.Forms.Label label;
    }
}