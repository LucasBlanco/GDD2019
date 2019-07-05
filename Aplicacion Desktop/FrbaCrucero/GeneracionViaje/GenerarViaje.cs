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
            dtPickerInicio.MinDate = Funciones.fechaConfig();
            
            Funciones.CargarComboBox(cmbCruceros, query(), "id", "nombre");
            cmbCruceros.Text = "";
            Funciones.CargarComboBox(cmbRecorrido, "select rec.id id, concat('codigo: ', rec.codigo, ', inicio: ', pr_inicio.nombre, ', destino: ',pr_destino.nombre) codigo from SEGUNDA_VUELTA.Recorrido rec join SEGUNDA_VUELTA.Puerto pr_inicio on rec.inicio = pr_inicio.id join SEGUNDA_VUELTA.Puerto pr_destino on rec.destino = pr_destino.id", "id", "codigo");
        }

        private string query() {
            return "select id, identificador as nombre from SEGUNDA_VUELTA.Crucero cru where cru.id in (select id from SEGUNDA_VUELTA.crucerosDisponibles('" + Convert.ToDateTime(dtPickerInicio.Value).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dtPickerFin.Value).ToString("yyyy-MM-dd") + "'))";
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (satisfiesControls()) {
                try {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.altaViaje", conexion);

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
                    Funciones.CargarComboBox(cmbCruceros, query(), "id", "nombre");
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
                return true;
            }
            else {
                MessageBox.Show("Tienes que completar todos los campos");
            }
            return false;
        }

        private void dtPickerFin_ValueChanged(object sender, EventArgs e)
        {
            Funciones.CargarComboBox(cmbCruceros, query(), "id", "nombre");
            cmbCruceros.Text = "";
        }

        private void dtPickerInicio_ValueChanged(object sender, EventArgs e)
        {
            dtPickerFin.MinDate = Convert.ToDateTime(dtPickerInicio.Text);
            Funciones.CargarComboBox(cmbCruceros, query(), "id", "nombre");
            cmbCruceros.Text = "";
        }

    }
}
