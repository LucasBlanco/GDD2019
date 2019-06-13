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
namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViaje : Form
    {
        SqlConnection conexion;
        public GenerarViaje()
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            Funciones.CargarComboBox(cmbCruceros, "select id, nombre from Crucero", "id", "nombre");
            Funciones.CargarComboBox(cmbRecorrido, "select id, codigo from Recorrido", "id", "codigo");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (satisfiesControls()) {
                try { 
                    SqlCommand cmd = new SqlCommand("altaViaje", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@idCrucero",  cmbCruceros.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@idRecorrido", cmbRecorrido.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", dtPickerInicio.Value));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", dtPickerFin.Value));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El viaje fue creado con exito", "Exito!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();
                }
            }

        }

        private bool satisfiesControls()
        {
            if ((cmbCruceros.Text != string.Empty) && (cmbRecorrido.Text != string.Empty) && (dtPickerInicio.Text != string.Empty) && (dtPickerFin.Text != string.Empty))
            {
                DateTime currentDateTime = DateTime.Now;
                if (dtPickerInicio.Value < dtPickerFin.Value && dtPickerInicio.Value >= currentDateTime)
                {
                    return true;
                }
                else {
                    MessageBox.Show("La fecha de inicio tiene que ser posterior a hoy y la fecha de fin posterior a la de inicio");
                }
            }
            else {
                MessageBox.Show("Tienes que completar todos los campos");
            }
            return false;
        }

    }
}
