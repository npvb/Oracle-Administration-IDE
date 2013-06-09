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
    public partial class triggers : Form
    {
        public string nombre_tabla = "";
        public string fp = "";
        string opcion = "";
        public string cuerpo = "";
        public string trigger = "";
        string query="";
        public triggers()
        {
            InitializeComponent();
        }
        private void CARGAR_TRIGGERS() {
            string tr_elim = "select trigger_name from user_triggers";

            try
            {


                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();

                OracleCommand cmd = new OracleCommand(tr_elim, Form1.conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while(dr.Read()){
                    cmb_triggers.Items.Add(dr.GetOracleValue(0).ToString());
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message.ToString(), "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void triggers_Load(object sender, EventArgs e)
        {
            string valor_tabla = "Select Table_name From user_tables";

            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();
           
            OracleCommand cmd = new OracleCommand(valor_tabla, Form1.conn);
            OracleDataReader dr = cmd.ExecuteReader();


            txt_schema.Text = Form1.user;
            txt_schema3.Text = Form1.user;
            txt_obj.Text = "TRIGGER";
            CARGAR_TRIGGERS();
            textBox1.Visible = false;
            button3.Visible = false;
           // nom_us_dt.Text = Form1.user;
            //tb_obj.Text = "TABLE";

            while (dr.Read())
            {
                cmb_nomtabla.Items.Add(dr.GetOracleValue(0));

            }
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   if(nombre_tabla==""){
            MessageBox.Show("Debe Seleccionar Una Tabla","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
               
              }else{

            tabControl2.SelectedTab = this.tabPage4;
            txt_schema2.Text = Form1.user;
            txt_tablename.Text = nombre_tabla;
            txt_nomtrig.Text = nombre_tabla+"_TG";
           
            }
        }


         private void B_A(string index) {

            
             Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
             Form1.conn.Open();
            

           
            if(index=="0"){
             trigger = "create or replace trigger \"" + txt_nomtrig.Text + "\"" +"BEFORE " + opcion + " on \"" + nombre_tabla + "\"" + "for each row begin " + cuerpo + " end;";
              
               
            }

             if(index=="1"){
                 trigger = "create or replace trigger \"" + txt_nomtrig.Text + "\"" +"AFTER " + opcion + " on \"" + nombre_tabla + "\"" + "for each row begin " + cuerpo + " end;";
             }

             MessageBox.Show(trigger);
             OracleCommand cmd = new OracleCommand(trigger, Form1.conn);
             try
             {

                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Se ha creado el Trigger " + txt_nomtrig.Text, "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);


             }
             catch (Exception err)
             {
                 MessageBox.Show("ERROR " + err.Message.ToString());
             }


        }


        private void cmb_nomtabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(nombre_tabla==" "){
                MessageBox.Show("Debe Escoger Una Tabla","PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
            nombre_tabla = cmb_nomtabla.GetItemText(cmb_nomtabla.SelectedItem);
            button3.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fp_pos = cmb_fp.SelectedIndex.ToString();
            try { 
            if(cuerpo==""){

                MessageBox.Show("Debe Ingresar El Cuerpo del Trigger","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            } else{

                B_A(fp_pos);
                cmb_triggers.Items.Clear();
                CARGAR_TRIGGERS();

        }//if
            }catch(Exception err){
                MessageBox.Show("Error: " + err.Message.ToString(), "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
        }

        private void cmb_fp_SelectedIndexChanged(object sender, EventArgs e)
        {
            fp = cmb_fp.GetItemText(cmb_fp.SelectedItem);
           
        }

        private void cmb_opt_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = cmb_opt.GetItemText(cmb_opt.SelectedItem);
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            cuerpo = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "drop TRIGGER \"" + cmb_triggers.GetItemText(cmb_triggers.SelectedItem) + "\"";
            //MessageBox.Show(query);

            

                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();

                OracleCommand cmd = new OracleCommand(query, Form1.conn);

                try
                {
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El trigger "+cmb_triggers.GetItemText(cmb_triggers.SelectedItem)+" ha sido Eliminado!","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    cmb_triggers.Items.Clear();
                    CARGAR_TRIGGERS();


            }catch(Exception err){
                MessageBox.Show("ERROR: "+err.Message.ToString(),"PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == false)
            {
                textBox1.Visible = true;
                textBox1.Text = query;
            }
            else {
                textBox1.Visible = false;
            }
        }

      
        

        





    }
}
