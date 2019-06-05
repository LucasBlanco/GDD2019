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
namespace FrbaCrucero.AbmRecorrido
{
    
    public partial class AltaRecorrido : Form
    {
        List<Tramo> tramos = new List<Tramo>();
        SqlConnection conexion;
        public AltaRecorrido()
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            Funciones.CargarComboBox(inicio, "select id, nombre from Puerto", "id", "nombre");
            Funciones.CargarComboBox(destino, "select id, nombre from Puerto", "id", "nombre");
            tramosDGW.AllowUserToAddRows = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(precio.Value <= 0){
                MessageBox.Show("El precio del tramo debe ser mayor a cero");
                return;
            }
            if (inicio.Text == destino.Text){
                MessageBox.Show("El inicio debe ser distinto al destino");
                return;
            }
             tramosDGW.Rows.Add(inicio.Text, destino.Text, precio.Value);
            tramos.Add(new Tramo(inicio.SelectedValue.ToString(), destino.SelectedValue.ToString(), precio.Value.ToString()));
            asignarValorAInicioYDeshabilitar(destino.SelectedValue.ToString());
            destino.SelectionLength = 0;
            precio.Value = 1;    
        }

        private void asignarValorAInicioYDeshabilitar(string valor)
        {
            inicio.SelectedValue = valor;
            inicio.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tramos.Any()) //prevent IndexOutOfRangeException for empty list
            {
                tramos.RemoveAt(tramos.Count - 1);
                tramosDGW.Rows.RemoveAt(tramosDGW.Rows.Count - 1);
                if (tramos.Any()){
                    asignarValorAInicioYDeshabilitar(tramos[tramos.Count-1].destino.ToString());
                }
                else {
                    inicio.SelectionLength = 0;
                    inicio.Enabled = true;
                }
                destino.SelectionLength = 0;
                precio.Value = 1;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inicio.SelectionLength = 0;
            destino.SelectionLength = 0;
            codigo.Text = null;
            precio.Value = 0;
            tramosDGW.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaRecorrido", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable tramosDT = new DataTable();

                    tramosDT.Columns.Add("indice", typeof(int));
                    tramosDT.Columns.Add("inicio", typeof(int));
                    tramosDT.Columns.Add("destino", typeof(int));
                    tramosDT.Columns.Add("precio", typeof(float));

                    int i = 0;
                    foreach (Tramo tramo in tramos)
                    {
                        DataRow dr = tramosDT.NewRow();
                        dr["indice"] = i;
                        dr["inicio"] = Funciones.toInt(tramo.inicio);
                        dr["destino"] = Funciones.toInt(tramo.destino);
                        dr["precio"] = Funciones.toFloat(tramo.precio);
                        tramosDT.Rows.Add(dr);
                        i++;
                    }

                    cmd.Parameters.Add(new SqlParameter("@codigo", codigo.Text));
                    cmd.Parameters.Add(new SqlParameter("@puertos", tramosDT));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El recorrido fue creado con exito", "Exito!");
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
            return (checkCamposVacios() && checkTramos());
        }

        private bool checkCamposVacios()
        {
            if (codigo.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }
        private bool checkTramos() {
            if (tramos.Any()) {
                return true;
            }
            MessageBox.Show("Ingrese por lo menos un tramo");
            return false;
        }
    }

    class Tramo
    {
        public string inicio, destino, precio;
        public Tramo(string inicio, string destino, string precio)
        {
            this.inicio = inicio;
            this.destino = destino;
            this.precio = precio;
        }
    }
}
