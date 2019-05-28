using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaGrado alta = new AltaGrado();
            alta.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusquedaBorrarGrado modif = new BusquedaBorrarGrado();
            modif.ShowDialog();
        }
    }
}
