using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PalcoNet.Generar_Publicacion
{
    public partial class Tipos : Form
    {

        DataTable dt;
        private List<Tipo> tipos;
        private ComboBox descripcion2;
        public Tipos(List<Tipo> tipos, ref ComboBox descripcion)
        {
            InitializeComponent();
            this.tipos = tipos;
            this.descripcion2 = descripcion;
            dt = new DataTable();
            dt.Columns.Add("Nro", typeof(System.Int32));
            dt.Columns.Add("Descripcion", typeof(string));
    
            tiposDGV.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guardarBTN_Click(object sender, EventArgs e)
        {
            this.tipos.Clear();
            foreach (DataGridViewRow dr in tiposDGV.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    Tipo item = new Tipo(Int32.Parse(dr.Cells[0].Value.ToString()), dr.Cells[1].Value.ToString());
                    this.tipos.Add(item);
                }

            }
            this.Hide();
        }

        private void agregarBTN_Click(object sender, EventArgs e)
        {
            if (satisfiesControls())
            {
                //ubicaciones.Add(new Ubicacion(filaTB.Text, Int32.Parse(asientoTB.Text), Int32.Parse(precioTB.Text), tipoUbicacionTB.Text));
                string[] newRow = new string[] { nro.Text, descripcion.Text };
                DataTable dataTable = (DataTable)tiposDGV.DataSource;

                dataTable.Rows.Add(newRow);
                dataTable.AcceptChanges();


                descripcion2.DataSource = dt;
                descripcion2.DisplayMember = "Descripcion";
                descripcion2.ValueMember = "Nro";
            }
        }


        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCamposNumericos());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { nro };
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
            if (nro.Text != string.Empty && descripcion.Text != string.Empty)
            {

                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }
    }
}
