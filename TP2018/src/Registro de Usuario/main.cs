using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text != string.Empty || password.Text != string.Empty)
            {
                new AltaCliente(username.Text, password.Text, this).ShowDialog();
            }
            else
            {
                MessageBox.Show("Ingreso un usuario y contraseña para continuar");
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (username.Text != string.Empty || password.Text != string.Empty)
            {
            new AltaEmpresa(username.Text, password.Text, this).ShowDialog();
            }
            else
            {
                MessageBox.Show("Ingreso un usuario y contraseña para continuar");
            }
        }
    }
}
