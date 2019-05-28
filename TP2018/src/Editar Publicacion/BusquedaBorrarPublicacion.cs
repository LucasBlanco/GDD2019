using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class BusquedaBorrarPublicacion : Form
    {
        SqlConnection conexion;
        DataTable dt;
        string id_usuario;
        string id_empresa;
        public BusquedaBorrarPublicacion(string id_usuario)
        {
            this.id_usuario = id_usuario;
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();

            this.id_empresa = Funciones.GetStringFromQuery("select id from Empresa where id_usuario=" + id_usuario, "id");

            dt = ConexionSQL.CargarDataGridView(publicaciones, "select codigo, fecha_publicacion, fecha_evento, descripcion, calle, nro_calle, id_rubro, id_grado, codigo, estado from Publicacion join Publicacion_estado est on estado = est.id where est.nombre <> 'Finalizada' and fecha_evento >'"+Funciones.yesterday()+"T10:00:00' and id_empresa=" + this.id_empresa);
                publicaciones.Columns[6].Visible = false;
                publicaciones.Columns[7].Visible = false;
                publicaciones.Columns[8].Visible = false;
                publicaciones.Columns[9].Visible = false;
            
            Funciones.CargarComboBox(grados, "select id, concat('Prioridad: ',prioridad,' Comision: ',comision ) as detalle from Grado_publicacion", "id", "detalle");
            Funciones.CargarComboBox(rubros, "select codigo, descripcion from Rubro", "codigo", "descripcion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (publicaciones.SelectedRows.Count > 0)
            {
                new EditarPublicacion(publicaciones.SelectedRows[0], this.id_usuario).ShowDialog();
                ConexionSQL.CargarDataGridView(publicaciones, "select codigo, fecha_publicacion, fecha_evento, descripcion, calle, nro_calle, id_rubro, id_grado, codigo, estado from Publicacion join Publicacion_estado est on estado = est.id where est.nombre <> 'Finalizada' and fecha_evento >'" + Funciones.yesterday() + "T10:00:00' and id_empresa=" + this.id_empresa);
                publicaciones.Update();
            }
            else
                MessageBox.Show("Elije una publicacion antes de modificar");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = publicaciones.SelectedRows[0];
            string idEmpresa = dgvr.Cells[13].Value.ToString();

            try
            {
                SqlCommand cmd = new SqlCommand("update Empresa set estado = 'inhabilitado' where id = " + idEmpresa, conexion);
                 

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Operacion realizada con exito!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (descripcion.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "descripcion", descripcion.Text);
            }
            if (fechaPublicacion.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "fecha_publicacion", Convert.ToDateTime(fechaPublicacion.Text).ToString("yyyy-MM-dd")+"T00:00:00", "=");
            }
            if (fechaEvento.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "fecha_evento", Convert.ToDateTime(fechaEvento.Text).ToString("yyyy-MM-dd") + "T00:00:00", "=");
            }
            if (calle.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "calle", calle.Text);
            }
            if (nro_calle.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "nro_calle", nro_calle.Text);
            }
            if (Funciones.hayCheckSeleccionadoCB(grados))
            {
                filters = Funciones.agregarFiltroAQuery(filters, "id_grado", Funciones.getIdsCheckSeleccionadosCB(grados), "=");
            }
            if (Funciones.hayCheckSeleccionadoCB(rubros))
            {
                filters = Funciones.agregarFiltroAQuery(filters, "id_rubro", Funciones.getIdsCheckSeleccionadosCB(rubros), "=");
            }
            string query = "select codigo, fecha_publicacion, fecha_evento, descripcion, calle, nro_calle, id_rubro, id_grado, codigo, estado from Publicacion join Publicacion_estado est on estado = est.id where est.nombre <> 'Finalizada' and fecha_evento >'" + Funciones.yesterday() + "T10:00:00' and id_empresa=" + this.id_empresa + (filters.Length > 0 ? (" and " + filters) : null);
            dt = ConexionSQL.CargarDataGridView(publicaciones, query);
            publicaciones.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           /* descripcion.Clear();
            mail.Clear();
            cuit.Clear();*/
        }

        private void razon_social_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BusquedaBorrarPublicacion_Load(object sender, EventArgs e)
        {
            
        }

        private void BusquedaBorrarPublicacion_Shown(Object sender, EventArgs e)
        {

            

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

  
    }
}
