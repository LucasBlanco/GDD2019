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
    public partial class Login : Form
    {
        SqlConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void registrarBTN_Click(object sender, EventArgs e)
        {
            this.Hide();

           new Registro_de_Usuario.main().ShowDialog();

        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            if (Funciones.checkCamposVacios(this.Controls))
            {

                try
                {

 

                    SqlCommand cmd = new SqlCommand("loginUser", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@username", username.Text));
                    cmd.Parameters.Add(new SqlParameter("@password", password.Text));
                    cmd.Parameters.Add(new SqlParameter("@id_out", 0)).Direction = ParameterDirection.Output;

                    // execute the command
                    conexion.Open();
                    cmd.ExecuteReader();
                    string idUser = Convert.ToString(cmd.Parameters["@id_Out"].Value);
                    conexion.Close();

                    if (idUser == "-1")
                    {
                        //Usuario con unico ingreso
                        this.Hide();
                        MessageBox.Show("Debera cambiar su password por unica vez o su usuario sera bloqueado", "Advertencia!");
                        new CambioPassword().ShowDialog();
                    }
                    else {
                        this.Hide();
                        new Eleccion_rol(idUser).ShowDialog();
                    }
                    
                    
                }
                catch (SqlException ex)
                {
                    conexion.Close();
                    MessageBox.Show("Error: "+ ex.Message.ToString());
                }
            }
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CambioPassword().ShowDialog();
        }

    }
}
