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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class ReservaViaje : Form
    {
        SqlConnection conexion;
        SeleccionCliente sc;
        Boolean clienteNuevo = true;
        string idCliente;
        string fecha;
        public ReservaViaje(string fecha)
        {
            this.fecha = fecha;
            
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            cliente_nacimiento.MaxDate = Funciones.fechaConfig();
            filtroFecha.MinDate = Funciones.fechaConfig();
            Funciones.CargarComboBox(filtroOrigen, "select id, nombre from Puerto", "id", "nombre");
            Funciones.CargarComboBox(filtroDestino, "select id, nombre from Puerto", "id", "nombre");

            DataTable dtFO = (DataTable)filtroOrigen.DataSource;
            var nRow = dtFO.NewRow();
            nRow[0] = -1;
            nRow[1] = "Seleccionar";
            dtFO.Rows.InsertAt(nRow, 0);
            DataTable dtFD = (DataTable)filtroDestino.DataSource;
            var nRow2 = dtFD.NewRow();
            nRow2[0] = -1;
            nRow2[1] = "Seleccionar";
            dtFD.Rows.InsertAt(nRow2, 0);
            filtroOrigen.SelectedIndex = 0;
            filtroDestino.SelectedIndex = 0;
            filtroOrigen.Update();
            filtroDestino.Update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buscarViaje_Click(object sender, EventArgs e)
        {

            String fecha = Convert.ToDateTime(filtroFecha.Value).ToString("yyyy-MM-dd");

            String query = @"select cru_id, via_id, cru_nombre as crucero from dbo.buscarViajes(" + filtroOrigen.SelectedValue.ToString() +
                                    " , " + filtroDestino.SelectedValue.ToString()+
                                    " , '" + fecha +
                                    "' , " + cantPasajes.Value + ")";
            Funciones.CargarDataGridView(crucerosDGW, query);
            crucerosDGW.Columns["cru_id"].Visible = false;
            crucerosDGW.Columns["via_id"].Visible = false;
            Funciones.CargarCheckboxList(cabinasCBL, "select id from Cabina where id= -1" , "id", "id");   
                                                
        }

        private void crucerosDGW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void crucerosDGW_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void cabinasDGW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id_viaje = crucerosDGW.SelectedRows[0].Cells["via_id"].Value.ToString();
            Funciones.CargarCheckboxList(cabinasCBL, "select id, concat('Nro: ', nro, ', Piso: ', piso, ', Precio: ', precio) nombre from cabinasLibresConDatos(" + id_viaje + ")", "id", "nombre");
        }

        private void cliente_dni_ValueChanged(object sender, EventArgs e)
        {
            string query =  @"select nombre, apellido, direccion, telefono, mail
                        from Cliente
                        where dni =" + cliente_dni.Value.ToString();

            using (var command = new SqlCommand(query, conexion))
            {
                conexion.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sc = new CompraReservaPasaje.SeleccionCliente(cliente_dni.Value.ToString(), this);
                        this.clienteNuevo = false;
                        sc.ShowDialog();
                    }
                    else {
                        this.clienteNuevo = true;
                    }

                }
                conexion.Close();
            }
        }

        public void seleccionDni(string nombre, string apellido, string direccion, string mail, string telefono, string nacimiento, string id){
            sc.Hide();
            cliente_nombre.Text = nombre;
            cliente_nombre.Enabled = false;
            cliente_apellido.Text = apellido;
            cliente_apellido.Enabled = false;
            cliente_direccion.Text = direccion;
            cliente_direccion.Enabled = false;
            cliente_mail.Text = mail;
            cliente_mail.Enabled = false;
            cliente_telefono.Text = telefono;
            cliente_telefono.Enabled = false;
            cliente_nacimiento.Value = Convert.ToDateTime(nacimiento);
            cliente_nacimiento.Enabled = false;
            this.idCliente = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    if (this.clienteNuevo)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("altaCliente", conexion);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@nombre", cliente_nombre.Text));
                            cmd.Parameters.Add(new SqlParameter("@apellido", cliente_apellido.Text));
                            cmd.Parameters.Add(new SqlParameter("@direccion", cliente_direccion.Text));
                            cmd.Parameters.Add(new SqlParameter("@telefono", cliente_telefono.Text));
                            cmd.Parameters.Add(new SqlParameter("@mail", cliente_mail.Text));
                            cmd.Parameters.Add(new SqlParameter("@dni", cliente_dni.Text));
                            cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", Convert.ToDateTime(cliente_nacimiento.Text).ToString("yyyy-MM-dd")));
                            cmd.Parameters.Add(new SqlParameter("@id", 0)).Direction = ParameterDirection.Output;
                            conexion.Open();
                            cmd.ExecuteReader();
                            idCliente = Convert.ToString(cmd.Parameters["@id"].Value);
                            conexion.Close();
                        }
                        catch (SqlException ex)
                        {
                            Funciones.handleSqlError(ex.Message.ToString(), "dni");
                            conexion.Close();
                        }
                       
                    }

                    SqlCommand cmd2 = new SqlCommand("reservarViaje", conexion);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    string id_cliente = this.idCliente;
                    string id_viaje = crucerosDGW.SelectedRows[0].Cells["via_id"].Value.ToString();
                    List<object> ids = Funciones.getIdsCheckSeleccionados(cabinasCBL, "id");
                    DataTable cabinasDT = new DataTable();

                    cabinasDT.Columns.Add("id", typeof(int));

                    foreach (object id in ids)
                    {
                        DataRow dr = cabinasDT.NewRow();
                        dr["id"] = id;
                        cabinasDT.Rows.Add(dr);
                    }
                    cmd2.Parameters.Add(new SqlParameter("@idCliente", id_cliente));
                    cmd2.Parameters.Add(new SqlParameter("@idViaje", id_viaje));
                    cmd2.Parameters.Add(new SqlParameter("@fecha", this.fecha));
                    cmd2.Parameters.Add(new SqlParameter("@idCabinas", cabinasDT));
                    cmd2.Parameters.Add(new SqlParameter("@codigo", 0)).Direction = ParameterDirection.Output;

                    // execute the command
                    conexion.Open();
                    cmd2.ExecuteReader();
                    string codigo = Convert.ToString(cmd2.Parameters["@codigo"].Value);
                    conexion.Close();
                    MessageBox.Show("La reserva fue realizada con exito", "Exito!");
                    new InformeCodigoReserva(codigo, Funciones.getIdsCheckSeleccionados(cabinasCBL, "nombre"), ids, id_viaje).ShowDialog();
                    Funciones.CargarCheckboxList(cabinasCBL, "select id from Cabina where id= -1", "id", "id"); 
                }
                catch (SqlException ex)
                {
                    Funciones.handleSqlError(ex.Message.ToString(), "dni");
                    conexion.Close();
                }

            }
            
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCabinas());
        }

        private bool checkCamposVacios()
        {
            if (cliente_nombre.Text != string.Empty && cliente_apellido.Text != string.Empty && cliente_direccion.Text != string.Empty && cliente_telefono.Text != string.Empty && cliente_dni.Text != string.Empty)
            {
                return true;
            }
            MessageBox.Show("Complete los datos del Cliente");
            return false;
        }
        
        private bool checkCabinas()
        {
            if (Funciones.getIdsCheckSeleccionados(cabinasCBL, "id").Count() > cantPasajes.Value)
            {
                return true;
            }
            MessageBox.Show("Seleccione por lo menos " + cantPasajes.Value + " cabinas");
            return false;
        }
        private bool checkCruceros()
        {
            if (crucerosDGW.SelectedRows.Count > 0)
            {
                return true;
            }
            MessageBox.Show("Seleccione por lo menos un crucero");
            return false;
        }

        private void cabinasCBL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
