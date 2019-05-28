using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Eleccion_rol : Form
    {
        string id_usuario;
        public Eleccion_rol(string id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            Funciones.CargarComboBox(roles, "select id, nombre from Usuario_rol join Rol on rol_id = id where usuario_id=" + id_usuario, "id", "nombre");
            if (roles.Items.Count == 1)
            {
                var algo =  ((DataRowView) roles.Items[0]).Row.ItemArray[0].ToString();
                this.Hide();
                new Menu(id_usuario, algo).ShowDialog();
            }
            else if(roles.Items.Count == 0){
                MessageBox.Show("Error: El usuario seleccionado no tiene roles disponibles");
                this.Hide();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Funciones.hayCheckSeleccionadoCB(roles)){
                this.Hide();
                new Menu(id_usuario, ((DataRowView) roles.SelectedItem).Row.ItemArray[0].ToString()).ShowDialog();
                
            }
            else{
             MessageBox.Show("Seleccione un rol para continuar");
            }
            
        }


    }
}
