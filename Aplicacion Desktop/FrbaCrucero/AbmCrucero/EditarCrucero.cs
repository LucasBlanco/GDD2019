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
    public partial class EditarCrucero : Form
    {
        SqlConnection conexion;
        int idCrucero;
        public EditarCrucero(DataGridViewRow cruceroR)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarComboBox(tipo_servicio, "select id, nombre as detalle from SEGUNDA_VUELTA.Servicio", "id", "detalle");
            Funciones.CargarComboBox(marca, "select id, nombre as detalle from SEGUNDA_VUELTA.Marca_Crucero", "id", "detalle");
            marca.SelectedValue = cruceroR.Cells["id_marca"].Value.ToString();
            modelo.Text = cruceroR.Cells["modelo"].Value.ToString();
            crucero.Text = cruceroR.Cells["nombre"].Value.ToString();
            identificador.Text = cruceroR.Cells["identificador"].Value.ToString();
            this.idCrucero = Funciones.toInt(cruceroR.Cells["id"].Value.ToString());
            Funciones.CargarDataGridView(cabinas, "select cab.id, cab.nro, cab.piso, srv.nombre as servicio, srv.id servicio_id from SEGUNDA_VUELTA.Cabina cab join SEGUNDA_VUELTA.Servicio srv on cab.id_servicio = srv.id where cab.borrada is null and cab.id_crucero =" + this.idCrucero);
            cabinas.Columns["id"].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.modificacionCrucero", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure


                    cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
                    cmd.Parameters.Add(new SqlParameter("@nombre", crucero.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_marca", marca.SelectedValue.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@identificador", identificador.Text));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El crucero fue modificado con exito", "Exito!");
                }
                catch (SqlException ex)
                {
                    Funciones.handleSqlError(ex.Message.ToString(), "identificador");
                    conexion.Close();
                }

            }
        }

        public bool satisfiesControls()
        {
            return (checkCamposVacios());
        }

        private bool checkCamposVacios()
        {
            if (crucero.Text != string.Empty && modelo.Text != string.Empty && identificador.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cabinas.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dgvr = cabinas.SelectedRows[0];
                    cabinas.Rows.RemoveAt(dgvr.Index);
                    cabinas.Update();
                }
                catch (Exception hola)
                {
                }

            }
            else
                MessageBox.Show("Elija una cabina antes de borrar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in cabinas.Rows)
            {
                object _nro = row.Cells[1].Value;
                object _piso = row.Cells[2].Value;
                if (_nro != null && _piso != null)
                {
                    if (_nro.ToString() == numero.Text && _piso.ToString() == piso.Text)
                    {
                        MessageBox.Show("Ya ingreso una cabina con el mismo numero y piso");
                        return;
                    }
                }
            }
            if (checkCamposNumericos())
            {

                DataTable dt = (DataTable)(cabinas.DataSource); 
                DataRow dr = dt.NewRow();
                dr["nro"] = numero.Text;
                dr["piso"] = piso.Text;
                dr["servicio"] = tipo_servicio.Text;
                dr["servicio_id"] = tipo_servicio.SelectedValue;
                dt.Rows.Add(dr);
                cabinas.DataSource = dt;
                cabinas.Update();
            }
        }

        public bool checkCamposNumericos()
        {
            int parsedValue;

            if (int.TryParse(numero.Text, out parsedValue) && int.TryParse(piso.Text, out parsedValue))
            {
                return true;
            }
            MessageBox.Show("Escriba los campos numericos correctamente");
            return false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.modificacionCrucero", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable cabinasDT = new DataTable();

                    cabinasDT.Columns.Add("a", typeof(int));
                    cabinasDT.Columns.Add("b", typeof(int));
                    cabinasDT.Columns.Add("c", typeof(int));

                    int i = 0;
                    foreach (DataGridViewRow cabina in cabinas.Rows)
                    {
                        if (cabina.Index != cabinas.Rows.Count - 1)
                        {
                            DataRow dr = cabinasDT.NewRow();
                            dr["a"] = Funciones.toInt(cabina.Cells["nro"].Value.ToString());
                            dr["b"] = Funciones.toInt(cabina.Cells["piso"].Value.ToString());

                            dr["c"] = Funciones.toInt(cabina.Cells["servicio_id"].Value.ToString());

                            cabinasDT.Rows.Add(dr);
                        }
                    }

                    cmd.Parameters.Add(new SqlParameter("@nombre", crucero.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_marca", marca.SelectedValue.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@cabinas", cabinasDT));
                    cmd.Parameters.Add(new SqlParameter("@identificador", identificador.Text));
                    cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El crucero fue creado con exito", "Exito!");
                }
                catch (SqlException ex)
                {
                    Funciones.handleSqlError(ex.Message.ToString(), "identificador");

                    conexion.Close();
                }

            }
        }
    }
}
