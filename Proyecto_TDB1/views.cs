using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Drawing;

namespace Proyecto_TDB1
{
    public partial class views : Form
    {
        public Form2 view;
        public string query;
        public views(Form2 p)
        {
            InitializeComponent();
            p = view;
        }
        private void Ver_Views() {
            

           // OracleDataReader dr1 = cmd.ExecuteReader();
            try
            {
                string sql =query;

                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();
                OracleCommand cmd = new OracleCommand(sql, Form1.conn);

                OracleDataAdapter adapter = new OracleDataAdapter(sql, Form1.conn);

                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;

               
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
               // Form1.conn.Close();

            }
        }

        private void Borrar_Views_Combo() { 
        cmb_view1.Items.Clear();
        cmb_elim.Items.Clear();
        }
        private void Carga_Views() {

            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            string view = "Select view_name from user_views";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(view, con);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_view1.Items.Add(dr.GetOracleValue(0).ToString());
                    cmb_elim.Items.Add(dr.GetOracleValue(0).ToString());
                }

                dr.Close();

            }catch(Exception err){
                MessageBox.Show(err.Message);
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
          //  Carga_Views();
        }

        private void bt_okview_Click(object sender, EventArgs e)
        {
            if (txt_nomview.Text == "_VIEW")
            {
                MessageBox.Show("Debe Ingresar Un Nombre al View", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                query = txt_query2.Text;
                string comando = "create or replace view \"" + txt_nomview.Text + "\" as " + query;
                OracleConnection con = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

                OracleCommand cmd = new OracleCommand(comando, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se ha creado view " + "\"" + txt_nomview.Text + "\"", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Ver_Views();
                    Borrar_Views_Combo();
                    Carga_Views();
                    show_viewtbx.Text = txt_nomview.Text;
                    tabControl1.SelectedTab = this.tabPage4;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe Ingresar una Sentencia SQL o tiene el Siguiente Error: \n" + ex.Message.ToString(), "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Form1.conn.Close();
                    System.Drawing.Color clr;
                    clr = System.Drawing.Color.Red;
                    label4.ForeColor = clr;

                }
            }

          
            
        }

        private void views_Load(object sender, EventArgs e)
        {
            txt_schema1.Text = Form1.user;
            txt_nomview.Text = "_VIEW";
            tb_schema2.Text = Form1.user;
            Carga_Views();
            txt_sqlvw.Visible = false;
            tb_schema3.Text = Form1.user;
            tb_objecttype.Text = "VIEW";

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {

            query = txb_sql1.Text;

            string comando = "Create or replace view \"" + cmb_view1.GetItemText(cmb_view1.SelectedItem) + "\" as " + txb_sql1.Text;
            OracleConnection con = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

            OracleCommand cmd = new OracleCommand(comando, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha Editado el View " + "\"" + txt_nomview.Text + "\"", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Ver_Views();
                show_viewtbx.Text = txt_nomview.Text;
                tabControl1.SelectedTab = this.tabPage4;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la Sentencia o tiene el Siguiente Error: \n" + ex.Message.ToString(), "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Form1.conn.Close();
                System.Drawing.Color clr;
                clr = System.Drawing.Color.Red;
                label12.ForeColor = clr;
               

            }
        }

        

        private void cmb_view1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txb_sql1.Text = query;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_sqlvw.Visible == false){
            txt_sqlvw.Visible = true;
            string comando = "drop VIEW \"" + cmb_elim.GetItemText(cmb_elim.SelectedItem) + "\"";
            txt_sqlvw.Text = comando;

            }else{
                txt_sqlvw.Visible = false;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
           
            //Carga_Views();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cmb_elim.GetItemText(cmb_elim.SelectedItem));
            string comando = "drop VIEW \"" + cmb_elim.GetItemText(cmb_elim.SelectedItem) +"\"";
                             
            OracleConnection conn= new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            /*drop VIEW "BOAT_VIEW"*/

            OracleCommand cmd = new OracleCommand(comando, conn);

            try{
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El View " + cmb_elim.GetItemText(cmb_elim.SelectedItem)+" ha sido Eliminado","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Carga_Views();
            }catch(Exception er){
                MessageBox.Show(er.Message);
            }
        }

       
    }
}
