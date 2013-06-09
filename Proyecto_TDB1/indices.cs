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
    public partial class indices : Form
    {
        public Form2 index;
        public string nom_tabla=" ";
        public string col1 = null;
        public string col2 = null;
        public string col3 = null;
        public string col4 = null;
        string parametro = "";

        public indices()
        {
            InitializeComponent();
           // p = index;
        }
        private void Carga_Columnas() {
            try {

                OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");     
                string col = "Select column_name from user_tab_cols where table_name= " + "'" + nom_tabla + "'";

                con.Open();
                OracleCommand cmd = new OracleCommand(col, con);

                OracleDataReader dr = cmd.ExecuteReader();
                
                while(dr.Read()){
                    cmb_col1.Items.Add(dr.GetOracleValue(0).ToString());
                    cmb_col2.Items.Add(dr.GetOracleValue(0).ToString());
                    cmb_col3.Items.Add(dr.GetOracleValue(0).ToString());
                    cmb_col4.Items.Add(dr.GetOracleValue(0).ToString());
                }
                dr.Close();

            }catch(Exception e){
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void Carga_Indices() {

            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
        string query="select index_name from user_indexes";

        try
        {
            con.Open();
            OracleCommand cmd = new OracleCommand(query, con);

            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmb_indice.Items.Add(dr.GetOracleValue(0).ToString());
                //cmb_elim.Items.Add(dr.GetOracleValue(0).ToString());
            }

            dr.Close();

        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message);
        }
        }
        private void Carga_Tablas()
        {

            OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            string table = "Select Table_name From user_tables";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(table, con);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_tabla1.Items.Add(dr.GetOracleValue(0).ToString());
                    //cmb_elim.Items.Add(dr.GetOracleValue(0).ToString());
                }

                dr.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void indices_Load(object sender, EventArgs e)
        {
            Carga_Tablas();
            Carga_Indices();
            txb_schema.Text = Form1.user;
            txt_schema3.Text = Form1.user;
            txt_objtp.Text = "INDEX";
            txt_sql.Visible = false;
            txtsquery.Visible = false;
       
            
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {

        }

        private void bt_next_Click(object sender, EventArgs e)
        {
           // nom_tabla = cmb_tabla1.GetItemText(cmb_tabla1.SelectedItem);
            if(rb_normal.Checked){
            tabControl2.SelectedTab = this.tabPage4;
            try
            {
                
                txt_schema2.Text = Form1.user;
                txt_nomtabla.Text = nom_tabla;
                txt_nomindex.Text = nom_tabla + "_IDX";
                button5.Visible = false;
                //Carga_Columnas();
              
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                label4.Text = "**LA TABLA DEBE EXISTIR";
                label4.ForeColor = System.Drawing.Color.Red;
            }
            }

            if(rb_texto.Checked){
                tabControl2.SelectedTab = this.tabPage4;
                txt_schema2.Text = Form1.user;
                txt_nomtabla.Text = nom_tabla;
                txt_nomindex.Text = nom_tabla + "_CTX";
                label9.Visible = false;
                label11.Visible=false;
                label12.Visible=false;
                label10.Visible = false;
                cmb_unik.Visible = false;
                cmb_col2.Visible = false;
                cmb_col3.Visible = false;
                cmb_col4.Visible = false;
                button1.Visible = false;
                button5.Visible = true;
               //Carga_Columnas();

            }
        }
        private void CLEAN_COMBO() {
            cmb_col1.Items.Clear();
            //cmb_col1.Text = "";
            cmb_col2.Items.Clear();
            //cmb_col2.Text = "";
            cmb_col3.Items.Clear();
            //cmb_col3.Text = "";
            cmb_col4.Items.Clear();
           // cmb_col4.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage3;
            CLEAN_COMBO();
           
        }

       

        private void INDEX(string aut_pos) {

            OracleConnection con = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
             

            if (aut_pos == "0")
            {
                MessageBox.Show("ENTRO CON NOT UNIQUE");
              
               parametro = "create index \"" + txt_nomindex.Text + "\" on \"" + nom_tabla + "\"(";
              
               if(col1!=null){
                parametro +=  "\"" + col1 + "\"";
               }
                if(col2!=null){
                    parametro +=   "," +"\"" +col2 + "\"";
                }
                if(col3!=null){
                    parametro += "," + "\"" + col3 + "\"";
                }
                if(col4!=null){
                    parametro += "," + "\"" + col4 + "\"";
                }
                
                parametro += ")";
                MessageBox.Show(parametro);
            }

            if (aut_pos == "1")
            {
                MessageBox.Show("ENTRO CON UNIQUE");

                parametro = "create UNIQUE index \"" + txt_nomindex.Text + "\" on \"" + nom_tabla + "\"(";

                if (col1 != null)
                {
                    parametro += "\"" + col1 + "\"";
                }
                if (col2 != null)
                {
                    parametro += "," + "\"" + col2 + "\"";
                }
                if (col3 != null)
                {
                    parametro += "," + "\"" + col3 + "\"";
                }
                if (col4 != null)
                {
                    parametro += "," + "\"" + col4 + "\"";
                }

                parametro += ")";
                MessageBox.Show(parametro);
            }


            OracleCommand cmd = new OracleCommand(parametro, con);
            try {
                
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El Indice "+txt_nomindex.Text+" ha sido Creado!","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }catch(Exception err){
                MessageBox.Show(err.Message.ToString(),"Proyecto TBD1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string aut_posi = cmb_unik.SelectedIndex.ToString();
          
            INDEX(aut_posi);
          
        }

        private void cmb_col1_SelectedIndexChanged(object sender, EventArgs e)
        {
            col1 = cmb_col1.Text;
            //parametro += "(" +"\""+col1+"\"";
            
        }

        private void cmb_col2_SelectedIndexChanged(object sender, EventArgs e)
        {
            col2 = cmb_col2.Text;
            //parametro += "(" + col2;
            
        }

        private void cmb_col3_SelectedIndexChanged(object sender, EventArgs e)
        {
            col3 = cmb_col3.Text;
           // parametro += "(" + col3;
           
        }

        private void cmb_col4_SelectedIndexChanged(object sender, EventArgs e)
        {
            col4 = cmb_col4.Text;
            //parametro += "(" + col4;
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            txt_sql.Text = parametro;

            if (txt_sql.Visible== false)
            {
                txt_sql.Visible = true;
            }
            else {
                txt_sql.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
           /* Form2 f = new Form2();
            
            f.ShowDialog();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OTRO BOTON");
            /*create index "BOAT_CTX1"
             on "BOAT" ("BOAT_NAME")
            indextype is ctxsys.context*/
            OracleConnection con = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

            string query = "create index \"" + txt_nomindex.Text + "\" on \"" + txt_nomtabla.Text + "\"(\"" + col1 + "\")" + "indextype is ctxsys.context";
            MessageBox.Show(query);

            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                 con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El Indice " + txt_nomindex.Text + " ha sido Creado!", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sql.Text = query;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR: \n"+err.Message.ToString(), "Proyecto TBD1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }

        private void cmb_tabla1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nom_tabla = cmb_tabla1.GetItemText(cmb_tabla1.SelectedItem);
            Carga_Columnas();
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection con = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

            string query = "drop INDEX  \""+cmb_indice.GetItemText(cmb_indice.SelectedItem)+"\"";
            MessageBox.Show(query);

            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("El Indice " + cmb_indice.GetItemText(cmb_indice.SelectedItem) + " ha sido Eliminado!", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsquery.Text = query;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR: \n" + err.Message.ToString(), "Proyecto TBD1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtsquery.Visible == false)
            {
                txtsquery.Visible = true;
            }
            else {
                txtsquery.Visible = false;
            }
        }

        private void cmb_unik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
      
      

       
        



       

    }
}
