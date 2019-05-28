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

namespace PalcoNet.Historial_Cliente
{
    public partial class Main : Form
    {
        string id_user;
        string id_cliente;
        Paginacion paginacion;
        public Main(string id_user)
        {
            InitializeComponent();
            this.id_user = id_user;
            this.id_cliente = Funciones.GetStringFromQuery("select id from Cliente where id_usuario=" + this.id_user, "id");
            if (this.id_cliente == null)
            {
                MessageBox.Show("El usuario no tiene un cliente asociado y por lo tanto no tiene un historial de compras");
                return;
            }
            string query = "select compra.id Nro_compra, medio.nombre Medio_pago, medio.detalle Tarjeta_credito, compra.fecha Fecha, ubicacion.fila Fila, ubicacion.asiento Asiento, ubicacion.precio, publicacion.descripcion from  Compra compra  join Compra_medioPago medio on compra.medio_pago = medio.id join Ubicacion ubicacion on ubicacion.id_compra = compra.id join Publicacion publicacion on publicacion.codigo = compra.id_publicacion where compra.id_cliente=" + this.id_cliente;
            string cantidad = "select count(*) as cantidad from Compra where id_cliente=" + id_cliente;
            Funciones.CargarDataGridView(historial, query);
            paginacion = new Paginacion(historial, query, cantidad, "Publicaciones", 10, nro_pagina);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paginacion.primeraPagina();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paginacion.anteriorPagina();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paginacion.siguientePagina();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            paginacion.ultimaPagina();
        }
    }
}
