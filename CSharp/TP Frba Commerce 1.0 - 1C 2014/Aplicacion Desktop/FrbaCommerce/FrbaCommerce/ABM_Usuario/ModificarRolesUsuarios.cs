using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Usuario
{
    public partial class ModificarRolesUsuario : FormGrid
    {
        private List<string> rolesOriginales, rolesInhabilitados;
        public ModificarRolesUsuario(Form anterior)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(521, 366);
            ventanaAnterior = anterior;
            label1.Text += DatosUsuario.usuario;
        }

        private void FiltroRubros_Load(object sender, EventArgs e)
        {
            string comando = "select ltrim(rtrim(str(r.ID_Rol))) +'-  '+ r.Nombre " +
                "from THE_GRID.Rol r inner join THE_GRID.Roles_x_Usuario ru on " +
                "ru.ID_Rol = r.ID_Rol and ru.ID_User = " + DatosUsuario.usuario +
                " and ru.Inhabilitado = 0 order by 1";
            rolesOriginales = TG.ObtenerListado(comando);
            foreach (string nombreRol in rolesOriginales)
            {
                listBox2.Items.Add(nombreRol);
            }

            comando = "select ltrim(rtrim(str(r.ID_Rol))) +'-  '+ r.Nombre " +
                "from THE_GRID.Rol r inner join THE_GRID.Roles_x_Usuario ru on " +
                "ru.ID_Rol = r.ID_Rol and ru.ID_User = " + DatosUsuario.usuario +
                " and ru.Inhabilitado = 1 order by 1";

            listBox3.DataSource = rolesInhabilitados = TG.ObtenerListado(comando);

            comando = @"select ltrim(rtrim(str(r.ID_Rol))) +'-  '+ r.Nombre
            from THE_GRID.Rol r 
            where r.ID_Rol not in (select ru.ID_Rol from THE_GRID.Roles_x_Usuario ru 
            where ru.ID_User = " + DatosUsuario.usuario + @")
            and r.Inhabilitado = 0
            union
            select ltrim(rtrim(str(r.ID_Rol))) +'-  '+ r.Nombre 
            from THE_GRID.Rol r inner join THE_GRID.Roles_x_Usuario ru 
            on ru.ID_User = " + DatosUsuario.usuario + @"
            and ru.ID_Rol = r.ID_Rol
            and ru.Inhabilitado = 1
            and r.Inhabilitado = 0
            order by 1";
            foreach (string nombreRol in TG.ObtenerListado(comando))
            {
                listBox1.Items.Add(nombreRol);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
            button1.Enabled = false;
            //faltaria hacer un re ordenamiento alfabetico en las listboxs cada vez q se modifican
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.Remove(listBox2.SelectedItem);
            button2.Enabled = false;
            

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            volverAtras();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string comando;
            
            foreach (string rol in listBox2.Items)
            {
                if (!rolesOriginales.Contains(rol))
                {
                    if (rolesInhabilitados.Contains(rol))
                        comando = "update THE_GRID.Roles_x_Usuario " +
                            "set Inhabilitado = 0 where ID_User = " + DatosUsuario.usuario +
                            " and ID_Rol = " + dameCodRol(rol);
                    else
                        comando = "insert into THE_GRID.Roles_x_Usuario " +
                            "values(" + DatosUsuario.usuario + "," + dameCodRol(rol) + ",0)";                        
                    TG.realizarConsulta(comando);
                }
            }

            foreach (string rol in rolesOriginales)
            {
                if (!listBox2.Items.Contains(rol))
                {
                    comando = "update THE_GRID.Roles_x_Usuario " +
                            "set Inhabilitado = 1 where ID_User = " + DatosUsuario.usuario +
                            " and ID_Rol = " + dameCodRol(rol);
                    TG.realizarConsulta(comando);
                }
            }

            DatosUsuario.resetearDatosModif();
            volverAtras();
        }

        private string dameCodRol(string rol)
        {
            int i; string codRol = "";
            for (i = 0; i < rol.Length; i++)
            {
                if (rol[i] == '-') break;
                codRol += rol[i];        
            }
            return codRol;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0) button1_Click(null, null);
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count > 0) button2_Click(null, null);
        }
       
    }
}
