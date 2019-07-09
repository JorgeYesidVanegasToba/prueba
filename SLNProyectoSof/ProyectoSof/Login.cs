using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProyectoSof
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightSalmon;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnIngresar_Enter(object sender, EventArgs e)
        {

        }

        private void txtCont_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                txtUsuario.Text = "USUARIO";
                txtCont.ForeColor = Color.LightGray;

            }
        }

        private void txtCont_Move(object sender, EventArgs e)
        {
            
        }

        private void txtCont_Leave(object sender, EventArgs e)
        {
            if (txtCont.Text == "CONTRASEÑA")
            {
                txtCont.Text = "";
                txtCont.ForeColor = Color.LightSalmon;
                txtCont.UseSystemPasswordChar = false;
            }
        }

        private void txtCont_Enter(object sender, EventArgs e)
        {
            if (txtCont.Text == "CONTRASEÑA")
            {
                txtCont.Text = "";
                txtCont.ForeColor = Color.LightSalmon;
                txtCont.UseSystemPasswordChar = true;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(txtCont.Text))
            {
                try
                {
                    ConsultasSQL bd = new ConsultasSQL();
                    Boolean res = bd.iniciarSesion(txtUsuario.Text, txtCont.Text);
                    if (res)
                    {
                        Principal1 p = new Principal1();
                        p.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorectos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete los datos");
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
