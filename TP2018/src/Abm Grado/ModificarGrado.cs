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

namespace PalcoNet.Abm_Grado
{
    public partial class ModificarGrado : Form
    {
        private SqlConnection conexion;
        private string id;

        public ModificarGrado(DataGridViewRow dgvr)
        {

            InitializeComponent();
            conexion = ConexionSQL.GetConexion();

            prioridad.Text = dgvr.Cells[0].Value.ToString();
            comision.Text = dgvr.Cells[1].Value.ToString();
            habilitado.Checked = (dgvr.Cells[2].Value.ToString().Length == 0);

            id = dgvr.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                try
                {
                    conexion.Open();
                    string comi =comision.Text.Replace(',','.');
                    string estado = habilitado.Checked ? "NULL" : "'inhabilitado'";
                    SqlCommand cmd = new SqlCommand("update Grado_publicacion set prioridad = '" + prioridad.Text + "', comision = " + comi + ", estado = " + estado +"  where id = " + id, conexion);

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Operacion realizada con exito!");
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

            foreach (TextBox t in textBoxes)
            {
                int intValue;
                float floatValue;

                if (!(Int32.TryParse(t.Text, out intValue) || float.TryParse(t.Text, out floatValue)))
                {
                    MessageBox.Show("el campo " + t.Name + " debe ser numerico");
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



    }
}
