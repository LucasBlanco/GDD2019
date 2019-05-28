using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Canje_Puntos
{
    public partial class Main : Form
    {
        //string id_cliente ;
        string puntos;
        string id_usuario;
        string id_cliente;
        public Main(string id_user)
        {
            InitializeComponent();
            SqlConnection conexion = ConexionSQL.GetConexion();
            this.id_usuario = id_user;
            this.id_cliente =  Funciones.GetStringFromQuery("select id from Cliente where id_usuario = " + id_user, "id");
            if (this.id_cliente == null)
            {
                MessageBox.Show("El usuario no tiene un cliente asociado y por lo tanto no tiene puntos disponibles");
                return;
            }
            puntos = Funciones.GetStringFromQuery("select dbo.calcularPuntos(" + this.id_cliente + ", "+ Funciones.today() +" ) as total", "total");
            Funciones.CargarDataGridView(productos, "select descripcion, puntos, id from Premio where puntos <= " + puntos.Replace(",", "."));
            total.Text = puntos;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productos.SelectedRows.Count >0)
            {

                try
                {
                    string id_premio = productos.SelectedRows[0].Cells[2].Value.ToString();
                    string cantidad = productos.SelectedRows[0].Cells[1].Value.ToString();
                    float resto = Funciones.toFloat(this.puntos) - Funciones.toFloat(cantidad);
                    total.Text = (resto).ToString();
                    SqlConnection conexion = ConexionSQL.GetConexion();
                    SqlCommand cmd = new SqlCommand("comprarPremio", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;         
                    cmd.Parameters.Add(new SqlParameter("@id_cliente", this.id_cliente));
                    cmd.Parameters.Add(new SqlParameter("@id_premio", id_premio));
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Los puntos se han canjeado con exito", "Exito!");
                    puntos = Funciones.GetStringFromQuery("select dbo.calcularPuntos(" + this.id_cliente + ", "+ Funciones.today() +" ) as total", "total");
                    Funciones.CargarDataGridView(productos, "select descripcion, puntos, id from Premio where puntos <= " + puntos.Replace(",", "."));
                    productos.Update();
                }

                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                }

            }
            else MessageBox.Show("Seleccione un producto para continuar");
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
