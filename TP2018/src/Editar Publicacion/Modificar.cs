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
using System.Text.RegularExpressions;

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarPublicacion : Form
    {
        private List<Generar_Publicacion.Ubicacion> ubicaciones;
        private List<DateTime> fechasEspectaculo;
        SqlConnection conexion;
        string id_empresa;
        string id_usuario;
        string id_publicacion;
        string estado_publicacion;
        DataGridView tabla;
        public EditarPublicacion(DataGridViewRow dgvr, string id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            Funciones.CargarComboBox(grados, "select id, concat('Prioridad: ',prioridad, ', Comision: ',comision ) as detalle from Grado_publicacion where estado is null", "id", "detalle");
            Funciones.CargarComboBox(rubros, "select codigo, descripcion from Rubro", "codigo", "descripcion");
            Funciones.CargarComboBox(estadoCB, "select nombre, id from Publicacion_estado", "id", "nombre");
            estadoCB.SelectedValue = dgvr.Cells[9].Value.ToString();


            fecha_evento.MinDate = DateTime.Parse(Funciones.yesterday());

            this.ubicaciones = new List<Generar_Publicacion.Ubicacion>();
            fechasEspectaculo = new List<DateTime>();
            conexion = ConexionSQL.GetConexion();
            descripcion.Text = dgvr.Cells[3].Value.ToString();
            calle.Text = dgvr.Cells[4].Value.ToString();

            DateTime dt = (DateTime)dgvr.Cells[2].Value;
            fecha_evento.Text = dt.ToString("dd/MM/yyyy HH:mm");
            
            nro.Text = dgvr.Cells[5].Value.ToString();
            rubros.SelectedValue = dgvr.Cells[6].Value.ToString();
            grados.SelectedValue = dgvr.Cells[7].Value.ToString();
            this.id_publicacion = dgvr.Cells[8].Value.ToString();
            this.estado_publicacion = dgvr.Cells[9].Value.ToString();
            this.id_empresa = Funciones.GetStringFromQuery("select id from Empresa where id_usuario ="+id_usuario, "id");
            this.iniciarUbicaciones();
            if (estadoCB.SelectedValue.ToString() == "Publicada")
            {
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Visible = false;
                }
                estadoCB.Visible = true;
                estadoLbl.Visible = true;
                guardarBTN.Visible = true;
                nota.Visible = true;

                Funciones.CargarComboBox(estadoCB, "select nombre, id from Publicacion_estado where nombre <> 'Borrador'", "id", "nombre");

            }
        }

        private void gradoBTN_Click(object sender, EventArgs e)
        {
            
        }

        private void ubicacionesBTN_Click(object sender, EventArgs e)
        {
            Generar_Publicacion.ABMUbicaciones ubicacionesForm = new Generar_Publicacion.ABMUbicaciones(this.id_publicacion,ref ubicaciones);
            ubicacionesForm.ShowDialog();
        }

        private void rubroBTN_Click(object sender, EventArgs e)
        {
          
        }

        private void fechasBTN_Click(object sender, EventArgs e)
        {
        
        }

        private void limpiarBTN_Click(object sender, EventArgs e)
        {
            descripcion.Clear();
            calle.Clear();
            ubicaciones.Clear();
            fechasEspectaculo.Clear();
        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("modifPublicacion", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable ubicacionest = new DataTable();

                    ubicacionest.Columns.Add("fila");
                    ubicacionest.Columns.Add("asiento", typeof(int));
                    ubicacionest.Columns.Add("precio", typeof(int));
                    ubicacionest.Columns.Add("tipo_ubicacion", typeof(int));

                    ubicacionest.Columns.Add("descripcion");


                    foreach (Generar_Publicacion.Ubicacion ubi in ubicaciones)
                    {
                        DataRow dr = ubicacionest.NewRow();
                        dr["fila"] = ubi.fila;
                        dr["asiento"] = ubi.asiento;
                        dr["precio"] = ubi.precio;
                        dr["tipo_ubicacion"] = ubi.tipo_nro;

                        dr["descripcion"] = ubi.tipo;
                        ubicacionest.Rows.Add(dr);
                    }

                    cmd.Parameters.Add(new SqlParameter("@fecha_evento", fecha_evento.Text));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_rubro", Funciones.getIdsCheckSeleccionadosCB(rubros)));
                    cmd.Parameters.Add(new SqlParameter("@calle", calle.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_calle", nro.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_grado", Funciones.getIdsCheckSeleccionadosCB(grados)));
                    cmd.Parameters.Add(new SqlParameter("@ubicaciones", ubicacionest));
                    cmd.Parameters.Add(new SqlParameter("@codigo", this.id_publicacion));
                    var tuvieja = Funciones.getIdsCheckSeleccionadosCB(estadoCB);
                    cmd.Parameters.Add(new SqlParameter("@estado", Funciones.getIdsCheckSeleccionadosCB(estadoCB)));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    this.Hide();
                    MessageBox.Show("La publicacion fue modificada con exito", "Exito!");
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
            return (checkCamposVacios() && checkCamposNumericos());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { nro };
            Regex nonNumericRegex = new Regex(@"\D");

            foreach (TextBox t in textBoxes)
            {
                if (nonNumericRegex.IsMatch(t.Text))
                {
                    MessageBox.Show("El campo " + t.Name + " debe ser numerico");
                    return false;
                }
            }
            return true;

        }

        private bool checkCamposVacios()
        {
            if (nro.Text != string.Empty && calle.Text != string.Empty && descripcion.Text != string.Empty && ubicaciones.Count > 0 && Funciones.hayCheckSeleccionadoCB(grados))
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void iniciarUbicaciones() {
            DataTable dt = new DataTable();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Ubicacion where id_publicacion=" + this.id_publicacion, conexion);
            da.Fill(dt);
            conexion.Close();
            List<DataRow> list = dt.AsEnumerable().ToList();
            foreach (var row in list)
            {
                Generar_Publicacion.Ubicacion item = new Generar_Publicacion.Ubicacion(row["fila"].ToString(), Int32.Parse(row["asiento"].ToString()), Int32.Parse(row["precio"].ToString()),row["descripcion"].ToString(), Int32.Parse(row["tipo_ubicacion"].ToString()));
                this.ubicaciones.Add(item);
            }
            
        }

        
    }
}
