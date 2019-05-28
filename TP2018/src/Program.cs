using PalcoNet.Abm_Rol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace PalcoNet
{
    class ConexionSQL
    {
        private static SqlConnection conexion;
        private static SqlDataAdapter dataAdapter;
        private static DataTable dataTable;

        internal static SqlConnection GetConexion()
        {
            if (conexion == null)
            {
                //conexion = new SqlConnection("server=DESKTOP-KSK57T8\\SQLSERVER2012 ; database=Lucas ; UID=gdEspectaculos2018;password=gdEspectaculos2018");
                string algo = ConfigurationManager.AppSettings["sqlConnection"];
                conexion = new SqlConnection(algo);

                //conexion = new SqlConnection("server=DESKTOP-PP45533\\SQLEXPRESS ; database=Lucas; Integrated Security=True;");

  
            }
            return conexion;
        }

        internal static DataTable CargarDataGridView(DataGridView dgv, String query)
        {
            try
            {
                conexion.Open();
                dataAdapter = new SqlDataAdapter(query, conexion);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv.DataSource = dataTable;
                conexion.Close();
                return dataTable;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                MessageBox.Show("Error de SQL: " + ex.Message.ToString());
                throw (ex);
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Funciones.SetSystemDate();
            DateTime today = DateTime.Today;
            Application.Run(new Login());

        }
    }

    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    };

    static class Funciones
    {
        private static SqlConnection conexion;
        private static SqlDataAdapter dataAdapter;
        private static DataTable dataTable;
        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime sysTime);

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);


  /*      internal static void SetSystemDate()
        {
            // Set system date and time
            SystemTime updatedTime = new SystemTime();
            Win32SetSystemTime(ref updatedTime);

            updatedTime.Year = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateYear"]);
            updatedTime.Month = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateMonth"]);
            updatedTime.Day = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateDay"]);
            updatedTime.Hour = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateHour"]);
            updatedTime.Minute = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateMinute"]);
            updatedTime.Second = (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateSecond"]);
            // Call the unmanaged function that sets the new date and time instantly
            Win32SetSystemTime(ref updatedTime);
        }*/





        internal static int toInt(string valor) {
            return Int32.Parse(Regex.Match(valor, @"\d+").Value);
        }
        internal static float toFloat(string valor)
        {
            return float.Parse(valor.Replace(",","."), CultureInfo.InvariantCulture.NumberFormat);
        }
        internal static void CargarDataGridView(DataGridView dgv, String query)
        {
            conexion = ConexionSQL.GetConexion();

            conexion.Open();
            dataAdapter = new SqlDataAdapter(query, conexion);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgv.DataSource = dataTable;
            conexion.Close();
        }

        internal static List<string> getColumnFromQuery(string query) {
            List<String> columnData = new List<String>();

            using (SqlConnection connection =  ConexionSQL.GetConexion())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return columnData;
        
        }

       
        internal static string GetStringFromQuery(string query, string campo) {
            SqlConnection conexion = ConexionSQL.GetConexion();
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter { SelectCommand = cmd };
            dataAdapter.Fill(dataSet);

            conexion.Close();
            if (dataSet.Tables[0].Rows.Count == 0) {
                return null;
            }
            return dataSet.Tables[0].Rows[0][campo].ToString();
        }

        internal static DateTime fechaConfig()
        {
            return new DateTime((ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateYear"]), (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateMonth"]), (ushort)Int16.Parse(ConfigurationManager.AppSettings["systemDateDay"]));
        }
        internal static void CargarCheckboxList(CheckedListBox checkboxList, String query, String id, String valor)
        {
            conexion = ConexionSQL.GetConexion();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            checkboxList.DataSource = dt;
            checkboxList.ValueMember = id;
            checkboxList.DisplayMember = valor;
            conexion.Close();
        }

        internal static void AgregarRowVerificandoUnicidad(DataGridView dataGrid, string[] row) {
            int cantDuplicados = 0;
            for (int i = 0; i < dataGrid.Rows.Count -1; i++)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    string var1 = row[j];
                    string var2 =  dataGrid.Rows[i].Cells[j].Value.ToString();
                    if (var1 == var2)
                    {
                        cantDuplicados++;
                    }
                }
                if (cantDuplicados == row.Length)
                {
                    MessageBox.Show("Error: el elemento ingresado esta duplicado");
                    return;
                }
                else {
                    cantDuplicados = 0;
                }
            }
            DataTable dataTable = (DataTable)dataGrid.DataSource;

            dataTable.Rows.Add(row);
            dataTable.AcceptChanges(); 
        }
        internal static void CargarComboBox(ComboBox checkboxList, String query, String id, String valor)
        {
            conexion = ConexionSQL.GetConexion();
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            checkboxList.DataSource = dt;
            checkboxList.ValueMember = id;
            checkboxList.DisplayMember = valor;
            conexion.Close();
        }


        internal static bool checkCamposVacios(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        MessageBox.Show("El campo " + textBox.Name + " debe ser completado");
                        return false;
                    }
                }
            }
            return true;
        }
        internal static bool hayCheckSeleccionado(CheckedListBox checkBoxList)
        {
            return checkBoxList.CheckedItems.Count > 0;
            
        }
        internal static bool hayCheckSeleccionadoCB(ComboBox checkBoxList)
        {
            return checkBoxList.SelectedIndex != -1;
        }
        internal static List<object> getIdsCheckSeleccionados(CheckedListBox checkBoxList, string id)
        {
            List<object> list = new List<object>();
            foreach (object itemChecked in checkBoxList.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                list.Add(castedItem[id]);
            }
            return list;
        }

        internal static string getIdsCheckSeleccionadosCB(ComboBox checkBoxList)
        {
            return checkBoxList.SelectedValue.ToString();
        }


        internal static string today(){
            return fechaConfig().ToString("yyyy-MM-dd");
        }
        
        internal static string yesterday(){
            var tuvieja = DateTime.Parse(today()).AddDays(-1).ToString("yyyy-MM-dd");
            return tuvieja;
        }

        internal static String agregarFiltroAQuery(String filtros, String campo, String valor, String comparador = null, string concatenador = null)
        {
            Console.WriteLine(valor);
            if(comparador == null){
                if(concatenador == null){
                    return filtros + (filtros.Length > 0 ? " AND " : "") + String.Format("{0} like '%{1}%'", campo, valor);
                }
                else
                {
                    return filtros + (filtros.Length > 0 ? (" "+concatenador+" ") : "") + String.Format("{0} like '%{1}%'", campo, valor);
                }
            }
            else
            {
                if (concatenador == null)
                {
                    return filtros + (filtros.Length > 0 ? " AND " : "") + String.Format("{0} " + comparador + " '{1}'", campo, valor);
                }
                else
                {
                    return filtros + (filtros.Length > 0 ? (" " + concatenador + " ") : "") + String.Format("{0} " + comparador + " '{1}'", campo, valor);
                }
            }


        }

    }

    internal class Paginacion
    {
        SqlDataAdapter pagingAdapter;
        public DataSet pagingDS {get; set;}
        int scrollVal;
        int resultadosPorPagina;
        SqlConnection conexion;
        String tableName;
        int cantidadResultados;
        Label nro_pagina;

        public Paginacion(DataGridView dgv, String query,string cantidad, String tableName, int resultadosPorPagina, Label nro_pagina)
        {
            scrollVal = 0;
            this.nro_pagina = nro_pagina;
            this.nro_pagina.Text = "0";
            this.resultadosPorPagina = resultadosPorPagina;
            this.cantidadResultados = Int32.Parse(Regex.Match(Funciones.GetStringFromQuery(cantidad, "cantidad"), @"\d+").Value);
            this.tableName = tableName;
            conexion = ConexionSQL.GetConexion();
            pagingAdapter = new SqlDataAdapter(query, conexion);
            pagingDS = new DataSet();
            conexion.Open();
            pagingAdapter.Fill(pagingDS, scrollVal, resultadosPorPagina, tableName);
            dgv.DataSource = pagingDS;
            dgv.DataMember = tableName;
            conexion.Close();
        }

        public void primeraPagina()
        {
            this.nro_pagina.Text = "0";
            scrollVal = 0;
            pagingDS.Clear();
            pagingAdapter.Fill(pagingDS, scrollVal, resultadosPorPagina, tableName);
        }

        public void anteriorPagina()
        {
            this.nro_pagina.Text = (Math.Max(Int32.Parse(Regex.Match(this.nro_pagina.Text, @"\d+").Value) -1, 0)).ToString();
            scrollVal = scrollVal - resultadosPorPagina;
            if (scrollVal <= 0)
            {
                scrollVal = 0;
            }
            pagingDS.Clear();
            pagingAdapter.Fill(pagingDS, scrollVal, resultadosPorPagina, tableName);
        }

        public void siguientePagina()
        {
            this.nro_pagina.Text = (Math.Min(Int32.Parse(Regex.Match(this.nro_pagina.Text, @"\d+").Value) + 1, Math.Ceiling((double)cantidadResultados / resultadosPorPagina))).ToString();
            scrollVal = scrollVal + resultadosPorPagina;
            pagingDS.Clear();
            pagingAdapter.Fill(pagingDS, scrollVal, resultadosPorPagina, tableName);
        }

        public void ultimaPagina()
        {
            this.nro_pagina.Text = (Math.Ceiling((double)cantidadResultados / resultadosPorPagina)).ToString();
            scrollVal = ((cantidadResultados % resultadosPorPagina) == 0) ? 
                            cantidadResultados - resultadosPorPagina 
                            : 
                            cantidadResultados - (cantidadResultados % resultadosPorPagina);
            pagingDS.Clear();
            pagingAdapter.Fill(pagingDS, scrollVal, resultadosPorPagina, tableName);
        }
    }
}
