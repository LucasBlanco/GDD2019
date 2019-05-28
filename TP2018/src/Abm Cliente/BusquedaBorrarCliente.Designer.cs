namespace PalcoNet.Abm_Cliente
{
    partial class BusquedaBorrarCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limpiarFiltrosBTN = new System.Windows.Forms.Button();
            this.filtrarBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreTB = new System.Windows.Forms.TextBox();
            this.documentoTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.apellidoTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.borrarCliente = new System.Windows.Forms.Button();
            this.modificarClienteBTN = new System.Windows.Forms.Button();
            this.ClientesDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limpiarFiltrosBTN);
            this.groupBox1.Controls.Add(this.filtrarBTN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nombreTB);
            this.groupBox1.Controls.Add(this.documentoTB);
            this.groupBox1.Controls.Add(this.emailTB);
            this.groupBox1.Controls.Add(this.apellidoTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(45, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda Cliente";
            // 
            // limpiarFiltrosBTN
            // 
            this.limpiarFiltrosBTN.Location = new System.Drawing.Point(223, 128);
            this.limpiarFiltrosBTN.Name = "limpiarFiltrosBTN";
            this.limpiarFiltrosBTN.Size = new System.Drawing.Size(93, 23);
            this.limpiarFiltrosBTN.TabIndex = 10;
            this.limpiarFiltrosBTN.Text = "Limpiar Filtros";
            this.limpiarFiltrosBTN.UseVisualStyleBackColor = true;
            this.limpiarFiltrosBTN.Click += new System.EventHandler(this.limpiarFiltrosBTN_Click);
            // 
            // filtrarBTN
            // 
            this.filtrarBTN.Location = new System.Drawing.Point(342, 128);
            this.filtrarBTN.Name = "filtrarBTN";
            this.filtrarBTN.Size = new System.Drawing.Size(93, 23);
            this.filtrarBTN.TabIndex = 10;
            this.filtrarBTN.Text = "Filtrar";
            this.filtrarBTN.UseVisualStyleBackColor = true;
            this.filtrarBTN.Click += new System.EventHandler(this.filtrarBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email:";
            // 
            // nombreTB
            // 
            this.nombreTB.Location = new System.Drawing.Point(74, 29);
            this.nombreTB.Name = "nombreTB";
            this.nombreTB.Size = new System.Drawing.Size(130, 20);
            this.nombreTB.TabIndex = 1;
            // 
            // documentoTB
            // 
            this.documentoTB.Location = new System.Drawing.Point(74, 73);
            this.documentoTB.Name = "documentoTB";
            this.documentoTB.Size = new System.Drawing.Size(130, 20);
            this.documentoTB.TabIndex = 2;
            // 
            // emailTB
            // 
            this.emailTB.Location = new System.Drawing.Point(273, 73);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(130, 20);
            this.emailTB.TabIndex = 4;
            // 
            // apellidoTB
            // 
            this.apellidoTB.Location = new System.Drawing.Point(273, 29);
            this.apellidoTB.Name = "apellidoTB";
            this.apellidoTB.Size = new System.Drawing.Size(130, 20);
            this.apellidoTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // borrarCliente
            // 

            this.borrarCliente.Location = new System.Drawing.Point(365, 542);
            this.borrarCliente.Name = "borrarCliente";
            this.borrarCliente.Size = new System.Drawing.Size(131, 32);
            this.borrarCliente.TabIndex = 8;
            this.borrarCliente.Text = "Borrar Cliente";
            this.borrarCliente.UseVisualStyleBackColor = true;
            this.borrarCliente.Click += new System.EventHandler(this.borrarCliente_Click);

            // 
            // modificarClienteBTN
            // 
            this.modificarClienteBTN.Location = new System.Drawing.Point(45, 542);
            this.modificarClienteBTN.Name = "modificarClienteBTN";
            this.modificarClienteBTN.Size = new System.Drawing.Size(131, 32);
            this.modificarClienteBTN.TabIndex = 6;
            this.modificarClienteBTN.Text = "Modificar Cliente";
            this.modificarClienteBTN.UseVisualStyleBackColor = true;
            this.modificarClienteBTN.Click += new System.EventHandler(this.modificarClienteBTN_Click);
            // 
            // ClientesDGV
            // 
            this.ClientesDGV.AllowUserToAddRows = false;
            this.ClientesDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientesDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ClientesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientesDGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.ClientesDGV.Location = new System.Drawing.Point(45, 234);
            this.ClientesDGV.Name = "ClientesDGV";
            this.ClientesDGV.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientesDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ClientesDGV.Size = new System.Drawing.Size(451, 290);
            this.ClientesDGV.TabIndex = 9;
            // 
            // BusquedaBorrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 598);
            this.Controls.Add(this.ClientesDGV);
            this.Controls.Add(this.modificarClienteBTN);
            this.Controls.Add(this.borrarCliente);
            this.Controls.Add(this.groupBox1);
            this.Name = "BusquedaBorrarCliente";
            this.Text = "Modificar o Borrar Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombreTB;
        private System.Windows.Forms.TextBox documentoTB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.TextBox apellidoTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button borrarCliente;
        private System.Windows.Forms.Button modificarClienteBTN;
        private System.Windows.Forms.DataGridView ClientesDGV;
        private System.Windows.Forms.Button limpiarFiltrosBTN;
        private System.Windows.Forms.Button filtrarBTN;
    }
}