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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class BusquedaBorrarEmpresa : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT razon_social as 'razon social', mail, telefono, calle, nro_calle as nro, nro_piso as piso, dpto, localidad, codigo_postal as 'codigo postal', ciudad, cuit, fecha_creacion as 'fecha creacion', estado, id  FROM Empresa";

        public BusquedaBorrarEmpresa()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            dt = ConexionSQL.CargarDataGridView(empresas, QUERY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( empresas.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = empresas.SelectedRows[0];
                ModificarEmpresa modificarForm = new ModificarEmpresa(dgvr);
                modificarForm.ShowDialog();
                Funciones.CargarDataGridView(empresas, QUERY);
                empresas.Update();
            }
            else 
                MessageBox.Show("Elija una fila antes de modificar");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (empresas.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = empresas.SelectedRows[0];
                string idEmpresa = dgvr.Cells[13].Value.ToString();

                try
                {
                    SqlCommand cmd = new SqlCommand("update Empresa set estado = 'inhabilitado' where id = " + idEmpresa, conexion);


                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                    Funciones.CargarDataGridView(empresas, QUERY);
                    empresas.Update();
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

        private void button3_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (razon_social.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "razon_social", razon_social.Text);
            }
            if (mail.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "mail", mail.Text);
            }
            if (cuit.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "cuit", cuit.Text);
            }
            dt = ConexionSQL.CargarDataGridView(empresas, QUERY + (filters.Length > 0 ? (" WHERE " + filters) : null));
            empresas.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            razon_social.Clear();
            mail.Clear();
            cuit.Clear();
        }

  
    }
}
