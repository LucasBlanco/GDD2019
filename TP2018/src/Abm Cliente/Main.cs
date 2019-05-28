using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void altaBTN_Click(object sender, EventArgs e)
        {
            AltaCliente altaForm = new AltaCliente();
            altaForm.ShowDialog();
        }

        private void modificarBorrarBTN_Click(object sender, EventArgs e)
        {
            BusquedaBorrarCliente busquedaBorrarCliente = new BusquedaBorrarCliente();
            busquedaBorrarCliente.ShowDialog();
        }
    }
}
