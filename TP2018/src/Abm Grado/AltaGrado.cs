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

namespace PalcoNet.Abm_Grado
{
    public partial class AltaGrado : Form
    {
        SqlConnection conexion;
        public AltaGrado()
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Grado_publicacion (prioridad, comision) values ('"+ prioridad.Text +"', "+ comision.Text+")", conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("El alta del grado se ha realizado con exito", "Exito!");
                }
 
                catch (SqlException ex)
                {
                    if (ex.Number == 2601)
                      MessageBox.Show("Error: Ya existe una prioridad con ese nombre");
                    else 
                        MessageBox.Show("Error: " + ex.Message.ToString());
                    conexion.Close();

                }

            }
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCamposNumericos());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { comision };
            Regex nonNumericRegex = new Regex(@"\D");

            foreach (TextBox t in textBoxes)
            {
                int intValue;
                float floatValue;

                if (!(Int32.TryParse(t.Text, out intValue) || float.TryParse(t.Text, out floatValue)))
                {
                    MessageBox.Show("El campo " + t.Name + " debe ser numerico");
                    return false;
                }
            }
            return true;

        }

        private bool checkCamposVacios()
        {
            if (comision.Text != string.Empty && prioridad.Text != string.Empty)
            {

                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prioridad.Clear();
            comision.Clear();
        }

        private void AltaGrado_Load(object sender, EventArgs e)
        {

        }




    }
}
