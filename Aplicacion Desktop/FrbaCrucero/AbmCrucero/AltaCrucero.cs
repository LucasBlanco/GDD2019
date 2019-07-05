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
        string fecha;
        public AltaCrucero(string fecha)
        {

            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            Funciones.CargarComboBox(tipo_servicio, "select id, nombre as detalle from SEGUNDA_VUELTA.Servicio", "id", "detalle");
            Funciones.CargarComboBox(marca, "select id, nombre as detalle from SEGUNDA_VUELTA.Marca_Crucero", "id", "detalle");
            fecha_alta.MinDate = Funciones.fechaConfig();
            cabinas.Columns["id_servicio_verdadero"].Visible = true;

        }

        private void AltaCrucero_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in cabinas.Rows)
            {
                object _nro = row.Cells[1].Value;
                object _piso = row.Cells[2].Value;
                if (_nro != null && _piso != null) {
                    if (_nro.ToString() == numero.Text && _piso.ToString() == piso.Text)
                    {
                        MessageBox.Show("Ya ingreso una cabina con el mismo numero y piso");
                        return;
                    }
                }
            }
            if (checkCamposNumericos())
            {
                cabinas.Rows.Add(tipo_servicio.Text, numero.Text, piso.Text, tipo_servicio.SelectedValue.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.altaCrucero", conexion);

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
                            dr["a"] = Funciones.toInt(cabina.Cells["nro_dt"].Value.ToString());
                            dr["b"] = Funciones.toInt(cabina.Cells["piso_dt"].Value.ToString());

                            dr["c"] = Funciones.toInt(cabina.Cells["id_servicio_verdadero"].Value.ToString());

                            cabinasDT.Rows.Add(dr);
                        }
                    }

                    cmd.Parameters.Add(new SqlParameter("@nombre", crucero.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", modelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_marca", marca.SelectedValue.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fechaAlta", Convert.ToDateTime(fecha_alta.Value).ToString("dd-MM-yyyy")));
                    cmd.Parameters.Add(new SqlParameter("@cabinas", cabinasDT));
                    cmd.Parameters.Add(new SqlParameter("@identificador", identificador.Text));

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

        public bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCabinas() && checkCamposNumericos());
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

        private bool checkCabinas()
        {
            if (cabinas.Rows.Count > 1)
            {
                return true;
            }
            MessageBox.Show("Ingrese por lo menos una cabina");
            return false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (cabinas.SelectedRows.Count > 0)
            {
                try {
                 DataGridViewRow dgvr = cabinas.SelectedRows[0];
                cabinas.Rows.RemoveAt(dgvr.Index);
                cabinas.Update();
                }
                catch(Exception hola){
                }
               
            }
            else
                MessageBox.Show("Elija una cabina antes de borrar");
        }
    }
}
