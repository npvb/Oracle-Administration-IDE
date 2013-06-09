using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Proyecto_TDB1
{
    public partial class procedures : Form
    {
        public string argumentos = "";
        public string nombre_argumento = "";
        public string tipo_argumento = "";
        public string defaol = "";
        public string IOT = "";
        public string tipo_dato = "";

        public procedures()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage4;
        }

        private void Cargar_Procedures() {
            OracleConnection conn = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            conn.Open();
            string parametro = "select object_name from user_objects where object_type = 'PROCEDURE'";
            OracleCommand cmd = new OracleCommand(parametro, Form1.conn);
            OracleDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    cmb_func.Items.Add(dr.GetOracleValue(0).ToString());
                }

                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR: " + err.Message.ToString());
            }
        }
        private void INICIO()
        {
            txt_schema.Text = Form1.user;
            txt_schema2.Text = Form1.user;
            txt_schema3.Text = Form1.user;
            txt_schema4.Text = Form1.user;
            txt_nom_obj.Text = "Procedimiento";
            aceptar.Visible = false;
            txt_nomfun.Text = "_pdr";
            textBox1.Visible = false;
            Cargar_Procedures();

        }

        private void procedures_Load(object sender, EventArgs e)
        {
            INICIO();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add();
        }


        private void Lee_grid()
        {
            argumentos = "(";
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if ((x > 0) && (x < dataGridView1.Rows.Count))

                nombre_argumento = (dataGridView1.Rows[x].Cells["Column1"].Value.ToString());
                tipo_argumento = (dataGridView1.Rows[x].Cells["Column2"].Value.ToString());
                defaol = (dataGridView1.Rows[x].Cells["Column3"].Value.ToString());
                IOT=(dataGridView1.Rows[x].Cells["Column4"].Value.ToString());

            }

            argumentos += nombre_argumento + " " + IOT + " " + tipo_argumento + " " + defaol + "," + ")";
        }

        private void next_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage5;
        }
        private void TIPO_DATO(string idx)
        {

            try
            {
                string idnx = cmb_return_tipdat.SelectedIndex.ToString();

                if (idnx == "0")
                {
                    tipo_dato = "VARCHAR2";

                }

                if (idnx == "1")
                {
                    tipo_dato = "DATE";
                }

                if (idnx == "2")
                {
                    tipo_dato = "NUMBER";
                }

                if (idnx == "3")
                {
                    tipo_dato = "CHAR";
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_nomfun.Text == "")
            {
                MessageBox.Show("Debe Ingresar Un Nombre para el Procedimiento","PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (checkBox1.Checked)
                {
                    tabControl2.SelectedTab = this.tabPage4;
                    aceptar.Visible = true;
                }
                else {
                    tabControl2.SelectedTab = this.tabPage5;
                    aceptar.Visible = true;
                }
            }

            txt_nomfun2.Text = txt_nomfun.Text;
            txt_nomfun3.Text = txt_nomfun.Text;
            string idnx = cmb_return_tipdat.SelectedIndex.ToString();
            TIPO_DATO(idnx);
            txt_retunrtipdat.Text = tipo_dato;
            txt_tipodato3.Text = tipo_dato;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            string indx = cmb_return_tipdat.SelectedIndex.ToString();
            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            con.Open();
            TIPO_DATO(indx);
            Lee_grid();
            string query = "";

            if (checkBox1.Checked)
            {
                query = "create or replace procedure\"" + txt_nomfun.Text + "\"" + "\n" + argumentos + "\n" + " return " + tipo_dato + "\n" + " is " + "\n" + " begin " + textBox4.Text + "\n" + " end;";
            }
            else
            {
                query = "create or replace procedure\"" + txt_nomfun.Text + "\n" + "\"" + " return " + tipo_dato + "\n" + " is " + "\n" + " begin " + textBox4.Text + "\n" + " end;";
            }

            OracleCommand cmd = new OracleCommand(query, Form1.conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha Creado el Procedimiento " + txt_nomfun.Text, "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_func.Items.Clear();
                /*Cargar_Funciones();*/
                INICIO();
                tabControl2.SelectedTab = this.tabPage3;


            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message.ToString());
            }

            MessageBox.Show(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "drop FUNCTION\"" + cmb_func.GetItemText(cmb_func.SelectedItem) + "\"";
            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            con.Open();

            OracleCommand cmd = new OracleCommand(sql, Form1.conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha Eliminado la Funcion " + cmb_func.GetItemText(cmb_func.SelectedItem), "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_func.Items.Clear();
                Cargar_Procedures();
                textBox1.Text = sql;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Visible == false)
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        }
    }
}
