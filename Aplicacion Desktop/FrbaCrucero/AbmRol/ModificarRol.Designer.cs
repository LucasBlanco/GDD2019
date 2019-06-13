namespace FrbaCrucero.AbmRol
{
    partial class ModificarRol
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
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Funcionalidades:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 51);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 51);
            this.button1.TabIndex = 10;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // funcionalidades
            // 
            this.funcionalidades.FormattingEnabled = true;
            this.funcionalidades.Items.AddRange(new object[] {
            "funcionalidad1",
            "funcionalidad2"});
            this.funcionalidades.Location = new System.Drawing.Point(88, 224);
            this.funcionalidades.Name = "funcionalidades";
            this.funcionalidades.Size = new System.Drawing.Size(653, 316);
            this.funcionalidades.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(257, 90);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(432, 29);
            this.nombre.TabIndex = 7;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 718);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.funcionalidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombre);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox funcionalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombre;
    }
}