using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apMatrizEsparsa
{
    public partial class frmMatriz : Form
    {
        ListaCruzada matrizEsparsa;
        public frmMatriz()
        {
            InitializeComponent();
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
            // matrizEsparsa = new ListaCruzada();
        }

        private void btnLerMatrizA_Click(object sender, EventArgs e)
        {
            LerMatriz(arq, dgvA);
        }


        public void LerMatriz(string arq, DataGridView dgv)
        {

        }
    }
}
