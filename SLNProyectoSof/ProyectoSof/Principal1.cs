using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoSof
{
    public partial class Principal1 : Form
    {

        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Rectangle sizeGripRectangle;
        bool inSizeDrag = false;
        const int GRIP_SIZE = 15;

        int w = 0;
        int h = 0;
        #endregion

        public Principal1()
        {
            InitializeComponent();
        }



        ConsultasSQL sql = new ConsultasSQL();

        //otros metodos
        private void CargarUsuarios()
        {
           
        }
        //fin de otros metodos;

        private void btnPacient_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AreaTrabajo area = new AreaTrabajo();

            area.Show();
            this.Hide();
        }

        private void Principal1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            //para poder arrastrar el formulario sin bordes

            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
