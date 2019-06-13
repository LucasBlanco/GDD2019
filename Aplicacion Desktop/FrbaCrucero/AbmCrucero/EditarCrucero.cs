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
    public partial class EditarCrucero : Form
    {
        SqlConnection conexion;
        int idCrucero;
        public EditarCrucero(DataGridViewRow cruceroR)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarComboBox(marca, "select id, nombre as detalle from Marca_Crucero", "id", "detalle");
            marca.SelectedValue = cruceroR.Cells["id_marca"].Value.ToString();
            modelo.Text = cruceroR.Cells["modelo"].Value.ToString();
            crucero.Text = cruceroR.Cells["nombre"].Value.ToString();
            identificador.Text = cruceroR.Cells["identificador"].Value.ToString();
            this.idCrucero = Funciones.toInt(cruceroR.Cells["id"].Value.ToString());


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("modificacionCrucero", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure


                    cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                    cmd.Parameters.Add(new SqlParameter("@nombre", crucero.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_marca", marca.SelectedValue.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@identificador", identificador.Text));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El crucero fue modificado con exito", "Exito!");
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
            if (crucero.Text != string.Empty && modelo.Text != string.Empty && identificador.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }
    }
}
