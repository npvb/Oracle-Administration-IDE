namespace Proyecto_TDB1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.triggers_boton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.funciones_boton = new System.Windows.Forms.Button();
            this.storepro_boton = new System.Windows.Forms.Button();
            this.sequences_boton = new System.Windows.Forms.Button();
            this.indices_boton = new System.Windows.Forms.Button();
            this.view_boton = new System.Windows.Forms.Button();
            this.tablas_boton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(668, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mENUToolStripMenuItem.Text = "MENU";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(304, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(350, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // triggers_boton
            // 
            this.triggers_boton.BackColor = System.Drawing.Color.Lavender;
            this.triggers_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggers_boton.Location = new System.Drawing.Point(152, 43);
            this.triggers_boton.Margin = new System.Windows.Forms.Padding(4);
            this.triggers_boton.Name = "triggers_boton";
            this.triggers_boton.Size = new System.Drawing.Size(120, 60);
            this.triggers_boton.TabIndex = 5;
            this.triggers_boton.Text = "Triggers";
            this.triggers_boton.UseVisualStyleBackColor = false;
            this.triggers_boton.Click += new System.EventHandler(this.triggers_boton_Click);
            this.triggers_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.triggers_boton_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Image = global::Proyecto_TDB1.Properties.Resources.Log_out_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(628, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 37);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.Image = global::Proyecto_TDB1.Properties.Resources.SQL;
            this.button2.Location = new System.Drawing.Point(16, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 52);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // funciones_boton
            // 
            this.funciones_boton.BackColor = System.Drawing.Color.Lavender;
            this.funciones_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funciones_boton.Image = global::Proyecto_TDB1.Properties.Resources.funct_48;
            this.funciones_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funciones_boton.Location = new System.Drawing.Point(152, 168);
            this.funciones_boton.Margin = new System.Windows.Forms.Padding(4);
            this.funciones_boton.Name = "funciones_boton";
            this.funciones_boton.Size = new System.Drawing.Size(120, 46);
            this.funciones_boton.TabIndex = 8;
            this.funciones_boton.Text = "Funciones";
            this.funciones_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.funciones_boton.UseVisualStyleBackColor = false;
            this.funciones_boton.Click += new System.EventHandler(this.funciones_boton_Click);
            this.funciones_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.funciones_boton_MouseMove);
            // 
            // storepro_boton
            // 
            this.storepro_boton.BackColor = System.Drawing.Color.Lavender;
            this.storepro_boton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.storepro_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storepro_boton.Image = global::Proyecto_TDB1.Properties.Resources.Flow_block;
            this.storepro_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.storepro_boton.Location = new System.Drawing.Point(152, 226);
            this.storepro_boton.Margin = new System.Windows.Forms.Padding(4);
            this.storepro_boton.Name = "storepro_boton";
            this.storepro_boton.Size = new System.Drawing.Size(120, 52);
            this.storepro_boton.TabIndex = 7;
            this.storepro_boton.Text = "Store \r\nProcedures";
            this.storepro_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.storepro_boton.UseVisualStyleBackColor = false;
            this.storepro_boton.Click += new System.EventHandler(this.storepro_boton_Click);
            this.storepro_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.storepro_boton_MouseMove);
            // 
            // sequences_boton
            // 
            this.sequences_boton.BackColor = System.Drawing.Color.Lavender;
            this.sequences_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sequences_boton.Image = global::Proyecto_TDB1.Properties.Resources.Diagram;
            this.sequences_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sequences_boton.Location = new System.Drawing.Point(152, 111);
            this.sequences_boton.Margin = new System.Windows.Forms.Padding(4);
            this.sequences_boton.Name = "sequences_boton";
            this.sequences_boton.Size = new System.Drawing.Size(120, 49);
            this.sequences_boton.TabIndex = 6;
            this.sequences_boton.Text = "Sequences";
            this.sequences_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sequences_boton.UseVisualStyleBackColor = false;
            this.sequences_boton.Click += new System.EventHandler(this.sequences_boton_Click);
            this.sequences_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sequences_boton_MouseMove);
            // 
            // indices_boton
            // 
            this.indices_boton.BackColor = System.Drawing.Color.Lavender;
            this.indices_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indices_boton.Image = global::Proyecto_TDB1.Properties.Resources.index;
            this.indices_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.indices_boton.Location = new System.Drawing.Point(16, 169);
            this.indices_boton.Margin = new System.Windows.Forms.Padding(4);
            this.indices_boton.Name = "indices_boton";
            this.indices_boton.Size = new System.Drawing.Size(100, 45);
            this.indices_boton.TabIndex = 4;
            this.indices_boton.Text = "Indices";
            this.indices_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indices_boton.UseVisualStyleBackColor = false;
            this.indices_boton.Click += new System.EventHandler(this.indices_boton_Click);
            this.indices_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.indices_boton_MouseMove);
            // 
            // view_boton
            // 
            this.view_boton.BackColor = System.Drawing.Color.Lavender;
            this.view_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_boton.Image = global::Proyecto_TDB1.Properties.Resources.Search_48;
            this.view_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.view_boton.Location = new System.Drawing.Point(16, 111);
            this.view_boton.Margin = new System.Windows.Forms.Padding(4);
            this.view_boton.Name = "view_boton";
            this.view_boton.Size = new System.Drawing.Size(100, 50);
            this.view_boton.TabIndex = 3;
            this.view_boton.Text = "Views";
            this.view_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.view_boton.UseVisualStyleBackColor = false;
            this.view_boton.Click += new System.EventHandler(this.view_boton_Click);
            this.view_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.view_boton_MouseMove);
            // 
            // tablas_boton
            // 
            this.tablas_boton.BackColor = System.Drawing.Color.Lavender;
            this.tablas_boton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablas_boton.Image = ((System.Drawing.Image)(resources.GetObject("tablas_boton.Image")));
            this.tablas_boton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tablas_boton.Location = new System.Drawing.Point(16, 43);
            this.tablas_boton.Margin = new System.Windows.Forms.Padding(4);
            this.tablas_boton.Name = "tablas_boton";
            this.tablas_boton.Size = new System.Drawing.Size(100, 60);
            this.tablas_boton.TabIndex = 2;
            this.tablas_boton.Text = "Tablas";
            this.tablas_boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tablas_boton.UseVisualStyleBackColor = false;
            this.tablas_boton.Click += new System.EventHandler(this.tablas_boton_Click);
            this.tablas_boton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tablas_boton_MouseMove);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(668, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.funciones_boton);
            this.Controls.Add(this.storepro_boton);
            this.Controls.Add(this.sequences_boton);
            this.Controls.Add(this.triggers_boton);
            this.Controls.Add(this.indices_boton);
            this.Controls.Add(this.view_boton);
            this.Controls.Add(this.tablas_boton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "OPERACIONES";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tablas_boton;
        private System.Windows.Forms.Button view_boton;
        private System.Windows.Forms.Button indices_boton;
        private System.Windows.Forms.Button triggers_boton;
        private System.Windows.Forms.Button sequences_boton;
        private System.Windows.Forms.Button storepro_boton;
        private System.Windows.Forms.Button funciones_boton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}