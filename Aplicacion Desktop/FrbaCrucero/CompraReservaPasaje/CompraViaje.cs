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
    public partial class CompraViaje : Form
    {
        SqlConnection conexion;
        public CompraViaje(string reserva, string _total)
        {
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            codigo_reserva.Value = (reserva != null) ? Funciones.toInt(reserva) : 0;
            total.Text = _total != null ? _total : String.Empty;
            if (_total != null) {
                calcularTotal();
            }
            efectivo.Checked = true;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CompraViaje_Load(object sender, EventArgs e)
        {

        }

        private void debito_CheckedChanged(object sender, EventArgs e)
        {
            dosCuotas.Visible = false;
            tresCuotas.Visible = false;
            unaCuota.Checked = true;
            nro_tarjeta.Visible = true;
            codigo_seguridad.Visible = true;
        }


        private void efectivo_CheckedChanged(object sender, EventArgs e)
        {
            dosCuotas.Visible = false;
            tresCuotas.Visible = false;
            unaCuota.Checked = true;
            nro_tarjeta.Visible = false;
            codigo_seguridad.Visible = false;
        }

        private void Pagar_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SEGUNDA_VUELTA.pagarReserva", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                   
                    cmd.Parameters.Add(new SqlParameter("@codigoReserva", codigo_reserva.Value));
                    cmd.Parameters.Add(new SqlParameter("@codigo", 0)).Direction = ParameterDirection.Output;

                    if (efectivo.Checked) {
                        cmd.Parameters.Add(new SqlParameter("@nombreMedioPago", "efectivo"));
                    }
                    if (credito.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@nombreMedioPago", "tarjeta_credito"));
                    }
                    if(debito.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@nombreMedioPago", "tarjeta_debito"));
                    }
                    if (unaCuota.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@cantidadCuotas", 1));
                    }
                    if (dosCuotas.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@cantidadCuotas", 3));
                    }
                    if(tresCuotas.Checked)
                    {
                        cmd.Parameters.Add(new SqlParameter("@cantidadCuotas", 6));
                    }
                    cmd.Parameters.Add(new SqlParameter("@nroTarjeta", nro_tarjeta.Value));
                    cmd.Parameters.Add(new SqlParameter("@codigoSeguridad", codigo_seguridad.Value));
                    cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(Funciones.fechaConfig()).ToString("yyyy-MM-dd")));
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    string codigo = Convert.ToString(cmd.Parameters["@codigo"].Value);
                    conexion.Close();
                    MessageBox.Show("El codigo del pasaje es "+ codigo, "Exito!");
                    new InformePago(codigo).ShowDialog();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();
                }

            }
        }

        private void credito_CheckedChanged(object sender, EventArgs e)
        {
            dosCuotas.Visible = true;
            tresCuotas.Visible = true;
            unaCuota.Checked = false;
            nro_tarjeta.Visible = true;
            codigo_seguridad.Visible = true;
        }

        private void codigo_reserva_ValueChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void calcularTotal() {
            total.Text = Funciones.GetStringFromQuery("select sum(SEGUNDA_VUELTA.precioViaje(via.id, res.id_cabina)) precio from SEGUNDA_VUELTA.Viaje via join SEGUNDA_VUELTA.Reserva res on res.id_viaje = via.id where res.codigo=" + codigo_reserva.Text, "precio");
        }

        private bool satisfiesControls()
        {
            return (checkCodigoReserva() && checkTarjeta() && checkReservaNoPaga());
        }

        private bool checkCodigoReserva()
        {
            if (total.Text != String.Empty )
            {
                return true;
            }
            MessageBox.Show("Ingrese un codigo de reserva valido");
            return false;
        }

        private bool checkReservaNoPaga()
        {
            int pagada = Funciones.toInt(Funciones.GetStringFromQuery("select top 1 case when res.id_cabina in (select id_cabina from SEGUNDA_VUELTA.Pasaje pas where pas.id_viaje = via.id) then 1 else 0 end pagada from SEGUNDA_VUELTA.Reserva res join SEGUNDA_VUELTA.Viaje via on res.id_viaje = via.id where res.codigo=" + codigo_reserva.Text, "pagada"));
            if ( pagada == 0)
            {
                return true;
            }
            MessageBox.Show("La reserva ya fue pagada");
            return false;
        }

        private bool checkTarjeta()
        {
            if ((credito.Checked || debito.Checked))
            {
                if ((nro_tarjeta.Text != String.Empty && codigo_seguridad.Value != 0))
                {
                    return true;
                }
            }
            else {
                return true;
            }
            MessageBox.Show("Ingrese el numero de la tarjeta y el codigo de seguridad");
            return false;
        }
    }
}
