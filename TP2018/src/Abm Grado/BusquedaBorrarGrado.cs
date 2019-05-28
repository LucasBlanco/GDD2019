using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class BusquedaBorrarGrado : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT * FROM Grado_publicacion";

        public BusquedaBorrarGrado()
        {
            InitializeComponent();

            conexion = ConexionSQL.GetConexion();
            dt = ConexionSQL.CargarDataGridView(grados, QUERY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grados.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = grados.SelectedRows[0];
                ModificarGrado modificarForm = new ModificarGrado(dgvr);
                modificarForm.ShowDialog();
                ConexionSQL.CargarDataGridView(grados, QUERY);
                grados.Update();
            } else
                MessageBox.Show("Elija una fila antes de modificar");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grados.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dgvr = grados.SelectedRows[0];
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("update Grado_publicacion set estado = " + "'inhabilitado'" + " where id = " + dgvr.Cells[3].Value.ToString(), conexion);

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se ha inhabilitado el grado con exito", "Exito!");
                    ConexionSQL.CargarDataGridView(grados, QUERY);
                    grados.Update();
                }

                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();

                }
            } else
                MessageBox.Show("Elija una fila antes de borrar");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (prioridad.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "prioridad", prioridad.Text);
            }
            if (comision.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "comision", comision.Text);
            }

            dt = ConexionSQL.CargarDataGridView(grados, QUERY + (filters.Length > 0 ? (" WHERE " + filters) : null));
            grados.Update();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prioridad.Clear();
            comision.Clear();
        }

  
    }
}
