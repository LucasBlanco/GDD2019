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
    public partial class RecorridosConMasPasajes : Form
    {
        public RecorridosConMasPasajes(int anio, int semestre, string fechaActual)
        {
            InitializeComponent();
            Funciones.CargarDataGridView(estadisticaDGW, "select * from recorridosConMasPasajes(" + anio + "," + semestre + " )");
        }
    }
}
