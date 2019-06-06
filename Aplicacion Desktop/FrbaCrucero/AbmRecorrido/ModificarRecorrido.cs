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
    
    public partial class ModificarRecorrido : Form
    {
        List<Tramo> tramos = new List<Tramo>();
        SqlConnection conexion;
        string idRecorrido;
        public ModificarRecorrido(DataGridViewRow dgvr)
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            this.idRecorrido = dgvr.Cells[dgvr.Cells.Count - 1].Value.ToString();
            codigo.Text = Funciones.GetStringFromQuery("select codigo from Recorrido where id=" + idRecorrido, "codigo");

            string queryDGW = @"select puerto_inicio.nombre inicio, puerto_destino.nombre destino, rec.precio precio
                        from Puerto_recorrido rec 
                        join Puerto puerto_inicio on rec.id_puerto_origen = puerto_inicio.id 
                        join Puerto puerto_destino on rec.id_puerto_destino = puerto_destino.id 
                        where rec.id_recorrido =" + idRecorrido;
            Funciones.CargarDataGridView(tramosDGW, queryDGW);
            tramosDGW.Update();
            

            string puertoInicio = Funciones.GetStringFromQuery("select inicio from Recorrido where id="+ idRecorrido, "inicio");
            string puertoDestino = Funciones.GetStringFromQuery("select destino from Recorrido where id=" + idRecorrido, "destino");

            string queryTramos =  @"select id_puerto_origen inicio, id_puerto_destino destino, precio
                        from Puerto_recorrido
                        where id_recorrido =" + idRecorrido;

            using (var command = new SqlCommand(queryTramos, conexion))
            {
                conexion.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) {
                        string inicioTramo = reader["inicio"].ToString();
                        string destinoTramo = reader["destino"].ToString();
                        string precioTramo = reader["precio"].ToString();
                        tramos.Add(new Tramo(inicioTramo, destinoTramo, precioTramo));
                    }
                      
                }
                conexion.Close();
            }
            
            
            Funciones.CargarComboBox(inicio, "select id, nombre from Puerto", "id", "nombre");
            Funciones.CargarComboBox(destino, "select id, nombre from Puerto", "id", "nombre");
            inicio.Enabled = false;
            inicio.SelectedValue = tramos[tramos.Count()-1].destino;
            tramosDGW.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (precio.Value <= 0)
            {
                MessageBox.Show("El precio del tramo debe ser mayor a cero");
                return;
            }
            if (inicio.Text == destino.Text)
            {
                MessageBox.Show("El inicio debe ser distinto al destino");
                return;
            }
            DataTable dt = tramosDGW.DataSource as DataTable;
            dt.Rows.Add(inicio.Text, destino.Text, precio.Value);
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
                if (tramos.Any())
                {
                    asignarValorAInicioYDeshabilitar(tramos[tramos.Count - 1].destino.ToString());
                }
                else
                {
                    inicio.SelectionLength = 0;
                    inicio.Enabled = true;
                }
                destino.SelectionLength = 0;
                precio.Value = 1;
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("modificacionRecorrido", conexion);
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
                    cmd.Parameters.Add(new SqlParameter("@idRecorrido", idRecorrido));
                    cmd.Parameters.Add(new SqlParameter("@puertos", tramosDT));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El recorrido fue modificado con exito", "Exito!");
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
        private bool checkTramos()
        {
            if (tramos.Any())
            {
                return true;
            }
            MessageBox.Show("Ingrese por lo menos un tramo");
            return false;
        }
    }
    
}
