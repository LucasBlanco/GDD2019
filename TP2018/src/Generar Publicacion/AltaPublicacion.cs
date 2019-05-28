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

namespace PalcoNet.Generar_Publicacion
{
    public partial class AltaPublicacion : Form
    {
        private List<Ubicacion> ubicaciones;
        private List<DateTime> fechasEspectaculo;
        private Grado grado;
        private Rubro rubro;
        SqlConnection conexion;
        string id_usuario;
        string id_empresa;
        public AltaPublicacion(string id_usuario)
        {
            InitializeComponent();
            this.ubicaciones = new List<Ubicacion>();
            fechasEspectaculo = new List<DateTime>();
            Funciones.CargarComboBox(grados, "select id, concat('Prioridad: ',prioridad, ', Comision: ',comision ) as detalle from Grado_publicacion where estado is null", "id", "detalle");
            Funciones.CargarComboBox(rubros, "select codigo, descripcion from Rubro", "codigo", "descripcion");
            this.id_empresa = Funciones.GetStringFromQuery("select id from Empresa where id_usuario=" + id_usuario, "id");
            if (this.id_empresa == null)
            {
                MessageBox.Show("El usuario no tiene una empresa asociada y por lo tanto no podra realizar publicaciones");
                return;
            }
            conexion = ConexionSQL.GetConexion();
            this.id_usuario = id_usuario;

        }

        private void limpiarBTN_Click(object sender, EventArgs e)
        {
            descripcionTB.Clear();
            direccionTB.Clear();
            ubicaciones.Clear();
            nro_calle.Clear();
            fechasEspectaculo.Clear();
        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            if (this.id_empresa == null)
            {
                MessageBox.Show("El usuario no tiene una empresa asociada y por lo tanto no podra dar de alta una publicacion");
                return;
            }
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaPublicacion", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable fechas = new DataTable();
                    DataTable ubicacionest = new DataTable();

                    ubicacionest.Columns.Add("fila");
                    ubicacionest.Columns.Add("asiento", typeof(int));
                    ubicacionest.Columns.Add("precio", typeof(int));
                    ubicacionest.Columns.Add("tipo_ubicacion", typeof(int));
                    ubicacionest.Columns.Add("descripcion");


                    fechas.Columns.Add("fecha_evento", typeof(DateTime));
                    foreach (DateTime fecha in fechasEspectaculo)
                    {
                        DataRow dr = fechas.NewRow();
                        
                        dr["fecha_evento"] = fecha;
                        fechas.Rows.Add(dr);
                    }


                    foreach (Ubicacion ubi in ubicaciones)
                    {
                        DataRow dr = ubicacionest.NewRow();
                        dr["fila"] = ubi.fila;
                        dr["asiento"] = ubi.asiento;
                        dr["precio"] = ubi.precio;
                        dr["tipo_ubicacion"] = ubi.tipo_nro;
                        dr["descripcion"] = ubi.tipo;
                        ubicacionest.Rows.Add(dr);
                    }

                    cmd.Parameters.Add(new SqlParameter("@fecha_evento", fechas));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcionTB.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_rubro", Funciones.getIdsCheckSeleccionadosCB(rubros)));
                    cmd.Parameters.Add(new SqlParameter("@calle", direccionTB.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_calle", nro_calle.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_grado", Funciones.getIdsCheckSeleccionadosCB(grados)));
                    cmd.Parameters.Add(new SqlParameter("@id_empresa", this.id_empresa));
                    cmd.Parameters.Add(new SqlParameter("@ubicaciones", ubicacionest));
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));



                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El alta de la publicacion se ha realizado con exito", "Exito!");
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
            TextBox[] textBoxes = new TextBox[] { nro_calle };
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
            if (nro_calle.Text != string.Empty && direccionTB.Text != string.Empty && descripcionTB.Text != string.Empty && ubicaciones.Count > 0 && fechasEspectaculo.Count > 0)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }


        private void ubicacionesBTN_Click(object sender, EventArgs e)
        {
            ABMUbicaciones ubicacionesForm = new ABMUbicaciones(null, ref ubicaciones);
            ubicacionesForm.ShowDialog();
        }

        private void fechasBTN_Click(object sender, EventArgs e)
        {
            ABMFechasPublicacion publicacionesForm = new ABMFechasPublicacion(null, fechasEspectaculo);
            publicacionesForm.ShowDialog();
        }

        private void gradoBTN_Click(object sender, EventArgs e)
        {
            PickGrado pickGrado = new PickGrado(grado);
            pickGrado.ShowDialog();
        }

        private void rubroBTN_Click_1(object sender, EventArgs e)
        {
            PickRubro pickRubro = new PickRubro(rubro);
            pickRubro.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }

    public partial class Ubicacion
    {
        public string fila { get; set; }
        public int asiento { get; set; }
        public int precio { get; set; }
        public string tipo { get; set; }
        public int tipo_nro { get; set; }

        public Ubicacion(string fila, int asiento, int precio, string tipo, int tipo_nro)
        {
            this.fila = fila;
            this.asiento = asiento;
            this.precio = precio;
            this.tipo = tipo;
            this.tipo_nro = tipo_nro;
        }

    }


    public partial class Tipo
    {
        public int nro { get; set; }
        public string descripcion { get; set; }

        public Tipo(int nro, string descripcion)
        {
            this.nro = nro;
            this.descripcion = descripcion;
        }

    }

    public partial class Rubro
    {
        public int? rubroId { get; set; }
        public Rubro(int? id) {
            rubroId = id;
        }
    }

    public partial class Grado
    {
        public int? gradoId { get; set; }
        public Grado(int? id) {
            gradoId = id;
        }
    }

}
