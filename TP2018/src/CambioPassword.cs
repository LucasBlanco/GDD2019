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

namespace PalcoNet
{
    public partial class CambioPassword : Form
    {
        SqlConnection conexion;
        public CambioPassword()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("cambiarPasswordUsuario", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    string id_usuario = Funciones.GetStringFromQuery("select id from Usuario where username='" + username.Text+"'", "id");
                    cmd.Parameters.Add(new SqlParameter("@idUser", id_usuario));
                    cmd.Parameters.Add(new SqlParameter("@password_vieja", password_actual.Text));
                    cmd.Parameters.Add(new SqlParameter("@password_nueva", password_nueva.Text));
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("La contraseña se ha modificado con exito", "Exito!");
                    this.Hide();
                    new Login().ShowDialog();
                }

                catch (SqlException ex)
                {

                        MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();


                }

            }
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios());
        }

        private bool checkCamposVacios()
        {
            if (username.Text != string.Empty && password_actual.Text != string.Empty && password_nueva.Text != string.Empty)
            {
                    return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }
    }
}
