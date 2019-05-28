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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class Main : Form
    {
        SqlConnection conexion;
        public Main()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (true)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaFactura", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dtGridSource = (DataTable)facturas.DataSource;
                    DataTable dt = new DataTable();

                    dt.Columns.Add("id");    
                    foreach (DataRow row in dtGridSource.Rows)
                    {
                        dt.Rows.Add(row["id"].ToString());
                    }
                    cmd.Parameters.Add(new SqlParameter("@compras", dt));
                    var tuvieja = Funciones.today();
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Las compras se han rendido exito", "Exito!");
                    Funciones.CargarDataGridView(facturas, "select * from traerComprasARendir(" + cantidad.Text + ")");
                    facturas.Update();
                }

                catch (SqlException ex)
                {

                        MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();


                }

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Funciones.CargarDataGridView(facturas, "select * from traerComprasARendir(" + cantidad.Text + ")");
        }
    }
}
