using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class TablaCrucero : Form
    {
        System.Data.SqlClient.SqlConnection conexion;
        String QUERY;
        string fecha;

        public TablaCrucero(string fecha)
        {
            InitializeComponent();
            QUERY = "SELECT Crucero.nombre, Crucero.modelo, Crucero.identificador, Marca_Crucero.nombre as marca, Crucero.fecha_alta, Crucero.id, Marca_Crucero.id as id_marca  FROM Crucero join Marca_Crucero on Marca_Crucero.id = Crucero.id_marca";
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarDataGridView(cruceros, QUERY);
            cruceros.Columns["id"].Visible = false;
            cruceros.Columns["id_marca"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cruceros.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = cruceros.SelectedRows[0];
                new EditarCrucero(dgvr).ShowDialog();
                Funciones.CargarDataGridView(cruceros, QUERY);
                //rolesDGW.Columns[2].Visible = false;
                cruceros.Update();
            }
            else
                MessageBox.Show("Elija una fila antes de modificar");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cruceros.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = cruceros.SelectedRows[0];
                new FueraDeServicio(Funciones.toInt(dgvr.Cells["id"].Value.ToString())).ShowDialog();
                Funciones.CargarDataGridView(cruceros, QUERY);
                //rolesDGW.Columns[2].Visible = false;
                cruceros.Update();
            }
            else
                MessageBox.Show("Elija una fila antes de modificar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cruceros.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = cruceros.SelectedRows[0];
                new TerminoVidaUtil(Funciones.toInt(dgvr.Cells["id"].Value.ToString())).ShowDialog();
                Funciones.CargarDataGridView(cruceros, QUERY);
                //rolesDGW.Columns[2].Visible = false;
                cruceros.Update();
            }
            else
                MessageBox.Show("Elija una fila antes de modificar");
        }
    }
}
