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
    
    public partial class sequences : Form
    {
        public string nomseq = "";
        public string empieza_con = "";
        public string valor_min = "";
        public string valor_max = "";
        public string aumenta_por = "";
        public string cache = "";
        public string cycle = "";
        public string order = "";
        public string cache2 = "";
        string cycle2 = "";
        string order2 = "";

        public sequences()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CARGAR_SECUENCIAS() {

            string valor2 = "Select Sequence_name From user_sequences";

            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();

            OracleCommand cmd = new OracleCommand(valor2, Form1.conn);
            OracleDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {

                    cmd.ExecuteNonQuery();
                    cmb_nomsec.Items.Add(dr.GetOracleValue(0));
                    cmb_nomsec2.Items.Add(dr.GetOracleValue(0));
                }
                dr.Close();
            }catch(Exception err){
                MessageBox.Show(err.Message.ToString());
            }
        
        }
        void Inicio() {
            txt_schema.Text = Form1.user;
            txt_cache.Text = "nocache";
            cycle = "nocycle";
            order = "noorder";
            txt_schema2.Text = Form1.user;
            cache2 = "nocache";
            order2 = "noorder";
            cycle2 = "nocycle";
            txt_schema3.Text = Form1.user;
            txt_obj.Text = "Secuencias";
            

        }
        private void sequences_Load(object sender, EventArgs e)
        {
            Inicio();
            CARGAR_SECUENCIAS();
        }

        private void button1_Click(object sender, EventArgs e)
        {//||
            if (nomseq == "")
            {
                MessageBox.Show("NOMBRE DE SECUENCIA INVALIDO" + nomseq, "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query = "create sequence\"" + nomseq + "\"" + " start with " + empieza_con + " maxvalue " + valor_max + " minvalue " + valor_min +"\n"+ cache +"\n"+ cycle +"\n"+ order;
                // string query = nomseq +" "+ empieza_con +" "+ valor_max +" "+ valor_min +" "+ aumenta_por +" "+ cache +" "+ cycle+" " + order;
                MessageBox.Show(query);

                  OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                  con.Open();
                     OracleCommand cmd = new OracleCommand(query, con);
                     try
                     {
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Se ha Creado la Secuencia "+nomseq,"PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                         cmb_nomsec.Items.Clear();
                         cmb_nomsec2.Items.Clear();
                         CARGAR_SECUENCIAS();
                     }catch(Exception err){
                         MessageBox.Show("ERROR: " + err.Message.ToString(), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     } 
            }
        
        }

        private void chb_cycle_CheckedChanged(object sender, EventArgs e)
        {
            
            cycle = "cycle";
      
        }

        private void chb_order_CheckedChanged(object sender, EventArgs e)
        {
            
            order = "order";
           
        }

        private void txtnom_sec_TextChanged(object sender, EventArgs e)
        {
            nomseq = txtnom_sec.Text+"_SEQ";
        }

        private void txt_empieza_TextChanged(object sender, EventArgs e)
        {
            empieza_con = txt_empieza.Text;
        }

        private void txt_min_TextChanged(object sender, EventArgs e)
        {
            valor_min = txt_min.Text;
        }

        private void txt_valorax_TextChanged(object sender, EventArgs e)
        {
            valor_max = txt_valorax.Text;
        }

        private void txt_aumpor_TextChanged(object sender, EventArgs e)
        {
            aumenta_por = txt_aumpor.Text;
        }

        private void txt_cache_TextChanged(object sender, EventArgs e)
        {
           
                cache = "cache "+txt_cache.Text;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "alter sequence\"" + cmb_nomsec.GetItemText(cmb_nomsec.SelectedItem) + "\"" + " increment by " + txt_empcon.Text + " maxvalue " + txt_max2.Text +"\n"+cache2 +"\n"+ cycle2 +"\n"+ order2;
            MessageBox.Show(query);

             OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                  con.Open();
                     OracleCommand cmd = new OracleCommand(query, con);
                     try
                     {
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Se ha Modificado la Secuencia "+cmb_nomsec.GetItemText(cmb_nomsec.SelectedItem),"PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                         cmb_nomsec.Items.Clear();
                         cmb_nomsec2.Items.Clear();
                         CARGAR_SECUENCIAS();
                     }catch(Exception err){
                         MessageBox.Show("ERROR: " + err.Message.ToString(), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     } 
            }

    
        

        private void txt_cache2_TextChanged(object sender, EventArgs e)
        {
           
                cache2 = "cache "+txt_cache2.Text;
            
        }

        private void ch_cycle_CheckedChanged(object sender, EventArgs e)
        {
            cycle2 = "cycle";
        }

        private void cb_order_CheckedChanged(object sender, EventArgs e)
        {
            order2 = "order";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "drop SEQUENCE\"" + cmb_nomsec2.GetItemText(cmb_nomsec2.SelectedItem) + "\"";

            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            con.Open();
            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha Eliminado la Secuencia " + cmb_nomsec2.GetItemText(cmb_nomsec2.SelectedItem), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_nomsec.Items.Clear();
                cmb_nomsec2.Items.Clear();
                CARGAR_SECUENCIAS();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR: " + err.Message.ToString(), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

        }

        
    }
}
