namespace PalcoNet.Abm_Cliente
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
            this.altaBTN = new System.Windows.Forms.Button();
            this.modificarBorrarBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // altaBTN
            // 
            this.altaBTN.Location = new System.Drawing.Point(74, 42);
            this.altaBTN.Name = "altaBTN";
            this.altaBTN.Size = new System.Drawing.Size(189, 36);
            this.altaBTN.TabIndex = 0;
            this.altaBTN.Text = "Dar de alta Cliente";
            this.altaBTN.UseVisualStyleBackColor = true;
            this.altaBTN.Click += new System.EventHandler(this.altaBTN_Click);
            // 
            // modificarBorrarBTN
            // 
            this.modificarBorrarBTN.Location = new System.Drawing.Point(74, 122);
            this.modificarBorrarBTN.Name = "modificarBorrarBTN";
            this.modificarBorrarBTN.Size = new System.Drawing.Size(189, 39);
            this.modificarBorrarBTN.TabIndex = 1;
            this.modificarBorrarBTN.Text = "Modificar/Borrar Cliente";
            this.modificarBorrarBTN.UseVisualStyleBackColor = true;
            this.modificarBorrarBTN.Click += new System.EventHandler(this.modificarBorrarBTN_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 211);
            this.Controls.Add(this.modificarBorrarBTN);
            this.Controls.Add(this.altaBTN);
            this.Name = "Main";
            this.Text = "ABM Cliente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button altaBTN;
        private System.Windows.Forms.Button modificarBorrarBTN;
    }
}