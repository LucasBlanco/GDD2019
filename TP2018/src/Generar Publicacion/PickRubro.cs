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
    public partial class PickRubro : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT * from Rubro";
        private Rubro rubroElegido;

        public PickRubro(Rubro rubro)
        {
            InitializeComponent();
            rubroElegido = rubro;
            conexion = ConexionSQL.GetConexion();
            dt = ConexionSQL.CargarDataGridView(elegirDGV, QUERY);        
        }

        private void elegir_Click(object sender, EventArgs e)
        {
            int idElegido = (int) elegirDGV.CurrentRow.Cells["codigo"].Value;
            Console.WriteLine(idElegido);
            rubroElegido.rubroId = idElegido;
            this.Hide();
        }
    }
}
