using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class InformeCodigoReserva : Form
    {
        public InformeCodigoReserva(string codigo, List<object> cabinas, List<object> ids, string idViaje)
        {
            InitializeComponent();
             DataTable cabinasDT = new DataTable();

             cabinasDT.Columns.Add("cabina", typeof(string));

                    foreach (object cabina in cabinas)
                    {
                        DataRow dr = cabinasDT.NewRow();
                        dr["cabina"] = cabina;
                        cabinasDT.Rows.Add(dr);
                    }
            codigo_reserva.Text = codigo;
            cabinasDGW.DataSource = cabinasDT;
            string ids_cabinas = "("+ String.Join(",", ids)+")";
            total.Text = Funciones.GetStringFromQuery("select sum(dbo.precioViaje(" + idViaje + ", cab.id)) precio from Cabina cab where cab.id in " + ids_cabinas, "precio");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CompraReservaPasaje.CompraViaje(codigo_reserva.Text, total.Text).ShowDialog();
        }
    }
}
