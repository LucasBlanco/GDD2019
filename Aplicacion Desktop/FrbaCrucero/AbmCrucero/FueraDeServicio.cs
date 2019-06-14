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
    public partial class FueraDeServicio : Form
    {
        SqlConnection conexion;
        int idCrucero;
        public FueraDeServicio(int id)
        {

            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            this.idCrucero = id;
            fecha_fin.MinDate = Funciones.fechaConfig();
            fecha_inicio.MinDate = Funciones.fechaConfig();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            new Cancelar(Convert.ToDateTime(fecha_inicio.Value).ToString("dd-MM-yyyy"), Convert.ToDateTime(fecha_fin.Value).ToString("dd-MM-yyyy"), this.idCrucero).ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ReprogramarPasajeFueraDeServicio(this.idCrucero).ShowDialog();

        }
    }
}
