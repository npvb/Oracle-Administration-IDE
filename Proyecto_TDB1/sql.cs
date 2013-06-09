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
    public partial class sql : Form
    {
        public sql()
        {
            InitializeComponent();
        }

        private void RUN_Click(object sender, EventArgs e)
        {
            string sql =txt_cmd_sql.Text ;
            try
            {
                Form1.conn = new System.Data.OracleClient.OracleConnection("Data Source=XE; User Id=" + Form1.user + "; Password=" + Form1.pass + ";");
                Form1.conn.Open();
                OracleCommand cmd = new OracleCommand(sql, Form1.conn);
                OracleDataAdapter adapter = new OracleDataAdapter(sql, Form1.conn);

                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;

                OracleDataReader dr1 = cmd.ExecuteReader();
            }catch(Exception err){
                System.Drawing.Color clr;
                clr = System.Drawing.Color.Red; 
                txt_cmd_sql.Text = err.Message.ToString();
                txt_cmd_sql.ForeColor = clr;

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Color clr;
            clr = System.Drawing.Color.Black;
            txt_cmd_sql.Text = "";
            txt_cmd_sql.ForeColor = clr;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
