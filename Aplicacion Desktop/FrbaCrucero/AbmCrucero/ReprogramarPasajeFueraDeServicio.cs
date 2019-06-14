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
    public partial class ReprogramarPasajeFueraDeServicio : Form
    {
        SqlConnection conexion;
        int idCrucero;
        public ReprogramarPasajeFueraDeServicio(int id)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                SqlCommand cmd = new SqlCommand("postergarViajesDeCrucero", conexion);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                cmd.Parameters.Add(new SqlParameter("@cantDias", Funciones.toInt(cantDias.Text)));

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se han reprogramado los pasajes con exito", "Exito!");
            }
        }

        public bool satisfiesControls()
        {
            return (checkCamposVacios());
        }

        private bool checkCamposVacios()
        {
            int parsedValue;
            if (cantDias.Text != string.Empty && int.TryParse(cantDias.Text, out parsedValue))
            {
                return true;
            }
            MessageBox.Show("Complete el campo cantidad de dias. Debe ser numerico");
            return false;
        }
    }
}
