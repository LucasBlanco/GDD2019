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

namespace PalcoNet.Listado_Estadistico
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
            this.cargarEstados(new string[] { "Primero", "Segundo", "Tercero", "Cuarto" });

            this.cargarRanking(new string[] { "Empresas con mayor cantidad de entradas vendidas", "Clientes con mayor cantidad de puntos vencidos", "Clientes con mayor cantidad de compras" });

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (satisfiesControls())
            {

                string tr = Funciones.getIdsCheckSeleccionadosCB(trimestreCB);

                string rank = Funciones.getIdsCheckSeleccionadosCB(rankingCB);

                if (rank == "Empresas con mayor cantidad de entradas vendidas")
                {
                    Empresas em = new Empresas(tr, year.Text);
                    em.ShowDialog();
                }
                else if (rank == "Clientes con mayor cantidad de puntos vencidos")
                {
                    PuntosClientes cc = new PuntosClientes(tr, year.Text);
                    cc.ShowDialog();
                }
                else if (rank == "Clientes con mayor cantidad de compras")
                {
                    CantidadComprasClientes cc = new CantidadComprasClientes(tr, year.Text);
                    cc.ShowDialog();
                }

            }


        }

        private bool checkCamposVacios()
        {

            if (
                year.Text != string.Empty &&
                trimestreCB.SelectedValue != null &&
                rankingCB.SelectedValue != null
                )
            {

                return true;
            }
            MessageBox.Show("Complete los campos obligatorios");
            return false;
        }

        private bool satisfiesControls()
        {
            return (checkCamposVacios() && checkCamposNumericos());
        }

        private bool checkCamposNumericos()
        {
            TextBox[] textBoxes = new TextBox[] { year};
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

        private void cargarRanking(string[] estados)
        {
            DataTable estadost = new DataTable();
            estadost.Columns.Add("nombre");
            foreach (string estado in estados)
            {
                DataRow dr = estadost.NewRow();
                dr["nombre"] = estado;
                estadost.Rows.Add(dr);
            }
            rankingCB.DataSource = estadost;
            rankingCB.ValueMember = "nombre";
            rankingCB.DisplayMember = "nombre";
        }


        private void cargarEstados(string[] estados)
        {
            DataTable estadost = new DataTable();
            estadost.Columns.Add("nombre");
            foreach (string estado in estados)
            {
                DataRow dr = estadost.NewRow();
                dr["nombre"] = estado;
                estadost.Rows.Add(dr);
            }
            trimestreCB.DataSource = estadost;
            trimestreCB.ValueMember = "nombre";
            trimestreCB.DisplayMember = "nombre";
        }
    }
}
