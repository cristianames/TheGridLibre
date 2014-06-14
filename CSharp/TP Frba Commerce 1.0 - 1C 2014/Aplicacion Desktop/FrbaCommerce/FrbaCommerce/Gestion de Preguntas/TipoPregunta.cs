using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class TipoPregunta : Form
    {
        
        
        public TipoPregunta()
        {
            InitializeComponent();
        }
        

        private void Pendientes_Load(object sender, EventArgs e)
        {

        }
        private void cargarDatos()
        {
            SqlConnection con = TG.conectar();
            SqlDataAdapter daGrilla = new SqlDataAdapter(@"select Pr.ID_Publicacion,P.Descripcion,Pregunta,Fecha_Pregunta from TG.Pregunta Pr, TG.Publicacion P
            where P.ID_Publicacion=Pr.ID_Publicacion AND P.ID_Vendedor = "+ "sa" +@" order by Fecha_Pregunta
            ", con);
            DataSet dsGrilla = new DataSet();
            daGrilla.Fill(dsGrilla, "gd_esquema.Maestra");
            gridPendientes.DataSource = dsGrilla.Tables[0];
            gridPendientes.DataMember = "gd_esquema.Maestra";
            //textBox1.Text = "SEP";
            con.Close();
        }

    }
}
