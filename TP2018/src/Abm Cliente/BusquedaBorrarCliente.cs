using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class BusquedaBorrarCliente : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT * FROM Cliente";
        public BusquedaBorrarCliente()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            dt=ConexionSQL.CargarDataGridView(ClientesDGV, QUERY);

        }


        private void modificarClienteBTN_Click(object sender, EventArgs e)
        {
            if (ClientesDGV.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dgvr = ClientesDGV.SelectedRows[0];
                    ModificarCliente modificarForm = new ModificarCliente(dgvr);
                    modificarForm.ShowDialog();
                    Funciones.CargarDataGridView(ClientesDGV, QUERY);
                    ClientesDGV.Update();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Debes seleccionar alguna fila");
                }
            } else
                MessageBox.Show("Debes seleccionar alguna fila");
        }


        private void borrarCliente_Click(object sender, EventArgs e)
        {
            if (ClientesDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = ClientesDGV.SelectedRows[0];
                int idCliente = (int)dgvr.Cells[18].Value;

                try
                {
                    SqlCommand cmd = new SqlCommand("bajaCliente", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@id", idCliente));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                    Funciones.CargarDataGridView(ClientesDGV, QUERY);
                    ClientesDGV.Update();

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();
                }
            } else
                MessageBox.Show("Debes seleccionar alguna fila");

            
        }

        private void limpiarFiltrosBTN_Click(object sender, EventArgs e)
        {
            nombreTB.Clear();
            apellidoTB.Clear();
            documentoTB.Clear();
            emailTB.Clear();
        }

        private void filtrarBTN_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (emailTB.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters,"mail",emailTB.Text);
            }
            if (apellidoTB.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "apellido", apellidoTB.Text);
            }
            if (nombreTB.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "nombre", nombreTB.Text);
            }
            if (documentoTB.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "documento", documentoTB.Text);
            }
            dt = ConexionSQL.CargarDataGridView(ClientesDGV, QUERY + (filters.Length > 0 ? (" WHERE " + filters) : null));
            ClientesDGV.Update();
            
        }

        

    }
}
