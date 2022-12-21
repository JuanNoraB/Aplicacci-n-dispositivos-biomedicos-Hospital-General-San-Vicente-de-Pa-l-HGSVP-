using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos
{
    public partial class Main_Dispositivos : Form
    {
        public Main_Dispositivos()
        {
            InitializeComponent();
        }

        private void Main_Dispositivos_Load(object sender, EventArgs e)
        {

        }

        private void hojaDeVidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hoja_de_vida frm = new Hoja_de_vida();
            frm.MdiParent = this;
            frm.Show();
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
