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

namespace FrbaCrucero.AbmRol
{
    public partial class CrearRol : Form
    {
        SqlConnection conexion;
        public CrearRol()
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            Funciones.CargarCheckboxList(funcionalidades, "select id, nombre from Funcionalidad", "id", "nombre");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaRol", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    List<object> ids = Funciones.getIdsCheckSeleccionados(funcionalidades, "id");
                    DataTable funcionalidadesDT = new DataTable();

                    funcionalidadesDT.Columns.Add("id", typeof(int));

                    foreach (object id in ids)
                    {
                        DataRow dr = funcionalidadesDT.NewRow();
                        dr["id"] = id;
                        funcionalidadesDT.Rows.Add(dr);
                    }

                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@ids", funcionalidadesDT));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El rol fue creado con exito", "Exito!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();
                }

            }
            
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkFuncionalidades());
        }

        private bool checkCamposVacios()
        {
            if (nombre.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private bool checkFuncionalidades()
        {

            if (funcionalidades.CheckedItems.Count > 0)
            {
                return true;
            }
            MessageBox.Show("Selecciona alguna funcionalidad");
            return false;
        }
    }
}
