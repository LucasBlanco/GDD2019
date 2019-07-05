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
        string fechaInicio;
        string fechaFin;
        public ReprogramarPasajeFueraDeServicio(int id, string inicio, string fin)
        {
            
            idCrucero = id;
            fechaInicio = inicio;
            fechaFin = fin;
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            cantDias.Minimum = (Convert.ToDateTime(this.fechaFin) - Convert.ToDateTime(this.fechaInicio)).Days;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.postergarViajesDeCrucero", conexion);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                cmd.Parameters.Add(new SqlParameter("@cantDias", Funciones.toInt(cantDias.Text)));
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", Convert.ToDateTime(this.fechaInicio).ToString("dd-MM-yyyy")));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", Convert.ToDateTime(this.fechaFin).ToString("dd-MM-yyyy")));

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se han reprogramado los pasajes con exito", "Exito!");
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
