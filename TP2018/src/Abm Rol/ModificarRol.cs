﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ModificarRol : Form
    {
        private String idRol;
        SqlConnection conexion;

        public ModificarRol(DataGridViewRow dgvr)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarCheckboxList(funcionalidades, "select * from Funcionalidad", "id", "nombre");
            nombre.Text = dgvr.Cells[0].Value.ToString();
            habilitado.Checked = (dgvr.Cells[1].Value.ToString() == "habilitado");

            this.idRol = dgvr.Cells[2].Value.ToString();
            SqlCommand cmd = new SqlCommand("select id from Funcionalidad join Funcionalidad_rol on id = id_funcionalidad where id_rol=" + this.idRol, conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            List<string> ids = new List<string>();
            while (dr.Read())
            {
                ids.Add(dr["id"].ToString());
            }
            conexion.Close();
            foreach (string id in ids) {
                for (int i = 0; i < funcionalidades.Items.Count; i++)
                {
                    DataRowView oDataRowView = funcionalidades.Items[i] as DataRowView;
                    string sValue = "";

                    if (oDataRowView != null)
                    {
                        sValue = oDataRowView.Row.ItemArray[0].ToString() as string;
                        if (sValue == id)
                        {
                            funcionalidades.SetItemChecked(i, true);
                        }
                    }
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                   
                    SqlCommand cmd = new SqlCommand("ModifRol", conexion);

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
                    cmd.Parameters.AddWithValue("@estado", habilitado.Checked ? Convert.DBNull : "inhabilitado"); 

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("La modificacion del rol se ha realizado con exito", "Exito!");
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2601)
                        MessageBox.Show("Error: Ya existe rol con ese nombre");
                    else
                        MessageBox.Show("Error: " + ex.Message.ToString());
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
