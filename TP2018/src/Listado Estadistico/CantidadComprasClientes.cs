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
    public partial class CantidadComprasClientes : Form
    {
        SqlConnection conexion;
        private string mes1;
        private string mes2;
        public CantidadComprasClientes(string trimestre, string year)
        {
            InitializeComponent();

            conexion = ConexionSQL.GetConexion();

            if (trimestre == "Primero")
            {

                this.mes1 = "1";
                this.mes2 = "3";
            }
            else if (trimestre == "Segundo")
            {
                this.mes1 = "4";
                this.mes2 = "6";

            }
            else if (trimestre == "Tercero")
            {
                this.mes1 = "7";
                this.mes2 = "9";

            }
            else if (trimestre == "Cuarto")
            {
                this.mes1 = "10";
                this.mes2 = "12";
            }


            SqlCommand cmd = new SqlCommand("select top 5 c.id, c.nombre as Nombre, count(*) as Cantidad from Cliente c join Compra com on id_cliente = c.id join Ubicacion on id_compra = com.id  where month(com.fecha) >= " + this.mes1 + " and month(com.fecha) <= " + this.mes2 + " group by c.id, c.nombre order by count(*) desc ", conexion);
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

        private void CantidadComprasClientes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                try
                {
                    string id = tabla.SelectedRows[0].Cells[0].Value.ToString();


                    SqlCommand cmd = new SqlCommand("select top 5 p.id_empresa, (select razon_social from Empresa where id = p.id_empresa) as Empresa, count(*) as Cantidad from Cliente c join Compra com on id_cliente = c.id join Ubicacion u on id_compra = com.id join Publicacion p on u.id_publicacion = p.codigo  where c.id = "+ id +" and month(com.fecha) >= " +mes1+ " and month(com.fecha) <= "+mes2+" group by p.id_empresa order by count(*) desc ", conexion);
                    cmd.CommandType = CommandType.Text;
                    DataTable t1 = new DataTable();
                    conexion.Open();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(t1);
                    }
                    conexion.Close();
                    tabla2.DataSource = t1;


      
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Debes seleccionar alguna fila");
                }
            }
            else
                MessageBox.Show("Debes seleccionar alguna fila");
        }
    }
}
