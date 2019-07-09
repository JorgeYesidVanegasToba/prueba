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
    public partial class AreaTrabajo : Form
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


        public AreaTrabajo()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();

        //llenenar comboBox

        //fin

        private void AreaTrabajo_Load(object sender, EventArgs e)
        {
            dataMostar.DataSource = sql.mostarDatos();
            sql.Llernarcmb(cmbPaisOrigen);
            sql.LlernarPaisDestino(cmbPaisDestino);
            sql.LlernarCiudadOrigen(cmbCiudadOrigen);
            sql.LlernarCiudadDestino(cmbCiudadDestino);

        }

        private void dataMostar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtID.Text = dataMostar.Rows.Count.ToString();
            if (sql.Insertar(txtID.Text, cmbCiudadOrigen.Text, cmbCiudadDestino.Text))
            {
                MessageBox.Show("Datos insertados");
                dataMostar.DataSource = sql.mostarDatos();
            }
            else { MessageBox.Show("Datos NO insertaos"); }
        }

        private void btnEliminrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCiudadDestino_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCiudadOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPaisDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            Operaciones area = new Operaciones();

            area.Show();
            this.Hide();
        }

        private void dataMostar_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            //para poder arrastrar el formulario sin bordes

            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
    }
}
