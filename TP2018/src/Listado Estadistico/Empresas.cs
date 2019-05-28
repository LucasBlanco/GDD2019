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
    public partial class Empresas : Form
    {
        SqlConnection conexion;
        private string año;
        public Empresas(string trimestre, string year)
        {
            InitializeComponent();
            conexion = ConexionSQL.GetConexion();

            this.año = year;

            Funciones.CargarCheckboxList(gradoCB, "select prioridad, id from Grado_publicacion", "id", "prioridad");
            if (trimestre == "Primero")
            {

                this.cargarEstados(new string[] { "Enero-" + year, "Febrero-" + year, "Marzo-" + year});
            }
            else if (trimestre == "Segundo")
            {
                this.cargarEstados(new string[] {"Abril-" + year, "Mayo-" + year, "Junio-" + year});

            }
            else if (trimestre == "Tercero")
            {
                this.cargarEstados(new string[] { "Julio-"+year, "Agosto-" + year, "Septiembre-" + year});

            }
            else if (trimestre == "Cuarto")
            {
                this.cargarEstados(new string[] { "Octubre-" + year, "Noviembre-" + year, "Diciembre-" + year });

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes = Funciones.getIdsCheckSeleccionadosCB(mesCB);
            List<object> grado = Funciones.getIdsCheckSeleccionados(gradoCB, "id");

            string str = "( ";

            foreach (object id in grado)
            {
                 
                str+=id.ToString()+", ";
                
            }
            str = str.Substring(0, str.Length - 2);
            str += " )";

            SqlCommand cmd = new SqlCommand("select top 5 publicacion.id_empresa ID, (select razon_social from Empresa where id = publicacion.id_empresa) Empresa,count(*) Cantidad from Publicacion publicacion join Ubicacion ubicacion on ubicacion.id_publicacion = publicacion.codigo where publicacion.id_grado in "+ str +" and year(publicacion.fecha_publicacion) = "+this.año+" and month(publicacion.fecha_publicacion) = "+ mes+" and ubicacion.id_compra is null group by publicacion.id_empresa order by count(*) desc", conexion);
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

        private void cargarEstados(string[] estados)
        {
            DataTable estadost = new DataTable();
            estadost.Columns.Add("nombre");
            estadost.Columns.Add("id");
            int i = 1;
            foreach (string estado in estados)
            {
                DataRow dr = estadost.NewRow();
                dr["nombre"] = estado;
                dr["id"] = i;
                i++;
                estadost.Rows.Add(dr);
            }
            mesCB.DataSource = estadost;
            mesCB.ValueMember = "id";
            mesCB.DisplayMember = "nombre";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabla.SelectedRows.Count > 0)
            {
                try
                {
                    string id = tabla.SelectedRows[0].Cells[0].Value.ToString();


                    string mes = Funciones.getIdsCheckSeleccionadosCB(mesCB);
                    List<object> grado = Funciones.getIdsCheckSeleccionados(gradoCB, "id");

                    string str = "( ";

                    foreach (object ids in grado)
                    {

                        str += ids.ToString() + ", ";

                    }
                    str = str.Substring(0, str.Length - 2);
                    str += " )";


                    SqlCommand cmd = new SqlCommand("select top 5 publicacion.codigo as Codigo, publicacion.fecha_publicacion as Fecha, g.comision as Comision, sum(case when ubicacion.id_compra is null then 1 else 0 end) as Cantidad from Publicacion publicacion join Ubicacion ubicacion on ubicacion.id_publicacion = publicacion.codigo join Empresa empresa on publicacion.id_empresa = empresa.id join Grado_publicacion g on publicacion.id_grado = g.id where publicacion.id_grado in "+ str +" and year(publicacion.fecha_publicacion) = "+ this.año +" and month(publicacion.fecha_publicacion) = "+mes+" and publicacion.id_empresa = "+id+" group by publicacion.codigo, razon_social, publicacion.fecha_publicacion, g.comision order by  publicacion.fecha_publicacion, g.comision  ", conexion);
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
