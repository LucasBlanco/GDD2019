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
    public partial class ABMFechasPublicacion : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT fecha_evento FROM Publicacion WHERE id_publicacion={0}";
        private List<DateTime> fechas;
        
        public ABMFechasPublicacion(String idPublicacion, List<DateTime> fechas)
        {
            InitializeComponent();
            this.fechas = fechas;
            fechaDP.MinDate = Funciones.fechaConfig();
            if (idPublicacion == null)
            {
                dt = new DataTable();
            }
            else
            {
                conexion = ConexionSQL.GetConexion();
                dt = ConexionSQL.CargarDataGridView(fechasDGV, String.Format(QUERY, idPublicacion));
            }

        }

        private void guardarFechasBTN_Click(object sender, EventArgs e)
        {
            if (fechasDGV.Rows.Count > 1)
            {
                int fila = fechasDGV.Rows.Count - 2 < 0 ? 0 : (fechasDGV.Rows.Count - 2);
                DateTime fechaUltimo = Convert.ToDateTime(fechasDGV.Rows[fila].Cells[0].Value.ToString());
                DateTime fechaNueva = Convert.ToDateTime(fechaDP.Text);



                if (fechaUltimo.CompareTo(fechaNueva) < 0)
                {
                    fechasDGV.Rows.Add(fechaDP.Value.ToString("HH:mm dd/MM/yyyy"));
                    fechas.Add(fechaDP.Value);
                }
                else
                    MessageBox.Show("Ingrese las fechas ordenadas");
            }
            else
            {
                fechasDGV.Rows.Add(fechaDP.Value.ToString("HH:mm dd/MM/yyyy"));
                fechas.Add(fechaDP.Value);
            }
        }

        private void guardarCambiosBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
