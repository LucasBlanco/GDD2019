using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearRol alta = new CrearRol();
            alta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusquedaBorrarRol modif = new BusquedaBorrarRol();
            modif.ShowDialog();
        }
    }
}
