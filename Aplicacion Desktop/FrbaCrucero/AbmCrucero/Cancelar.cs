using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCrucero.AbmCrucero
{
    public partial class Cancelar : Form
    {
        String fechaInicio;
        String fechaFin;
        int idCrucero;
        SqlConnection conexion;

        public Cancelar(String fechaInicio, String fechaFin, int id)
        {
            InitializeComponent();
            this.fechaInicio = fechaInicio;
            conexion = ConexionSQL.GetConexion();
            this.fechaFin = fechaFin;
            this.idCrucero = id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.ponerEnFueraDeServicioCruceroYCancelarPasajes", conexion);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", this.fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", this.fechaFin));
                cmd.Parameters.Add(new SqlParameter("@motivo", motivo.Text));


                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se han cancelado los pasajes con exito", "Exito!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();
                }
            }
        }

        public bool satisfiesControls()
        {
            return (checkCamposVacios());
        }

        private bool checkCamposVacios()
        {
            if (motivo.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void Cancelar_Load(object sender, EventArgs e)
        {

        }

        private void motivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
