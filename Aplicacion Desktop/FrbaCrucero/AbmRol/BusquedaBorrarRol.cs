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

namespace FrbaCrucero.AbmRol
{
    public partial class BusquedaBorrarRol : Form
    {
        SqlConnection conexion;
        String QUERY;
        public BusquedaBorrarRol()
        {
            InitializeComponent();
            QUERY = "SELECT nombre, (case when inhabilitado = 1 then 'si' else 'no' end) inhabilitado, id FROM Rol";
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarDataGridView(rolesDGW, QUERY);
            rolesDGW.Columns["id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rolesDGW.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = rolesDGW.SelectedRows[0];
                new ModificarRol(dgvr).ShowDialog();
                Funciones.CargarDataGridView(rolesDGW, QUERY); 
                //rolesDGW.Columns[2].Visible = false;
                rolesDGW.Update();
            }
            else
                MessageBox.Show("Elija una fila antes de modificar");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rolesDGW.SelectedRows.Count > 0)
            {

                DataGridViewRow dgvr = rolesDGW.SelectedRows[0];
                int id = (int)dgvr.Cells[2].Value;

                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Rol where id ="+id, conexion);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                    Funciones.CargarDataGridView(rolesDGW, QUERY);
                    rolesDGW.Update();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();

                }
            }
            else
                MessageBox.Show("Elija una fila antes de borrar");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String filters = "";
            if (nombre.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "nombre", nombre.Text);
            }

            ConexionSQL.CargarDataGridView(rolesDGW, "Select nombre, (case when inhabilitado = 1 then 'si' else 'no' end) inhabilitado, id from Rol" + (filters.Length > 0 ? (" WHERE " + filters) : null));
            rolesDGW.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rolesDGW.SelectedRows.Count > 0)
            {

                DataGridViewRow dgvr = rolesDGW.SelectedRows[0];
                int id = (int)dgvr.Cells[2].Value;

                try
                {
                    SqlCommand cmd = new SqlCommand("update Rol set inhabilitado = 0 where id =" + id, conexion);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                    Funciones.CargarDataGridView(rolesDGW, QUERY);
                    rolesDGW.Update();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();

                }
            }
            else
                MessageBox.Show("Elija una fila antes de borrar");
        }
    }
}
