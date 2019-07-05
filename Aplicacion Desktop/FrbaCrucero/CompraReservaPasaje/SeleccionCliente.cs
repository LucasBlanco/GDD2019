using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionCliente : Form
    {
        SqlConnection conexion;
        ReservaViaje reserva;
        public SeleccionCliente(string dni, ReservaViaje reserva)
        {
            this.reserva = reserva;
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            string query = @"select id, nombre, apellido, direccion, telefono, mail, fecha_nacimiento
                        from SEGUNDA_VUELTA.Cliente
                        where dni =" + dni;
            Funciones.CargarDataGridView(clientesDGW, query);
            clientesDGW.Columns["id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clientesDGW.SelectedRows.Count > 0)
            {
                string nombre = clientesDGW.SelectedRows[0].Cells["nombre"].Value.ToString();
                string apellido = clientesDGW.SelectedRows[0].Cells["apellido"].Value.ToString();
                string direccion = clientesDGW.SelectedRows[0].Cells["direccion"].Value.ToString();
                string mail = clientesDGW.SelectedRows[0].Cells["mail"].Value.ToString();
                string telefono = clientesDGW.SelectedRows[0].Cells["telefono"].Value.ToString();
                string nacimiento = clientesDGW.SelectedRows[0].Cells["fecha_nacimiento"].Value.ToString();
                string id = clientesDGW.SelectedRows[0].Cells["id"].Value.ToString();
                reserva.seleccionDni(nombre, apellido, direccion, mail, telefono, nacimiento, id);
            }
            else {
                MessageBox.Show("Seleccione un cliente");
            }
            
        }

    }
}
