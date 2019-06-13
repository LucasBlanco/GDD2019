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
    public partial class AltaCrucero : Form
    {
        SqlConnection conexion;

        public AltaCrucero()
        {

            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarComboBox(tipo_servicio, "select id, nombre as detalle from Servicio", "id", "detalle");
            Funciones.CargarComboBox(marca, "select id, nombre as detalle from Servicio", "id", "detalle");

        }

        private void AltaCrucero_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cabinas.Rows.Add(tipo_servicio.SelectedValue.ToString(), numero.Text, piso.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaCrucero", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable cabinasDT = new DataTable();

                    cabinasDT.Columns.Add("id_servicio", typeof(int));
                    cabinasDT.Columns.Add("nro", typeof(int));
                    cabinasDT.Columns.Add("piso", typeof(int));

                    int i = 0;
                    foreach (DataGridViewRow cabina in cabinas.Rows)
                    {
                        DataRow dr = cabinasDT.NewRow();
                        dr["id_servicio"] = Funciones.toInt(cabina.Cells["id_servicio_dt"].ToString());
                        dr["piso"] = Funciones.toInt(cabina.Cells["piso_dt"].ToString());
                        dr["nro"] = Funciones.toInt(cabina.Cells["nro_dt"].ToString()); 
                        cabinasDT.Rows.Add(dr);
                    }

                    cmd.Parameters.Add(new SqlParameter("@nombre", crucero.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_marca", marca.SelectedValue.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fechaAlta", Convert.ToDateTime(fecha_alta.Value).ToString("dd-MM-yyyy")));
                    cmd.Parameters.Add(new SqlParameter("@cabinas", cabinasDT));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El recorrido fue creado con exito", "Exito!");
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
            return true;
        }

        class Cabina
        {
            public int id_servicio, nro, piso;
            public Cabina(int id_servicio, int nro, int piso)
            {
                this.id_servicio = id_servicio;
                this.nro = nro;
                this.piso = piso;
            }
        }
    }
}
