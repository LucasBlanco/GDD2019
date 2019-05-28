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

namespace PalcoNet.Generar_Publicacion
{
    public partial class ABMUbicaciones : Form
    {
        SqlConnection conexion;
        DataTable dt;
        static String QUERY = "SELECT * FROM Ubicacion WHERE id_publicacion={0}";
        private List<Ubicacion> ubicaciones;
        private List<Tipo> tipos;

        public ABMUbicaciones(String publicacionId, ref List<Ubicacion> ubicaciones)
        {
            this.tipos = new List<Tipo>();
            InitializeComponent();
            this.ubicaciones = ubicaciones;
            
            
            if (publicacionId == null)
            {
                dt = new DataTable();
                dt.Columns.Add("fila", typeof(string));
                dt.Columns.Add("asiento", typeof(System.Int32));
                dt.Columns.Add("precio", typeof(System.Int32));
                dt.Columns.Add("tipo_ubicacion_nro", typeof(System.Int32));
                dt.Columns.Add("tipo_ubicacion_descripcion", typeof(string));

                ubicacionesDGV.DataSource = dt;
                ubicacionesGB.Visible = false;


            }
            else
            {
                conexion = ConexionSQL.GetConexion();
                ConexionSQL.CargarDataGridView(ubicacionesDGV, String.Format(QUERY,publicacionId));
                Funciones.CargarComboBox(descripcion, "select descripcion, tipo_ubicacion from Ubicacion where id_publicacion =" + publicacionId+" group by descripcion, tipo_ubicacion", "tipo_ubicacion", "descripcion");
            }

        }

        private void limpiarBTN_Click(object sender, EventArgs e)
        {
            fila.Clear();
            asiento.Clear();
            precio.Clear();
        }

        private bool satisfiesControls() 
        {
            return (checkCamposVacios() && checkCamposNumericos());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { asiento, precio};
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
            if (fila.Text != string.Empty && asiento.Text != string.Empty && descripcion.Text != string.Empty && precio.Text != string.Empty)
            {

                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void filaTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregarBTN_Click_1(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                
                //ubicaciones.Add(new Ubicacion(filaTB.Text, Int32.Parse(asientoTB.Text), Int32.Parse(precioTB.Text), tipoUbicacionTB.Text));
                string[] newRow = new string[] { fila.Text, asiento.Text, precio.Text, descripcion.SelectedValue.ToString(), descripcion.Text };
                Funciones.AgregarRowVerificandoUnicidad(ubicacionesDGV, newRow);
                /*DataTable dataTable = (DataTable)ubicacionesDGV.DataSource;

                dataTable.Rows.Add(newRow);
                dataTable.AcceptChanges(); */
                limpiarBTN_Click(null, null);
            }
        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            this.guardarDatos();
        }

        public void guardarDatos(){
        this.ubicaciones.Clear();
            foreach (DataGridViewRow dr in ubicacionesDGV.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    Ubicacion item = new Ubicacion(dr.Cells[0].Value.ToString(), Int32.Parse(dr.Cells[1].Value.ToString()), Int32.Parse(dr.Cells[2].Value.ToString()), dr.Cells[4].Value.ToString(), Int32.Parse(dr.Cells[3].Value.ToString()));
                    this.ubicaciones.Add(item);
                }

            }
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tipos publicacionesForm = new Tipos(tipos, ref descripcion);
            publicacionesForm.ShowDialog();
            if (descripcion.Items.Count > 0) {
                ubicacionesGB.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ABMUbicaciones_Load(object sender, EventArgs e)
        {

        }



    }
}
