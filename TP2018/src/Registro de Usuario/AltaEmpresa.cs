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
using System.Text.RegularExpressions;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class AltaEmpresa : Form
    {
        string username;
        string password;
        SqlConnection conexion;
        Form registro_usuario;
        public AltaEmpresa(string username, string password, Form registro_usuario)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.registro_usuario = registro_usuario;
            conexion = ConexionSQL.GetConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("altaEmpresaYUsuario", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@razon_social", razon_social.Text));
                    cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono.Text));
                    cmd.Parameters.Add(new SqlParameter("@calle", calle.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_calle", nro.Text));
                    cmd.Parameters.Add(new SqlParameter("@nro_piso", piso.Text));
                    cmd.Parameters.Add(new SqlParameter("@dpto", dpto.Text));
                    cmd.Parameters.Add(new SqlParameter("@localidad", localidad.Text));
                    cmd.Parameters.Add(new SqlParameter("@codigo_postal", CP.Text));
                    cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad.Text));
                    cmd.Parameters.Add(new SqlParameter("@cuit", cuit.Text));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@tipo", "empresa"));
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));


                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    this.Hide();
                    registro_usuario.Hide();
                    new Login().ShowDialog();
                    MessageBox.Show("El alta de la empresa y el usuario se ha realizado con exito", "Exito!");
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
            TextBox[] textBoxes = new TextBox[] { telefono, nro, piso, CP};
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

            if (razon_social.Text != string.Empty && mail.Text != string.Empty && telefono.Text != string.Empty && calle.Text != string.Empty && nro.Text != string.Empty && piso.Text != string.Empty && dpto.Text != string.Empty && cuit.Text != string.Empty && localidad.Text != string.Empty && CP.Text != string.Empty && ciudad.Text != string.Empty)
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
            if (!(status = cuitr.IsMatch(cuit.Text)))
            {
                MessageBox.Show("El cuit es invalido. Debe seguir el formato XX-XXXXXXX-XX");
            }
            return status;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            razon_social.Clear();
            mail.Clear();
            telefono.Clear();
            calle.Clear();
            nro.Clear();
            piso.Clear();
            dpto.Clear();
            cuit.Clear();
            //TODO: cambiar datos de la DB para que el cuil tenga el tamaño indicado
            localidad.Clear();
            CP.Clear();
            ciudad.Clear();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }




    }
}
