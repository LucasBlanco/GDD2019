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
            Funciones.CargarComboBox(filtro_marcaCB, "select id, nombre as detalle from Marca_Crucero", "id", "detalle");
            DataTable dtFO = (DataTable)filtro_marcaCB.DataSource;
            var nRow = dtFO.NewRow();
            nRow[0] = -1;
            nRow[1] = "Seleccionar";
            dtFO.Rows.InsertAt(nRow, 0);
            filtro_marcaCB.SelectedIndex = 0;
            filtro_marcaCB.Update();

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (filtro_marcaCB.SelectedValue.ToString() != "-1") {
                filters = Funciones.agregarFiltroAQuery(filters, "Crucero.id_marca", filtro_marcaCB.SelectedValue.ToString());
            }
            if (filtro_identificador.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "Crucero.identificador", filtro_identificador.Text);
            }
            if (filtro_modelo.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "Crucero.modelo", filtro_modelo.Text);
            }
            if (filtro_nombre.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "Crucero.nombre", filtro_nombre.Text);
            }
            ConexionSQL.CargarDataGridView(cruceros, QUERY + (filters.Length > 0 ? (" where " + filters) : null));
            cruceros.Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filtro_identificador.Text = "";
            filtro_marcaCB.SelectedIndex = 0;
            filtro_modelo.Text = "";
            filtro_nombre.Text = "";
        }
    }
}
