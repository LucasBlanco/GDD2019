using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet.Listado_Estadistico
{
    public partial class PuntosClientes : Form
    {
        SqlConnection conexion;

        public PuntosClientes(string trimestre, string year)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();
            string mes1 = "";
            string mes2 = "";
            if (trimestre == "Primero")
            {

                 mes1 = "1";
                 mes2 = "3";
            }
            else if (trimestre == "Segundo")
            {
                 mes1 = "4";
                 mes2 = "6";

            }
            else if (trimestre == "Tercero")
            {
                 mes1 = "7";
                 mes2 = "9";

            }
            else if (trimestre == "Cuarto")
            {
                 mes1 = "10";
                 mes2 = "12";
            }

            var algo = Funciones.today();
            SqlCommand cmd = new SqlCommand("select top 5 cliente.nombre as Nombre, cliente.apellido as Apellido, cliente.documento as DNI, cliente.tipo_documento as Tipo, sum(isnull(compra.puntos_disponibles, 0)) as Cantidad from Cliente cliente join Compra compra on compra.id_cliente = cliente.id where year(compra.fecha)= " + year + " and month(compra.fecha) >= "+ mes1 +" and MONTH(compra.fecha) <= " + mes2 +" and DATEDIFF( month, compra.fecha, '"+  Funciones.today() +"' ) > 6 group by cliente.id, cliente.nombre, cliente.apellido, cliente.documento, cliente.tipo_documento order by sum(isnull(compra.puntos_disponibles, 0)) desc", conexion);
            cmd.CommandType = CommandType.Text;
            DataTable t1 = new DataTable();
            conexion.Open();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(t1);
            }
            conexion.Close();
            tabla.DataSource = t1;
        }

        private void PuntosClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
