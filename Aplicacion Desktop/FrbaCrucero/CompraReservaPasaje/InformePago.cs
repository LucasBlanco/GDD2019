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
    public partial class InformePago : Form
    {
        public InformePago(string codigo)
        {
            InitializeComponent();
            fecha.Text = Funciones.GetStringFromQuery("select top 1 fecha from Pasaje where codigo=" + codigo, "fecha");
            crucero.Text = Funciones.GetStringFromQuery("select top 1 cru.nombre nombre from Pasaje p join Cabina cab on p.id_cabina = cab.id join Crucero cru on cab.id_crucero = cru.id where p.codigo=" + codigo, "nombre");
            medio_pago.Text = Funciones.GetStringFromQuery("select top 1 m.nombre nombre from Pasaje p join Medio_pago m on p.id_medio_pago = m.id where p.codigo=" + codigo, "nombre");
            nro_tarjeta.Text = Funciones.GetStringFromQuery("select top 1 m.nro_tarjeta nombre from Pasaje p join Medio_pago m on p.id_medio_pago = m.id where p.codigo=" + codigo, "nombre");
            cant_cuotas.Text = Funciones.GetStringFromQuery("select top 1 m.cant_cuotas nombre from Pasaje p join Medio_pago m on p.id_medio_pago = m.id where p.codigo=" + codigo, "nombre");
            cod_pasaje.Text = codigo;
            Funciones.CargarDataGridView(cabinasDGW, "select nro, piso, srv.nombre from Cabina cab join Servicio srv on id_servicio = srv.id join Pasaje p on p.id_cabina = cab.id where p.codigo=" + codigo);
            total.Text = Funciones.GetStringFromQuery("select sum(dbo.precioViaje(via.id, cab.id)) precio from Cabina cab join Pasaje pas on pas.id_cabina = cab.id join Viaje via on pas.id_viaje = via.id where pas.codigo ="+codigo, "precio");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
