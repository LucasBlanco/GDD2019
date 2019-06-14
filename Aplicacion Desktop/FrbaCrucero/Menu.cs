using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    
    public partial class Menu : Form
    {
        string fecha;
        public Menu(int idUser, string fecha)
        {

            InitializeComponent();
            if (idUser == -1) {
                idUser = Convert.ToInt32(
                            Funciones.GetStringFromQuery(
                                "select id from Usuario where nombre = 'cliente'",
                                "id"
                            )
                        );
            }

            this.fecha = fecha;
            string query = @"select f.nombre 
                                from Usuario u
                                join Usuario_rol ur on ur.id_usuario = u.id
                                join Rol_funcionalidad rf on rf.id_rol = ur.id_rol
                                join Funcionalidad f on rf.id_funcionalidad = f.id
                                where u.id =" + idUser ;
            List<String> permisos = Funciones.getColumnFromQuery(query);

            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }

            foreach (string func in permisos)
            {
                this.Controls[func].Visible = true;
            }
        }

        private void abm_recorrido_Click(object sender, EventArgs e)
        {
            new AbmRecorrido.Main().ShowDialog();
        }


        private void listado_estadistico_Click(object sender, EventArgs e)
        {
            new ListadoEstadistico.Main(fecha).ShowDialog();
        }


        private void abm_crucero_Click(object sender, EventArgs e)
        {
            new AbmCrucero.Main(fecha).ShowDialog();
		}
        private void abm_rol_Click(object sender, EventArgs e)
        {
            new AbmRol.Main().ShowDialog();
        }
        private void reservar_viaje_Click(object sender, EventArgs e)
        {
            new CompraReservaPasaje.ReservaViaje(fecha).ShowDialog();
        }

        private void pago_reserva_Click(object sender, EventArgs e)
        {
            new CompraReservaPasaje.CompraViaje(null, null).ShowDialog();
        }
    }
}
