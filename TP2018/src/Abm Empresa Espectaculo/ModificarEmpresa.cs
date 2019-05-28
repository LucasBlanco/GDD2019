using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ModificarEmpresa : Form
    {
        SqlConnection conexion;
        string id;
        public ModificarEmpresa(DataGridViewRow dgvr)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();

            razon_social.Text = dgvr.Cells[0].Value.ToString();
            mail.Text = dgvr.Cells[1].Value.ToString();
            telefono.Text = dgvr.Cells[2].Value.ToString();
            calle.Text = dgvr.Cells[3].Value.ToString();
            nro.Text = dgvr.Cells[4].Value.ToString();
            piso.Text = dgvr.Cells[5].Value.ToString();
            dpto.Text = dgvr.Cells[6].Value.ToString();
            cuit.Text = dgvr.Cells[10].Value.ToString();
            //TODO: cambiar datos de la DB para que el cuil tenga el tamaño indicado
            localidad.Text = dgvr.Cells[7].Value.ToString();
            CP.Text = dgvr.Cells[8].Value.ToString();
            ciudad.Text = dgvr.Cells[9].Value.ToString();
            habilitadoCBox.Checked = (dgvr.Cells[12].Value.ToString().Length == 0);
            id = dgvr.Cells[13].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("modificarEmpresa", conexion);

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
                    cmd.Parameters.AddWithValue("@estado", habilitadoCBox.Checked ? Convert.DBNull : "inhabilitado"); 
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("La modificacion de la empresa se ha realizado con exito", "Exito!");
                }

                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                    conexion.Close();
                }

            }
            else MessageBox.Show("datos mal cargados");
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCamposNumericos() && checkCuil());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { CP, telefono, nro, piso };
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
                MessageBox.Show("el cuit es invalido");
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
            habilitadoCBox.Checked = false;
        }

        private void cuit1_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
