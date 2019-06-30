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
    public partial class ModificarRol : Form
    {
        private String idRol;
        SqlConnection conexion;
        public ModificarRol(DataGridViewRow rol)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarCheckboxList(funcionalidades, "select * from Funcionalidad", "id", "nombre");
            nombre.Text = rol.Cells["nombre"].Value.ToString();
            this.idRol = rol.Cells["id"].Value.ToString();
            SqlCommand cmd = new SqlCommand("select id from Funcionalidad join Rol_funcionalidad on id = id_funcionalidad where id_rol=" + this.idRol, conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> ids = new List<string>();
            while (dr.Read())
            {
                ids.Add(dr["id"].ToString());
            }
            conexion.Close();
            foreach (string id in ids)
            {
                for (int i = 0; i < funcionalidades.Items.Count; i++)
                {
                    DataRowView oDataRowView = funcionalidades.Items[i] as DataRowView;
                    string sValue = "";

                    if (oDataRowView != null)
                    {
                        sValue = oDataRowView.Row.ItemArray[1].ToString() as string;
                        if (sValue == id)
                        {
                            funcionalidades.SetItemChecked(i, true);
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {

                    SqlCommand cmd = new SqlCommand("modificacionRol", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(int));
                    List<object> ids = Funciones.getIdsCheckSeleccionados(funcionalidades, "id");
                    foreach (object id in ids)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr["id"] = id;
                        dataTable.Rows.Add(dr);
                    }
                    cmd.Parameters.Add(new SqlParameter("@idRol", this.idRol));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@ids", dataTable));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("La modificacion del rol se ha realizado con exito", "Exito!");
                }

                catch (SqlException ex)
                {
                    Funciones.handleSqlError(ex.Message.ToString(), "nombre");
                    conexion.Close();

                }

            }
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios());
        }


        private bool checkCamposVacios()
        {
            if (nombre.Text != string.Empty)
            {
                if (funcionalidades.CheckedItems.Count > 0)
                    return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }
    }
}
