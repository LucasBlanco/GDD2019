namespace FrbaCrucero.AbmCrucero
{
    partial class ReprogramarPasajeFueraDeServicio
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
            this.cantDias = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cantDias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° dias";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reprogramar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cantDias
            // 
            this.cantDias.Location = new System.Drawing.Point(78, 30);
            this.cantDias.Name = "cantDias";
            this.cantDias.Size = new System.Drawing.Size(90, 20);
            this.cantDias.TabIndex = 3;
            // 
            // ReprogramarPasajeFueraDeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 108);
            this.Controls.Add(this.cantDias);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "ReprogramarPasajeFueraDeServicio";
            this.Text = "ReprogramarPasajeFueraDeServicio";
            ((System.ComponentModel.ISupportInitialize)(this.cantDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown cantDias;
    }
}