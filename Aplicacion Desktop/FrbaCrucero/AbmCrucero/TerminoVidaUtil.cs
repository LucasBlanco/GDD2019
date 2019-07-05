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
    public partial class TerminoVidaUtil : Form
    {
        int idCrucero;
        SqlConnection conexion;

        public TerminoVidaUtil(int id)
        {
            conexion = ConexionSQL.GetConexion();

            this.idCrucero = id;
            InitializeComponent();
            fechaBaja.MinDate = Funciones.fechaConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CancelarPasajesTerminoVidaUtil(this.idCrucero, Convert.ToDateTime(fechaBaja.Value).ToString("dd-MM-yyyy")).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.completarVidaUtilCruceroYReprogramarPasajes", conexion);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
            cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(fechaBaja.Value).ToString("dd-MM-yyyy")));
            cmd.Parameters.Add(new SqlParameter("@cruceroReemplazante", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output;

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
            object hola = cmd.Parameters["@cruceroReemplazante"].Value;
            MessageBox.Show("Los viajes seran realizados por el crucero: " + hola.ToString(), "Exito!");
        }
            catch (SqlException ex)
                {
                    Funciones.handleSqlError(ex.Message.ToString(), "identificador");
                    
                    conexion.Close();
                }
        }
    }
}
