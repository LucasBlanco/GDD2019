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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class AltaCliente : Form
    {
        string username; 
        string password;
        SqlConnection conexion;
        Form registro_usuario;
        public AltaCliente(string username, string password, Form registro_usuario)
        {

            InitializeComponent();
            this.username = username;
            this.password = password;
            this.registro_usuario = registro_usuario;
            conexion = ConexionSQL.GetConexion();
            nacimiento.MaxDate = Funciones.fechaConfig();
        }

        private void registrarBTN_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                
                try
                {
                    SqlCommand cmd = new SqlCommand("altaClienteYUsuario", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@apellido", apellido.Text));
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", tipo.Text));
                    cmd.Parameters.Add(new SqlParameter("@documento", dni.Text));
                    cmd.Parameters.Add(new SqlParameter("@cuil", cuil.Text));
                    cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                    cmd.Parameters.Add(new SqlParameter("@telefono", mail.Text));
                    cmd.Parameters.Add(new SqlParameter("@calle", calle.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_calle", nro.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_piso", piso.Text));
                    cmd.Parameters.Add(new SqlParameter("@dpto", dpto.Text));
                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad.Text));
                    cmd.Parameters.Add(new SqlParameter("@codigo_postal", CP.Text));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@tipo", "cliente"));
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));


                    string fnacimiento = Convert.ToDateTime(nacimiento.Text).ToString("yyyy-MM-dd") + "T00:00:00"; 

                    cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", fnacimiento));
                    cmd.Parameters.Add(new SqlParameter("@tarjeta_credito", tarjeta.Text));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    this.Hide();
                    registro_usuario.Hide();
                    MessageBox.Show("El alta de cliente y usuario se ha realizado con exito", "Exito!");
                    
                    new Login().ShowDialog();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not in the correct format.", nacimiento.Text);
                }
                catch (SqlException ex)
                {

                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();
                }
                
            }
            
            
        }

        private void limpiarValoresBTN_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            tipo.Clear();
            dni.Clear();
            cuil.Clear();
            mail.Clear();
            telefono.Clear();
            localidad.Clear();
            calle.Clear();
            nro.Clear();
            piso.Clear();
            dpto.Clear();
            CP.Clear();
            tarjeta.Clear();
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
                    MessageBox.Show("El campo " + t.Name + " debe ser numerico");
                    return false;
                }
            }
            return true;

        }

        private bool checkCuil()
        {
            bool status;
            Regex cuitr = new Regex(@"\d{2}-\d{8}-\d{2}");
            if (!(status = cuitr.IsMatch(cuil.Text)))
            {
                MessageBox.Show("El cuil es invalido. Debe seguir el formato XX-XXXXXXX-XX");
            }
            return status;
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

        private void rolBTN_Click(object sender, EventArgs e)
        {
            SeleccionarRol seleccionarRolForm = new SeleccionarRol();
            seleccionarRolForm.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
