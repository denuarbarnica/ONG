using ONG.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONG.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var desaparecidosBL = new DesaparecidosBL();
            var listadeDesaparecidos = desaparecidosBL.ObtenerDesaparecidos();

            foreach (var desaparecido in listadeDesaparecidos)
            {
                MessageBox.Show(desaparecido.Primer_Nombre);

            }
        }
    }
}
