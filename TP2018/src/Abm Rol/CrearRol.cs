using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class CrearRol : Form
    {
        SqlConnection conexion;
        public CrearRol()
        {
            InitializeComponent();

            Funciones.CargarCheckboxList(funcionalidades, "select * from Funcionalidad", "id", "nombre");
            conexion = ConexionSQL.GetConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaRol", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(int));
                    List<object> ids = Funciones.getIdsCheckSeleccionados(funcionalidades, "id");
                    foreach( object id in ids){
                        DataRow dr = dataTable.NewRow();
                        dr["id"] = id;
                        dataTable.Rows.Add(dr);
                    }
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@ids", dataTable));
                    
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El alta del rol se ha realizado con exito", "Exito!");
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 50000)
                        MessageBox.Show("Error: Ya existe rol con ese nombre");
                    else
                        MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();


                }

            }
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() );
        }

        private bool checkCamposVacios()
        {
            if (nombre.Text != string.Empty)
            {
                if(funcionalidades.CheckedItems.Count > 0)
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            for (int i = 0; i < funcionalidades.Items.Count; i++)
            {
                funcionalidades.SetItemChecked(i, false);
            }
        }

        private void funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
