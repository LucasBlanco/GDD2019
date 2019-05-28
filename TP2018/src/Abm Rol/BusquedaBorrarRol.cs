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

namespace PalcoNet.Abm_Rol
{
    public partial class BusquedaBorrarRol : Form
    {
        public BusquedaBorrarRol()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarDataGridView(tabla, "SELECT nombre, (case when estado is null then 'habilitado' else estado end), id FROM Rol");
            tabla.Columns[2].Visible = false;
        }
        SqlConnection conexion;


        private void button2_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = tabla.SelectedRows[0];
                ModificarRol modificarForm = new ModificarRol(dgvr);
                modificarForm.ShowDialog();
                Funciones.CargarDataGridView(tabla, "SELECT nombre, (case when estado is null then 'habilitado' else estado end), id FROM Rol");
                tabla.Columns[2].Visible = false;
                tabla.Update();
            } else
                MessageBox.Show("Elija una fila antes de modificar");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {

                DataGridViewRow dgvr = tabla.SelectedRows[0];
                int id = (int)dgvr.Cells[2].Value;

                try
                {
                    SqlCommand cmd = new SqlCommand("inhabilitarRol", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@idRol", id));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                    Funciones.CargarDataGridView(tabla, "SELECT nombre, (case when estado is null then 'habilitado' else estado end), id FROM Rol");
                    tabla.Update();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();

                }
            } else
                MessageBox.Show("Elija una fila antes de borrar");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nombre.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (nombre.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "nombre", nombre.Text);
            }
        
            ConexionSQL.CargarDataGridView(tabla, "Select * from Rol" + (filters.Length > 0 ? (" WHERE " + filters) : null));
            tabla.Update();
        }

  
    }
}
