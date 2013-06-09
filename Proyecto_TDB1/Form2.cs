using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_TDB1
{
    public partial class Form2 : Form 
    {
        //public Form1 Padre;
      
        public Form2()
        {
            InitializeComponent();
           
        }

        

        private void tablas_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Las tablas son la unidad basica de \n almacenamiento de datos en Oracle. Los datos son \n almacenados en filas y columnas. \n Se definen a traves de Nombre y \n Conjunto de Columnas(nombre,tipo)\n Al crear una tabla Oracle asigna un \n segmento de datos en el \n tablespace. Se puede controlar el \n espacio y el uso del mismo.";
        }

        private void view_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Los views son presentaciones modificadas para\nrequisitos particulares de datos en una o más\ntablas u otros views. Usted puede pensar en ellas \ncomo queries almacenados.Los views no contienen \nrealmente datos,sino que por el contrario\n derivan sus datos de las tablas sobre las cuales se\n basan. Estas tablas se refieren como las tabla base \ndel view.";
        }

        private void tablas_boton_Click(object sender, EventArgs e)
        {
            Form3 forma = new Form3(this);
            forma.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.Hide();

            Form1 fmr = new Form1();
          
            fmr.Close();

        }

        private void view_boton_Click(object sender, EventArgs e)
        {
            views v = new views(this);
            v.ShowDialog();
           

        }

        private void indices_boton_Click(object sender, EventArgs e)
        {
            indices idx = new indices();
           // this.Hide();
            idx.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql sq = new sql();
            sq.ShowDialog();
        }

        private void triggers_boton_Click(object sender, EventArgs e)
        {
            triggers tr = new triggers();
            tr.ShowDialog();
        }

        private void indices_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Los índices son estructuras opcionales asociadas \na las tablas. Usted puede crearlos para mejorar \nfuncionamiento de las consultas. Apenas pues el índice \nen este libro le ayuda a encontrar rápidamente la \ninformación específica, un índice de la base de datos\n Oracle proporciona un camino de acceso rápido a \nlos datos de la tabla. Antes de que usted agregue \níndices adicionales, examine el funcionamiento de su \n base de datos.Usted puede entonces comparar  \nfuncionamiento después de que se agreguen los nuevos \níndices.";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Le permite ingresar una secuencia de comandos \npara crear consultas de datos";
        }

        private void triggers_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Un Trigger de la base de datos es un procedimiento \nalmacenado asociado a una tabla de base de\n datos, a una visión, o a un acontecimiento.\nEl trigger se puede llamar una vez, \ncuando ocurre un cierto acontecimiento,\n o muchas veces,una vez para cada fila \nafectada por una declaración\n del INSERT,UPDATE, o de la DELETE.El trigger se\n puede llamar después del acontecimiento,\n para registrarlo, o tome una cierta acción \nde seguimiento.";
        }

        private void sequences_boton_Click(object sender, EventArgs e)
        {
            sequences sqc = new sequences();
            sqc.ShowDialog();

        }

        private void funciones_boton_Click(object sender, EventArgs e)
        {
            funciones fc = new funciones();
            fc.ShowDialog();

        }

        private void storepro_boton_Click(object sender, EventArgs e)
        {
            procedures pr = new procedures();
            pr.ShowDialog();
        }

        private void sequences_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Una secuencia es un objeto de base de\n datos que genera valores secuenciales \núnicos. Estos valores son de uso frecuente para\n las llaves primarias y únicas. Usando \nun generador de la secuencia proporcionar \nel valor para una llave primaria en\n una tabla garantiza que\n el valor dominante es único.";
        }

        private void funciones_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Los procedimientos almacenados y las \n funciones (subprogramas) se pueden compilar \n y almacenar en una base de datos XE de Oracle, \n lista para ser ejecutado. Una vez que está \n compilado, es un objeto del esquema conocido \n como un procedimiento almacenado o función\n  almacenada, que se pueden referir o llamaron \n cualquier número de épocas por los \n usos múltiples conectados con la base de datos \n XE de Oracle. Ambos procedimientos almacenados y \n funciones pueden aceptar parámetros cuando se \n ejecutan (llamado).";
        }

        private void storepro_boton_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "Los procedimientos almacenados y las \n funciones (subprogramas) se pueden compilar \n y almacenar en una base de datos XE de Oracle, \n lista para ser ejecutado. Una vez que está \n compilado, es un objeto del esquema conocido \n como un procedimiento almacenado o función\n  almacenada, que se pueden referir o llamaron \n cualquier número de épocas por los \n usos múltiples conectados con la base de datos \n XE de Oracle. Ambos procedimientos almacenados y \n funciones pueden aceptar parámetros cuando se \n ejecutan (llamado).";
        }


    }
}
