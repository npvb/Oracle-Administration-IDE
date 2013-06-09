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
    public partial class Form3 : Form
    {
        public Form2 forma3;
        string nombretabla = "";
        public string nomtabladrop = "";
        public string tipodatodrop = "";
        string null_mod = "";
        string tipo_mod = "";
    
        
        
        public Form3(Form2 p)
        {
            InitializeComponent();
            p = forma3;
        }
        public string parametro = "";

       private void CargaTablasOracle(){

           OracleConnection con = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

           try
           {
               con.Open();
               OracleCommand cmd = new OracleCommand("Select table_name from user_tables", con);

               OracleDataReader dr = cmd.ExecuteReader();


               tb_nomus_drop.Text = Form1.user;
               nom_us_dt.Text = Form1.user;
               tb_obj.Text = "TABLE";

               while (dr.Read())
               {
                   cmbo_tabla2.Items.Add(dr.GetOracleValue(0).ToString());
                   cmb_tabladropc.Items.Add(dr.GetOracleValue(0).ToString()); 
                   cmb_dropt.Items.Add(dr.GetOracleValue(0).ToString());
                   cmb_tablaref.Items.Add(dr.GetOracleValue(0).ToString());
                   cmb_nomtabla_mod.Items.Add(dr.GetOracleValue(0).ToString());
                   


               }
               dr.Close();
             // MessageBox.Show(cmb_tabladropc.Items.Count.ToString());
              
              
           }
           catch (Exception ex)
           {

               MessageBox.Show(ex.ToString());

           }
           finally
           {
               con.Close();
           }

           //carga los views

        /*   OracleConnection cone = new OracleConnection("Data Source= XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");

           try
           {
               string view = "Select view_name from user_views";

               cone.Open();
               OracleCommand cmd = new OracleCommand(view, cone);

               OracleDataReader dr = cmd.ExecuteReader();

               while(dr.Read()){
                   cmb_sec.Items.Add(dr.GetOracleValue(0));
               }

               dr.Close();

           }catch(Exception err){
               MessageBox.Show("Error: "+err.Message.ToString(),"PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
           
           }*/

           string valor_tabla = "Select Table_name From user_tables";

           Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
           Form1.conn.Open();
           OracleDataAdapter adapter = new OracleDataAdapter(valor_tabla, Form1.conn);
           DataTable tabla = new DataTable();
           adapter.Fill(tabla);

           cmb_tabla.DataSource = tabla;
           cmb_tabla.DisplayMember = tabla.Columns["Table_name"].ToString();



          /* Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
           Form1.conn.Open();
           try
           {
               OracleCommand cmd = new OracleCommand("Select table_name from user_tables", Form1.conn);
               OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   // cmb_tabladropc.Items.Add(dr.GetOracleValue(0).ToString());
                   // lstTablaD.Items.Add(dr.GetOracleValue(0).ToString());

                }
                dr.Close();

           }
           catch (Exception ex)
           {

               MessageBox.Show(ex.ToString());

           }
          */
           
       }

        private void Inicio(){
            CargaTablasOracle();
            ok_button.Visible = false; 
            next.Enabled = false;
            button5.Enabled = false;
            dataGridView1.Visible = false;
            txb_sql.Visible = false;
            tb_dropt.Visible = false;
            txt_schemamod.Text = Form1.user;
            VOIDS();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Inicio();

            
        }

     
       

        private void creartabla_Click(object sender, EventArgs e)
        {
           textBox1.Text = nomtabla.Text;
           text_rest.Text = nombretabla + "_PK";
           tabControl2.SelectedTab = this.tabPage4;
           VOIDS();       
         
        }

        private void nomtabla_TextChanged(object sender, EventArgs e)
        {
            nombretabla= nomtabla.Text.ToUpper();
          
            ok_button.Visible = true;
            next.Enabled = true;
            dataGridView1.Visible = true;
            button5.Enabled = true;
            
         
        }

       

        private void fill_newsec_CheckedChanged(object sender, EventArgs e)
        {

            //textBox1.Text = nomtabla.Text;
           /* cmb_pk.Items.Clear();
            cmb_sec.Items.Clear();
            cmb_pk_comp.Items.Clear();

            if (fill_newsec.Checked)
            {

                grupo_sec_new.Visible = true;
                text_rest.Visible = true;
                lbl_sqc.Visible = true;
                combo_pk.Visible=true;

                txt_rest.Text = nomtabla.Text + "_PK";
                lbl_sqc.Text = nomtabla.Text + "_SEQ";

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string valor = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    combo_pk.Items.Add(valor);
                }

            }*/
        }

        private void next2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage5;
            Carga_Cols();
            textBox4.Text = nomtabla.Text+"_fk";

        }


        private void Creacion_Tabla(){

            string tipo_campo, nombre,  nulo; 
            int pre=4000;
            string  precision=pre.ToString();
            string escala = pre.ToString();

            string parametro = "CREATE TABLE \"" + nombretabla + "\"(";
              string parametro2 = "CREATE SEQUENCE ";
              string parametro3 = "ALTER TABLE \"" + nombretabla + "\"" + " add constraint ";

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if ((x > 0) && (x < dataGridView1.Rows.Count))
                    parametro += ",";

                tipo_campo = dataGridView1.Rows[x].Cells["Tipo_Campo"].Value.ToString();
                nombre = dataGridView1.Rows[x].Cells["Nombre_Campo"].Value.ToString();
                nulo = (dataGridView1.Rows[x].Cells["Null"].Value.ToString());

                if (tipo_campo == "NUMBER")
                {
                   // this.dataGridView1.Columns["Precision"].DefaultCellStyle.Format = "1";
                   // dataGridView1.Rows[x].Cells["Precision"].v";
                   precision = dataGridView1.Rows[x].Cells["Precision"].Value.ToString(); 
                    escala = dataGridView1.Rows[x].Cells["Scale"].Value.ToString();

                    parametro += "\"" + nombre + "\"" + " " + tipo_campo + "(" + precision + "," + escala + ")" + nulo;
                }

                if (tipo_campo == "VARCHAR2" || tipo_campo == "CHAR")
                {
                    int ya = 0;
                    precision = ya.ToString();
                    
                    escala = dataGridView1.Rows[x].Cells["Scale"].Value.ToString();
                    parametro += "\"" + nombre + "\"" + " " + tipo_campo + "(" + escala + ")" + nulo;
                }

                if (tipo_campo == "DATE")
                {

                    int xi = 0;
                    escala = xi.ToString();
                    precision = xi.ToString();

                    parametro += "\"" + nombre + "\"" + " " + tipo_campo + " " + nulo;
                }

            }

            if (no_fill.Checked)
                parametro3 += "\"" + txt_rest.Text + "\"" + " primary key(" + "\"" + cmb_pk.GetItemText(cmb_pk.SelectedItem) + "\"" + "," + "\"" + cmb_pk_comp.GetItemText(cmb_pk_comp.SelectedItem) + "\")";


            if (fill_newsec.Checked)
            {
                parametro += "," + "constraint " + "\"" + text_rest.Text + "\"" + " primary key(" + "\"" + combo_pk.GetItemText(combo_pk.SelectedItem) + "\")";
                parametro2 += "\"" + lbl_sqc.Text + " \"";
            }

            if (fillexissec.Checked)
            {
                parametro += "," + "constraint " + "\"" + txt_rest.Text + "\"" + " primary key(" + "\"" + cmb_pk.GetItemText(cmb_pk.SelectedItem) + "\")";
               
            }

    //llaves foraneas
            string col = null;
            string col2=null;
            for (int x = 0; x < key_col.Items.Count; x++)
            {

                col += "\"" + key_col.Items[x] + "\"" + ",";
            }
                
              for (int xi = 0; xi < listBox1.Items.Count;xi++ )
            {
            col2 += "\"" + listBox1.Items[xi] + "\"" + ",";
            }

            parametro3 = "\"" + textBox4.Text + "\"" + " FOREIGN KEY(" + col + ")" + " REFERENCES " + "\"" + cmb_tablaref.GetItemText(cmb_tablaref.SelectedItem) + "\"" + "(\"" + col2;



            parametro += ")";
            parametro3 += ")";
            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();
            OracleCommand cmd = new OracleCommand(parametro, Form1.conn);
            OracleCommand cmd2 = new OracleCommand(parametro2, Form1.conn);
             OracleCommand cmd3 = new OracleCommand(parametro3, Form1.conn);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha creado tabla " + nombretabla, "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // MessageBox.Show(parametro3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Form1.conn.Close();
            }




        }

       

        private void npk_CheckedChanged(object sender, EventArgs e)
        {
            
            cmb_pk.Items.Clear();
            cmb_sec.Items.Clear();
            cmb_pk_comp.Items.Clear();

            if (npk.Checked)
            {
                VOIDS();

            }
        }

        public void VOIDS() {

            text_rest.Visible = false;
            lbl_sqc.Visible = false;
            combo_pk.Visible = false;
            txt_rest.Visible = false;
            cmb_sec.Visible = false;
            cmb_pk.Visible = false;
            cmb_pk_comp.Visible = false;
            grupo_sec_new.Visible = false;
            groupBox1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
      
        }

       

       

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add();
        }

      

        private void vertabla_Click(object sender, EventArgs e)
        {
             try
                {
                string sql = "Select * from " + "\"" + cmb_tabla.GetItemText(cmb_tabla.SelectedItem) + "\"";

                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();
                OracleCommand cmd = new OracleCommand(sql, Form1.conn);

                OracleDataAdapter adapter = new OracleDataAdapter(sql, Form1.conn);

                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView2.DataSource = tabla;

                OracleDataReader dr1 = cmd.ExecuteReader();
               


                    /*  while (dr1.Read())
                      {
                         combo_campos.Items.Add(dr1.GetOracleValue(0).ToString()); 

                      }
                      dr1.Close();*/


                    // MessageBox.Show("Puede Ingresar Nuevos Campos a la Tabla","Proyecto TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message);
                    Form1.conn.Close();

                }
            

           
        }

        private void new_campo_Click(object sender, EventArgs e)
        {
            string new_campo = "";

            if(varchar.Checked){
                new_campo = "\"" + nom_campo_new.Text + "\"" + "VARCHAR2" + "( " + scale_new.Text + ")" + comboBox1.Text + " ) ";
                
            }

            if(charac.Checked){
                new_campo = "\"" + nom_campo_new.Text + "\"" + "CHAR" + "( " + scale_new.Text + ")" + comboBox1.Text + " ) ";
                precision_new.Visible = false;
            }

            if(date.Checked){
                new_campo = "\"" + nom_campo_new.Text + "\"" + "DATE" + comboBox1.Text + " ) ";
                precision_new.Visible = false;
                scale_new.Visible = false;
            }
            if(number.Checked){
                int p=1;
                    int s=38;
                
                    
                if (precision_new.Text == "" && scale_new.Text == "")
                {
                    
                    precision_new.Text = p.ToString();
                    scale_new.Text = s.ToString();
                }
                new_campo = "\"" + nom_campo_new.Text + "\"" + "NUMBER" + " ( " + precision_new.Text + "," + scale_new.Text + " ) " + comboBox1.Text + " ) ";
            }


            string comando = "alter table \"" + cmbo_tabla2.GetItemText(cmbo_tabla2.SelectedItem).ToString() + "\" add (" + new_campo;

            MessageBox.Show("Se ha agregado el Campo "+nom_campo_new.Text,"PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
            MessageBox.Show(comando);

            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();

            try
            {

                OracleCommand cmd = Form1.conn.CreateCommand();

                cmd.CommandText = comando;
                cmd.ExecuteNonQuery();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }

        }

        private void number_CheckedChanged(object sender, EventArgs e)
        {
            if (number.Checked)
            {

                precision_new.Visible = true;
                precision_new.Text = "1";
                scale_new.Text = "38";
            }

           
        }

        private void varchar_CheckedChanged(object sender, EventArgs e)
        {
            if (varchar.Checked)
            {


                precision_new.Visible = false; 
                scale_new.Text = "4000";
            }

        }

       

        private void charac_CheckedChanged(object sender, EventArgs e)
        {
            precision_new.Visible = false; 
            scale_new.Text = "100";
        }

        private void Carga_Cols() {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string datos = dataGridView1.Rows[i].Cells[0].Value.ToString();
                lst_keycol.Items.Add(datos);
            }


        }
        private void cmb_tabladropc_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
              {
                 Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                  Form1.conn.Open();

                  nomtabladrop = cmb_tabladropc.GetItemText(cmb_tabladropc.SelectedItem).ToUpper();
                 

                  string sql = "Select column_name from user_tab_cols where table_name= " + "'" +nomtabladrop + "'";
                  OracleDataAdapter adapter = new OracleDataAdapter(sql, Form1.conn);
                  DataTable tabla = new DataTable();
                  adapter.Fill(tabla);

                  OracleCommand cmd1 = new OracleCommand(sql, Form1.conn);

                  OracleDataReader d = cmd1.ExecuteReader();

                  while (d.Read())
                  {

                      cmb_columna_dropc.Items.Add(d.GetOracleValue(0).ToString());
                  }
                  d.Close();

              }catch(Exception err){
                  MessageBox.Show(err.Message);


              }

        }

        private void drop_column_Click(object sender, EventArgs e)
        {
           


        }

        private void cmb_columna_dropc_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipodatodrop = cmb_columna_dropc.GetItemText(cmb_columna_dropc.SelectedItem);
           // cmb_tabla.GetItemText(cmb_tabla.SelectedItem)
            MessageBox.Show(nomtabladrop);
        }

        private void Sacar_lst() {

            int c = key_col.Items.Count;
            MessageBox.Show(c.ToString());
        }

        private void drop_column_Click_1(object sender, EventArgs e)
        {
            /*alter table "BOAT" drop column
            "naville"*/
           // MessageBox.Show("entro");
            string comando = "alter table \"" + nomtabladrop + "\" drop column \"" + tipodatodrop +"\"";
            //MessageBox.Show(comando);

           Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();
            //MessageBox.Show(comando);

            try
            {

                OracleCommand cmd = Form1.conn.CreateCommand();

                cmd.CommandText = comando;
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Columna "+tipodatodrop+" ha sido Eliminada","PROYECTO TDB1",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }

            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
        }

        private void sql_Click(object sender, EventArgs e)
        {
            if (txb_sql.Visible == false)
            {
                txb_sql.Visible = true;
                string comando = "alter table \"" + nomtabladrop + "\" drop column \"" + tipodatodrop + "\"";
                txb_sql.Text = comando;
            }
            else {
                txb_sql.Visible = false;
            }
        }

     

        private void drop_table_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cmb_dropt.GetItemText(cmb_dropt.SelectedItem));
            string comando = "drop TABLE \"" + cmb_dropt.GetItemText(cmb_dropt.SelectedItem) + "\"";
         //  MessageBox.Show(comando);
            string tab = cmb_dropt.GetItemText(cmb_dropt.SelectedItem);

            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();
            //MessageBox.Show(comando);

            try
            {

                OracleCommand cmd = Form1.conn.CreateCommand();

                cmd.CommandText = comando;
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Tabla " + tab + " ha sido Eliminada", "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbo_tabla2.Items.Clear();
                cmb_tabladropc.Items.Clear();
                cmb_dropt.Items.Clear();
                cmb_tablaref.Items.Clear();
                CargaTablasOracle();
            }

            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
        }

        private void sql_dropt_Click(object sender, EventArgs e)
        {
            if( tb_dropt.Visible == false){
            tb_dropt.Visible = true;
            string comando = "drop TABLE \"" + cmb_dropt.GetItemText(cmb_dropt.SelectedItem) + "\"";
            tb_dropt.Text = comando;
        }else{
            tb_dropt.Visible = false;
        }

        }

        private void text_rest_TextChanged(object sender, EventArgs e)
        {
        }

        private void fill_newsec_CheckedChanged_1(object sender, EventArgs e)
        {
            VOIDS();
                grupo_sec_new.Visible = true;
                text_rest.Visible = true;
                lbl_sqc.Visible = true;
                combo_pk.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;

                txt_rest.Text = nomtabla.Text + "_PK";
                lbl_sqc.Text = nomtabla.Text + "_SEQ";

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string valor = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    combo_pk.Items.Add(valor);
                }

        }

        private void fillexissec_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {

                // textBox1.Text = nomtabla.Text;
               /* cmb_pk.Items.Clear();
                cmb_sec.Items.Clear();
                cmb_pk_comp.Items.Clear();*/
                VOIDS();

               
                    grupo_sec_new.Visible = false;
                    text_rest.Visible = false;
                    lbl_sqc.Visible = false;
                    combo_pk.Visible = false;
                    cmb_pk_comp.Visible = false;
                    label7.Visible = false;

                    groupBox1.Visible = true;
                    txt_rest.Visible = true;
                    cmb_sec.Visible = true;
                    cmb_pk.Visible = true;
                    
                    label5.Visible = true;
                    label4.Visible = true;
                    label6.Visible=true;

                    txt_rest.Text = nomtabla.Text + "_PK";
                    lbl_sqc.Text = nomtabla.Text + "_SEQ";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string valor = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        cmb_pk.Items.Add(valor);
                    }

                    string valor2 = "Select Sequence_name From user_sequences";

                    Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                    Form1.conn.Open();

                    OracleCommand cmd = new OracleCommand(valor2, Form1.conn);
                    OracleDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        cmd.ExecuteNonQuery();
                        cmb_sec.Items.Add(dr.GetOracleValue(0));
                    }
                    dr.Close();
                   /* OracleDataAdapter adapter = new OracleDataAdapter(valor2, Form1.conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    cmb_sec.DataSource = tabla;
                    cmb_sec.DisplayMember = tabla.Columns["Sequence_name"].ToString();*/

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void no_fill_CheckedChanged_1(object sender, EventArgs e)
        {
            //MessageBox.Show("falta fucking esto!");
             try
            {
                VOIDS();
                 groupBox1.Visible = true;
                    txt_rest.Visible = true;
                    label5.Visible = true; 
                    label6.Visible = false;
                    label7.Visible = true;
                    label4.Visible = true;
                    cmb_sec.Visible = true;
                    cmb_pk.Visible = false;
                    cmb_pk_comp.Visible = true; ;

                  //  txt_rest.Text = nomtabla.Text + "_PK";
                   // lbl_sqc.Text = nomtabla.Text + "_SEQ";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string valor = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        cmb_pk.Items.Add(valor);
                    }

                    string valor2 = "Select Sequence_name From user_sequences";

                    Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                    Form1.conn.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter(valor2, Form1.conn);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    cmb_sec.DataSource = tabla;
                    cmb_sec.DisplayMember = tabla.Columns["Sequence_name"].ToString();

                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void npk_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            grupo_sec_new.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            label18.Visible = false;
            combo_pk.Visible = false;
            txt_rest.Visible = false;
            lbl_sqc.Visible = false;
            text_rest.Visible = false;
            cmb_sec.Visible = false;
            cmb_pk.Visible = false;
            cmb_pk_comp.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;


        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_keycol.Items.Count > 0)
                {
                    key_col.Items.Add(lst_keycol.SelectedItem.ToString());
                    lst_keycol.Items.RemoveAt(lst_keycol.SelectedIndex);

                }
                else
                    MessageBox.Show("No tiene elementos a seleccionar", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception er){
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN CAMPO O TIENE EL SIGUIENTE ERROR: " + er.Message, "PROYECTO TDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (key_col.Items.Count > 0)
                {
                    lst_keycol.Items.Add(key_col.SelectedItem.ToString());
                    key_col.Items.RemoveAt(key_col.SelectedIndex);

                }
                else
                    MessageBox.Show("No tiene elementos a seleccionar", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN CAMPO O TIENE EL SIGUIENTE ERROR: " + er.Message, "PROYECTO TDB", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void cmb_tablaref_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string nom_ref = cmb_tablaref.GetItemText(cmb_tablaref.SelectedItem).ToUpper();

            try
              {
                 Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                  Form1.conn.Open();      

                  string sql = "Select column_name from user_tab_cols where table_name= " + "'" +nom_ref + "'";
                  OracleDataAdapter adapter = new OracleDataAdapter(sql, Form1.conn);
                  DataTable tabla = new DataTable();
                  adapter.Fill(tabla);

                  OracleCommand cmd1 = new OracleCommand(sql, Form1.conn);

                  OracleDataReader d = cmd1.ExecuteReader();

                  while (d.Read())
                  {

                      listBox2.Items.Add(d.GetOracleValue(0).ToString());
                  }
                  d.Close();

              }catch(Exception err){
                  MessageBox.Show(err.Message);


              }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.Items.Count > 0)
                {
                    listBox1.Items.Add(listBox2.SelectedItem.ToString());
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);

                }
                else
                    MessageBox.Show("No tiene elementos a seleccionar", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN CAMPO O TIENE EL SIGUIENTE ERROR: " + er.Message, "PROYECTO TDB", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItem.ToString());
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                }
                else
                    MessageBox.Show("No tiene elementos a seleccionar", "Proyecto TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR: DEBE SELECCIONAR UN CAMPO O TIENE EL SIGUIENTE ERROR:  " + er.Message, "PROYECTO TDB", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = this.tabPage4;
            lst_keycol.Items.Clear();
            key_col.Items.Clear();

        }

        
        private void ok_button_Click_1(object sender, EventArgs e)
        {
            Creacion_Tabla();
            cmbo_tabla2.Items.Clear();
            cmb_tabladropc.Items.Clear();
            cmb_dropt.Items.Clear();
            cmb_tablaref.Items.Clear();
            cmb_nomtabla_mod.Items.Clear();
           // CargaTablasOracle();
            tabControl2.SelectedTab = this.tabPage3;
            nomtabla.Text = "";
            Inicio();
            
        }

        private void cmb_nomtabla_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmb_nul_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            null_mod = cmb_nul_mod.GetItemText(cmb_nomtabla_mod.SelectedItem);
        }

        private void TIPO(string idx) {
            string mod_campo = "";
           // string n = cmb_tipo_mod.SelectedIndex.ToString();

            if (tipo_mod == "0")
            {
                mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "VARCHAR2" + "( " + txt_long_mod.Text + ")" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = true;
            }

            if (tipo_mod== "1")
            {
                mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "DATE" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = false;
            }

            if (tipo_mod == "2")
            {

                mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "NUMBER" + " ( " + txt_pre_mod.Text + "," + txt_sc_mod.Text + " ) " + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = true;
                txt_sc_mod.Enabled = true;
                txt_long_mod.Enabled = false;
            }


            if (tipo_mod == "3")
            {
                mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "CHAR" + "( " + txt_sc_mod.Text + ")" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = true;
            }




            string sql = "alter table \"" + cmb_nomtabla_mod.GetItemText(cmb_nomtabla_mod.SelectedItem).ToString() + "\" modify (" + mod_campo;
            MessageBox.Show(sql);
            Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
            Form1.conn.Open();
            OracleCommand cmd = new OracleCommand(sql, Form1.conn);

            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha Modificado la Tabla " + cmb_nomtabla_mod.GetItemText(cmb_nomtabla_mod.SelectedItem), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception er)
            {
                MessageBox.Show("ERROR: " + er.Message.ToString(), "PROYECTO TDB1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void button8_Click(object sender, EventArgs e)
        {
 

            string n=cmb_tipo_mod.SelectedIndex.ToString();
            TIPO(n);

          

        }

        private void cmb_tipo_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_mod = cmb_tipo_mod.SelectedIndex.ToString();
                //cmb_tipo_mod.GetItemText(cmb_tipo_mod.SelectedItem);

            if (tipo_mod == "0")
            {
                //"\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "VARCHAR2" + "( " + txt_long_mod.Text + ")" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = true;
            }
            if (tipo_mod == "1")
            {
               // mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "DATE" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = false;
            }

            if (tipo_mod == "2")
            {

               // mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "NUMBER" + " ( " + txt_pre_mod.Text + "," + txt_sc_mod.Text + " ) " + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = true;
                txt_sc_mod.Enabled = true;
                txt_long_mod.Enabled = false;
            }


            if (tipo_mod == "3")
            {
               // mod_campo = "\"" + cmb_nomcol_mod.GetItemText(cmb_nomcol_mod.SelectedItem) + "\"" + "CHAR" + "( " + txt_sc_mod.Text + ")" + cmb_nul_mod.GetItemText(cmb_nul_mod.SelectedItem) + " ) ";
                txt_pre_mod.Enabled = false;
                txt_sc_mod.Enabled = false;
                txt_long_mod.Enabled = true;
            }

        }

        private void cmb_nomtabla_mod_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();

                string sql = "Select column_name from user_tab_cols where table_name= " + "'" + cmb_nomtabla_mod.GetItemText(cmb_nomtabla_mod.SelectedItem) + "'";

                OracleCommand cmd1 = new OracleCommand(sql, Form1.conn);

                OracleDataReader d = cmd1.ExecuteReader();

                while (d.Read())
                {

                    cmb_nomcol_mod.Items.Add(d.GetOracleValue(0).ToString());
                }
                d.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);


            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


   

       

       
        


      


       

       

       

      
       

        
    }
}
