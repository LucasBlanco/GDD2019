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

namespace PalcoNet.Comprar
{
    public partial class Main : Form
    {
        string id_user;
        string id_cliente;
        Paginacion paginacion;

        static string QUERY_PUBLICACIONES = "SELECT publi.fecha_evento, publi.codigo, publi.descripcion, r.descripcion  from Publicacion publi join Grado_publicacion grado on publi.id_grado = grado.id join Publicacion_estado estado on estado.id = publi.estado join Rubro r on publi.id_rubro =r.codigo  where estado.nombre = 'Publicada' and publi.fecha_evento >= " + Funciones.today() + " order by grado.comision desc ";
        static string CANTIDAD_PUBLICACIONES = "SELECT count(*) as cantidad from Publicacion p join Publicacion_estado e on p.estado = e.id where e.nombre = 'Publicada' ";
        public Main(string id_user)
        {
            InitializeComponent();
            this.id_user = id_user;
            fechaDesde.MinDate = Funciones.fechaConfig();
            fechaHasta.MinDate = Funciones.fechaConfig();

            id_cliente = Funciones.GetStringFromQuery("select id from Cliente where id_usuario=" + this.id_user, "id");
            if (id_cliente == null)
            {
                MessageBox.Show("El usuario no tiene un cliente asociado y por lo tanto no podra realizar una compra");
            }
            else 
            {
                tarjetaTB.Text = Funciones.GetStringFromQuery("select tarjeta_credito from Cliente where id=" + this.id_cliente, "tarjeta_credito");
            }
                Funciones.CargarCheckboxList(categorias, "select * from Rubro", "codigo", "descripcion");

                paginacion = new Paginacion(publicaciones, QUERY_PUBLICACIONES, CANTIDAD_PUBLICACIONES, "Publicaciones", 10, nro_pagina);
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            String filters = "";
            if (descripcion.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "descripcion", descripcion.Text);
            }
            if (fechaDesde.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "fecha_evento", Convert.ToDateTime(fechaDesde.Text).ToString("yyyy-MM-dd")+"T00:00:00", ">");
            }
            if (fechaHasta.Text.Length > 0)
            {
                filters = Funciones.agregarFiltroAQuery(filters, "fecha_evento", Convert.ToDateTime(fechaHasta.Text).ToString("yyyy-MM-dd") + "T00:00:00", "<");
            }
            if (Funciones.hayCheckSeleccionado(categorias))
            {
                filters = filters + " and ( ";
                List<object> categoriasList =  Funciones.getIdsCheckSeleccionados(categorias, "codigo");
                filters = Funciones.agregarFiltroAQuery(filters, "publi.id_rubro", categoriasList[0].ToString(), "=", " ");
                categoriasList.RemoveAt(0);
                foreach (object id in categoriasList) {
                    filters = Funciones.agregarFiltroAQuery(filters, "publi.id_rubro", id.ToString(), "=", "OR");
                }
                filters = filters + " ) ";
            }
            string query = "SELECT publi.fecha_evento, publi.codigo, publi.descripcion, r.descripcion  from Publicacion publi join Grado_publicacion grado on publi.id_grado = grado.id join Publicacion_estado estado on estado.id = publi.estado join Rubro r on publi.id_rubro =r.codigo  where estado.nombre = 'Publicada' and publi.fecha_evento >= " + Funciones.today() + (filters.Length > 0 ? (" and " + filters) : null) + " order by grado.comision desc ";
            ConexionSQL.CargarDataGridView(publicaciones, query);
            publicaciones.Update();
        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (publicaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = publicaciones.SelectedRows[0];
                string id_publicacion = dgvr.Cells[1].Value.ToString();
                Funciones.CargarCheckboxList(ubicaciones, "select concat(fila,asiento,tipo_ubicacion,id_publicacion) id, concat('Ubicacion: ', fila, asiento, ' ',descripcion, ', Precio: ','$', precio ) detalle from Ubicacion where  id_compra is null  and id_publicacion=" + id_publicacion, "id", "detalle");
            }
            else {
                MessageBox.Show("Seleccione una ubicacion para continuar");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.id_cliente == null)
            {
                MessageBox.Show("Compra denegada. El usuario no tiene un cliente asociado");
                return;
            }

            if ((efectivoRadio.Checked || tarjetaRadio.Checked) && Funciones.hayCheckSeleccionado(ubicaciones) && tarjetaTB != null)
            {
                SqlConnection conexion = ConexionSQL.GetConexion();
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("altaCompra", conexion);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(string));
                    List<object> ids = Funciones.getIdsCheckSeleccionados(ubicaciones, "id");
                    foreach (object id in ids)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr["id"] = id;
                        dataTable.Rows.Add(dr);
                    }
                    cmd.Parameters.Add(new SqlParameter("@medio_pago", (efectivoRadio.Checked)? "Efectivo" : "Tarjeta_credito"));

                    cmd.Parameters.Add(new SqlParameter("@tarjeta_credito", tarjetaTB.Text));


                    //this.id_cliente = Funciones.GetStringFromQuery("select id from Cliente where id_usuario=" + this.id_user, "id");

                    //cmd.Parameters.Add(new SqlParameter("@id_cliente", id_cliente));
                    cmd.Parameters.Add(new SqlParameter("@id_cliente", id_cliente));
                    cmd.Parameters.Add(new SqlParameter("@ubicaciones", dataTable));
                    cmd.Parameters.Add(new SqlParameter("@today", Funciones.today()));
                    cmd.Parameters.Add(new SqlParameter("@id_publicacion", publicaciones.SelectedRows[0].Cells[1].Value.ToString()));

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("La compra se ha realizado con exito");
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    conexion.Close();
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                }

            }
            else MessageBox.Show("datos mal cargados");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paginacion.siguientePagina();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paginacion.anteriorPagina();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paginacion.primeraPagina();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            paginacion.ultimaPagina();
        }
    }
}
