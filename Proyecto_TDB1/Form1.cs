using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;


namespace Proyecto_TDB1
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
          
        }

        

        public static OracleConnection conn=null;
       
        bool cone = false;
        public static string user,pass;
 
      

        private void aceptar_login_Click(object sender, EventArgs e)
        {
            try
            {

                user = username_login.Text;
                pass = password_login.Text;


                string connectionString = "Data Source=XE;User Id=" + user + ";Password=" + pass + ";";
                
                conn = new OracleConnection(connectionString);
                conn.Open();
                cone = true;

                MessageBox.Show("Conexion Establecida con Exito", "Proyecto TDB1", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

                if (cone = true)
                {
                    Form2 Forma = new Form2();
                    this.Hide();
                    Forma.ShowDialog();
                    

                }
                else { 
                }

            }
            catch (Exception err)
            {

                MessageBox.Show("Conexion No Establecida || Usuario o Contraseña Denegada" + err.Message, "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }   
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
