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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class BusquedaBorrarRecorrido : Form
    {
        SqlConnection conexion;
        string QUERY = "select puerto_inicio.nombre inicio, puerto_destino.nombre destino, codigo, SEGUNDA_VUELTA.precioRecorrido(rec.id) as precio, case when rec.inhabilitado = 0 then 'No' else 'Si' end inhabilitado, rec.id from SEGUNDA_VUELTA.Recorrido rec join SEGUNDA_VUELTA.Puerto puerto_inicio on rec.inicio = puerto_inicio.id join SEGUNDA_VUELTA.Puerto puerto_destino on rec.destino = puerto_destino.id";
        public BusquedaBorrarRecorrido()
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            Funciones.CargarDataGridView(recorridosDGW, QUERY );
            Funciones.CargarComboBox(filtroInicio, "select id, nombre from SEGUNDA_VUELTA.Puerto", "id", "nombre");
            Funciones.CargarComboBox(filtroDestino, "select id, nombre from SEGUNDA_VUELTA.Puerto", "id", "nombre");
            recorridosDGW.AllowUserToAddRows = false;
            recorridosDGW.Columns["id"].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filtroInicio.SelectionLength = 0;
            filtroDestino.SelectionLength = 0;
            filtroCodigo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String filters = "";

            filters = Funciones.agregarFiltroAQuery(filters, "inicio", filtroInicio.SelectedValue.ToString(), "=");
            filters = Funciones.agregarFiltroAQuery(filters, "destino", filtroDestino.SelectedValue.ToString(), "=");
            if (filtroCodigo.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "codigo", filtroCodigo.Text, null, "or");
            }
            ConexionSQL.CargarDataGridView(recorridosDGW, QUERY + (filters.Length > 0 ? (" where " + filters) : null));
            recorridosDGW.Update();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (recorridosDGW.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dgvr = recorridosDGW.SelectedRows[0];
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("delete from SEGUNDA_VUELTA.Recorrido where id = " + dgvr.Cells[dgvr.Cells.Count - 1].Value.ToString(), conexion);

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se ha inhabilitado el recorrido con exito", "Exito!");
                    ConexionSQL.CargarDataGridView(recorridosDGW, QUERY);
                    recorridosDGW.Update();
                }

                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();

                }
            }
            else
                MessageBox.Show("Elija una fila antes de borrar");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (recorridosDGW.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = recorridosDGW.SelectedRows[0];
                new AbmRecorrido.ModificarRecorrido(dgvr).ShowDialog();
                ConexionSQL.CargarDataGridView(recorridosDGW, QUERY);
                recorridosDGW.Update();
            }
            else
                MessageBox.Show("Elija una fila antes de modificar");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (recorridosDGW.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dgvr = recorridosDGW.SelectedRows[0];
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("update SEGUNDA_VUELTA.Recorrido set inhabilitado = 0 where id = " + dgvr.Cells[dgvr.Cells.Count - 1].Value.ToString(), conexion);

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se ha habilitado el recorrido con exito", "Exito!");
                    ConexionSQL.CargarDataGridView(recorridosDGW, QUERY);
                    recorridosDGW.Update();
                }

                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();

                }
            }
            else
                MessageBox.Show("Elija una fila antes de habilitar");
        }
    }
}
