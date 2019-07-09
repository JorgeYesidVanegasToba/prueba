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
    public partial class Operaciones : Form
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

        public Operaciones()
        {
            InitializeComponent();
        }

        ConsultasSQL sql = new ConsultasSQL();


        private void btnPacient_Click(object sender, EventArgs e)
        {
            
        }
        private void dataMostar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataMostar.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(fila.Cells[0].Value);
            txtCiudadOrigen.Text = Convert.ToString(fila.Cells[1].Value);
            txtCiudadDestino.Text = Convert.ToString(fila.Cells[2].Value);
        }

        private void dataMostar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AreaTrabajo area = new AreaTrabajo();

            area.Show();
            this.Hide();

        }

        private void btnEliminrar_Click(object sender, EventArgs e)
        {
            if (sql.Eliminar(txtID.Text))
            {
                MessageBox.Show("Datos Eliminados");
                dataMostar.DataSource = sql.mostarDatos();
            }
            else { MessageBox.Show("Los datos No fueron eliminados"); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (sql.Actulaizar(txtID.Text, txtCiudadOrigen.Text, txtCiudadDestino.Text))
            {
                MessageBox.Show("Datos actulaizados");
                dataMostar.DataSource = sql.mostarDatos();
            }
            else { MessageBox.Show("los datos No fueron actualizados"); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                dataMostar.DataSource = sql.Buscar(txtBuscar.Text);
            }
            else dataMostar.DataSource = sql.mostarDatos();
        }

        private void Operaciones_Load(object sender, EventArgs e)
        {
            dataMostar.DataSource = sql.mostarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            //para poder arrastrar el formulario sin bordes

            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Text = dataMostar.Rows.Count.ToString();
            if (sql.Insertar(txtID.Text, txtCiudadOrigen.Text, txtCiudadDestino.Text))
            {
                MessageBox.Show("Datos insertados");
                dataMostar.DataSource = sql.mostarDatos();
            }
            else { MessageBox.Show("Datos NO insertaos"); }
        }
    }
}
