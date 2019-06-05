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

namespace FrbaCrucero
{
    public partial class Login : Form
    {
        SqlConnection conexion;
        string fecha;
        public Login(string fecha)
        {
            this.fecha = fecha;
            conexion = ConexionSQL.GetConexion();
            InitializeComponent();
            username.Text = "admin";
            password.Text = "w23e";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Funciones.checkCamposVacios(this.Controls))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("loginUser", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuario", username.Text));
                    cmd.Parameters.Add(new SqlParameter("@password", password.Text));
                    cmd.Parameters.Add(new SqlParameter("@respuesta", SqlDbType.NVarChar, 255)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@idUser", 0)).Direction = ParameterDirection.Output;
                    conexion.Open();
                    cmd.ExecuteReader();
                    string respuesta = Convert.ToString(cmd.Parameters["@respuesta"].Value);
                    int idUser = Convert.ToInt32(cmd.Parameters["@idUser"].Value);
                    conexion.Close();
                    if (respuesta == "maxima cantidad de intentos fallidos"){
                        MessageBox.Show("Se alcanzo la maxima cantidad de intentos fallidos");
                    } else
                    if(respuesta == "usuario incorrecto"){
                        MessageBox.Show("El usuario ingresado no es correcto");
                    } else
                        if (respuesta == "password incorrecta")
                        {
                            MessageBox.Show("La contraseña no es correcta");
                        }
                        else {
                            new Menu(idUser, this.fecha).ShowDialog();
                        }

                    

                }
                catch (SqlException ex)
                {
                    conexion.Close();
                    MessageBox.Show("Error: " + ex.Message.ToString());
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Menu(-1, this.fecha).ShowDialog();
        }
    }
}
