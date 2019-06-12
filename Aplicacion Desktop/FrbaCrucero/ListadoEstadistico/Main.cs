using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Main : Form
    {
        string fecha;
        public Main(string fecha)
        {
            this.fecha = fecha;
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!camposValidos()) {
                return;
            }
            new RecorridosConMasPasajes(Funciones.toInt(anio.Value.ToString()), semestreSeleccionado(), fecha).ShowDialog();
        }

        private int semestreSeleccionado() {
            if (primerSemestre.Checked) { 
                return 1;
            }
            return 2;
        }

        private bool camposValidos() {
            if (anio.Value > Funciones.toInt(fecha.Split('-')[0])) {
                MessageBox.Show("El año ingresado debe ser anterior al "+ fecha.Split('-')[0], "Error!");
                return false;
            }
            if (!primerSemestre.Checked && !segundoSemestre.Checked) {
                MessageBox.Show("Seleccione un periodo", "Error!");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!camposValidos())
            {
                return;
            }
            new RecorridosConMasCabinasLibres(Funciones.toInt(anio.Value.ToString()), semestreSeleccionado()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!camposValidos())
            {
                return;
            }
            new CrucerosMasFueraDeServicio(Funciones.toInt(anio.Value.ToString()), semestreSeleccionado(), fecha).ShowDialog();
        }
    }
}
