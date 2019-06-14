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
    public partial class CancelarPasajesTerminoVidaUtil : Form
    {

        int idCrucero;
        SqlConnection conexion;
        String fecha;
        public CancelarPasajesTerminoVidaUtil(int id, String fecha)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            this.idCrucero = id;
            this.fecha = fecha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                SqlCommand cmd = new SqlCommand("completarVidaUtilCruceroYCancelarPasajes", conexion);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                cmd.Parameters.Add(new SqlParameter("@fecha", this.fecha));

                cmd.Parameters.Add(new SqlParameter("@motivo", motivo.Text));


                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Se han cancelado los pasajes con exito", "Exito!");
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
    }
}
