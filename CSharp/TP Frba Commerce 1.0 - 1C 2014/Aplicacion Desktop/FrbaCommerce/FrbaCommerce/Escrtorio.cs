using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Escrtorio : Form
    {
        public Escrtorio()
        {
            InitializeComponent();
            /*
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.Size = new System.Drawing.Size(115, 20);
            int i;
            for (i = 0; i < 12; i++ ){
                this.tableLayoutPanel1.RowCount = this.tableLayoutPanel1.RowCount + 1;
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                this.tableLayoutPanel1.Size = new System.Drawing.Size(115, tableLayoutPanel1.Height + 20);
            }*/
            this.ClientSize = new System.Drawing.Size(167, 319);
            string comando = "SELECT Nombre FROM TG.Funcionalidades_x_Rol F WHERE R.ID_Rol = " +
                TG.codigoRol.ToString();
            listBox1.DataSource = TG.ObtenerListado(comando);
        }

        private void Escrtorio_Load(object sender, EventArgs e)
        {

        }
    }
}
