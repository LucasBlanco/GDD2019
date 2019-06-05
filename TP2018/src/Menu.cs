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

namespace PalcoNet
{
    public partial class Menu : Form
    {
        List<string> funcionalidades = new List<string>();
        string id_user;
        public Menu(string id_user, string id_rol)
        {
            InitializeComponent();
            this.id_user = id_user;
            SqlConnection conexion = ConexionSQL.GetConexion();
            SqlCommand cmd = new SqlCommand("select func.nombre from Funcionalidad_rol func_rol join Funcionalidad func on func.id = func_rol.id_funcionalidad where func_rol.id_rol="+ id_rol, conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<string> ids = new List<string>();
            while (dr.Read())
            {
                funcionalidades.Add(dr["nombre"].ToString());
            }
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            this.Controls["log_out"].Visible = true;
            foreach (string func in funcionalidades) {
                this.Controls[func].Visible = true;
            }
            
            conexion.Close();
            
        }

        

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void rol_Click(object sender, EventArgs e)
        {
            new Abm_Rol.Main().ShowDialog();
        }

        private void usuario_Click(object sender, EventArgs e)
        {
            new Habilitar_usuario().ShowDialog();
        }

        private void cliente_Click(object sender, EventArgs e)
        {
            new Abm_Cliente.Main().ShowDialog();
        }

        private void empresa_Click(object sender, EventArgs e)
        {
            new Abm_Empresa_Espectaculo.Main().ShowDialog();
        }

        private void publicacion_Click(object sender, EventArgs e)
        {
            new Generar_Publicacion.Main(this.id_user).ShowDialog();
        }

        private void grado_Click(object sender, EventArgs e)
        {
            new Abm_Grado.Main().ShowDialog();
        }



        private void historial_Click(object sender, EventArgs e)
        {
            new Historial_Cliente.Main(id_user).ShowDialog();
        }

        private void canjear_Click(object sender, EventArgs e)
        {
            new Canje_Puntos.Main(this.id_user).ShowDialog();
        }

        private void pago_comision_Click(object sender, EventArgs e)
        {
            new Generar_Rendicion_Comisiones.Main().ShowDialog();
        }

        private void estadisticas_Click(object sender, EventArgs e)
        {
            new Listado_Estadistico.Estadisticas().ShowDialog();
        }

        private void comprar_Click(object sender, EventArgs e)
        {
            new Comprar.Main(this.id_user).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
        }
    }
}
