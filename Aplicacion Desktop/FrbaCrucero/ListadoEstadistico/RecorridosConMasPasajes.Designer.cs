namespace FrbaCrucero.ListadoEstadistico
{
    partial class RecorridosConMasPasajes
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
            this.estadisticaDGW = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // estadisticaDGW
            // 
            this.estadisticaDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estadisticaDGW.Location = new System.Drawing.Point(12, 12);
            this.estadisticaDGW.Name = "estadisticaDGW";
            this.estadisticaDGW.Size = new System.Drawing.Size(438, 237);
            this.estadisticaDGW.TabIndex = 0;
            // 
            // RecorridosConMasPasajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.estadisticaDGW);
            this.Name = "RecorridosConMasPasajes";
            this.Text = "RecorridosConMasPasajes";
            ((System.ComponentModel.ISupportInitialize)(this.estadisticaDGW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView estadisticaDGW;
    }
}