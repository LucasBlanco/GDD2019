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

namespace PalcoNet
{
    public partial class Habilitar_usuario : Form
    {
        public Habilitar_usuario()
        {
            InitializeComponent();
            Funciones.CargarDataGridView(usuarios, "select username, (case when estado is null then 'habilitado' else estado end) from Usuario");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usuarios.SelectedRows.Count > 0)
            {
                try
                {
                    string username = usuarios.SelectedRows[0].Cells[0].Value.ToString();
                    SqlConnection conexion = ConexionSQL.GetConexion();
                    SqlCommand cmd = new SqlCommand("update Usuario set estado = null where username='" + username + "'", conexion);
                    cmd.CommandType = CommandType.Text;


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    usuarios.Update();
                    Funciones.CargarDataGridView(usuarios, "select username, (case when estado is null then 'habilitado' else estado end) from Usuario");
                    usuarios.Update();
                    MessageBox.Show("El usuario fue modificado con exito");
                }
                catch
                {
                    MessageBox.Show("Hubo un error al modificar el usuario");
                }
            }
            else
                MessageBox.Show("Elije un usuario antes de modificar");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usuarios.SelectedRows.Count > 0)
            {
                try
                {
                    string username = usuarios.SelectedRows[0].Cells[0].Value.ToString();
                    SqlConnection conexion = ConexionSQL.GetConexion();
                    SqlCommand cmd = new SqlCommand("update Usuario set estado = 'inhabilitado' where username='"+ username+"'", conexion);
                    cmd.CommandType = CommandType.Text;
                    
                    
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                   
                   Funciones.CargarDataGridView(usuarios, "select username, (case when estado is null then 'habilitado' else estado end) from Usuario");
                   usuarios.Update();
                    MessageBox.Show("El usuario fue modificado con exito");
                }
                catch {
                    MessageBox.Show("Hubo un error al modificar el usuario");
                }
            }
            else
                MessageBox.Show("Elije un usuario antes de modificar");

        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            String query = "select username, (case when estado is null then 'habilitado' else estado end) from Usuario";
            if (username.Text.Length > 0)
            {
                if (query.Contains("where"))
                {
                    query += " and";
                }
                else 
                {
                    query += " where";
                }
                query += " username like '"+ username.Text+"%'";
            }
            if (habilitado.Checked)
            {
                if (query.Contains("where"))
                {
                    query += " and";
                }
                else
                {
                    query += " where";
                }
                query += " estado is null";
            }
            if (inhabilitado.Checked)
            {
                if (query.Contains("where"))
                {
                    query += " and";
                }
                else
                {
                    query += " where";
                }
                query += " estado = 'inhabilitado'";
            }
            Funciones.CargarDataGridView(usuarios, query);
            usuarios.Update();
        }
    }
}
