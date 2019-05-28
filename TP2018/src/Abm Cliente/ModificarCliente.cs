using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class ModificarCliente : Form
    {
        private SqlConnection conexion;
        private String idUsuario;
        private String idCliente;

        public ModificarCliente(DataGridViewRow dgvr)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            nacimiento.MaxDate = Funciones.fechaConfig();

            nombre.Text = dgvr.Cells[0].Value.ToString();
            apellido.Text = dgvr.Cells[1].Value.ToString();
            tipo.Text = dgvr.Cells[2].Value.ToString();
            dni.Text = dgvr.Cells[3].Value.ToString();
            cuil.Text = dgvr.Cells[4].Value.ToString();
            //TODO: cambiar datos de la DB para que el cuil tenga el tamaño indicado
            mail.Text = dgvr.Cells[5].Value.ToString();
            telefono.Text = dgvr.Cells[6].Value.ToString();
            calle.Text = dgvr.Cells[7].Value.ToString();
            nro.Text = dgvr.Cells[8].Value.ToString();
            piso.Text = dgvr.Cells[9].Value.ToString();
            dpto.Text = dgvr.Cells[10].Value.ToString();
            localidad.Text = dgvr.Cells[11].Value.ToString();
            CP.Text = dgvr.Cells[12].Value.ToString();
            DateTime dt = (DateTime) dgvr.Cells[13].Value;
            nacimiento.Text = dt.ToString("dd-MM-yyyy"); 
            tarjeta.Text = dgvr.Cells[17].Value.ToString();
            idUsuario = dgvr.Cells[15].Value.ToString();
            habilitadoCBox.Checked = (dgvr.Cells[16].Value.ToString().Length == 0);
            idCliente = dgvr.Cells[18].Value.ToString();

        }

        private void limpiarBTN_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            tipo.Clear();
            dni.Clear();
            mail.Clear();
            telefono.Clear();
            localidad.Clear();
            calle.Clear();
            dpto.Clear();
            piso.Clear();
            nro.Clear();
            CP.Clear();
            tarjeta.Clear();
        }

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("modifCliente", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@apellido", apellido.Text));
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", tipo.Text));
                    cmd.Parameters.Add(new SqlParameter("@documento", dni.Text));
                    cmd.Parameters.Add(new SqlParameter("@cuil", cuil.Text));
                    cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono.Text));
                    cmd.Parameters.Add(new SqlParameter("@calle", calle.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_calle", nro.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_piso", piso.Text));
                    cmd.Parameters.Add(new SqlParameter("@dpto", dpto.Text));
                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad.Text));
                    cmd.Parameters.Add(new SqlParameter("@codigo_postal", CP.Text));

                    string fnacimiento = Convert.ToDateTime(nacimiento.Text).ToString("yyyy-MM-dd") + "T00:00:00"; 

                    cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", fnacimiento));
                    cmd.Parameters.Add(new SqlParameter("@tarjeta_credito", tarjeta.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_usuario", idUsuario));
                    cmd.Parameters.AddWithValue("@estado", habilitadoCBox.Checked ? Convert.DBNull : "inhabilitado");
                    cmd.Parameters.Add(new SqlParameter("@id", idCliente));
                   
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not in the correct format.", nacimiento.Text);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();
                }
            }
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCamposNumericos() && checkCuil());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { dni, telefono, nro, piso, CP, tarjeta };
            Regex nonNumericRegex = new Regex(@"\D");

            foreach (TextBox t in textBoxes)
            {
                if (nonNumericRegex.IsMatch(t.Text))
                {
                    MessageBox.Show("el campo " + t.Name + " debe ser numerico");
                    return false;
                }
            }
            return true;
        }

        private bool checkCamposVacios()
        {

            if (
                dni.Text != string.Empty &&
                mail.Text != string.Empty &&
                telefono.Text != string.Empty &&
                calle.Text != string.Empty &&
                nro.Text != string.Empty &&
                piso.Text != string.Empty &&
                dpto.Text != string.Empty &&
                cuil.Text != string.Empty &&
                localidad.Text != string.Empty &&
                CP.Text != string.Empty &&
                nombre.Text != string.Empty &&
                apellido.Text != string.Empty &&
                tipo.Text != string.Empty &&
                nacimiento.Text != string.Empty &&
                tarjeta.Text != string.Empty
                )
            {

                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private bool checkCuil()
        {
            bool status;
            Regex cuitr = new Regex(@"\d{2}-\d{8}-\d{2}");
            if (!(status = cuitr.IsMatch(cuil.Text)))
            {
                MessageBox.Show("El cuit es invalido");
            }
            return status;
        }
    }
}
