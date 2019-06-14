namespace FrbaCrucero.AbmCrucero
{
    partial class EditarCrucero
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
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.marca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.identificador = new System.Windows.Forms.TextBox();
            this.modelo = new System.Windows.Forms.TextBox();
            this.crucero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Modificar crucero";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Marca:";
            // 
            // marca
            // 
            this.marca.FormattingEnabled = true;
            this.marca.Location = new System.Drawing.Point(118, 94);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(121, 21);
            this.marca.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Identificador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Modelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Crucero:";
            // 
            // identificador
            // 
            this.identificador.Location = new System.Drawing.Point(118, 68);
            this.identificador.Name = "identificador";
            this.identificador.Size = new System.Drawing.Size(100, 20);
            this.identificador.TabIndex = 23;
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(118, 42);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(100, 20);
            this.modelo.TabIndex = 22;
            // 
            // crucero
            // 
            this.crucero.Location = new System.Drawing.Point(118, 16);
            this.crucero.Name = "crucero";
            this.crucero.Size = new System.Drawing.Size(100, 20);
            this.crucero.TabIndex = 21;
            // 
            // EditarCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 187);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.identificador);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.crucero);
            this.Name = "EditarCrucero";
            this.Text = "EditarCrucero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox marca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox identificador;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.TextBox crucero;
    }
}