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
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hoja_de_vida frm = new Hoja_de_vida();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.Show();
        }
    }
}
