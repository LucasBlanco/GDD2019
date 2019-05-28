using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class Main: Form
    {
        string id_usuario;
        public Main(string id_usuario)
        {
            this.id_usuario = id_usuario;
            InitializeComponent();
        }

        private void Alta_Click(object sender, EventArgs e)
        {
            new AltaPublicacion(this.id_usuario).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id_empresa = Funciones.GetStringFromQuery("select id from Empresa where id_usuario=" + id_usuario, "id");
            if (id_empresa == null)
            {
                MessageBox.Show("El usuario no tiene una empresa asociada y por lo tanto no tiene publicaciones");
            }
            else {
                new Editar_Publicacion.BusquedaBorrarPublicacion(this.id_usuario).ShowDialog();
            }
            
        }
    }
}
