﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCrucero.AbmCrucero
{
    public partial class TerminoVidaUtil : Form
    {
        int idCrucero;
        SqlConnection conexion;

        public TerminoVidaUtil(int id)
        {
            conexion = ConexionSQL.GetConexion();

            this.idCrucero = id;
            InitializeComponent();
            fechaBaja.MinDate = Funciones.fechaConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CancelarPasajesTerminoVidaUtil(this.idCrucero, Convert.ToDateTime(fechaBaja.Value).ToString("dd-MM-yyyy")).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("completarVidaUtilCruceroYReprogramarPasajes", conexion);

            // 2. set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@idCrucero", this.idCrucero));
            cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(fechaBaja.Value).ToString("dd-MM-yyyy")));

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Se ha encontrado un reemplazo con exito", "Exito!");
        
        }
    }
}
