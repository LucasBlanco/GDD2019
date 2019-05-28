using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class PickGrado : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT * from Grado_publicacion";
        private Grado gradoElegido;

        public PickGrado(Grado grado)
        {
            InitializeComponent();
            gradoElegido = grado;
            conexion = ConexionSQL.GetConexion();
            dt = ConexionSQL.CargarDataGridView(elegirDGV, QUERY);        
        }

        private void elegir_Click(object sender, EventArgs e)
        {
            int idElegido =(int) elegirDGV.CurrentRow.Cells["id"].Value;
            Console.WriteLine(idElegido);
            gradoElegido.gradoId = idElegido;
            this.Hide();
        }
    }
}
